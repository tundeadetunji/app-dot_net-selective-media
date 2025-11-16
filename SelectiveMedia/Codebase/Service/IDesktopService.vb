Public Interface IDesktopService
    Sub SetWallpaper(imageLocation As String)
    Sub StartTheApps(apps As List(Of String))
    Sub StartTheApps(file As String)
End Interface
