<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calendar))
        Me.mCalendar = New System.Windows.Forms.MonthCalendar()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonGoToStart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mCalendar
        '
        Me.mCalendar.BackColor = System.Drawing.Color.White
        Me.mCalendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mCalendar.Location = New System.Drawing.Point(0, 0)
        Me.mCalendar.Name = "mCalendar"
        Me.mCalendar.ShowWeekNumbers = True
        Me.mCalendar.TabIndex = 16773
        '
        'buttonCancel
        '
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(290, 161)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancel.TabIndex = 16774
        Me.buttonCancel.TabStop = False
        Me.buttonCancel.Text = "Button1"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonGoToStart
        '
        Me.buttonGoToStart.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonGoToStart.Location = New System.Drawing.Point(0, 162)
        Me.buttonGoToStart.Name = "buttonGoToStart"
        Me.buttonGoToStart.Size = New System.Drawing.Size(250, 31)
        Me.buttonGoToStart.TabIndex = 16775
        Me.buttonGoToStart.Text = "Go to Start"
        Me.buttonGoToStart.UseVisualStyleBackColor = True
        '
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(250, 193)
        Me.Controls.Add(Me.buttonGoToStart)
        Me.Controls.Add(Me.mCalendar)
        Me.Controls.Add(Me.buttonCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(266, 232)
        Me.MinimizeBox = False
        Me.Name = "Calendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calendar"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mCalendar As MonthCalendar
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonGoToStart As Button
End Class
