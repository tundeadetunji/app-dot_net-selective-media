Imports System.Linq
Public Class Support
    Public Function StringToList(text As String) As List(Of String)
        ' Split the input text into lines and return as a List of String
        Dim lines As String() = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Return New List(Of String)(lines)
    End Function
    Public Function ListToString(longs As List(Of Long)) As String
        ' Join all items in the list into a single string, each on its own line
        Return String.Join(Environment.NewLine, longs.Select(Function(l) l.ToString()).ToArray())
    End Function
End Class
