Module General

    ' Variables globales
    Public UserStr As String
    Public Sucursal As Integer
    Public SucStr As String
    Public Cdir As String
    Public SDBName As String
    Public SDBDir As String
    Public WinDir As String
    Public Line1 As String
    Public Paso As Integer

    Public Mensaje As String
    Public Respuesta As Integer
    Public Criterio As String
    Public Criterio1 As String

    Public TotDebe As Decimal
    Public Tothaber As Decimal
    Public Saldo As Decimal

    Public Usuario As String
    Public EsAdmin As Boolean
    Public ClaveErronea As Boolean
    Public CantIntentos As Integer

    Public Pedido As Integer

    Public txtLocal As String
    Public txtNet As String

    ' API declarations
    <System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Public Function GetWindowsDirectory(ByVal lpBuffer As System.Text.StringBuilder, ByVal nSize As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("advapi32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Public Function GetUserName(ByVal lpBuffer As System.Text.StringBuilder, ByRef nSize As Integer) As Integer
    End Function

End Module
