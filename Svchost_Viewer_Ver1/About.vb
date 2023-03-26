Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Svchost_Viewer_Ver1
	Partial Public Class About
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub About_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			ProductName.Text = Application.ProductName
			ProductVersion.Text = "version : " & Application.ProductVersion
		End Sub

		Private Sub Ok_button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ok_button.Click
			Close()
		End Sub

		Private Sub richTextBox1_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs) Handles richTextBox1.LinkClicked
			Try
				System.Diagnostics.Process.Start(e.LinkText)
			Catch e1 As Exception
			End Try
		End Sub
	End Class
End Namespace
