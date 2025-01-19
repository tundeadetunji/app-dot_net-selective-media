Public Class SettingsService

#Region "Properties"
    Private ReadOnly Property BeginTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\BeginTime.txt"
    Private ReadOnly Property EndTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\EndTime.txt"
    Private ReadOnly ModeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Mode.txt"
    Private ReadOnly Property AnnounceFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Announce.txt"
    Private ReadOnly Property DayProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\DayPrograms.txt"
    Private ReadOnly Property NightProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightPrograms.txt"
    Private ReadOnly Property RateFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Rate.txt"
    Private ReadOnly Property PlayersFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Players.txt"

#End Region

#Region "Support"
    ''' <summary>
    ''' if folders have changed or their number of files have changed, then clear the history files
    ''' </summary>
    Private Sub Recalibrate(history As HistoryService)

    End Sub

#End Region

#Region "Exported"

    Public Function SettingsValidated() As Boolean

    End Function
    Public Sub SaveSettings(dialog As IDialogResource, disk As DiskService, history As HistoryService, state As StateService)
        'recalibrate
        Recalibrate(history)
        state.UpdateSequentialState()
        state.UpdateCurrentSection()
        disk.SetFiles()

        'save settings
    End Sub

    Public Function GetPlayers(disk As DiskService)

    End Function

    Public Function GetNightMediaLocation(disk As DiskService) As String

    End Function
    Public Sub SetNightMediaLocation(location As String, disk As DiskService)

    End Sub
    Public Function GetRegularMediaLocation(disk As DiskService) As String

    End Function
    Public Sub SetRegularMediaLocation(location As String, disk As DiskService)

    End Sub
    Public Function GetAlternateMediaLocation(disk As DiskService) As String

    End Function
    Public Sub SetAlternateMediaLocation(location As String, disk As DiskService)

    End Sub
    Public Function GetWallpaperLocation(disk As DiskService) As String

    End Function
    Public Sub SetWallpaperLocation(location As String, disk As DiskService)

    End Sub
    Public Function GetAnnounce(disk As DiskService) As String

    End Function
    Public Sub SetAnnounce(location As String, disk As DiskService)

    End Sub

    Public Function GetBeginTime(disk As DiskService) As String
        Dim b_time_f As String
        Try
            b_time_f = My.Computer.FileSystem.ReadAllText(BeginTimeFile).Trim
        Catch x As Exception
            b_time_f = "12:00 AM"
        End Try
        Return b_time_f
    End Function

    Public Sub SetBeginTime(begin_time As String, disk As DiskService)
        Try
            My.Computer.FileSystem.WriteAllText(BeginTimeFile, b_, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetEndTime(disk As DiskService) As String
        Dim e_time_f As String
        Try
            e_time_f = My.Computer.FileSystem.ReadAllText(end_time).Trim
        Catch x As Exception
            e_time_f = "6:00 AM"
        End Try
        Return e_time_f
    End Function

    Public Sub SetEndTime(end_time As String, disk As DiskService)
        Try
            My.Computer.FileSystem.WriteAllText(end_time, e_, False)
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetMode(disk As DiskService) As String

    End Function

    Public Sub SetMode(_mode As String, disk As DiskService)

    End Sub
    Public Function GetRate(disk As DiskService) As String

    End Function

    Public Sub SetRate(_rate As String, disk As DiskService)

    End Sub
    Public Function GetProgramsFile(disk As DiskService) As String

    End Function

    Public Sub SetProgramsFile(ProgramsFile As String, disk As DiskService)

    End Sub

#End Region

End Class
