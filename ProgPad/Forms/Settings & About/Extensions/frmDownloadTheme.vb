Imports System.Runtime.InteropServices
Imports System.Net

Public Class frmDownloadTheme
    Private Const FEATURE_DISABLE_NAVIGATION_SOUNDS As Integer = 21
    Private Const SET_FEATURE_ON_THREAD As Integer = &H1
    Private Const SET_FEATURE_ON_PROCESS As Integer = &H2
    Private Const SET_FEATURE_IN_REGISTRY As Integer = &H4
    Private Const SET_FEATURE_ON_THREAD_LOCALMACHINE As Integer = &H8
    Private Const SET_FEATURE_ON_THREAD_INTRANET As Integer = &H10
    Private Const SET_FEATURE_ON_THREAD_TRUSTED As Integer = &H20
    Private Const SET_FEATURE_ON_THREAD_INTERNET As Integer = &H40
    Private Const SET_FEATURE_ON_THREAD_RESTRICTED As Integer = &H80


    <DllImport("urlmon.dll")> <PreserveSig()> Private Shared Function CoInternetSetFeatureEnabled(FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> dwFlags As Integer, fEnable As Boolean) As <MarshalAs(UnmanagedType.[Error])> Integer
    End Function

    Friend WithEvents htDoc As HtmlDocument
    Friend WithEvents wc As New WebClient

    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        htDoc = WebBrowser1.Document
    End Sub

    Private Sub htDoc_MouseDown(sender As Object, e As System.Windows.Forms.HtmlElementEventArgs) Handles htDoc.MouseDown
        If WebBrowser1.Document.GetElementFromPoint(e.MousePosition).GetAttribute("href").StartsWith("installtheme:") Then
            Dim href As String = WebBrowser1.Document.GetElementFromPoint(e.MousePosition).GetAttribute("href").Replace("installtheme:", "")
            Dim themeFileURI As String = href.Substring(href.LastIndexOf("@")).Replace("@", "")
            Dim themeName As String = href.Replace(themeFileURI, "").Replace("@", "")
            Dim mbres = MessageBox.Show("Do you want to install the theme: " & themeName & "?", "Install theme?", MessageBoxButtons.YesNo)
            If mbres = Windows.Forms.DialogResult.Yes Then
                If IO.File.Exists(Application.StartupPath & "\Themes" & themeFileURI.Substring(themeFileURI.LastIndexOf("/")).Replace("/", "\")) Then
                    IO.File.Delete(Application.StartupPath & "\Themes" & themeFileURI.Substring(themeFileURI.LastIndexOf("/")).Replace("/", "\"))
                End If
                wc.DownloadFileAsync(New Uri(themeFileURI), Application.StartupPath & "\Themes\" & themeFileURI.Substring(themeFileURI.LastIndexOf("/")).Replace("/", ""))

            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\mainicon.ico")
        CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, False)
    End Sub

    Private Sub wc_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles wc.DownloadFileCompleted
        Me.Close()
    End Sub
End Class
