Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class frmEncrypt
    Public ApplicableText As String
    Public EncryptMode As Boolean = False

    Private Sub frmEncrypt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInitVector.Enabled = chkAdvanced.Checked
        txtSalt.Enabled = chkAdvanced.Checked
        cbxHash.Enabled = chkAdvanced.Checked
        cbxHash.SelectedIndex = 0
        If EncryptMode = True Then
            btnEncrypt.Text = "Encrypt"
        Else
            btnEncrypt.Text = "Decrypt"
        End If
    End Sub

    Private Sub chkAdvanced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
        txtInitVector.Enabled = chkAdvanced.Checked
        txtSalt.Enabled = chkAdvanced.Checked
        cbxHash.Enabled = chkAdvanced.Checked
        If chkAdvanced.Checked = True Then
            MessageBox.Show("Please note that any custom values you enter here will need to be the same upon decryption!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        Dim hashMode As String
        If cbxHash.SelectedIndex = 0 Then hashMode = "SHA1" Else hashMode = "MD5"

        Try
            If EncryptMode = True Then
                frmMain.SelScintilla.Text = "PROGPADENCRYPT:" & RijndaelSimple.Encrypt(ApplicableText, txtPassword.Text, txtSalt.Text, hashMode, 2, txtInitVector.Text, 256)
                frmMain.EncryptAndCloseSelectedToolStripMenuItem.Text = "Decrypt Selected"
                Me.Close()
            Else
                frmMain.SelScintilla.Text = RijndaelSimple.Decrypt(ApplicableText.Replace("PROGPADENCRYPT:", ""), txtPassword.Text, txtSalt.Text, hashMode, 2, txtInitVector.Text, 256)
                frmMain.EncryptAndCloseSelectedToolStripMenuItem.Text = "Encrypt Selected"
                Me.Close()
            End If
        Catch ex As Exception
            If EncryptMode = False Then
                MessageBox.Show("An error occured: " & ex.Message & " Please check your password & other information. If you do not want to decrypt this file, just close this form. If you have modified the document since it was encrypted, please revert these changes - if you do not do so the file will not be able to be decrypted.")
            Else
                MessageBox.Show("An error occured encrypting the document. If you are using custom settings, consider reverting back to the defaults.")
            End If

        End Try

    End Sub
End Class

Module Module1
    Public Class RijndaelSimple
        Public Shared Function Encrypt(ByVal plainText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
            Dim initVectorBytes As Byte()
            initVectorBytes = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte()
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue)
            Dim plainTextBytes As Byte()
            plainTextBytes = Encoding.UTF8.GetBytes(plainText)
            Dim password As PasswordDeriveBytes
            password = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte()
            keyBytes = password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged
            symmetricKey = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
            Dim memoryStream As MemoryStream
            memoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream
            cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim cipherTextBytes As Byte()
            cipherTextBytes = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            Dim cipherText As String
            cipherText = Convert.ToBase64String(cipherTextBytes)
            Encrypt = cipherText
        End Function
        Public Shared Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
            Dim initVectorBytes As Byte()
            initVectorBytes = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte()
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue)
            Dim cipherTextBytes As Byte()
            cipherTextBytes = Convert.FromBase64String(cipherText)
            Dim password As PasswordDeriveBytes
            password = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte()
            keyBytes = password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged
            symmetricKey = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As MemoryStream
            memoryStream = New MemoryStream(cipherTextBytes)
            Dim cryptoStream As CryptoStream
            cryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte()
            ReDim plainTextBytes(cipherTextBytes.Length)
            Dim decryptedByteCount As Integer
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Dim plainText As String
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
            Decrypt = plainText
        End Function
    End Class
End Module