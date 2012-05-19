Imports System.IO
Imports System.Text
Imports Microsoft.CSharp
Imports System.Resources
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.CodeDom.Compiler
Imports System.Collections.Generic

' * Made by: Ethernal Five
' * Released on 29 jan 2012
' * Released on: Hackforums.net, Leetcoders.org & forums.virtuouscoding.net/
' * If you use this, please credit me. I've put alot of work in it.
' a as string = "' * Made by: Ethernal Five"

#Region "Enums"
''' <summary>
''' The programming languages which codedom can compile.
''' </summary>
Public Enum Language
    VisualBasic
    CSharp
End Enum

''' <summary>
''' How you're assembly will compile. Default setting is Console.
''' </summary>
Public Enum Target
    ''' <summary>
    ''' An Windows forms application.
    ''' </summary>
    WinForms
    ''' <summary>
    ''' A Windows console application.
    ''' </summary>
    Console
    ''' <summary>
    ''' A Windows Dynamic Link Library(DLL) application.
    ''' </summary>
    Library
End Enum

''' <summary>
''' The .NET version you're compiled file will use.
''' </summary>
Public Enum DotNetVersion
    ''' <summary>
    ''' .NET Version 2.0
    ''' </summary>
    v2
    ''' <summary>
    ''' .NET Version 3.0
    ''' </summary>
    v3
    ''' <summary>
    ''' .NET Version 3.5
    ''' </summary>
    v35
    ''' <summary>
    ''' .NET Version 4.0
    ''' </summary>
    v4
End Enum

''' <summary>
''' The Filealign option lets you specify the size of sections in your output file. Default value is 1024.
''' </summary>
Public Enum File_Align
    _512
    _1024
    _2048
    _4096
    _8192
End Enum

''' <summary>
''' Specifies which version of the common language runtime (CLR) can run the assembly. Default value is anycpu.
''' </summary>
Public Enum Platform
    ''' <summary>
    ''' x86 compiles your assembly to be run by the 32-bit, x86-compatible common language runtime.
    ''' </summary>
    x86
    ''' <summary>
    ''' Itanium compiles your assembly to be run by the 64-bit common language runtime on a computer with an Itanium processor.
    ''' </summary>
    Itanium
    ''' <summary>
    ''' x64 compiles your assembly to be run by the 64-bit common language runtime on a computer that supports the AMD64 or EM64T instruction set.
    ''' </summary>
    x64
    ''' <summary>
    ''' anycpu compiles your assembly to run on any platform.
    ''' </summary>
    AnyCPU
End Enum
#End Region

Public Class Compiler
    Const a As String = "' * Made by: Ethernal Five"

