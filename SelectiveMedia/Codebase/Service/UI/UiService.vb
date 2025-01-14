Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Runtime.Remoting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Public Class UiService
#Region "Initialization"
	Public Shared ReadOnly Property Instance As New UiService
	Private Sub New()
	End Sub


#End Region

#Region "Properties"
	Private ReadOnly Property services As ServiceFactory = ServiceFactory.Instance
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
	Private Sub SetHiddenControls(dialog As IDialogResource)
		dialog.GetBeginTime.Value = Date.Parse(services.settings.GetBeginTime)
		dialog.GetEndTime.Value = Date.Parse(services.settings.GetEndTime)
		BindProperty(dialog.GetModeDropDown, GetEnum(New Mode))
		dialog.GetModeDropDown.Text = services.settings.GetMode
		BindProperty(dialog.GetRateDropDown, GetEnum(New Rate))
		dialog.GetRateDropDown.Text = services.settings.GetRate
	End Sub

#End Region
#Region "Exported"
	Public Sub OnStartup(dialog As IDialogResource)
		SetHelp(dialog.GetHelpIcon)
		dialog.GetDialog.Text = "PC Transform"
		dialog.GetDialogTitleLabel.Text = "Settings"
		SetHiddenControls(dialog)
		HideHiddenControls(dialog)
	End Sub
	Public Sub HideDialog(dialog As IDialogResource)
		dialog.GetDialog.Hide()
		dialog.GetDialog.Visible = False
		dialog.GetDialog.Opacity = 0
	End Sub
	Public Sub HideHiddenControls(dialog As IDialogResource)
		dialog.GetBeginTime.Visible = False
		dialog.GetEndTime.Visible = False
		dialog.GetModeDropDown.Visible = False
		dialog.GetRateDropDown.Visible = False
	End Sub

#End Region
End Class
