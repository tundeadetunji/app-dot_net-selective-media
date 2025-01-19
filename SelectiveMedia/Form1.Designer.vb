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
        Me.TimeTimer = New System.Windows.Forms.Timer(Me.components)
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
        Me.WTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MediaTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ModeDropDown = New System.Windows.Forms.ComboBox()
        Me.RateDropDown = New System.Windows.Forms.ComboBox()
        Me.AnnounceTextBox = New System.Windows.Forms.TextBox()
        Me.HelpIcon = New System.Windows.Forms.PictureBox()
        Me.ProgramsFileTextBox = New System.Windows.Forms.TextBox()
        Me.TopBorder = New System.Windows.Forms.PictureBox()
        Me.BottomBorder = New System.Windows.Forms.PictureBox()
        Me.LeftBorder = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CloseDialogButton = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimeTimer
        '
        Me.TimeTimer.Enabled = True
        Me.TimeTimer.Interval = 1000
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
        Me.NightMediaLocationTextBox.TabIndex = 4
        '
        'RegularMediaLocationTextBox
        '
        Me.RegularMediaLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.RegularMediaLocationTextBox.Location = New System.Drawing.Point(14, 95)
        Me.RegularMediaLocationTextBox.Name = "RegularMediaLocationTextBox"
        Me.RegularMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.RegularMediaLocationTextBox.TabIndex = 5
        '
        'AlternateMediaLocationTextBox
        '
        Me.AlternateMediaLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.AlternateMediaLocationTextBox.Location = New System.Drawing.Point(14, 127)
        Me.AlternateMediaLocationTextBox.Name = "AlternateMediaLocationTextBox"
        Me.AlternateMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.AlternateMediaLocationTextBox.TabIndex = 6
        '
        'EndTime
        '
        Me.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.EndTime.Location = New System.Drawing.Point(14, 320)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(200, 26)
        Me.EndTime.TabIndex = 3
        Me.EndTime.Value = New Date(2018, 12, 31, 6, 0, 0, 0)
        '
        'BeginTime
        '
        Me.BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.BeginTime.Location = New System.Drawing.Point(14, 288)
        Me.BeginTime.Name = "BeginTime"
        Me.BeginTime.Size = New System.Drawing.Size(200, 26)
        Me.BeginTime.TabIndex = 2
        Me.BeginTime.Value = New Date(2018, 12, 31, 0, 0, 0, 0)
        '
        'WallpaperLocationTextBox
        '
        Me.WallpaperLocationTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.WallpaperLocationTextBox.Location = New System.Drawing.Point(14, 191)
        Me.WallpaperLocationTextBox.Name = "WallpaperLocationTextBox"
        Me.WallpaperLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.WallpaperLocationTextBox.TabIndex = 8
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
        'WTimer
        '
        Me.WTimer.Interval = 1000
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
        Me.ModeDropDown.TabIndex = 0
        Me.ModeDropDown.Tag = "f"
        '
        'RateDropDown
        '
        Me.RateDropDown.FormattingEnabled = True
        Me.RateDropDown.Location = New System.Drawing.Point(14, 386)
        Me.RateDropDown.Name = "RateDropDown"
        Me.RateDropDown.Size = New System.Drawing.Size(202, 28)
        Me.RateDropDown.TabIndex = 1
        Me.RateDropDown.Tag = "f"
        '
        'AnnounceTextBox
        '
        Me.AnnounceTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.AnnounceTextBox.Location = New System.Drawing.Point(14, 223)
        Me.AnnounceTextBox.Name = "AnnounceTextBox"
        Me.AnnounceTextBox.Size = New System.Drawing.Size(406, 26)
        Me.AnnounceTextBox.TabIndex = 9
        '
        'HelpIcon
        '
        Me.HelpIcon.BackColor = System.Drawing.Color.Transparent
        Me.HelpIcon.BackgroundImage = Global.SelectiveMedia.My.Resources.Resources.girl_idea_icon_128
        Me.HelpIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.HelpIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HelpIcon.Location = New System.Drawing.Point(14, 422)
        Me.HelpIcon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.HelpIcon.Name = "HelpIcon"
        Me.HelpIcon.Size = New System.Drawing.Size(90, 90)
        Me.HelpIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.HelpIcon.TabIndex = 16771
        Me.HelpIcon.TabStop = False
        '
        'ProgramsFileTextBox
        '
        Me.ProgramsFileTextBox.ForeColor = System.Drawing.Color.Wheat
        Me.ProgramsFileTextBox.Location = New System.Drawing.Point(14, 159)
        Me.ProgramsFileTextBox.Name = "ProgramsFileTextBox"
        Me.ProgramsFileTextBox.Size = New System.Drawing.Size(406, 26)
        Me.ProgramsFileTextBox.TabIndex = 7
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
        'BottomBorder
        '
        Me.BottomBorder.BackColor = System.Drawing.Color.Black
        Me.BottomBorder.Location = New System.Drawing.Point(0, 629)
        Me.BottomBorder.Name = "BottomBorder"
        Me.BottomBorder.Size = New System.Drawing.Size(434, 1)
        Me.BottomBorder.TabIndex = 16773
        Me.BottomBorder.TabStop = False
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
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Location = New System.Drawing.Point(433, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1, 630)
        Me.PictureBox1.TabIndex = 16775
        Me.PictureBox1.TabStop = False
        '
        'CloseDialogButton
        '
        Me.CloseDialogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseDialogButton.AutoSize = True
        Me.CloseDialogButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseDialogButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseDialogButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseDialogButton.ForeColor = System.Drawing.Color.Black
        Me.CloseDialogButton.Location = New System.Drawing.Point(401, 15)
        Me.CloseDialogButton.Name = "CloseDialogButton"
        Me.CloseDialogButton.Size = New System.Drawing.Size(21, 24)
        Me.CloseDialogButton.TabIndex = 16776
        Me.CloseDialogButton.Text = "x"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Black
        Me.PictureBox2.Location = New System.Drawing.Point(0, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(434, 1)
        Me.PictureBox2.TabIndex = 16777
        Me.PictureBox2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 630)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CloseDialogButton)
        Me.Controls.Add(Me.PictureBox1)
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
        Me.Text = "Settings"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimeTimer As Timer
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
    Friend WithEvents WTimer As Timer
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
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CloseDialogButton As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
