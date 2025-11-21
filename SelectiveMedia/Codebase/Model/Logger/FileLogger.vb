Imports iNovation.Variant
Imports iNovation.Code.General
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Public Class FileLogger
    Implements Logger(Of LogEntry)

    Private ReadOnly Property LogFile As String
    Private Sub New(LogFile As String)
        Me.LogFile = LogFile
    End Sub
    Public Shared Function Create(LogFile As String) As FileLogger
        Return New FileLogger(LogFile)
    End Function

    Private Sub Logger_Log(Entry As LogEntry) Implements Logger(Of LogEntry).Log
        Dim savedEntries As String = ReadText(LogFile)
        Dim Entries As HashSet(Of LogEntry) = If(String.IsNullOrEmpty(savedEntries), New HashSet(Of LogEntry), New HashSet(Of LogEntry)(JsonConvert.DeserializeObject(Of List(Of LogEntry))(savedEntries)))
        Entries.Add(Entry)
        Dim EntriesAsList As List(Of LogEntry) = New List(Of LogEntry)(Entries)
        WriteText(LogFile, JsonConvert.SerializeObject(New List(Of LogEntry)(Entries)))
    End Sub
End Class
