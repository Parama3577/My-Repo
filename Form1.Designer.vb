<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GoToScreenshotsFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScreenshotsCapturePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PromptForCaptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteScreenshotsOnCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FeedbackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button4 = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoToScreenshotsFolderToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.ToolStripMenuItem1.Text = "Tools"
        '
        'GoToScreenshotsFolderToolStripMenuItem
        '
        Me.GoToScreenshotsFolderToolStripMenuItem.Name = "GoToScreenshotsFolderToolStripMenuItem"
        Me.GoToScreenshotsFolderToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.GoToScreenshotsFolderToolStripMenuItem.Text = "Go to Screenshots Folder..."
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScreenshotsCapturePathToolStripMenuItem, Me.PromptForCaptionsToolStripMenuItem, Me.ShowTimestampBelowScreenshotsToolStripMenuItem, Me.DeleteScreenshotsOnCloseToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ToolsToolStripMenuItem.Text = "Settings"
        '
        'ScreenshotsCapturePathToolStripMenuItem
        '
        Me.ScreenshotsCapturePathToolStripMenuItem.Name = "ScreenshotsCapturePathToolStripMenuItem"
        Me.ScreenshotsCapturePathToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ScreenshotsCapturePathToolStripMenuItem.Text = "Choose Screenshots Capture Path..."
        '
        'PromptForCaptionsToolStripMenuItem
        '
        Me.PromptForCaptionsToolStripMenuItem.Checked = True
        Me.PromptForCaptionsToolStripMenuItem.CheckOnClick = True
        Me.PromptForCaptionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PromptForCaptionsToolStripMenuItem.Name = "PromptForCaptionsToolStripMenuItem"
        Me.PromptForCaptionsToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.PromptForCaptionsToolStripMenuItem.Text = "Prompt For Captions After Each Screenshot..."
        '
        'ShowTimestampBelowScreenshotsToolStripMenuItem
        '
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.Checked = True
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.CheckOnClick = True
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.Name = "ShowTimestampBelowScreenshotsToolStripMenuItem"
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ShowTimestampBelowScreenshotsToolStripMenuItem.Text = "Show Timestamp Below Screenshots..."
        '
        'DeleteScreenshotsOnCloseToolStripMenuItem
        '
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.Checked = True
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.CheckOnClick = True
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.Name = "DeleteScreenshotsOnCloseToolStripMenuItem"
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.DeleteScreenshotsOnCloseToolStripMenuItem.Text = "Delete Screenshots on Application Close..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FeedbackToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.HelpToolStripMenuItem.Text = "About"
        '
        'FeedbackToolStripMenuItem
        '
        Me.FeedbackToolStripMenuItem.Name = "FeedbackToolStripMenuItem"
        Me.FeedbackToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FeedbackToolStripMenuItem.Text = "Feedback"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(12, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 60)
        Me.Button1.TabIndex = 1
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.Button1, "Click to Capture Screen")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.Screen2Doc.My.Resources.Resources.oDoc
        Me.Button2.Location = New System.Drawing.Point(78, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 60)
        Me.Button2.TabIndex = 2
        Me.ToolTip2.SetToolTip(Me.Button2, "Create Word Doc from Screenshots")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.Screen2Doc.My.Resources.Resources.oMail
        Me.Button3.Location = New System.Drawing.Point(144, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 60)
        Me.Button3.TabIndex = 3
        Me.ToolTip3.SetToolTip(Me.Button3, "Generate e-Mail from Screenshots")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.Screen2Doc.My.Resources.Resources.oRedo
        Me.Button4.Location = New System.Drawing.Point(210, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(60, 60)
        Me.Button4.TabIndex = 4
        Me.ToolTip4.SetToolTip(Me.Button4, "Reset Application")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(284, 94)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeedbackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScreenshotsCapturePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PromptForCaptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowTimestampBelowScreenshotsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteScreenshotsOnCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToScreenshotsFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
