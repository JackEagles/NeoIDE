Imports System.Collections.Specialized
Imports System.IO

Public Class frmFindInFiles
    Dim checked As Boolean = False

    'The initial directory for the search
    Dim rdir As String

    'The file types that we're looking for, and the files that we've found
    Dim filetypes, foundfiles, AddToListView As New StringCollection

    'To show the user how many dirs we have counted
    Dim enumeratedDirs, fileCount As Integer
    'The file that were currently searching - show the user
    Dim CurSearchingFile As String

    'Variables for the two textboxes so that the backgroundworker thread can access them
    Dim txtFileNameText, txtFileContainsText As String

    'To see whether we've finished enumerating files or not and update status accordingly
    Dim firstStageComplete As Boolean


    Private Sub frmFindInFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        txtInitialDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tmrUpdateStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateStatus.Tick
        If firstStageComplete = True Then
            lblStatus.Text = "Status: Searching through " & CurSearchingFile
        Else
            lblStatus.Text = "Status: Enumerated " & fileCount & " files, in " & enumeratedDirs & " folders."
        End If
    End Sub

    Private Sub bwEnumFiles_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwEnumFiles.DoWork
        Dim dirs As List(Of String) = GetFilesRecursive(rdir)
        firstStageComplete = True
        For Each p As String In dirs
            For Each itm In txtFileTypes.Text.Split(", ")
                itm = itm.Trim
                If p.EndsWith(itm) Then
                    If chkFileContents.Checked = True AndAlso chkFileName.Checked = True Then
                        Dim fname As String = p.Substring(p.LastIndexOf("\")).Replace("\", "")
                        CurSearchingFile = fname
                        If fname.Contains(txtFileNameText) Then
                            Try
                                Dim reader As New IO.StreamReader(p)
                                Dim contents As String = reader.ReadToEnd
                                Dim foundOccurances As String = ""
                                If contents.ToLower.Contains(txtFileContainsText.ToLower) Then
                                    Dim success As Boolean = False
checkOccurances:
                                    success = False
                                      If contents.ToLower.Contains(txtFileContainsText.ToLower) Then
                                        Dim ln As Integer = contents.ToLower.LastIndexOf(txtFileContainsText.ToLower)
                                        For i As Integer = 100 To 10 Step -10
                                        If success = True Then Exit For
                                            Try
                                                Dim ttText As String = contents.Substring(ln - i / 2, i)
                                                contents = contents.Replace(contents.Substring(contents.ToLower.LastIndexOf(txtFileContainsText.ToLower)), "")
                                                foundOccurances &= "^&&&%%$$" & ttText
                                                success = True
                                                GoTo checkOccurances
                                            Catch ex As Exception
                                            End Try
                                        Next

                                    End If
                                    foundfiles.Add(p & "^^&&%^" & foundOccurances)
                                End If
                            Catch
                            End Try
                        End If
                    ElseIf chkFileName.Checked = True Then
                        Dim fname As String = p.Substring(p.LastIndexOf("\")).Replace("\", "")
                        CurSearchingFile = fname
                        If fname.Contains(txtFileNameText) Then
                            foundfiles.Add(p)
                        End If
                    ElseIf chkFileContents.Checked = True Then
                        Dim fname As String = p.Substring(p.LastIndexOf("\")).Replace("\", "")
                        CurSearchingFile = fname
                        If fname.Contains(txtFileNameText) Then
                            Try
                                Dim reader As New IO.StreamReader(p)
                                Dim contents As String = reader.ReadToEnd
                                Dim foundOccurances As String = ""
                                If contents.ToLower.Contains(txtFileContainsText.ToLower) Then
                                    Dim success As Boolean = False
checkOccurances2:
                                    success = False
                                    If contents.ToLower.Contains(txtFileContainsText.ToLower) Then
                                        Dim ln As Integer = contents.ToLower.LastIndexOf(txtFileContainsText.ToLower)
                                        For i As Integer = 100 To 10 Step -10
                                            If success = True Then Exit For
                                            Try
                                                Dim ttText As String = contents.Substring(ln - i, i)
                                                contents = contents.Replace(contents.Substring(contents.ToLower.LastIndexOf(txtFileContainsText.ToLower)), "")
                                                foundOccurances &= "^&&&%%$$" & ttText
                                                success = True
                                                GoTo checkOccurances2
                                            Catch ex As Exception
                                            End Try
                                        Next

                                    End If
                                    foundfiles.Add(p & "^^&&%^" & foundOccurances)
                                End If
                            Catch
                            End Try
                        End If

                    End If
                End If
            Next
        Next
    End Sub

    Public Function GetFilesRecursive(ByVal b As String) As List(Of String)
        Dim result As New List(Of String)()
        Dim stack As New Stack(Of String)()
        stack.Push(b)
        While stack.Count > 0
            Dim dir As String = stack.Pop()
            Try
                enumeratedDirs += 1
                result.AddRange(Directory.GetFiles(dir, "*.*"))
                fileCount = result.Count
                For Each dn As String In Directory.GetDirectories(dir)
                    stack.Push(dn)
                Next
            Catch
            End Try
        End While
        Return result
    End Function

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        filetypes.Clear() : foundfiles.Clear() : AddToListView.Clear()
        enumeratedDirs = 0 : fileCount = 0
        CurSearchingFile = ""
        firstStageComplete = False
        rdir = txtInitialDir.Text
        tmrUpdateStatus.Start()
        bwEnumFiles.RunWorkerAsync()
        txtFileNameText = txtFileNAme.Text
        txtFileContainsText = txtFileContents.Text
        btnStart.Enabled = False
        btnBrowse.Enabled = False
        chkFileContents.Enabled = False
        chkFileContents.Enabled = False
        For Each ctrl In Me.Controls
            If TypeOf (ctrl) Is TextBox Then
                CType(ctrl, TextBox).Enabled = False
            End If
        Next
    End Sub

    Private Sub bwEnumFiles_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwEnumFiles.RunWorkerCompleted
        On Error Resume Next
        tmrUpdateStatus.Stop()
        For Each itm In foundfiles
            If Filter(itm) = False Then
                AddToListView.Add(itm)
            End If
        Next
        If foundfiles.Count = 0 Then
            MessageBox.Show("No files with those criteria found. Try adding more file types, or less constraints on files names/content.")
            lblStatus.Text = "Information: Double click an item to open it."
        End If
        Dim res As New frmFindResults
        res.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
        res.Show(frmMain.dPanel)

        For Each itm In AddToListView
            If itm.Contains("^^&&%^") Then
                Dim occurances As String = itm.Substring(itm.LastIndexOf("^^&&%^"))
                Dim filePath As String = itm.Replace(occurances, "")
                Dim fileName As String = filePath.Substring(filePath.LastIndexOf("\")).Replace("\", "")
                Dim nd As New TreeNode
                nd.Text = fileName
                nd.ToolTipText = filePath
                nd.ImageKey = frmMain.CacheShellIcon(filePath)
                nd.SelectedImageKey = frmMain.CacheShellIcon(filePath)
                res.tvMain.ImageList = frmMain.ilTabControlImages
                occurances = occurances.Replace("^^&&%^", "")
checkNewOccurences:
                Dim curOccurence As String = occurances.Substring(occurances.LastIndexOf("^&&&%%$$"))
                occurances = occurances.Replace(curOccurence, "")
                curOccurence = curOccurence.Replace("^&&&%%$$", "")
                If curOccurence.Length >= 50 Then
                    nd.Nodes.Add(curOccurence)
                    If occurances.Contains("^&&&%%$$") Then
                        GoTo checkNewOccurences
                    End If
                End If
                res.tvMain.Nodes.Add(nd)
            Else
                Dim fileName As String = itm.Substring(itm.LastIndexOf("\")).Replace("\", "")
                Dim nd As New TreeNode
                nd.Text = fileName
                nd.ToolTipText = itm
                res.tvMain.Nodes.Add(nd)
            End If
        Next
        btnStart.Enabled = True
        btnBrowse.Enabled = True
        chkFileContents.Enabled = True
        chkFileName.Enabled = True
        For Each ctrl In Me.Controls
            If TypeOf (ctrl) Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
            End If
        Next
        Me.Close()

    End Sub


    Private Function Filter(ByVal itm As String)
        For Each Stri In AddToListView
            If Stri = itm Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Please select an initial directory:"
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtInitialDir.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub txtInitialDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInitialDir.TextChanged
        If My.Computer.FileSystem.DirectoryExists(txtInitialDir.Text) Then
            btnStart.Enabled = True
        Else
            btnStart.Enabled = False
        End If
    End Sub



    Private Sub lvwMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class