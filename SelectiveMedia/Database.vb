Imports iNovation.Code.Desktop
Imports iNovation.Code.General

Imports System.Collections.ObjectModel
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Module Database

#Region "References Variables"
#End Region

#Region "Connection Strings Variables"
    Public file_ As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\File.idfh"
    Public con_s As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & file_ & ";Persist Security Info=True;Jet OLEDB:Database Password=ccedeed3-867b"

#End Region

#Region "Media Variables"

	Dim mp4Files As ReadOnlyCollection(Of String)
	Dim mkvFiles As ReadOnlyCollection(Of String)
	Dim aviFiles As ReadOnlyCollection(Of String)
	Dim _3gpFiles As ReadOnlyCollection(Of String)
	Dim mpgFiles As ReadOnlyCollection(Of String)
	Dim mpegFiles As ReadOnlyCollection(Of String)
	Dim flvFiles As ReadOnlyCollection(Of String)
	Dim vobFiles As ReadOnlyCollection(Of String)
	Dim movFiles As ReadOnlyCollection(Of String)
	Dim amvFiles As ReadOnlyCollection(Of String)
	Dim wmvFiles As ReadOnlyCollection(Of String)
	Dim datFiles As ReadOnlyCollection(Of String)
	Dim _3gppFiles As ReadOnlyCollection(Of String)
	Dim m4vFiles As ReadOnlyCollection(Of String)
	Dim webmFiles As ReadOnlyCollection(Of String)
#End Region

#Region "Settings"

	Public Sub CommitSoFar(table_ As String, value_ As Integer)
		Dim f_query As String = ""
		Select Case table_.ToLower
			Case "a"
				f_query = "UPDATE [SoFar] SET A=@A WHERE (RecordSerial=1)"
			Case "f"
				f_query = "UPDATE [SoFar] SET F=@A WHERE (RecordSerial=1)"
			Case "c"
				f_query = "UPDATE [SoFar] SET C=@A WHERE (RecordSerial=1)"
			'			Case "wa"
			'				f_query = "UPDATE [SoFar] SET WA=@A WHERE (RecordSerial=1)"
			Case "wf"
				f_query = "UPDATE [SoFar] SET WF=@A WHERE (RecordSerial=1)"
		End Select

		Try
			Using f_conn As New OleDbConnection(con_s)
				Using f_comm As New OleDbCommand()
					With f_comm
						.Connection = f_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = f_query
						.Parameters.AddWithValue("@A", value_)
					End With
					Try
						f_conn.Open()
						f_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub

	Public Sub RecordFileCount(a_, b_, c_, e_)
		'if file_count before is different from now, re-initialize database

		Dim l1_ As ListBox = Form1.L1, l2_ As ListBox = Form1.L2, l3_ As ListBox = Form1.L3, l4_ As ListBox = Form1.L4, l5_ As ListBox = Form1.L5

		If l1_.Items.Count <> Val(a_) Then
			InitializeDatabase("A")
		End If

		If l2_.Items.Count <> Val(b_) Then
			InitializeDatabase("B")
		End If

		If l3_.Items.Count <> Val(c_) Then
			InitializeDatabase("C")
		End If

		'		If l4_.Items.Count <> Val(d_) Then
		'			InitializeDatabase("D")
		'		End If

		If l5_.Items.Count <> Val(e_) Then
			InitializeDatabase("E")
		End If

		'CHECK
		WriteFileCount("a", l1_.Items.Count)
		WriteFileCount("b", l2_.Items.Count)
		WriteFileCount("c", l3_.Items.Count)
		''			WriteFileCount("d", l4_.Items.Count)
		WriteFileCount("e", l5_.Items.Count)


	End Sub
	'CLEAR
	Public Sub SaveSetting_(setting_a As String, setting_f As String, setting_c As String, setting_wa As String, setting_wf As String)
		Try
			Dim f_query As String = "UPDATE [SettingN] SET A=@A, F=@F, C=@C, WA=@WA, WF=@WF WHERE (RecordSerial=1)"
			Using f_conn As New OleDbConnection(con_s)
				Using f_comm As New OleDbCommand()
					With f_comm
						.Connection = f_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = f_query
						.Parameters.AddWithValue("@A", setting_a)
						.Parameters.AddWithValue("@F", setting_f)
						.Parameters.AddWithValue("@C", setting_c)
						.Parameters.AddWithValue("@WA", setting_wa)
						.Parameters.AddWithValue("@WF", setting_wf)
					End With
					Try
						f_conn.Open()
						f_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try

	End Sub


