Namespace Svchost_Viewer_Ver1
	Partial Public Class Form1
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

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.treeView1 = New System.Windows.Forms.TreeView()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.panel1_svchost_Process = New System.Windows.Forms.Panel()
			Me.Panel1_groupBox2 = New System.Windows.Forms.GroupBox()
			Me.Status_mode_txt = New System.Windows.Forms.Label()
			Me.service_name_txt = New System.Windows.Forms.Label()
			Me.Start_mode_txt = New System.Windows.Forms.Label()
			Me.Service_Type_txt = New System.Windows.Forms.Label()
			Me.service_stopped_checkbox = New System.Windows.Forms.CheckBox()
			Me.service_pause_checkbox = New System.Windows.Forms.CheckBox()
			Me.Description_Label1 = New System.Windows.Forms.Label()
			Me.ServiceInformation_richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.Panel1_groupBox1 = New System.Windows.Forms.GroupBox()
			Me.processInformation_richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.serviceControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.stopSelectServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.windowsServiceManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.generateReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.toolStripTextLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
			Me.panel1_svchost_Process.SuspendLayout()
			Me.Panel1_groupBox2.SuspendLayout()
			Me.Panel1_groupBox1.SuspendLayout()
			Me.menuStrip1.SuspendLayout()
			Me.statusStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' treeView1
			' 
			Me.treeView1.BackColor = System.Drawing.SystemColors.ControlLightLight
			Me.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.treeView1.ForeColor = System.Drawing.SystemColors.ControlText
			Me.treeView1.ImageIndex = 1
			Me.treeView1.ImageList = Me.imageList1
			Me.treeView1.Location = New System.Drawing.Point(0, 27)
			Me.treeView1.Name = "treeView1"
			Me.treeView1.SelectedImageIndex = 0
			Me.treeView1.ShowPlusMinus = False
			Me.treeView1.ShowRootLines = False
			Me.treeView1.Size = New System.Drawing.Size(209, 343)
			Me.treeView1.TabIndex = 6
