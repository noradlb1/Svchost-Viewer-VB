Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Svchost_Viewer_Ver1
	Friend Class GetSvchostInfoHandler
		Private mylist As New List(Of TreeNode_Collection)()

		''' <summary>
		''' Will get all the running svchost processes, and the services there running.
		''' </summary>
		''' <returns></returns>
		Public Function GetData() As List(Of TreeNode_Collection)
			Dim myWMIAccess As New WMIAccess()

			Dim myWin32Process As New List(Of Win32Process)()
			Dim myWin32Services As New List(Of Win32Service)()
			Dim myTreeNode_Collection As New List(Of TreeNode_Collection)()
			Dim newNode As TreeNode_Collection

			'Get all svchost.exe processes and save the info in myWin32Process.
			myWin32Process = myWMIAccess.getSpecficProcesses("SELECT * FROM Win32_Process WHERE Caption=""svchost.exe""")

			For Each x As Win32Process In myWin32Process
				newNode = New TreeNode_Collection()
				myWin32Services = New List(Of Win32Service)()

				newNode.myWin32Process = x

				myWin32Services = myWMIAccess.getSpecificServices("SELECT * FROM Win32_Service WHERE ProcessId=""" & x.ProcessId.ToString() & """")
				newNode.myServiceList = myWin32Services

				myTreeNode_Collection.Add(newNode)

				myWin32Services = Nothing
				newNode = Nothing
			Next x

			'Clean up:::::::::::::::::.........
			newNode = Nothing
			myWMIAccess = Nothing
			myWin32Process = Nothing
			myWin32Services = Nothing

			Return myTreeNode_Collection
		End Function

	End Class
End Namespace
