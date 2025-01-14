Public Interface IDialogResource
    Function GetHelpIcon() As PictureBox
    Function GetDialogTitleLabel() As Label
    Function GetDialog() As Form
    Function GetNightMediaLocationTextBox() As TextBox
    Function GetRegularMediaLocationTextBox() As TextBox
    Function GetAlternateMediaLocationTextBox() As TextBox
    Function GetProgramsFileTextBox() As TextBox
    Function GetWallpaperLocationTextBox() As TextBox
    Function GetAnnounceTextBox() As TextBox
    Function GetBeginTime() As DateTimePicker
    Function GetEndTime() As DateTimePicker
    Function GetModeDropDown() As ComboBox
    Function GetRateDropDown() As ComboBox
End Interface
