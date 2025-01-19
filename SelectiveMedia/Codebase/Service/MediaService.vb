Imports SelectiveMedia.Constants
Imports iNovation.Code.General
Imports iNovation.Code.FeedbackExtensions
Imports iNovation.Code.Desktop
Public Class MediaService

#Region "Support"
    Private Function ChoseRandomFileToPlay(files As List(Of String), history As HistoryService, section As MediaSection) As String
        Dim which_file
        Dim counter As Long = 0
2:
        which_file = Random_(0, files.Count)
        If Not history.ThisFileHasAlreadyPlayed(which_file, section) Then
            Return which_file
        ElseIf counter = files.Count Then
            history.ClearHistory(section)
            counter = 0
            GoTo 2
        Else
            counter += 1
            GoTo 2
        End If

    End Function
    Private Function ChoseSequentialFileToPlay(files As List(Of String), history As HistoryService, section As MediaSection) As Long
        If history.GetCurrentSequentialFileIndex > files.Count - 1 Then
            history.ClearHistory(section)
            Return 0
        Else
            Return history.GetCurrentSequentialFileIndex + 1
        End If

    End Function
    Private Sub SetTime(dialog As IDialogResource, disk As DiskService, settings As SettingsService)

        Select Case settings.GetMode(disk)
            Case SequentialNight, SequentialAlternate, SequentialRegular
                dialog.GetMediaTimer.Interval = TwoSeconds
            Case Random, App
                Dim random_value = Random_(1, 4)
                Select Case random_value
                    Case 1
                        dialog.GetMediaTimer.Interval = If(settings.GetRate(disk) = Relaxed, TwentyMinutes, TwoMinutes)
                    Case 2
                        dialog.GetMediaTimer.Interval = If(settings.GetRate(disk) = Relaxed, TenMinutes, ThreeMinutes)
                    Case 3
                        dialog.GetMediaTimer.Interval = FiveMinutes
                End Select
        End Select

    End Sub

#End Region

#Region "Exported"

    Public Sub StartMedia(dialog As IDialogResource, desktop As DesktopService, program As AppService, disk As DiskService, history As HistoryService, settings As SettingsService, state As StateService)

        Select Case settings.GetMode(disk)
            Case SequentialNight, SequentialRegular, SequentialAlternate
                StartMediaSequential(state, disk, history, settings)
            Case Random
                StartMediaRandom(program, state, disk, history)
            Case App
                desktop.StartTheApps(settings.GetProgramsFile(disk))
        End Select

        SetTime(dialog, disk, settings)
    End Sub

    Private Sub StartMediaRandom(app As AppService, state As StateService, disk As DiskService, history As HistoryService)
        Dim files As List(Of String) = disk.GetFiles(state.NextSection(app))
        Dim file As String = ChoseRandomFileToPlay(files, history, state.CurrentSection)
        history.AddFileToHistory(file, state.CurrentSection)
        StartFile(file)

    End Sub

    Private Sub StartMediaSequential(state As StateService, disk As DiskService, history As HistoryService, settings As SettingsService)
        Dim files As List(Of String) = disk.GetFiles(state.CurrentSection)
        Dim index As Long = ChoseSequentialFileToPlay(files, history, state.CurrentSection)
        history.UpdateIndexOfTheFilePlayingNow(index)

        If Not state.SequentialState Then
            state.UpdateSequentialState(True)
            settings.GetAnnounce(disk).Inform
        End If
        StartFile(files(index))
    End Sub

#End Region

End Class
