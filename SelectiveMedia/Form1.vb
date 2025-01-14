Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Imports System.IO
Imports System.Collections.ObjectModel
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


#End Region

#Region "Properties"
	Private ReadOnly Property services As ServiceFactory = ServiceFactory.Instance
	Private ReadOnly Property repository As RepositoryFactory = RepositoryFactory.Instance
#End Region

#Region "Other Functions"
	'CLEAR
	Public Sub GetSettings_()
		Try
			Me.Settings_TableAdapter.GetSetting_(Me.Settings_DataSet.SettingN)
		Catch
		End Try
	End Sub
	'CLEAR
	Public Sub GetFileCount()
		Try
			Me.FileCountTableAdapter.FileCount(Me.FileCountDataSet.FileCount)
		Catch ex As Exception
		End Try
	End Sub

	Public Function FileCounter() As Integer
		Try
			'			Me.FileTableAdapter.FileCounter(Me.FileDataSet.Dialog, Me.WhereFileTableAdapter.Where_FileCounter())
			Me.FileTableAdapter.FileCounter(Me.FileDataSet.Dialog)
			Me.FileBindingSource.MoveLast()
			Return Val(FileCounterAValue.Text)
		Catch ex As Exception
		End Try
	End Function
	Public Function FileCounterB() As Integer
		Try
			'			Me.FileTableAdapter.FileCounter(Me.FileDataSet.Dialog, Me.WhereFileTableAdapter.Where_FileCounter())
			Me.BTableAdapter.FileCounter(Me.BDataSet.SettingB)
			Me.BBindingSource.MoveLast()
			Return Val(FileCounterBValue.Text)
		Catch ex As Exception
		End Try
	End Function
	Public Function FileCounterC() As Integer
		Try
			'			Me.FileTableAdapter.FileCounter(Me.FileDataSet.Dialog, Me.WhereFileTableAdapter.Where_FileCounter())
			Me.CTableAdapter.FileCounter(Me.CDataSet.SettingC)
			Me.CBindingSource.MoveLast()
			Return Val(FileCounterCValue.Text)
		Catch ex As Exception
		End Try
	End Function
	Public Function FileCounterE() As Integer
		Try
			'			Me.FileTableAdapter.FileCounter(Me.FileDataSet.Dialog, Me.WhereFileTableAdapter.Where_FileCounter())
			Me.ETableAdapter.FileCounter(Me.EDataSet.SettingE)
			Me.EBindingSource.MoveLast()
			Return Val(FileCounterEValue.Text)
		Catch ex As Exception
		End Try
	End Function
