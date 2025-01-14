Public Class ServiceFactory

#Region "Init"

    Public Shared ReadOnly Property Instance As New ServiceFactory
    Private Sub New()

    End Sub

#End Region

#Region "Exported"
    Public ReadOnly Property disk As DiskService = DiskService.Instance
    Public ReadOnly Property desktop As DesktopService = DesktopService.Instance
    Public ReadOnly Property ui As UiService = UiService.Instance
    Public ReadOnly Property settings As SettingsService = SettingsService.Instance
    Public ReadOnly Property media As MediaService = MediaService.Instance


#End Region
End Class
