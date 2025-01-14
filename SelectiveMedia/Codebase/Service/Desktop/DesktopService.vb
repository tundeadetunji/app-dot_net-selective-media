Public Class DesktopService
#Region "Init"
    Public Shared ReadOnly Property Instance As New DesktopService
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
	Friend Sub SetWallpaper(ByVal img As String)

		Dim imageLocation As String

		imageLocation = img

		Try

			'img.Save(imageLocation, System.Drawing.Imaging.ImageFormat.Bmp)

			SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)

		Catch Ex As Exception

			'			MsgBox("There was an error setting the wallpaper: " & Ex.Message)

		End Try

	End Sub

#End Region
End Class