#End Region

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		services.ui.HideDialog(Me)

		InTimer.Enabled = False
		ConnectString()
		'
		'		Dim x_ As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\Windows\Start Menu\Programs\Startup\Yahoo! Widget Engine.lnk"

		GetSettings_()
		GetOtherSettings()

		'dialog
		services.ui.OnStartup(Me)

		'begin

		If NightMediaLocationTextBox.Text = "" Or My.Computer.FileSystem.DirectoryExists(NightMediaLocationTextBox.Text) = False Or RegularMediaLocationTextBox.Text = "" Or My.Computer.FileSystem.DirectoryExists(RegularMediaLocationTextBox.Text) = False Or AlternateMediaLocationTextBox.Text = "" Or My.Computer.FileSystem.DirectoryExists(AlternateMediaLocationTextBox.Text) = False Or WallpaperLocationTextBox.Text = "" Or My.Computer.FileSystem.DirectoryExists(WallpaperLocationTextBox.Text) = False Then
			InTimer.Enabled = True
		ElseIf NightMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(NightMediaLocationTextBox.Text) = True And RegularMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(RegularMediaLocationTextBox.Text) = True And AlternateMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(AlternateMediaLocationTextBox.Text) = True And WallpaperLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(WallpaperLocationTextBox.Text) = True Then
			InTimer.Enabled = False
			GetFiles_(L1, SettingA.Text, L2, SettingB.Text, L3, SettingC.Text, L5, SettingE.Text)
			GetFileCount()
			RecordFileCount(FileCountA.Text, FileCountB.Text, FileCountC.Text, FileCountE.Text)

			If Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString) And Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString) Then
				DayWTimer.Enabled = True
			Else
				NWTimer.Enabled = True
			End If

			MediaTimer.Enabled = True
		End If

	End Sub

	'CLEAR
	Private Sub NightMediaLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles NightMediaLocationTextBox.DoubleClick
		NightMediaLocationTextBox.Text = GetFolder(sender)
	End Sub

	'CLEAR
	Private Sub RegularMediaLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles RegularMediaLocationTextBox.DoubleClick
		RegularMediaLocationTextBox.Text = GetFolder(sender)
	End Sub

	'CLEAR
	Private Sub AlternateMediaLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles AlternateMediaLocationTextBox.DoubleClick
		AlternateMediaLocationTextBox.Text = GetFolder(sender)
	End Sub
	Private Sub MediaTimer_Tick(sender As Object, e As EventArgs) Handles MediaTimer.Tick
		'		If L1.Items.Count = 0 Or L2.Items.Count = 0 Or L3.Items.Count = 0 Or l4.Items.Count = 0 Then
		'			Timer1.Interval = 1000
		'			Exit Sub
		'		End If
		If PlayerIsOn() Then
			If GetSelect() = Mode.Sequential.ToString Then
			ElseIf GetSelect() = Mode.Random.ToString Then
				MediaTimer.Interval = 120000
			End If
			Exit Sub
		End If
		'Button1_Click(sender, e)
		StartMedia()

	End Sub
	Private hasStarted As Boolean = False
	Private Sub StartMedia() '(sender As Object, e As EventArgs) Handles Button1.Click
		If GetSelect() = Mode.Random.ToString Then
			StartMediaRandom()
		ElseIf GetSelect() = Mode.Sequential.ToString Then
			StartMediaSequential()
		End If

	End Sub
	Private Sub StartMediaSequential() '(sender As Object, e As EventArgs) Handles Button1.Click

		With listSelect
			If .Items.Count > 0 Then
				If .Items.Count < 1 Then
					.SelectedIndex = 0
				Else
					.SelectedIndex += 1
				End If
			End If

			If hasStarted = False Then
				hasStarted = True
				Try
					listSelect.Items.Clear()

					If (Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString)) And (Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString)) Then
						GetFiles_V_(listSelect, Content(SettingA))
					Else
						GetFiles_V_(listSelect, Content(SettingB))
					End If

					listSelect.SelectedIndex = 0
				Catch ex As Exception

				End Try

				If AnnounceTextBox.Text.Trim.Length > 0 And GetSelect() = Mode.Sequential.ToString Then
					f.say(AnnounceTextBox.Text.Trim)
				End If
			End If

			StartFile(.SelectedItem)
		End With

		SetTime()
	End Sub

	Private Sub StartMediaRandom() '(sender As Object, e As EventArgs) Handles Button1.Click

		'		RecordFileCount()

		'which folder
		'if hour is between 0 and 6:30 then pick from a
		'if hour is between 6:31 and 11.59 then pick from b and c
		'pick file

		If (Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString)) And (Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString)) Then
			WriteFileCounter("a", WhichFileA(L1))
			Try
				Process.Start(L1.Items.Item(FileCounter()))
			Catch ex As Exception
			End Try
		Else
			folder_counter_.Text = WhichFolder()
			Select Case Integer.Parse(folder_counter_.Text)
				Case 1
					WriteFileCounter("b", WhichFileB(L2))
					Try
						Process.Start(L2.Items.Item(FileCounterB()))
					Catch ex As Exception
					End Try
				Case 2
					'					file_counter_.Text = WhichFile(file_counter_, L3).ToString
					WriteFileCounter("c", WhichFileC(L3))
					Try
						Process.Start(L3.Items.Item(FileCounterC()))
					Catch ex As Exception
					End Try
			End Select
		End If
		SetTime()

	End Sub

	Private Sub SetTime()
		'pick time
		time_counter_.Text = WhichTime(time_counter_)
		If GetSelect() = Mode.Sequential.ToString Then
			MediaTimer.Interval = 2000
		ElseIf GetSelect() = Mode.Random.ToString Then
			With MediaTimer
				If mode_.ToLower = "relaxed" Then
					Select Case time_counter_.Text
						Case 1
							.Interval = 1000 * 20 * 60
						Case 2
							.Interval = 1000 * 10 * 60
						Case 3
							.Interval = 1000 * 5 * 60
					End Select
				Else
					Select Case time_counter_.Text
						Case 1
							.Interval = 1000 * 2 * 60
						Case 2
							.Interval = 1000 * 3 * 60
						Case 3
							.Interval = 1000 * 5 * 60
					End Select
				End If
			End With
		End If


	End Sub

