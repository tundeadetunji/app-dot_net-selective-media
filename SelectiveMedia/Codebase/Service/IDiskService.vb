Public Interface IDiskService
    Sub RecordFileCount(section As MediaSection, count As Long)
    Sub SetPermissions()
    Function FileCount(section As MediaSection, settings As ISettingsService) As Long
    Function FolderContainsAnySupportedFile(directory As String) As Boolean
    Function GetMediaFiles(directory As String) As List(Of String)
    Function GetMediaFolders(section As MediaSection, settings As ISettingsService) As List(Of String)
    Function GetWallpapers(settings As ISettingsService) As List(Of String)
    Function PromptUserToSelectFile(control_ As Control) As String
    Function PromptUserToSelectFolder(control_ As Control, Optional description_ As String = "Select Folder", Optional ShowNewFolderButton_ As Boolean = True) As String
    Function RecordedFileCount(section As MediaSection) As Long
End Interface
