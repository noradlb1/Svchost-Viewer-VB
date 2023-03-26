'Class made by hackman3vilGuy
'http://www.codeproject.com/KB/vista-security/UAC_Shield_for_Elevation.aspx?msg=2003597

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Runtime.InteropServices

Namespace Svchost_Viewer_Ver1
	Friend Class VistaSecurity


		<DllImport("user32")> _
		Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInt32, ByVal wParam As UInt32, ByVal lParam As UInt32) As UInt32
		End Function

		Friend Const BCM_FIRST As Integer = &H1600 'Normal button
		Friend Const BCM_SETSHIELD As Integer = (BCM_FIRST + &HC) 'Elevated button

		Friend Shared Function IsAdmin() As Boolean
			Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
			Dim p As New WindowsPrincipal(id)
			Return p.IsInRole(WindowsBuiltInRole.Administrator)
		End Function

		Friend Shared Sub AddShieldToButton(ByVal b As Button)
			b.FlatStyle = FlatStyle.System
			SendMessage(b.Handle, BCM_SETSHIELD, 0, &HFFFFFFFFL)
		End Sub

		Friend Shared Sub RestartElevated()
			Dim startInfo As New ProcessStartInfo()
			startInfo.UseShellExecute = True
			startInfo.WorkingDirectory = Environment.CurrentDirectory
			startInfo.FileName = Application.ExecutablePath
			startInfo.Verb = "runas"
			Try
				Dim p As Process = Process.Start(startInfo)
			Catch e1 As System.ComponentModel.Win32Exception
				Return 'If cancelled, do nothing
			End Try

			Application.Exit()
		End Sub
	End Class
End Namespace
