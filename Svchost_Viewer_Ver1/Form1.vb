Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports System.ServiceProcess
Imports System.IO
Imports System.Management

Namespace Svchost_Viewer_Ver1
	Partial Public Class Form1
		Inherits Form

		Private txt1 As String = "You need to run the application with administrator privileges" & ControlChars.Lf & "to use these functions." & ControlChars.Lf & ControlChars.Lf & " Do you want to do this now ??"
		Private txt2 As String = "Notice"
		Private txt3 As String = "Are you sure, you want to close this service ??" & ControlChars.Lf & ControlChars.Lf & "Doing so, may lead to your computer, not running" & ControlChars.Lf & "as you intended it to." & ControlChars.Lf & ControlChars.Lf & "NOTE:" & ControlChars.Lf & "The service might only be closed, until your next reboot." & ControlChars.Lf & "If you want to make sure is stays closed, please use the" & ControlChars.Lf & "Windows service Manager."
		Private txt4 As String = "Something went wrong, look below to find out what:" & ControlChars.Lf
		Private txt5 As String = "Error"
		Private txt6 As String = "The selected service can't be stopped"
		Private txt7 As String = "Getting Information :"
		'String txt8 = "Done in : ";
		Private txt9 As String = "You have "
		Private txt10 As String = " svchost(s) running a total of "
		Private txt11 As String = " services."

		Private proCount As Integer = 0
		Private serCount As Integer = 0

		Private mylist As New List(Of TreeNode_Collection)()

		Public Sub New()
			InitializeComponent()

				If Not VistaSecurity.IsAdmin() Then
					'Not runing as admin
					serviceControlToolStripMenuItem.Image = My.Resources.user32_106.ToBitmap()
					windowsServiceManagerToolStripMenuItem.Image = My.Resources.user32_106.ToBitmap()
					DisableServiceControlles(True)
				Else
					'Runing as admin
					Me.Text &= " (Administrator)"
				End If
		End Sub

		'Main start method::::::::::.............
		Private Sub Run()
			refreshToolStripMenuItem.Enabled = False
			toolStripTextLabel1.Text = ("Done in : " & FetchDataHandler().ToString())

			If treeView1.Nodes.Count <> 0 Then
				treeView1.ExpandAll()

				treeView1.SelectedNode = treeView1.Nodes(0)
			End If

			proCount = 0
			serCount = 0

			For Each x As TreeNode In treeView1.Nodes
				proCount += 1

				For Each y As TreeNode In x.Nodes
					serCount += 1
				Next y
			Next x

			refreshToolStripMenuItem.Enabled = True

			If proCount <> 0 Then
				toolStripTextLabel1.Text = (txt9 & proCount & txt10 & serCount & txt11)
			Else
				toolStripTextLabel1.Text = ("Svchost viewer could not find any running services.")
			End If
		End Sub


		'Data fetching::::::::::::::::....................
		Private Function FetchDataHandler() As TimeSpan
			Dim TotalTime As TimeSpan

			'Get the Start time.....
			Dim mySW As New System.Diagnostics.Stopwatch()
			mySW.Start()

			'Reset program for refresh.
			mylist.Clear()
			treeView1.Nodes.Clear()

			'Make background thread, to get svchost data.
			Dim myBGW As New BackgroundWorker()
			AddHandler myBGW.DoWork, AddressOf FetchData
			myBGW.RunWorkerAsync()

			Try
				toolStripProgressBar1.Visible = True
				toolStripTextLabel1.Text = txt7

				Do While myBGW.IsBusy
					Application.DoEvents()
				Loop

				toolStripTextLabel1.Text = ""
				toolStripProgressBar1.Visible = False

				'Clean up::::::::::::::::::::::.............
				myBGW.Dispose()
				myBGW = Nothing

				FillTreeView(mylist)

				mySW.Stop() 'Stop the stopwatch....
			Catch e1 As Exception
				'If you closes the application before thread is done, program
				'will crash at "toolStripProgressBar1.Visible = true;" this is to stop that.
				'Shit-ty way of doing this, but it works

			Finally
				mySW.Stop()
			End Try

			TotalTime = (mySW.Elapsed)
			Return TotalTime
		End Function

		Private Sub FetchData(ByVal sender As Object, ByVal e As EventArgs)
			mylist = GetSerivceData()
		End Sub

		Private Function GetSerivceData() As List(Of TreeNode_Collection)
			Dim myServicesList As New List(Of TreeNode_Collection)()

			Dim mySvchostHandler As New GetSvchostInfoHandler()
			myServicesList = mySvchostHandler.GetData()

			Return myServicesList
		End Function


		'Display methods:::::::::::::::::::::::::........................
		''' <summary>
		''' Show the information for the process and the services it's running.  //Controller
		''' </summary>
		''' <param name="ParentIndex">Must by -1 if node has no parent</param>
		''' <param name="NodeIndex"></param>
		Private Sub ShowInformation(ByVal ParentIndex As Integer, ByVal NodeIndex As Integer)
			If ParentIndex <> -1 Then
				ShowProcessInformation(mylist(ParentIndex).myWin32Process)
				ShowServiceInformation(mylist(ParentIndex).myServiceList(NodeIndex))
			Else
				'Reset textlabels:::::::::::::::::::::::::..............
				ServiceInformation_richTextBox1.Clear()
				service_name_txt.Text = "Name : "
				Service_Type_txt.Text = "Service Type : "
				Start_mode_txt.Text = "Start mode : "
				Status_mode_txt.Text = "Status : "
				service_pause_checkbox.Checked = False
				service_stopped_checkbox.Checked = False


				ShowProcessInformation(mylist(NodeIndex).myWin32Process)
			End If
		End Sub

		Private Sub ShowServiceInformation(ByVal service As Win32Service)
			ServiceInformation_richTextBox1.Clear()
			ServiceInformation_richTextBox1.Text = (service.Name & " : " & ControlChars.Lf & service.Description)

			service_name_txt.Text = "Name : " & service.Name
			Service_Type_txt.Text = "Service Type : " & service.ServiceType
			Start_mode_txt.Text = "Start mode : " & service.StartMode
			Status_mode_txt.Text = "Status : " & service.Status

			'Service can be paused:::::::::::::::::::...........
			If service.AcceptPause Then
				service_pause_checkbox.Checked = True
			Else
				service_pause_checkbox.Checked = False
			End If

			'Service can be Stop::::::::::.......................
			If service.AcceptStop Then
				service_stopped_checkbox.Checked = True
			Else
				service_stopped_checkbox.Checked = False
			End If
		End Sub

		Private Sub ShowProcessInformation(ByVal myWin32Process As Win32Process)
			processInformation_richTextBox1.Clear()
			processInformation_richTextBox1.Text &= ("svchost.exe with process ID : " & myWin32Process.Handle.ToString() & " is using " & GetRightbytetype(myWin32Process.PageFileUsage.ToString()) & ControlChars.Lf & "Amount of data written : " & GetRightbytetype(myWin32Process.WriteTransferCount.ToString()) & ControlChars.Lf & "Amount of data read : " & GetRightbytetype(myWin32Process.ReadTransferCount.ToString()))
		End Sub

		Private Sub FillTreeView(ByVal Collection As List(Of TreeNode_Collection))

			Dim newNode As TreeNode
			Dim newServiceNode As TreeNode

			For Each x As TreeNode_Collection In Collection
				newNode = New TreeNode(x.myWin32Process.Name & " PID: " & x.myWin32Process.ProcessId)
				newNode.ImageIndex = 1
				newNode.SelectedImageIndex = 1

				For Each Services As Win32Service In x.myServiceList
					newServiceNode = New TreeNode(Services.Name)
					newServiceNode.ImageIndex = 0

					newNode.Nodes.Add(newServiceNode)
					newServiceNode = Nothing
				Next Services

				treeView1.Nodes.Add(newNode)
				newNode = Nothing
			Next x
		End Sub



		'Helper methods::::::::::::::::::::::::::::::::::::::...................
		Private Sub RemoveServiceNode(ByVal parent As Integer, ByVal nodeIndex As Integer)
			If mylist(parent).myServiceList.Count = 1 Then
				treeView1.Nodes(parent).Nodes(nodeIndex).Remove() 'Remove service from treeview.
				treeView1.Nodes(parent).Remove() 'Remove parent node from tree.

				mylist(parent).myServiceList.RemoveAt(nodeIndex) 'Remove service from internal array.
				mylist.Remove(mylist(parent)) 'Remove parent node from internal array, because there a no child nodes left.

				proCount -= 1
				serCount -= 1
			Else
				treeView1.Nodes(parent).Nodes(nodeIndex).Remove() 'Remove service from treeview.
				mylist(parent).myServiceList.RemoveAt(nodeIndex) 'Remove service from internal array.
				serCount -= 1
			End If

			toolStripTextLabel1.Text = (txt9 & proCount & txt10 & serCount & txt11)

		End Sub

		Private Sub StopService()
			If treeView1.SelectedNode Is Nothing OrElse treeView1.SelectedNode.Parent Is Nothing Then
				'Selection of a Parent node, or nothing.
				'do nothing....
			Else
				Dim myController As New ServiceController(treeView1.SelectedNode.Text)

				If myController.CanStop Then 'Check if service can be stopped
					If MessageBox.Show(txt3, txt2, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
						Try
							myController.Stop()
							RemoveServiceNode(treeView1.SelectedNode.Parent.Index, treeView1.SelectedNode.Index)
						Catch e As Exception
							MessageBox.Show(txt4 & e.Message, txt5, MessageBoxButtons.OK, MessageBoxIcon.Error)
						End Try
					End If

				Else
					MessageBox.Show(txt6, txt2, MessageBoxButtons.OK, MessageBoxIcon.Error)
				End If

				myController = Nothing
				'MessageBox.Show("Done....");
			End If
		End Sub

		Private Sub DisableServiceControlles(ByVal yes As Boolean)
			If yes Then
				stopSelectServiceToolStripMenuItem.Enabled = False
			Else
				stopSelectServiceToolStripMenuItem.Enabled = True
			End If
		End Sub

		''' <summary>
		''' When given a number of bytes in a string format it returns the rigth type
		''' f.x. the string "4569563136" would return as 4,25 GB.
		''' </summary>
		''' <param name="S">Bytes in String format i.e "4569563136"</param>
		''' <returns>returns as 4,25 GB</returns>
		Private Function GetRightbytetype(ByVal S As String) As String
			Dim x As Double = 0

			Try
				x = Convert.ToDouble(S)
			Catch e1 As Exception
				x = 0
			End Try

			If x < 1024 Then
				Return (x & " B")
			ElseIf (x / 1024) < 1024 Then
				x = Math.Round((x / 1024), 2)
				Return (x & " KB")
			ElseIf (x / 1024) / 1024 < 1024 Then
				x = Math.Round(((x / 1024) / 1024), 2)
				Return x & " MB"
			ElseIf (((x / 1024) / 1024) / 1024) < 1024 Then
				x = Math.Round((((x / 1024) / 1024) / 1024), 2)
				Return x & " GB"
			ElseIf ((((x / 1024) / 1024) / 1024) / 1024) < 1024 Then
				x = Math.Round(((((x / 1024) / 1024) / 1024) / 1024), 2)
				Return x & " TB"
			ElseIf (((((x / 1024) / 1024) / 1024) / 1024) / 1024) < 1024 Then
				x = Math.Round((((((x / 1024) / 1024) / 1024) / 1024) / 1024), 2)
				Return x & " PB"
			End If

			Return " "
		End Function

		Private Sub GenerateReport()
			If mylist.Count <> 0 Then
				Dim mySave As New SaveFileDialog()
				mySave.Filter = "Text file|*.txt"
				mySave.FilterIndex = 0
				mySave.AddExtension = True
				mySave.Title = "Save report as"

				If mySave.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					Dim WindowsVersion As String = ""

					Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
					For Each wmi_Windows As ManagementObject In searcher.Get()
					  WindowsVersion = wmi_Windows("Caption").ToString()
					Next wmi_Windows

					Dim mySW As New StreamWriter(mySave.FileName)

					mySW.WriteLine("Report generated on : " & Date.Now)
					mySW.WriteLine("OS : " & WindowsVersion)
					mySW.WriteLine("Services running on " & Environment.MachineName & " : ")
					mySW.WriteLine("-----------------------------------------------------")

					Dim processes As Integer = 0
					Dim services As Integer = 0

					For Each x As TreeNode_Collection In mylist
						For Each y As Win32Service In x.myServiceList
							mySW.WriteLine(y.Caption)
							services += 1
						Next y

						processes += 1
					Next x

					mySW.WriteLine("-----------------------------------------------------")
					mySW.WriteLine("System is running : " & services.ToString() & " service(s)" & ControlChars.Lf & " in a total of : " & processes.ToString() & " svchost.exe process(es)")

					mySW.Close()
					mySW = Nothing
					mySave = Nothing

					searcher = Nothing
				End If

			Else
				MessageBox.Show("No services found!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If

		End Sub




		'GUI Events::::::::::::::::::::::::::::::::::::::::::::::::::...........................................

		''' <summary>
		''' Call a Metode to show the information about the service or svchost program user selected.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub treeView1_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeView1.AfterSelect
			If e.Node.Parent Is Nothing Then
				'Selected Node is a root node.
				ShowInformation(-1, e.Node.Index)
			Else
				ShowInformation(e.Node.Parent.Index, e.Node.Index)
			End If
		End Sub

		Private Sub treeView1_BeforeCollapse(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles treeView1.BeforeCollapse
			e.Cancel = True 'Stops nodes from collapsing.
		End Sub

		Private Sub toolStripButton1_Refresh_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Run()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			'Easy way to start background thread, and still get Form1 to load completely.
			timer1.Enabled = True
		End Sub

		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			Application.Exit()
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
			timer1.Enabled = False

			Run()
		End Sub

		Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshToolStripMenuItem.Click
			Run()
		End Sub

		Private Sub stopSelectServiceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stopSelectServiceToolStripMenuItem.Click
			StopService()
		End Sub

		Private Sub serviceControlToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles serviceControlToolStripMenuItem.DropDownOpening
			If Not VistaSecurity.IsAdmin() Then
				serviceControlToolStripMenuItem.HideDropDown()
				DisableServiceControlles(True)
				If MessageBox.Show(txt1, txt2, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.Yes Then
					VistaSecurity.RestartElevated()
				End If
			Else

				If treeView1.SelectedNode IsNot Nothing Then
					If treeView1.SelectedNode.Parent Is Nothing Then
						DisableServiceControlles(True)
					Else
						DisableServiceControlles(False)
					End If
				Else
					DisableServiceControlles(True)
				End If
			End If
		End Sub

		Private Sub windowsServiceManagerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles windowsServiceManagerToolStripMenuItem.Click
			Try
				System.Diagnostics.Process.Start("services.msc", "runas")
			Catch e1 As Exception
				MessageBox.Show("Something want wrong :" & ControlChars.Lf & e1.Message,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning)
			End Try
		End Sub

		Private Sub generateReportToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles generateReportToolStripMenuItem.Click
			GenerateReport()
		End Sub

		Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
			Dim myAbout As New About()
			myAbout.ShowDialog()
		End Sub


	End Class
End Namespace
