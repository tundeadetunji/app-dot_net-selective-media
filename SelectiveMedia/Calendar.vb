Imports iNovation.Code.Desktop
Imports iNovation.Code.General

Imports NModule.D
Imports Feedback.Feedback
Imports Web_Module.DataConnectionDesktop
Imports MachineModule.Machine
Imports System.Collections.ObjectModel
Imports MachineModule.Power
Imports MachineModule.Media
Imports JModule.D
Imports HModule.H
Imports General_Module.FormatWindow
Imports NModule.InternalTypes
Imports NModule.NFunctions
Imports NModule.SJ
Imports System.IO
Imports Web_Module.DW
Imports Web_Module.Methods
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Syncfusion.DocIO.DLS
Imports JModule.J
Imports Miscellaneous.GeneralModule
Public Class Calendar
    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        Close()
    End Sub

    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function sGetStart() As Date
        Dim d As Date
        Dim s_file As String = My.Application.Info.DirectoryPath & "\start.txt"
        If IsEmpty(s_file) Then
            d = Today
        Else
            d = Date.Parse(ReadText(s_file))
        End If
        Return d
    End Function

    Private Sub buttonGoToStart_Click(sender As Object, e As EventArgs) Handles buttonGoToStart.Click
        With mCalendar
            .SetDate(GetStart)

        End With
    End Sub
End Class