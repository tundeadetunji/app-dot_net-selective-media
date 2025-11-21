Public Class Files
#Region "Exported"
    Public Shared ReadOnly Property LogFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\LogFile.txt"
    Public Shared ReadOnly Property PlayersFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\Players.txt"
    Public Shared ReadOnly Property HelpFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\SelectiveMediaHelp.html"
    Public Shared ReadOnly Property EditIcon As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\EditIcon.png"
    Public Shared ReadOnly Property LockIcon As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\iNovation Digital Works\Media\LockIcon.png"

#End Region
End Class
