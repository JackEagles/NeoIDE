'#define FTP_DEBUG   

Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections

Namespace FTPLib
    Public Class FTP
#Region "Public Variables"

        ''' <summary>
        ''' IP address or hostname to connect to
        ''' </summary>
        Public server As String
        ''' <summary>
        ''' Username to login as
        ''' </summary>
        Public user As String
        ''' <summary>
        ''' Password for account
        ''' </summary>
        Public pass As String
        ''' <summary>
        ''' Port number the FTP server is listening on
        ''' </summary>
        Public port As Integer
        ''' <summary>
        ''' The timeout (miliseconds) for waiting on data to arrive
        ''' </summary>
        Public timeout As Integer

#End Region

#Region "Private Variables"

        Private m_messages As String
        ' server messages
        Private responseStr As String
        ' server response if the user wants it.
        Private passive_mode As Boolean
        ' #######################################
        Private bytes_total As Long
        ' upload/download info if the user wants it.
        Private file_size As Long
        ' gets set when an upload or download takes place
        Private main_sock As Socket
        Private main_ipEndPoint As IPEndPoint
        Private listening_sock As Socket
        Private data_sock As Socket
        Private data_ipEndPoint As IPEndPoint
        Private file As FileStream
        Private response As Integer
        Private bucket As String

#End Region

#Region "Constructors"
        ''' <summary>
        ''' Constructor
        ''' </summary>
        Public Sub New()
            server = Nothing
            user = Nothing
            pass = Nothing
            port = 21
            passive_mode = True
            ' #######################################
            main_sock = Nothing
            main_ipEndPoint = Nothing
            listening_sock = Nothing
            data_sock = Nothing
            data_ipEndPoint = Nothing
            file = Nothing
            bucket = ""
            bytes_total = 0
            timeout = 10000
            ' 10 seconds
            m_messages = ""
        End Sub
        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="server">Server to connect to</param>
        ''' <param name="user">Account to login as</param>
        ''' <param name="pass">Account password</param>
        Public Sub New(server As String, user As String, pass As String)
            Me.server = server
            Me.user = user
            Me.pass = pass
            port = 21
            passive_mode = True
            ' #######################################
            main_sock = Nothing
            main_ipEndPoint = Nothing
            listening_sock = Nothing
            data_sock = Nothing
            data_ipEndPoint = Nothing
            file = Nothing
            bucket = ""
            bytes_total = 0
            timeout = 10000
            ' 10 seconds
            m_messages = ""
        End Sub
        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="server">Server to connect to</param>
        ''' <param name="port">Port server is listening on</param>
        ''' <param name="user">Account to login as</param>
        ''' <param name="pass">Account password</param>
        Public Sub New(server As String, port As Integer, user As String, pass As String)
            Me.server = server
            Me.user = user
            Me.pass = pass
            Me.port = port
            passive_mode = True
            ' #######################################
            main_sock = Nothing
            main_ipEndPoint = Nothing
            listening_sock = Nothing
            data_sock = Nothing
            data_ipEndPoint = Nothing
            file = Nothing
            bucket = ""
            bytes_total = 0
            timeout = 10000
            ' 10 seconds
            m_messages = ""
        End Sub

#End Region

        ''' <summary>
        ''' Connection status to the server
        ''' </summary>
        Public ReadOnly Property IsConnected() As Boolean
            Get
                If main_sock IsNot Nothing Then
                    Return main_sock.Connected
                End If
                Return False
            End Get
        End Property
        ''' <summary>
        ''' Returns true if the message buffer has data in it
        ''' </summary>
        Public ReadOnly Property MessagesAvailable() As Boolean
            Get
                If m_messages.Length > 0 Then
                    Return True
                End If
                Return False
            End Get
        End Property
        ''' <summary>
        ''' Server messages if any, buffer is cleared after you access this property
        ''' </summary>
        Public ReadOnly Property Messages() As String
            Get
                Dim tmp As String = m_messages
                m_messages = ""
                Return tmp
            End Get
        End Property
        ''' <summary>
        ''' The response string from the last issued command
        ''' </summary>
        Public ReadOnly Property ResponseString() As String
            Get
                Return responseStr
            End Get
        End Property
        ''' <summary>
        ''' The total number of bytes sent/recieved in a transfer
        ''' </summary>
        Public ReadOnly Property BytesTotal() As Long
            ' #######################################
            Get
                Return bytes_total
            End Get
        End Property
        ''' <summary>
        ''' The size of the file being downloaded/uploaded (Can possibly be 0 if no size is available)
        ''' </summary>
        Public ReadOnly Property FileSize() As Long
            ' #######################################
            Get
                Return file_size
            End Get
        End Property
        ''' <summary>
        ''' True:  Passive mode [default]
        ''' False: Active Mode
        ''' </summary>
        Public Property PassiveMode() As Boolean
            ' #######################################
            Get
                Return passive_mode
            End Get
            Set(value As Boolean)
                passive_mode = value
            End Set
        End Property


        Private Sub Fail()
            Disconnect()
            Throw New Exception(responseStr)
        End Sub


        Private Sub SetBinaryMode(mode As Boolean)
            If mode Then
                SendCommand("TYPE I")
            Else
                SendCommand("TYPE A")
            End If

            ReadResponse()
            If response <> 200 Then
                Fail()
            End If
        End Sub


        Private Sub SendCommand(command As String)
            Dim cmd As [Byte]() = Encoding.ASCII.GetBytes((command & vbCr & vbLf).ToCharArray())

#If (FTP_DEBUG) Then
			If command.Length > 3 AndAlso command.Substring(0, 4) = "PASS" Then
				Console.WriteLine(vbCr & "PASS xxx")
			Else
				Console.WriteLine(vbCr & command)
			End If
#End If

            main_sock.Send(cmd, cmd.Length, 0)
        End Sub


        Private Sub FillBucket()
            Dim bytes As [Byte]() = New [Byte](511) {}
            Dim bytesgot As Long
            Dim msecs_passed As Integer = 0
            ' #######################################
            While main_sock.Available < 1
                System.Threading.Thread.Sleep(50)
                msecs_passed += 50
                ' this code is just a fail safe option 
                ' so the code doesn't hang if there is 
                ' no data comming.
                If msecs_passed > timeout Then
                    Disconnect()
                    Throw New Exception("Timed out waiting on server to respond.")
                End If
            End While

            While main_sock.Available > 0
                bytesgot = main_sock.Receive(bytes, 512, 0)
                bucket += Encoding.ASCII.GetString(bytes, 0, CInt(bytesgot))
                ' this may not be needed, gives any more data that hasn't arrived
                ' just yet a small chance to get there.
                System.Threading.Thread.Sleep(50)
            End While
        End Sub


        Private Function GetLineFromBucket() As String
            Dim i As Integer
            Dim buf As String = ""

            If (InlineAssignHelper(i, bucket.IndexOf(ControlChars.Lf))) < 0 Then
                While i < 0
                    FillBucket()
                    i = bucket.IndexOf(ControlChars.Lf)
                End While
            End If

            buf = bucket.Substring(0, i)
            bucket = bucket.Substring(i + 1)

            Return buf
        End Function


        ' Any time a command is sent, use ReadResponse() to get the response
        ' from the server. The variable responseStr holds the entire string and
        ' the variable response holds the response number.
        Private Sub ReadResponse()
            Dim buf As String
            m_messages = ""

            While True
                'buf = GetLineFromBucket();
                buf = GetLineFromBucket()

#If (FTP_DEBUG) Then
				Console.WriteLine(buf)
#End If
                ' the server will respond with "000-Foo bar" on multi line responses
                ' "000 Foo bar" would be the last line it sent for that response.
                ' Better example:
                ' "000-This is a multiline response"
                ' "000-Foo bar"
                ' "000 This is the end of the response"
                If Regex.Match(buf, "^[0-9]+ ").Success Then
                    responseStr = buf
                    response = Integer.Parse(buf.Substring(0, 3))
                    Exit While
                Else
                    m_messages += Regex.Replace(buf, "^[0-9]+-", "") & vbLf
                End If
            End While
        End Sub


        ' if you add code that needs a data socket, i.e. a PASV or PORT command required,
        ' call this function to do the dirty work. It sends the PASV or PORT command,
        ' parses out the port and ip info and opens the appropriate data socket
        ' for you. The socket variable is private Socket data_socket. Once you
        ' are done with it, be sure to call CloseDataSocket()
        Private Sub OpenDataSocket()
            If passive_mode Then
                ' #######################################
                Dim pasv As String()
                Dim server As String
                Dim port As Integer

                Connect()
                SendCommand("PASV")
                ReadResponse()
                If response <> 227 Then
                    Fail()
                End If

                Try
                    Dim i1 As Integer, i2 As Integer

                    i1 = responseStr.IndexOf("("c) + 1
                    i2 = responseStr.IndexOf(")"c) - i1
                    pasv = responseStr.Substring(i1, i2).Split(","c)
                Catch generatedExceptionName As Exception
                    Disconnect()
                    Throw New Exception("Malformed PASV response: " & responseStr)
                End Try

                If pasv.Length < 6 Then
                    Disconnect()
                    Throw New Exception("Malformed PASV response: " & responseStr)
                End If

                server = [String].Format("{0}.{1}.{2}.{3}", pasv(0), pasv(1), pasv(2), pasv(3))
                port = (Integer.Parse(pasv(4)) << 8) + Integer.Parse(pasv(5))

                Try
#If (FTP_DEBUG) Then
					Console.WriteLine("Data socket: {0}:{1}", server, port)
#End If
                    CloseDataSocket()

#If (FTP_DEBUG) Then
					Console.WriteLine("Creating socket...")
#End If
                    data_sock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

#If (FTP_DEBUG) Then
					Console.WriteLine("Resolving host")
#End If

                    data_ipEndPoint = New IPEndPoint(Dns.GetHostByName(server).AddressList(0), port)


#If (FTP_DEBUG) Then
					Console.WriteLine("Connecting..")
#End If
                    data_sock.Connect(data_ipEndPoint)

#If (FTP_DEBUG) Then
#End If
                    Console.WriteLine("Connected.")
                Catch ex As Exception
                    Throw New Exception("Failed to connect for data transfer: " & ex.Message)
                End Try
            Else
                ' #######################################
                Connect()

                Try
#If (FTP_DEBUG) Then
					Console.WriteLine("Data socket (active mode)")
#End If
                    CloseDataSocket()

#If (FTP_DEBUG) Then
					Console.WriteLine("Creating listening socket...")
#End If
                    listening_sock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

#If (FTP_DEBUG) Then
					Console.WriteLine("Binding it to local address/port")
#End If
                    ' for the PORT command we need to send our IP address; let's extract it
                    ' from the LocalEndPoint of the main socket, that's already connected
                    Dim sLocAddr As String = main_sock.LocalEndPoint.ToString()
                    Dim ix As Integer = sLocAddr.IndexOf(":"c)
                    If ix < 0 Then
                        Throw New Exception("Failed to parse the local address: " & sLocAddr)
                    End If
                    Dim sIPAddr As String = sLocAddr.Substring(0, ix)
                    ' let the system automatically assign a port number (setting port = 0)
                    Dim localEP As System.Net.IPEndPoint = New IPEndPoint(IPAddress.Parse(sIPAddr), 0)

                    listening_sock.Bind(localEP)
                    sLocAddr = listening_sock.LocalEndPoint.ToString()
                    ix = sLocAddr.IndexOf(":"c)
                    If ix < 0 Then
                        Throw New Exception("Failed to parse the local address: " & sLocAddr)
                    End If
                    Dim nPort As Integer = Integer.Parse(sLocAddr.Substring(ix + 1))
#If (FTP_DEBUG) Then
					Console.WriteLine("Listening on {0}:{1}", sIPAddr, nPort)
#End If
                    ' start to listen for a connection request from the host (note that
                    ' Listen is not blocking) and send the PORT command
                    listening_sock.Listen(1)
                    Dim sPortCmd As String = String.Format("PORT {0},{1},{2}", sIPAddr.Replace("."c, ","c), nPort \ 256, nPort Mod 256)
                    SendCommand(sPortCmd)
                    ReadResponse()
                    If response <> 200 Then
                        Fail()
                    End If
                Catch ex As Exception
                    Throw New Exception("Failed to connect for data transfer: " & ex.Message)
                End Try
            End If
        End Sub


        Private Sub ConnectDataSocket()
            ' #######################################
            If data_sock IsNot Nothing Then
                ' already connected (always so if passive mode)
                Return
            End If

            Try
#If (FTP_DEBUG) Then
				Console.WriteLine("Accepting the data connection.")
#End If
                data_sock = listening_sock.Accept()
                ' Accept is blocking
                listening_sock.Close()
                listening_sock = Nothing

                If data_sock Is Nothing Then
                    Throw New Exception("Winsock error: " & Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()))
                End If
#If (FTP_DEBUG) Then
#End If
                Console.WriteLine("Connected.")
            Catch ex As Exception
                Throw New Exception("Failed to connect for data transfer: " & ex.Message)
            End Try
        End Sub


        Private Sub CloseDataSocket()
#If (FTP_DEBUG) Then
			Console.WriteLine("Attempting to close data channel socket...")
#End If
            If data_sock IsNot Nothing Then
                If data_sock.Connected Then
#If (FTP_DEBUG) Then
					Console.WriteLine("Closing data channel socket!")
#End If
                    data_sock.Close()
#If (FTP_DEBUG) Then
#End If
                    Console.WriteLine("Data channel socket closed!")
                End If
                data_sock = Nothing
            End If

            data_ipEndPoint = Nothing
        End Sub
        ''' <summary>
        ''' Closes all connections to the ftp server
        ''' </summary>
        Public Sub Disconnect()
            CloseDataSocket()

            If main_sock IsNot Nothing Then
                If main_sock.Connected Then
                    SendCommand("QUIT")
                    main_sock.Close()
                End If
                main_sock = Nothing
            End If

            If file IsNot Nothing Then
                file.Close()
            End If

            main_ipEndPoint = Nothing
            file = Nothing
        End Sub
        ''' <summary>
        ''' Connect to a ftp server
        ''' </summary>
        ''' <param name="server">IP or hostname of the server to connect to</param>
        ''' <param name="port">Port number the server is listening on</param>
        ''' <param name="user">Account name to login as</param>
        ''' <param name="pass">Password for the account specified</param>
        Public Sub Connect(server As String, port As Integer, user As String, pass As String)
            Me.server = server
            Me.user = user
            Me.pass = pass
            Me.port = port

            Connect()
        End Sub
        ''' <summary>
        ''' Connect to a ftp server
        ''' </summary>
        ''' <param name="server">IP or hostname of the server to connect to</param>
        ''' <param name="user">Account name to login as</param>
        ''' <param name="pass">Password for the account specified</param>
        Public Sub Connect(server As String, user As String, pass As String)
            Me.server = server
            Me.user = user
            Me.pass = pass

            Connect()
        End Sub
        ''' <summary>
        ''' Connect to an ftp server
        ''' </summary>
        Public Sub Connect()
            If server Is Nothing Then
                Throw New Exception("No server has been set.")
            End If
            If user Is Nothing Then
                Throw New Exception("No username has been set.")
            End If

            If main_sock IsNot Nothing Then
                If main_sock.Connected Then
                    Return
                End If
            End If

            main_sock = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            main_ipEndPoint = New IPEndPoint(Dns.GetHostByName(server).AddressList(0), port)

            Try
                main_sock.Connect(main_ipEndPoint)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

            ReadResponse()
            If response <> 220 Then
                Fail()
            End If

            SendCommand("USER " & user)
            ReadResponse()

            Select Case response
                Case 331
                    If pass Is Nothing Then
                        Disconnect()
                        Throw New Exception("No password has been set.")
                    End If
                    SendCommand("PASS " & pass)
                    ReadResponse()
                    If response <> 230 Then
                        Fail()
                    End If
                    Exit Select
                Case 230
                    Exit Select
            End Select

            Return
        End Sub
        ''' <summary>
        ''' Retrieves a list of files from the ftp server
        ''' </summary>
        ''' <returns>An ArrayList of files</returns>
        Public Function List() As ArrayList
            Dim bytes As [Byte]() = New [Byte](511) {}
            Dim file_list As String = ""
            Dim bytesgot As Long = 0
            Dim msecs_passed As Integer = 0
            Dim list__1 As New ArrayList()

            Connect()
            OpenDataSocket()
            SendCommand("LIST")
            ReadResponse()

            'FILIPE MADUREIRA.
            'Added response 125
            Select Case response
                Case 125, 150
                    Exit Select
                Case Else
                    CloseDataSocket()
                    Throw New Exception(responseStr)
            End Select
            ConnectDataSocket()
            ' #######################################
            While data_sock.Available < 1
                System.Threading.Thread.Sleep(50)
                msecs_passed += 50
                ' this code is just a fail safe option 
                ' so the code doesn't hang if there is 
                ' no data comming.
                If msecs_passed > (timeout \ 10) Then
                    'CloseDataSocket();
                    'throw new Exception("Timed out waiting on server to respond.");

                    'FILIPE MADUREIRA.
                    'If there are no files to list it gives timeout.
                    'So I wait less time and if no data is received, means that there are no files
                    'Maybe there are no files
                    Exit While
                End If
            End While

            While data_sock.Available > 0
                bytesgot = data_sock.Receive(bytes, bytes.Length, 0)
                file_list += Encoding.ASCII.GetString(bytes, 0, CInt(bytesgot))
                ' *shrug*, sometimes there is data comming but it isn't there yet.
                System.Threading.Thread.Sleep(50)
            End While

            CloseDataSocket()

            ReadResponse()
            If response <> 226 Then
                Throw New Exception(responseStr)
            End If

            For Each f As String In file_list.Split(ControlChars.Lf)
                If f.Length > 0 AndAlso Not Regex.Match(f, "^total").Success Then
                    list__1.Add(f.Substring(0, f.Length - 1))
                End If
            Next

            Return list__1
        End Function
        ''' <summary>
        ''' Gets a file list only
        ''' </summary>
        ''' <returns>ArrayList of files only</returns>
        Public Function ListFiles() As ArrayList
            Dim list__1 As New ArrayList()

            For Each f As String In List()
                'FILIPE MADUREIRA
                'In Windows servers it is identified by <DIR>
                If (f.Length > 0) Then
                    If (f(0) <> "d"c) AndAlso (f.ToUpper().IndexOf("<DIR>") < 0) Then
                        list__1.Add(f)
                    End If
                End If
            Next

            Return list__1
        End Function
        ''' <summary>
        ''' Gets a directory list only
        ''' </summary>
        ''' <returns>ArrayList of directories only</returns>
        Public Function ListDirectories() As ArrayList
            Dim list__1 As New ArrayList()

            For Each f As String In List()
                'FILIPE MADUREIRA
                'In Windows servers it is identified by <DIR>
                If f.Length > 0 Then
                    If (f(0) = "d"c) OrElse (f.ToUpper().IndexOf("<DIR>") >= 0) Then
                        list__1.Add(f)
                    End If
                End If
            Next

            Return list__1
        End Function
        ''' <summary>
        ''' Returns the 'Raw' DateInformation in ftp format. (YYYYMMDDhhmmss). Use GetFileDate to return a DateTime object as a better option.
        ''' </summary>
        ''' <param name="fileName">Remote FileName to Query</param>
        ''' <returns>Returns the 'Raw' DateInformation in ftp format</returns>
        Public Function GetFileDateRaw(fileName As String) As String
            Connect()

            SendCommand("MDTM " & fileName)
            ReadResponse()
            If response <> 213 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            End If

            Return (Me.responseStr.Substring(4))
        End Function
        ''' <summary>
        ''' GetFileDate will query the ftp server for the date of the remote file.
        ''' </summary>
        ''' <param name="fileName">Remote FileName to Query</param>
        ''' <returns>DateTime of the Input FileName</returns>
        Public Function GetFileDate(fileName As String) As DateTime
            Return ConvertFTPDateToDateTime(GetFileDateRaw(fileName))
        End Function

        Private Function ConvertFTPDateToDateTime(input As String) As DateTime
            If input.Length < 14 Then
                Throw New ArgumentException("Input Value for ConvertFTPDateToDateTime method was too short.")
            End If

            'YYYYMMDDhhmmss": 
            Dim year As Integer = Convert.ToInt16(input.Substring(0, 4))
            Dim month As Integer = Convert.ToInt16(input.Substring(4, 2))
            Dim day As Integer = Convert.ToInt16(input.Substring(6, 2))
            Dim hour As Integer = Convert.ToInt16(input.Substring(8, 2))
            Dim min As Integer = Convert.ToInt16(input.Substring(10, 2))
            Dim sec As Integer = Convert.ToInt16(input.Substring(12, 2))

            Return New DateTime(year, month, day, hour, min, sec)
        End Function
        ''' <summary>
        ''' Get the working directory on the ftp server
        ''' </summary>
        ''' <returns>The working directory</returns>
        Public Function GetWorkingDirectory() As String
            'PWD - print working directory
            Connect()
            SendCommand("PWD")
            ReadResponse()

            If response <> 257 Then
                Throw New Exception(responseStr)
            End If

            Dim pwd As String
            Try
                pwd = responseStr.Substring(responseStr.IndexOf("""", 0) + 1)
                '5);
                pwd = pwd.Substring(0, pwd.LastIndexOf(""""))
                ' directories with quotes in the name come out as "" from the server
                pwd = pwd.Replace("""""", """")
            Catch ex As Exception
                Throw New Exception("Uhandled PWD response: " & ex.Message)
            End Try

            Return pwd
        End Function
        ''' <summary>
        ''' Change to another directory on the ftp server
        ''' </summary>
        ''' <param name="path">Directory to change to</param>
        Public Sub ChangeDir(path As String)
            Connect()
            SendCommand("CWD " & path)
            ReadResponse()
            If response <> 250 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            End If
        End Sub
        ''' <summary>
        ''' Create a directory on the ftp server
        ''' </summary>
        ''' <param name="dir">Directory to create</param>
        Public Sub MakeDir(dir As String)
            Connect()
            SendCommand("MKD " & dir)
            ReadResponse()

            Select Case response
                Case 257, 250
                    Exit Select
                Case Else
#If (FTP_DEBUG) Then
					Console.Write(vbCr & responseStr)
#End If
                    Throw New Exception(responseStr)
            End Select
        End Sub
        ''' <summary>
        ''' Remove a directory from the ftp server
        ''' </summary>
        ''' <param name="dir">Name of directory to remove</param>
        Public Sub RemoveDir(dir As String)
            Connect()
            SendCommand("RMD " & dir)
            ReadResponse()
            If response <> 250 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            End If
        End Sub
        ''' <summary>
        ''' Remove a file from the ftp server
        ''' </summary>
        ''' <param name="filename">Name of the file to delete</param>
        Public Sub RemoveFile(filename As String)
            Connect()
            SendCommand("DELE " & filename)
            ReadResponse()
            If response <> 250 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            End If
        End Sub
        ''' <summary>
        ''' Rename a file on the ftp server
        ''' </summary>
        ''' <param name="oldfilename">Old file name</param>
        ''' <param name="newfilename">New file name</param>
        Public Sub RenameFile(oldfilename As String, newfilename As String)
            ' #######################################
            Connect()
            SendCommand("RNFR " & oldfilename)
            ReadResponse()
            If response <> 350 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            Else
                SendCommand("RNTO " & newfilename)
                ReadResponse()
                If response <> 250 Then
#If (FTP_DEBUG) Then
					Console.Write(vbCr & responseStr)
#End If
                    Throw New Exception(responseStr)
                End If
            End If
        End Sub
        ''' <summary>
        ''' Get the size of a file (Provided the ftp server supports it)
        ''' </summary>
        ''' <param name="filename">Name of file</param>
        ''' <returns>The size of the file specified by filename</returns>
        Public Function GetFileSize(filename As String) As Long
            Connect()
            SendCommand("SIZE " & filename)
            ReadResponse()
            If response <> 213 Then
#If (FTP_DEBUG) Then
				Console.Write(vbCr & responseStr)
#End If
                Throw New Exception(responseStr)
            End If

            Return Int64.Parse(responseStr.Substring(4))
        End Function
        ''' <summary>
        ''' Open an upload with no resume if it already exists
        ''' </summary>
        ''' <param name="filename">File to upload</param>
        Public Sub OpenUpload(filename As String)
            OpenUpload(filename, filename, False)
        End Sub
        ''' <summary>
        ''' Open an upload with no resume if it already exists
        ''' </summary>
        ''' <param name="filename">Local file to upload (Can include path to file)</param>
        ''' <param name="remotefilename">Filename to store file as on ftp server</param>
        Public Sub OpenUpload(filename As String, remotefilename As String)
            OpenUpload(filename, remotefilename, False)
        End Sub
        ''' <summary>
        ''' Open an upload with resume support
        ''' </summary>
        ''' <param name="filename">Local file to upload (Can include path to file)</param>
        ''' <param name="resume">Attempt resume if exists</param>
        Public Sub OpenUpload(filename As String, [resume] As Boolean)
            OpenUpload(filename, filename, [resume])
        End Sub
        ''' <summary>
        ''' Open an upload with resume support
        ''' </summary>
        ''' <param name="filename">Local file to upload (Can include path to file)</param>
        ''' <param name="remote_filename">Filename to store file as on ftp server</param>
        ''' <param name="resume">Attempt resume if exists</param>
        Public Sub OpenUpload(filename As String, remote_filename As String, [resume] As Boolean)
            Connect()
            SetBinaryMode(True)
            OpenDataSocket()

            bytes_total = 0

            Try
                file = New FileStream(filename, FileMode.Open)
            Catch ex As Exception
                file = Nothing
                Throw New Exception(ex.Message)
            End Try

            file_size = file.Length

            If [resume] Then
                Dim size As Long = GetFileSize(remote_filename)
                SendCommand("REST " & size)
                ReadResponse()
                If response = 350 Then
                    file.Seek(size, SeekOrigin.Begin)
                End If
            End If

            SendCommand("STOR " & remote_filename)
            ReadResponse()

            Select Case response
                Case 125, 150
                    Exit Select
                Case Else
                    file.Close()
                    file = Nothing
                    Throw New Exception(responseStr)
            End Select
            ConnectDataSocket()
            ' #######################################	
            Return
        End Sub
        ''' <summary>
        ''' Download a file with no resume
        ''' </summary>
        ''' <param name="filename">Remote file name</param>
        Public Sub OpenDownload(filename As String)
            OpenDownload(filename, filename, False)
        End Sub
        ''' <summary>
        ''' Download a file with optional resume
        ''' </summary>
        ''' <param name="filename">Remote file name</param>
        ''' <param name="resume">Attempt resume if file exists</param>
        Public Sub OpenDownload(filename As String, [resume] As Boolean)
            OpenDownload(filename, filename, [resume])
        End Sub
        ''' <summary>
        ''' Download a file with no attempt to resume
        ''' </summary>
        ''' <param name="filename">Remote filename</param>
        ''' <param name="localfilename">Local filename (Can include path to file)</param>
        Public Sub OpenDownload(filename As String, localfilename As String)
            OpenDownload(filename, localfilename, False)
        End Sub
        ''' <summary>
        ''' Open a file for download
        ''' </summary>
        ''' <param name="remote_filename">The name of the file on the FTP server</param>
        ''' <param name="local_filename">The name of the file to save as (Can include path to file)</param>
        ''' <param name="resume">Attempt resume if file exists</param>
        Public Sub OpenDownload(remote_filename As String, local_filename As String, [resume] As Boolean)
            Connect()
            SetBinaryMode(True)

            bytes_total = 0

            Try
                file_size = GetFileSize(remote_filename)
            Catch
                file_size = 0
            End Try

            If [resume] AndAlso IO.File.Exists(local_filename) Then
                Try
                    file = New FileStream(local_filename, FileMode.Open)
                Catch ex As Exception
                    file = Nothing
                    Throw New Exception(ex.Message)
                End Try

                SendCommand("REST " & file.Length)
                ReadResponse()
                If response <> 350 Then
                    Throw New Exception(responseStr)
                End If
                file.Seek(file.Length, SeekOrigin.Begin)
                bytes_total = file.Length
            Else
                Try
                    file = New FileStream(local_filename, FileMode.Create)
                Catch ex As Exception
                    file = Nothing
                    Throw New Exception(ex.Message)
                End Try
            End If

            OpenDataSocket()
            SendCommand("RETR " & remote_filename)
            ReadResponse()

            Select Case response
                Case 125, 150
                    Exit Select
                Case Else
                    file.Close()
                    file = Nothing
                    Throw New Exception(responseStr)
            End Select
            ConnectDataSocket()
            ' #######################################	
            Return
        End Sub
        ''' <summary>
        ''' Upload the file, to be used in a loop until file is completely uploaded
        ''' </summary>
        ''' <returns>Bytes sent</returns>
        Public Function DoUpload() As Long
            Dim bytes As [Byte]() = New [Byte](511) {}
            Dim bytes_got As Long

            Try
                bytes_got = file.Read(bytes, 0, bytes.Length)
                bytes_total += bytes_got
                data_sock.Send(bytes, CInt(bytes_got), 0)

                If bytes_got <= 0 Then
                    ' the upload is complete or an error occured
                    file.Close()
                    file = Nothing

                    CloseDataSocket()
                    ReadResponse()
                    Select Case response
                        Case 226, 250
                            Exit Select
                        Case Else
                            Throw New Exception(responseStr)
                    End Select

                    SetBinaryMode(False)
                End If
            Catch ex As Exception
                file.Close()
                file = Nothing
                CloseDataSocket()
                ReadResponse()
                SetBinaryMode(False)
                Throw ex
            End Try

            Return bytes_got
        End Function
        ''' <summary>
        ''' Download a file, to be used in a loop until the file is completely downloaded
        ''' </summary>
        ''' <returns>Number of bytes recieved</returns>
        Public Function DoDownload() As Long
            Dim bytes As [Byte]() = New [Byte](511) {}
            Dim bytes_got As Long

            Try
                bytes_got = data_sock.Receive(bytes, bytes.Length, 0)

                If bytes_got <= 0 Then
                    ' the download is done or an error occured
                    CloseDataSocket()
                    file.Close()
                    file = Nothing

                    ReadResponse()
                    Select Case response
                        Case 226, 250
                            Exit Select
                        Case Else
                            Throw New Exception(responseStr)
                    End Select

                    SetBinaryMode(False)

                    Return bytes_got
                End If

                file.Write(bytes, 0, CInt(bytes_got))
                bytes_total += bytes_got
            Catch ex As Exception
                CloseDataSocket()
                file.Close()
                file = Nothing
                ReadResponse()
                SetBinaryMode(False)
                Throw ex
            End Try

            Return bytes_got
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace