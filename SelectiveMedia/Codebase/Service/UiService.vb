Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Runtime.Remoting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Public Class UiService

#Region "Initialization"
	Public Shared ReadOnly Property Instance As UiService = New UiService
	Private Sub New()

	End Sub
#End Region

#Region "Constants"
	Public Shared ReadOnly Property background_color As Color = Color.FromArgb(34, 34, 34)

#End Region

#Region "Support"
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
	Public Sub InitializeDialog(dialog As IDialogResource)
		SetHelp(dialog.GetHelpIcon)
		dialog.GetDialog.Text = "PC Transform"
		dialog.GetDialog.BackColor = background_color
		dialog.GetDialogTitleLabel.Text = "Settings"
		ShowOrHideInitiallyHiddenControls(dialog, False)
		dialog.GetCloseDialogButton.Text = ChrW(10539)
	End Sub
	Public Sub HideDialog(dialog As IDialogResource)
		dialog.GetDialog.Hide()
		dialog.GetDialog.Visible = False
		dialog.GetDialog.Opacity = 0
	End Sub
	Public Sub ShowOrHideInitiallyHiddenControls(dialog As IDialogResource, visible As Boolean)
		dialog.GetBeginTime.Visible = visible
		dialog.GetEndTime.Visible = visible
		dialog.GetModeDropDown.Visible = visible
		dialog.GetRateDropDown.Visible = visible
	End Sub

#End Region
End Class
