Public Interface IMediaService
    Sub StartMedia(dialog As IDialogResource, app As IAppService, desktop As IDesktopService, disk As IDiskService, history As IHistoryService, settings As ISettingsService, state As IStateService)
End Interface
