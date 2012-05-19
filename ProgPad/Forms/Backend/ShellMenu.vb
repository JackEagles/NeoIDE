Imports System.Diagnostics
Imports Microsoft.Win32

NotInheritable Class ShellMenu

    Private Sub New()
    End Sub
  Public Shared Sub Register(ByVal fileType As String, ByVal shellKeyName As String, ByVal menuText As String, ByVal menuCommand As String)
        Dim regPath As String = String.Format("{0}\shell\{1}", fileType, shellKeyName)
        Using key As RegistryKey = Registry.ClassesRoot.CreateSubKey(regPath)
            key.SetValue(Nothing, menuText)
        End Using
        Using key As RegistryKey = Registry.ClassesRoot.CreateSubKey(String.Format("{0}\command", regPath))
            key.SetValue(Nothing, menuCommand)
        End Using
    End Sub

    Public Shared Sub Unregister(ByVal fileType As String, ByVal shellKeyName As String)
        Try
            Dim regPath As String = String.Format("{0}\shell\{1}", fileType, shellKeyName)
            Registry.ClassesRoot.DeleteSubKeyTree(regPath)
        Catch
        End Try
    End Sub
End Class