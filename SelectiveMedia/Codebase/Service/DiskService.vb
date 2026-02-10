Imports System.IO
Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports SelectiveMedia.Lists
Imports System.Collections.ObjectModel
Public Class DiskService
    Implements IDiskService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As DiskService = New DiskService
    Private Sub New()

    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property RegularFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\RegularFilesCount.txt"
    Private ReadOnly Property AlternateFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\AlternateFilesCount.txt"
    Private ReadOnly Property NightFilesCountFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightFilesCount.txt"

#End Region

#Region "Support"

    'Private Sub SetRegularFiles(settings As SettingsService)
    '	RegularFiles_.Clear()
    '	Dim directory As String = settings.GetRegularMediaLocation()
    '	For Each fileType As String In SupportedMediaFileTypes
    '		Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
    '		If files.Count > 0 Then
    '			RegularFiles_.AddRange(files)
    '		End If
    '	Next
    'End Sub
    'Private Sub SetAlternateFiles(settings As SettingsService)
    '	AlternateFiles_.Clear()
    '	Dim directory As String = settings.GetAlternateMediaLocation()
    '	For Each fileType As String In SupportedMediaFileTypes
    '		Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
    '		If files.Count > 0 Then
    '			AlternateFiles_.AddRange(files)
    '		End If
    '	Next
    'End Sub
    'Private Sub SetNightFiles(settings As SettingsService)
    '	NightFiles_.Clear()
    '	Dim directory As String = settings.GetNightMediaLocation()
    '	For Each fileType As String In SupportedMediaFileTypes
    '		Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType)
    '		If files.Count > 0 Then
    '			NightFiles_.AddRange(files)
    '		End If
    '	Next
    'End Sub

    'Private Sub SetFiles(settings As SettingsService)
    '	SetRegularFiles(settings)
    '	SetAlternateFiles(settings)
    '	SetNightFiles(settings)
    'End Sub
    'Private Sub SetWallpapers(settings As SettingsService)
    '	Wallpapers_.Clear()
    '	Dim directory As String = settings.GetWallpapersLocation()
    '	For Each FileType As String In SupportedImageFileTypes
    '		Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, FileType)
    '		If files.Count > 0 Then
    '			Wallpapers_.AddRange(files)
    '		End If
    '	Next
    'End Sub

    Private Sub RecordRegularFileCount(count As Long)
        WriteText(RegularFilesCountFile, count)
    End Sub

    Private Sub RecordAlternateFileCount(count As Long)
        WriteText(AlternateFilesCountFile, count)
    End Sub

    Private Sub RecordNightFileCount(count As Long)
        WriteText(NightFilesCountFile, count)
    End Sub
    Private Function RecordedRegularFileCount() As Long
        Return Val(ReadText(RegularFilesCountFile))
    End Function
    Private Function RecordedAlternateFileCount() As Long
        Return Val(ReadText(AlternateFilesCountFile))
    End Function
    Private Function RecordedNightFileCount() As Long
        Return Val(ReadText(NightFilesCountFile))
    End Function
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

#End Region

