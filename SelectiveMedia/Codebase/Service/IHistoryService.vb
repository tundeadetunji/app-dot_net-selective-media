Imports System.Security

Public Interface IHistoryService
    Function ThisFileHasAlreadyPlayed(file As String) As Boolean
    Sub ClearHistory()
    Sub AddFileToHistory(file As String)
End Interface
