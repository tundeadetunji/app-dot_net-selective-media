﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.DayWTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NWTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllAppsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.InTimer = New System.Windows.Forms.Timer(Me.components)
        Me.WTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MediaTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FileDataSet = New SelectiveMedia.FileDataSet()
        Me.BBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BDataSet = New SelectiveMedia.FileDataSet()
        Me.CBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CDataSet = New SelectiveMedia.FileDataSet()
        Me.Settings_DataSet = New SelectiveMedia.FileDataSet()
        Me.FileCountDataSet = New SelectiveMedia.FileDataSet()
        Me.SoFarDataSet = New SelectiveMedia.FileDataSet()
        Me.EBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EDataSet = New SelectiveMedia.FileDataSet()
        Me.FolderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FolderDataSet = New SelectiveMedia.FileDataSet()
        Me.FileTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.FolderTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.FolderCounterTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.FileCounterATableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.WhereFolderTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.WhereFileTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.Settings_TableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingNTableAdapter()
        Me.FileCountTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.FileCountTableAdapter()
        Me.BTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingBTableAdapter()
        Me.CTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingCTableAdapter()
        Me.SoFarTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SoFarTableAdapter()
        Me.FileCounterBTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingBTableAdapter()
        Me.FileCounterCTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingCTableAdapter()
        Me.FileCounterETableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingETableAdapter()
        Me.ETableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingETableAdapter()
        Me.ACountTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.DialogTableAdapter()
        Me.BCountTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingBTableAdapter()
        Me.CCountTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingCTableAdapter()
        Me.ECountTableAdapter = New SelectiveMedia.FileDataSetTableAdapters.SettingETableAdapter()
        Me.ModeDropDown = New System.Windows.Forms.ComboBox()
        Me.RateDropDown = New System.Windows.Forms.ComboBox()
        Me.AnnounceTextBox = New System.Windows.Forms.TextBox()
        Me.HelpIcon = New System.Windows.Forms.PictureBox()
        Me.ProgramsFileTextBox = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.FileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Settings_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileCountDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoFarDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FolderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FolderDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DialogTitle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DialogTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogTitle.Location = New System.Drawing.Point(316, 333)
        Me.DialogTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DialogTitle.Name = "DialogTitle"
        Me.DialogTitle.Size = New System.Drawing.Size(0, 20)
        Me.DialogTitle.TabIndex = 14579
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
        Me.NightMediaLocationTextBox.Location = New System.Drawing.Point(14, 63)
        Me.NightMediaLocationTextBox.Name = "NightMediaLocationTextBox"
        Me.NightMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.NightMediaLocationTextBox.TabIndex = 4
        '
        'RegularMediaLocationTextBox
        '
        Me.RegularMediaLocationTextBox.Location = New System.Drawing.Point(14, 95)
        Me.RegularMediaLocationTextBox.Name = "RegularMediaLocationTextBox"
        Me.RegularMediaLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.RegularMediaLocationTextBox.TabIndex = 5
        '
        'AlternateMediaLocationTextBox
        '
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
        Me.EndTime.Visible = False
        '
        'BeginTime
        '
        Me.BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.BeginTime.Location = New System.Drawing.Point(14, 288)
        Me.BeginTime.Name = "BeginTime"
        Me.BeginTime.Size = New System.Drawing.Size(200, 26)
        Me.BeginTime.TabIndex = 2
        Me.BeginTime.Value = New Date(2018, 12, 31, 0, 0, 0, 0)
        Me.BeginTime.Visible = False
        '
        'WallpaperLocationTextBox
        '
        Me.WallpaperLocationTextBox.Location = New System.Drawing.Point(14, 191)
        Me.WallpaperLocationTextBox.Name = "WallpaperLocationTextBox"
        Me.WallpaperLocationTextBox.Size = New System.Drawing.Size(406, 26)
        Me.WallpaperLocationTextBox.TabIndex = 8
        '
        'DayWTimer
        '
        Me.DayWTimer.Interval = 1000
        '
        'NWTimer
        '
        Me.NWTimer.Interval = 1000
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
        'OutTimer
        '
        '
        'InTimer
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
        'FileBindingSource
        '
        Me.FileBindingSource.DataMember = "Dialog"
        Me.FileBindingSource.DataSource = Me.FileDataSet
        '
        'FileDataSet
        '
        Me.FileDataSet.DataSetName = "FileDataSet"
        Me.FileDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BBindingSource
        '
        Me.BBindingSource.DataMember = "SettingB"
        Me.BBindingSource.DataSource = Me.BDataSet
        '
        'BDataSet
        '
        Me.BDataSet.DataSetName = "FileDataSet"
        Me.BDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CBindingSource
        '
        Me.CBindingSource.DataMember = "SettingC"
        Me.CBindingSource.DataSource = Me.CDataSet
        '
        'CDataSet
        '
        Me.CDataSet.DataSetName = "FileDataSet"
        Me.CDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Settings_DataSet
        '
        Me.Settings_DataSet.DataSetName = "FileDataSet"
        Me.Settings_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FileCountDataSet
        '
        Me.FileCountDataSet.DataSetName = "FileDataSet"
        Me.FileCountDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SoFarDataSet
        '
        Me.SoFarDataSet.DataSetName = "FileDataSet"
        Me.SoFarDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EBindingSource
        '
        Me.EBindingSource.DataMember = "SettingE"
        Me.EBindingSource.DataSource = Me.EDataSet
        '
        'EDataSet
        '
        Me.EDataSet.DataSetName = "FileDataSet"
        Me.EDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FolderBindingSource
        '
        Me.FolderBindingSource.DataMember = "Dialog"
        Me.FolderBindingSource.DataSource = Me.FolderDataSet
        '
        'FolderDataSet
        '
        Me.FolderDataSet.DataSetName = "FileDataSet"
        Me.FolderDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FileTableAdapter
        '
        Me.FileTableAdapter.ClearBeforeFill = True
        '
        'FolderTableAdapter
        '
        Me.FolderTableAdapter.ClearBeforeFill = True
        '
        'FolderCounterTableAdapter
        '
        Me.FolderCounterTableAdapter.ClearBeforeFill = True
        '
        'FileCounterATableAdapter
        '
        Me.FileCounterATableAdapter.ClearBeforeFill = True
        '
        'WhereFolderTableAdapter
        '
        Me.WhereFolderTableAdapter.ClearBeforeFill = True
        '
        'WhereFileTableAdapter
        '
        Me.WhereFileTableAdapter.ClearBeforeFill = True
        '
        'Settings_TableAdapter
        '
        Me.Settings_TableAdapter.ClearBeforeFill = True
        '
        'FileCountTableAdapter
        '
        Me.FileCountTableAdapter.ClearBeforeFill = True
        '
        'BTableAdapter
        '
        Me.BTableAdapter.ClearBeforeFill = True
        '
        'CTableAdapter
        '
        Me.CTableAdapter.ClearBeforeFill = True
        '
        'SoFarTableAdapter
        '
        Me.SoFarTableAdapter.ClearBeforeFill = True
        '
        'FileCounterBTableAdapter
        '
        Me.FileCounterBTableAdapter.ClearBeforeFill = True
        '
        'FileCounterCTableAdapter
        '
        Me.FileCounterCTableAdapter.ClearBeforeFill = True
        '
        'FileCounterETableAdapter
        '
        Me.FileCounterETableAdapter.ClearBeforeFill = True
        '
        'ETableAdapter
        '
        Me.ETableAdapter.ClearBeforeFill = True
        '
        'ACountTableAdapter
        '
        Me.ACountTableAdapter.ClearBeforeFill = True
        '
        'BCountTableAdapter
        '
        Me.BCountTableAdapter.ClearBeforeFill = True
        '
        'CCountTableAdapter
        '
        Me.CCountTableAdapter.ClearBeforeFill = True
        '
        'ECountTableAdapter
        '
        Me.ECountTableAdapter.ClearBeforeFill = True
        '
        'ModeDropDown
        '
        Me.ModeDropDown.FormattingEnabled = True
        Me.ModeDropDown.Location = New System.Drawing.Point(14, 352)
        Me.ModeDropDown.Name = "ModeDropDown"
        Me.ModeDropDown.Size = New System.Drawing.Size(202, 28)
        Me.ModeDropDown.TabIndex = 0
        Me.ModeDropDown.Tag = "f"
        Me.ModeDropDown.Visible = False
        '
        'RateDropDown
        '
        Me.RateDropDown.FormattingEnabled = True
        Me.RateDropDown.Location = New System.Drawing.Point(14, 386)
        Me.RateDropDown.Name = "RateDropDown"
        Me.RateDropDown.Size = New System.Drawing.Size(202, 28)
        Me.RateDropDown.TabIndex = 1
        Me.RateDropDown.Tag = "f"
        Me.RateDropDown.Visible = False
        '
        'AnnounceTextBox
        '
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
        Me.ProgramsFileTextBox.Location = New System.Drawing.Point(14, 159)
        Me.ProgramsFileTextBox.Name = "ProgramsFileTextBox"
        Me.ProgramsFileTextBox.Size = New System.Drawing.Size(406, 26)
        Me.ProgramsFileTextBox.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 630)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(434, 630)
        Me.Name = "Form1"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.FileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Settings_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileCountDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoFarDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FolderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FolderDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HelpIcon, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DayWTimer As Timer
    Friend WithEvents NWTimer As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutTimer As Timer
    Friend WithEvents InTimer As Timer
    Friend WithEvents WTimer As Timer
    Friend WithEvents MediaTimer As Timer
    Friend WithEvents FileDataSet As FileDataSet
    Friend WithEvents FileBindingSource As BindingSource
    Friend WithEvents FileTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents FolderDataSet As FileDataSet
    Friend WithEvents FolderTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents FolderBindingSource As BindingSource
    Friend WithEvents FolderCounterTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents FileCounterATableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents WhereFolderTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents WhereFileTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents Settings_DataSet As FileDataSet
    Friend WithEvents Settings_TableAdapter As FileDataSetTableAdapters.SettingNTableAdapter
    Friend WithEvents FileCountDataSet As FileDataSet
    Friend WithEvents FileCountTableAdapter As FileDataSetTableAdapters.FileCountTableAdapter
    Friend WithEvents BDataSet As FileDataSet
    Friend WithEvents BTableAdapter As FileDataSetTableAdapters.SettingBTableAdapter
    Friend WithEvents BBindingSource As BindingSource
    Friend WithEvents CTableAdapter As FileDataSetTableAdapters.SettingCTableAdapter
    Friend WithEvents CDataSet As FileDataSet
    Friend WithEvents CBindingSource As BindingSource
    Friend WithEvents SoFarTableAdapter As FileDataSetTableAdapters.SoFarTableAdapter
    Friend WithEvents SoFarDataSet As FileDataSet
    Friend WithEvents FileCounterBTableAdapter As FileDataSetTableAdapters.SettingBTableAdapter
    Friend WithEvents FileCounterCTableAdapter As FileDataSetTableAdapters.SettingCTableAdapter
    Friend WithEvents FileCounterETableAdapter As FileDataSetTableAdapters.SettingETableAdapter
    Friend WithEvents ETableAdapter As FileDataSetTableAdapters.SettingETableAdapter
    Friend WithEvents EDataSet As FileDataSet
    Friend WithEvents EBindingSource As BindingSource
    Friend WithEvents ACountTableAdapter As FileDataSetTableAdapters.DialogTableAdapter
    Friend WithEvents BCountTableAdapter As FileDataSetTableAdapters.SettingBTableAdapter
    Friend WithEvents CCountTableAdapter As FileDataSetTableAdapters.SettingCTableAdapter
    Friend WithEvents ECountTableAdapter As FileDataSetTableAdapters.SettingETableAdapter
    Friend WithEvents ModeDropDown As ComboBox
    Friend WithEvents RateDropDown As ComboBox
    Friend WithEvents AnnounceTextBox As TextBox
    Friend WithEvents ToolStripMenuItem21 As ToolStripSeparator
    Friend WithEvents AllAppsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpIcon As PictureBox
    Friend WithEvents ProgramsFileTextBox As TextBox
End Class
