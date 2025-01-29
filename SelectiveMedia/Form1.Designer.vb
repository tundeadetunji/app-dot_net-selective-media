<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DialogTitle = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.NightMediaLocationTextBox = New System.Windows.Forms.TextBox()
        Me.RegularMediaLocationTextBox = New System.Windows.Forms.TextBox()
        Me.AlternateMediaLocationTextBox = New System.Windows.Forms.TextBox()
        Me.EndTime = New System.Windows.Forms.DateTimePicker()
        Me.BeginTime = New System.Windows.Forms.DateTimePicker()
        Me.WallpaperLocationTextBox = New System.Windows.Forms.TextBox()
        Me.DayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NightTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllAppsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FadeOutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FadeInTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MediaTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ModeDropDown = New System.Windows.Forms.ComboBox()
        Me.RateDropDown = New System.Windows.Forms.ComboBox()
        Me.AnnounceTextBox = New System.Windows.Forms.TextBox()
        Me.ProgramsFileTextBox = New System.Windows.Forms.TextBox()
        Me.CloseDialogButton = New System.Windows.Forms.Label()
        Me.DialogContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Divider = New System.Windows.Forms.PictureBox()
        Me.LeftBorder = New System.Windows.Forms.PictureBox()
        Me.BottomBorder = New System.Windows.Forms.PictureBox()
        Me.TopBorder = New System.Windows.Forms.PictureBox()
        Me.HelpIcon = New System.Windows.Forms.PictureBox()
        Me.RightBorder = New System.Windows.Forms.PictureBox()
        Me.StartWithPCCheckBox = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.DialogContextMenuStrip.SuspendLayout()
        CType(Me.Divider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DialogTitle
        '
        Me.DialogTitle.AutoSize = True
        Me.DialogTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.DialogTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogTitle.Location = New System.Drawing.Point(11, 18)
        Me.DialogTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DialogTitle.Name = "DialogTitle"
        Me.DialogTitle.Size = New System.Drawing.Size(76, 20)
        Me.DialogTitle.TabIndex = 14579
        Me.DialogTitle.Text = "Settings"
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Location = New System.Drawing.Point(348, 392)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(0, 20)
        Me.TimeLabel.TabIndex = 14586
        '
        'NightMediaLocationTextBox
        '
        Me.NightMediaLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.NightMediaLocationTextBox.Location = New System.Drawing.Point(14, 63)
        Me.NightMediaLocationTextBox.Name = "NightMediaLocationTextBox"
        Me.NightMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.NightMediaLocationTextBox.TabIndex = 1
        '
        'RegularMediaLocationTextBox
        '
        Me.RegularMediaLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.RegularMediaLocationTextBox.Location = New System.Drawing.Point(14, 95)
        Me.RegularMediaLocationTextBox.Name = "RegularMediaLocationTextBox"
        Me.RegularMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.RegularMediaLocationTextBox.TabIndex = 2
        '
        'AlternateMediaLocationTextBox
        '
        Me.AlternateMediaLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.AlternateMediaLocationTextBox.Location = New System.Drawing.Point(14, 127)
        Me.AlternateMediaLocationTextBox.Name = "AlternateMediaLocationTextBox"
        Me.AlternateMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.AlternateMediaLocationTextBox.TabIndex = 3
        '
        'EndTime
        '
        Me.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.EndTime.Location = New System.Drawing.Point(14, 320)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(200, 26)
        Me.EndTime.TabIndex = 7
        Me.EndTime.Value = New Date(2018, 12, 31, 6, 0, 0, 0)
        '
        'BeginTime
        '
        Me.BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.BeginTime.Location = New System.Drawing.Point(14, 288)
        Me.BeginTime.Name = "BeginTime"
        Me.BeginTime.Size = New System.Drawing.Size(200, 26)
        Me.BeginTime.TabIndex = 6
        Me.BeginTime.Value = New Date(2018, 12, 31, 0, 0, 0, 0)
        '
        'WallpaperLocationTextBox
        '
        Me.WallpaperLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.WallpaperLocationTextBox.Location = New System.Drawing.Point(14, 191)
        Me.WallpaperLocationTextBox.Name = "WallpaperLocationTextBox"
        Me.WallpaperLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.WallpaperLocationTextBox.TabIndex = 5
        '
        'DayTimer
        '
        Me.DayTimer.Interval = 1000
        '
        'NightTimer
        '
        Me.NightTimer.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Media"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.ToolStripMenuItem21, Me.AllAppsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 58)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Image = Global.SelectiveMedia.My.Resources.Resources.Gartoon_Team_Gartoon_Places_User_home_1024
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(179, 24)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        Me.ToolStripMenuItem21.Size = New System.Drawing.Size(176, 6)
        '
        'AllAppsToolStripMenuItem
        '
        Me.AllAppsToolStripMenuItem.Image = Global.SelectiveMedia.My.Resources.Resources.ICS_client
        Me.AllAppsToolStripMenuItem.Name = "AllAppsToolStripMenuItem"
        Me.AllAppsToolStripMenuItem.Size = New System.Drawing.Size(179, 24)
        Me.AllAppsToolStripMenuItem.Text = "Task Manager"
        '
        'FadeOutTimer
        '
        '
        'FadeInTimer
        '
        '
        'MediaTimer
        '
        Me.MediaTimer.Interval = 1000
        '
        'ModeDropDown
        '
        Me.ModeDropDown.FormattingEnabled = True
        Me.ModeDropDown.Location = New System.Drawing.Point(14, 352)
        Me.ModeDropDown.Name = "ModeDropDown"
        Me.ModeDropDown.Size = New System.Drawing.Size(202, 28)
        Me.ModeDropDown.TabIndex = 8
        Me.ModeDropDown.Tag = "f"
        '
        'RateDropDown
        '
        Me.RateDropDown.FormattingEnabled = True
        Me.RateDropDown.Location = New System.Drawing.Point(14, 386)
        Me.RateDropDown.Name = "RateDropDown"
        Me.RateDropDown.Size = New System.Drawing.Size(202, 28)
        Me.RateDropDown.TabIndex = 9
        Me.RateDropDown.Tag = "f"
        '
        'AnnounceTextBox
        '
        Me.AnnounceTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.AnnounceTextBox.Location = New System.Drawing.Point(14, 223)
        Me.AnnounceTextBox.Name = "AnnounceTextBox"
        Me.AnnounceTextBox.Size = New System.Drawing.Size(406, 26)
        Me.AnnounceTextBox.TabIndex = 0
        '
        'ProgramsFileTextBox
        '
        Me.ProgramsFileTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.ProgramsFileTextBox.Location = New System.Drawing.Point(14, 159)
        Me.ProgramsFileTextBox.Name = "ProgramsFileTextBox"
        Me.ProgramsFileTextBox.Size = New System.Drawing.Size(406, 26)
        Me.ProgramsFileTextBox.TabIndex = 4
        '
        'CloseDialogButton
        '
        Me.CloseDialogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseDialogButton.AutoSize = True
        Me.CloseDialogButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseDialogButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseDialogButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseDialogButton.ForeColor = System.Drawing.Color.AntiqueWhite
        Me.CloseDialogButton.Location = New System.Drawing.Point(401, 15)
        Me.CloseDialogButton.Name = "CloseDialogButton"
        Me.CloseDialogButton.Size = New System.Drawing.Size(21, 24)
        Me.CloseDialogButton.TabIndex = 16776
        Me.CloseDialogButton.Text = "x"
        '
        'DialogContextMenuStrip
        '
        Me.DialogContextMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.DialogContextMenuStrip.Name = "ContextMenuStrip1"
        Me.DialogContextMenuStrip.Size = New System.Drawing.Size(107, 58)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.SelectiveMedia.My.Resources.Resources.Gartoon_Team_Gartoon_Action_Draw_freehand_pencil_1024
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(106, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(103, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.SelectiveMedia.My.Resources.Resources.Iconsmind_Outline_Power_3_512
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(106, 24)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Divider
        '
        Me.Divider.BackColor = System.Drawing.Color.Black
        Me.Divider.Location = New System.Drawing.Point(0, 48)
        Me.Divider.Name = "Divider"
        Me.Divider.Size = New System.Drawing.Size(434, 1)
        Me.Divider.TabIndex = 16777
        Me.Divider.TabStop = False
        '
        'LeftBorder
        '
        Me.LeftBorder.BackColor = System.Drawing.Color.Black
        Me.LeftBorder.Location = New System.Drawing.Point(0, 0)
        Me.LeftBorder.Name = "LeftBorder"
        Me.LeftBorder.Size = New System.Drawing.Size(1, 630)
        Me.LeftBorder.TabIndex = 16774
        Me.LeftBorder.TabStop = False
        '
        'BottomBorder
        '
        Me.BottomBorder.BackColor = System.Drawing.Color.Black
        Me.BottomBorder.Location = New System.Drawing.Point(0, 629)
        Me.BottomBorder.Name = "BottomBorder"
        Me.BottomBorder.Size = New System.Drawing.Size(434, 1)
        Me.BottomBorder.TabIndex = 16773
        Me.BottomBorder.TabStop = False
        '
        'TopBorder
        '
        Me.TopBorder.BackColor = System.Drawing.Color.Black
        Me.TopBorder.Location = New System.Drawing.Point(0, 0)
        Me.TopBorder.Name = "TopBorder"
        Me.TopBorder.Size = New System.Drawing.Size(434, 1)
        Me.TopBorder.TabIndex = 16772
        Me.TopBorder.TabStop = False
        '
        'HelpIcon
        '
        Me.HelpIcon.BackColor = System.Drawing.Color.Transparent
        Me.HelpIcon.BackgroundImage = Global.SelectiveMedia.My.Resources.Resources.girl_idea_icon_128
        Me.HelpIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.HelpIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HelpIcon.Location = New System.Drawing.Point(14, 452)
        Me.HelpIcon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.HelpIcon.Name = "HelpIcon"
        Me.HelpIcon.Size = New System.Drawing.Size(90, 90)
        Me.HelpIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.HelpIcon.TabIndex = 16771
        Me.HelpIcon.TabStop = False
        '
        'RightBorder
        '
        Me.RightBorder.BackColor = System.Drawing.Color.Black
        Me.RightBorder.Location = New System.Drawing.Point(433, 0)
        Me.RightBorder.Name = "RightBorder"
        Me.RightBorder.Size = New System.Drawing.Size(1, 630)
        Me.RightBorder.TabIndex = 16778
        Me.RightBorder.TabStop = False
        '
        'StartWithPCCheckBox
        '
        Me.StartWithPCCheckBox.AutoSize = True
        Me.StartWithPCCheckBox.Location = New System.Drawing.Point(14, 420)
        Me.StartWithPCCheckBox.Name = "StartWithPCCheckBox"
        Me.StartWithPCCheckBox.Size = New System.Drawing.Size(147, 24)
        Me.StartWithPCCheckBox.TabIndex = 10
        Me.StartWithPCCheckBox.Text = "Start with the PC"
        Me.StartWithPCCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 630)
        Me.Controls.Add(Me.StartWithPCCheckBox)
        Me.Controls.Add(Me.RightBorder)
        Me.Controls.Add(Me.Divider)
        Me.Controls.Add(Me.CloseDialogButton)
        Me.Controls.Add(Me.LeftBorder)
        Me.Controls.Add(Me.BottomBorder)
        Me.Controls.Add(Me.TopBorder)
        Me.Controls.Add(Me.ProgramsFileTextBox)
        Me.Controls.Add(Me.HelpIcon)
        Me.Controls.Add(Me.AnnounceTextBox)
        Me.Controls.Add(Me.RateDropDown)
        Me.Controls.Add(Me.ModeDropDown)
        Me.Controls.Add(Me.WallpaperLocationTextBox)
        Me.Controls.Add(Me.BeginTime)
        Me.Controls.Add(Me.EndTime)
        Me.Controls.Add(Me.AlternateMediaLocationTextBox)
        Me.Controls.Add(Me.RegularMediaLocationTextBox)
        Me.Controls.Add(Me.NightMediaLocationTextBox)
        Me.Controls.Add(Me.DialogTitle)
        Me.Controls.Add(Me.TimeLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Wheat
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(434, 630)
        Me.Name = "Form1"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Media"
        Me.TopMost = True
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.DialogContextMenuStrip.ResumeLayout(False)
        CType(Me.Divider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DialogTitle As Label
    Friend WithEvents TimeLabel As Label
    Friend WithEvents NightMediaLocationTextBox As TextBox
    Friend WithEvents RegularMediaLocationTextBox As TextBox
    Friend WithEvents AlternateMediaLocationTextBox As TextBox
    Friend WithEvents EndTime As DateTimePicker
    Friend WithEvents BeginTime As DateTimePicker
    Friend WithEvents WallpaperLocationTextBox As TextBox
    Friend WithEvents DayTimer As Timer
    Friend WithEvents NightTimer As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FadeOutTimer As Timer
    Friend WithEvents FadeInTimer As Timer
    Friend WithEvents MediaTimer As Timer
    Friend WithEvents ModeDropDown As ComboBox
    Friend WithEvents RateDropDown As ComboBox
    Friend WithEvents AnnounceTextBox As TextBox
    Friend WithEvents ToolStripMenuItem21 As ToolStripSeparator
    Friend WithEvents AllAppsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpIcon As PictureBox
    Friend WithEvents ProgramsFileTextBox As TextBox
    Friend WithEvents TopBorder As PictureBox
    Friend WithEvents BottomBorder As PictureBox
    Friend WithEvents LeftBorder As PictureBox
    Friend WithEvents CloseDialogButton As Label
    Friend WithEvents Divider As PictureBox
    Friend WithEvents DialogContextMenuStrip As ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents RightBorder As PictureBox
    Friend WithEvents StartWithPCCheckBox As CheckBox
End Class