#Region "Main"

	Private Sub PrepDay()
		'films, theme
		'close my widgets and vg
		WTimer.Enabled = True

		'		Try
		'			Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\Windows\Themes\theme.theme")
		'		Catch ex As Exception
		'		End Try
		Try
			PickWallpaper("d")
		Catch ex As Exception
		End Try
		'open other programs
		StartApps(ReadText(programs_))
	End Sub

	Private Sub PrepNight()
		'adult films, theme
		'my widgets, vg
		WTimer.Enabled = False
		''Try
		''	Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\My Widgets\Picture Frame.widget")
		''Catch ex As Exception
		''End Try
		Try
			PickWallpaper("n")
		Catch ex As Exception
		End Try
		'open other programs
		StartApps(ReadText(programs_alternate))
	End Sub

	Private Sub PickWallpaper(t_ As String)
		'		Try
		Select Case t_.ToLower
			Case "d"
				'If Random_(1, 11) < 5 Then
				WriteFileCounter("e", WhichFileE(L5))
				SetWallpaper(L5.Items.Item(FileCounterE()))
			'Else
			'Try
			'Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\Windows\Themes\dtheme.theme")
			'Catch ex As Exception
			'WriteFileCounter("e", WhichFileE(L5))
			'SetWallpaper(L5.Items.Item(FileCounterE()))
			'End Try
			'End If
			Case "n"
		End Select
		'		Catch
		'		End Try
		'		Dim r_val_ As Integer = Random_(0, L4.Items.Count - 1)
		'		SetWallpaper(L4.Items.Item(r_val_))
	End Sub
	'CLEAR
	Public Function WhichFolder() As Integer
		Dim which_folder
2:
		which_folder = Random_(1, 3)
		If which_folder <> folder_counter_.Text Then
			Return which_folder
			'			Exit Function
		Else
			GoTo 2
		End If

	End Function
	'CHECK  
	Private Function FileAlreadyA(file_counter__ As Integer, l As ListBox) As Boolean
		'if count of items in table = count of items in l, then initialize table (have recorded every index)
		If Me.ACountTableAdapter.Count_() = l.Items.Count Then InitializeDatabase("a")
		'
		FileAlreadyA = Me.FileCounterATableAdapter.Count_FileCounter(file_counter__) < 1
	End Function
	'CLEAR
	'CHECK Exit Function
	Public Function WhichFileA(l As ListBox) As Integer
		Dim which_file
2:
		which_file = Random_(0, l.Items.Count)
		If FileAlreadyA(which_file, l) Then
			Return which_file
			'			Exit Function
		Else
			GoTo 2
		End If

	End Function

	'CHECK
	Private Function FileAlreadyB(file_counter__ As Integer, l As ListBox) As Boolean
		'if count of items in table = count of items in l, then initialize table (have recorded every index)
		If Me.BCountTableAdapter.Count_() = l.Items.Count Then InitializeDatabase("b")
		'
		FileAlreadyB = Me.FileCounterBTableAdapter.Count_FileCounter(file_counter__) < 1
	End Function

	'CLEAR
	'CHECK Exit Function
	Public Function WhichFileB(l As ListBox) As Integer
		Dim which_file
