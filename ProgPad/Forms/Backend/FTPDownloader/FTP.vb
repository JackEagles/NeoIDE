Imports System.Text.RegularExpressions

Namespace ftp
    Class ftp_main
        Public Shared ftplib As New NeoIDE.FTPLib.FTP


        <STAThread()> _
        Private Shared Sub Main(args As String())
            If args.Length > 0 Then
                Try
                    commandline_mode(args)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            Else
                console_mode()
            End If
        End Sub

        Private Shared Sub commandline_mode(args As String())
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
            Dim go As Boolean = True
            Dim ftpGet As String() = New String(-1) {}
            Dim ftpPut As String() = New String(-1) {}

            ftplib.port = 21
            ftplib.user = "anonymous"
            ftplib.pass = ""

            i = 0
            While (i < args.Length) AndAlso go
                Select Case args(i)
                    Case "-s"
                        ftplib.server = args(i + 1)
                        Exit Select

                    Case "-p"
                        If IsInteger(args(i + 1)) Then
                            ftplib.port = Int32.Parse(args(i + 1))
                        Else
                            Console.WriteLine("Port should be a numeric value...")
                            go = False
                        End If
                        Exit Select

                    Case "-usr"
                        ftplib.user = args(i + 1)
                        Exit Select

                    Case "-pwd"
                        ftplib.pass = args(i + 1)
                        Exit Select

                    Case "-get"
                        j = i + 1
                        k = 0
                        While j < args.Length AndAlso args(j) <> "-"


                            j += 1
                            k += 1
                        End While
                        ftpGet = New String(k - 1) {}

                        j = i + 1
                        k = 0
                        While j < args.Length AndAlso args(j) <> "-"
                            ftpGet(k) = args(j)
                            j += 1
                            k += 1
                        End While
                        If j = i + 1 Then
                            Console.WriteLine("File to get must be specified...")
                            go = False
                        End If
                        i = j - 2
                        Exit Select

                    Case "-put"
                        j = i + 1
                        k = 0
                        While j < args.Length AndAlso args(j) <> "-"


                            j += 1
                            k += 1
                        End While
                        ftpPut = New String(k - 1) {}

                        j = i + 1
                        k = 0
                        While j < args.Length AndAlso args(j) <> "-"
                            ftpPut(k) = args(j)
                            j += 1
                            k += 1
                        End While
                        If j = i + 1 Then
                            Console.WriteLine("File to put must be specified...")
                            go = False
                        End If
                        i = j - 2
                        Exit Select

                    Case "-cd"
                        ftplib.ChangeDir(args(i + 1))
                        Exit Select

                    Case "-ld"
                        System.IO.Directory.SetCurrentDirectory(args(i + 1))
                        Exit Select

                    Case "-h"
                        show_help_command_line()
                        go = False
                        Exit Select
                End Select
                i += 2
            End While

            If ftpPut.Length > 0 OrElse ftpGet.Length > 0 Then
                If ftpPut.Length > 0 Then
                    For i = 0 To ftpPut.Length - 1
                        If ftpPut(i).LastIndexOf("/") >= 0 Then
                            ftplib.OpenUpload(ftpPut(i), ftpPut(i).Substring(ftpPut(i).LastIndexOf("/") + 1))
                        ElseIf ftpPut(i).LastIndexOf("\") >= 0 Then
                            ftplib.OpenUpload(ftpPut(i), ftpPut(i).Substring(ftpPut(i).LastIndexOf("\") + 1))
                        Else
                            ftplib.OpenUpload(ftpPut(i))
                        End If

                        Dim perc As Integer
                        While ftplib.DoUpload() > 0
                            perc = CInt(((ftplib.BytesTotal) * 100) / ftplib.FileSize)
                            Console.Write(vbCr & "Upload: {0}/{1} {2}%", ftplib.BytesTotal, ftplib.FileSize, perc)
                            Console.Out.Flush()
                        End While
                        Console.WriteLine("")
                    Next
                End If

                If ftpGet.Length > 0 Then
                    For i = 0 To ftpGet.Length - 1
                        ftplib.OpenDownload(ftpGet(i))
                        Dim perc As Integer
                        While ftplib.DoDownload() > 0
                            perc = CInt(((ftplib.BytesTotal) * 100) / ftplib.FileSize)
                            Console.Write(vbCr & "Downloading: {0}/{1} {2}%", ftplib.BytesTotal, ftplib.FileSize, perc)
                            Console.Out.Flush()
                        End While
                        Console.WriteLine("")
                    Next
                End If
            Else
                Console.WriteLine("Any order (set/put) was given...")
            End If
        End Sub

        Private Shared Sub console_mode()
            Dim go As Boolean = True
            Dim input As String = ""

            Console.WriteLine("FTP Client" & vbLf & "'?' for a list of commands.")
            While go
                Console.Write("% ")
                input = Console.ReadLine()
                Select Case Regex.Replace(input, " .*", "")
                    Case "open"
                        open(input)
                        Exit Select
                    Case "close"
                        close()
                        Exit Select
                    Case "ls"
                        list(input)
                        Exit Select
                    Case "lsd"
                        list_dir(input)
                        Exit Select
                    Case "lsf"
                        list_file(input)
                        Exit Select
                    Case "mkdir"
                        mkdir(input)
                        Exit Select
                    Case "rmdir"
                        rmdir(input)
                        Exit Select
                    Case "rm"
                        rm(input)
                        Exit Select
                    Case "ren"
                        rename(input)
                        Exit Select
                    Case "get"
                        download(input)
                        Exit Select
                    Case "put"
                        upload(input)
                        Exit Select
                    Case "set"
                        set_option(input)
                        Exit Select
                    Case "quit"
                        go = False
                        close()
                        Exit Select
                    Case "cd"
                        cd(input)
                        Exit Select
                    Case "pwd"
                        pwd()
                        Exit Select
                    Case "rawdate"
                        raw_date(input)
                        Exit Select
                    Case "date"
                        [date](input)
                        Exit Select
                    Case "?"
                        show_help()
                        Exit Select
                    Case Else
                        Console.WriteLine("E: Unrecognized command.")
                        Exit Select
                End Select

                If ftplib.MessagesAvailable Then
                    Console.Write(ftplib.Messages)
                End If
            End While
        End Sub

        Private Shared Sub show_help_command_line()
            Console.WriteLine("-h                  -- Show this help" & vbLf & "-c                  -- Start console mode (any other parameter can be defined)" & vbLf & "-s [ftp server]     -- Set the server to connect" & vbLf & "-p [port]           -- Set the port to connect to ('21' is default)" & vbLf & "-usr [username]     -- Set the username to connect as ('anonymous' is default)" & vbLf & "-pwd [password]     -- Set the password" & vbLf & "-get [filename list]-- Download a file (not compatible with use of -put)" & vbLf & "-put [filename list]-- Upload a file (not compatible with use of -get)" & vbLf & "-cd [directory]     -- Server source/target directory" & vbLf & "-ld [directory]     -- Local source/target directory" & vbLf & vbLf & "-- Samples --" & vbLf & vbLf & "ftp -s 127.0.0.1 -cd test -put C:\tmp\testfile1.txt C:\tmp\testfile2.txt" & vbLf & vbTab & "Connect to FTP 127.0.0.1:21, change to remote 'test' directory and " & vbLf & vbTab & "upload the local files 'C:\tmp\testfile1.txt' and 'C:\tmp\testfile2.txt'" & vbLf & vbLf & "ftp -s 127.0.0.1 -cd test -ld C:\tmp -put testfile1.txt testfile2.txt" & vbLf & vbTab & "As above, but local path is set once" & vbLf)
        End Sub

        Private Shared Sub show_help()
            Console.WriteLine("set user [username]     -- Set the username to connect as" & vbLf & "set pass [password]     -- Set the password" & vbLf & "set port [port]         -- Set the port to connect to" & vbLf & "set mode [A/P]          -- Set the A(ctive) or P(assive) [default] mode" & vbLf & "open [ftp server]       -- Connect to an ftp server" & vbLf & "close                   -- Close an existing connection" & vbLf & "get [filename]          -- Download a file" & vbLf & "put [filename]          -- Upload a file" & vbLf & "cd [directory]          -- Change directory" & vbLf & "pwd                     -- Get working directory" & vbLf & "ls                      -- List files and directories" & vbLf & "lsf                     -- List files only" & vbLf & "lsd                     -- (get the good stuff, joking!) List directories only" & vbLf & "rm [filename]           -- Delete a file" & vbLf & "ren [oldname] [newname] -- Rename a file" & vbLf & "rmdir [directory]       -- Remove a directory" & vbLf & "mkdir [directory]       -- Create a directory" & vbLf & "rawdate [filename]      -- Get raw date of file" & vbLf & "date [filename]         -- Get formatted date" & vbLf)
        End Sub

        Private Shared Sub set_option(command As String)
            Dim [option] As String = Regex.Replace(command, "^[A-Za-z]+ ", "")
            [option] = Regex.Replace([option], " .*", "")
            Select Case [option]
                'case "debug":
                '					if (ftplib.debug)
                '					{
                '						ftplib.debug = false;
                '						Console.WriteLine("--> Debug mode turned off.");
                '					}
                '					else 
                '					{
                '						ftplib.debug = true;
                '						Console.WriteLine("--> Debug mode turned on.");
                '					}
                '					break;

                Case "user"
                    ftplib.user = Regex.Replace(command, "set user ", "")
                    Console.WriteLine("--> User set to: " & Convert.ToString(ftplib.user))
                    Exit Select
                Case "pass"
                    ftplib.pass = Regex.Replace(command, "set pass ", "")
                    Console.WriteLine("--> Pass set to: " & Convert.ToString(ftplib.pass))
                    Exit Select
                Case "port"
                    ftplib.port = Integer.Parse(InlineAssignHelper(ftplib.user, Regex.Replace(command, "set port ", "")))
                    Console.WriteLine("--> Port set to: " & Convert.ToString(ftplib.port))
                    Exit Select
                Case "mode"
                    Dim sMode As String = Regex.Replace(command, "set mode ", "").ToUpper()
                    If sMode = "A" OrElse sMode = "P" Then
                        ftplib.PassiveMode = (sMode = "P")
                        Console.WriteLine("--> Mode set to: " & (If(ftplib.PassiveMode, "Passive", "Active")))
                    Else
                        Console.WriteLine("E: Invalid value for set mode option.")
                    End If
                    Exit Select
                Case Else
                    Console.WriteLine("E: Unrecognized option for set.")
                    Exit Select
            End Select

            Return
        End Sub

        Private Shared Sub cd(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ftplib.ChangeDir(Regex.Replace(command, "cd ", ""))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub pwd()
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                Console.WriteLine(ftplib.GetWorkingDirectory())
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub mkdir(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ftplib.MakeDir(Regex.Replace(command, "mkdir ", ""))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub rmdir(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ftplib.RemoveDir(Regex.Replace(command, "rmdir ", ""))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub rm(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ftplib.RemoveFile(Regex.Replace(command, "rm ", ""))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub rename(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                Dim cSepar As Char() = {" "c}
                Dim sNames As String() = Regex.Replace(command, "ren ", "").Split(cSepar, 2)
                ftplib.RenameFile(sNames(0), sNames(1))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub open(command As String)
            Try
                Console.WriteLine("--> Connecting...")
                ftplib.Connect(Regex.Replace(command, "open ", ""), ftplib.user, ftplib.pass)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub close()
            Try
                If ftplib.IsConnected Then
                    Console.WriteLine("--> Disconnecting.")
                    ftplib.Disconnect()
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        ' all of the file listing functions return an ArrayList from System.Collections
        Private Shared Sub list(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                For Each f As String In ftplib.List()
                    Console.WriteLine(f)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        ' all of the file listing functions return an ArrayList from System.Collections
        Private Shared Sub list_file(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                For Each f As String In ftplib.ListFiles()
                    Console.WriteLine(f)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        ' all of the file listing functions return an ArrayList from System.Collections
        Private Shared Sub list_dir(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                For Each f As String In ftplib.ListDirectories()
                    Console.WriteLine(f)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub raw_date(command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                Console.WriteLine(ftplib.GetFileDateRaw(Regex.Replace(command, "rawdate ", "")))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub [date](command As String)
            Try
                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If
                Console.WriteLine(ftplib.GetFileDate(Regex.Replace(command, "date ", "")).ToString())
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub download(command As String)
            Try
                Dim perc As Integer = 0

                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ' open the file with resume support if it already exists, the last
                ' peram should be false for no resume
                ftplib.OpenDownload(Regex.Replace(command, "get ", ""), False)
                While ftplib.DoDownload() > 0
                    perc = CInt(((ftplib.BytesTotal) * 100) / ftplib.FileSize)
                    Console.Write(vbCr & "Downloading: {0}/{1} {2}%", ftplib.BytesTotal, ftplib.FileSize, perc)
                    Console.Out.Flush()
                End While
                Console.WriteLine("")
            Catch ex As Exception
                Console.WriteLine("")
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Sub upload(command As String)
            Try
                Dim perc As Integer = 0
                Dim file As String = Regex.Replace(command, "put ", "")

                If Not ftplib.IsConnected Then
                    Console.WriteLine("E: Must be connected to a server.")
                    Return
                End If

                ' open an upload
                ftplib.OpenUpload(file, System.IO.Path.GetFileName(file))
                While ftplib.DoUpload() > 0
                    perc = CInt(((ftplib.BytesTotal) * 100) / ftplib.FileSize)
                    Console.Write(vbCr & "Upload: {0}/{1} {2}%", ftplib.BytesTotal, ftplib.FileSize, perc)
                    Console.Out.Flush()
                End While
                Console.WriteLine("")
            Catch ex As Exception
                Console.WriteLine("")
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Private Shared Function IsInteger(theValue As String) As Boolean
            Try
                Convert.ToInt32(theValue)
                Return True
            Catch
                Return False
            End Try
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace