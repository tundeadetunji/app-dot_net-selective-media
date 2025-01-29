Imports System.Collections.Specialized.BitVector32
Imports iNovation.Code.General
Public Class HistoryService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As HistoryService = New HistoryService
    Private Sub New()

    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property RegularHistoryFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\RegularHistory.txt"
    Private ReadOnly Property AlternateHistoryFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\AlternateHistory.txt"
    Private ReadOnly Property NightHistoryFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightHistory.txt"
    Private Property CurrentSequentialFileIndex As Long = 0

#End Region

#Region "Support"
    'Private Function GetRegularHistory(util As Support) As List(Of String)
    '    Return StringToList(ReadText(RegularHistoryFile))
    'End Function
    Public Function GetHistory(section As MediaSection, util As Support) As List(Of Long)

        Dim file As String = NightHistoryFile
        If section = MediaSection.Regular Then
            file = RegularHistoryFile
        ElseIf section = MediaSection.Alternate Then
            file = AlternateHistoryFile
        End If

        ' Convert the text read from the file into a list of strings
        Dim historyStrings As List(Of String) = util.StringToList(ReadText(file))

        ' Convert the list of strings to a list of longs
        Dim historyLongs As New List(Of Long)
        For Each historyString As String In historyStrings
            Dim value As Long
            If Long.TryParse(historyString.Trim(), value) Then
                historyLongs.Add(value)
            End If
        Next

        Return historyLongs
    End Function

    Private Sub AddToRegularHistory(index As Long, util As Support)
        Dim added As List(Of Long) = GetHistory(MediaSection.Regular, util)
        added.Add(index)
        WriteText(RegularHistoryFile, util.ListToString(added))
    End Sub
    Private Sub ClearRegularHistory()
        WriteText(RegularHistoryFile, String.Empty)
    End Sub
    'Private Function GetAlternateHistory(util As Support) As List(Of String)
    '    Return StringToList(ReadText(AlternateHistoryFile))
    'End Function
    Private Sub AddToAlternateHistory(index As Long, util As Support)
        Dim added As List(Of Long) = GetHistory(MediaSection.Alternate, util)
        added.Add(index)
        WriteText(AlternateHistoryFile, util.ListToString(added))
    End Sub
    Private Sub ClearAlternateHistory()
        WriteText(AlternateHistoryFile, String.Empty)
    End Sub
    'Private Function GetNightHistory(util As Support) As List(Of String)
    '    Return StringToList(ReadText(NightHistoryFile))
    'End Function
    Private Sub AddToNightHistory(index As Long, util As Support)
        Dim added As List(Of Long) = GetHistory(MediaSection.Night, util)
        added.Add(index)
        WriteText(NightHistoryFile, util.ListToString(added))
    End Sub
    Private Sub ClearNightHistory()
        WriteText(NightHistoryFile, String.Empty)
    End Sub

#End Region

#Region "Exported"
    Public Function FileAtThisIndexHasAlreadyPlayed(index As Long, section As MediaSection, util As Support) As Boolean
        Return GetHistory(section, util).Contains(index)
    End Function

    Public Sub UpdateIndexOfSequentialPlayback(index As Long)
        Me.CurrentSequentialFileIndex = index
    End Sub

    Public Sub ClearHistory(section As MediaSection)
        Select Case section
            Case MediaSection.Regular
                ClearRegularHistory()
            Case MediaSection.Alternate
                ClearAlternateHistory()
            Case MediaSection.Night
                ClearNightHistory()
        End Select
    End Sub

    Public Sub AddIndexToHistory(index As Long, section As MediaSection, util As Support)
        Select Case section
            Case MediaSection.Regular
                AddToRegularHistory(index, util)
            Case MediaSection.Alternate
                AddToAlternateHistory(index, util)
            Case MediaSection.Night
                AddToNightHistory(index, util)
        End Select
    End Sub
    Public Function GetCurrentSequentialFileIndex() As Long
        Return CurrentSequentialFileIndex
    End Function
#End Region

End Class
