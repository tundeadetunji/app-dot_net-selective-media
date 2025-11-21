Imports iNovation.Variant
Public Class LogEntry

    Public ReadOnly Property AtWhatTime As DateTime
    Public ReadOnly Property Why As String
    Public ReadOnly Property WhatHappened As String

    Private Sub New(WhatHappened As String, Why As String)
        Me.WhatHappened = WhatHappened
        Me.Why = Why
        Me.AtWhatTime = DateTime.Now
    End Sub
    Public Shared Function Create(WhatHappened As String, Why As String) As LogEntry
        Return New LogEntry(WhatHappened, Why)
    End Function
End Class
