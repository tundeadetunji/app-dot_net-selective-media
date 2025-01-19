Imports System.Collections.ObjectModel
Public Class DiskService

#Region "Properties"
	Private Property _RegularFiles As List(Of String) = New List(Of String)
	Private Property _AlternateFiles As List(Of String) = New List(Of String)
	Private Property _NightFiles As List(Of String) = New List(Of String)

#End Region

#Region "Support"
	Private Sub SetRegularFiles(files As List(Of String))
		_RegularFiles = files
	End Sub
	Private Sub SetAlternateFiles(files As List(Of String))
		_AlternateFiles = files
	End Sub
	Private Sub SetNightFiles(files As List(Of String))
		_NightFiles = files
	End Sub

#End Region

#Region "Exported"

	Public Function GetFolder(control_ As Control, Optional description_ As String = "Select Folder", Optional ShowNewFolderButton_ As Boolean = True) As String


		Dim f_ As New FolderBrowserDialog

		With f_
			.Description = description_
			.ShowNewFolderButton = ShowNewFolderButton_
			.ShowDialog()

			Return If(String.IsNullOrEmpty(.SelectedPath), control_.Text, .SelectedPath)

		End With
	End Function

	Public Function GetFiles(section As MediaSection) As List(Of String)
		Select Case section
			Case MediaSection.Alternate
				Return _AlternateFiles
			Case MediaSection.Regular
				Return _RegularFiles
			Case Else
				Return _NightFiles
		End Select
	End Function

	Public Sub SetFiles(settings As SettingsService)

	End Sub

#End Region

End Class