#Region "Properties"
    Private _language As Language = Language.VisualBasic
    ''' <summary>
    ''' The programming language you wish to compile. Default language is Visual Basic.
    ''' </summary>
    Public Property Language() As Language
        Get
            Return _language
        End Get
        Set(ByVal value As Language)
            _language = value
        End Set
    End Property

    Private _netversion As DotNetVersion = DotNetVersion.v4
    ''' <summary>
    ''' The .NET version you're compiled file will use. Default version is 4.0.
    ''' </summary>
    Public Property DotNetVersion() As DotNetVersion
        Get
            Return _netversion
        End Get
        Set(ByVal value As DotNetVersion)
            _netversion = value
        End Set
    End Property

    Private _filealign As File_Align = File_Align._1024
    ''' <summary>
    ''' The Filealign option lets you specify the size of sections in your output file. Default value is 1024.
    ''' </summary>
    Public Property File_Align() As File_Align
        Get
            Return _filealign
        End Get
        Set(ByVal value As File_Align)
            _filealign = value
        End Set
    End Property

    Private _target As Target = Target.Console
    ''' <summary>
    ''' How you're assembly will compile. Default setting is Console.
    ''' </summary>
    Public Property Target() As Target
        Get
            Return _target
        End Get
        Set(ByVal value As Target)
            _target = value
        End Set
    End Property

    Private _platform As Platform = Platform.AnyCPU
    ''' <summary>
    ''' Specifies which version of the common language runtime (CLR) can run the assembly. Default value is AnyCPU.
    ''' </summary>
    Public Property Platform() As Platform
        Get
            Return _platform
        End Get
        Set(ByVal value As Platform)
            _platform = value
        End Set
    End Property

    Private _icon As String = String.Empty
    ''' <summary>
    ''' The Icon to be used with you're file. Must be a path to an .ico file.
    ''' </summary>
    Public Property Icon() As String
        Get
            Return _icon
        End Get
        Set(ByVal value As String)
            _icon = value
        End Set
    End Property

    Private _executeaftercompiled As Boolean = False
    ''' <summary>
    ''' If true, it will execute the assembly after it has been compiled. Default value is false.
    ''' </summary>
    Public Property ExecuteAfterCompiled() As Boolean
        Get
            Return _executeaftercompiled
        End Get
        Set(ByVal value As Boolean)
            _executeaftercompiled = value
        End Set
    End Property

    Private _silentmode As Boolean = False
    ''' <summary>
    ''' If Silent Mode is true, then there will be no error and succes messages displayed. Default value is false.
    ''' </summary>
    Public Property SilentMode() As Boolean
        Get
            Return _silentmode
        End Get
        Set(ByVal value As Boolean)
            _silentmode = value
        End Set
    End Property

    Private _source As String = String.Empty
    ''' <summary>
    ''' The code you want to compile to an executable. Must be specified.
    ''' </summary>
    Public Property Source() As String
        Get
            Return _source
        End Get
        Set(ByVal value As String)
            _source = value
        End Set
    End Property

    Private _references As String() = Nothing
    ''' <summary>
    ''' The assemblies you want to reference. For example if you are using forms, you should reference System.Windows.Forms.dll. As default System.dll is already added.
    ''' </summary>
    Public Property References() As String()
        Get
            Return _references
        End Get
        Set(ByVal value As String())
            _references = value
        End Set
    End Property

    Private _appconfig As String = String.Empty
    ''' <summary>
    ''' The AppConfig compiler option enables a C# application to specify the location of an assembly's application configuration (app.config) file to the common language runtime (CLR) at assembly binding time.
    ''' </summary>
    Public Property AppConfig() As String
        Get
            Return _appconfig
        End Get
        Set(ByVal value As String)
            _appconfig = value
        End Set
    End Property

    Private _optimize As Boolean = False
    ''' <summary>
    ''' The Optimize option enables or disables optimizations performed by the compiler to make your output file smaller, faster, and more efficient. Default is false.
    ''' </summary>
    Public Property Optimize() As Boolean
        Get
            Return _optimize
        End Get
        Set(ByVal value As Boolean)
            _optimize = value
        End Set
    End Property

    Private _unsafe As Boolean = False
    ''' <summary>
    ''' The Unsafe compiler option allows code that uses the unsafe keyword to compile. Default is false.
    ''' </summary>
    Public Property Unsafe() As Boolean
        Get
            Return _unsafe
        End Get
        Set(ByVal value As Boolean)
            _unsafe = value
        End Set
    End Property

    Private _debug As Boolean = False
    ''' <summary>
    ''' The Debug option causes the compiler to generate debugging information and place it in the output file or files.
    ''' </summary>
    Public Property Debug() As Boolean
        Get
            Return _debug
        End Get
        Set(ByVal value As Boolean)
            _debug = value
        End Set
    End Property

    Private _optionalparameters As String = String.Empty
    ''' <summary>
    ''' With this option you can specify you're own compiler options, like /keyfile. For advanced users only.
    ''' </summary>
    Public Property Optional_Parameters() As String
        Get
            Return _optionalparameters
        End Get
        Set(ByVal value As String)
            _optionalparameters = value
        End Set
    End Property

    Private _errorlog As Boolean = False
    ''' <summary>
    ''' Creates an error log file if any errors occur. Default is false.
    ''' </summary>
    Public Property ErrorLog() As Boolean
        Get
            Return _errorlog
        End Get
        Set(ByVal value As Boolean)
            _errorlog = value
        End Set
    End Property

    ''' <summary>
    ''' Add a resource. Parameter name must be the file to the resource. This could be any file you want.
    ''' </summary>
    Public Sub AddResource(ByVal file__1 As String)
        If Not Directory.Exists("Resources") Then
            Directory.CreateDirectory("Resources")
        End If
        File.WriteAllBytes("Resources\" & Path.GetFileName(file__1), File.ReadAllBytes(file__1))
    End Sub
#End Region

#Region "Compile"
    Private newline As String = Environment.NewLine
    ''' <summary>
    ''' Compiles the assembly.
    ''' </summary>
    Public Sub Compile(ByVal OutputPath As String)
        Try
            If Not String.IsNullOrEmpty(_source) Then
                If Not String.IsNullOrEmpty(OutputPath) Then
                    If Directory.Exists("Resources") AndAlso Directory.GetFiles("Resources\") IsNot Nothing Then
                        Dim w As New ResourceWriter("res.resources")
                        For Each resource As String In Directory.GetFiles("Resources\")
                            If Path.GetExtension(resource) <> ".db" Then
                                w.AddResource(resource, File.ReadAllBytes(resource))
                            End If
                        Next
                        w.Close()
                    End If

                    Dim p As New CompilerParameters()
                    Dim sb As New StringBuilder()
                    p.OutputAssembly = OutputPath
                    If References Is Nothing Then
                        References = New String() {"System.dll"}
                    End If
                    p.ReferencedAssemblies.AddRange(References)
                    If Directory.Exists("Resources") Then
                        p.EmbeddedResources.Add("res.resources")
                    End If
                    If _icon <> String.Empty Then
                        sb.Append(" /win32icon:""" & _icon & """")
                    End If

                    Select Case Target
                        Case Target.Console
                            sb.Append(" /target:exe")
                            p.GenerateExecutable = True
                            Exit Select
                        Case Target.WinForms
                            sb.Append(" /target:winexe")
                            p.GenerateExecutable = True
                            Exit Select
                        Case Target.Library
                            sb.Append(" /target:library")
                            p.GenerateExecutable = False
                            Exit Select
                    End Select

                    Select Case File_Align
                        Case File_Align._512
                            sb.Append(" /filealign:512")
                            Exit Select
                        Case File_Align._1024
                            sb.Append(" /filealign:1024")
                            Exit Select
                        Case File_Align._2048
                            sb.Append(" /filealign:2048")
                            Exit Select
                        Case File_Align._4096
                            sb.Append(" /filealign:4096")
                            Exit Select
                        Case File_Align._8192
                            sb.Append(" /filealign:8192")
                            Exit Select
                    End Select

                    Select Case Platform
                        Case Platform.AnyCPU
                            sb.Append(" /platform:AnyCPU")
                            Exit Select
                        Case Platform.Itanium
                            sb.Append(" /platform:Itanium")
                            Exit Select
                        Case Platform.x64
                            sb.Append(" /platform:x64")
                            Exit Select
                        Case Platform.x86
                            sb.Append(" /platform:x86")
                            Exit Select
                    End Select
                    If AppConfig <> String.Empty AndAlso Language = Language.CSharp Then
                        sb.Append(" /appconfig:" & AppConfig)
                    End If
                    If _optionalparameters <> String.Empty Then
                        For Each param As String In _optionalparameters.Split("/"c)
                            Dim durr As String = " /" & param
                            If durr <> " /" AndAlso durr <> "/" Then
                                sb.Append(durr)
                            End If
                        Next
                    End If
                    If _optimize = True Then
                        sb.Append(" /optimize+")
                    End If
                    If _unsafe = True Then
                        sb.Append(" /unsafe")
                    End If
                    If _debug = True Then
                        sb.Append(" /debug:full")
                    End If
                    p.CompilerOptions = sb.ToString()

                    If Target = Target.Library AndAlso Path.GetExtension(OutputPath) = ".exe" AndAlso SilentMode = False Then
                        If MessageBox.Show("You are compiling an Dynamic Link Library, but you are using .exe instead of .dll as extension." & newline & "Do you want to continue?", "Compiler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                            Return
                        End If
                    End If

                    Dim ProviderOptions = New Dictionary(Of String, String)()
                    Select Case DotNetVersion
                        Case DotNetVersion.v2
                            ProviderOptions.Add("CompilerVersion", "v2.0")
                            Exit Select
                        Case DotNetVersion.v3
                            ProviderOptions.Add("CompilerVersion", "v3.0")
                            Exit Select
                        Case DotNetVersion.v35
                            ProviderOptions.Add("CompilerVersion", "v3.5")
                            Exit Select
                        Case DotNetVersion.v4
                            ProviderOptions.Add("CompilerVersion", "v4.0")
                            Exit Select
                    End Select

                    Dim results As CompilerResults = Nothing
                    Select Case Language
                        Case Language.CSharp
                            results = New CSharpCodeProvider(ProviderOptions).CompileAssemblyFromSource(p, Source)
                            Exit Select
                        Case Language.VisualBasic
                            results = New VBCodeProvider(ProviderOptions).CompileAssemblyFromSource(p, Source)
                            Exit Select
                    End Select
                    results.TempFiles.Delete()

                    Try
                        File.Delete("res.resources")
                        Directory.Delete("Resources", True)
                    Catch
                    End Try

                    If results.Errors.Count > 0 Then
                        If SilentMode = False Then
                            MessageBox.Show("Compiler encountered " & results.Errors.Count & " errors.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
                            For Each err As CompilerError In results.Errors
                                MessageBox.Show(err.ErrorText & newline & "Collumn " & err.Column & ", Line " & err.Line & newline & err.FileName, "Compiler", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                                If _errorlog = True Then
                                    File.AppendAllText("error.log", DateTime.Now & newline & err.ErrorText & newline & "Collumn " & err.Column & ", Line " & err.Line & newline & err.FileName & newline)
                                End If
                            Next
                        End If
                    Else
                        If SilentMode = False Then
                            MessageBox.Show("Succesfully compiled!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        If ExecuteAfterCompiled Then
                            Process.Start(OutputPath)
                        End If
                    End If
                Else
                    Throw New ArgumentException("Please provide the output path to write to compiled executable.", "EthernalCompiler.Output = ""<path to output file here>""")
                End If
            Else
                Throw New ArgumentException("Please provide the source code to compile into an Windows executable.", "EthernalCompiler.CodeToCompile = ""<code to compile here>""")
            End If
        Catch err As Exception
            MessageBox.Show(err.Message & newline & "Stack Trace " & err.StackTrace & newline & "Inner Exception: " & Convert.ToString(err.InnerException), "Compiler", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
#End Region
End Class