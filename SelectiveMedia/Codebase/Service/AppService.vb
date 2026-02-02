Imports iNovation.Code
Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports iNovation.Code.GeneralExtensions
Imports iNovation.Variant
Imports SelectiveMedia.Strings
'Imports iNovation.Variant
Public Class AppService
    Implements IAppService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As AppService = New AppService
    Private Sub New()

    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property Logger As Logger(Of LogEntry) = FileLogger.Create(Files.LogFile)

#End Region

#Region "Support"
    Private Sub StartMediaTimers(dialog As IDialogResource)
        dialog.GetMediaTimer.Enabled = True
    End Sub
    Private Sub SetInitialState(disk As IDiskService, state As IStateService, settings As ISettingsService)
        state.UpdateCurrentSection(If(Support.GetPeriod(settings) = Period.Day, MediaSection.Regular, MediaSection.Night))
    End Sub

    Private Sub Recalibrate(dialog As IDialogResource, disk As IDiskService, history As IHistoryService, settings As ISettingsService)

        Dim Reasons As New List(Of String)

        Dim shouldClearHistory As Boolean = False

        If Not dialog.GetNightMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetNightMediaLocation) Then
            Reasons.Add("User changed NightMediaLocation")
            shouldClearHistory = True
        End If

        Dim NightFileCount = disk.FileCount(MediaSection.Night, settings)
        If NightFileCount <> disk.RecordedFileCount(MediaSection.Night) Then
            Reasons.Add("User added or removed media files from NightMediaLocation")
            shouldClearHistory = True
        End If

        If Not dialog.GetRegularMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetRegularMediaLocation) Then
            Reasons.Add("User changed RegularMediaLocation")
            shouldClearHistory = True
        End If

        Dim RegularFileCount = disk.FileCount(MediaSection.Regular, settings)
        If RegularFileCount <> disk.RecordedFileCount(MediaSection.Regular) Then
            Reasons.Add("User added or removed media files from RegularMediaLocation")
            shouldClearHistory = True
        End If

        If Not dialog.GetAlternateMediaLocationTextBox.Text.EqualsIgnoreCase(settings.GetAlternateMediaLocation) Then
            Reasons.Add("User changed AlternateMediaLocation")
            shouldClearHistory = True
        End If

        Dim AlternateFileCount = disk.FileCount(MediaSection.Alternate, settings)
        If AlternateFileCount <> disk.RecordedFileCount(MediaSection.Alternate) Then
            Reasons.Add("User added or removed media files from AlternateMediaLocation")
            shouldClearHistory = True
        End If

        If shouldClearHistory Then
            If Reasons.Any Then
                Dim s As String = String.Join("; ", Reasons)
                Logger.Log(LogEntry.Create(LogEvent.ClearHistory.ToString, s))
                SendLogToServer(s)
            End If

            history.ClearHistory()
            disk.RecordFileCount(MediaSection.Regular, RegularFileCount)
            disk.RecordFileCount(MediaSection.Alternate, AlternateFileCount)
            disk.RecordFileCount(MediaSection.Night, NightFileCount)
        End If

    End Sub

    Private Sub SendLogToServer(s As String)
        DataTransferServices.LogService.SendLog("Channels" & vbCrLf & s)
    End Sub

    Private Sub SetWallpaper(desktop As IDesktopService, disk As IDiskService, settings As ISettingsService)
        If Not settings.ShouldChangeWallpaper Then Return
        Dim wallpapers As List(Of String) = disk.GetWallpapers(settings)
        If wallpapers.Count > 0 Then
            Dim wallpaper As String = wallpapers(Random_(0, wallpapers.Count))
            desktop.SetWallpaper(wallpaper)
        End If
    End Sub

#End Region

#Region "Exported"
    Public Function CanStart(dialog As IDialogResource, settings As ISettingsService) As Boolean Implements IAppService.CanStart
        Return settings.Validated(dialog)
    End Function
    Public Sub Start(dialog As IDialogResource, desktop As IDesktopService, disk As IDiskService, history As IHistoryService, settings As ISettingsService, state As IStateService) Implements IAppService.Start
        Recalibrate(dialog, disk, history, settings)
        SetInitialState(disk, state, settings)
        SetWallpaper(desktop, disk, settings)
        StartMediaTimers(dialog)
    End Sub

#End Region
End Class
