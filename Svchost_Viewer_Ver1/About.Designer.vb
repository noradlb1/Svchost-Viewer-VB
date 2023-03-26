Namespace Svchost_Viewer_Ver1
	Partial Public Class About
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		Private Shadows ProductName As System.Windows.Forms.Label
		Private Shadows ProductVersion As System.Windows.Forms.Label
		Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
		Private WithEvents Ok_button As System.Windows.Forms.Button

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(About))
			Me.ProductName = New System.Windows.Forms.Label()
			Me.ProductVersion = New System.Windows.Forms.Label()
			Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.Ok_button = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' ProductName
			' 
			Me.ProductName.AutoSize = True
			Me.ProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.ProductName.Location = New System.Drawing.Point(9, 9)
			Me.ProductName.Name = "ProductName"
			Me.ProductName.Size = New System.Drawing.Size(110, 17)
			Me.ProductName.TabIndex = 0
			Me.ProductName.Text = "Product Name"
			' 
			' ProductVersion
			' 
			Me.ProductVersion.AutoSize = True
			Me.ProductVersion.Location = New System.Drawing.Point(9, 28)
			Me.ProductVersion.Name = "ProductVersion"
			Me.ProductVersion.Size = New System.Drawing.Size(81, 13)
			Me.ProductVersion.TabIndex = 1
			Me.ProductVersion.Text = "Product version"
			' 
			' richTextBox1
			' 
			Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default
			Me.richTextBox1.Location = New System.Drawing.Point(12, 57)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.ReadOnly = True
			Me.richTextBox1.Size = New System.Drawing.Size(316, 96)
			Me.richTextBox1.TabIndex = 2
			Me.richTextBox1.Text = "Svchost viewer is" & ControlChars.Lf & "made by ShoXDK" & ControlChars.Lf & ControlChars.Lf & "Source code and updates are available on" & ControlChars.Lf & "http:/" & "/www.codeplex.com/svchostviewer" & ControlChars.Lf & ControlChars.Lf & "Open/Freeware 2009"
'			Me.richTextBox1.LinkClicked += New System.Windows.Forms.LinkClickedEventHandler(Me.richTextBox1_LinkClicked)
			' 
			' Ok_button
			' 
			Me.Ok_button.Location = New System.Drawing.Point(133, 159)
			Me.Ok_button.Name = "Ok_button"
			Me.Ok_button.Size = New System.Drawing.Size(75, 23)
			Me.Ok_button.TabIndex = 3
			Me.Ok_button.Text = "OK"
			Me.Ok_button.UseVisualStyleBackColor = True
'			Me.Ok_button.Click += New System.EventHandler(Me.Ok_button_Click)
			' 
			' About
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(340, 187)
			Me.Controls.Add(Me.Ok_button)
			Me.Controls.Add(Me.richTextBox1)
			Me.Controls.Add(Me.ProductVersion)
			Me.Controls.Add(Me.ProductName)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "About"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "About"
'			Me.Load += New System.EventHandler(Me.About_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region


	End Class
End Namespace