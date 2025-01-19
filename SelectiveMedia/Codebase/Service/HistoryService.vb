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

    End Function
    Private Sub AddToRegularHistory(file As String)

    End Sub
    Private Sub ClearRegularHistory(file As String)

    End Sub
    Private Function GetAlternateHistory() As List(Of String)

    End Function
    Private Sub AddToAlternateHistory(file As String)

    End Sub
    Private Sub ClearAlternateHistory(file As String)

    End Sub
    Private Function GetNightHistory() As List(Of String)

    End Function
    Private Sub AddToNightHistory(file As String)

    End Sub
    Private Sub ClearNightHistory(file As String)

    End Sub

#End Region

#Region "Exported"
    Public Function ThisFileHasAlreadyPlayed(file As String, section As MediaSection) As Boolean

    End Function

    Public Sub UpdateTheIndexOfTheFilePlayingNow(index As Long)
        Me.CurrentSequentialFileIndex = index
    End Sub

    Public Sub ClearHistory(section As MediaSection)

    End Sub

    Public Function AddFileToHistory(file As String, section As MediaSection)

    End Function
    Public Function GetCurrentSequentialFileIndex() As Long
        Return CurrentSequentialFileIndex
    End Function
#End Region

End Class
