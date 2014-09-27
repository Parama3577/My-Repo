Imports System.IO 'For file operations
Imports Word = Microsoft.Office.Interop.Word 'For microsoft word automation
Imports outlook = Microsoft.Office.Interop.Outlook 'For microsoft outlook automation


Public Class Form1

    Dim imgCaptureCounter As Integer
    Dim imgCaptions As New Hashtable
    Dim imgCaptureFolder As String
    Dim imgCaptureParentFolder As String
    Dim imgPromptForCaption As Boolean
    Dim imgDisplayTimestampWithScreenshots As Boolean
    Dim imgDltScrnshtsOnClose As Boolean
    Dim oIni As New IniFile
    Dim WithEvents hkM As HotkeyManager
    Dim configFile As String
    Dim docGenerated As Boolean = False
    Dim emailGenerated As Boolean = False

    Function getTimeStamp(Optional ByVal format As String = "yyyyMMdd") As String
        Dim theDate As DateTime = Now
        Dim ymd As String = theDate.ToString("yyyyMMdd")
        If format = "yyyyMMddhhmmss" Then
            ymd = theDate.ToString("yyyyMMddhhmmss")
        End If
        Return ymd
    End Function

    Function getApplicationTitle() As String
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Return ApplicationTitle
    End Function

    Function getApplicationConfigs() As Hashtable
        Dim config As New Hashtable
        If Not File.Exists(configFile) Then
            setApplicationConfigs(Application.StartupPath)
        End If
        oIni.Load(configFile)
        config.Add("ImgCaptureParentPath", oIni.GetKeyValue("SYSTEM_GLOBALS", "ImgCaptureParentPath"))
        config.Add("PromptForCaption", oIni.GetKeyValue("SYSTEM_GLOBALS", "PromptForCaption"))
        config.Add("DeleteScreenshotsOnClose", oIni.GetKeyValue("SYSTEM_GLOBALS", "DeleteScreenshotsOnClose"))
        config.Add("DisplayTimestampUnderScreenshots", oIni.GetKeyValue("SYSTEM_GLOBALS", "DisplayTimestampUnderScreenshots"))
        Return config
    End Function

    Private Sub setApplicationConfigs(ByVal a As String, Optional ByVal b As String = "True", Optional ByVal c As String = "True", Optional ByVal d As String = "False")
        oIni.AddSection("SYSTEM_GLOBALS").AddKey("ImgCaptureParentPath").Value = a
        oIni.AddSection("SYSTEM_GLOBALS").AddKey("PromptForCaption").Value = b
        oIni.AddSection("SYSTEM_GLOBALS").AddKey("DisplayTimestampUnderScreenshots").Value = c
        oIni.AddSection("SYSTEM_GLOBALS").AddKey("DeleteScreenshotsOnClose").Value = d
        oIni.Save(configFile)
        File.SetAttributes(configFile, FileAttributes.Hidden)
    End Sub

    Private Sub resetAppGlobals()
        Try
            Me.Button2.Enabled = False
            Me.Button3.Enabled = False
            Me.Button4.Enabled = False
            imgCaptureCounter = 0
            imgCaptions.Clear()
            If Directory.Exists(imgCaptureFolder) Then
                Dim dirInfo As DirectoryInfo = Directory.GetParent(imgCaptureFolder)
                Directory.Move(imgCaptureFolder, dirInfo.FullName & "\" & getTimeStamp("yyyyMMddhhmmss"))
            End If
            MsgBox("All environment variables restored. Start anew!", MsgBoxStyle.Information, "Reset")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Load Application Defaults
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim configs As New Hashtable
        configFile = Application.StartupPath & "\config.ini"
        configs = getApplicationConfigs()
        imgCaptureParentFolder = configs("ImgCaptureParentPath")
        imgPromptForCaption = Convert.ToBoolean(configs("PromptForCaption"))
        imgDltScrnshtsOnClose = Convert.ToBoolean(configs("DeleteScreenshotsOnClose"))
        imgDisplayTimestampWithScreenshots = Convert.ToBoolean(configs("DisplayTimestampUnderScreenshots"))

        If imgPromptForCaption Then
            PromptForCaptionsToolStripMenuItem.Checked = True
        Else
            PromptForCaptionsToolStripMenuItem.Checked = False
        End If

        If imgDltScrnshtsOnClose Then
            DeleteScreenshotsOnCloseToolStripMenuItem.Checked = True
        Else
            DeleteScreenshotsOnCloseToolStripMenuItem.Checked = False
        End If

        If imgDisplayTimestampWithScreenshots Then
            ShowTimestampBelowScreenshotsToolStripMenuItem.Checked = True
        Else
            ShowTimestampBelowScreenshotsToolStripMenuItem.Checked = False
        End If

        Me.Text = getApplicationTitle()
        Me.AboutToolStripMenuItem.Text = "About " & My.Application.Info.ProductName
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(10, 10)

        'Creat a new instance of HotkeyManager
        'objec and pass this form as its argument.
        Me.hkM = New HotkeyManager(Me)
        Try
            'Create a Hotkey object with its Id = 100 and value = Alt+G.
            Dim hk As New Hotkey(100, Keys.Alt Or Keys.G)
            'Register the Alt+G.
            Me.hkM.RegisterHotkey(hk, True)
        Catch ex As Exception
            'An exception is throw, show the exception message.
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Hide()
        Try
            If Directory.Exists(imgCaptureFolder) Then
                If Not imgDltScrnshtsOnClose Then
                    Dim dirInfo As DirectoryInfo = Directory.GetParent(imgCaptureFolder)
                    Directory.Move(imgCaptureFolder, dirInfo.FullName & "\" & getTimeStamp("yyyyMMddhhmmss"))
                Else
                    Directory.Delete(imgCaptureFolder, True)
                End If
            End If
            File.Delete(configFile)
            setApplicationConfigs(imgCaptureParentFolder, imgPromptForCaption, imgDltScrnshtsOnClose)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        If Me.hkM IsNot Nothing Then
            'Dispose the HotkeyManager objec when the application is exiting.
            'This method will unregister all hotkeys for this HotkeyManager.
            Me.hkM.Dispose()
        End If
    End Sub 'Form1_Closing

    Private Sub hk_HotkeyPressed(ByVal sender As Object, _
            ByVal e As HotkeyEventArgs) Handles hkM.HotkeyPressed
        'A hotkey is pressed, show the hotkey in a lable.
        'Me.HotkeyLabel.Text = e.Hotkey.ToString
        Button1_Click(sender, e)
    End Sub


    Private Sub FeedbackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeedbackToolStripMenuItem.Click
        Dim mailTo As String
        Dim mailSub As String
        Dim mailBody As String
        mailTo = "Rhine.Bandyopadhyay@cognizant.com"
        mailSub = "Feedback on " & getApplicationTitle()
        mailBody = "Hi Rhine," & vbNewLine & " I would like to share my feedback on '" & My.Application.Info.ProductName & "' with you ..."
        Process.Start("mailto:" & mailTo & "?subject=" & mailSub & "&body=" & mailBody)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim ApplicationDesc As String
        
        ApplicationDesc = My.Application.Info.ProductName _
                            & String.Format(" Version {0}", My.Application.Info.Version.ToString _
                            & vbNewLine & vbNewLine & My.Application.Info.Description _
                            & vbNewLine & vbNewLine & My.Application.Info.Copyright _
                            & ". " & My.Application.Info.CompanyName & ".")
        MsgBox(ApplicationDesc, _
              MsgBoxStyle.Information, _
              String.Format("About {0}", getApplicationTitle))
    End Sub

    Private Sub DeleteScreenshotsOnCloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteScreenshotsOnCloseToolStripMenuItem.Click
        If imgDltScrnshtsOnClose Then
            imgDltScrnshtsOnClose = False
        Else
            imgDltScrnshtsOnClose = True
        End If
    End Sub

    Private Sub ShowTimestampBelowScreenshotsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTimestampBelowScreenshotsToolStripMenuItem.Click
        If imgDisplayTimestampWithScreenshots Then
            imgDisplayTimestampWithScreenshots = False
        Else
            imgDisplayTimestampWithScreenshots = True
        End If
    End Sub

    Private Sub PromptForCaptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromptForCaptionsToolStripMenuItem.Click
        If imgPromptForCaption Then
            imgPromptForCaption = False
        Else
            imgPromptForCaption = True
        End If
    End Sub

    Private Sub ScreenshotsCapturePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScreenshotsCapturePathToolStripMenuItem.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.SelectedPath = imgCaptureParentFolder
        folderDlg.ShowNewFolderButton = True
        If MsgBox("Please note that after you change the screenshot capture folder, your documents or e-mails will be generated only with the images residing in the folder that you will be selecting now. Continue ?", 36, "Warning") = MsgBoxResult.Yes Then
            If (folderDlg.ShowDialog() = DialogResult.OK) Then
                imgCaptureParentFolder = folderDlg.SelectedPath
                'Dim root As Environment.SpecialFolder = folderDlg.SelectedPath
                resetAppGlobals()
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim imgCaptureName As String
        Dim imgCaption As String = ""
        Dim timestamp As String = ""
        imgCaptureFolder = imgCaptureParentFolder & "\Images_" & getTimeStamp()

        If docGenerated Or emailGenerated Then
            If MsgBox("A document or an eMail has been generated with the previous set of Screenshots. Click Yes to start anew or No to continue adding to the existing set of screenshots.", _
                      52, "Reload") = MsgBoxResult.Yes Then
                resetAppGlobals()
                docGenerated = False
                emailGenerated = False
            End If
        End If

        If Not Directory.Exists(imgCaptureFolder) Then
            Directory.CreateDirectory(imgCaptureFolder)
        End If

        Me.Hide()

        Try
            Dim screenshot As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim screengrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screengrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenshot)

            imgCaptureName = imgCaptureFolder & "\" & imgCaptureCounter & ".jpg"
            screengrab.Save(imgCaptureName)

            If imgPromptForCaption Then
                imgCaption = InputBox("Screenshot captured! Enter a Caption that would best describe your screenshot ( max. 255 chars )." _
                                      & vbNewLine & vbNewLine & _
                                      "Tip : You may turn this feature off from the Settings menu.", _
                     getApplicationTitle, _
                     "")
            End If

            If imgDisplayTimestampWithScreenshots Then
                timestamp = "[ " & Now & " ] "
            End If

            imgCaptions.Add(imgCaptureCounter, timestamp & imgCaption & ".")
            imgCaptureCounter = imgCaptureCounter + 1

            Me.Show()
            Me.Button2.Enabled = True
            Me.Button3.Enabled = True
            Me.Button4.Enabled = True
        Catch ex As Exception
            MsgBox("sorry unable to snap your screen and save at the moment please try again later", MsgBoxStyle.Critical, "Warning!")
            Me.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim PIctureLocation As String

        'Start Word and open the document template.
        oWord = CreateObject("Word.Application")
        oWord.Visible = True
        oDoc = oWord.Documents.Add

        Dim startOfDoc As Object = "\startofdoc"

        Try
            For x = 0 To imgCaptureCounter - 1
                PIctureLocation = imgCaptureFolder & "\" & x & ".jpg"
                oDoc.Bookmarks.Item("\endofdoc").Range.Font.Bold = True
                'oDoc.Bookmarks.Item("\endofdoc").Range.Text = "Screenshot " & x + 1 & vbCrLf
                oDoc.Bookmarks.Item("\endofdoc").Range.InlineShapes.AddPicture(PIctureLocation)
                oDoc.Bookmarks.Item("\endofdoc").Range.Text = vbCrLf & imgCaptions(x).ToString & vbCrLf & vbCrLf
            Next
            oDoc.Bookmarks.Item("\endofdoc").Range.Text = vbCrLf & "This document was generated using " & getApplicationTitle() & "! " & My.Application.Info.Description
            docGenerated = True
        Catch ex As Exception
            oDoc.Bookmarks.Item("\endofdoc").Range.Text = ex.Message
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim OutlookMessage As outlook.MailItem
        Dim AppOutlook As New outlook.Application
        Dim PIctureLocation As String
        Dim mailBody As String
        Dim colAttach As outlook.Attachments
        Dim oAttach As outlook.Attachment

        OutlookMessage = AppOutlook.CreateItem(outlook.OlItemType.olMailItem)
        colAttach = OutlookMessage.Attachments

        mailBody = "<div>"
        For x = 0 To imgCaptureCounter - 1
            PIctureLocation = imgCaptureFolder & "\" & x & ".jpg"
            oAttach = colAttach.Add(PIctureLocation)

            'mailBody &= "<p><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d""><b>Screenshot " & x + 1 & "</b><u></u><u></u></span></p>"
            mailBody &= "<p><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d""><img width=""831"" height=""467"" src=""cid:" & x & ".jpg"" class=""></span><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d""><u></u><u></u></span></p>"
            mailBody &= "<p><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d"">" & imgCaptions(x).ToString & "<u></u><u></u></span></p>"
            If x <> imgCaptureCounter - 1 Then
                mailBody &= "<hr>"
            End If

        Next
        mailBody &= "</div>"
        mailBody &= "<p><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d"">This mail was generated using " & getApplicationTitle() & "! " & My.Application.Info.Description & "</span><span style=""font-size:11.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#1f497d""><u></u><u></u></span></p>"
        Try

            'Dim Recipents As outlook.Recipients = OutlookMessage.Recipients
            'Recipents.Add("myemail@hotmail.com")
            OutlookMessage.Subject = "Sent from " & getApplicationTitle()
            OutlookMessage.BodyFormat = outlook.OlBodyFormat.olFormatHTML
            OutlookMessage.HTMLBody = mailBody
            'OutlookMessage.Send()
            OutlookMessage.Display()
            emailGenerated = True
        Catch ex As Exception
            MessageBox.Show("Mail could not be sent") 'if you dont want this message, simply delete this line 
        Finally
            OutlookMessage = Nothing
            AppOutlook = Nothing
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("This action will permanently delete all files created so far. Continue?", 36, "Reset application") = MsgBoxResult.Yes Then
            resetAppGlobals()
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub
End Class
