Imports System.Collections.ObjectModel
Public Class Constants

#Region "Exported"
	Public Const Random As String = "Random"
	Public Const Sequential As String = "Sequential"
	Public Const SequentialNight As String = "SequentialNight"
	Public Const SequentialRegular As String = "SequentialRegular"
	Public Const SequentialAlternate As String = "SequentialAlternate"
	Public Const App As String = "App"
	Public Const Relaxed As String = "Relaxed"
	Public Const Ad As String = "Ad"
	Public Const Alternate As String = "Alternate"
	Public Const Regular As String = "Regular"
	Public Const Night As String = "Night"
	Public Const TwoMinutes As Integer = 120000
	Public Const TwoSeconds As Integer = 2000
	Public Const TwentyMinutes As Integer = 1000 * 20 * 60
	Public Const TenMinutes As Integer = 1000 * 10 * 60
	Public Const FiveMinutes As Integer = 1000 * 5 * 60
	Public Const ThreeMinutes As Integer = 1000 * 3 * 60
	Public Shared SupportedMediaFileTypes As New List(Of String) From {
		"*.avi", "*.mkv", "*.wmv", "*.mov", "*.mp4", "*.3gp", "*.3gpp", "*.flv", "*.mpg", "*.mpeg", "*.vob", "*.dat", "*.amv", "*.m4v", "*.webm"
	}
	Public Shared SupportedImageFileTypes As New List(Of String) From {
		"*.jpg", "*.jpeg", "*.bmp"
	}

#End Region

End Class
