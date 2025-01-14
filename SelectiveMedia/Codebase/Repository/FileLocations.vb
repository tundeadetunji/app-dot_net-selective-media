Public Class FileLocations

#Region "Initialization"
	Public Shared ReadOnly Property Instance As New FileLocations
	Private Sub New()

    End Sub
#End Region


#Region "Exported"
	Public ReadOnly Property BeginTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\BeginTime.txt"
	Public ReadOnly Property EndTimeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\EndTime.txt"
	Public ReadOnly ModeFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Mode.txt"
	Public ReadOnly Property AnnounceFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Announce.txt"
	Public ReadOnly Property DayProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\DayPrograms.txt"
	Public ReadOnly Property NightProgramsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\NightPrograms.txt"
	Public ReadOnly Property RateFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Rate.txt"

#End Region

End Class
