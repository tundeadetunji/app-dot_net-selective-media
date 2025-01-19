Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Drawing
Imports System.Runtime.InteropServices
Public Class DesktopService

#Region "Initialization"
	Public Shared ReadOnly Property Instance As DesktopService = New DesktopService
	Private Sub New()

	End Sub
#End Region

#Region "Properties"

	' Import the SystemParametersInfo function from user32.dll
	<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
	Private Shared Function SystemParametersInfo(uAction As UInteger, uParam As UInteger, lpvParam As String, fuWinIni As UInteger) As Boolean
	End Function

	' Constants for setting wallpaper style
	Private Const SPI_SETDESKWALLPAPER As UInteger = 20
	Private Const SPIF_UPDATEINIFILE As UInteger = &H1
	Private Const SPIF_SENDCHANGE As UInteger = &H2
	Private Const WALLPAPER_STYLE_FILL As String = "10" ' Fill
	Private Const WALLPAPER_STYLE_TILE As String = "0"  ' Tile


	'Private Const SPI_SETDESKWALLPAPER As Integer = &H14

	'Private Const SPIF_UPDATEINIFILE As Integer = &H1
	'Private Const SPIF_SENDWININICHANGE As Integer = &H2

	'Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

#End Region

#Region "Exported"

	Public Sub SetWallpaper(imagePath As String)
		If Not IO.File.Exists(imagePath) Then Return

		' Get the dimensions of the image
		Using img As Image = Image.FromFile(imagePath)
			Dim width As Integer = img.Width
			Dim height As Integer = img.Height

			' Determine the wallpaper style based on the dimensions
			Dim style As String
			If width > height Then
				style = WALLPAPER_STYLE_FILL
			Else
				style = WALLPAPER_STYLE_TILE
			End If

			' Set the wallpaper style in the registry
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "WallpaperStyle", style)
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "TileWallpaper", If(style = WALLPAPER_STYLE_TILE, "1", "0"))

			' Set the wallpaper
			SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
		End Using
	End Sub

	'Friend Sub SetWallpaper(ByVal img As String)
	'	''Todo adjust for landscape/portrait

	'	Dim imageLocation As String

	'	imageLocation = img

	'	Try

	'		'img.Save(imageLocation, System.Drawing.Imaging.ImageFormat.Bmp)

	'		SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)

	'	Catch Ex As Exception

	'		'			MsgBox("There was an error setting the wallpaper: " & Ex.Message)

	'	End Try

	'End Sub

	Public Sub StartTheApps(file As String)
		Dim apps As List(Of String) = StringToList(file)
		If apps.Count < 1 Then Return
		For Each app As String In apps
			StartFile(app)
		Next
	End Sub


#End Region
End Class