2:
		which_file = Random_(0, l.Items.Count)
		If FileAlreadyB(which_file, l) Then
			Return which_file
			'			Exit Function
		Else
			GoTo 2
		End If

	End Function


	Private Function FileAlreadyC(file_counter__ As Integer, l As ListBox) As Boolean
		'if count of items in table = count of items in l, then initialize table (have recorded every index)
		If Me.CCountTableAdapter.Count_() = l.Items.Count Then InitializeDatabase("c")
		'
		FileAlreadyC = Me.FileCounterCTableAdapter.Count_FileCounter(file_counter__) < 1
	End Function

	'CLEAR
	'CHECK Exit Function
	Public Function WhichFileC(l As ListBox) As Integer
		Dim which_file
2:
		which_file = Random_(0, l.Items.Count)
		If FileAlreadyC(which_file, l) Then
			Return which_file
			'			Exit Function
		Else
			GoTo 2
		End If

	End Function

	'CHECK  IF ERROR OCCUR, SKIP SoFar
	Private Function FileAlreadyE(file_counter__ As Integer, l As ListBox) As Boolean
		'if count of items in table = count of items in l, then initialize table (have recorded every index)
		If Me.ECountTableAdapter.Count_() = l.Items.Count Then InitializeDatabase("e")
		'
		FileAlreadyE = Me.FileCounterETableAdapter.Count_FileCounter(file_counter__) < 1
	End Function
	'CLEAR
	'CHECK Exit Function
	Public Function WhichFileE(l As ListBox) As Integer
		Dim which_file
2:
		which_file = Random_(0, l.Items.Count)
		If FileAlreadyE(which_file, l) Then
			Return which_file
			'			Exit Function
		Else
			GoTo 2
		End If

	End Function

	'CLEAR
	'CHECK Exit Function
	Public Function WhichTime(time_counter As TextBox) As Integer
		Dim wf
