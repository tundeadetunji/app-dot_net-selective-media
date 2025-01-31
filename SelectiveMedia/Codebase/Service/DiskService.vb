Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports SelectiveMedia.Constants
Public Class DiskService

#Region "Initialization"
	Public Shared ReadOnly Property Instance As DiskService = New DiskService
	Private Sub New()

	End Sub
#End Region

#Region "Properties"
	Private Property RegularFiles_ As List(Of String) = New List(Of String)
	Private Property AlternateFiles_ As List(Of String) = New List(Of String)
	Private Property NightFiles_ As List(Of String) = New List(Of String)
	Private Property Wallpapers_ As List(Of String) = New List(Of String)
	Private ReadOnly Property RegularFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\RegularFilesCount.txt"
	Private ReadOnly Property AlternateFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\AlternateFilesCount.txt"
	Private ReadOnly Property NightFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightFilesCount.txt"

#End Region
#Region "Support"

	Private Sub SetRegularFiles(settings As SettingsService)
		RegularFiles_.Clear()
		Dim directory As String = settings.GetRegularMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				RegularFiles_.AddRange(files)
			End If
		Next
	End Sub
	Private Sub SetAlternateFiles(settings As SettingsService)
		AlternateFiles_.Clear()
		Dim directory As String = settings.GetAlternateMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				AlternateFiles_.AddRange(files)
			End If
		Next
	End Sub
	Private Sub SetNightFiles(settings As SettingsService)
		NightFiles_.Clear()
		Dim directory As String = settings.GetNightMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 0 Then
				NightFiles_.AddRange(files)
			End If
		Next
	End Sub

	Private Sub SetFiles(settings As SettingsService)
		SetRegularFiles(settings)
		SetAlternateFiles(settings)
		SetNightFiles(settings)
	End Sub
	Private Sub SetWallpapers(settings As SettingsService)
		Wallpapers_.Clear()
		Dim directory As String = settings.GetWallpapersLocation()
		For Each FileType As String In SupportedImageFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, FileType)
			If files.Count > 0 Then
				Wallpapers_.AddRange(files)
			End If
		Next
	End Sub

	Private Sub UpdateRegularFilesCount(count As Long)
		WriteText(RegularFilesCountFile, count)
	End Sub

	Private Sub UpdateAlternateFilesCount(count As Long)
		WriteText(AlternateFilesCountFile, count)
	End Sub

	Private Sub UpdateNightFilesCount(count As Long)
		WriteText(NightFilesCountFile, count)
	End Sub

#End Region
#Region "Exported"

	Public Function GetFolder(control_ As Control, Optional description_ As String = "Select Folder", Optional ShowNewFolderButton_ As Boolean = True) As String
		Dim f_ As New FolderBrowserDialog

		With f_
			.Description = description_
			.ShowNewFolderButton = ShowNewFolderButton_
			.ShowDialog()
			Return If(String.IsNullOrEmpty(.SelectedPath), control_.Text, .SelectedPath)
		End With
	End Function

	Public Function GetFile(control_ As Control) As String

		Dim f As String = iNovation.Code.Desktop.GetFile(FileKind.AnyFileKind)
		If Not String.IsNullOrEmpty(f) Then
			control_.Text = f
			Return f
		End If
		Return control_.Text
	End Function

	Public Function GetWallpapers() As List(Of String)
		Return Wallpapers_
	End Function

	Public Function GetFiles(section As MediaSection) As List(Of String)
		Select Case section
			Case MediaSection.Alternate
				Return AlternateFiles_
			Case MediaSection.Regular
				Return RegularFiles_
			Case Else
				Return NightFiles_
		End Select
	End Function


	Public Sub Load(settings As SettingsService)
		SetFiles(settings)
		SetWallpapers(settings)

		UpdateRegularFilesCount(RegularFiles_.Count)
		UpdateAlternateFilesCount(AlternateFiles_.Count)
		UpdateNightFilesCount(NightFiles_.Count)
	End Sub

	Public Function GetRegularFilesCount() As Long
		Return Val(ReadText(RegularFilesCountFile))
	End Function

	Public Function GetAlternateFilesCount() As Long
		Return Val(ReadText(AlternateFilesCountFile))
	End Function

	Public Function GetNightFilesCount() As Long
		Return Val(ReadText(NightFilesCountFile))
	End Function
	Public Sub SetPermissions()
		PermitFolder(My.Application.Info.DirectoryPath)
	End Sub

#End Region

End Class
