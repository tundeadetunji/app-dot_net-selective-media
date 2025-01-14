Public Class RepositoryFactory

#Region "Initialization"
    Public Shared ReadOnly Property Instance As RepositoryFactory = New RepositoryFactory
    Private Sub New()

    End Sub
#End Region

#Region "Exported"
    Public ReadOnly Property files As FileLocations = FileLocations.Instance
#End Region

End Class
