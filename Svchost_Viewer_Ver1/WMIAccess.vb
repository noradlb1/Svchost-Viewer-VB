' Class used to access service information in the windows WMI
'''* "database", made by ShoXDK
' * 19-06-2009
'

Imports System
Imports System.Collections.Generic
'using System.Linq;
Imports System.Text

Imports System.Management
Imports System.Diagnostics

Namespace Svchost_Viewer_Ver1

	Public Class WMIAccess
		'Got it from http://www.csharphelp.com/board2/read.html?f=1&i=11982&t=11982
		Private Shared Function ToDateTime(ByVal dmtfDate As String) As Date
			'There is a utility called mgmtclassgen that ships with the .NET SDK that
			'will generate managed code for existing WMI classes. It also generates
			' datetime conversion routines like this one.
			'Thanks to Chetan Parmar and dotnet247.com for the help.
			Dim year As Integer = Date.Now.Year
			Dim month As Integer = 1
			Dim day As Integer = 1
			Dim hour As Integer = 0
			Dim minute As Integer = 0
			Dim second As Integer = 0
			Dim millisec As Integer = 0
			Dim dmtf As String = dmtfDate
			Dim tempString As String = System.String.Empty

			If ((System.String.Empty = dmtf) OrElse (dmtf Is Nothing)) Then
				Return Date.MinValue
			End If

			If (dmtf.Length <> 25) Then
				Return Date.MinValue
			End If

			tempString = dmtf.Substring(0, 4)
			If ("****" <> tempString) Then
				year = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(4, 2)

			If ("**" <> tempString) Then
				month = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(6, 2)

			If ("**" <> tempString) Then
				day = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(8, 2)

			If ("**" <> tempString) Then
				hour = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(10, 2)

			If ("**" <> tempString) Then
				minute = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(12, 2)

			If ("**" <> tempString) Then
				second = System.Int32.Parse(tempString)
			End If

			tempString = dmtf.Substring(15, 3)

			If ("***" <> tempString) Then
				millisec = System.Int32.Parse(tempString)
			End If

			Dim dateRet As New Date(year, month, day, hour, minute, second, millisec)

			Return dateRet
		End Function


		'Services___________________________________________________________________________

		''' <summary>
		''' Returns a list with all the services on the system, in the Win32Services form.
		''' </summary>
		''' <returns>List<Win32Services></returns>
		Public Function getAllServices() As List(Of Win32Service)
			Dim mylist As New List(Of Win32Service)()
			Dim MyWin32Services As Win32Service

			'Setup to get data out of the Windows WMI:::...
			Dim mos As New ManagementObjectSearcher("root\CIMV2", String.Format("SELECT * FROM Win32_Service"))

			'Looping through the WMI results::::::.....
			For Each result As ManagementObject In mos.Get()
				MyWin32Services = New Win32Service()

				MyWin32Services = getServiceData(result)

				mylist.Add(MyWin32Services)
				MyWin32Services = Nothing
			Next result
			Return mylist
		End Function

		Public Function getSpecificServices(ByVal WMI_Search As String) As List(Of Win32Service)
			Dim mylist As New List(Of Win32Service)()
			Dim MyWin32Services As Win32Service

			Try
				'Setup to get data out of the Windows WMI:::...
				Dim mos As New ManagementObjectSearcher("root\CIMV2", String.Format(WMI_Search))

				'Looping through the WMI results::::::.....
				For Each result As ManagementObject In mos.Get()
					MyWin32Services = New Win32Service()
					MyWin32Services = getServiceData(result)
					mylist.Add(MyWin32Services)
					MyWin32Services = Nothing
				Next result
			Catch e As Exception
				Throw New Exception("Something went wrong !!!" & ControlChars.Lf & "Error message:" & ControlChars.Lf & e.Message)
			End Try

			Return mylist
		End Function

		Public Function getServiceData(ByVal result As ManagementObject) As Win32Service
			Dim MyWin32Services As New Win32Service()

'			#Region "MyWin32Services.AcceptPause"
			Try
				MyWin32Services.AcceptPause = DirectCast(result("AcceptPause"), Boolean)
			Catch e1 As NullReferenceException
				MyWin32Services.AcceptPause = False
			End Try
'			#End Region

'			#Region "MyWin32Services.AcceptStop"
			Try
				MyWin32Services.AcceptStop = DirectCast(result("AcceptStop"), Boolean)
			Catch e2 As NullReferenceException
				MyWin32Services.AcceptStop = False
			End Try
'			#End Region

'			#Region "MyWin32Services.Caption"
			Try
				MyWin32Services.Caption = DirectCast(result("Caption"), String)
			Catch e3 As NullReferenceException
				MyWin32Services.Caption = "No Caption Found."
			End Try
'			#End Region

'			#Region "MyWin32Services.CheckPoint"
			Try
				MyWin32Services.CheckPoint = DirectCast(result("CheckPoint"), UInt32)
			Catch e4 As NullReferenceException
				MyWin32Services.CheckPoint = 0
			End Try
'			#End Region

'			#Region "MyWin32Services.CreationClassName"
			Try
				MyWin32Services.CreationClassName = DirectCast(result("CreationClassName"), String)
			Catch e5 As NullReferenceException
				MyWin32Services.CreationClassName = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.Description"
			Try
				MyWin32Services.Description = DirectCast(result("Description"), String)
			Catch e6 As NullReferenceException
				MyWin32Services.Description = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.DesktopInterac"
			Try
				MyWin32Services.DesktopInteract = DirectCast(result("DesktopInteract"), Boolean)
			Catch e7 As NullReferenceException
				MyWin32Services.DesktopInteract = False
			End Try
'			#End Region

'			#Region "MyWin32Services.DisplayName"
			Try
				MyWin32Services.DisplayName = DirectCast(result("DisplayName"), String)
			Catch e8 As NullReferenceException
				MyWin32Services.DisplayName = ""
			End Try
'			#End Region

'			#Region " MyWin32Services.ErrorControl"
			Try
				MyWin32Services.ErrorControl = DirectCast(result("ErrorControl"), String)
			Catch e9 As NullReferenceException
				MyWin32Services.ErrorControl = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.ExitCode"
			Try
				MyWin32Services.ExitCode = DirectCast(result("ExitCode"), UInt32)
			Catch e10 As NullReferenceException
				MyWin32Services.ExitCode = 0
			End Try
'			#End Region

'			#Region "MyWin32Services.InstallDate"
			Try
				MyWin32Services.InstallDate = DirectCast(result("InstallDate"), Date)
			Catch e11 As NullReferenceException
				MyWin32Services.InstallDate = Date.MinValue
			End Try
'			#End Region

'			#Region "MyWin32Services.Name"
			Try
				MyWin32Services.Name = DirectCast(result("Name"), String)
			Catch e12 As NullReferenceException
				MyWin32Services.Name = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.PathName"
			Try
				MyWin32Services.PathName = DirectCast(result("PathName"), String)
			Catch e13 As NullReferenceException
				MyWin32Services.PathName = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.ProcessId   NOTE: Maybe problem with Null result...."
			Try
				MyWin32Services.ProcessId = DirectCast(result("ProcessId"), UInt32)
			Catch e14 As NullReferenceException
				MyWin32Services.ProcessId = 0
			End Try
'			#End Region

'			#Region "MyWin32Services.ServiceSpecificExitCode"
			Try
				MyWin32Services.ServiceSpecificExitCode = DirectCast(result("ServiceSpecificExitCode"), UInt32)
			Catch e15 As NullReferenceException
				MyWin32Services.ServiceSpecificExitCode = 0
			End Try
'			#End Region

'			#Region "MyWin32Services.ServiceType"
			Try
				MyWin32Services.ServiceType = DirectCast(result("ServiceType"), String)
			Catch e16 As NullReferenceException
				MyWin32Services.ServiceType = ""
			End Try

'			#End Region

'			#Region "MyWin32Services.Started"
			Try
				MyWin32Services.Started = DirectCast(result("Started"), Boolean)
			Catch e17 As NullReferenceException
				MyWin32Services.Started = False
			End Try
'			#End Region

'			#Region "MyWin32Services.StartMode"
			Try
				MyWin32Services.StartMode = DirectCast(result("StartMode"), String)
			Catch e18 As NullReferenceException
				MyWin32Services.StartMode = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.StartName"
			Try
				MyWin32Services.StartName = DirectCast(result("StartName"), String)
			Catch e19 As NullReferenceException
				MyWin32Services.StartName = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.State"
			Try
				MyWin32Services.State = DirectCast(result("State"), String)
			Catch e20 As NullReferenceException
				MyWin32Services.State = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.Status"
			Try
				MyWin32Services.Status = DirectCast(result("Status"), String)
			Catch e21 As NullReferenceException
				MyWin32Services.Status = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.SystemCreationClassName"
			Try
				MyWin32Services.SystemCreationClassName = DirectCast(result("SystemCreationClassName"), String)
			Catch e22 As NullReferenceException
				MyWin32Services.SystemCreationClassName = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.SystemName"
			Try
				MyWin32Services.SystemName = DirectCast(result("SystemName"), String)
			Catch e23 As NullReferenceException
				MyWin32Services.SystemName = ""
			End Try
'			#End Region

'			#Region "MyWin32Services.TagId"
			Try
				MyWin32Services.TagId = DirectCast(result("TagId"), UInt32)
			Catch e24 As NullReferenceException
				MyWin32Services.TagId = 0
			End Try
'			#End Region

'			#Region "MyWin32Services.WaitHint"
			Try
				MyWin32Services.WaitHint = DirectCast(result("WaitHint"), UInt32)
			Catch e25 As NullReferenceException
				MyWin32Services.WaitHint = 0
			End Try
'			#End Region

			Return MyWin32Services
		End Function

		'Processes__________________________________________________________________________

		Public Function getSpecficProcesses(ByVal WMI_Search As String) As List(Of Win32Process)
			Dim mylist As New List(Of Win32Process)()
			Dim MyWin32Process As Win32Process

			Dim mos As New ManagementObjectSearcher("root\CIMV2", String.Format(WMI_Search))

			For Each result As ManagementObject In mos.Get()
				MyWin32Process = New Win32Process()
				MyWin32Process = getAllProcessData(result)
				mylist.Add(MyWin32Process)
				MyWin32Process = Nothing
			Next result


			Return mylist
		End Function

		Public Function getAllProcessData(ByVal result As ManagementObject) As Win32Process
			Dim MyWin32process As New Win32Process()

'			#Region "MyWin32process.Caption"
			Try
				MyWin32process.Caption = DirectCast(result("Caption"), String)
			Catch e1 As NullReferenceException
				MyWin32process.Caption = ""
			End Try
'			#End Region

'			#Region "MyWin32process.CommandLine"
			Try
				MyWin32process.CommandLine = DirectCast(result("CommandLine"), String)
			Catch e2 As NullReferenceException
				MyWin32process.CommandLine = ""
			End Try
'			#End Region

'			#Region "MyWin32process.CreationClassName"
			Try
				MyWin32process.CreationClassName = DirectCast(result("CreationClassName"), String)
			Catch e3 As NullReferenceException
				MyWin32process.CreationClassName = ""
			End Try
'			#End Region

'			#Region "MyWin32process.CreationDate"
			Try
				MyWin32process.CreationDate = ToDateTime(DirectCast(result("CreationDate"), String)).ToString()
			Catch e4 As NullReferenceException
				MyWin32process.CreationDate = ""
			End Try
'			#End Region

'			#Region "MyWin32process.CSCreationClassName"
			Try
				MyWin32process.CSCreationClassName = DirectCast(result("CSCreationClassName"), String)
			Catch e5 As NullReferenceException
				MyWin32process.CSCreationClassName = ""
			End Try
'			#End Region

'			#Region "MyWin32process.CSName"
			Try
				MyWin32process.CSName = DirectCast(result("CSName"), String)
			Catch e6 As NullReferenceException
				MyWin32process.CSName = ""
			End Try
'			#End Region

'			#Region "MyWin32process.Description"
			Try
				MyWin32process.Description = DirectCast(result("Description"), String)
			Catch e7 As NullReferenceException
				MyWin32process.Description = ""
			End Try
'			#End Region

'			#Region "MyWin32process.ExecutablePath"
			Try
				MyWin32process.ExecutablePath = DirectCast(result("ExecutablePath"), String)
			Catch e8 As NullReferenceException
				MyWin32process.ExecutablePath = ""
			End Try
'			#End Region

'			#Region "MyWin32process.ExecutionState"
			Try
				MyWin32process.ExecutionState = DirectCast(result("ExecutionState"), UInt16)
			Catch e9 As NullReferenceException
				MyWin32process.ExecutionState = 0
			End Try
'			#End Region

'			#Region "MyWin32process.Handle"
			Try
				MyWin32process.Handle = DirectCast(result("Handle"), String)
			Catch e10 As NullReferenceException
				MyWin32process.Handle = ""
			End Try
'			#End Region

'			#Region "MyWin32process.HandleCount"
			Try
				MyWin32process.HandleCount = DirectCast(result("HandleCount"), UInt32)
			Catch e11 As NullReferenceException
				MyWin32process.HandleCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.InstallDate"
			Try
				MyWin32process.InstallDate = DirectCast(result("InstallDate"), Date)
			Catch e12 As NullReferenceException
				MyWin32process.InstallDate = Date.Parse("01-01-0001")
			End Try
'			#End Region

'			#Region "MyWin32process.KernelModeTime"
			Try
				MyWin32process.KernelModeTime = DirectCast(result("KernelModeTime"), UInt64)
			Catch e13 As NullReferenceException
				MyWin32process.KernelModeTime = 0
			End Try
'			#End Region

'			#Region "MyWin32process.MaximumWorkingSetSize"
			Try
				MyWin32process.MaximumWorkingSetSize = DirectCast(result("MaximumWorkingSetSize"), UInt32)
			Catch e14 As NullReferenceException
				MyWin32process.MaximumWorkingSetSize = 0
			End Try
'			#End Region

'			#Region "MyWin32process.MinimumWorkingSetSize"
			Try
				MyWin32process.MinimumWorkingSetSize = DirectCast(result("MinimumWorkingSetSize"), UInt32)
			Catch e15 As NullReferenceException
				MyWin32process.MinimumWorkingSetSize = 0
			End Try
'			#End Region

'			#Region " MyWin32process.Name"
			Try
				MyWin32process.Name = DirectCast(result("Name"), String)
			Catch e16 As NullReferenceException
				MyWin32process.Name = ""
			End Try
'			#End Region

'			#Region "MyWin32process.OSCreationClassName"
			Try
				MyWin32process.OSCreationClassName = DirectCast(result("OSCreationClassName"), String)
			Catch e17 As NullReferenceException
				MyWin32process.OSCreationClassName = ""
			End Try
'			#End Region

'			#Region "MyWin32process.OSName"
			Try
				MyWin32process.OSName = DirectCast(result("OSName"), String)
			Catch e18 As NullReferenceException
				MyWin32process.OSName = ""
			End Try
'			#End Region

'			#Region "MyWin32process.OtherOperationCount"
			Try
				MyWin32process.OtherOperationCount = DirectCast(result("OtherOperationCount"), UInt64)
			Catch e19 As NullReferenceException
				MyWin32process.OtherOperationCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.OtherTransferCount"
			Try
				MyWin32process.OtherTransferCount = DirectCast(result("OtherTransferCount"), UInt64)
			Catch e20 As NullReferenceException
				MyWin32process.OtherTransferCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PageFaults"
			Try
				MyWin32process.PageFaults = DirectCast(result("PageFaults"), UInt32)
			Catch e21 As NullReferenceException
				MyWin32process.PageFaults = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PageFileUsage"
			Try
				MyWin32process.PageFileUsage = DirectCast(result("PageFileUsage"), UInt32)
			Catch e22 As NullReferenceException
				MyWin32process.PageFileUsage = 0
			End Try
'			#End Region

'			#Region "MyWin32process.ParentProcessId   Maybe problems with Null default value !!"
			Try
				MyWin32process.ParentProcessId = DirectCast(result("ParentProcessId"), UInt32)
			Catch e23 As NullReferenceException
				MyWin32process.ParentProcessId = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PeakPageFileUsage"
			Try
				MyWin32process.PeakPageFileUsage = DirectCast(result("PeakPageFileUsage"), UInt32)
			Catch e24 As NullReferenceException
				MyWin32process.PeakPageFileUsage = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PeakVirtualSize"
			Try
				MyWin32process.PeakVirtualSize = DirectCast(result("PeakVirtualSize"), UInt64)
			Catch e25 As NullReferenceException
				MyWin32process.PeakVirtualSize = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PeakWorkingSetSize"
			Try
				MyWin32process.PeakWorkingSetSize = DirectCast(result("PeakWorkingSetSize"), UInt32)
			Catch e26 As NullReferenceException
				MyWin32process.PeakWorkingSetSize = 0
			End Try
'			#End Region

'			#Region "MyWin32process.Priority  Maybe problems with Null default value !!"
			Try
				MyWin32process.Priority = DirectCast(result("Priority"), UInt32)
			Catch e27 As NullReferenceException
				MyWin32process.Priority = 0
			End Try
'			#End Region

'			#Region "MyWin32process.PrivatePageCount"
			Try
				MyWin32process.PrivatePageCount = DirectCast(result("PrivatePageCount"), UInt64)
			Catch e28 As NullReferenceException
				MyWin32process.PrivatePageCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.ProcessId Maybe problems with Null default value !!"
			Try
				MyWin32process.ProcessId = DirectCast(result("ProcessId"), UInt32)
			Catch e29 As NullReferenceException
				MyWin32process.ProcessId = 0
			End Try
'			#End Region

'			#Region "MyWin32process.QuotaNonPagedPoolUsage"
			Try
				MyWin32process.QuotaNonPagedPoolUsage = DirectCast(result("QuotaNonPagedPoolUsage"), UInt32)
			Catch e30 As NullReferenceException
				MyWin32process.QuotaNonPagedPoolUsage = 0
			End Try
'			#End Region

'			#Region "MyWin32process.QuotaPagedPoolUsage"
			Try
				MyWin32process.QuotaPagedPoolUsage = DirectCast(result("QuotaPagedPoolUsage"), UInt32)
			Catch e31 As NullReferenceException
				MyWin32process.QuotaPagedPoolUsage = 0
			End Try
'			#End Region

'			#Region "MyWin32process.QuotaPeakNonPagedPoolUsage"
			Try
				MyWin32process.QuotaPeakNonPagedPoolUsage = DirectCast(result("QuotaPeakNonPagedPoolUsage"), UInt32)
			Catch e32 As NullReferenceException
				MyWin32process.QuotaPeakNonPagedPoolUsage = 0
			End Try
'			#End Region

'			#Region " MyWin32process.QuotaPeakPagedPoolUsage"
			Try
				MyWin32process.QuotaPeakPagedPoolUsage = DirectCast(result("QuotaPeakPagedPoolUsage"), UInt32)
			Catch e33 As NullReferenceException
				MyWin32process.QuotaPeakPagedPoolUsage = 0
			End Try
'			#End Region

'			#Region "MyWin32process.ReadOperationCount"
			Try
				MyWin32process.ReadOperationCount = DirectCast(result("ReadOperationCount"), UInt64)
			Catch e34 As NullReferenceException
				MyWin32process.ReadOperationCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.ReadTransferCount"
			Try
				MyWin32process.ReadTransferCount = DirectCast(result("ReadTransferCount"), UInt64)
			Catch e35 As NullReferenceException
				MyWin32process.ReadTransferCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.SessionId"
			Try
				MyWin32process.SessionId = DirectCast(result("SessionId"), UInt32)
			Catch e36 As NullReferenceException
				MyWin32process.SessionId = 0
			End Try
'			#End Region

'			#Region "MyWin32process.Status"
			Try
				MyWin32process.Status = DirectCast(result("Status"), String)
			Catch e37 As NullReferenceException
				MyWin32process.Status = ""
			End Try
'			#End Region

'			#Region "MyWin32process.TerminationDate"
			Try
				MyWin32process.TerminationDate = DirectCast(result("TerminationDate"), Date)
			Catch e38 As NullReferenceException
				MyWin32process.TerminationDate = Date.Parse("01-01-0001")
			End Try
'			#End Region

'			#Region " MyWin32process.ThreadCount"
			Try
				MyWin32process.ThreadCount = DirectCast(result("ThreadCount"), UInt32)
			Catch e39 As NullReferenceException
				MyWin32process.ThreadCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.UserModeTime"
			Try
				MyWin32process.UserModeTime = DirectCast(result("UserModeTime"), UInt64)
			Catch e40 As NullReferenceException
				MyWin32process.UserModeTime = 0
			End Try
'			#End Region

'			#Region "MyWin32process.VirtualSize"
			Try
				MyWin32process.VirtualSize = DirectCast(result("VirtualSize"), UInt64)
			Catch e41 As NullReferenceException
				MyWin32process.VirtualSize = 0
			End Try
'			#End Region

'			#Region " MyWin32process.WindowsVersion"
			Try
				MyWin32process.WindowsVersion = DirectCast(result("WindowsVersion"), String)
			Catch e42 As NullReferenceException
				MyWin32process.WindowsVersion = ""
			End Try
'			#End Region

'			#Region "MyWin32process.WorkingSetSize"
			Try
				MyWin32process.WorkingSetSize = DirectCast(result("WorkingSetSize"), UInt64)
			Catch e43 As NullReferenceException
				MyWin32process.WorkingSetSize = 0
			End Try
'			#End Region

'			#Region "MyWin32process.WriteOperationCount"
			Try
				MyWin32process.WriteOperationCount = DirectCast(result("WriteOperationCount"), UInt64)
			Catch e44 As NullReferenceException
				MyWin32process.WriteOperationCount = 0
			End Try
'			#End Region

'			#Region "MyWin32process.WriteTransferCount"
			Try
				MyWin32process.WriteTransferCount = DirectCast(result("WriteTransferCount"), UInt64)
			Catch e45 As NullReferenceException
				MyWin32process.WriteTransferCount = 0
			End Try
'			#End Region

			Return MyWin32process
		End Function
	End Class

	Public Class Win32Service
		Public Property AcceptPause() As Boolean
		Public Property AcceptStop() As Boolean
		Public Property Caption() As String
		Public Property CheckPoint() As UInt32
		Public Property CreationClassName() As String
		Public Property Description() As String
		Public Property DesktopInteract() As Boolean
		Public Property DisplayName() As String
		Public Property ErrorControl() As String
		Public Property ExitCode() As UInt32
		Public Property InstallDate() As Date
		Public Property Name() As String
		Public Property PathName() As String
		Public Property ProcessId() As UInt32
		Public Property ServiceSpecificExitCode() As UInt32
		Public Property ServiceType() As String
		Public Property Started() As Boolean
		Public Property StartMode() As String
		Public Property StartName() As String
		Public Property State() As String
		Public Property Status() As String
		Public Property SystemCreationClassName() As String
		Public Property SystemName() As String
		Public Property TagId() As UInt32
		Public Property WaitHint() As UInt32

	End Class

	Public Class Win32Process
		''' <summary>
		''' <para>Data type: string</para>
		''' <para>Short description of an object—a one-line string.</para>
		''' </summary>
		Public Property Caption() As String

		''' <summary>
		''' <para>Data type: string</para>
		''' <para>Command line used to start a specific process, if applicable. This property is new for Windows XP.</para>
		''' </summary>
		Public Property CommandLine() As String

		''' <summary>
		''' <para >Data type: string</para>
		''' <para>Qualifiers: Key, MaxLen(256)</para>
		''' <para>Name of the first concrete class in the inheritance chain that is used to create an instance. You can use this property with other key properties of the class to uniquely identify all of the instances of the class and its subclasses. This property is inherited from CIM_System.</para>
		''' </summary>
		Public Property CreationClassName() As String

		''' <summary>
		''' <para>Data type: datetime</para>
		''' <para>Date the process begins executing.</para>
		''' </summary>
		Public Property CreationDate() As String

		''' <summary>
		''' <para>Data type: string</para>
		''' <para>Creation class name of the scoping computer system.</para>
		''' </summary>
		Public Property CSCreationClassName() As String

		Public Property CSName() As String
		Public Property Description() As String
		Public Property ExecutablePath() As String
		Public Property ExecutionState() As UInt16
		Public Property Handle() As String
		Public Property HandleCount() As UInt32
		Public Property InstallDate() As Date
		Public Property KernelModeTime() As UInt64
		Public Property MaximumWorkingSetSize() As UInt32
		Public Property MinimumWorkingSetSize() As UInt32
		Public Property Name() As String
		Public Property OSCreationClassName() As String
		Public Property OSName() As String
		Public Property OtherOperationCount() As UInt64
		Public Property OtherTransferCount() As UInt64
		Public Property PageFaults() As UInt32
		Public Property PageFileUsage() As UInt32
		Public Property ParentProcessId() As UInt32
		Public Property PeakPageFileUsage() As UInt32
		Public Property PeakVirtualSize() As UInt64
		Public Property PeakWorkingSetSize() As UInt32
		Public Property Priority() As UInt32
		Public Property PrivatePageCount() As UInt64
		Public Property ProcessId() As UInt32
		Public Property QuotaNonPagedPoolUsage() As UInt32
		Public Property QuotaPagedPoolUsage() As UInt32
		Public Property QuotaPeakNonPagedPoolUsage() As UInt32
		Public Property QuotaPeakPagedPoolUsage() As UInt32
		Public Property ReadOperationCount() As UInt64
		Public Property ReadTransferCount() As UInt64
		Public Property SessionId() As UInt32
		Public Property Status() As String
		Public Property TerminationDate() As Date
		Public Property ThreadCount() As UInt32
		Public Property UserModeTime() As UInt64
		Public Property VirtualSize() As UInt64
		Public Property WindowsVersion() As String
		Public Property WorkingSetSize() As UInt64
		Public Property WriteOperationCount() As UInt64
		Public Property WriteTransferCount() As UInt64


	End Class
End Namespace