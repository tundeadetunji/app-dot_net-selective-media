Imports iNovation.Code.Desktop
Imports iNovation.Code.General

Imports System.Collections.ObjectModel
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Module Database


#Region "Media Variables"

	Dim mp4Files As ReadOnlyCollection(Of String)
	Dim mkvFiles As ReadOnlyCollection(Of String)
	Dim aviFiles As ReadOnlyCollection(Of String)
	Dim _3gpFiles As ReadOnlyCollection(Of String)
	Dim mpgFiles As ReadOnlyCollection(Of String)
	Dim mpegFiles As ReadOnlyCollection(Of String)
	Dim flvFiles As ReadOnlyCollection(Of String)
	Dim vobFiles As ReadOnlyCollection(Of String)
	Dim movFiles As ReadOnlyCollection(Of String)
	Dim amvFiles As ReadOnlyCollection(Of String)
	Dim wmvFiles As ReadOnlyCollection(Of String)
	Dim datFiles As ReadOnlyCollection(Of String)
	Dim _3gppFiles As ReadOnlyCollection(Of String)
	Dim m4vFiles As ReadOnlyCollection(Of String)
	Dim webmFiles As ReadOnlyCollection(Of String)
#End Region

#Region "Main"

	Public Sub GetFiles_(adult_ As ListBox, adult_value As String, films_ As ListBox, films_value As String, cartoons_ As ListBox, cartoons_value As String, wallpaper_regular As ListBox, wallpaper_regular_value As String)
		GetFiles_V_(adult_, adult_value)
		GetFiles_V_(films_, films_value)
		GetFiles_V_(cartoons_, cartoons_value)
		'		GetFiles_I_(wallpaper_adult, wallpaper_adult_value)
		GetFiles_I_(wallpaper_regular, wallpaper_regular_value)
	End Sub
	Public Sub GetFiles_V_(l_ As ListBox, location_ As String)
		'CLEAR

		Dim directory_ As String = location_
		If My.Computer.FileSystem.DirectoryExists(directory_) = False Then Return

		l_.Items.Clear()

		aviFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.avi")
		If aviFiles.Count > 0 Then
			For i% = 0 To aviFiles.Count - 1
				l_.Items.Add(aviFiles.Item(i))
			Next
		End If

		mkvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mkv")
		If mkvFiles.Count > 0 Then
			For i% = 0 To mkvFiles.Count - 1
				l_.Items.Add(mkvFiles.Item(i))
			Next
		End If

		wmvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.wmv")
		If wmvFiles.Count > 0 Then
			For i% = 0 To wmvFiles.Count - 1
				l_.Items.Add(wmvFiles.Item(i))
			Next
		End If

		movFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mov")
		If movFiles.Count > 0 Then
			For i% = 0 To movFiles.Count - 1
				l_.Items.Add(movFiles.Item(i))
			Next
		End If

		mp4Files = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mp4")
		If mp4Files.Count > 0 Then
			For i% = 0 To mp4Files.Count - 1
				l_.Items.Add(mp4Files.Item(i))
			Next
		End If

		_3gpFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.3gp")
		If _3gpFiles.Count > 0 Then
			For i% = 0 To _3gpFiles.Count - 1
				l_.Items.Add(_3gpFiles.Item(i))
			Next
		End If

		_3gppFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.3gpp")
		If _3gppFiles.Count > 0 Then
			For i% = 0 To _3gppFiles.Count - 1
				l_.Items.Add(_3gppFiles.Item(i))
			Next
		End If

		flvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.flv")
		If flvFiles.Count > 0 Then
			For i% = 0 To flvFiles.Count - 1
				l_.Items.Add(flvFiles.Item(i))
			Next
		End If

		mpgFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mpg")
		If mpgFiles.Count > 0 Then
			For i% = 0 To mpgFiles.Count - 1
				l_.Items.Add(mpgFiles.Item(i))
			Next
		End If

		mpegFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mpeg")
		If mpegFiles.Count > 0 Then
			For i% = 0 To mpegFiles.Count - 1
				l_.Items.Add(mpegFiles.Item(i))
			Next
		End If

		vobFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.vob")
		If vobFiles.Count > 0 Then
			For i% = 0 To vobFiles.Count - 1
				l_.Items.Add(vobFiles.Item(i))
			Next
		End If

		datFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.dat")
		If datFiles.Count > 0 Then
			For i% = 0 To datFiles.Count - 1
				l_.Items.Add(datFiles.Item(i))
			Next
		End If

		amvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.amv")
		If amvFiles.Count > 0 Then
			For i% = 0 To amvFiles.Count - 1
				l_.Items.Add(amvFiles.Item(i))
			Next
		End If

		m4vFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.m4v")
		If m4vFiles.Count > 0 Then
			For i% = 0 To m4vFiles.Count - 1
				l_.Items.Add(m4vFiles.Item(i))
			Next
		End If

		webmFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.webm")
		If webmFiles.Count > 0 Then
			For i% = 0 To webmFiles.Count - 1
				l_.Items.Add(webmFiles.Item(i))
			Next
		End If

	End Sub
	Public Sub GetFiles_I_(l_ As ListBox, location_ As String)
		'CLEAR
		Dim directory_ As String = location_
		If My.Computer.FileSystem.DirectoryExists(directory_) = False Then Exit Sub
		l_.Items.Clear()

		aviFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.jpg")
		If aviFiles.Count > 0 Then
			For i% = 0 To aviFiles.Count - 1
				l_.Items.Add(aviFiles.Item(i))
			Next
		End If

		mkvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.jpeg")
		If mkvFiles.Count > 0 Then
			For i% = 0 To mkvFiles.Count - 1
				l_.Items.Add(mkvFiles.Item(i))
			Next
		End If

		wmvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
		If wmvFiles.Count > 0 Then
			For i% = 0 To wmvFiles.Count - 1
				l_.Items.Add(wmvFiles.Item(i))
			Next
		End If

		movFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.bmp")
		If movFiles.Count > 0 Then
			For i% = 0 To movFiles.Count - 1
				l_.Items.Add(movFiles.Item(i))
			Next
		End If

	End Sub

#End Region

End Module
