Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Runtime.Remoting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports SelectiveMedia.Strings
Public Class UiService
    Implements IUiService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As UiService = New UiService
    Private Sub New()

    End Sub
#End Region


#Region "OS API"
    Private Declare Function SendMessage Lib "User32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    Private Declare Sub ReleaseCapture Lib "User32" ()
    Const WM_NCLBUTTONDOWN As Short = &HA1S
    Const HTCAPTION As Short = 2

    Private Sub DialogMouseMove(sender As Object, e As MouseEventArgs)
        Dim Button As Short = e.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = (e.X)
        Dim Y As Single = (e.Y)
        Dim lngReturnValue As Integer
        If Button = 1 Then
            Call ReleaseCapture()
            lngReturnValue = SendMessage(sender.Handle.ToInt32, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If

    End Sub


#End Region

#Region "Support"
    Private Sub StyleControls(dialog As IDialogResource)
        For Each component As Control In dialog.GetDialog.Controls
            If TypeOf component Is TextBox Or TypeOf component Is ComboBox Or TypeOf component Is DateTimePicker Then
                component.BackColor = Colors.background_color
                component.ForeColor = Colors.foregroud_color
            End If
        Next
    End Sub

    Private Sub SetHelp(HelpIcon As PictureBox)
        Dim s_manual As New ToolTip()
        s_manual.ToolTipIcon = ToolTipIcon.Info
        s_manual.UseAnimation = True
        s_manual.BackColor = Color.White
        s_manual.IsBalloon = True
        s_manual.UseFading = True
        s_manual.ToolTipTitle = "Need a tip?"
        s_manual.SetToolTip(HelpIcon, "Click for Help!")
    End Sub

#End Region

#Region "Exported"
    Public Sub InitializeDialog(dialog As IDialogResource) Implements IUiService.InitializeDialog
        AddHandler dialog.GetDialog.MouseMove, New MouseEventHandler(AddressOf DialogMouseMove)

        SetHelp(dialog.GetHelpIcon)
        dialog.GetDialog.Text = "Media"
        dialog.GetDialog.BackColor = Colors.background_color
        dialog.GetDialogTitleLabel.Text = "Settings"
        ToggleVisibilityOfHiddenControls(dialog, False)
        dialog.GetCloseDialogButton.Text = ChrW(10539)
        'dialog.GetDialog().ShowInTaskbar = False
        StyleControls(dialog)


    End Sub

    Public Sub AwaitUserInteraction(dialog As IDialogResource) Implements IUiService.AwaitUserInteraction
        With dialog.GetAnnounceTextBox
            .Focus()
            .SelectionStart = .Text.Length
            .SelectionLength = 0
        End With

    End Sub

    Public Sub HideDialog(dialog As IDialogResource) Implements IUiService.HideDialog
        dialog.GetDialog.Hide()
        dialog.GetDialog.Visible = False
        dialog.GetDialog.Opacity = 0
    End Sub
    Public Sub ToggleVisibilityOfHiddenControls(dialog As IDialogResource, visible As Boolean) Implements IUiService.ToggleVisibilityOfHiddenControls
        dialog.GetBeginTime.Visible = visible
        dialog.GetEndTime.Visible = visible
        dialog.GetModeDropDown.Visible = visible
        dialog.GetRateDropDown.Visible = visible
        dialog.GetStartWithPCCheckBox.Visible = visible
        dialog.GetChangeWallpaperCheckBox.Visible = visible
    End Sub

    Public Sub ToggleEditingTextBoxes(dialog As IDialogResource, state As Boolean) Implements IUiService.ToggleEditingTextBoxes
        dialog.GetNightMediaLocationTextBox.ReadOnly = state
        dialog.GetRegularMediaLocationTextBox.ReadOnly = state
        dialog.GetAlternateMediaLocationTextBox.ReadOnly = state
        dialog.GetProgramsFileTextBox.ReadOnly = state
        dialog.GetWallpaperLocationTextBox.ReadOnly = state
        dialog.GetAnnounceTextBox.ReadOnly = state
    End Sub

#End Region
End Class
