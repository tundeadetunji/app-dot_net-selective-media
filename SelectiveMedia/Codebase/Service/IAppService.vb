Public Interface IAppService
    Sub Start(dialog As IDialogResource, desktop As IDesktopService, disk As IDiskService, history As IHistoryService, settings As ISettingsService, state As IStateService)
    Function CanStart(dialog As IDialogResource, settings As ISettingsService) As Boolean
End Interface
