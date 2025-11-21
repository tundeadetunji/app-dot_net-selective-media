Imports iNovation.Variant
Imports iNovation.Code.General
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Public Class FileLogger
    Implements Logger(Of LogEntry)

    Private ReadOnly Property LogFile As String
    Private Shared ReadOnly logLock As New Object()
    Private Sub New(LogFile As String)
        Me.LogFile = LogFile
    End Sub
    Public Shared Function Create(LogFile As String) As FileLogger
        Return New FileLogger(LogFile)
    End Function

    Private Sub Log(Entry As LogEntry) Implements Logger(Of LogEntry).Log
        SyncLock logLock
            WriteText(LogFile, JsonConvert.SerializeObject(Entry) & Environment.NewLine)
        End SyncLock
    End Sub
End Class