#End Region

#Region "Main"

	Public Sub GetFiles_(adult_ As ListBox, adult_value As String, films_ As ListBox, films_value As String, cartoons_ As ListBox, cartoons_value As String, wallpaper_regular As ListBox, wallpaper_regular_value As String)
		GetFiles_V_(adult_, adult_value)
		GetFiles_V_(films_, films_value)
		GetFiles_V_(cartoons_, cartoons_value)
		'		GetFiles_I_(wallpaper_adult, wallpaper_adult_value)
		GetFiles_I_(wallpaper_regular, wallpaper_regular_value)
	End Sub
	Public Sub GetFiles_V_(l_ As ListBox, location_ As String)
		'CLEAR

		Dim directory_ As String = location_
		If My.Computer.FileSystem.DirectoryExists(directory_) = False Then Return

		l_.Items.Clear()

		aviFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.avi")
		If aviFiles.Count > 0 Then
			For i% = 0 To aviFiles.Count - 1
				l_.Items.Add(aviFiles.Item(i))
			Next
		End If

		mkvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mkv")
		If mkvFiles.Count > 0 Then
			For i% = 0 To mkvFiles.Count - 1
				l_.Items.Add(mkvFiles.Item(i))
			Next
		End If

		wmvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.wmv")
		If wmvFiles.Count > 0 Then
			For i% = 0 To wmvFiles.Count - 1
				l_.Items.Add(wmvFiles.Item(i))
			Next
		End If

		movFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mov")
		If movFiles.Count > 0 Then
			For i% = 0 To movFiles.Count - 1
				l_.Items.Add(movFiles.Item(i))
			Next
		End If

		mp4Files = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mp4")
		If mp4Files.Count > 0 Then
			For i% = 0 To mp4Files.Count - 1
				l_.Items.Add(mp4Files.Item(i))
			Next
		End If

		_3gpFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.3gp")
		If _3gpFiles.Count > 0 Then
			For i% = 0 To _3gpFiles.Count - 1
				l_.Items.Add(_3gpFiles.Item(i))
			Next
		End If

		_3gppFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.3gpp")
		If _3gppFiles.Count > 0 Then
			For i% = 0 To _3gppFiles.Count - 1
				l_.Items.Add(_3gppFiles.Item(i))
			Next
		End If

		flvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.flv")
		If flvFiles.Count > 0 Then
			For i% = 0 To flvFiles.Count - 1
				l_.Items.Add(flvFiles.Item(i))
			Next
		End If

		mpgFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mpg")
		If mpgFiles.Count > 0 Then
			For i% = 0 To mpgFiles.Count - 1
				l_.Items.Add(mpgFiles.Item(i))
			Next
		End If

		mpegFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.mpeg")
		If mpegFiles.Count > 0 Then
			For i% = 0 To mpegFiles.Count - 1
				l_.Items.Add(mpegFiles.Item(i))
			Next
		End If

		vobFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.vob")
		If vobFiles.Count > 0 Then
			For i% = 0 To vobFiles.Count - 1
				l_.Items.Add(vobFiles.Item(i))
			Next
		End If

		datFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.dat")
		If datFiles.Count > 0 Then
			For i% = 0 To datFiles.Count - 1
				l_.Items.Add(datFiles.Item(i))
			Next
		End If

		amvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.amv")
		If amvFiles.Count > 0 Then
			For i% = 0 To amvFiles.Count - 1
				l_.Items.Add(amvFiles.Item(i))
			Next
		End If

		m4vFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.m4v")
		If m4vFiles.Count > 0 Then
			For i% = 0 To m4vFiles.Count - 1
				l_.Items.Add(m4vFiles.Item(i))
			Next
		End If

		webmFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchAllSubDirectories, "*.webm")
		If webmFiles.Count > 0 Then
			For i% = 0 To webmFiles.Count - 1
				l_.Items.Add(webmFiles.Item(i))
			Next
		End If

	End Sub
	Public Sub GetFiles_I_(l_ As ListBox, location_ As String)
		'CLEAR
		Dim directory_ As String = location_
		If My.Computer.FileSystem.DirectoryExists(directory_) = False Then Exit Sub
		l_.Items.Clear()

		aviFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.jpg")
		If aviFiles.Count > 0 Then
			For i% = 0 To aviFiles.Count - 1
				l_.Items.Add(aviFiles.Item(i))
			Next
		End If

		mkvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.jpeg")
		If mkvFiles.Count > 0 Then
			For i% = 0 To mkvFiles.Count - 1
				l_.Items.Add(mkvFiles.Item(i))
			Next
		End If

		wmvFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
		If wmvFiles.Count > 0 Then
			For i% = 0 To wmvFiles.Count - 1
				l_.Items.Add(wmvFiles.Item(i))
			Next
		End If

		movFiles = My.Computer.FileSystem.GetFiles(directory_, FileIO.SearchOption.SearchTopLevelOnly, "*.bmp")
		If movFiles.Count > 0 Then
			For i% = 0 To movFiles.Count - 1
				l_.Items.Add(movFiles.Item(i))
			Next
		End If

	End Sub

