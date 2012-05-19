Imports System.Collections.Specialized

Public Class frmTips
    Dim Tips As New StringCollection

    Private Sub frmTips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = New Icon(Application.StartupPath & "\Images\Mainicon.ico")
        Tips.Add("Did You Know:" & Environment.NewLine & "NeoIDE supports command lines - this means that you can set your default editor for any file type as NeoIDE - using the 'Open With' feature in Windows Explorer!")
        Tips.Add("Did You Know:" & Environment.NewLine & "There's a document switcher which you can access by pressing SHIFT + TAB which lets you quickly change tabs to different documents!")
        Tips.Add("Try it out:" & Environment.NewLine & "Pressing the keys CTRL + 1-8 will select the respective tabs for each number. Pressing CTRL + 9 will take you to the last open tab.")
        Tips.Add("Peace of mind:" & Environment.NewLine & "NeoIDE automatically saves documents which you haven't - this means that even if your computer crashes, all your latest edits will be intact & recoverable!")
        Tips.Add("Did You Know:" & Environment.NewLine & "You can drag & drop files onto the project sidebar instead of browsing for them. This applies to folders too!")
        Tips.Add("Portability:" & Environment.NewLine & "NeoIDE stores all information in the same directory as the application - meaning that it is completely portable, as long as you have .NET installed on the machine which you transfer it to - your settings will remain intact!")
        Tips.Add("Did You Know:" & Environment.NewLine & "You can add your own syntax highlighting schemes to NeoIDE - just add them to the 'Custom Lexers' folder. Be careful though - as Scintilla.NET doesn't use the same highlighting files as the normal Scintilla textbox control!")
        Tips.Add("Speed & Functionality:" & Environment.NewLine & "NeoIDE performs line, word, column and charactor counts for the selected editor using a multi-threaded approach - meaning that the application can handle very large documents without any lag!")
        Tips.Add("Powerful & Tiny:" & Environment.NewLine & "NeoIDE packs all its functionality into just over 1mb on disk!")
        Tips.Add("You choose:" & Environment.NewLine & "NeoIDE can automatically apply certain syntax highlighting to certain document types - for instance .vb files can automatically have Visual Basic syntax highlighting applied to them when they are opened!")
        Tips.Add("Your colors:" & Environment.NewLine & "You can customize the look and feel of NeoIDE to your liking - dark or light - with many different tab styles & customizable colors")
        Tips.Add("Cloud Storage:" & Environment.NewLine & "NeoIDE can store all your programming files (within reason) in the cloud so that you can access them whenever you want from wherever you want. You can even share them with your friends too! What more could you ask for?")
        Tips.Add("Ease of use:" & Environment.NewLine & "You can choose to install NeoIDE and create shortcuts on the startmenu should you wish to. NeoIDE will even create an install entry and an uninstaller if you want!")
        Tips.Add("Sharing:" & Environment.NewLine & "You can share whatever you want with Whoever you want from NeoIDE - with integration into all e-mail services and some Social Networks!")
        Tips.Add("Accessibility:" & Environment.NewLine & "NeoIDE can be configured to put shortcuts to itself wherever you want - it can also register itself as a program with Windows & automatically uninstall should you wish it to.")
        Dim ran As New Random
        txtTip.Text = Tips(ran.Next(0, 13))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim tipindex As Integer = 0
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        tipindex += 1
        If tipindex = 14 Then tipindex = 0
        txtTip.Text = Tips(tipindex)
    End Sub
End Class