'			Me.treeView1.BeforeCollapse += New System.Windows.Forms.TreeViewCancelEventHandler(Me.treeView1_BeforeCollapse)
'			Me.treeView1.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeView1_AfterSelect)
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (DirectCast(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			Me.imageList1.Images.SetKeyName(0, "shell1.ico")
			Me.imageList1.Images.SetKeyName(1, "user1.ico")
			' 
			' panel1_svchost_Process
			' 
			Me.panel1_svchost_Process.BackColor = System.Drawing.SystemColors.Control
			Me.panel1_svchost_Process.Controls.Add(Me.Panel1_groupBox2)
			Me.panel1_svchost_Process.Controls.Add(Me.Panel1_groupBox1)
			Me.panel1_svchost_Process.Location = New System.Drawing.Point(215, 27)
			Me.panel1_svchost_Process.Name = "panel1_svchost_Process"
			Me.panel1_svchost_Process.Size = New System.Drawing.Size(459, 343)
			Me.panel1_svchost_Process.TabIndex = 7
			' 
			' Panel1_groupBox2
			' 
			Me.Panel1_groupBox2.Controls.Add(Me.Status_mode_txt)
			Me.Panel1_groupBox2.Controls.Add(Me.service_name_txt)
			Me.Panel1_groupBox2.Controls.Add(Me.Start_mode_txt)
			Me.Panel1_groupBox2.Controls.Add(Me.Service_Type_txt)
			Me.Panel1_groupBox2.Controls.Add(Me.service_stopped_checkbox)
			Me.Panel1_groupBox2.Controls.Add(Me.service_pause_checkbox)
			Me.Panel1_groupBox2.Controls.Add(Me.Description_Label1)
			Me.Panel1_groupBox2.Controls.Add(Me.ServiceInformation_richTextBox1)
			Me.Panel1_groupBox2.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Panel1_groupBox2.Location = New System.Drawing.Point(6, 83)
			Me.Panel1_groupBox2.Name = "Panel1_groupBox2"
			Me.Panel1_groupBox2.Size = New System.Drawing.Size(446, 258)
			Me.Panel1_groupBox2.TabIndex = 4
			Me.Panel1_groupBox2.TabStop = False
			Me.Panel1_groupBox2.Text = "Service Information :"
			' 
			' Status_mode_txt
			' 
			Me.Status_mode_txt.AutoSize = True
			Me.Status_mode_txt.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Status_mode_txt.Location = New System.Drawing.Point(45, 67)
			Me.Status_mode_txt.Name = "Status_mode_txt"
			Me.Status_mode_txt.Size = New System.Drawing.Size(43, 13)
			Me.Status_mode_txt.TabIndex = 18
			Me.Status_mode_txt.Text = "Status :"
			' 
			' service_name_txt
			' 
			Me.service_name_txt.AutoSize = True
			Me.service_name_txt.ForeColor = System.Drawing.SystemColors.ControlText
			Me.service_name_txt.Location = New System.Drawing.Point(47, 16)
			Me.service_name_txt.Name = "service_name_txt"
			Me.service_name_txt.Size = New System.Drawing.Size(41, 13)
			Me.service_name_txt.TabIndex = 16
			Me.service_name_txt.Text = "Name :"
			' 
			' Start_mode_txt
			' 
			Me.Start_mode_txt.AutoSize = True
			Me.Start_mode_txt.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Start_mode_txt.Location = New System.Drawing.Point(24, 50)
			Me.Start_mode_txt.Name = "Start_mode_txt"
			Me.Start_mode_txt.Size = New System.Drawing.Size(64, 13)
			Me.Start_mode_txt.TabIndex = 15
			Me.Start_mode_txt.Text = "Start mode :"
			' 
			' Service_Type_txt
			' 
			Me.Service_Type_txt.AutoSize = True
			Me.Service_Type_txt.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Service_Type_txt.Location = New System.Drawing.Point(12, 33)
			Me.Service_Type_txt.Name = "Service_Type_txt"
			Me.Service_Type_txt.Size = New System.Drawing.Size(76, 13)
			Me.Service_Type_txt.TabIndex = 14
			Me.Service_Type_txt.Text = "Service Type :"
			' 
			' service_stopped_checkbox
			' 
			Me.service_stopped_checkbox.AutoCheck = False
			Me.service_stopped_checkbox.AutoSize = True
			Me.service_stopped_checkbox.ForeColor = System.Drawing.SystemColors.ControlText
			Me.service_stopped_checkbox.Location = New System.Drawing.Point(290, 32)
			Me.service_stopped_checkbox.Name = "service_stopped_checkbox"
			Me.service_stopped_checkbox.Size = New System.Drawing.Size(142, 17)
			Me.service_stopped_checkbox.TabIndex = 13
			Me.service_stopped_checkbox.TabStop = False
			Me.service_stopped_checkbox.Text = "Service can be stopped."
			Me.service_stopped_checkbox.UseVisualStyleBackColor = True
			' 
			' service_pause_checkbox
			' 
			Me.service_pause_checkbox.AutoCheck = False
			Me.service_pause_checkbox.AutoSize = True
			Me.service_pause_checkbox.ForeColor = System.Drawing.SystemColors.ControlText
			Me.service_pause_checkbox.Location = New System.Drawing.Point(290, 15)
			Me.service_pause_checkbox.Name = "service_pause_checkbox"
			Me.service_pause_checkbox.Size = New System.Drawing.Size(139, 17)
			Me.service_pause_checkbox.TabIndex = 12
			Me.service_pause_checkbox.TabStop = False
			Me.service_pause_checkbox.Text = "Service can be paused."
			Me.service_pause_checkbox.UseVisualStyleBackColor = True
			' 
			' Description_Label1
			' 
			Me.Description_Label1.AutoSize = True
			Me.Description_Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.Description_Label1.Location = New System.Drawing.Point(9, 88)
			Me.Description_Label1.Name = "Description_Label1"
			Me.Description_Label1.Size = New System.Drawing.Size(79, 13)
			Me.Description_Label1.TabIndex = 1
			Me.Description_Label1.Text = "Description :"
			' 
			' ServiceInformation_richTextBox1
			' 
			Me.ServiceInformation_richTextBox1.BackColor = System.Drawing.SystemColors.Control
			Me.ServiceInformation_richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.ServiceInformation_richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow
			Me.ServiceInformation_richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText
			Me.ServiceInformation_richTextBox1.Location = New System.Drawing.Point(6, 104)
			Me.ServiceInformation_richTextBox1.Name = "ServiceInformation_richTextBox1"
			Me.ServiceInformation_richTextBox1.ReadOnly = True
			Me.ServiceInformation_richTextBox1.Size = New System.Drawing.Size(434, 148)
			Me.ServiceInformation_richTextBox1.TabIndex = 0
			Me.ServiceInformation_richTextBox1.Text = ""
			' 
			' Panel1_groupBox1
			' 
			Me.Panel1_groupBox1.Controls.Add(Me.processInformation_richTextBox1)
			Me.Panel1_groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.Panel1_groupBox1.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Panel1_groupBox1.Location = New System.Drawing.Point(6, 3)
			Me.Panel1_groupBox1.Name = "Panel1_groupBox1"
			Me.Panel1_groupBox1.Size = New System.Drawing.Size(446, 74)
			Me.Panel1_groupBox1.TabIndex = 3
			Me.Panel1_groupBox1.TabStop = False
			Me.Panel1_groupBox1.Text = "Svchost Information :"
			' 
			' processInformation_richTextBox1
			' 
			Me.processInformation_richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.processInformation_richTextBox1.Location = New System.Drawing.Point(12, 17)
			Me.processInformation_richTextBox1.Name = "processInformation_richTextBox1"
			Me.processInformation_richTextBox1.ReadOnly = True
			Me.processInformation_richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
			Me.processInformation_richTextBox1.Size = New System.Drawing.Size(428, 51)
			Me.processInformation_richTextBox1.TabIndex = 3
			Me.processInformation_richTextBox1.Text = ""
			Me.processInformation_richTextBox1.WordWrap = False
			' 
			' timer1
			' 
'			Me.timer1.Tick += New System.EventHandler(Me.timer1_Tick)
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.refreshToolStripMenuItem, Me.serviceControlToolStripMenuItem, Me.toolsToolStripMenuItem, Me.aboutToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
			Me.menuStrip1.Size = New System.Drawing.Size(676, 24)
			Me.menuStrip1.TabIndex = 8
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' refreshToolStripMenuItem
			' 
			Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
			Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
			Me.refreshToolStripMenuItem.Text = "Refresh"
'			Me.refreshToolStripMenuItem.Click += New System.EventHandler(Me.refreshToolStripMenuItem_Click)
			' 
			' serviceControlToolStripMenuItem
			' 
			Me.serviceControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.stopSelectServiceToolStripMenuItem})
			Me.serviceControlToolStripMenuItem.Name = "serviceControlToolStripMenuItem"
			Me.serviceControlToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
			Me.serviceControlToolStripMenuItem.Text = "Service control"
