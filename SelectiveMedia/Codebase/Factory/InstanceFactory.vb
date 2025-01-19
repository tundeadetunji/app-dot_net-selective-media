Public Class InstanceFactory

#Region "Initialization"
	Public Shared ReadOnly Property Instance As InstanceFactory = New InstanceFactory
	Private Sub New()
		program = AppService.Instance
		desktop = DesktopService.Instance
		disk = DiskService.Instance
		history = HistoryService.Instance
		playback = MediaService.Instance
		settings = SettingsService.Instance
		state = StateService.Instance(False, MediaSection.Regular)
		ui = UiService.Instance
	End Sub
#End Region

#Region "Exported"
	Public ReadOnly Property program As AppService
	Public ReadOnly Property desktop As DesktopService
	Public ReadOnly Property disk As DiskService
	Public ReadOnly Property history As HistoryService
	Public ReadOnly Property playback As MediaService
	Public ReadOnly Property settings As SettingsService
	Public ReadOnly Property state As StateService
	Public ReadOnly Property ui As UiService

#End Region

End Class
