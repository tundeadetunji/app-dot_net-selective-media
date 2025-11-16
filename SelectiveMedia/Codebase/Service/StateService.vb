Imports SelectiveMedia.Strings
Public Class StateService
    Implements IStateService

#Region "Initialization"
    Public Shared ReadOnly Property Instance(SequentialState As Boolean, CurrentSection As MediaSection) As StateService
        Get
            Return New StateService(SequentialState, CurrentSection)
        End Get
    End Property

    Private Sub New(SequentialState As Boolean, CurrentSection As MediaSection)
        Me._SequentialState = SequentialState
        Me._CurrentSection = CurrentSection
    End Sub

#End Region

#Region "Properties"
    Private Property _SequentialState As Boolean
    Private Property _CurrentSection As MediaSection
    Private Property _IndexOfSequentialPlayback As Long = 0L
#End Region

#Region "Exported"
    Public Function IndexOfSequentialPlayback() As Long Implements IStateService.IndexOfSequentialPlayback
        Return _IndexOfSequentialPlayback
    End Function

    Public Sub UpdateIndexOfSequentialPlayback(value As Long) Implements IStateService.UpdateIndexOfSequentialPlayback
        _IndexOfSequentialPlayback = value
    End Sub

    Public Function SequentialState() As Boolean Implements IStateService.SequentialState
        Return _SequentialState
    End Function

    Public Function CurrentSection() As MediaSection Implements IStateService.CurrentSection
        Return _CurrentSection
    End Function

    Public Sub UpdateSequentialState(SequentialState As Boolean) Implements IStateService.UpdateSequentialState

        _SequentialState = SequentialState
        'Return Me.SequentialState
    End Sub

    Public Sub UpdateCurrentSection(CurrentSection As MediaSection) Implements IStateService.UpdateCurrentSection

        _CurrentSection = CurrentSection
        'Return Me.CurrentSection
    End Sub
    Public Function NextSection(settings As SettingsService) As MediaSection Implements IStateService.NextSection
        If Support.GetPeriod(settings) = Period.Day Then
            Return If(CurrentSection() = MediaSection.Regular, MediaSection.Alternate, MediaSection.Regular)
        End If
        Return MediaSection.Night

        'Select Case CurrentSection
        '    Case MediaSection.Regular
        '        Return If(Support.GetPeriod(settings) = Period.Day, MediaSection.Alternate, MediaSection.Night)
        '    Case MediaSection.Alternate
        '        Return If(Support.GetPeriod(settings) = Period.Day, MediaSection.Regular, MediaSection.Night)
        'End Select
        'Return MediaSection.Night
    End Function


#End Region
End Class
