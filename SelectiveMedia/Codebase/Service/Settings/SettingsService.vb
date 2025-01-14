Public Class SettingsService

#Region "Initialization"
    Public Shared ReadOnly Property Instance As New SettingsService
    Private Sub New()

    End Sub
#End Region

#Region "Properties"

    Private ReadOnly Property services As ServiceFactory = ServiceFactory.Instance

#End Region

#Region "Exported"
    Public Function GetNightMediaLocation() As String

    End Function
    Public Sub SetNightMediaLocation(location As String)

    End Sub
    Public Function GetRegularMediaLocation() As String

    End Function
    Public Sub SetRegularMediaLocation(location As String)

    End Sub
    Public Function GetAlternateMediaLocation() As String

    End Function
    Public Sub SetAlternateMediaLocation(location As String)

    End Sub
    Public Function GetWallpaperLocation() As String

    End Function
    Public Sub SetWallpaperLocation(location As String)

    End Sub
    Public Function GetAnnounce() As String

    End Function
    Public Sub SetAnnounce(location As String)

    End Sub

    Public Function GetBeginTime() As String
        Dim b_time_f As String
        Try
            b_time_f = My.Computer.FileSystem.ReadAllText(BeginTimeFile).Trim
        Catch x As Exception
            b_time_f = "12:00 AM"
        End Try
        Return b_time_f
    End Function

    Public Sub SetBeginTime(begin_time As String)
        Try
            My.Computer.FileSystem.WriteAllText(BeginTimeFile, b_, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetEndTime() As String
        Dim e_time_f As String
        Try
            e_time_f = My.Computer.FileSystem.ReadAllText(end_time).Trim
        Catch x As Exception
            e_time_f = "6:00 AM"
        End Try
        Return e_time_f
    End Function

    Public Sub SetEndTime(end_time As String)
        Try
            My.Computer.FileSystem.WriteAllText(end_time, e_, False)
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetMode() As String

    End Function

    Public Sub SetMode(_mode As String)

    End Sub
    Public Function GetRate() As String

    End Function

    Public Sub SetRate(_rate As String)

    End Sub
    Public Function GetProgramsFile() As String

    End Function

    Public Sub SetProgramsFile(ProgramsFile As String)

    End Sub

#End Region

End Class