'			Me.serviceControlToolStripMenuItem.DropDownOpening += New System.EventHandler(Me.serviceControlToolStripMenuItem_DropDownOpening)
			' 
			' stopSelectServiceToolStripMenuItem
			' 
			Me.stopSelectServiceToolStripMenuItem.Name = "stopSelectServiceToolStripMenuItem"
			Me.stopSelectServiceToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
			Me.stopSelectServiceToolStripMenuItem.Text = "Stop Selected Service"
'			Me.stopSelectServiceToolStripMenuItem.Click += New System.EventHandler(Me.stopSelectServiceToolStripMenuItem_Click)
			' 
			' toolsToolStripMenuItem
			' 
			Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.windowsServiceManagerToolStripMenuItem, Me.generateReportToolStripMenuItem})
			Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
			Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
			Me.toolsToolStripMenuItem.Text = "Tools"
			' 
			' windowsServiceManagerToolStripMenuItem
			' 
			Me.windowsServiceManagerToolStripMenuItem.Name = "windowsServiceManagerToolStripMenuItem"
			Me.windowsServiceManagerToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
			Me.windowsServiceManagerToolStripMenuItem.Text = "Windows Service Manager"
'			Me.windowsServiceManagerToolStripMenuItem.Click += New System.EventHandler(Me.windowsServiceManagerToolStripMenuItem_Click)
			' 
			' generateReportToolStripMenuItem
			' 
			Me.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem"
			Me.generateReportToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
			Me.generateReportToolStripMenuItem.Text = "Generate Report"