#Region "Exported"

    Public Function PromptUserToSelectFolder(control_ As Control, Optional description_ As String = "Select Folder", Optional ShowNewFolderButton_ As Boolean = True) As String Implements IDiskService.PromptUserToSelectFolder
        Dim f_ As New FolderBrowserDialog

        With f_
            .Description = description_
            .ShowNewFolderButton = ShowNewFolderButton_
            .ShowDialog()
            Return If(String.IsNullOrEmpty(.SelectedPath), control_.Text, .SelectedPath)
        End With
    End Function

    Public Function PromptUserToSelectFile(control_ As Control) As String Implements IDiskService.PromptUserToSelectFile
        Dim f As String = iNovation.Code.Desktop.GetFile(FileKind.AnyFileKind)
        If Not String.IsNullOrEmpty(f) Then
            control_.Text = f
            Return f
        End If
        Return control_.Text
    End Function

    Public Function GetWallpapers(settings As ISettingsService) As List(Of String) Implements IDiskService.GetWallpapers
        Dim Wallpapers_ As List(Of String) = New List(Of String)
        Dim directory As String = settings.GetWallpapersLocation()
        If String.IsNullOrEmpty(directory) Then Return Wallpapers_
        For Each FileType As String In SupportedImageFileTypes
            Dim files = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, FileType)
            If files.Count > 0 Then
                Wallpapers_.AddRange(files)
            End If
        Next

        Return Wallpapers_
    End Function

    Public Function GetMediaFolders(section As MediaSection, settings As ISettingsService) As List(Of String) Implements IDiskService.GetMediaFolders
        Dim folder As String = Nothing
        Select Case section
            Case MediaSection.Regular
                folder = settings.GetRegularMediaLocation()
            Case MediaSection.Alternate
                folder = settings.GetAlternateMediaLocation()
            Case MediaSection.Night
                folder = settings.GetNightMediaLocation()
        End Select

        'Dim folders As List(Of String) = New List(Of String)
        'folders = New List(Of String)(GetDirectories(folder, FileIO.SearchOption.SearchAllSubDirectories))

        'Dim foldersAsReadOnly As ReadOnlyCollection(Of String) = GetDirectories(folder, FileIO.SearchOption.SearchAllSubDirectories)
        Dim foldersAsReadOnly As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetDirectories(folder, FileIO.SearchOption.SearchAllSubDirectories)
        If foldersAsReadOnly.Count = 0 Then Return New List(Of String)

        Dim folders As List(Of String) = New List(Of String)(foldersAsReadOnly)

        If folders.Count = 0 Then Return New List(Of String)

        Dim finalList As New List(Of String)

        For Each f As String In folders
            Dim found As List(Of String) = CType(GetFiles(f, FileType.any, FileIO.SearchOption.SearchTopLevelOnly), List(Of String))
            If found.Count > 0 Then
                finalList.Add(f)
            End If

        Next
        'For Each s As String In finalList
        '    Debug.WriteLine("*** " & s)
        'Next
        Return finalList
    End Function

    Public Function GetMediaFiles(folder As String) As List(Of String) Implements IDiskService.GetMediaFiles

        Dim results As New List(Of String)

        'Todo check if folder exists first
        'If Not Directory.Exists(folder) Then
        '    Return results
        'End If

        If CType(GetFiles(folder, FileType.any, FileIO.SearchOption.SearchTopLevelOnly), List(Of String)).Count < 1 Then Return results

        ' For each supported extension pattern ("*.mp4", "*.jpg", etc)
        For Each pattern As String In SupportedMediaFileTypes
            Dim files = CType(GetFiles(folder, pattern, FileIO.SearchOption.SearchAllSubDirectories), List(Of String))
            If files.Count > 0 Then results.AddRange(files)
        Next

        Return results
    End Function

    Public Sub RecordFileCount(section As MediaSection, count As Long) Implements IDiskService.RecordFileCount
        Select Case section
            Case MediaSection.Regular
                RecordRegularFileCount(count)
            Case MediaSection.Alternate
                RecordAlternateFileCount(count)
            Case Else
                RecordNightFileCount(count)
        End Select
    End Sub

    Public Function RecordedFileCount(section As MediaSection) As Long Implements IDiskService.RecordedFileCount
        Select Case section
            Case MediaSection.Regular
                Return RecordedRegularFileCount()
            Case MediaSection.Alternate
                Return RecordedAlternateFileCount()
            Case Else
                Return RecordedNightFileCount()
        End Select
    End Function

    Public Sub SetPermissions() Implements IDiskService.SetPermissions
        PermitFolder(My.Application.Info.DirectoryPath)
    End Sub

    Public Function FileCount(section As MediaSection, settings As ISettingsService) As Long Implements IDiskService.FileCount
        Select Case section
            Case MediaSection.Regular
                Return Long.Parse(CType(ConstructRegularFiles(settings), List(Of String)).Count.ToString())
            Case MediaSection.Alternate
                Return Long.Parse(CType(ConstructAlternateFiles(settings), List(Of String)).Count.ToString())
            Case Else
                Return Long.Parse(CType(ConstructNightFiles(settings), List(Of String)).Count.ToString())
        End Select
    End Function

    Public Function FolderContainsAnySupportedFile(directory As String) As Boolean Implements IDiskService.FolderContainsAnySupportedFile
        For Each fileType As String In SupportedMediaFileTypes
            If My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchAllSubDirectories, fileType).Count = 0 Then Return False
        Next
        Return True
    End Function

#End Region

End Class
