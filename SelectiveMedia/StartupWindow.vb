Public Class StartupWindow
	Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
		With Form1
			'			.Visible = True
			.Opacity = 0
			'			.InTimer.Enabled = True
			.Show()
		End With

	End Sub
End Class