'			Me.generateReportToolStripMenuItem.Click += New System.EventHandler(Me.generateReportToolStripMenuItem_Click)
			' 
			' aboutToolStripMenuItem
			' 
			Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
			Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
			Me.aboutToolStripMenuItem.Text = "About"
'			Me.aboutToolStripMenuItem.Click += New System.EventHandler(Me.aboutToolStripMenuItem_Click)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripTextLabel1, Me.toolStripProgressBar1})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 373)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(676, 22)
			Me.statusStrip1.TabIndex = 9
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' toolStripTextLabel1
			' 
			Me.toolStripTextLabel1.Name = "toolStripTextLabel1"
			Me.toolStripTextLabel1.Size = New System.Drawing.Size(10, 17)
			Me.toolStripTextLabel1.Text = "."
			' 
			' toolStripProgressBar1
			' 
			Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
			Me.toolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
			Me.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
			Me.toolStripProgressBar1.Visible = False
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.SystemColors.Control
			Me.ClientSize = New System.Drawing.Size(676, 395)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.panel1_svchost_Process)
			Me.Controls.Add(Me.treeView1)
			Me.Controls.Add(Me.menuStrip1)
			Me.Cursor = System.Windows.Forms.Cursors.Default
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MainMenuStrip = Me.menuStrip1
			Me.MaximizeBox = False
			Me.Name = "Form1"
			Me.Text = "Svchost Viewer"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.Form1_FormClosing)
			Me.panel1_svchost_Process.ResumeLayout(False)
			Me.Panel1_groupBox2.ResumeLayout(False)
			Me.Panel1_groupBox2.PerformLayout()
			Me.Panel1_groupBox1.ResumeLayout(False)
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents treeView1 As System.Windows.Forms.TreeView
		Private panel1_svchost_Process As System.Windows.Forms.Panel
		Private Panel1_groupBox1 As System.Windows.Forms.GroupBox
		Private Panel1_groupBox2 As System.Windows.Forms.GroupBox
		Private ServiceInformation_richTextBox1 As System.Windows.Forms.RichTextBox
		Private Description_Label1 As System.Windows.Forms.Label
		Private Status_mode_txt As System.Windows.Forms.Label
		Private service_name_txt As System.Windows.Forms.Label
		Private Start_mode_txt As System.Windows.Forms.Label
		Private Service_Type_txt As System.Windows.Forms.Label
		Private service_stopped_checkbox As System.Windows.Forms.CheckBox
		Private service_pause_checkbox As System.Windows.Forms.CheckBox
		Private processInformation_richTextBox1 As System.Windows.Forms.RichTextBox
		Private imageList1 As System.Windows.Forms.ImageList
		Private WithEvents timer1 As System.Windows.Forms.Timer
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private WithEvents refreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripTextLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
		Private WithEvents serviceControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents stopSelectServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents windowsServiceManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents generateReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	End Class
End Namespace

