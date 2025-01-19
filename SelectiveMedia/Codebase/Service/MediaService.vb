﻿Imports SelectiveMedia.Constants
Imports iNovation.Code.General
Imports iNovation.Code.FeedbackExtensions
Imports iNovation.Code.Desktop

Public Class MediaService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As MediaService = New MediaService
    Private Sub New()

    End Sub
#End Region

#Region "Support"
    Private Function ChoseRandomFileToPlay(files As List(Of String), history As HistoryService, section As MediaSection) As Long
        Dim index
        Dim counter As Long = 0
2:
        index = Random_(0, files.Count)
        If Not history.FileAtThisIndexHasAlreadyPlayed(index, section) Then
            Return index
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

#End Region

#Region "Exported"

    Public Sub StartMedia(dialog As IDialogResource, program As AppService, desktop As DesktopService, disk As DiskService, history As HistoryService, settings As SettingsService, state As StateService)

        Select Case settings.GetMode()
            Case SequentialNight, SequentialRegular, SequentialAlternate
                StartMediaSequential(state, disk, history, settings)
            Case Random
                StartMediaRandom(program, disk, settings, history, state)
            Case App
                desktop.StartTheApps(settings.GetProgramsFile())
        End Select

        SetTime(dialog, disk, settings)
    End Sub

    Private Sub StartMediaRandom(app As AppService, disk As DiskService, settings As SettingsService, history As HistoryService, state As StateService)
        Dim files As List(Of String) = disk.GetFiles(state.NextSection(app, disk, settings))
        If files.Count < 1 Then Return
        Dim index As Long = ChoseRandomFileToPlay(files, history, state.CurrentSection)
        history.AddIndexToHistory(index, state.CurrentSection)
        StartFile(files(index))
    End Sub

    Private Sub StartMediaSequential(state As StateService, disk As DiskService, history As HistoryService, settings As SettingsService)
        Dim files As List(Of String) = disk.GetFiles(state.CurrentSection)
        If files.Count < 1 Then Return
        Dim index As Long = ChoseSequentialFileToPlay(files, history, state.CurrentSection)
        history.UpdateIndexOfSequentialPlayback(index)

        If Not state.SequentialState Then
            state.UpdateSequentialState(True)
            settings.GetAnnounce().Inform
        End If
        StartFile(files(index))
    End Sub

#End Region

End Class
