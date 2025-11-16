Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class DesktopService
    Implements IDesktopService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As DesktopService = New DesktopService
    Private Sub New()

    End Sub
#End Region

#Region "Properties"

    Private Const SPI_SETDESKWALLPAPER As Integer = &H14

    Private Const SPIF_UPDATEINIFILE As Integer = &H1
    Private Const SPIF_SENDWININICHANGE As Integer = &H2

    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

#End Region

#Region "Exported"

    Public Sub SetWallpaper(ByVal imageLocation As String) Implements IDesktopService.SetWallpaper
        Try
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        Catch Ex As Exception

        End Try

    End Sub

    Public Sub StartTheApps(file As String) Implements IDesktopService.StartTheApps
        Dim file_content As String = ReadText(file)
        If String.IsNullOrEmpty(file_content) Then Return
        Dim apps As List(Of String) = StringToList(file_content)
        If apps.Count < 1 Then Return
        For Each app As String In apps
            StartFile(app.Trim)
        Next
    End Sub
    Public Sub StartTheApps(apps As List(Of String)) Implements IDesktopService.StartTheApps
        If apps.Count < 1 Then Return
        For Each app As String In apps
            StartFile(app.Trim)
        Next
    End Sub


#End Region
End Class
