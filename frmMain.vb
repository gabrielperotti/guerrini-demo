Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Partial Public Class frmMain
    Inherits Form

    Public cnStock As ADODB.Connection
    Public MiRs9 As ADODB.Recordset
    Private strBuffer As New StringBuilder(256)
    Private SDBDir As String = ""
    Private UserStr As String = ""

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetWindowsDirectory(ByVal lpBuffer As StringBuilder, ByVal nSize As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetUserName(ByVal lpBuffer As StringBuilder, ByRef nSize As Integer) As Boolean
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()

        Me.Top = 1
        Me.Left = 1

        Dim bufferSize As Integer = strBuffer.Capacity
        GetUserName(strBuffer, bufferSize)

        Dim Line1 As String
        Dim WinDirBuilder As New StringBuilder(256)
        bufferSize = GetWindowsDirectory(WinDirBuilder, WinDirBuilder.Capacity)
        Dim WinDir As String = WinDirBuilder.ToString().Substring(0, bufferSize)

        If Not File.Exists(Path.Combine(WinDir, "Sistema.ini")) Then
            MessageBox.Show("No se encuentra archivo INI.", "Soporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Mostrar frmEditar si existe
            End
        End If

        Using reader As New StreamReader(Path.Combine(WinDir, "Sistema.ini"))
            While Not reader.EndOfStream
                Line1 = reader.ReadLine()
                If Line1.StartsWith("Camino=") Then
                    SDBDir = Line1.Substring(7)
                    Exit While
                End If
            End While
            While Not reader.EndOfStream
                Line1 = reader.ReadLine()
                If Line1.StartsWith("UsuDefault=") Then
                    UserStr = Line1.Substring(11)
                    Exit While
                End If
            End While
        End Using

        Me.Text = "Menu Principal del Sistema"
    End Sub

    Private Sub Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ControlaZ()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ControlaZ()
    End Sub

    Private Sub RunModule(folder As String, exeName As String)
        Try
            Dim fullPath As String = Path.Combine(SDBDir, folder, exeName)
            If File.Exists(fullPath) Then
                Process.Start(fullPath)
            Else
                MessageBox.Show($"No se encontró el ejecutable: {fullPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    ' Eventos de botones
    Private Sub cmdFacturacion_Click(sender As Object, e As EventArgs) Handles cmdFacturacion.Click
        RunModule("Facturacion", "Factura.exe")
    End Sub

    Private Sub cmdStock_Click(sender As Object, e As EventArgs) Handles cmdStock.Click
        RunModule("Stock", "Stock.exe")
    End Sub

    Private Sub cmdCtaCte_Click(sender As Object, e As EventArgs) Handles cmdCtaCte.Click
        RunModule("CtaCte", "CtaCte.exe")
    End Sub

    Private Sub cmdProveedores_Click(sender As Object, e As EventArgs) Handles cmdProveedores.Click
        RunModule("Proveedores", "Provee.exe")
    End Sub

    Private Sub cmdContabilidad_Click(sender As Object, e As EventArgs) Handles cmdContabilidad.Click
        RunModule("Contabilidad", "Conta.exe")
    End Sub

    Private Sub cmdPersonal_Click(sender As Object, e As EventArgs) Handles cmdPersonal.Click
        RunModule("Reloj", "Reloj.exe")
    End Sub

    Private Sub Cmdmigrador_Click(sender As Object, e As EventArgs) Handles Cmdmigrador.Click
        'RunModule("ControlCaja", "caja.exe")
        MessageBox.Show(" no implementado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmdSeguridad_Click(sender As Object, e As EventArgs) Handles cmdSeguridad.Click
        RunModule("Seguridad", "Seguridad.exe")
    End Sub

    Private Sub cmdBancos_Click(sender As Object, e As EventArgs) Handles cmdBancos.Click
        RunModule("Bancos", "Bancos.exe")
    End Sub

    Private Sub cmdProce_Click(sender As Object, e As EventArgs) Handles cmdProce.Click
        Try
            Dim origen1 = "F:\\PROCEDIMIENTOS\\PROCE.PDF"
            Dim destino1 = "C:\\SISTEMA\\PROCEDIMIENTOS\\PROCE.PDF"
            If File.Exists(origen1) Then File.Copy(origen1, destino1, True)

            Dim origen2 = "F:\\PROCEDIMIENTOS\\FORMULARIOSRRHH.PDF"
            Dim destino2 = "C:\\SISTEMA\\PROCEDIMIENTOS\\FORMULARIOSRRHH.PDF"
            If File.Exists(origen2) Then File.Copy(origen2, destino2, True)

            Process.Start("rundll32.exe", "url.dll,FileProtocolHandler """ & destino1 & """")
            Process.Start("rundll32.exe", "url.dll,FileProtocolHandler """ & destino2 & """")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdGacetilla_Click(sender As Object, e As EventArgs) Handles cmdGacetilla.Click
        Try
            Dim origen = "F:\\PROCEDIMIENTOS\\Gacetilla.PDF"
            Dim destino = "C:\\SISTEMA\\PROCEDIMIENTOS\\Gacetilla.PDF"
            If File.Exists(origen) Then File.Copy(origen, destino, True)
            Process.Start("rundll32.exe", "url.dll,FileProtocolHandler """ & destino & """")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmsalir_Click(sender As Object, e As EventArgs) Handles cmsalir.Click
        Me.Close()
    End Sub

    ' Placeholder de la función ControlaZ()
    Private Sub ControlaZ()
        ' Aquí va la lógica que tenías en VB6 para revisar conexión Z:
        ' Se puede adaptar si querés montar unidades, validar red, etc.
        Console.WriteLine("ControlaZ() ejecutado")
    End Sub
End Class
