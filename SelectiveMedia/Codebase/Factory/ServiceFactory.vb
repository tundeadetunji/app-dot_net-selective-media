Public Class ServiceFactory

#Region "Initialization"
	Public Shared ReadOnly Property Instance As ServiceFactory = New ServiceFactory
	Private Sub New()
		app = AppService.Instance
		desktop = DesktopService.Instance
		disk = DiskService.Instance
		history = HistoryService.Instance
		playback = MediaService.Instance
		settings = SettingsService.Instance
		ui = UiService.Instance(settings)
	End Sub
#End Region

#Region "Exported"
	Public ReadOnly Property app As IAppService
	Public ReadOnly Property desktop As IDesktopService
	Public ReadOnly Property disk As IDiskService
	Public ReadOnly Property history As IHistoryService
	Public ReadOnly Property playback As IMediaService
	Public ReadOnly Property settings As ISettingsService
	Public ReadOnly Property ui As IUiService

#End Region

End Class
