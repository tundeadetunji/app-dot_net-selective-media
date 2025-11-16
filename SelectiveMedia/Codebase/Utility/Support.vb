Imports System.IO
Imports System.Linq
Imports System.Text
Imports iNovation.Code.Desktop
Imports iNovation.Code.General
Public Class Support

	Public Shared Function GetPeriod(settings As SettingsService) As Period
		Dim currentTime As DateTime = DateTime.Now
		Dim beginTime As DateTime = DateTime.Parse(settings.GetBeginTime())
		Dim endTime As DateTime = DateTime.Parse(settings.GetEndTime())

		' Compare only the time components
		If currentTime.TimeOfDay >= beginTime.TimeOfDay AndAlso currentTime.TimeOfDay <= endTime.TimeOfDay Then
			Return Period.Night
		Else
			Return Period.Day
		End If
	End Function

	Public Shared Function PlayerIsOn(PlayersFile As String) As Boolean

		Dim Players As List(Of String) = CType(SplitTextInSplits(ReadText(PlayersFile), vbCrLf, SideToReturn.AsListOfString), List(Of String))
		For Each player As String In Players
			If AppIsOn(player) Then Return True
		Next
		Return False
	End Function

	Public Shared Function StringToList(text As String) As List(Of String)
		' Split the input text into lines and return as a List of String
		Dim lines As String() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
		Return New List(Of String)(lines)
	End Function
	Public Shared Function ListToString(strings As List(Of String)) As String
		' Join all items in the list into a single string, each on its own line
		Return String.Join(Environment.NewLine, strings.Select(Function(l) l.ToString()).ToArray())
	End Function

	Public Shared Function NormalizePath(path As String) As String
		If String.IsNullOrWhiteSpace(path) Then Return ""

		Try
			Return IO.Path.GetFullPath(path).ToLowerInvariant().Trim()

		Catch ex As Exception
			Return path.ToLowerInvariant().Trim()

		End Try

	End Function

	'Public Shared Function ReadText(file_ As String, Optional trim_text As Boolean = True) As String
	'	If String.IsNullOrWhiteSpace(file_) Then Return ""
	'	If Not File.Exists(file_) Then Return ""

	'	Const maxRetries As Integer = 5
	'	Const retryDelayMs As Integer = 30

	'	For i As Integer = 1 To maxRetries
	'		Try
	'			Using fs As New FileStream(file_, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
	'				Using sr As New StreamReader(fs, Encoding.UTF8, True)
	'					Dim text = sr.ReadToEnd()
	'					Return If(trim_text, text.Trim(), text)
	'				End Using
	'			End Using

	'		Catch ex As IOException
	'			' File temporarily locked → retry
	'			Threading.Thread.Sleep(retryDelayMs)
	'		Catch
	'			' Other failures → break
	'			Exit For
	'		End Try
	'	Next

	'	Return ""
	'End Function
	'Public Shared Sub WriteText(file_ As String, txt_ As String, Optional append_ As Boolean = False, Optional trim_text As Boolean = True)
	'	If String.IsNullOrWhiteSpace(file_) Then Exit Sub

	'	Const maxRetries As Integer = 5
	'	Const retryDelayMs As Integer = 30

	'	Dim content As String = If(trim_text, txt_.Trim(), txt_)

	'	For i As Integer = 1 To maxRetries
	'		Try
	'			Dim mode As FileMode = If(append_, FileMode.Append, FileMode.Create)

	'			' EXCLUSIVE lock: nobody else can write simultaneously
	'			Using fs As New FileStream(file_, mode, FileAccess.Write, FileShare.None)
	'				Using sw As New StreamWriter(fs, Encoding.UTF8)
	'					sw.WriteLine(content)
	'					sw.Flush()
	'				End Using
	'			End Using

	'			Exit Sub

	'		Catch ex As IOException
	'			' Someone else is writing → retry soon
	'			Threading.Thread.Sleep(retryDelayMs)
	'		Catch
	'			Exit Sub
	'		End Try
	'	Next
	'End Sub

End Class
