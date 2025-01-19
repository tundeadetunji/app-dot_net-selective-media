﻿Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports System.IO
Imports System.Collections.ObjectModel
Imports SelectiveMedia.Constants
Public Class Form1 : Implements IDialogResource

#Region "Overrides"
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

#End Region

#Region "Properties"
	Private ReadOnly Property ui As UiService = New UiService
	Private ReadOnly Property program As AppService = New AppService
	Private ReadOnly Property disk As DiskService = New DiskService
	Private ReadOnly Property desktop As DesktopService = New DesktopService
	Private ReadOnly Property settings As SettingsService = New SettingsService
	Private ReadOnly Property playback As MediaService = New MediaService
	Private ReadOnly Property state As StateService = StateService.Instance(False, MediaSection.Regular)
	Private ReadOnly Property history As HistoryService = HistoryService.Instance

#End Region

#Region "Notify Icon Related"
	Private Sub AllAppsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllAppsToolStripMenuItem.Click
		TaskManager()
	End Sub

	Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click

		With Me
			'			.Visible = True
			.Opacity = 0
			.FadeInTimer.Enabled = True
			'			.Show()
		End With
	End Sub


#End Region

#Region "Control Box Related"
	Private Sub CloseDialogButton_Click(sender As Object, e As EventArgs) Handles CloseDialogButton.Click
		If settings.SettingsValidated Then
			settings.SaveSettings(Me, disk, history, state)
			ui.ShowOrHideInitiallyHiddenControls(Me, False)
			FadeOutTimer.Enabled = True
			program.Start(Me, disk, settings)
		End If
	End Sub
	Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs) Handles FadeInTimer.Tick
		Me.Visible = True
		If Me.Opacity >= 1 Then
			FadeInTimer.Enabled = False
			Exit Sub
		End If
		Me.Opacity += 0.2
	End Sub
	Private Sub FadeOutTimer_Tick(sender As Object, e As EventArgs) Handles FadeOutTimer.Tick
		If Me.Opacity <= 0 Then
			FadeOutTimer.Enabled = False
			Me.Visible = False
			Return
		End If
		Me.Opacity -= 0.2
	End Sub

#End Region

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		FadeInTimer.Enabled = False

		ui.HideDialog(Me)

		ui.InitializeDialog(Me)

		If Not program.CanStart(Me) Then
			FadeInTimer.Enabled = True
		Else
			FadeInTimer.Enabled = False
			program.Start(Me, disk, settings)
		End If

	End Sub
	Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
		ui.ShowOrHideInitiallyHiddenControls(Me, Not BeginTime.Visible) 'just picked BeginTime at random, could have been any one of them
	End Sub

	Private Sub NightMediaLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles NightMediaLocationTextBox.DoubleClick, RegularMediaLocationTextBox.DoubleClick, AlternateMediaLocationTextBox.DoubleClick, WallpaperLocationTextBox.DoubleClick
		CType(sender, TextBox).Text = disk.GetFolder(sender)
	End Sub

	Private Sub MediaTimer_Tick(sender As Object, e As EventArgs) Handles MediaTimer.Tick

		If desktop.PlayerIsOn(disk) Then
			If settings.GetMode(disk) = Random Then
				MediaTimer.Interval = TwoMinutes
			End If
			Exit Sub
		End If

		playback.StartMedia(Me, program, disk, history, settings, state)

	End Sub


	Private Sub DayTimer_Tick(sender As Object, e As EventArgs) Handles DayTimer.Tick
		If program.GetPeriod(Me, disk, settings) = Period.Day Then
			DayTimer.Enabled = False
			program.PrepNight()
			NightTimer.Enabled = True
		End If
	End Sub

	Private Sub NightTimer_Tick(sender As Object, e As EventArgs) Handles NightTimer.Tick
		If program.GetPeriod(Me, disk, settings) = Period.Night Then
			NightTimer.Enabled = False
			program.PrepDay()
			DayTimer.Enabled = True
		End If

	End Sub

	Private Sub DropDown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ModeDropDown.KeyPress, RateDropDown.KeyPress
		AllowNothing(e)
	End Sub

	Private Sub HelpIcon_Click(sender As Object, e As EventArgs) Handles HelpIcon.Click
		StartFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\help.txt")
	End Sub

End Class
