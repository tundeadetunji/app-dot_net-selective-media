Imports System.Runtime.Remoting

Public Class AppService

#Region "Properties"
    Private ReadOnly Property disk As DiskService = DiskService.Instance
#End Region

#Region "Support"

	Private Sub SetPermissions()

        PermitFolder(My.Application.Info.DirectoryPath)

    End Sub

	Private Sub PrepDay()
		'films, theme
		'close my widgets and vg
		WTimer.Enabled = True

		'		Try
		'			Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Microsoft\Windows\Themes\theme.theme")
		'		Catch ex As Exception
		'		End Try
		Try
			PickWallpaper("d")
		Catch ex As Exception
		End Try
		'open other programs
		StartApps(ReadText(programs_))
	End Sub

	Private Sub PrepNight()
		'adult films, theme
		'my widgets, vg
		WTimer.Enabled = False
		''Try
		''	Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\My Widgets\Picture Frame.widget")
		''Catch ex As Exception
		''End Try
		Try
			PickWallpaper("n")
		Catch ex As Exception
		End Try
		'open other programs
		StartApps(ReadText(programs_alternate))
	End Sub

#End Region

#Region "Exported"
	Public Sub OnStartup(dialog As IDialogResource)
        'Todo remove
        disk.SetPermissions()
    End Sub

    ''' <summary>
    ''' All files are in place and locations are valid
    ''' </summary>
    ''' <returns></returns>
    Public Function CanStart(dialog As IDialogResource) As Boolean

    End Function

	Public Sub Start(dialog As IDialogResource)


		If Date.Parse(Now.ToShortTimeString) >= Date.Parse(BeginTime.Value.ToShortTimeString) And Date.Parse(Now.ToShortTimeString) <= Date.Parse(EndTime.Value.ToShortTimeString) Then
			DayWTimer.Enabled = True
		Else
			NWTimer.Enabled = True
		End If

		MediaTimer.Enabled = True

	End Sub


	Public Function GetPeriod() As Period

	End Function

#End Region
End Class
