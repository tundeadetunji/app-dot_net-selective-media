Imports Newtonsoft.Json
Public Class LogEntry

    <JsonProperty>
    Public ReadOnly Property AtWhatTime As DateTime
    <JsonProperty>
    Public ReadOnly Property Why As String
    <JsonProperty>
    Public ReadOnly Property WhatHappened As String

    <JsonConstructor>
    Public Sub New(WhatHappened As String, Why As String)
        Me.WhatHappened = WhatHappened
        Me.Why = Why
        Me.AtWhatTime = DateTime.Now
    End Sub
    Public Shared Function Create(WhatHappened As String, Why As String) As LogEntry
        Return New LogEntry(WhatHappened, Why)
    End Function

End Class