#End Region

#Region "Update"

	Public Sub ConnectString()
		My.MySettings.Default("ConnectionString") = con_s
		SetPermissions()
		CopyFiles()

        Dim s_file As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\start.txt"
        If ReadText(s_file).Trim.Length < 1 Then WriteText(s_file, Now)


	End Sub
	Private Function GetDays()
        Dim s_file As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\start.txt"
        If ReadText(s_file).Trim.Length < 1 Then Return ""
		Dim d As Date = Date.Parse(ReadText(s_file))
		Dim d_ = DateDiff(DateInterval.Day, d, Now)
		Dim h_ = DateDiff(DateInterval.Hour, d, Now)
		Dim m_ = DateDiff(DateInterval.Minute, d, Now)

		If d_ < 1 Then
			If (h_ >= 1) Then
				Return ToPlural(h_, SingularWord.Hour) & vbCrLf & "(click for more information)"
			ElseIf (m_ >= 1) Then
				Return ToPlural(m_, SingularWord.Minute) & vbCrLf & "(click for more information)"
			ElseIf (m_ < 1) Then
				Return "less than 1 minute " & vbCrLf & "(click for more information)"
			End If
		ElseIf d_ >= 1 Then
			Return ToPlural(d_, SingularWord.Day) & vbCrLf & "(click for more information)"
		End If

	End Function

	Public Sub SetPermissions()

		PermitFolder(My.Application.Info.DirectoryPath)

		'
		'		Dim str_ As String = "icacls """ & file_ & """ /grant " & Environment.UserName & ":(F)"
		'		Try
		'			o.WriteText(My.Application.Info.DirectoryPath & "\FilePermissions.bat", str_)
		'			o.StartFile(My.Application.Info.DirectoryPath & "\FilePermissions.bat")
		'		Catch
		'		End Try


	End Sub

	Public Sub WriteFileCounter(table_ As String, value_ As Integer)
		Dim f_query As String = ""
		Select Case table_.ToLower
			Case "a"
				f_query = "INSERT INTO [Dialog] (FileCounterA) VALUES (@FileCounter)"
			Case "b"
				f_query = "INSERT INTO [SettingB] (FileCounterA) VALUES (@FileCounter)"
			Case "c"
				f_query = "INSERT INTO [SettingC] (FileCounterA) VALUES (@FileCounter)"
			'			Case "d"
			'				f_query = "INSERT INTO [SettingD] (FileCounterA) VALUES ('0')"
			Case "e"
				f_query = "INSERT INTO [SettingE] (FileCounterA) VALUES (@FileCounter)"
		End Select

		Try
			Using f_conn As New OleDbConnection(con_s)
				Using f_comm As New OleDbCommand()
					With f_comm
						.Connection = f_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = f_query
						.Parameters.AddWithValue("@FileCounter", value_)
					End With
					Try
						f_conn.Open()
						f_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub


	Public Sub InitializeDatabase(table_ As String)
		Dim i_query As String = ""
		'		Dim f_query As String = ""
		Select Case table_.ToLower
			Case "a"
				i_query = "DELETE FROM [Dialog]"
			'				f_query = "INSERT INTO [Dialog] (FileCounterA) VALUES ('0')"
			Case "b"
				i_query = "DELETE FROM [SettingB]"
			'				f_query = "INSERT INTO [SettingB] (FileCounterA) VALUES ('0')"
			Case "c"
				i_query = "DELETE FROM [SettingC]"
			'				f_query = "INSERT INTO [SettingC] (FileCounterA) VALUES ('0')"
			'			Case "d"
			'				i_query = "DELETE FROM [SettingD]"
			''				f_query = "INSERT INTO [SettingD] (FileCounterA) VALUES ('0')"
			Case "e"
				i_query = "DELETE FROM [SettingE]"
				'				f_query = "INSERT INTO [SettingE] (FileCounterA) VALUES ('0')"
		End Select

		Try
			Using f_conn As New OleDbConnection(con_s)
				Using f_comm As New OleDbCommand()
					With f_comm
						.Connection = f_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = i_query
						'						.Parameters.AddWithValue("@FileCounter", file_counter__value)
					End With
					Try
						f_conn.Open()
						f_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub

	Public Sub WriteFileCount(table_ As String, value_ As String)
		Dim f_query As String = ""
		Select Case table_.ToLower
			Case "a"
				f_query = "UPDATE [FileCount] SET FileCountA=@A WHERE (RecordSerial=1)"
			Case "b"
				f_query = "UPDATE [FileCount] SET FileCountB=@A WHERE (RecordSerial=1)"
			Case "c"
				f_query = "UPDATE [FileCount] SET FileCountC=@A WHERE (RecordSerial=1)"
			Case "d"
				f_query = "UPDATE [FileCount] SET FileCountD=@A WHERE (RecordSerial=1)"
			Case "e"
				f_query = "UPDATE [FileCount] SET FileCountE=@A WHERE (RecordSerial=1)"
		End Select

		Try
			Using f_conn As New OleDbConnection(con_s)
				Using f_comm As New OleDbCommand()
					With f_comm
						.Connection = f_conn
						.CommandTimeout = 0
						.CommandType = CommandType.Text
						.CommandText = f_query
						.Parameters.AddWithValue("@A", value_)
					End With
					Try
						f_conn.Open()
						f_comm.ExecuteNonQuery()
					Catch ex As Exception
					End Try
				End Using
			End Using
		Catch
		End Try
	End Sub


#End Region

#Region "Other Functions"
	Public Function GetFolder(control_ As Control, Optional description_ As String = "Select Folder", Optional ShowNewFolderButton_ As Boolean = True) As String

		Dim t
		If TypeOf control_ Is TextBox Then t = control_
		If TypeOf control_ Is ComboBox Then t = control_
		If TypeOf control_ IsNot TextBox And TypeOf control_ IsNot ComboBox Then Exit Function

		Dim f_ As New FolderBrowserDialog

		With f_
			.Description = description_
			.ShowNewFolderButton = ShowNewFolderButton_
			.ShowDialog()

			If .SelectedPath.Length > 0 Then
				Return .SelectedPath
			ElseIf .SelectedPath.Length < 1 Then
				Return t.text
			End If

		End With
	End Function

#End Region
End Module
