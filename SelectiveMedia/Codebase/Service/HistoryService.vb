Imports System.Collections.Specialized.BitVector32
Imports iNovation.Code.General
Public Class HistoryService
    Implements IHistoryService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As HistoryService = New HistoryService
    Private Sub New()

    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property HistoryFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\History.txt"
    Private historySet As HashSet(Of String)

#End Region

#Region "Support"
    Private Sub EnsureLoaded()
        If historySet IsNot Nothing Then Return

        historySet = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        If IO.File.Exists(HistoryFile) Then
            For Each line In IO.File.ReadAllLines(HistoryFile)
                Dim norm = Support.NormalizePath(line)
                If norm.Length > 0 Then historySet.Add(norm)
            Next
        End If
    End Sub
#End Region


#Region "Exported"
    'Public Function ThisFileHasAlreadyPlayed(file As String) As Boolean Implements IHistoryService.ThisFileHasAlreadyPlayed
    '    Dim history As List(Of String) = Support.StringToList(ReadText(HistoryFile).Trim)
    '    For Each entry As String In history
    '        If entry.Trim.ToLower.Replace("\\", "\").Equals(file.Replace("\\", "\").Trim.ToLower, StringComparison.CurrentCultureIgnoreCase) Then
    '            Return True
    '        End If
    '    Next

    '    Return False
    'End Function
    Public Function ThisFileHasAlreadyPlayed(file As String) As Boolean Implements IHistoryService.ThisFileHasAlreadyPlayed
        EnsureLoaded()
        Return historySet.Contains(Support.NormalizePath(file))
    End Function


    'Public Function ThisFileHasAlreadyPlayed(file As String) As Boolean Implements IHistoryService.ThisFileHasAlreadyPlayed
    '    Dim normalized = Support.NormalizePath(file)

    '    Dim items = Support.StringToList(ReadText(_HistoryFile))

    '    For Each item As String In items
    '        If Support.NormalizePath(item) = normalized Then
    '            Return True
    '        End If
    '    Next

    '    Return False
    'End Function

    Public Sub ClearHistory() Implements IHistoryService.ClearHistory
        historySet?.Clear()
        IO.File.WriteAllText(HistoryFile, "")
    End Sub

    'Public Sub ClearHistory() Implements IHistoryService.ClearHistory
    '    WriteText(_HistoryFile, "")
    'End Sub

    Public Sub AddFileToHistory(file As String) Implements IHistoryService.AddFileToHistory
        EnsureLoaded()
        Dim norm = Support.NormalizePath(file)
        If historySet.Add(norm) Then
            IO.File.AppendAllLines(HistoryFile, {norm})
        End If
    End Sub

    'Public Sub AddFileToHistory(file As String) Implements IHistoryService.AddFileToHistory
    '    'Dim history As List(Of String) = CType(Support.StringToList(ReadText(HistoryFile)), List(Of String))
    '    Dim history As List(Of String) = ReadText(_HistoryFile).Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries).ToList()
    '    history.Add(Support.NormalizePath(file.Trim.ToLower))
    '    WriteText(_HistoryFile, Support.ListToString(history))
    'End Sub

#End Region

End Class
