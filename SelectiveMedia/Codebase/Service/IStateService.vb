Public Interface IStateService
    Sub UpdateCurrentSection(CurrentSection As MediaSection)
    Sub UpdateSequentialState(SequentialState As Boolean)
    Function CurrentSection() As MediaSection
    Function NextSection(settings As SettingsService) As MediaSection
    Function SequentialState() As Boolean
    Function IndexOfSequentialPlayback() As Long
    Sub UpdateIndexOfSequentialPlayback(value As Long)

End Interface
