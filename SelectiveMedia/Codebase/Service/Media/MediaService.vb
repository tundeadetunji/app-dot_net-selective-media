Public Class MediaService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As MediaService = New MediaService
    Private Sub New()

    End Sub

#End Region

#Region "Properties"
    Private ReadOnly Property services As ServiceFactory = ServiceFactory.Instance
    Private ReadOnly Property repository As RepositoryFactory = RepositoryFactory.Instance
#End Region


#Region "Exported"
    Public Sub StartMedia(dialog As IDialogResource)

    End Sub
#End Region

End Class
