Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class AppService

#Region "Support"
	Private Sub SetPermissions()

        PermitFolder(My.Application.Info.DirectoryPath)

    End Sub


#End Region

#Region "Exported"

	''' <summary>
	''' All files are in place and locations are valid
	''' </summary>
	''' <returns></returns>
	Public Function CanStart(dialog As IDialogResource) As Boolean
		'Todo
	End Function

	Public Sub Start(dialog As IDialogResource, disk As DiskService, settings As SettingsService)
		SetPermissions()

		If GetPeriod(dialog, disk, settings) = Period.Day Then
			dialog.GetDayTimer.Enabled = True
		Else
			dialog.GetNightTimer.Enabled = True
		End If

		dialog.GetMediaTimer.Enabled = True

	End Sub


	Public Function GetPeriod(dialog As IDialogResource, disk As DiskService, settings As SettingsService) As Period
		If Date.Parse(Now.ToShortTimeString) >= Date.Parse(settings.GetBeginTime(disk)).ToShortTimeString And Date.Parse(Now.ToShortTimeString) <= Date.Parse(settings.GetEndTime(disk)).ToShortTimeString Then
			Return Period.Day
		Else
			Return Period.Night
		End If
	End Function
	Public Sub PrepDay(dialog As IDialogResource, desktop As DesktopService, disk As DiskService, settings As SettingsService)
		Dim wallpapers As List(Of String) = disk.GetWallpapers
		Dim wallpaper As String = wallpapers(Random_(0, wallpapers.Count))
		desktop.SetWallpaper(wallpaper)
		StartApps(ReadText(programs_))
	End Sub

	Public Sub PrepNight()
		'adult films, theme
		'my widgets, vg
		WTimer.Enabled = False
		''Try
		''	Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\My Widgets\Picture Frame.widget")
		''Catch ex As Exception
		''End Try
		Try
			PickWallpaper("n")
		Catch ex As Exception
		End Try
		'open other programs
		StartApps(ReadText(programs_alternate))
	End Sub

#End Region
End Class
