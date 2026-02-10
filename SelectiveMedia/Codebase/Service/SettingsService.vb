Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports iNovation.Code.GeneralExtensions
Imports SelectiveMedia.Strings
Public Class SettingsService
    Implements ISettingsService

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
    Private ReadOnly Property ChangeWallpaperFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\ChangeWallpaper.txt"
    Private ReadOnly Property StartWithPCFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\StartWithPC.txt"

#End Region

#Region "Exported"
    ''' <summary>
    ''' All files are in place and locations are valid
    ''' </summary>
    ''' <returns></returns>
    Public Function Validated(dialog As IDialogResource) As Boolean Implements ISettingsService.Validated


        Dim valid As Boolean = True

        If Not IO.Directory.Exists(dialog.GetNightMediaLocationTextBox.Text) Then valid = False
        If Not IO.Directory.Exists(dialog.GetRegularMediaLocationTextBox.Text) Then valid = False
        If Not IO.Directory.Exists(dialog.GetAlternateMediaLocationTextBox.Text) Then valid = False

        'If Not ServiceFactory.Instance.disk.FolderContainsAnySupportedFile(dialog.GetNightMediaLocationTextBox.Text) Then valid = False

        'If Not IO.File.Exists(dialog.GetProgramsFileTextBox.Text) Then valid = False
        'If Not IO.Directory.Exists(dialog.GetWallpaperLocationTextBox.Text) Then valid = False
        If String.IsNullOrEmpty(dialog.GetModeDropDown.Text) Then valid = False
        If String.IsNullOrEmpty(dialog.GetRateDropDown.Text) Then valid = False

        Return valid
    End Function
    Public Sub SaveSettings(dialog As IDialogResource) Implements ISettingsService.SaveSettings

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
        SetShouldStartWithPC(dialog.GetStartWithPCCheckBox.Checked, True)
        SetShouldChangeWallpaper(dialog.GetChangeWallpaperCheckBox.Checked)
        'load
        'app.Start(dialog, desktop, disk, history, settings, state)
    End Sub

    Public Function ShouldChangeWallpaper() As Boolean Implements ISettingsService.ShouldChangeWallpaper
        Return Boolean.Parse(ReadText(ChangeWallpaperFile))
    End Function

    Public Sub SetShouldChangeWallpaper(state As Boolean) Implements ISettingsService.SetShouldChangeWallpaper
        WriteText(ChangeWallpaperFile, state)
    End Sub
    Public Function ShouldStartWithPC() As Boolean Implements ISettingsService.ShouldStartWithPC
        Return Boolean.Parse(ReadText(StartWithPCFile))
    End Function

    Public Sub SetShouldStartWithPC(state As Boolean, shouldUpdateRegistry As Boolean) Implements ISettingsService.SetShouldStartWithPC
        WriteText(StartWithPCFile, state)
        If shouldUpdateRegistry Then ToStartup(If(state, RegistryValue, RegistryValue.Replace(".exe", "")), RegistryKey)
    End Sub

    Public Function GetBeginTime() As String Implements ISettingsService.GetBeginTime
        Dim b_time_f As String = ReadText(BeginTimeFile)
        Return If(Not String.IsNullOrEmpty(b_time_f), b_time_f, "12:00 AM")
    End Function

    Public Sub SetBeginTime(begin_time As String) Implements ISettingsService.SetBeginTime
        WriteText(BeginTimeFile, begin_time)
    End Sub

    Public Function GetEndTime() As String Implements ISettingsService.GetEndTime
        Dim e_time_f As String = ReadText(EndTimeFile)
        Return If(Not String.IsNullOrEmpty(e_time_f), e_time_f, "6:00 AM")
    End Function

    Public Sub SetEndTime(end_time As String) Implements ISettingsService.SetEndTime
        WriteText(EndTimeFile, end_time)
    End Sub

    Public Function GetAnnounce() As String Implements ISettingsService.GetAnnounce
        Return ReadText(AnnounceFile)
    End Function
    Public Sub SetAnnounce(announcement As String) Implements ISettingsService.SetAnnounce
        WriteText(AnnounceFile, announcement)
    End Sub

    Public Function GetNightMediaLocation() As String Implements ISettingsService.GetNightMediaLocation
        Return ReadText(NightMediaLocationFile)
    End Function
    Public Sub SetNightMediaLocation(location As String) Implements ISettingsService.SetNightMediaLocation
        WriteText(NightMediaLocationFile, location)
    End Sub

    Public Function GetRegularMediaLocation() As String Implements ISettingsService.GetRegularMediaLocation
        Return ReadText(RegularMediaLocationFile)
    End Function
    Public Sub SetRegularMediaLocation(location As String) Implements ISettingsService.SetRegularMediaLocation
        WriteText(RegularMediaLocationFile, location)
    End Sub
    Public Function GetAlternateMediaLocation() As String Implements ISettingsService.GetAlternateMediaLocation
        Return ReadText(AlternateMediaLocationFile)
    End Function
    Public Sub SetAlternateMediaLocation(location As String) Implements ISettingsService.SetAlternateMediaLocation
        WriteText(AlternateMediaLocationFile, location)
    End Sub
    Public Function GetWallpapersLocation() As String Implements ISettingsService.GetWallpapersLocation
        Return ReadText(WallpapersLocationFile)
    End Function
    Public Sub SetWallpapersLocation(location As String) Implements ISettingsService.SetWallpapersLocation
        WriteText(WallpapersLocationFile, location)
    End Sub
    Public Function GetProgramsFile() As String Implements ISettingsService.GetProgramsFile
        Return ReadText(ProgramsFile)
    End Function

    Public Sub SetProgramsFile(value As String) Implements ISettingsService.SetProgramsFile
        WriteText(ProgramsFile, value)
    End Sub
    Public Function GetRate() As String Implements ISettingsService.GetRate
        Return ReadText(RateFile)
    End Function

    Public Sub SetRate(_rate As String) Implements ISettingsService.SetRate
        WriteText(RateFile, _rate)
    End Sub
    Public Function GetMode() As String Implements ISettingsService.GetMode
        Return ReadText(ModeFile)
    End Function

    Public Sub SetMode(_mode As String) Implements ISettingsService.SetMode
        WriteText(ModeFile, _mode)
    End Sub

    Public Sub RestoreSettings(dialog As IDialogResource) Implements ISettingsService.RestoreSettings
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
        dialog.GetStartWithPCCheckBox.Checked = ShouldStartWithPC()
        dialog.GetChangeWallpaperCheckBox.Checked = ShouldChangeWallpaper()
    End Sub

#End Region

End Class
