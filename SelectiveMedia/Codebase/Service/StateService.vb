Imports SelectiveMedia.Constants
Public Class StateService

#Region "Initialization"
    Public Shared ReadOnly Property Instance(SequentialState As Boolean, CurrentSection As MediaSection) As StateService
        Get
            Return New StateService(SequentialState, CurrentSection)
        End Get
    End Property

    Private Sub New(SequentialState As Boolean, CurrentSection As MediaSection)
        Me.SequentialState = SequentialState
        Me.CurrentSection = CurrentSection
    End Sub

#End Region

#Region "Properties"
    Public Property SequentialState As Boolean
    Public Property CurrentSection As MediaSection
#End Region

#Region "Support"
#End Region

#Region "Exported"
    Public Function UpdateSequentialState(SequentialState As Boolean) As Boolean
        Me.SequentialState = SequentialState
        Return Me.SequentialState
    End Function

    Public Function UpdateCurrentSection(CurrentSection As MediaSection) As MediaSection
        Me.CurrentSection = CurrentSection
        Return Me.CurrentSection
    End Function
    Public Function NextSection(app As AppService) As MediaSection
        Select Case Me.CurrentSection
            Case MediaSection.Regular
                Return If(app.GetPeriod = Period.Day, MediaSection.Alternate, MediaSection.Night)
            Case MediaSection.Alternate
                Return If(app.GetPeriod = Period.Day, MediaSection.Regular, MediaSection.Night)
        End Select
        Return MediaSection.Night
    End Function


#End Region
End Class
