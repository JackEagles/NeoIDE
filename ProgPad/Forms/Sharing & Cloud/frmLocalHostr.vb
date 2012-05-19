Imports System.ComponentModel
Imports System.Collections.Specialized

Public Class frmLocalHostrUploader
    Public fName As String = "Could not upload file. An error occured."
    Friend WithEvents bwUpload As New BackgroundWorker
    Dim uploadedlink As String

    Private Sub frmLocalHostrUploader_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Localhostr_Uploader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        bwUpload.RunWorkerAsync()
    End Sub

    Private Sub bwUpload_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwUpload.DoWork
        Try
            Dim FileName = IO.Path.GetFileName(fName)
            Dim Http As New Http
            With Http
                Dim Fields As New NameValueCollection
                Fields.Add("name", FileName)
                Dim UData As New Http.UploadData
                UData.FieldName = "file"
                UData.FileName = FileName
                UData.Contents = IO.File.ReadAllBytes(fName)
                Dim Request As Http.HttpResponse = .GetUploadResponse("http://d.localhostr.com/upload", Nothing, Fields, UData)
                Dim Html$ = Request.Html
                If (Html.Contains("{""jsonrpc"" : ""2.0"", ""result"" : {""name"":""")) Then
                    uploadedlink = .UrlDecode(.ParseBetween(Html, "url"":""", """", "url"":""".Length))
                Else
                    uploadedlink = "Could not upload file. An error occured."
                End If
            End With
        Catch
        End Try
    End Sub

    Private Sub bwUpload_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUpload.RunWorkerCompleted
        txtFileURL.Visible = True : lblFileURL.Visible = True : pbMain.Visible = False
        txtFileURL.Text = uploadedlink
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.hackforums.net/member.php?action=profile&uid=734377")
    End Sub
End Class