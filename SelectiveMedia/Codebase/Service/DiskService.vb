Imports iNovation.Code.General
Imports SelectiveMedia.Constants
Public Class DiskService

#Region "Properties"
	Private Property _RegularFiles As List(Of String) = New List(Of String)
	Private Property _AlternateFiles As List(Of String) = New List(Of String)
	Private Property _NightFiles As List(Of String) = New List(Of String)
	Private Property _Wallpapers As List(Of String) = New List(Of String)


#End Region
#Region "Support"
	Private Sub SetRegularFiles(settings As SettingsService)
		_RegularFiles.Clear()
		Dim directory As String = settings.GetRegularMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 1 Then
				_RegularFiles.AddRange(files)
			End If
		Next
	End Sub
	Private Sub SetAlternateFiles(settings As SettingsService)
		_AlternateFiles.Clear()
		Dim directory As String = settings.GetAlternateMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 1 Then
				_AlternateFiles.AddRange(files)
			End If
		Next
	End Sub
	Private Sub SetNightFiles(settings As SettingsService)
		_NightFiles.Clear()
		Dim directory As String = settings.GetNightMediaLocation()
		For Each fileType As String In SupportedMediaFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
			If files.Count > 1 Then
				_NightFiles.AddRange(files)
			End If
		Next
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

	Public Function GetWallpapers() As List(Of String)
		Return _Wallpapers
	End Function

	Public Sub SetWallpapers(settings As SettingsService)
		_Wallpapers.Clear()
		Dim directory As String = settings.GetWallpapersLocation()
		For Each FileType As String In SupportedImageFileTypes
			Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, FileType)
			If files.Count > 1 Then
				_Wallpapers.AddRange(files)
			End If
		Next
	End Sub
	Public Function GetFiles(section As MediaSection) As List(Of String)
		Select Case section
			Case MediaSection.Alternate
				Return _AlternateFiles
			Case MediaSection.Regular
				Return _RegularFiles
			Case Else
				Return _NightFiles
		End Select
	End Function
	Public Sub SetFiles(disk As DiskService, settings As SettingsService)
		SetRegularFiles(disk, settings)
		SetAlternateFiles(disk, settings)
		SetNightFiles(disk, settings)
	End Sub


#End Region

End Class
