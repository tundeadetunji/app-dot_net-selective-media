Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports iNovation.Code.GeneralExtensions
Imports SelectiveMedia.Constants
Public Class SettingsService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As SettingsService = New SettingsService
    Private Sub New()

    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property BeginTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\BeginTime.txt"
    Private ReadOnly Property EndTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\EndTime.txt"
    Private ReadOnly Property AnnounceFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Announce.txt"
    'Private ReadOnly Property DayProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\DayPrograms.txt"
    'Private ReadOnly Property NightProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightPrograms.txt"
    Private ReadOnly Property NightMediaLocationFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightMediaLocation.txt"
    Private ReadOnly Property RegularMediaLocationFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\RegularMediaLocation.txt"
    Private ReadOnly Property AlternateMediaLocationFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\AlternateMediaLocation.txt"
    Private ReadOnly Property WallpapersLocationFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\WallpapersLocation.txt"
    Private ReadOnly Property ProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Programs.txt"
    Private ReadOnly Property RateFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Rate.txt"
    Private ReadOnly Property ModeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Mode.txt"
    Private ReadOnly Property StartWithPCFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\StartWithPC.txt"

#End Region

#Region "Exported"
    ''' <summary>
    ''' All files are in place and locations are valid
    ''' </summary>
    ''' <returns></returns>
    Public Function Validated(dialog As IDialogResource) As Boolean
        Dim valid As Boolean = True

        If Not IO.Directory.Exists(dialog.GetNightMediaLocationTextBox.Text) Then valid = False
        If Not IO.Directory.Exists(dialog.GetRegularMediaLocationTextBox.Text) Then valid = False
        If Not IO.Directory.Exists(dialog.GetAlternateMediaLocationTextBox.Text) Then valid = False
        'If Not IO.File.Exists(dialog.GetProgramsFileTextBox.Text) Then valid = False
        If Not IO.Directory.Exists(dialog.GetWallpaperLocationTextBox.Text) Then valid = False
        If String.IsNullOrEmpty(dialog.GetModeDropDown.Text) Then valid = False
        If String.IsNullOrEmpty(dialog.GetRateDropDown.Text) Then valid = False

        Return valid
    End Function
    Public Sub SaveSettings(dialog As IDialogResource, app As AppService, desktop As DesktopService, disk As DiskService, history As HistoryService, settings As SettingsService, state As StateService)

        'save settings
        SetBeginTime(dialog.GetBeginTime.Value.ToShortTimeString)
        SetEndTime(dialog.GetEndTime.Value.ToShortTimeString)
        SetAnnounce(dialog.GetAnnounceTextBox.Text)
        'SetDayPrograms(String.Empty)
        'SetNightPrograms(String.Empty)
        SetNightMediaLocation(dialog.GetNightMediaLocationTextBox.Text)
        SetRegularMediaLocation(dialog.GetRegularMediaLocationTextBox.Text)
        SetAlternateMediaLocation(dialog.GetAlternateMediaLocationTextBox.Text)
        SetWallpapersLocation(dialog.GetWallpaperLocationTextBox.Text)
        SetProgramsFile(dialog.GetProgramsFileTextBox.Text)
        SetRate(dialog.GetRateDropDown.Text)
        SetMode(dialog.GetModeDropDown.Text)
        SetStartWithPC(dialog.GetStartWithPCCheckBox.Checked)

        'load
        app.Start(dialog, desktop, disk, history, settings, state)
    End Sub

    Public Function GetStartWithPC() As Boolean
        Return Boolean.Parse(ReadText(StartWithPCFile))
    End Function

    Public Sub SetStartWithPC(state As Boolean)
        WriteText(StartWithPCFile, state)
        ToStartup(If(state, RegistryValue, RegistryValue.Replace(".exe", "")), RegistryKey)
    End Sub

    Public Function GetBeginTime() As String
        Dim b_time_f As String = ReadText(BeginTimeFile)
        Return If(Not String.IsNullOrEmpty(b_time_f), b_time_f, "12:00 AM")
    End Function

    Public Sub SetBeginTime(begin_time As String)
        WriteText(BeginTimeFile, begin_time)
    End Sub

    Public Function GetEndTime() As String
        Dim e_time_f As String = ReadText(EndTimeFile)
        Return If(Not String.IsNullOrEmpty(e_time_f), e_time_f, "6:00 AM")
    End Function

    Public Sub SetEndTime(end_time As String)
        WriteText(EndTimeFile, end_time)
    End Sub

    Public Function GetAnnounce() As String
        Return ReadText(AnnounceFile)
    End Function
    Public Sub SetAnnounce(announcement As String)
        WriteText(AnnounceFile, announcement)
    End Sub

    'Public Function GetDayPrograms() As List(Of String)
    '    Dim file_content As String = ReadText(DayProgramsFile)
    '    Return If(String.IsNullOrEmpty(file_content), New List(Of String), file_content.StringToList)
    'End Function

    'Public Sub SetDayPrograms(programs As String)
    '    'Todo
    'End Sub

    'Public Function GetNightPrograms() As List(Of String)
    '    Dim file_content As String = ReadText(NightProgramsFile)
    '    Return If(String.IsNullOrEmpty(file_content), New List(Of String), file_content.StringToList)
    'End Function

    'Public Sub SetNightPrograms(programs As String)
    '    'Todo
    'End Sub
    Public Function GetNightMediaLocation() As String
        Return ReadText(NightMediaLocationFile)
    End Function
    Public Sub SetNightMediaLocation(location As String)
        WriteText(NightMediaLocationFile, location)
    End Sub

    Public Function GetRegularMediaLocation() As String
        Return ReadText(RegularMediaLocationFile)
    End Function
    Public Sub SetRegularMediaLocation(location As String)
        WriteText(RegularMediaLocationFile, location)
    End Sub
    Public Function GetAlternateMediaLocation() As String
        Return ReadText(AlternateMediaLocationFile)
    End Function
    Public Sub SetAlternateMediaLocation(location As String)
        WriteText(AlternateMediaLocationFile, location)
    End Sub
    Public Function GetWallpapersLocation() As String
        Return ReadText(WallpapersLocationFile)
    End Function
    Public Sub SetWallpapersLocation(location As String)
        WriteText(WallpapersLocationFile, location)
    End Sub
    Public Function GetProgramsFile() As String
        Return ReadText(ProgramsFile)
    End Function

    Public Sub SetProgramsFile(value As String)
        WriteText(ProgramsFile, value)
    End Sub
    Public Function GetRate() As String
        Return ReadText(RateFile)
    End Function

    Public Sub SetRate(_rate As String)
        WriteText(RateFile, _rate)
    End Sub
    Public Function GetMode() As String
        Return ReadText(ModeFile)
    End Function

    Public Sub SetMode(_mode As String)
        WriteText(ModeFile, _mode)
    End Sub

    Friend Sub RestoreSettings(dialog As IDialogResource)
        dialog.GetNightMediaLocationTextBox.Text = GetNightMediaLocation()
        dialog.GetRegularMediaLocationTextBox.Text = GetRegularMediaLocation()
        dialog.GetAlternateMediaLocationTextBox.Text = GetAlternateMediaLocation()
        dialog.GetProgramsFileTextBox.Text = GetProgramsFile()
        dialog.GetWallpaperLocationTextBox.Text = GetWallpapersLocation()
        dialog.GetAnnounceTextBox.Text = GetAnnounce()
        dialog.GetBeginTime.Value = Date.Parse(GetBeginTime.Trim).ToString
        dialog.GetEndTime.Value = Date.Parse(GetEndTime.Trim).ToString
        BindProperty(dialog.GetModeDropDown, GetEnum(New Mode))
        dialog.GetModeDropDown.Text = GetMode()
        BindProperty(dialog.GetRateDropDown, GetEnum(New Rate))
        dialog.GetRateDropDown.Text = GetRate()
        dialog.GetStartWithPCCheckBox.Checked = GetStartWithPC()
    End Sub

#End Region

End Class
