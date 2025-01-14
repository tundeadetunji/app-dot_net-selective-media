Imports General_Module.FormatWindow
Module LanguageC
	Private g As New General_Module.FormatWindow()
	Public f As New Feedback.Feedback
	Public l As New Language.Language

	Public Sub InitialMarkVoiceFeedback(UsePromptMenuItem As ToolStripMenuItem, AccompanyPromptWithVoiceFeedbackMenuItem As ToolStripMenuItem, UseVoiceFeedbackMenuItem As ToolStripMenuItem)
		'AccompanyPromptWithVoiceFeedbackMenuItem.Checked = False
		'UseVoiceFeedbackMenuItem.Checked = False
		'UsePromptMenuItem.Checked = False

		AccompanyPromptWithVoiceFeedbackMenuItem.Checked = My.Settings.accompany_prompt_with_voice_feedback
		UseVoiceFeedbackMenuItem.Checked = My.Settings.use_voice_feedback
		UsePromptMenuItem.Checked = My.Settings.use_prompt

		f.setting_accompany_prompt_with_voice_feedback = My.Settings.accompany_prompt_with_voice_feedback
		f.setting_use_voice_feedback = My.Settings.use_voice_feedback
		f.setting_use_prompt = My.Settings.use_prompt

	End Sub
	Public Sub MarkAccompanyPromptWithVoiceFeedback(mark As Boolean, AccompanyPromptWithVoiceFeedbackMenuItem As ToolStripMenuItem, UseVoiceFeedbackMenuItem As ToolStripMenuItem, UsePromptMenuItem As ToolStripMenuItem)
		My.Settings.accompany_prompt_with_voice_feedback = mark
		AccompanyPromptWithVoiceFeedbackMenuItem.Checked = mark

		Dim bo As Boolean = BooleanOpposite(mark)
		UseVoiceFeedbackMenuItem.Checked = bo
		UsePromptMenuItem.Checked = bo

		My.Settings.use_voice_feedback = bo
		My.Settings.use_prompt = bo

		f.setting_accompany_prompt_with_voice_feedback = mark

		''		f.setting_use_prompt = bo
		''		f.setting_use_voice_feedback = bo

	End Sub
	Public Sub MarkUseVoiceFeedback(mark As Boolean, UseVoiceFeedbackMenuItem As ToolStripMenuItem, AccompanyPromptWithVoiceFeedbackMenuItem As ToolStripMenuItem, UsePromptMenuItem As ToolStripMenuItem)
		My.Settings.use_voice_feedback = mark
		UseVoiceFeedbackMenuItem.Checked = mark

		Dim bo As Boolean = BooleanOpposite(mark)
		AccompanyPromptWithVoiceFeedbackMenuItem.Checked = bo
		UsePromptMenuItem.Checked = bo

		My.Settings.accompany_prompt_with_voice_feedback = bo
		My.Settings.use_prompt = bo

		f.setting_use_voice_feedback = mark

		''		f.setting_accompany_prompt_with_voice_feedback = bo
		''		f.setting_use_prompt = bo

	End Sub
	Public Sub MarkUsePrompt(mark As Boolean, UsePromptMenuItem As ToolStripMenuItem, AccompanyPromptWithVoiceFeedbackMenuItem As ToolStripMenuItem, UseVoiceFeedbackMenuItem As ToolStripMenuItem)
		My.Settings.use_prompt = mark
		UsePromptMenuItem.Checked = mark

		Dim bo As Boolean = BooleanOpposite(mark)
		AccompanyPromptWithVoiceFeedbackMenuItem.Checked = bo
		UseVoiceFeedbackMenuItem.Checked = bo

		My.Settings.accompany_prompt_with_voice_feedback = bo
		My.Settings.use_voice_feedback = bo

		f.setting_use_prompt = mark

		''		f.setting_accompany_prompt_with_voice_feedback = bo
		''		f.setting_use_voice_feedback = bo
	End Sub