2:
		wf = Random_(1, 4)
		If wf <> time_counter.Text Then
			Return wf
			'			Exit Function
		ElseIf wf = time_counter.Text Then
			GoTo 2
		End If

	End Function

	'CLEAR
	Public Function PlayerIsOn() As Boolean
		'		Dim p() As Process = Process.GetProcessesByName(WhichPlayer)
		'		PlayerIsOn = p.Count > 0
		Return AppIsOn(cPlayer.Text)

	End Function


	'CLEAR
	Private Sub TextBox4_DoubleClick(sender As Object, e As EventArgs)
		tWallpaperAdult.Text = GetFolder(sender)
	End Sub

	'CLEAR
	Private Sub WTimer_Tick(sender As Object, e As EventArgs) Handles DayWTimer.Tick
		If Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString) And Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString) Then
			DayWTimer.Enabled = False
			PrepNight() 'do stuff to happen during interval
			NWTimer.Enabled = True 'listen for end of interval; at that point, timer takes over
		Else
		End If

	End Sub

	'CLEAR
	Private Sub NWTimer_Tick(sender As Object, e As EventArgs) Handles NWTimer.Tick
		If Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString) And Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString) Then
		Else
			NWTimer.Enabled = False
			PrepDay() 'do stuff to happen outside interval
			DayWTimer.Enabled = True 'listen for begining of interval; at that point, timer takes over
		End If

	End Sub

	'CLEAR
	Private Sub WallpaperLocationTextBox_DoubleClick(sender As Object, e As EventArgs) Handles WallpaperLocationTextBox.DoubleClick
		WallpaperLocationTextBox.Text = GetFolder(sender)
	End Sub

	Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click

		With Me
			'			.Visible = True
			.Opacity = 0
			.InTimer.Enabled = True
			'			.Show()
		End With
	End Sub

	'CLEAR
	Private Sub CloseButton_Click(sender As Object, e As EventArgs)
		OutTimer.Enabled = True
	End Sub

	Private Sub InTimer_Tick(sender As Object, e As EventArgs) Handles InTimer.Tick
		Me.Visible = True
		If Me.Opacity >= 1 Then
			InTimer.Enabled = False
			Exit Sub
		End If
		Me.Opacity += 0.2
	End Sub

	Private Sub WTimer_Tick_1(sender As Object, e As EventArgs) Handles WTimer.Tick
		WTimer.Enabled = False
		'		KillProcess("YahooWidgetEngine")
	End Sub

	'CLEAR

	'CLEAR
	Private Sub SettingA_TextChanged(sender As Object, e As EventArgs)
		NightMediaLocationTextBox.Text = SettingA.Text
	End Sub

	'CLEAR
	Private Sub SettingB_TextChanged(sender As Object, e As EventArgs)
		RegularMediaLocationTextBox.Text = SettingB.Text
	End Sub

	'CLEAR
	Private Sub SettingC_TextChanged(sender As Object, e As EventArgs)
		AlternateMediaLocationTextBox.Text = SettingC.Text
	End Sub

	'CLEAR
	Private Sub SettingD_TextChanged(sender As Object, e As EventArgs)
		tWallpaperAdult.Text = SettingD.Text
	End Sub

	Private Sub OutTimer_Tick(sender As Object, e As EventArgs) Handles OutTimer.Tick
		If Me.Opacity <= 0 Then
			Me.Visible = False
			OutTimer.Enabled = False

			BeginTime.Visible = False
			EndTime.Visible = False
			cPlayer.Visible = False
			ModeDropDown.Visible = False
			RateDropDown.Visible = False

			If IsEmpty(ModeDropDown) = False Then
				mode_ = Content(ModeDropDown)
			Else
				mode_ = rates(0)
			End If
			SaveDateValues(BeginTime.Value.ToShortTimeString, EndTime.Value.ToShortTimeString)
			SaveOtherSettings()
			ThisPlayer(set_player_.Text)
			If NightMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(NightMediaLocationTextBox.Text) And RegularMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(RegularMediaLocationTextBox.Text) And AlternateMediaLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(AlternateMediaLocationTextBox.Text) And WallpaperLocationTextBox.Text <> "" And My.Computer.FileSystem.DirectoryExists(WallpaperLocationTextBox.Text) = True Then
				Try
					SaveSetting_(NightMediaLocationTextBox.Text.Trim, RegularMediaLocationTextBox.Text.Trim, AlternateMediaLocationTextBox.Text.Trim, tWallpaperAdult.Text.Trim, WallpaperLocationTextBox.Text.Trim)
				Catch x As Exception
				End Try
				GetSettings_()
				GetFiles_(L1, SettingA.Text, L2, SettingB.Text, L3, SettingC.Text, L5, SettingE.Text)
				GetFileCount()
				RecordFileCount(FileCountA.Text, FileCountB.Text, FileCountC.Text, FileCountE.Text)

				If Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString) And Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString) Then
					DayWTimer.Enabled = True
				Else
					NWTimer.Enabled = True
				End If
				MediaTimer.Enabled = True
			End If
		End If
		Me.Opacity -= 0.2
	End Sub

	'CLEAR
	Private Sub SettingE_TextChanged(sender As Object, e As EventArgs)
		tWallpaperAdult.Text = SettingE.Text
	End Sub

	'CLEAR
	Private Sub SettingF_TextChanged(sender As Object, e As EventArgs)
		WallpaperLocationTextBox.Text = SettingF.Text

	End Sub

	'CLEAR
	Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
		If EndTime.Visible = True Then
			BeginTime.Visible = False
			EndTime.Visible = False
			cPlayer.Visible = False
			ModeDropDown.Visible = False
			RateDropDown.Visible = False
			Exit Sub
		End If

		BeginTime.Visible = True
		EndTime.Visible = True
		cPlayer.Visible = True
		ModeDropDown.Visible = True
		RateDropDown.Visible = True
	End Sub

	Private Sub DropDown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ModeDropDown.KeyPress, RateDropDown.KeyPress
		AllowNothing(e)
	End Sub

	Private Sub AllAppsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllAppsToolStripMenuItem.Click
		TaskManager()
	End Sub

	Private Sub HelpIcon_Click(sender As Object, e As EventArgs) Handles HelpIcon.Click
		StartFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\help.txt")
	End Sub

#End Region

End Class
