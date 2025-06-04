Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports ADODB
'Imports Microsoft.Office.Interop

Module Funciones

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure

    <DllImport("mpr.dll", CharSet:=CharSet.Ansi)>
    Private Function WNetAddConnection2(ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer
    End Function

    <DllImport("mpr.dll", CharSet:=CharSet.Ansi)>
    Private Function WNetCancelConnection2(ByVal lpName As String, ByVal dwFlags As Integer, ByVal fForce As Integer) As Integer
    End Function

    ' Constantes
    Private Const NO_ERROR As Integer = 0
    Private Const CONNECT_UPDATE_PROFILE As Integer = &H1
    Private Const RESOURCETYPE_DISK As Integer = &H1
    Private Const RESOURCETYPE_PRINT As Integer = &H2
    Private Const RESOURCETYPE_ANY As Integer = &H0
    Private Const RESOURCE_CONNECTED As Integer = &H1
    Private Const RESOURCE_REMEMBERED As Integer = &H3
    Private Const RESOURCE_GLOBALNET As Integer = &H2
    Private Const RESOURCEDISPLAYTYPE_DOMAIN As Integer = &H1
    Private Const RESOURCEDISPLAYTYPE_GENERIC As Integer = &H0
    Private Const RESOURCEDISPLAYTYPE_SERVER As Integer = &H2
    Private Const RESOURCEDISPLAYTYPE_SHARE As Integer = &H3
    Private Const RESOURCEUSAGE_CONNECTABLE As Integer = &H1
    Private Const RESOURCEUSAGE_CONTAINER As Integer = &H2

    ' Variables que se asumen globales
    Public txtLocal As String
    Public txtNet As String
    Public UserStr As String

    ' Asumimos que MDB y SDB son conexiones DAO o ADODB
    Public MDB As Object
    Public SDB As Object
    Public MiSql As String
    Public MiRs As Object
    Public MiRs9 As Recordset
    Public cnStock As ADODB.Connection
    Dim memUbicacion As Integer

    ' Traducción de funciones
    Public Sub CentrarMain(ByVal ventana As Form)
        ventana.Left = (frmMain.Width - ventana.Width) / 2
        ventana.Top = (frmMain.Height - ventana.Height) / 3
    End Sub

    Public Sub CentrarScreen(ByVal ventana As Form)
        ventana.Left = (Screen.PrimaryScreen.Bounds.Width - ventana.Width) / 2
        ventana.Top = (Screen.PrimaryScreen.Bounds.Height - ventana.Height) / 2
    End Sub

    Public Function IdArticulo(ByVal Empresa As String, ByVal Articulo As Double) As Double
        IdArticulo = 0
        MiSql = $"Select IdArticulo from [MAESTK] where Empresa = '{Trim(Empresa)}' AND Articulo = {Trim(Articulo.ToString())};"
        MiRs = SDB.OpenRecordset(MiSql, 4) ' dbOpenSnapshot = 4
        If MiRs.RecordCount > 0 Then
            IdArticulo = MiRs!IdArticulo
        End If
    End Function

    Public Sub LlenarCombo(ByVal Tabla As String, ByVal Campo As String, ByVal Combo As ComboBox, ByVal Were As String)
        Combo.Items.Clear()
        MiSql = $"Select {Campo.Trim()} from {Tabla.Trim()} Where "
        If Were <> "" Then
            MiSql &= Were & " and "
        End If
        If Tabla = "DetaStk" Then
            MiSql &= "MesAnterior = false and "
        End If
        MiSql = Left(MiSql, MiSql.Length - 6) & $"GROUP BY {Campo.Trim()} ORDER BY {Campo.Trim()};"
        MiRs = SDB.OpenRecordset(MiSql, 4)
        If MiRs.RecordCount > 0 Then
            MiRs.MoveFirst()
            Do While Not MiRs.EOF
                If Not IsDBNull(MiRs.Fields(Campo)) Then
                    Combo.Items.Add(MiRs.Fields(Campo).Value)
                End If
                MiRs.MoveNext()
            Loop
        End If
    End Sub

    Public Function SacarNombre(ByVal path As String) As String
        If path.EndsWith("\") Then Return ""
        For i = path.Length To 1 Step -1
            If Mid(path, i, 1) = "\" Then
                memUbicacion = i + 1
                Exit For
            End If
        Next
        Return Mid(path, memUbicacion)
    End Function

    Public Function SacarPath(ByVal path As String) As String
        If path.EndsWith("\") Then
            Return Left(path, path.Length - 1)
        End If
        For i = path.Length To 1 Step -1
            If Mid(path, i, 1) = "\" Then
                memUbicacion = i - 1
                Exit For
            End If
        Next
        Return Left(path, memUbicacion)
    End Function

    Public Sub TratarErrores(ByVal NroError As Long)
        Select Case Err.Number
            Case 3022
                MsgBox("Las bases no necesitan inicializarse")
            Case Else
                MsgBox("Ha ocurrido un error. Consulte STOCKLOG.TXT para mas datos")
                FileOpen(1, "..\StockLog.txt", OpenMode.Append)
                WriteLine(1, $"[{Now}] Error {NroError}: {Err.Description}")
                FileClose(1)
        End Select
    End Sub

    Public Sub BotonesModoEdicion(ByVal formulario As Form)
        For Each kontrol As Control In formulario.Controls
            Select Case kontrol.Name
                Case "cmdAceptar", "cmdCancelar", "PanelDatos", "PanelDatos1", "PanesDatos2"
                    kontrol.Enabled = True
                Case "cmdModificar", "cmdAgregar", "cmdBorrar"
                    kontrol.Enabled = False
            End Select
        Next
    End Sub

    Public Function Hoy(ByVal que As Integer) As String
        Select Case que
            Case 0 : Return DateTime.Now.Date.ToShortDateString()
            Case 1 : Return DateTime.Now.ToShortTimeString()
            Case 2 : Return DateTime.Now.ToString()
        End Select
        Return ""
    End Function

    Public Sub BotonesModoNormal(ByVal formulario As Form)
        For Each kontrol As Control In formulario.Controls
            Select Case kontrol.Name
                Case "cmdAceptar", "cmdCancelar", "PanelDatos", "PanelDatos1", "PanesDatos2"
                    kontrol.Enabled = False
                Case "cmdModificar", "cmdAgregar", "cmdBorrar"
                    kontrol.Enabled = True
            End Select
        Next
    End Sub

    Public Sub FiltrarErrores()
        MsgBox($"El error ocurrido es : {Err.Number} {Err.Description}")
    End Sub

    Public Function InsertarRegistrosDeTablaExcel(ByVal nArchivo As String, ByVal nRango As String, ByVal nTabla As String) As Integer
        Try
            MiSql = $"INSERT INTO [{nTabla}] SELECT * FROM [{nRango}] IN '{nArchivo}' 'EXCEL 4.0;'"
            MDB.Execute(MiSql, 128) ' dbFailOnError = 128
            Return MDB.RecordsAffected
        Catch ex As Exception
            TratarErrores(Err.Number)
            Return 0
        End Try
    End Function

    Public Sub cmdAdd()
        Dim netR As NETRESOURCE
        Dim errInfo As Long
        Dim myPass As String = ""
        Dim myUser As String = ""
        Dim sPath As String = CurDir()

        netR.dwScope = RESOURCE_GLOBALNET
        netR.dwType = RESOURCETYPE_DISK
        netR.dwDisplayType = RESOURCEDISPLAYTYPE_SHARE
        netR.dwUsage = RESOURCEUSAGE_CONNECTABLE
        netR.lpLocalName = txtLocal
        netR.lpRemoteName = txtNet

        errInfo = WNetAddConnection2(netR, myPass, myUser, CONNECT_UPDATE_PROFILE)
        If errInfo <> NO_ERROR Then
            MsgBox($"ERROR: {errInfo} - Net Connection Failed!", MsgBoxStyle.Exclamation, "Share not Connected")
        End If
    End Sub

    Public Sub cmdCancel()
        Dim errInfo As Long
        Dim strLocalName As String = txtLocal

        errInfo = WNetCancelConnection2(strLocalName, CONNECT_UPDATE_PROFILE, 1)
        If errInfo <> NO_ERROR Then
            MsgBox($"ERROR: {errInfo} - Net Disconnection Failed!", MsgBoxStyle.Exclamation, "Share not Disconnected")
        End If
    End Sub

    Public Sub ControlaZ()
        Dim fs As Object = CreateObject("Scripting.FileSystemObject")
        txtNet = "\\pctvvip\temp"
        txtLocal = "Z:"
        Dim ruta As Boolean = fs.driveexists(txtNet)

        If ruta = False Then
            txtNet = "\\192.168.2.56\temp"
            txtLocal = "Z:"
            fs = CreateObject("Scripting.FileSystemObject")
            ruta = fs.driveexists(txtNet)
        End If

        Dim fs1 As Object = CreateObject("Scripting.FileSystemObject")
        Dim unidad As Boolean = fs1.driveexists("Z:")

        cnStock = New ADODB.Connection
        cnStock.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=stock;Data Source=SERVERNT"
        cnStock.Open()

        MiSql = $"Select * from autoriza where usuario ='{UserStr}';"
        MiRs9 = New Recordset()
        MiRs9.CursorLocation = CursorLocationEnum.adUseClient
        MiRs9.Open(MiSql, cnStock, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly)

        If MiRs9.RecordCount > 0 Then
            If ruta And Not unidad And MiRs9!verC Then cmdAdd()
            If ruta And unidad And Not MiRs9!verC Then cmdCancel()
            If Not ruta And unidad And Not MiRs9!verC Then cmdCancel()
            If Not ruta And unidad And MiRs9!verC Then cmdCancel()
        Else
            If unidad Then cmdCancel()
        End If
    End Sub

End Module
