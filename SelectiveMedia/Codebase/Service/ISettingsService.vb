Public Interface ISettingsService
    Sub SaveSettings(dialog As IDialogResource)
    Sub SetAlternateMediaLocation(location As String)
    Sub SetAnnounce(announcement As String)
    Sub SetBeginTime(begin_time As String)
    Sub SetEndTime(end_time As String)
    Sub SetMode(_mode As String)
    Sub SetNightMediaLocation(location As String)
    Sub SetProgramsFile(value As String)
    Sub SetRate(_rate As String)
    Sub SetRegularMediaLocation(location As String)
    Sub SetShouldChangeWallpaper(state As Boolean)
    Sub SetShouldStartWithPC(state As Boolean, shouldUpdateRegistry As Boolean)
    Sub SetWallpapersLocation(location As String)
    Function GetAlternateMediaLocation() As String
    Function GetAnnounce() As String
    Function GetBeginTime() As String
    Function GetEndTime() As String
    Function GetMode() As String
    Function GetNightMediaLocation() As String
    Function GetProgramsFile() As String
    Function GetRate() As String
    Function GetRegularMediaLocation() As String
    Function GetWallpapersLocation() As String
    Function ShouldChangeWallpaper() As Boolean
    Function ShouldStartWithPC() As Boolean
    Function Validated(dialog As IDialogResource) As Boolean
    Sub RestoreSettings(dialog As IDialogResource)

End Interface
