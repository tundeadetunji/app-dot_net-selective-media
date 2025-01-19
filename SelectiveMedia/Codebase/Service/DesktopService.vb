Public Class DesktopService

#Region "Properties"
	Private Const SPI_SETDESKWALLPAPER As Integer = &H14

	Private Const SPIF_UPDATEINIFILE As Integer = &H1
	Private Const SPIF_SENDWININICHANGE As Integer = &H2

	Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

#End Region

#Region "Support"
	Private Sub PickWallpaper(periodOfDay As Period)
		'		Try
		Select Case t_.ToLower
			Case "d"
				'If Random_(1, 11) < 5 Then
				WriteFileCounter("e", WhichFileE(L5))
				SetWallpaper(L5.Items.Item(FileCounterE()))
			'Else
			'Try
			'Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\Windows\Themes\dtheme.theme")
			'Catch ex As Exception
			'WriteFileCounter("e", WhichFileE(L5))
			'SetWallpaper(L5.Items.Item(FileCounterE()))
			'End Try
			'End If
			Case "n"
		End Select
		'		Catch
		'		End Try
		'		Dim r_val_ As Integer = Random_(0, L4.Items.Count - 1)
		'		SetWallpaper(L4.Items.Item(r_val_))
	End Sub

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

	Public Function PlayerIsOn(disk As DiskService) As Boolean
		'		Dim p() As Process = Process.GetProcessesByName(WhichPlayer)
		'		PlayerIsOn = p.Count > 0
		Return AppIsOn(cPlayer.Text)

	End Function



#End Region
End Class