#Region ""
	Public Function LanguageSelected(selected_language As String) As String
		Select Case selected_language
			Case "English"
				Return "English"
			Case "français"
				Return "French"
			Case "ไทย"
				Return "Thai"
			Case "Yorùbá"
				Return "Yoruba"
			Case "Hausa"
				Return "Hausa"
			Case "Igbo"
				Return "Igbo"
			Case "中文"
				Return "Chinese"
		End Select

	End Function

	Public ReadOnly Property selected_language As String
		Get
			Dim selected_language_ As String = My.Settings.selected_language
			'			If selected_language_.Length < 1 Then selected_language_ = "English"
			Return selected_language_
		End Get
	End Property

	Public Function saveSelected_Language(selected_language As String)
		My.Settings.selected_language = LanguageSelected(selected_language)
	End Function

#End Region

#Region "Format"
	Public Sub MarkTheme(s_theme As String, green_ As ToolStripMenuItem, turqoise_ As ToolStripMenuItem, velvet_ As ToolStripMenuItem, purple_ As ToolStripMenuItem, white_ As ToolStripMenuItem, brown_ As ToolStripMenuItem, yellow_ As ToolStripMenuItem, d_ As Form)
		saveTheme(s_theme)

		green_.Checked = False : turqoise_.Checked = False : velvet_.Checked = False : purple_.Checked = False : white_.Checked = False : brown_.Checked = False : yellow_.Checked = False

		Select Case s_theme.ToLower
			Case "green"
				green_.Checked = True
			Case "turqoise"
				turqoise_.Checked = True
			Case "velvet"
				velvet_.Checked = True
			Case "purple"
				purple_.Checked = True
			Case "white"
				white_.Checked = True
			Case "brown"
				brown_.Checked = True
			Case "yellow"
				yellow_.Checked = True
		End Select

		SetDialogBackground(d_, themeBackgroundFile)
	End Sub
	Public Sub saveTheme(s_theme As String)
		My.Settings.selected_theme = s_theme
	End Sub

	Public ReadOnly Property selected_theme() As String
		Get
			Dim selected_theme_ As String = My.Settings.selected_theme
			If selected_theme_.Length < 1 Then selected_theme_ = "Yellow"
			Return selected_theme_
		End Get
	End Property

	Public Function themeBackgroundFile() As String
		'		Dim s_theme As String = My.Computer.FileSystem.ReadAllText(theme_file).Trim

		'Dim theme_background_file_ As String = ReadText(theme_background_file)
		'If theme_background_file_.Length < 1 Or theme_background_file_ Is Nothing Or My.Computer.FileSystem.FileExists(theme_background_file_) = False Then theme_background_file_ = ""
		Return My.Settings.selected_theme_background
	End Function
	Public Sub SaveThemeBackground(background_file As String)
		'		If background_file.Length > 0 Then
		My.Settings.selected_theme_background = background_file
		'		End If
	End Sub
	Public Sub DialogBackground(d_ As Form, Optional AppType As String = "")
		On Error Resume Next
		'		Dim f As New Feedback.Feedback(app_)
		Select Case AppType.ToLower
			Case "net"
				Dim value_ As Array = GetFileAndExtension("picture")
				If value_(0) = True And value_(1).ToString.Length > 0 Then
					SaveThemeBackground(value_(1).ToString)
					SetDialogBackground(d_, value_(1).ToString)
					'				Else
					'					SetDialogBackground(d_, themeBackgroundFile)
				End If
			Case ""
				Dim background_file = GetFile("picture")
				If background_file.Length > 0 Then
					SaveThemeBackground(background_file)
					SetDialogBackground(d_, background_file)
					'				Else
					'					SetDialogBackground(d_, themeBackgroundFile)
				End If
		End Select

	End Sub
	Public Sub ClearDialogBackground(d_ As Form)
		d_.BackgroundImage = Nothing
		SaveThemeBackground("")
	End Sub

#End Region

#Region "File Paths Variables"

	'Public ReadOnly Property notification_file As String
	'	Get
	'		Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & app & "\Settings_Notification.txt"
	'	End Get
	'End Property

	'Public Shared ReadOnly Property logo As String
	'	Get
	'		Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & app & "\logo.jpg"
	'	End Get
	'End Property


	'Public Shared ReadOnly Property starter__ As String
	'	Get
	'		Return My.Application.Info.DirectoryPath & "\My Admin Starter.exe"
	'	End Get
	'End Property

	Public ReadOnly Property printer_ As String
		Get
			Return My.Settings.printer_ ' Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & app & "\Setting_Printer.txt"
		End Get
	End Property

#End Region

End Module
