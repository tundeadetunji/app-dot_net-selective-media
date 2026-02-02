Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports System.IO
Imports System.Collections.ObjectModel
Imports SelectiveMedia.Strings
Imports iNovation.Code.GeneralExtensions
Imports SelectiveMedia.Files
Imports iNovation.Variant

Public Class Form1 : Implements IDialogResource

#Region "Overrides"
    Public Function GetChangeWallpaperCheckBox() As CheckBox Implements IDialogResource.GetChangeWallpaperCheckBox
        Return ChangeWallpaperCheckBox
    End Function

    Public Function GetStartWithPCCheckBox() As CheckBox Implements IDialogResource.GetStartWithPCCheckBox
        Return StartWithPCCheckBox
    End Function
    Public Function GetHelpIcon() As PictureBox Implements IDialogResource.GetHelpIcon
        Return HelpIcon
    End Function

    Public Function GetDialogTitleLabel() As Label Implements IDialogResource.GetDialogTitleLabel
        Return DialogTitle
    End Function

    Public Function GetDialog() As Form Implements IDialogResource.GetDialog
        Return Me
    End Function
    Public Function GetNightMediaLocationTextBox() As TextBox Implements IDialogResource.GetNightMediaLocationTextBox
        Return NightMediaLocationTextBox
    End Function

    Public Function GetRegularMediaLocationTextBox() As TextBox Implements IDialogResource.GetRegularMediaLocationTextBox
        Return RegularMediaLocationTextBox
    End Function

    Public Function GetAlternateMediaLocationTextBox() As TextBox Implements IDialogResource.GetAlternateMediaLocationTextBox
        Return AlternateMediaLocationTextBox
    End Function

    Public Function GetProgramsFileTextBox() As TextBox Implements IDialogResource.GetProgramsFileTextBox
        Return ProgramsFileTextBox
    End Function

    Public Function GetWallpaperLocationTextBox() As TextBox Implements IDialogResource.GetWallpaperLocationTextBox
        Return WallpaperLocationTextBox
    End Function

    Public Function GetAnnounceTextBox() As TextBox Implements IDialogResource.GetAnnounceTextBox
        Return AnnounceTextBox
    End Function

    Public Function GetBeginTime() As DateTimePicker Implements IDialogResource.GetBeginTime
        Return BeginTime
    End Function

    Public Function GetEndTime() As DateTimePicker Implements IDialogResource.GetEndTime
        Return EndTime
    End Function

    Public Function GetModeDropDown() As ComboBox Implements IDialogResource.GetModeDropDown
        Return ModeDropDown
    End Function

    Public Function GetRateDropDown() As ComboBox Implements IDialogResource.GetRateDropDown
        Return RateDropDown
    End Function

    Public Function GetMediaTimer() As Timer Implements IDialogResource.GetMediaTimer
        Return MediaTimer
    End Function

    Public Function GetDayTimer() As Timer Implements IDialogResource.GetDayTimer
        Return DayTimer
    End Function

    Public Function GetNightTimer() As Timer Implements IDialogResource.GetNightTimer
        Return NightTimer
    End Function

    Public Function GetCloseDialogButton() As Label Implements IDialogResource.GetCloseDialogButton
        Return CloseDialogButton
    End Function

#End Region

#Region "Properties"
    Private ReadOnly Property state As StateService = StateService.Instance(False, MediaSection.Alternate)

#End Region

#Region "Access"
    Private ReadOnly Property service As ServiceFactory = ServiceFactory.Instance

#End Region

#Region "Notify Icon Related"
    Private Sub AllAppsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllAppsToolStripMenuItem.Click
        TaskManager()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click

        With Me
            .Opacity = 0
            .TopMost = True
            .ShowInTaskbar = True
            .FadeInTimer.Enabled = True
        End With
    End Sub


#End Region

#Region "Control Box Related"
    Private Sub CloseDialogButton_Click(sender As Object, e As EventArgs) Handles CloseDialogButton.Click
        If service.settings.Validated(Me) Then
            service.settings.SaveSettings(Me)
            service.ui.ToggleVisibilityOfHiddenControls(Me, False)
            FadeOutTimer.Enabled = True
            service.app.Start(Me, service.desktop, service.disk, service.history, service.settings, state)
        End If
    End Sub
    Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs) Handles FadeInTimer.Tick
        Me.Visible = True
        If Me.Opacity >= 1 Then
            FadeInTimer.Enabled = False
            ShowInTaskbar = True
            Exit Sub
        End If
        Me.Opacity += 0.2
    End Sub
    Private Sub FadeOutTimer_Tick(sender As Object, e As EventArgs) Handles FadeOutTimer.Tick
        If Me.Opacity <= 0 Then
            FadeOutTimer.Enabled = False
            Me.Visible = False
            ShowInTaskbar = False
            Return
        End If
        Me.Opacity -= 0.2
    End Sub

