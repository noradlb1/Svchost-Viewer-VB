Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Svchost_Viewer_Ver1
	Friend Class TreeNode_Collection
		Public myWin32Process As New Win32Process()
		Public myServiceList As New List(Of Win32Service)()
	End Class
End Namespace
