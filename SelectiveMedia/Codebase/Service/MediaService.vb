Imports System.Security
Imports iNovation.Code.Desktop
Imports iNovation.Code.FeedbackExtensions
Imports iNovation.Code.General
Imports SelectiveMedia.Strings
Imports SelectiveMedia.Logger
Public Class MediaService
    Implements IMediaService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As MediaService = New MediaService
    Private Sub New()

    End Sub
#End Region

#Region "Exported"

    Public Sub StartMedia(dialog As IDialogResource, app As IAppService, desktop As IDesktopService, disk As IDiskService, history As IHistoryService, settings As ISettingsService, state As IStateService) Implements IMediaService.StartMedia
        Select Case settings.GetMode().Trim()
            Case SequentialNight, SequentialRegular, SequentialAlternate
                StartMediaSequential(state, disk, history, settings)
            Case Random
                StartMediaRandom(app, disk, settings, history, state)
            Case Strings.App
                desktop.StartTheApps(settings.GetProgramsFile())
        End Select

        SetTime(dialog, settings)
    End Sub

#End Region

#Region "Intermediate"


    Private Sub StartMediaRandom(app As IAppService, disk As IDiskService, settings As ISettingsService, history As IHistoryService, state As IStateService)
        Dim current_section As MediaSection = state.CurrentSection
        Dim next_section As MediaSection = state.NextSection(settings)
        Dim folders As List(Of String) = disk.GetMediaFolders(next_section, settings)
        'Debug.WriteLine("*** " & folders.Count)
        If folders.Count < 1 Then Return
        Dim selectedMediaFile As String = ChoseRandomFileToPlay(folders, disk, history, next_section)
        state.UpdateCurrentSection(next_section)
        history.AddFileToHistory(selectedMediaFile)
        StartFile(selectedMediaFile)
    End Sub

    Private Sub StartMediaSequential(state As IStateService, disk As IDiskService, history As IHistoryService, settings As ISettingsService)

        Dim files As List(Of String) = New List(Of String)
        'Dim chosenSection As MediaSection = GetSectionFromMode(settings.GetMode())
        Select Case GetSectionFromMode(settings.GetMode())
            Case MediaSection.Regular
                files = disk.GetMediaFiles(settings.GetRegularMediaLocation())
            Case MediaSection.Alternate
                files = disk.GetMediaFiles(settings.GetAlternateMediaLocation())
            Case Else
                files = disk.GetMediaFiles(settings.GetNightMediaLocation())
        End Select

        If files.Count < 1 Then Return
        files.Sort()

        Dim index As Long = state.IndexOfSequentialPlayback() + 1

        If (index > files.Count - 1) Then
            index = 0
        End If

        state.UpdateIndexOfSequentialPlayback(index)

        If Not state.SequentialState Then
            state.UpdateSequentialState(True)
            settings.GetAnnounce().Inform
        End If

        Try
            StartFile(files(index))
        Catch ignored As Exception
        End Try
    End Sub

#End Region

#Region "Support"
    Private Function ChoseRandomFileToPlay(folders As List(Of String), disk As IDiskService, history As IHistoryService, section As MediaSection) As String
        Dim attempts As Integer = 0

        ' Collect ALL media files across ALL folders
        Dim mediaFiles As New List(Of String)
        For Each folder In folders
            mediaFiles.AddRange(disk.GetMediaFiles(folder))
        Next

        If mediaFiles.Count = 0 Then Return ""

        ' Filter unplayed files first
        Dim unplayed = mediaFiles.
                   Select(Function(f) f.Trim()).
                   Where(Function(f) Not history.ThisFileHasAlreadyPlayed(f)).
                   ToList()

        ' Case 1: There are unplayed files
        If unplayed.Count > 0 Then
            Return unplayed(Random_(0, unplayed.Count))
        End If

        ' Case 2: All files have been played → reset history and start fresh
        history.ClearHistory()
        Return mediaFiles(Random_(0, mediaFiles.Count))
    End Function


    'Private Function ChoseRandomFileToPlay(folders As List(Of String), disk As IDiskService, history As IHistoryService, section As MediaSection) As String
    '    Dim selectedFile As String
    '    Dim attempts As Long = 0

    '    If folders.Count = 0 Then
    '        Return ""
    '    End If

    '    Dim selectedFolder As String = folders(Random_(0, folders.Count))

    '    Dim mediaFiles As List(Of String) = disk.GetMediaFiles(selectedFolder)

    '    If mediaFiles.Count = 0 Then Return ""

    '    Do
    '        selectedFile = mediaFiles(Random_(0, mediaFiles.Count)) ' Get a random index
    '        Log("selectedFile: " & selectedFile)
    '        Log("ThisFileHasAlreadyPlayed: " & history.ThisFileHasAlreadyPlayed(selectedFile))

    '        If Not history.ThisFileHasAlreadyPlayed(selectedFile.Trim) Then
    '            Return selectedFile
    '        End If

    '        attempts += 1
    '        If attempts >= mediaFiles.Count Then
    '            ' If all files have been played, clear history and return 0
    '            history.ClearHistory()
    '            Return mediaFiles(0)
    '        End If
    '    Loop

    'End Function

    Private Sub SetTime(dialog As IDialogResource, settings As ISettingsService)

        Select Case settings.GetMode()
            Case SequentialNight, SequentialAlternate, SequentialRegular
                dialog.GetMediaTimer.Interval = TwoSeconds
            Case Random, App
                Dim random_value = Random_(1, 4)
                Select Case random_value
                    Case 1
                        dialog.GetMediaTimer.Interval = If(settings.GetRate() = Relaxed, TwentyMinutes, TwoMinutes)
                    Case 2
                        dialog.GetMediaTimer.Interval = If(settings.GetRate() = Relaxed, TenMinutes, ThreeMinutes)
                    Case 3
                        dialog.GetMediaTimer.Interval = FiveMinutes
                End Select
        End Select

    End Sub

    Private Function GetSectionFromMode(modeValue As String) As MediaSection
        Select Case modeValue.ToLower
            Case SequentialRegular.ToLower
                Return MediaSection.Regular
            Case SequentialAlternate.ToLower
                Return MediaSection.Alternate
            Case Else
                Return MediaSection.Night
        End Select
    End Function

#End Region


End Class