#End Region

#Region "Form1 Events Related"
    Private Sub DropDown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ModeDropDown.KeyPress, RateDropDown.KeyPress
        AllowNothing(e)
    End Sub

    Private Sub HelpIcon_Click(sender As Object, e As EventArgs) Handles HelpIcon.Click
        StartFile(HelpFile)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        With EditToolStripMenuItem
            If .Text = Edit Then 'it's locked, so make it edit
                .Text = Lock
                .Image = Image.FromFile(LockIcon)
                'make controls editable
                service.ui.ToggleEditingTextBoxes(Me, False)
                Return
            End If
            .Text = Edit
            .Image = Image.FromFile(EditIcon)
            'make controls locked
            service.ui.ToggleEditingTextBoxes(Me, True)
        End With
    End Sub

    Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        service.ui.ToggleVisibilityOfHiddenControls(Me, Not BeginTime.Visible)
    End Sub

    Private Sub NightMediaLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles NightMediaLocationTextBox.DoubleClick, RegularMediaLocationTextBox.DoubleClick, AlternateMediaLocationTextBox.DoubleClick, WallpaperLocationTextBox.DoubleClick
        CType(sender, TextBox).Text = service.disk.PromptUserToSelectFolder(sender)
    End Sub
    Private Sub ProgramsFileTextBox_DoubleClick(sender As Object, e As EventArgs) Handles ProgramsFileTextBox.DoubleClick
        CType(sender, TextBox).Text = service.disk.PromptUserToSelectFile(sender)
    End Sub

    Private Sub NightMediaLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles NightMediaLocationTextBox.TextChanged
        'services.ui.SetPlaceholder(NightMediaLocationTextBox, "Videos to play between first and second time fields")
    End Sub

    Private Sub RegularMediaLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles RegularMediaLocationTextBox.TextChanged
        'services.ui.SetPlaceholder(RegularMediaLocationTextBox, "Videos to play between second and first time fields initially")
    End Sub

    Private Sub AlternateMediaLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles AlternateMediaLocationTextBox.TextChanged
        'services.ui.SetPlaceholder(RegularMediaLocationTextBox, "Videos to play between second and first time fields alternately")
    End Sub

    Private Sub ProgramsFileTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProgramsFileTextBox.TextChanged
        'services.ui.SetPlaceholder(ProgramsFileTextBox, "File containing applications to run instead of videos")
    End Sub

    Private Sub WallpaperLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles WallpaperLocationTextBox.TextChanged
        'services.ui.SetPlaceholder(WallpaperLocationTextBox, "Images to select from for wallpaper")
    End Sub

    Private Sub AnnounceTextBox_TextChanged(sender As Object, e As EventArgs) Handles AnnounceTextBox.TextChanged
        'services.ui.SetPlaceholder(AnnounceTextBox, "Announce when starting sequential play")
    End Sub

    Private Sub StartWithPCCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartWithPCCheckBox.CheckedChanged
        service.settings.SetShouldStartWithPC(StartWithPCCheckBox.Checked, False)
    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FadeInTimer.Enabled = False

        Try
            service.disk.SetPermissions()
        Catch ex As Exception

        End Try

        service.ui.HideDialog(Me)

        service.ui.InitializeDialog(Me)

        service.settings.RestoreSettings(Me)

        service.ui.AwaitUserInteraction(Me)

        If Not service.app.CanStart(Me, service.settings) Then
            FadeInTimer.Enabled = True
        Else
            FadeInTimer.Enabled = False
            service.app.Start(Me, service.desktop, service.disk, service.history, service.settings, state)
        End If
    End Sub

    Private Sub MediaTimer_Tick(sender As Object, e As EventArgs) Handles MediaTimer.Tick
        MediaTimer.Enabled = False
        If Support.PlayerIsOn(Files.PlayersFile) Then
            If service.settings.GetMode().EqualsIgnoreCase(Random) Then
                MediaTimer.Interval = TwoMinutes
            End If
            MediaTimer.Enabled = True
            Exit Sub
        End If

        service.playback.StartMedia(Me, service.app, service.desktop, service.disk, service.history, service.settings, state)
        MediaTimer.Enabled = True
    End Sub

    Private Sub PinMediaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PinMediaToolStripMenuItem.Click

    End Sub
End Class
