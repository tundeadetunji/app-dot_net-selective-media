Imports iNovation.Code.General
Imports iNovation.Code.GeneralExtensions
Imports iNovation.Code.Desktop
Imports SelectiveMedia.Constants
Imports iNovation.Code
Public Class AppService

#Region "Initialization"
	Public Shared ReadOnly Property Instance As AppService = New AppService
	Private Sub New()

	End Sub

#End Region

#Region "Properties"
	Private ReadOnly Property PlayersFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Players.txt"


#End Region
#Region "Support"
	''' <summary>
	''' if folders have changed or their number of files have changed, then clear the history files
	''' </summary>
	Private Sub Recalibrate(dialog As IDialogResource, disk As DiskService, history As HistoryService, settings As SettingsService)
		'NightMediaLocation
		If Not dialog.GetNightMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetNightMediaLocation) Then
			history.ClearHistory(MediaSection.Night)
		Else
			Dim _NightFiles As List(Of String) = ConstructNightFiles(settings)
			If _NightFiles.Count <> disk.GetNightFilesCount Then
				history.ClearHistory(MediaSection.Night)
			End If
		End If

		'RegularMediaLocation
		If Not dialog.GetRegularMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetRegularMediaLocation) Then
			history.ClearHistory(MediaSection.Regular)
		Else
			Dim _RegularFiles As List(Of String) = ConstructRegularFiles(settings)
			If _RegularFiles.Count <> disk.GetRegularFilesCount Then
				history.ClearHistory(MediaSection.Regular)
			End If
		End If

		'AlternateMediaLocation
		If Not dialog.GetAlternateMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetAlternateMediaLocation) Then
			history.ClearHistory(MediaSection.Alternate)
		Else
			Dim _AlternateFiles As List(Of String) = ConstructAlternateFiles(settings)
			If _AlternateFiles.Count <> disk.GetAlternateFilesCount Then
				history.ClearHistory(MediaSection.Alternate)
			End If
		End If
	End Sub
	Private Function ConstructRegularFiles(settings As SettingsService)
		Dim _RegularFiles As New List(Of String)
		Dim directory As String = settings.GetRegularMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				_RegularFiles.AddRange(files)
			End If
		Next
		Return _RegularFiles
	End Function
	Private Function ConstructAlternateFiles(settings As SettingsService) As List(Of String)
		Dim _AlternateFiles As New List(Of String)
		Dim directory As String = settings.GetAlternateMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				_AlternateFiles.AddRange(files)
			End If
		Next
		Return _AlternateFiles
	End Function
	Private Function ConstructNightFiles(settings As SettingsService) As List(Of String)
		Dim _NightFiles As New List(Of String)
		Dim directory As String = settings.GetNightMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				_NightFiles.AddRange(files)
			End If
		Next
		Return _NightFiles
	End Function
	Private Sub SetWallpaper(desktop As DesktopService, disk As DiskService)
		Dim wallpapers As List(Of String) = disk.GetWallpapers
		If wallpapers.Count > 0 Then
			Dim wallpaper As String = wallpapers(Random_(0, wallpapers.Count))
			desktop.SetWallpaper(wallpaper)
		End If
	End Sub


#End Region
#Region "Exported"
	Public Function CanStart(dialog As IDialogResource, settings As SettingsService) As Boolean
		Return settings.Validated(dialog)
	End Function
	Public Sub Start(dialog As IDialogResource, desktop As DesktopService, disk As DiskService, history As HistoryService, settings As SettingsService, state As StateService)
		Recalibrate(dialog, disk, history, settings)
		Load(disk, state, settings)
		SetWallpaper(desktop, disk)
		dialog.GetMediaTimer.Enabled = True
	End Sub

	Public Sub Load(disk As DiskService, state As StateService, settings As SettingsService)
		state.UpdateCurrentSection(If(GetPeriod(settings) = Period.Day, MediaSection.Alternate, MediaSection.Night))
		disk.Load(settings)
	End Sub
	Public Function GetPeriod(settings As SettingsService) As Period
		Dim currentTime As DateTime = DateTime.Now
		Dim beginTime As DateTime = DateTime.Parse(settings.GetBeginTime())
		Dim endTime As DateTime = DateTime.Parse(settings.GetEndTime())

		' Compare only the time components
		If currentTime.TimeOfDay >= beginTime.TimeOfDay AndAlso currentTime.TimeOfDay <= endTime.TimeOfDay Then
			Return Period.Night
		Else
			Return Period.Day
		End If
	End Function
	'Public Function GetPeriod(disk As DiskService, settings As SettingsService) As Period
	'	If Date.Parse(Now.ToShortTimeString) >= Date.Parse(settings.GetBeginTime()).ToShortTimeString And Date.Parse(Now.ToShortTimeString) <= Date.Parse(settings.GetEndTime()).ToShortTimeString Then
	'		Return Period.Night
	'	Else
	'		Return Period.Day
	'	End If
	'End Function
	'Public Sub PrepDay(desktop As DesktopService, disk As DiskService, settings As SettingsService)
	'	Dim wallpapers As List(Of String) = disk.GetWallpapers
	'	If wallpapers.Count > 0 Then
	'		Dim wallpaper As String = wallpapers(Random_(0, wallpapers.Count))
	'		desktop.SetWallpaper(wallpaper)
	'	End If
	'	desktop.StartTheApps(settings.GetDayPrograms)
	'End Sub
	'Public Sub PrepNight(desktop As DesktopService, settings As SettingsService)
	'	desktop.StartTheApps(settings.GetNightPrograms)
	'End Sub
	Public Function PlayerIsOn() As Boolean
		Dim Players As List(Of String) = ReadText(PlayersFile).StringToList
		For Each player As String In Players
			If AppIsOn(player) Then Return True
		Next
		Return False
	End Function

#End Region
End Class
