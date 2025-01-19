Imports SelectiveMedia.Constants
Imports iNovation.Code.General
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
                        dialog.GetMediaTimer.Interval = If(settings.GetRate = Relaxed, TwentyMinutes, TwoMinutes)
                    Case 2
                        dialog.GetMediaTimer.Interval = If(settings.GetRate = Relaxed, TenMinutes, ThreeMinutes)
                    Case 3
                        dialog.GetMediaTimer.Interval = FiveMinutes
                End Select
        End Select

    End Sub

#End Region

#Region "Exported"

    Public Sub StartMedia(disk As DiskService, settings As SettingsService, state As StateService)

        Select Case settings.GetMode(disk)
            Case SequentialNight, SequentialRegular, SequentialAlternate
                StartMediaSequential(state)
            Case Random
                StartMediaRandom()
            Case App
                'start apps
        End Select

        SetTime()
    End Sub
    Private Sub StartMediaRandom(state As StateService, disk As DiskService, history As HistoryService)
        Dim files As List(Of String) = disk.GetFiles(state.NextSection)
        Dim file As String = ChoseFileToPlay()
        history.AddFileToHistory(file)
        StartFile(file)

    End Sub

    Private Sub StartMediaSequential(state As StateService, disk As DiskService, history As HistoryService)
        Dim files As List(Of String) = disk.GetFiles(state.CurrentSection)
        Dim index As Long = ChoseSequentialFileToPlay()
        history.UpdateTheIndexOfTheFilePlayingNow(index)
        StartFile(files(index))
    End Sub

#End Region

End Class
