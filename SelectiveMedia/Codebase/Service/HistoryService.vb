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
    Private Function GetRegularHistory() As List(Of String)
        Return StringToList(ReadText(RegularHistoryFile))
    End Function
    Private Sub AddToRegularHistory(index As Long)
        Dim added As List(Of String) = GetRegularHistory()
        added.Add(index)
        WriteText(RegularHistoryFile, ListToString(added))
    End Sub
    Private Sub ClearRegularHistory()
        WriteText(RegularHistoryFile, String.Empty)
    End Sub
    Private Function GetAlternateHistory() As List(Of String)
        Return StringToList(ReadText(AlternateHistoryFile))
    End Function
    Private Sub AddToAlternateHistory(index As Long)
        Dim added As List(Of String) = GetAlternateHistory()
        added.Add(index)
        WriteText(AlternateHistoryFile, ListToString(added))
    End Sub
    Private Sub ClearAlternateHistory()
        WriteText(AlternateHistoryFile, String.Empty)
    End Sub
    Private Function GetNightHistory() As List(Of String)
        Return StringToList(ReadText(NightHistoryFile))
    End Function
    Private Sub AddToNightHistory(index As Long)
        Dim added As List(Of String) = GetNightHistory()
        added.Add(index)
        WriteText(NightHistoryFile, ListToString(added))
    End Sub
    Private Sub ClearNightHistory()
        WriteText(NightHistoryFile, String.Empty)
    End Sub

#End Region

#Region "Exported"
    Public Function FileAtThisIndexHasAlreadyPlayed(index As Long, section As MediaSection) As Boolean
        'Todo fix allowing duplicates
        Select Case section
            Case MediaSection.Regular
                Return GetRegularHistory().Contains(index)
            Case MediaSection.Alternate
                Return GetAlternateHistory().Contains(index)
            Case Else
                Return GetNightHistory().Contains(index)
        End Select
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

    Public Sub AddIndexToHistory(index As Long, section As MediaSection)
        Select Case section
            Case MediaSection.Regular
                AddToRegularHistory(index)
            Case MediaSection.Alternate
                AddToAlternateHistory(index)
            Case MediaSection.Night
                AddToNightHistory(index)
        End Select
    End Sub
    Public Function GetCurrentSequentialFileIndex() As Long
        Return CurrentSequentialFileIndex
    End Function
#End Region

End Class
