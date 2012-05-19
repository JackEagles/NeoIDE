' Below is description for all versions of RichEdit. Unfortunately, 
' * starting from version 4.1 there is no any documentation available. :-(
' * 
' * ### RichEdit 1.0 Features
' * Basic nonUnicode editing, cut/copy/paste, file streaming 
' * Basic set of character/paragraph formatting properties 
' * Message-based interface plus OLE interfaces: IRichEditOle and IRichEditOleCallback 
' * Vertical text and IME support (FE builds only). 
' * WYSIWYG editing using printer metrics 
' * Different builds for different scripts 
' * Common-control notifications plus some new ones 
' * Plain text and RTF files 
' * Pen-enabled and understood gestures for use with Pen Windows
' * 
' * 
' * ### RichEdit 2.0 Additions 
' * Unicode internally + able to read/write using codepages 
' * International line breaking algorithm 
' * Find Up/Down. Magellan mouse support. 
' * Multilevel undo 
' * BiDi (RE 2.1) and FE support including level 2/3 IME, dual font, keyboard linking, smart font apply 
' * AutoURL recognition. Word UI 
' * Plain/rich, single-line/multiline, scalable architecture 
' * Password and accelerator control options 
' * Windowless interfaces (ITextHost/ITextServices) 
' * Better display (mixed fonts use off-screen bitmap), system selection colors, transparency support 
' * TOM (Text Object Model) dual interfaces 
' * Character formatting additions include background color, locale ID, underline type, superscript/subscript. 
' * Paragraph formatting additions include space before/after, line spacing. 
' * Roundtrip all Word Format Font/Para dialog properties 
' * Extensive code stabilization, testing, performance increase
' * 
' * 
' * ### RichEdit 2.5 Additions 
' * First Windows CE version. Used by Pocket Word 
' * Outline view, normal and heading styles 
' * RTF additions 
' * Minor UI improvements 
' * Western languages only 
' * 
' * 
' * ### RichEdit 3.0 Additions 
' * Used for emulating RichEdit 1.0's 
' * Zoom 
' * Italics caret/cursor. URL hand cursor 
' * Paragraph numbering (alpha, numeric, Roman) 
' * Simple tables (no wrap in cells) 
' * More underline types, underline coloring, hidden text 
' * More of Word's default hot keys, e.g., accent dead keys, outline view, numbering 
' * Smart quotes (English only), soft hyphens 
' * Use Office's LineServices component to break/display lines. Used for complex scripts and options like center, right, decimal tabs, fully justified text 
' * Complex script support for BiDi, Indic, and Thai with help from LineServices and Uniscribe components 
' * Font Binding based on charset, which acts as writing system ID 
' * Codepage-specific stream in/out 
' * UTF-8 RTF. Used preferentially for cut/copy/paste. Can be streamed in/out. 
' * Office 9 IME support (MSIME98) including Reconversion, Document feed, Mouse Operation, and Caret position features 
' * AIMM component IME support for nonFE systems. 
' * Increased freeze and undo/redo control 
' * Font increment/decrement function 
' * System edit control, list box, and combo box controls 
' * Alt+x input method 
' * Used to emulate RichEdit 1.0's 
' * 
' * 
' * ### RichEdit 3.5 Additions 
' * Second Windows CE release. Used by eBooks 
' * Screen-size pagination 
' * Text wrap around objects flushed left/right 
' * Custom ClearType support 
' * Enhanced East Asian typography 
' * 
' * ### RichEdit 4.0 Additions 
' * Multilevel tables 
' * Autocorrect 
' * Improved autoURL detection 
' * Friendly name hyperlinks 
' * Font binding according to writing system (generalization of charset) 
' * Indic support 
' * Vertical text 
' * Support for the latest IMEs 
' * Speech and handwriting input (Windows Text Services Framework) 
' * More standard hot keys 
' * Many security fixes (3.0 has also) 
' * 
' * 
' * ### RichEdit 5.0 Additions 
' * Multiselection, smart drag&drop 
' * Better nested tables, horizontally merged cells 
' * Better font binding/international support 
' * More underline styles, small cap & shadow emulation 
' * Binary file format: "parsed XML" 
' * Partial XHTML reader/writer 
' * Subpixel ClearType support 
' * Better RTF handling, e.g., multilevel lists 
' * URL tooltips 
' * Many bug/minor-request fixes 
' * Improved ink support, especially for OneNote 
' * Advanced East Asian typography 
' * Initial PTS integration, including object tight wrap 
' * Infrastructure for math, ruby, warichu, tatenakayoko 
' * Text trackers and blobs 
' * 
' * 
' * ### RichEdit 5.1 
' * Third Windows CE release. Used by Pocket Word 
' * Various UI and RTF enhancements 
' * 
' * 
' * ### RichEdit 6.0 Additions 
' * High-quality editing & display of math 
' * Formula autobuildup 
' * Create and support math linear format 
' * More list numbering options 
' * Simple "visi" mode 
' * URL improvements
' * Multistory: high-perf cut/copy/paste, rich scratchpads, WP infrastructure 
' * Text Object Model 2 
' * Display enhancements, e.g., word underline, horizontal scaling 
' * Table UI adds, e.g., column resizing 
' * OfficeArt/PowerPoint enhancements 
' * Overlapping lines, drop caps & other ePeriodicals improvements 
' * Device independent layout 
' * Virtualized OS: "hDC" is totally opaque 
' * Multiple columns
' * Myriad security fixes
' * 
' * 
' * ### RichEdit 5.0 ###
' * It is distributed with Microsoft Office 2003. It is located in
' * X:\Program Files\Common Files\Microsoft Shared\OFFICE11 (replace X: with correspond letter)
' * 
' * 
' * ### RichEdit 6.0 ###
' * It is distributed with Microsoft Office 2007. It is located in
' * X:\Program Files\Common Files\Microsoft Shared\OFFICE12 (replace X: with correspond letter)
' * 
' * 
' * Versions 5.0 and 6.0 has the same DLL name - RICHED20.DLL.
' * 
' * 
' * REMEMBER!!! There is no documentation. Using o
' * 
' 



Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Security.Permissions

''' <summary>
''' This ExtendedRichTextBox is based on .NET Framework and also uses WinAPI
''' to extend its functionality. It also contains wrappers for TOM 
''' (Text Object Model) and for OLE (Object Linking and Embedding - this
''' code was written by Oscar Londoño, go to 
''' 
''' http://www.codeproject.com/KB/edit/MyExtRichTextBox.aspx 
''' 
''' for more details)
''' </summary>
<Serializable()> _
Public Class ExtendedRichTextBox
    Inherits RichTextBox
#Region "CONSTRUCTOR"
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function LoadLibrary(ByVal libname As String) As IntPtr
    End Function

    Private Shared RichEditModuleHandle As IntPtr
    'Libraries
    Private Const RichEditDllV3 As String = "RichEd20.dll"
    Private Const RichEditDllV41 As String = "Msftedit.dll"
    'You can also specify



    'Class names
    Private Const RichEditClassV3A As String = "RichEdit20A"
    Private Const RichEditClassV3W As String = "RichEdit20W"
    Private Const RichEditClassV41W As String = "RICHEDIT50W"
    Private Const RichEditClass50 As String = "RichEdit50W"
    'Office 2003 required
    Private Const RichEditClass60 As String = "RichEdit60W"
    'Office 2007 required
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode:=True)> _
        Get
            'Check the existence of the library
            RichEditModuleHandle = LoadLibrary(RichEditDllV41)
            If RichEditModuleHandle = IntPtr.Zero Then
                Return MyBase.CreateParams
            End If

            Dim par As CreateParams = MyBase.CreateParams
            'Assign correspond class name
            par.ClassName = RichEditClassV41W
            Return par
        End Get
    End Property

    Private dropPath As String = ""
    Public Sub New()
        Me.EnableAutoDragDrop = False
        SetLayoutType(LayoutModes.WYSIWYG)
    End Sub
#End Region

#Region "PARAFORMAT MASKS"
    Private Const PFN_BULLET As UInteger = &H1

    Private Const PFM_STARTINDENT As UInteger = &H1
    Private Const PFM_RIGHTINDENT As UInteger = &H2
    Private Const PFM_OFFSET As UInteger = &H4
    Private Const PFM_ALIGNMENT As UInteger = &H8
    Private Const PFM_TABSTOPS As UInteger = &H10
    Private Const PFM_NUMBERING As UInteger = &H20
    Private Const PFM_OFFSETINDENT As UInteger = &H80000000UI

    Private Const PFM_SPACEBEFORE As UInteger = &H40
    Private Const PFM_SPACEAFTER As UInteger = &H80
    Private Const PFM_LINESPACING As UInteger = &H100
    Private Const PFM_STYLE As UInteger = &H400
    Private Const PFM_BORDER As UInteger = &H800
    ' (*)	
    Private Const PFM_SHADING As UInteger = &H1000
    ' (*)	
    Private Const PFM_NUMBERINGSTYLE As UInteger = &H2000
    ' (*)	
    Private Const PFM_NUMBERINGTAB As UInteger = &H4000
    ' (*)	
    Private Const PFM_NUMBERINGSTART As UInteger = &H8000
    ' (*)	

    Private Const PFM_DIR As UInteger = &H10000
    Private Const PFM_RTLPARA As UInteger = &H10000
    ' (Version 1.0 flag) 
    Private Const PFM_KEEP As UInteger = &H20000
    ' (*)	
    Private Const PFM_KEEPNEXT As UInteger = &H40000
    ' (*)	
    Private Const PFM_PAGEBREAKBEFORE As UInteger = &H80000
    ' (*)	
    Private Const PFM_NOLINENUMBER As UInteger = &H100000
    ' (*)	
    Private Const PFM_NOWIDOWCONTROL As UInteger = &H200000
    ' (*)	
    Private Const PFM_DONOTHYPHEN As UInteger = &H400000
    ' (*)	
    Private Const PFM_SIDEBYSIDE As UInteger = &H800000
    ' (*)	

    Private Const PFM_TABLE As UInteger = &HC0000000UI
    ' (*)	

#End Region

#Region "CHARFORMAT MASKS"
    Private Const CFM_BOLD As UInteger = &H1
    Private Const CFM_ITALIC As UInteger = &H2
    Private Const CFM_UNDERLINE As UInteger = &H4
    Private Const CFM_STRIKEOUT As UInteger = &H8
    Private Const CFM_PROTECTED As UInteger = &H10
    Private Const CFM_LINK As UInteger = &H20
    ' This is for hyperlinks in document 
    Private Const CFM_SIZE As UInteger = &H80000000UI
    Private Const CFM_COLOR As UInteger = &H40000000
    Private Const CFM_FACE As UInteger = &H20000000
    Private Const CFM_OFFSET As UInteger = &H10000000
    Private Const CFM_CHARSET As UInteger = &H8000000

    Private Const CFM_FONTSTYLE_EFFECTS As UInteger = (CFM_BOLD Or CFM_ITALIC Or CFM_UNDERLINE Or CFM_STRIKEOUT Or CFM_LINK)
    Private Const CFM_FORMATTING_EFFECTS As UInteger = (CFM_BOLD Or CFM_ITALIC Or CFM_UNDERLINE Or CFM_STRIKEOUT Or CFM_LINK Or CFM_COLOR)

    ' (*) 
    ' this means supported but not displayed.

    Private Const CFM_SMALLCAPS As UInteger = &H40
    ' (*) 
    Private Const CFM_ALLCAPS As UInteger = &H80
    ' (*) 
    Private Const CFM_HIDDEN As UInteger = &H100
    ' (*) 
    Private Const CFM_OUTLINE As UInteger = &H200
    ' (*) 
    Private Const CFM_SHADOW As UInteger = &H400
    ' (*) 
    Private Const CFM_EMBOSS As UInteger = &H800
    ' (*) 
    Private Const CFM_IMPRINT As UInteger = &H1000
    ' (*) 
    Private Const CFM_DISABLED As UInteger = &H2000
    Private Const CFM_REVISED As UInteger = &H4000

    Private Const CFM_BACKCOLOR As UInteger = &H4000000
    Private Const CFM_LCID As UInteger = &H2000000
    Private Const CFM_UNDERLINETYPE As UInteger = &H800000
    ' (*) 
    Private Const CFM_WEIGHT As UInteger = &H400000
    Private Const CFM_SPACING As UInteger = &H200000
    ' (*) 
    Private Const CFM_KERNING As UInteger = &H100000
    ' (*) 
    Private Const CFM_STYLE As UInteger = &H80000
    ' (*) 
    Private Const CFM_ANIMATION As UInteger = &H40000
    ' (*) 
    Private Const CFM_REVAUTHOR As UInteger = &H8000
#End Region

#Region "PARAFORMAT EFFECTS"
    Private Const PFE_RTLPARA As UInteger = (PFM_DIR >> 16)
    Private Const PFE_RTLPAR As UInteger = (PFM_RTLPARA >> 16)
    ' (Version 1.0 flag) 
    Private Const PFE_KEEP As UInteger = (PFM_KEEP >> 16)
    ' (*) 
    Private Const PFE_KEEPNEXT As UInteger = (PFM_KEEPNEXT >> 16)
    ' (*) 
    Private Const PFE_PAGEBREAKBEFORE As UInteger = (PFM_PAGEBREAKBEFORE >> 16)
    ' (*) 
    Private Const PFE_NOLINENUMBER As UInteger = (PFM_NOLINENUMBER >> 16)
    ' (*) 
    Private Const PFE_NOWIDOWCONTROL As UInteger = (PFM_NOWIDOWCONTROL >> 16)
    ' (*) 
    Private Const PFE_DONOTHYPHEN As UInteger = (PFM_DONOTHYPHEN >> 16)
    ' (*) 
    Private Const PFE_SIDEBYSIDE As UInteger = (PFM_SIDEBYSIDE >> 16)
    ' (*) 

    Private Const PFE_TABLEROW As UInteger = &HC000
    ' These 3 options are mutually	
    Private Const PFE_TABLECELLEND As UInteger = &H8000
    ' exclusive and each imply	    
    Private Const PFE_TABLECELL As UInteger = &H4000
    ' hat para is part of a table  
#End Region

#Region "CHARFORMAT EFFECTS"
    Private Const CFE_BOLD As UInteger = &H1
    Private Const CFE_ITALIC As UInteger = &H2
    Private Const CFE_UNDERLINE As UInteger = &H4
    Private Const CFE_STRIKEOUT As UInteger = &H8
    Private Const CFE_LINK As UInteger = &H20

    Private Const CFE_SUBSCRIPT As UInteger = &H10000
    ' Superscript and subscript are 
    Private Const CFE_SUPERSCRIPT As UInteger = &H20000
    '  mutually exclusive 

    Private Const CFE_AUTOCOLOR As UInteger = &H40000000
#End Region

#Region "FORMAT_RANGE_CONSTANTS"
    Private Const SCF_SELECTION As Integer = &H1
    Private Const SCF_WORD As Integer = &H2
    Private Const SCF_DEFAULT As Integer = &H0
    ' set the default charformat or paraformat
    Private Const SCF_ALL As Integer = &H4
    ' not valid with SCF_SELECTION or SCF_WORD
    Private Const SCF_USEUIRULES As Integer = &H8
#End Region

#Region "TEXT OBJECT MODEL"
    Public Class WinAPI
        <DllImport("user32.dll")> _
        Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, <MarshalAs(UnmanagedType.IUnknown)> ByRef lParam As Object) As IntPtr
        End Function
    End Class

    Public Enum tomConstants As Integer
        tomFalse = 0
        tomTrue = -1
        tomUndefined = -9999999
        tomToggle = -9999998
        tomAutoColor = -9999997
        tomDefault = -9999996
        tomBackward = -1073741823
        tomForward = 1073741823
        tomMove = 0
        tomExtend = 1
        tomNoSelection = 0
        tomSelectionIP = 1
        tomSelectionNormal = 2
        tomSelectionFrame = 3
        tomSelectionColumn = 4
        tomSelectionRow = 5
        tomSelectionBlock = 6
        tomSelectionInlineShape = 7
        tomSelectionShape = 8
        tomSelStartActive = 1
        tomSelAtEOL = 2
        tomSelOvertype = 4
        tomSelActive = 8
        tomSelReplace = 16
        tomEnd = 0
        tomStart = 32
        tomCollapseEnd = 0
        tomCollapseStart = 1
        tomNone = 0
        tomSingle = 1
        tomWords = 2
        tomDouble = 3
        tomDotted = 4
        tomLineSpaceSingle = 0
        tomLineSpace1pt5 = 1
        tomLineSpaceDouble = 2
        tomLineSpaceAtLeast = 3
        tomLineSpaceExactly = 4
        tomLineSpaceMultiple = 5
        tomAlignLeft = 0
        tomAlignCenter = 1
        tomAlignRight = 2
        tomAlignJustify = 3
        tomAlignDecimal = 3
        tomAlignBar = 4
        tomSpaces = 0
        tomDots = 1
        tomDashes = 2
        tomLines = 3
        tomTabBack = -3
        tomTabNext = -2
        tomTabHere = -1
        tomListNone = 0
        tomListBullet = 1
        tomListNumberAsArabic = 2
        tomListNumberAsLCLetter = 3
        tomListNumberAsUCLetter = 4
        tomListNumberAsLCRoman = 5
        tomListNumberAsUCRoman = 6
        tomListNumberAsSequence = 7
        tomListParentheses = 65536
        tomListPeriod = 131072
        tomListPlain = 196608
        tomCharacter = 1
        tomWord = 2
        tomSentence = 3
        tomParagraph = 4
        tomLine = 5
        tomStory = 6
        tomScreen = 7
        tomSection = 8
        tomColumn = 9
        tomRow = 10
        tomWindow = 11
        tomCell = 12
        tomCharFormat = 13
        tomParaFormat = 14
        tomTable = 15
        tomObject = 16
        tomMatchWord = 2
        tomMatchCase = 4
        tomMatchPattern = 8
        tomUnknownStory = 0
        tomMainTextStory = 1
        tomFootnotesStory = 2
        tomEndnotesStory = 3
        tomCommentsStory = 4
        tomTextFrameStory = 5
        tomEvenPagesHeaderStory = 6
        tomPrimaryHeaderStory = 7
        tomEvenPagesFooterStory = 8
        tomPrimaryFooterStory = 9
        tomFirstPageHeaderStory = 10
        tomFirstPageFooterStory = 11
        tomNoAnimation = 0
        tomLasVegasLights = 1
        tomBlinkingBackground = 2
        tomSparkleText = 3
        tomMarchingBlackAnts = 4
        tomMarchingRedAnts = 5
        tomShimmer = 6
        tomWipeDown = 7
        tomWipeRight = 8
        tomAnimationMax = 8
        tomLowerCase = 0
        tomUpperCase = 1
        tomTitleCase = 2
        tomSentenceCase = 4
        tomToggleCase = 5
        tomReadOnly = 256
        tomShareDenyRead = 512
        tomShareDenyWrite = 1024
        tomPasteFile = 4096
        tomCreateNew = 16
        tomCreateAlways = 32
        tomOpenExisting = 48
        tomOpenAlways = 64
        tomTruncateExisting = 80
        tomRTF = 1
        tomText = 2
        tomHTML = 3
        tomWordDocument = 4
    End Enum

    Public Interface ITextDocument
        '{8CC497C0-A1DF-11CE-8098-00AA0047BE5D}
        ReadOnly Property Name() As [String]

        ReadOnly Property Selection() As ITextSelection
        ReadOnly Property StoryRanges() As ITextStoryRanges
        Function Range(ByVal cp1 As Long, ByVal cp2 As Long) As ITextRange
        Function RangeFromPoint(ByVal x As Long, ByVal y As Long) As ITextRange

        ReadOnly Property StoryCount() As Int32

        Property Saved() As Int32

        Property DefaultTabStop() As [Single]

        Sub [New]()

        Sub Open(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As String, ByVal Flags As Int32, ByVal CodePage As Int32)
        Sub Save(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As String, ByVal Flags As Int32, ByVal CodePage As Int32)

        Function Freeze() As Int32
        Function Unfreeze() As Int32

        Sub BeginEditCollection()
        Sub EndEditCollection()

        Function Undo(ByVal Count As Int32) As Int32
        Function Redo(ByVal Count As Int32) As Int32



    End Interface
    Public Interface ITextFont
        '{8CC497C3-A1DF-11CE-8098-00AA0047BE5D}
        ReadOnly Property Duplicate() As ITextFont
        Function CanChange() As Int32
        Function IsEqual(ByVal pFont As ITextFont) As Int32
        Sub Reset(ByVal Value As Int32)
        Property Style() As Int32
        Property AllCaps() As Int32
        Property Animation() As Int32
        Property BackColor() As Int32
        Property Bold() As Int32
        Property Emboss() As Int32
        Property ForeColor() As Int32
        Property Hidden() As Int32
        Property Engrave() As Int32
        Property Italic() As Int32
        Property Kerning() As [Single]
        Property LanguageID() As Int32
        Property Name() As [String]
        Property Outline() As Int32
        Property Position() As [Single]
        Property [Protected]() As Int32
        Property Shadow() As Int32
        Property Size() As [Single]
        Property SmallCaps() As Int32
        Property Spacing() As [Single]
        Property StrikeTrough() As Int32
        Property Subscript() As Int32
        Property Superscript() As Int32
        Property Underline() As Int32
        Property Weight() As Int32
    End Interface
    Public Interface ITextRange
        '{8CC497C2-A1DF-11CE-8098-00AA0047BE5D}
        Property Text() As String
        Property [Char]() As Int32
        ReadOnly Property Dublicate() As ITextRange
        Property FormattedText() As ITextRange
        Property Start() As Int32
        Property [End]() As Int32
        Property Font() As ITextFont
        Property Para() As ITextPara
        ReadOnly Property StoryLength() As Int32
        ReadOnly Property StoryType() As Int32
        Sub Collapse(ByVal bStart As Int32)
        Function Expand(ByVal Unit As Int32) As Int32
        Function GetIndex(ByVal Unit As Int32) As Int32
        Sub SetIndex(ByVal Unit As Int32, ByVal Index As Int32, ByVal Extend As Int32)
        Sub SetRange(ByVal cpActive As Int32, ByVal cpOther As Int32)
        Function InRange(ByVal pRange As ITextRange) As Int32
        Function InStory(ByVal pRange As ITextRange) As Int32
        Function IsEqual(ByVal pRange As ITextRange) As Int32
        Sub [Select]()
        Function StartOf(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function EndOf(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function Move(ByVal Unit As Int32, ByVal Count As Int32) As Int32
        Function MoveStart(ByVal Unit As Int32, ByVal Count As Int32) As Int32
        Function MoveEnd(ByVal Unit As Int32, ByVal Count As Int32) As Int32
        Function MoveWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveStartWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveEndWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveStartUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveEndUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function FindText(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function FindTextStart(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function FindTextEnd(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function Delete(ByVal Unit As Int32, ByVal Count As Int32) As Int32
        Sub Cut(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Sub Copy(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Sub Paste(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Function CanPaste(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32, ByVal Format As Int32) As Int32
        Function CanEdit() As Int32
        Sub ChangeCase(ByVal Type As Int32)
        Sub GetPoint(ByVal Type As Int32, ByVal px As Int32, ByVal py As Int32)
        Sub SetPoint(ByVal x As Int32, ByVal px As Int32, ByVal y As Int32, ByVal Type As Int32, ByVal Extend As Int32)
        Sub ScrollIntoView(ByVal Value As Int32)
        Function GetEmbeddedObject() As [Object]
    End Interface
    Public Interface ITextPara
        '{8CC497C4-A1DF-11CE-8098-00AA0047BE5D}
        Property Duplicate() As ITextPara
        Function CanChange() As Int32
        Function IsEqual(ByVal pPara As ITextPara) As Int32
        Sub Reset(ByVal Value As Int32)
        Property Style() As Int32
        Property Alignment() As Int32
        Property Hyphenation() As Int32
        ReadOnly Property FirstLineIndent() As [Single]
        Property KeepTogether() As Int32
        Property KeppWithNext() As Int32
        Property LeftIndent() As [Single]
        Property LineSpacingRule() As Int32
        Property ListAlignment() As Int32
        Property ListLevelIndex() As Int32
        Property ListStart() As Int32
        Property ListTab() As [Single]
        Property ListType() As Int32
        Property NoLineNumber() As Int32
        Property PageBreakBefore() As Int32
        Property RightIndent() As [Single]
        Sub SetIndents(ByVal StartIndent As [Single], ByVal LeftIndent As [Single], ByVal RightIndent As [Single])
        Sub SetLineSpacing(ByVal LineSpacingRule As Int32, ByVal LineSpacing As [Single])
        Property SpaceAfter() As [Single]
        Property SpaceBefore() As [Single]
        Property WindowControl() As Int32
        ReadOnly Property TabCount() As Int32
        Sub AddTab(ByVal tbPos As [Single], ByVal tbAlign As Int32, ByVal tbLeader As Int32)
        Sub ClearAllTabs()
        Sub DeleteTab(ByVal tbPos As [Single])
        Sub GetTab(ByVal iTab As Int32, ByVal ptbPos As Single, ByVal ptbAlign As Int32, ByVal ptbLeader As Int32)
    End Interface
    Public Interface ITextSelection
        '{8CC497C1-A1DF-11CE-8098-00AA0047BE5D}
        Property Text() As String
        Property [Char]() As Int32
        ReadOnly Property Duplicate() As ITextRange
        Property FormattedText() As ITextRange
        Property Start() As Int32
        Property [End]() As Int32
        Property Font() As ITextFont
        Property Para() As ITextPara
        ReadOnly Property StoryLength() As Int32
        ReadOnly Property StoryType() As Int32
        Sub Collapse(ByVal bStart As Int32)
        Function Expand(ByVal Unit As Int32) As Int32
        Function GetIndex(ByVal Unit As Int32) As Int32
        Sub SetIndex(ByVal Unit As Int32, ByVal Index As Int32, ByVal Extend As Int32)
        Sub SetRange(ByVal cpActive As Int32, ByVal cpOther As Int32)
        Function InRange(ByVal pRange As ITextRange) As Int32
        Function InStory(ByVal pRange As ITextRange) As Int32
        Function IsEqual(ByVal pRange As ITextRange) As Int32
        Sub [Select]()
        Function StartOf(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function EndOf(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function Move(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function MoveStart(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function MoveEnd(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function MoveWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveStartWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveEndWhile(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveStartUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function MoveEndUntil(<MarshalAs(UnmanagedType.AsAny)> ByVal Cset As Int32, ByVal Count As Int32) As Int32
        Function FindText(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function FindTextStart(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function FindTextEnd(ByVal bstr As String, ByVal cch As Int32, ByVal Flags As Int32) As Int32
        Function Delete(ByVal Unit As Int32, ByVal Count As Int32) As Int32
        Sub Cut(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Sub Copy(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Sub Paste(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32)
        Function CanPaste(<MarshalAs(UnmanagedType.AsAny)> ByVal pVar As Int32, ByVal Format As Int32) As Int32
        Function CanEdit() As Int32
        Sub ChangeCase(ByVal Type As Int32)
        Sub GetPoint(ByVal Type As Int32, ByVal px As Int32, ByVal py As Int32)
        Sub SetPoint(ByVal x As Int32, ByVal px As Int32, ByVal y As Int32, ByVal Type As Int32, ByVal Extend As Int32)
        Sub ScrollIntoView(ByVal Value As Int32)
        Function GetEmbeddedObject() As [Object]
        Property Flags() As Int32
        ReadOnly Property Type() As Int32
        Function MoveLeft(ByVal Unit As Int32, ByVal Count As Int32, ByVal Extend As Int32) As Int32
        Function MoveRight(ByVal Unit As Int32, ByVal Count As Int32, ByVal Extend As Int32) As Int32
        Function MoveUp(ByVal Unit As Int32, ByVal Count As Int32, ByVal Extend As Int32) As Int32
        Function MoveDown(ByVal Unit As Int32, ByVal Count As Int32, ByVal Extend As Int32) As Int32
        Function HomeKey(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Function EndKey(ByVal Unit As Int32, ByVal Extend As Int32) As Int32
        Sub TypeText(ByVal bstr As String)
    End Interface
    Public Interface ITextStoryRanges
        '{8CC497C5-A1DF-11CE-8098-00AA0047BE5D}
        Function Item(ByVal Index As Int32) As ITextRange
        Function GetEnumerator() As System.Collections.IEnumerator
        ReadOnly Property Count() As Int32
    End Interface
#End Region

#Region "CONTROL LAYOUT"

    Public Const EM_SETTARGETDEVICE As Integer = (WM_USER + 72)
    Public Enum LayoutModes As Integer
        [Default] = 0
        WordWrap = 1
        ''' <summary>
        ''' What You See Is What You Get
        ''' </summary>
        WYSIWYG = 2
    End Enum

    <DllImport("user32.dll")> _
    Public Shared Function SendMessageLong(ByVal hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    End Function

    Public Sub SetLayoutType(ByVal eViewMode As LayoutModes)
        Dim pd As New PrintDocument()
        Dim ps As New PrinterSettings()

        'int* y = (int*)500;

        Select Case eViewMode
            Case LayoutModes.WYSIWYG
                'SendMessage(this.Handle, EM_SETTARGETDEVICE, ps.GetHdevmode(), new IntPtr(y));
                Exit Select
            Case LayoutModes.WordWrap
                SendMessage(New HandleRef(Me, Me.Handle), EM_SETTARGETDEVICE, 0, 0)
                Exit Select
            Case LayoutModes.[Default]
                SendMessage(New HandleRef(Me, Me.Handle), EM_SETTARGETDEVICE, 0, 1)
                Exit Select
        End Select
    End Sub
#End Region

#Region "FORMATTING AND PRINTING"

#Region "Windows API"

    Private Const WM_SETREDRAW As Integer = &HB
    Private Const EM_SETEVENTMASK As Integer = &H431
    Private Const EM_SETCHARFORMAT As Integer = &H444
    Private Const EM_GETCHARFORMAT As Integer = &H43A
    Private Const EM_GETPARAFORMAT As Integer = &H43D
    Private Const EM_SETPARAFORMAT As Integer = &H447
    Private Const EM_SETTYPOGRAPHYOPTIONS As Integer = &H4CA
    'private const int CFM_UNDERLINETYPE = 0x800000;
    'private const int CFM_BACKCOLOR = 0x4000000;
    Private Const CFE_AUTOBACKCOLOR As Integer = &H4000000
    'private const int PFM_ALIGNMENT = 0x08;
    Private Const TO_ADVANCEDTYPOGRAPHY As Integer = &H1

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As CHARFORMAT2) As Integer
    End Function

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As IRichEditOleCallback) As Integer
    End Function

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As PARAFORMAT2) As Integer
    End Function

    Private Declare Ansi Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

    ''' <summary> 
    ''' Contains information about character formatting in a rich edit control. 
    ''' </summary> 
    ''' <remarks><see cref="CHARFORMAT"/> works with all Rich Edit versions.</remarks> 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CHARFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public dwEffects As UInteger
        Public yHeight As Integer
        Public yOffset As Integer
        Public crTextColor As Integer
        Public bCharSet As Byte
        Public bPitchAndFamily As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public szFaceName As Char()
    End Structure

    ''' <summary> 
    ''' Contains information about character formatting in a rich edit control. 
    ''' </summary> 
    ''' <remarks><see cref="CHARFORMAT2"/> requires Rich Edit 2.0.</remarks> 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CHARFORMAT2
        Public cbSize As Integer
        Public dwMask As UInteger
        Public dwEffects As UInteger
        Public yHeight As Integer
        Public yOffset As Integer
        Public crTextColor As Integer
        Public bCharSet As Byte
        Public bPitchAndFamily As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public szFaceName As Char()
        Public wWeight As Short
        Public sSpacing As Short
        Public crBackColor As Integer
        Public LCID As Integer
        Public dwReserved As UInteger
        Public sStyle As Short
        Public wKerning As Short
        Public bUnderlineType As Byte
        Public bAnimation As Byte
        Public bRevAuthor As Byte
    End Structure

    ''' <summary> 
    ''' Contains information about paragraph formatting in a rich edit control. 
    ''' </summary> 
    ''' <remarks><see cref="PARAFORMAT"/> works with all Rich Edit versions.</remarks> 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure PARAFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public rgxTabs As Integer()
    End Structure

    ''' <summary> 
    ''' Contains information about paragraph formatting in a rich edit control. 
    ''' </summary> 
    ''' <remarks><see cref="PARAFORMAT2"/> requires Rich Edit 2.0.</remarks> 
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure PARAFORMAT2
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public rgxTabs As Integer()
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

#End Region
#Region "Method: OnHandleCreated"

    ''' <summary> 
    ''' Raises the <see cref="HandleCreated"/> event. 
    ''' </summary> 
    ''' <param name="e">An <see cref="EventArgs"/> that contains the event data.</param> 
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)

        ' Enable support for justification 
        SendMessage(New HandleRef(Me, Handle), EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY)
    End Sub

#End Region

#Region "VARIABLES, CONSTANTS AND ENUMS"
    ''' <summary> 
    ''' Specifies horizontal alignment for a segment of rich text. 
    ''' </summary> 
    Public Enum RichTextAlign
        ''' <summary> 
        ''' The text alignment is unknown. 
        ''' </summary> 
        Unknown = 0

        ''' <summary> 
        ''' The text is aligned to the left. 
        ''' </summary> 
        Left = 1

        ''' <summary> 
        ''' The text is aligned to the right. 
        ''' </summary> 
        Right = 2

        ''' <summary> 
        ''' The text is aligned in the center. 
        ''' </summary> 
        Center = 3

        ''' <summary> 
        ''' The text is justified. 
        ''' </summary> 
        Justify = 4
    End Enum
    ''' <summary> 
    ''' Specifies the underline styles for a segment of rich text. 
    ''' </summary> 
    Public Enum UnderlineStyle
        ''' <summary> 
        ''' No underlining. 
        ''' </summary> 
        None = 0

        ''' <summary> 
        ''' Single-line solid underline. 
        ''' </summary> 
        Normal = 1

        ''' <summary> 
        ''' Single-line underline broken between words. 
        ''' </summary> 
        Word = 2

        ''' <summary> 
        ''' Double-line underline. 
        ''' </summary> 
        [Double] = 3

        ''' <summary> 
        ''' 'Dotted' pattern underline. 
        ''' </summary> 
        Dotted = 4

        ''' <summary> 
        ''' 'Dash' pattern underline. 
        ''' </summary> 
        Dash = 5

        ''' <summary> 
        ''' 'Dash-dot' pattern underline. 
        ''' </summary> 
        DashDot = 6

        ''' <summary> 
        ''' 'Dash-dot-dot' pattern underline. 
        ''' </summary> 
        DashDotDot = 7

        ''' <summary> 
        ''' Single-line wave style underline. 
        ''' </summary> 
        Wave = 8

        ''' <summary> 
        ''' Single-line solid underline with extra thickness. 
        ''' </summary> 
        Thick = 9

        ''' <summary> 
        ''' Single-line solid underline with less thickness. 
        ''' </summary> 
        HairLine = 10

        ''' <summary> 
        ''' Double-line wave style underline. 
        ''' </summary> 
        DoubleWave = 11

        ''' <summary> 
        ''' Single-line wave style underline with extra thickness. 
        ''' </summary> 
        HeavyWave = 12

        ''' <summary> 
        ''' 'Long Dash' pattern underline. 
        ''' </summary> 
        LongDash = 13

        ''' <summary> 
        ''' 'Dash' pattern underline with extra thickness. 
        ''' </summary> 
        ThickDash = 14

        ''' <summary> 
        ''' 'Dash-dot' pattern underline with extra thickness. 
        ''' </summary> 
        ThickDashDot = 15

        ''' <summary> 
        ''' 'Dash-dot-dot' pattern underline with extra thickness. 
        ''' </summary> 
        ThickDashDotDot = 16

        ''' <summary> 
        ''' 'Dotted' pattern underline with extra thickness. 
        ''' </summary> 
        ThickDotted = 17

        ''' <summary> 
        ''' 'Long Dash' pattern underline with extra thickness. 
        ''' </summary> 
        ThickLongDash = 18
    End Enum
    ''' <summary> 
    ''' Specifies the color of underline for a segment of rich text. 
    ''' </summary> 
    Public Enum UnderlineColor
        ''' <summary> 
        ''' No specific underline color specified. 
        ''' </summary> 
        None = -1

        ''' <summary> 
        ''' Black. 
        ''' </summary> 
        Black = &H0

        ''' <summary> 
        ''' Blue. 
        ''' </summary> 
        Blue = &H10

        ''' <summary> 
        ''' Cyan. 
        ''' </summary> 
        Cyan = &H20

        ''' <summary> 
        ''' LimeGreen. 
        ''' </summary> 
        LimeGreen = &H30

        ''' <summary> 
        ''' Magenta. 
        ''' </summary> 
        Magenta = &H40

        ''' <summary> 
        ''' Red. 
        ''' </summary> 
        Red = &H50

        ''' <summary> 
        ''' Yellow. 
        ''' </summary> 
        Yellow = &H60

        ''' <summary> 
        ''' White. 
        ''' </summary> 
        White = &H70

        ''' <summary> 
        ''' DarkBlue. 
        ''' </summary> 
        DarkBlue = &H80

        ''' <summary> 
        ''' DarkCyan. 
        ''' </summary> 
        DarkCyan = &H90

        ''' <summary> 
        ''' Green. 
        ''' </summary> 
        Green = &HA0

        ''' <summary> 
        ''' DarkMagenta. 
        ''' </summary> 
        DarkMagenta = &HB0

        ''' <summary> 
        ''' Brown. 
        ''' </summary> 
        Brown = &HC0

        ''' <summary> 
        ''' OliveGreen. 
        ''' </summary> 
        OliveGreen = &HD0

        ''' <summary> 
        ''' DarkGray. 
        ''' </summary> 
        DarkGray = &HE0

        ''' <summary> 
        ''' Gray. 
        ''' </summary> 
        Gray = &HF0
    End Enum

#Region "Property: SelectionUnderlineStyle"

    ''' <summary> 
    ''' Gets or sets the underline style to apply to the current selection or insertion point. 
    ''' </summary> 
    ''' <value>A <see cref="UnderlineStyle"/> that represents the underline style to 
    ''' apply to the current text selection or to text entered after the insertion point.</value> 
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SelectionUnderlineStyle() As UnderlineStyle
        Get
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)

            ' Get the underline style 
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, fmt)
            If (fmt.dwMask And CFM_UNDERLINETYPE) = 0 Then
                Return UnderlineStyle.None
            Else
                Dim style As Byte = CByte(fmt.bUnderlineType And &HF)
                Return CType(style, UnderlineStyle)
            End If
        End Get
        Set(ByVal value As UnderlineStyle)
            ' Ensure we don't alter the color 
            Dim color As UnderlineColor = SelectionUnderlineColor

            ' Ensure we don't show it if it shouldn't be shown 
            If value = UnderlineStyle.None Then
                color = UnderlineColor.Black
            End If

            ' Set the underline type 
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = CFM_UNDERLINETYPE
            fmt.bUnderlineType = CByte(CByte(value) Or CByte(color))
            SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

#End Region
#Region "Property: SelectionUnderlineColor"

    ''' <summary> 
    ''' Gets or sets the underline color to apply to the current selection or insertion point. 
    ''' </summary> 
    ''' <value>A <see cref="UnderlineColor"/> that represents the underline color to 
    ''' apply to the current text selection or to text entered after the insertion point.</value> 
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SelectionUnderlineColor() As UnderlineColor
        Get
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)

            ' Get the underline color 
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, fmt)
            If (fmt.dwMask And CFM_UNDERLINETYPE) = 0 Then
                Return UnderlineColor.None
            Else
                Dim style As Byte = CByte(fmt.bUnderlineType And &HF0)
                Return CType(style, UnderlineColor)
            End If
        End Get
        Set(ByVal value As UnderlineColor)
            ' If the an underline color of "None" is specified, remove underline effect 
            If value = UnderlineColor.None Then
                SelectionUnderlineStyle = UnderlineStyle.None
            Else
                ' Ensure we don't alter the style 
                Dim style As UnderlineStyle = SelectionUnderlineStyle

                ' Ensure we don't show it if it shouldn't be shown 
                If style = UnderlineStyle.None Then
                    value = UnderlineColor.Black
                End If

                ' Set the underline color 
                Dim fmt As New CHARFORMAT2()
                fmt.cbSize = Marshal.SizeOf(fmt)
                fmt.dwMask = CFM_UNDERLINETYPE
                fmt.bUnderlineType = CByte(CByte(style) Or CByte(value))
                SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, fmt)
            End If
        End Set
    End Property

#End Region
#Region "Properties: Selection Colors"

    ''' <summary> 
    ''' Gets or sets the background color to apply to the 
    ''' current selection or insertion point. 
    ''' </summary> 
    ''' <value>A <see cref="Color"/> that represents the background color to 
    ''' apply to the current text selection or to text entered after the insertion point.</value> 
    ''' <remarks> 
    ''' <para>A value of Color.Empty indicates that the default background color is used.</para> 
    ''' <para>If the selection contains more than one background 
    ''' color, then this property will indicate it by 
    ''' returning Color.Empty.</para> 
    ''' </remarks> 
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SelectionBackColor2() As Color
        Get
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)

            ' Get the background color 
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, fmt)

            ' Default to Color.Empty as there could be 
            ' several colors present in this selection 
            If (fmt.dwMask And CFM_BACKCOLOR) = 0 Then
                Return Color.Empty
            End If

            ' Default to Color.Empty if the background color is automatic 
            If (fmt.dwEffects And CFE_AUTOBACKCOLOR) = CFE_AUTOBACKCOLOR Then
                Return Color.Empty
            End If

            ' Deal with the weird Windows color format 
            Return ColorTranslator.FromWin32(fmt.crBackColor)
        End Get
        Set(ByVal value As Color)
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = CFM_BACKCOLOR
            If value.IsEmpty Then
                fmt.dwEffects = CFE_AUTOBACKCOLOR
            Else
                fmt.crBackColor = ColorTranslator.ToWin32(value)
            End If

            ' Set the background color 
            SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text color of the current selection.
    ''' </summary>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SelectionColor2() As Color
        Get
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)

            ' Get the background color 
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, fmt)

            ' Default to Color.Empty as there could be 
            ' several colors present in this selection 
            If (fmt.dwMask And CFM_COLOR) = 0 Then
                Return Color.Empty
            End If

            ' Default to Color.Empty if the background color is automatic 
            If (fmt.dwEffects And CFE_AUTOCOLOR) = CFE_AUTOCOLOR Then
                Return Color.Empty
            End If

            ' Deal with the weird Windows color format 
            Return ColorTranslator.FromWin32(fmt.crTextColor)
        End Get
        Set(ByVal value As Color)
            Dim fmt As New CHARFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = CFM_COLOR
            If value.IsEmpty Then
                fmt.dwEffects = CFE_AUTOCOLOR
            Else
                fmt.crTextColor = ColorTranslator.ToWin32(value)
            End If

            ' Set the background color 
            SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

#End Region
#Region "Property: SelectionAlignment"

    ''' <summary> 
    ''' Gets or sets the text alignment to apply to the current 
    ''' selection or insertion point. 
    ''' </summary> 
    ''' <value>A member of the <see cref="RichTextAlign"/> enumeration that represents 
    ''' the text alignment to apply to the current text selection or to text entered 
    ''' after the insertion point.</value> 
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shadows Property SelectionAlignment() As RichTextAlign
        Get
            Dim fmt As New PARAFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, fmt)

            If (fmt.dwMask And PFM_ALIGNMENT) = 0 Then
                Return RichTextAlign.Unknown
            Else
                Return CType(fmt.wAlignment, RichTextAlign)
            End If
        End Get
        Set(ByVal value As RichTextAlign)
            Dim fmt As New PARAFORMAT2()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = PFM_ALIGNMENT
            fmt.wAlignment = CShort(value)

            ' Set the alignment 
            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

#End Region

    ' Convert the unit that is used by the .NET framework (1/100 inch)
    ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
    Private Const AnInch As Double = 14.4

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CHARRANGE
        Public cpMin As Integer
        ' First character of range (0 for start of doc)
        Public cpMax As Integer
        ' Last character of range (-1 for end of doc)
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure FORMATRANGE
        Public hdc As IntPtr
        ' Actual DC to draw on
        Public hdcTarget As IntPtr
        ' Target DC for determining text formatting
        Public rc As RECT
        ' Region of the DC to draw to (in twips)
        Public rcPage As RECT
        ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE
        ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57
    Private Const BULLET_NUMBER As Integer = 2



#End Region

#Region "CHAR STYLE"

    <Browsable(False)> _
    Public Class CharStyle
        Private _bold As Boolean = False, _italic As Boolean = False, _strikeout As Boolean = False, _underline As Boolean = False, _link As Boolean = False

        Public Sub New()
            _bold = False
            _italic = False
            _strikeout = False
            _underline = False
            _link = False
        End Sub

        Public Sub New(ByVal bold As Boolean, ByVal italic As Boolean, ByVal underline As Boolean, ByVal strikeout As Boolean, ByVal link As Boolean)
            _bold = bold
            _italic = italic
            _underline = underline
            _strikeout = strikeout
            _link = link
        End Sub


        ''' <summary>
        ''' Indicates whether font is bold
        ''' </summary>
        Public Property Bold() As Boolean
            Get
                Return _bold
            End Get
            Set(ByVal value As Boolean)
                _bold = value
            End Set
        End Property
        ''' <summary>
        ''' If true font is italic, otherwise false
        ''' </summary>
        Public Property Italic() As Boolean
            Get
                Return _italic
            End Get
            Set(ByVal value As Boolean)
                _italic = value
            End Set
        End Property
        ''' <summary>
        ''' If true selected text is underlined, otherwise false
        ''' </summary>
        Public Property Underline() As Boolean
            Get
                Return _underline
            End Get
            Set(ByVal value As Boolean)
                _underline = value
            End Set
        End Property
        ''' <summary>
        ''' If true, RichTextBox draw line through the baseline text
        ''' </summary>
        Public Property Strikeout() As Boolean
            Get
                Return _strikeout
            End Get
            Set(ByVal value As Boolean)
                _strikeout = value
            End Set
        End Property
        ''' <summary>
        ''' If true, then it is a hyperlink, otherwise - text
        ''' </summary>
        Public Property Link() As Boolean
            Get
                Return _link
            End Get
            Set(ByVal value As Boolean)
                _link = value
            End Set
        End Property
    End Class

    Private Const DEFAULT_EFFECTS As UInteger = 1140850688
    Private Const DEFAULT_MASK As UInteger = 4278190079UI

    <Browsable(False)> _
    Public Property SelectionCharStyle() As CharStyle
        Get
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)

            If param.crBackColor > 0 AndAlso param.crTextColor > 0 Then
            ElseIf param.crBackColor > 0 Then
                param.dwEffects -= 1073741824
            ElseIf param.crTextColor > 0 Then
                param.dwEffects -= 67108864
            End If


            Dim cs As New CharStyle()
            'MessageBox.Show(param.dwEffects.ToString());
            'I know, it difficult, but all combinations must be processed
            If param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD OrElse param.dwEffects = CFE_BOLD Then
                cs.Bold = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC OrElse param.dwEffects = CFE_ITALIC Then
                cs.Italic = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_UNDERLINE OrElse param.dwEffects = CFE_UNDERLINE Then
                cs.Underline = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_STRIKEOUT OrElse param.dwEffects = CFE_STRIKEOUT Then
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_LINK OrElse param.dwEffects = CFE_LINK Then
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC Then
                cs.Bold = True
                cs.Italic = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_UNDERLINE OrElse param.dwEffects = CFE_BOLD + CFE_UNDERLINE Then
                cs.Bold = True
                cs.Underline = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_STRIKEOUT OrElse param.dwEffects = CFE_BOLD + CFE_STRIKEOUT Then
                cs.Bold = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_LINK Then
                cs.Bold = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_UNDERLINE OrElse param.dwEffects = CFE_ITALIC + CFE_UNDERLINE Then
                cs.Italic = True
                cs.Underline = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_STRIKEOUT OrElse param.dwEffects = CFE_ITALIC + CFE_STRIKEOUT Then
                cs.Italic = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_LINK OrElse param.dwEffects = CFE_ITALIC + CFE_LINK Then
                cs.Italic = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_UNDERLINE + CFE_STRIKEOUT OrElse param.dwEffects = CFE_UNDERLINE + CFE_STRIKEOUT Then
                cs.Underline = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_STRIKEOUT + CFE_LINK Then
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE Then
                cs.Bold = True
                cs.Italic = True
                cs.Underline = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_STRIKEOUT OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_STRIKEOUT Then
                cs.Bold = True
                cs.Italic = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_LINK Then
                cs.Bold = True
                cs.Italic = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT OrElse param.dwEffects = CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT Then
                cs.Bold = True
                cs.Underline = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_UNDERLINE + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_UNDERLINE + CFE_LINK Then
                cs.Bold = True
                cs.Underline = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT OrElse param.dwEffects = CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT Then
                cs.Italic = True
                cs.Underline = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_UNDERLINE + CFE_LINK OrElse param.dwEffects = CFE_ITALIC + CFE_UNDERLINE + CFE_LINK Then
                cs.Italic = True
                cs.Underline = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_ITALIC + CFE_STRIKEOUT + CFE_LINK Then
                cs.Italic = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK Then
                cs.Underline = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT Then
                cs.Bold = True
                cs.Italic = True
                cs.Underline = True
                cs.Strikeout = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_LINK Then
                cs.Bold = True
                cs.Italic = True
                cs.Underline = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_STRIKEOUT + CFE_LINK Then
                cs.Bold = True
                cs.Italic = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK Then
                cs.Bold = True
                cs.Underline = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK Then
                cs.Bold = True
                cs.Underline = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK Then
                cs.Italic = True
                cs.Underline = True
                cs.Strikeout = True
                cs.Link = True
            ElseIf param.dwEffects = DEFAULT_EFFECTS + CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK OrElse param.dwEffects = CFE_BOLD + CFE_ITALIC + CFE_UNDERLINE + CFE_STRIKEOUT + CFE_LINK Then
                cs.Bold = True
                cs.Italic = True
                cs.Underline = True
                cs.Strikeout = True
                cs.Link = True
            Else
                cs = New CharStyle()
            End If
            'style was not recognized...            
            Return cs
        End Get
        Set(ByVal value As CharStyle)
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)
            Dim effects As UInteger = 0, mask As UInteger = 0

            'we need to set both mask and style
            'otherwise we can loose some formatting            
            If value.Bold = True Then
                effects += CFE_BOLD
                mask += CFM_BOLD
            Else
                mask += CFM_BOLD
            End If
            If value.Italic = True Then
                effects += CFE_ITALIC
                mask += CFM_ITALIC
            Else
                mask += CFM_ITALIC
            End If
            If value.Underline = True Then
                effects += CFE_UNDERLINE
                mask += CFM_UNDERLINE
            Else
                mask += CFM_UNDERLINE
            End If
            If value.Strikeout = True Then
                effects += CFE_STRIKEOUT
                mask += CFM_STRIKEOUT
            Else
                mask += CFM_STRIKEOUT
            End If
            If value.Link = True Then
                effects += CFE_LINK
                mask += CFM_LINK
            Else
                mask += CFM_LINK
            End If

            param.dwEffects = effects
            param.dwMask = mask

            SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, param)
        End Set
    End Property

    Private Function GetStringFromChar(ByVal val As Char()) As String
        If val.Length = 0 Then
            Return ""
        End If
        Dim s As String = ""

        For i As Integer = 0 To val.Length - 1
            s += val.GetValue(i).ToString()
        Next

        Return s
    End Function

    Public Property SelectionFont2() As Font
        Get
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)

            Dim f As New Font(GetStringFromChar(param.szFaceName), CSng(param.yHeight \ 20), GraphicsUnit.Inch)
            Dim f2 As New Font(f.Name, CSng(f.Size))

            Return f
        End Get
        Set(ByVal value As Font)
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)
            param.dwMask = CFM_FACE + CFM_SIZE + CFM_CHARSET
            param.bCharSet = value.GdiCharSet
            Dim name As Char() = New Char(63) {}
            name = value.Name.ToCharArray()
            param.szFaceName = New Char(63) {}
            name.CopyTo(param.szFaceName, 0)
            param.yHeight = CInt(Math.Truncate(value.Size * AnInch))
            SendMessage(New HandleRef(Me, Handle), EM_SETCHARFORMAT, SCF_SELECTION, param)
        End Set
    End Property

#End Region

#Region "LINE SPACING"

    Public Class ParaLineSpacing
        Public Enum LineSpacingStyle As Byte
            ''' <summary>
            ''' Single spacing. The ExactSpacing member is ignored.
            ''' </summary>
            [Single] = 0
            ''' <summary>
            ''' One-and-a-half spacing. The ExactSpacing member is ignored.
            ''' </summary>
            OneAndAHalf = 1
            ''' <summary>
            ''' Double spacing. The ExactSpacing member is ignored.
            ''' </summary>
            [Double] = 2
            ''' <summary>
            ''' The ExactSpacing member specifies the spacingfrom one line to the next, in twips. 
            ''' However, if ExactSpacing specifies a value that is less than single spacing, 
            ''' the control displays single-spaced text.
            ''' </summary>
            ExactFixed = 3
            ''' <summary>
            ''' The ExactSpacing member specifies the spacing from one line to the next, in twips. 
            ''' The control uses the exact spacing specified, even if ExactSpacing specifies a 
            ''' value that is less than single spacing.
            ''' </summary>
            ExactFree = 4
            ''' <summary>
            ''' The value of dyLineSpacing / 20 is the spacing, in lines, from one line to the next. 
            ''' Thus, setting dyLineSpacing to 20 produces single-spaced text, 40 is double spaced, 
            ''' 60 is triple spaced, and so on.
            ''' </summary>
            Relative = 5
            ''' <summary>
            ''' Value was not recognized. Do not send this value through SendMessage, RichTextBox will
            ''' not recognize it. Added for internal purposes.
            ''' </summary>
            Unknown = 6
        End Enum

        Private style As LineSpacingStyle = LineSpacingStyle.[Single]
        Private spacing As Integer = 20

        Public Property SpacingStyle() As LineSpacingStyle
            Get
                Return style
            End Get
            Set(ByVal value As LineSpacingStyle)
                style = value
            End Set
        End Property
        Public Property ExactSpacing() As Integer
            Get
                Return spacing
            End Get
            Set(ByVal value As Integer)
                spacing = value
            End Set
        End Property
    End Class

    Public Property SelectionLineSpacing() As ParaLineSpacing
        Get
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            Dim pls As New ParaLineSpacing()

            If param.bLineSpacingRule >= 1 AndAlso param.bLineSpacingRule <= 5 Then
                pls.SpacingStyle = DirectCast(param.bLineSpacingRule, ParaLineSpacing.LineSpacingStyle)
            Else
                pls.SpacingStyle = ParaLineSpacing.LineSpacingStyle.Unknown
            End If

            pls.ExactSpacing = param.dyLineSpacing

            Return pls
        End Get
        Set(ByVal value As ParaLineSpacing)
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            param.dyLineSpacing = value.ExactSpacing
            If value.SpacingStyle <> ParaLineSpacing.LineSpacingStyle.Unknown Then
                param.bLineSpacingRule = CByte(value.SpacingStyle)
            Else
                param.bLineSpacingRule = 1
            End If
        End Set
    End Property

    ''' <summary>
    ''' Space, in twips, before line
    ''' </summary>
    Public Property SelectionSpaceBefore() As Integer
        Get
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            Return param.dySpaceBefore
        End Get
        Set(ByVal value As Integer)
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            param.dwMask = PFM_SPACEBEFORE
            param.dySpaceBefore = value

            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, param)
        End Set
    End Property
    ''' <summary>
    ''' Space, in twips, after line
    ''' </summary>
    Public Property SelectionSpaceAfter() As Integer
        Get
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            Return param.dySpaceAfter
        End Get
        Set(ByVal value As Integer)
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            param.dwMask = PFM_SPACEAFTER
            param.dySpaceAfter = value

            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, param)
        End Set
    End Property

#End Region

#Region "CHAR OFFSET"

    Public Enum OffsetType
        Subscript
        Superscript
        None
    End Enum

    Public Property SelectionOffsetType() As OffsetType
        Get
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)

            If param.yOffset < 0 Then
                Return OffsetType.Superscript
            ElseIf param.yOffset > 0 Then
                Return OffsetType.Subscript
            Else
                Return OffsetType.None
            End If
        End Get
        Set(ByVal value As OffsetType)
            Dim param As New CHARFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)

            Dim _offset As Integer = 0

            Select Case value
                Case OffsetType.Subscript
                    If param.yOffset < 0 Then
                        'super
                        _offset = Math.Abs(param.yOffset)
                    ElseIf param.yOffset > 0 Then
                        'sub
                        _offset = param.yOffset
                    Else
                        'none
                        _offset = 0
                    End If
                    Exit Select
                Case OffsetType.Superscript
                    If param.yOffset < 0 Then
                        'super
                        _offset = param.yOffset
                    ElseIf param.yOffset > 0 Then
                        'sub
                        _offset = -param.yOffset
                    Else
                        'none
                        _offset = 0
                    End If
                    Exit Select
                Case OffsetType.None
                    _offset = 0
                    Exit Select
                Case Else
                    Exit Select
            End Select

            param.dwMask = CFM_OFFSET
            param.yOffset = _offset

            SendMessage(New HandleRef(Me, Handle), EM_GETCHARFORMAT, SCF_SELECTION, param)
        End Set
    End Property

#End Region

    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    ' :-(  BORDER STYLE IS NOT SUPPORTED BY RichTextBox 2.0 :-(
    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
#Region "BORDERS"

    <Browsable(False)> _
    Public Class ParaBorders
        Private _bottom As Boolean = False, _top As Boolean = False, _left As Boolean = False, _right As Boolean = False, _inside As Boolean = False, _outside As Boolean = False, _
         _autocolor As Boolean = False
        Private _bWidth As Short = 1, _bOffset As Short = 1
        Private _style As ParaBorderStyle = ParaBorderStyle.None
        Private _color As ParaBorderColor = ParaBorderColor.Black

        Public Sub New()
            _bottom = False
            _top = False
            _left = False
            _right = False
        End Sub
        Public Sub New(ByVal bottom As Boolean, ByVal top As Boolean, ByVal left As Boolean, ByVal right As Boolean)
            _bottom = bottom
            _top = top
            _left = left
            _right = right
        End Sub

        Public Property Bottom() As Boolean
            Get
                Return _bottom
            End Get
            Set(ByVal value As Boolean)
                _bottom = value
            End Set
        End Property
        Public Property Top() As Boolean
            Get
                Return _top
            End Get
            Set(ByVal value As Boolean)
                _top = value
            End Set
        End Property
        Public Property Left() As Boolean
            Get
                Return _left
            End Get
            Set(ByVal value As Boolean)
                _left = value
            End Set
        End Property
        Public Property Right() As Boolean
            Get
                Return _right
            End Get
            Set(ByVal value As Boolean)
                _right = value
            End Set
        End Property
        Public Property Inside() As Boolean
            Get
                Return _inside
            End Get
            Set(ByVal value As Boolean)
                _inside = value
            End Set
        End Property
        Public Property Outside() As Boolean
            Get
                Return _outside
            End Get
            Set(ByVal value As Boolean)
                _outside = value
            End Set
        End Property

        Public Property UseAutoColor() As Boolean
            Get
                Return _autocolor
            End Get
            Set(ByVal value As Boolean)
                _autocolor = value
            End Set
        End Property

        Public Property BorderWidth() As Short
            Get
                Return _bWidth
            End Get
            Set(ByVal value As Short)
                _bWidth = value
            End Set
        End Property
        Public Property BorderOffset() As Short
            Get
                Return _bOffset
            End Get
            Set(ByVal value As Short)
                _bOffset = value
            End Set
        End Property

        Public Property BorderStyle() As ParaBorderStyle
            Get
                Return _style
            End Get
            Set(ByVal value As ParaBorderStyle)
                _style = value
            End Set
        End Property
        Public Property BorderColor() As ParaBorderColor
            Get
                Return _color
            End Get
            Set(ByVal value As ParaBorderColor)
                _color = value
            End Set
        End Property

        ''' <summary>
        ''' Represents styles for borders
        ''' </summary>
        Public Enum ParaBorderStyle
            None
            Point3_4
            Point11_2
            Point21_4
            Point3
            Point41_2
            Point6
            PointDouble3_4
            PointDouble11_2
            PointDouble21_4
            PointGray3_4
            PointGrayDashed3_4
        End Enum
        Public Enum ParaBorderColor
            Black
            Blue
            Cyan
            Green
            Magenta
            Red
            Yellow
            White
            DarkBlue
            DarkCyan
            DarkGreen
            DarkMagenta
            DarkRed
            DarkYellow
            DarkGray
            LightGray
        End Enum

        Public Function GetData() As Short
            'try
            '{
            Dim ba As New BitArray(16)
            'Set all bits to 0
            ba.SetAll(False)

            '
            '            Left border     00000001
            '            Right border    00000010
            '            Top border      00000100
            '            Bottom border   00001000
            '            Inside borders  00010000
            '            Outside borders 00100000
            '            Autocolor       01000000  If this bit is set, the color index in bits 12 to 15 is not used.
            '             


            ba.[Set](0, True)
            'this is always 0
            '#Region "WHICH BORDERS"
            If _autocolor = True Then
                ba.[Set](1, True)
            End If
            If _outside = True Then
                ba.[Set](2, True)
            End If
            If _inside = True Then
                ba.[Set](3, True)
            End If
            If _bottom = True Then
                ba.[Set](4, True)
            End If
            If _top = True Then
                ba.[Set](5, True)
            End If
            If _right = True Then
                ba.[Set](6, True)
            End If
            If _left = True Then
                ba.[Set](7, True)
            End If
            '#End Region

            '#Region "BORDER STYLE"
            '
            '            0000   None
            '            0001   3/4 point
            '            0010   11/2 point
            '            0011   21/4 point
            '            0100   3 point
            '            0101   41/2 point
            '            0110   6 point
            '            0111   3/4 point double
            '            1000   11/2 point double
            '            1001   21/4 point double
            '            1010   3/4 point gray
            '            1011   3/4 point gray dashed
            '            


            Select Case _style
                Case ParaBorderStyle.None
                    ba.[Set](8, False)
                    ba.[Set](9, False)
                    ba.[Set](10, False)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.Point3_4
                    ba.[Set](8, False)
                    ba.[Set](9, False)
                    ba.[Set](10, False)
                    ba.[Set](11, True)
                    Exit Select
                Case ParaBorderStyle.Point11_2
                    ba.[Set](8, False)
                    ba.[Set](9, False)
                    ba.[Set](10, True)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.Point21_4
                    ba.[Set](8, False)
                    ba.[Set](9, False)
                    ba.[Set](10, True)
                    ba.[Set](11, True)
                    Exit Select
                Case ParaBorderStyle.Point3
                    ba.[Set](8, False)
                    ba.[Set](9, True)
                    ba.[Set](10, False)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.Point41_2
                    ba.[Set](8, False)
                    ba.[Set](9, True)
                    ba.[Set](10, False)
                    ba.[Set](11, True)
                    Exit Select
                Case ParaBorderStyle.Point6
                    ba.[Set](8, False)
                    ba.[Set](9, True)
                    ba.[Set](10, True)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.PointDouble3_4
                    ba.[Set](8, False)
                    ba.[Set](9, True)
                    ba.[Set](10, True)
                    ba.[Set](11, True)
                    Exit Select
                Case ParaBorderStyle.PointDouble11_2
                    ba.[Set](8, True)
                    ba.[Set](9, False)
                    ba.[Set](10, False)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.PointDouble21_4
                    ba.[Set](8, True)
                    ba.[Set](9, False)
                    ba.[Set](10, False)
                    ba.[Set](11, True)
                    Exit Select
                Case ParaBorderStyle.PointGray3_4
                    ba.[Set](8, True)
                    ba.[Set](9, False)
                    ba.[Set](10, True)
                    ba.[Set](11, False)
                    Exit Select
                Case ParaBorderStyle.PointGrayDashed3_4
                    ba.[Set](8, True)
                    ba.[Set](9, False)
                    ba.[Set](10, True)
                    ba.[Set](11, True)
                    Exit Select
                Case Else
                    ' no borders
                    ba.[Set](8, False)
                    ba.[Set](9, False)
                    ba.[Set](10, False)
                    ba.[Set](11, False)
                    Exit Select
            End Select
            '#End Region

            '#Region "BORDER COLOR"

            '
            '            0000    Black
            '            0001    Blue
            '            0010    Cyan
            '            0011    Green
            '            0100    Magenta
            '            0101    Red
            '            0110    Yellow
            '            0111    White
            '            1000    DarkBlue
            '            1001    DarkCyan
            '            1010    DarkGreen
            '            1011    DarkMagenta
            '            1100    DarkRed
            '            1101    DarkYellow
            '            1110    DarkGray
            '            1111    LightGray
            '            


            Select Case _color
                Case ParaBorderColor.Black
                    ba.[Set](12, False)
                    ba.[Set](13, False)
                    ba.[Set](14, False)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.Blue
                    ba.[Set](12, False)
                    ba.[Set](13, False)
                    ba.[Set](14, False)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.Cyan
                    ba.[Set](12, False)
                    ba.[Set](13, False)
                    ba.[Set](14, True)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.Green
                    ba.[Set](12, False)
                    ba.[Set](13, False)
                    ba.[Set](14, True)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.Magenta
                    ba.[Set](12, False)
                    ba.[Set](13, True)
                    ba.[Set](14, False)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.Red
                    ba.[Set](12, False)
                    ba.[Set](13, True)
                    ba.[Set](14, False)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.Yellow
                    ba.[Set](12, False)
                    ba.[Set](13, True)
                    ba.[Set](14, True)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.White
                    ba.[Set](12, False)
                    ba.[Set](13, True)
                    ba.[Set](14, True)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.DarkBlue
                    ba.[Set](12, True)
                    ba.[Set](13, False)
                    ba.[Set](14, False)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.DarkCyan
                    ba.[Set](12, True)
                    ba.[Set](13, False)
                    ba.[Set](14, False)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.DarkGreen
                    ba.[Set](12, True)
                    ba.[Set](13, False)
                    ba.[Set](14, True)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.DarkMagenta
                    ba.[Set](12, True)
                    ba.[Set](13, False)
                    ba.[Set](14, True)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.DarkRed
                    ba.[Set](12, True)
                    ba.[Set](13, True)
                    ba.[Set](14, False)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.DarkYellow
                    ba.[Set](12, True)
                    ba.[Set](13, True)
                    ba.[Set](14, False)
                    ba.[Set](15, True)
                    Exit Select
                Case ParaBorderColor.DarkGray
                    ba.[Set](12, True)
                    ba.[Set](13, True)
                    ba.[Set](14, True)
                    ba.[Set](15, False)
                    Exit Select
                Case ParaBorderColor.LightGray
                    ba.[Set](12, True)
                    ba.[Set](13, True)
                    ba.[Set](14, True)
                    ba.[Set](15, True)
                    Exit Select
                Case Else
                    ba.[Set](12, False)
                    ba.[Set](13, False)
                    ba.[Set](14, False)
                    ba.[Set](15, False)
                    'Default to Black
                    Exit Select
            End Select

            '#End Region

            Dim arr As Byte() = DirectCast(Array.CreateInstance(GetType(Byte), 2), Byte())

            ba.CopyTo(arr, 0)

            Return BitConverter.ToInt16(arr, 0)
            '}
            'catch (Exception)
            '{
            '    return 0;
            '}
        End Function
    End Class
    '
    '    public ParaBorders SelectionBorders
    '    {
    '        /*get 
    '        {
    '            PARAFORMAT2 param = new PARAFORMAT2();
    '            param.cbSize = Marshal.SizeOf(param);
    '            SendMessage(new HandleRef(this, Handle), EM_GETPARAFORMAT, SCF_SELECTION, ref param);
    '
    '            ParaBorders pb = new ParaBorders();
    '
    '            pb.BorderWidth = param.wBorderWidth;
    '            pb.BorderOffset = param.wBorderSpace;
    '
    '            //MessageBox.Show(Convert.ToString(param.wBorders));
    '
    '            return pb;
    '
    '        }
    '
    '        set
    '        {
    '            PARAFORMAT2 param = new PARAFORMAT2();
    '            param.cbSize = Marshal.SizeOf(param);
    '            SendMessage(new HandleRef(this, Handle), EM_GETPARAFORMAT, SCF_SELECTION, ref param);
    '
    '            param.dwMask = PFM_BORDER;
    '            param.wBorders = value.GetData();
    '            param.wBorderWidth = value.BorderWidth;
    '            param.wBorderSpace = value.BorderOffset;
    '
    '            SendMessage(new HandleRef(this, Handle), EM_SETPARAFORMAT, SCF_SELECTION, ref param);
    '        }
    '    }
    '

#End Region

#Region "LIST"

    ''' <summary>
    ''' Represents style for lists
    ''' </summary>
    Public Class ParaListStyle
        Public Enum ListType As Short
            ''' <summary>
            ''' No list
            ''' </summary>
            None = 0
            ''' <summary>
            ''' Small letters (a, b, c ...)
            ''' </summary>
            SmallLetters = 3
            ''' <summary>
            ''' Capital letters (A, B, C ...)
            ''' </summary>
            CapitalLetters = 4
            ''' <summary>
            ''' Small roman (i, ii, iii ...)
            ''' </summary>
            SmallRoman = 5
            ''' <summary>
            ''' Capital roman (I, II, III ...)
            ''' </summary>
            CapitalRoman = 6
            ''' <summary>
            ''' Bulleted list (standard bullet)
            ''' </summary>
            Bullet = 1
            ''' <summary>
            ''' Arabic numbers
            ''' </summary>
            Numbers = 2
            ''' <summary>
            ''' User specifed bullets
            ''' </summary>
            CharBullet = 7
        End Enum
        Public Enum ListStyle As Short
            ''' <summary>
            ''' Follows the number with a right parenthesis.
            ''' </summary>
            NumberAndParenthesis = 0
            ''' <summary>
            ''' Encloses the number in parentheses.
            ''' </summary>
            NumberInPar = &H100
            ''' <summary>
            ''' Follows the number with a period.
            ''' </summary>
            NumberAndPeriod = &H200
            ''' <summary>
            ''' Displays only the number.
            ''' </summary>
            OnlyNumber = &H300
            ''' <summary>
            ''' Continues a numbered list without applying the next number or bullet.
            ''' </summary>
            ContinueWithNoNumber = &H400
        End Enum

        Private NUMBERING_START As Short = 1
        Private CHAR_BULLET_CODE_UNICODE As Short = 0
        Private ls As ListStyle = ListStyle.NumberAndParenthesis
        Private lt As ListType = ListType.None

        Public Property NumberingStart() As Short
            Get
                Return NUMBERING_START
            End Get
            Set(ByVal value As Short)
                NUMBERING_START = value
            End Set
        End Property
        Public Property BulletCharCode() As Short
            Get
                Return CHAR_BULLET_CODE_UNICODE
            End Get
            Set(ByVal value As Short)
                CHAR_BULLET_CODE_UNICODE = value
            End Set
        End Property
        Public Property Style() As ListStyle
            Get
                Return ls
            End Get
            Set(ByVal value As ListStyle)
                ls = value
            End Set
        End Property
        Public Property Type() As ListType
            Get
                Return lt
            End Get
            Set(ByVal value As ListType)
                lt = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Gets or sets current selection list type if exists. Before applying sequence, 
    ''' set NumberingStart property to the value from which you want to start list 
    ''' numbering. (Default is 1). Before using bulleted list, set BulletCharCode
    ''' property to the value of corresponding Unicode character, which will represent
    ''' a bullet.
    ''' </summary>
    Public Property SelectionListType() As ParaListStyle
        Get
            Dim retVal As New ParaListStyle()
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)
            Select Case param.wNumbering
                Case 0
                    retVal.Type = ParaListStyle.ListType.None
                    Exit Select
                Case 3
                    retVal.Type = ParaListStyle.ListType.SmallLetters
                    Exit Select
                Case 4
                    retVal.Type = ParaListStyle.ListType.CapitalLetters
                    Exit Select
                Case 5
                    retVal.Type = ParaListStyle.ListType.SmallRoman
                    Exit Select
                Case 6
                    retVal.Type = ParaListStyle.ListType.CapitalRoman
                    Exit Select
                Case 2
                    retVal.Type = ParaListStyle.ListType.Numbers
                    Exit Select
                Case 1
                    retVal.Type = ParaListStyle.ListType.Bullet
                    Exit Select
                Case Else
                    retVal.Type = ParaListStyle.ListType.CharBullet
                    Exit Select
            End Select
            Select Case param.wNumberingStyle
                Case 0
                    retVal.Style = ParaListStyle.ListStyle.NumberAndParenthesis
                    Exit Select
                Case &H100
                    retVal.Style = ParaListStyle.ListStyle.NumberInPar
                    Exit Select
                Case &H200
                    retVal.Style = ParaListStyle.ListStyle.NumberAndPeriod
                    Exit Select
                Case &H300
                    retVal.Style = ParaListStyle.ListStyle.OnlyNumber
                    Exit Select
                Case &H400
                    retVal.Style = ParaListStyle.ListStyle.ContinueWithNoNumber
                    Exit Select
                Case Else
                    retVal.Style = ParaListStyle.ListStyle.NumberAndParenthesis
                    Exit Select
            End Select
            retVal.NumberingStart = param.wNumberingStart

            Return retVal
        End Get
        Set(ByVal value As ParaListStyle)
            Dim param As New PARAFORMAT2()
            param.cbSize = Marshal.SizeOf(param)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, param)

            param.dwMask = PFM_NUMBERING + PFM_NUMBERINGSTART + PFM_NUMBERINGSTYLE
            param.wNumberingStart = CShort(value.NumberingStart)
            param.wNumberingStyle = CShort(value.Style)
            param.wNumbering = CShort(value.Type)

            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, param)
        End Set
    End Property

#End Region

#Region "PRINTING"

    ' Render the contents of the RichTextBox for printing
    '	Return the last character printed + 1 (printing start from this point for next page)
    Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer
        Try
            ' Mark starting and ending character
            Dim cRange As CHARRANGE
            cRange.cpMin = charFrom
            cRange.cpMax = charTo

            ' Calculate the area to render and print
            Dim rectToPrint As RECT
            rectToPrint.Top = CInt(Math.Truncate(e.MarginBounds.Top * AnInch))
            rectToPrint.Bottom = CInt(Math.Truncate(e.MarginBounds.Bottom * AnInch))
            rectToPrint.Left = CInt(Math.Truncate(e.MarginBounds.Left * AnInch))
            rectToPrint.Right = CInt(Math.Truncate(e.MarginBounds.Right * AnInch))

            ' Calculate the size of the page
            Dim rectPage As RECT
            rectPage.Top = CInt(Math.Truncate(e.PageBounds.Top * AnInch))
            rectPage.Bottom = CInt(Math.Truncate(e.PageBounds.Bottom * AnInch))
            rectPage.Left = CInt(Math.Truncate(e.PageBounds.Left * AnInch))
            rectPage.Right = CInt(Math.Truncate(e.PageBounds.Right * AnInch))

            Dim hdc As IntPtr = e.Graphics.GetHdc()

            Dim fmtRange As FORMATRANGE
            fmtRange.chrg = cRange
            ' Indicate character from to character to
            fmtRange.hdc = hdc
            ' Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc
            ' Point at printer hDC
            fmtRange.rc = rectToPrint
            ' Indicate the area on page to print
            fmtRange.rcPage = rectPage
            ' Indicate whole size of page
            Dim res As IntPtr = IntPtr.Zero

            Dim wparam As IntPtr = IntPtr.Zero
            wparam = New IntPtr(1)

            ' Move the pointer to the FORMATRANGE structure in memory
            Dim lparam As IntPtr = IntPtr.Zero
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
            Marshal.StructureToPtr(fmtRange, lparam, False)

            ' Send the rendered data for printing
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

            ' Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam)

            ' Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc)

            ' Return last + 1 character printer
            Return res.ToInt32()
        Catch generatedExceptionName As Exception
            Return -1
        End Try
    End Function

#End Region

#End Region

#Region "OLE PROCESSING"

#Region "OLE definitions"
    Private Const EM_SETOLECALLBACK As Short = WM_USER + 70
    <Flags(), ComVisible(False)> _
    Public Enum STGM As Integer
        STGM_DIRECT = &H0
        STGM_TRANSACTED = &H10000
        STGM_SIMPLE = &H8000000
        STGM_READ = &H0
        STGM_WRITE = &H1
        STGM_READWRITE = &H2
        STGM_SHARE_DENY_NONE = &H40
        STGM_SHARE_DENY_READ = &H30
        STGM_SHARE_DENY_WRITE = &H20
        STGM_SHARE_EXCLUSIVE = &H10
        STGM_PRIORITY = &H40000
        STGM_DELETEONRELEASE = &H4000000
        STGM_NOSCRATCH = &H100000
        STGM_CREATE = &H1000
        STGM_CONVERT = &H20000
        STGM_FAILIFTHERE = &H0
        STGM_NOSNAPSHOT = &H200000
    End Enum

    ' DVASPECT
    <Flags(), ComVisible(False)> _
    Public Enum DVASPECT As Integer
        DVASPECT_CONTENT = 1
        DVASPECT_THUMBNAIL = 2
        DVASPECT_ICON = 4
        DVASPECT_DOCPRINT = 8
        DVASPECT_OPAQUE = 16
        DVASPECT_TRANSPARENT = 32
    End Enum

    ' CLIPFORMAT
    <ComVisible(False)> _
    Public Enum CLIPFORMAT As Integer
        CF_TEXT = 1
        CF_BITMAP = 2
        CF_METAFILEPICT = 3
        CF_SYLK = 4
        CF_DIF = 5
        CF_TIFF = 6
        CF_OEMTEXT = 7
        CF_DIB = 8
        CF_PALETTE = 9
        CF_PENDATA = 10
        CF_RIFF = 11
        CF_WAVE = 12
        CF_UNICODETEXT = 13
        CF_ENHMETAFILE = 14
        CF_HDROP = 15
        CF_LOCALE = 16
        CF_MAX = 17
        CF_OWNERDISPLAY = &H80
        CF_DSPTEXT = &H81
        CF_DSPBITMAP = &H82
        CF_DSPMETAFILEPICT = &H83
        CF_DSPENHMETAFILE = &H8E
    End Enum

    ' Object flags
    <Flags(), ComVisible(False)> _
    Public Enum REOOBJECTFLAGS As UInteger
        REO_NULL = &H0
        ' No flags
        REO_READWRITEMASK = &H3F
        ' Mask out RO bits
        REO_DONTNEEDPALETTE = &H20
        ' Object doesn't need palette
        REO_BLANK = &H10
        ' Object is blank
        REO_DYNAMICSIZE = &H8
        ' Object defines size always
        REO_INVERTEDSELECT = &H4
        ' Object drawn all inverted if sel
        REO_BELOWBASELINE = &H2
        ' Object sits below the baseline
        REO_RESIZABLE = &H1
        ' Object may be resized
        REO_LINK = &H80000000UI
        ' Object is a link (RO)
        REO_STATIC = &H40000000
        ' Object is static (RO)
        REO_SELECTED = &H8000000
        ' Object selected (RO)
        REO_OPEN = &H4000000
        ' Object open in its server (RO)
        REO_INPLACEACTIVE = &H2000000
        ' Object in place active (RO)
        REO_HILITED = &H1000000
        ' Object is to be hilited (RO)
        REO_LINKAVAILABLE = &H800000
        ' Link believed available (RO)
        REO_GETMETAFILE = &H400000
        ' Object requires metafile (RO)
    End Enum

    ' OLERENDER
    <ComVisible(False)> _
    Public Enum OLERENDER As Integer
        OLERENDER_NONE = 0
        OLERENDER_DRAW = 1
        OLERENDER_FORMAT = 2
        OLERENDER_ASIS = 3
    End Enum

    ' TYMED
    <Flags(), ComVisible(False)> _
    Public Enum TYMED As Integer
        TYMED_NULL = 0
        TYMED_HGLOBAL = 1
        TYMED_FILE = 2
        TYMED_ISTREAM = 4
        TYMED_ISTORAGE = 8
        TYMED_GDI = 16
        TYMED_MFPICT = 32
        TYMED_ENHMF = 64
    End Enum

    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure FORMATETC
        Public cfFormat As CLIPFORMAT
        Public ptd As IntPtr
        Public dwAspect As DVASPECT
        Public lindex As Integer
        Public tymed As TYMED
    End Structure

    <StructLayout(LayoutKind.Sequential), ComVisible(False)> _
    Public Structure STGMEDIUM
        '[MarshalAs(UnmanagedType.I4)]
        Public tymed As Integer
        Public unionmember As IntPtr
        Public pUnkForRelease As IntPtr
    End Structure

    <ComVisible(True), ComImport(), Guid("00000103-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumFORMATETC
        <PreserveSig()> _
        Function [Next](<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As FORMATETC, <[In](), Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched As Integer()) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Reset() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Clone(<Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum As IEnumFORMATETC()) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComVisible(True), StructLayout(LayoutKind.Sequential)> _
    Public Class COMRECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer

        Public Sub New()
        End Sub

        Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
            Me.left = left
            Me.top = top
            Me.right = right
            Me.bottom = bottom
        End Sub

        Public Shared Function FromXYWH(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As COMRECT
            Return New COMRECT(x, y, x + width, y + height)
        End Function
    End Class

    Public Enum GETOBJECTOPTIONS
        REO_GETOBJ_NO_INTERFACES = &H0
        REO_GETOBJ_POLEOBJ = &H1
        REO_GETOBJ_PSTG = &H2
        REO_GETOBJ_POLESITE = &H4
        REO_GETOBJ_ALL_INTERFACES = &H7
    End Enum

    Public Enum GETCLIPBOARDDATAFLAGS
        RECO_PASTE = 0
        RECO_DROP = 1
        RECO_COPY = 2
        RECO_CUT = 3
        RECO_DRAG = 4
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Class REOBJECT
        Public cbStruct As Integer = Marshal.SizeOf(GetType(REOBJECT))
        ' Size of structure
        Public cp As Integer
        ' Character position of object
        Public clsid As Guid
        ' Class ID of object
        Public poleobj As IntPtr
        ' OLE object interface
        Public pstg As IStorage
        ' Associated storage interface
        Public polesite As IOleClientSite
        ' Associated client site interface
        Public sizel As Size
        ' Size of object (may be 0,0)
        Public dvAspect As UInteger
        ' Display aspect to use
        Public dwFlags As UInteger
        ' Object status flags
        Public dwUser As UInteger
        ' Dword for user's use
    End Class

    <ComVisible(True), Guid("0000010F-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAdviseSink

        'C#r: UNDONE (Field in interface) public static readonly    Guid iid;
        Sub OnDataChange(<[In]()> ByVal pFormatetc As FORMATETC, <[In]()> ByVal pStgmed As STGMEDIUM)

        Sub OnViewChange(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAspect As Integer, <[In](), MarshalAs(UnmanagedType.I4)> ByVal lindex As Integer)

        Sub OnRename(<[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pmk As Object)

        Sub OnSave()


        Sub OnClose()
    End Interface

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class STATDATA

        <MarshalAs(UnmanagedType.U4)> _
        Public advf As Integer
        <MarshalAs(UnmanagedType.U4)> _
        Public dwConnection As Integer

    End Class

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class tagOLEVERB
        <MarshalAs(UnmanagedType.I4)> _
        Public lVerb As Integer

        <MarshalAs(UnmanagedType.LPWStr)> _
        Public lpszVerbName As [String]

        <MarshalAs(UnmanagedType.U4)> _
        Public fuFlags As Integer

        <MarshalAs(UnmanagedType.U4)> _
        Public grfAttribs As Integer

    End Class

    <ComVisible(True), ComImport(), Guid("00000104-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumOLEVERB

        <PreserveSig()> _
        Function [Next](<MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As tagOLEVERB, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched As Integer()) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        Sub Reset()


        Sub Clone(ByRef ppenum As IEnumOLEVERB)


    End Interface

    <ComVisible(True), Guid("00000105-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATDATA

        'C#r: UNDONE (Field in interface) public static readonly    Guid iid;

        Sub [Next](<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer, <Out()> ByVal rgelt As STATDATA, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pceltFetched As Integer())


        Sub Skip(<[In](), MarshalAs(UnmanagedType.U4)> ByVal celt As Integer)


        Sub Reset()


        Sub Clone(<Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum As IEnumSTATDATA())


    End Interface

    <ComVisible(True), Guid("0000011B-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleContainer


        Sub ParseDisplayName(<[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pbc As Object, <[In](), MarshalAs(UnmanagedType.BStr)> ByVal pszDisplayName As String, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal pchEaten As Integer(), <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppmkOut As Object())


        Sub EnumObjects(<[In](), MarshalAs(UnmanagedType.U4)> ByVal grfFlags As Integer, <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal ppenum As Object())


        Sub LockContainer(<[In](), MarshalAs(UnmanagedType.I4)> ByVal fLock As Integer)
    End Interface

    <ComVisible(True), ComImport(), Guid("0000010E-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IDataObject
        <PreserveSig()> _
        Function GetData(ByRef a As FORMATETC, ByRef b As STGMEDIUM) As UInteger

        <PreserveSig()> _
        Function GetDataHere(ByRef pFormatetc As FORMATETC, ByRef pMedium As STGMEDIUM) As UInteger

        <PreserveSig()> _
        Function QueryGetData(ByRef pFormatetc As FORMATETC) As UInteger

        <PreserveSig()> _
        Function GetCanonicalFormatEtc(ByRef pformatectIn As FORMATETC, ByRef pformatetcOut As FORMATETC) As UInteger

        <PreserveSig()> _
        Function SetData(ByRef pFormatectIn As FORMATETC, ByRef pmedium As STGMEDIUM, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fRelease As Boolean) As UInteger

        <PreserveSig()> _
        Function EnumFormatEtc(ByVal dwDirection As UInteger, ByVal penum As IEnumFORMATETC) As UInteger

        <PreserveSig()> _
        Function DAdvise(ByRef pFormatetc As FORMATETC, ByVal advf As Integer, <[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pAdvSink As IAdviseSink, ByRef pdwConnection As UInteger) As UInteger

        <PreserveSig()> _
        Function DUnadvise(ByVal dwConnection As UInteger) As UInteger

        <PreserveSig()> _
        Function EnumDAdvise(<Out(), MarshalAs(UnmanagedType.[Interface])> ByRef ppenumAdvise As IEnumSTATDATA) As UInteger
    End Interface

    <ComVisible(True), Guid("00000118-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleClientSite

        <PreserveSig()> _
        Function SaveObject() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAssign As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, <Out(), MarshalAs(UnmanagedType.[Interface])> ByRef ppmk As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetContainer(<MarshalAs(UnmanagedType.[Interface])> ByRef container As IOleContainer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ShowObject() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function OnShowWindow(<[In](), MarshalAs(UnmanagedType.I4)> ByVal fShow As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function RequestNewObjectLayout() As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComVisible(False), StructLayout(LayoutKind.Sequential)> _
    Public NotInheritable Class tagLOGPALETTE
        'leftover(offset=0, palVersion)
        <MarshalAs(UnmanagedType.U2)> _
        Public palVersion As Short

        'leftover(offset=2, palNumEntries)
        <MarshalAs(UnmanagedType.U2)> _
        Public palNumEntries As Short

        ' UNMAPPABLE: palPalEntry: Cannot be used as a structure field.
        '   /** @com.structmap(UNMAPPABLE palPalEntry) */
        '  public UNMAPPABLE palPalEntry;
    End Class

    <ComVisible(True), ComImport(), Guid("00000112-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleObject

        <PreserveSig()> _
        Function SetClientSite(<[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pClientSite As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetClientSite(ByRef site As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetHostNames(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal szContainerApp As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal szContainerObj As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Close(<[In](), MarshalAs(UnmanagedType.I4)> ByVal dwSaveOption As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, <[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pmk As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMoniker(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAssign As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwWhichMoniker As Integer, ByRef moniker As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InitFromData(<[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pDataObject As IDataObject, <[In](), MarshalAs(UnmanagedType.I4)> ByVal fCreation As Integer, <[In](), MarshalAs(UnmanagedType.U4)> ByVal dwReserved As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        Function GetClipboardData(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwReserved As Integer, ByRef data As IDataObject) As Integer

        <PreserveSig()> _
        Function DoVerb(<[In](), MarshalAs(UnmanagedType.I4)> ByVal iVerb As Integer, <[In]()> ByVal lpmsg As IntPtr, <[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pActiveSite As IOleClientSite, <[In](), MarshalAs(UnmanagedType.I4)> ByVal lindex As Integer, <[In]()> ByVal hwndParent As IntPtr, <[In]()> ByVal lprcPosRect As COMRECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnumVerbs(ByRef e As IEnumOLEVERB) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Update() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function IsUpToDate() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetUserClassID(<[In](), Out()> ByRef pClsid As Guid) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetUserType(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwFormOfType As Integer, <Out(), MarshalAs(UnmanagedType.LPWStr)> ByRef userType As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetExtent(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwDrawAspect As Integer, <[In]()> ByVal pSizel As Size) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetExtent(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwDrawAspect As Integer, <Out()> ByVal pSizel As Size) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Advise(<[In](), MarshalAs(UnmanagedType.[Interface])> ByVal pAdvSink As IAdviseSink, ByRef cookie As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function Unadvise(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwConnection As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnumAdvise(ByRef e As IEnumSTATDATA) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetMiscStatus(<[In](), MarshalAs(UnmanagedType.U4)> ByVal dwAspect As Integer, ByRef misc As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetColorScheme(<[In]()> ByVal pLogpal As tagLOGPALETTE) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComImport()> _
    <Guid("0000000d-0000-0000-C000-000000000046")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATSTG
        ' The user needs to allocate an STATSTG array whose size is celt.
        <PreserveSig()> _
        Function [Next](ByVal celt As UInteger, <MarshalAs(UnmanagedType.LPArray), Out()> ByVal rgelt As STATSTG(), ByRef pceltFetched As UInteger) As UInteger

        Sub Skip(ByVal celt As UInteger)

        Sub Reset()

        Function Clone() As <MarshalAs(UnmanagedType.[Interface])> IEnumSTATSTG
    End Interface

    <ComImport()> _
    <Guid("0000000b-0000-0000-C000-000000000046")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IStorage
        ' [string][in] 
        ' [in] 
        ' [in] 
        ' [in] 
        ' [out] 
        Function CreateStream(ByVal pwcsName As String, ByVal grfMode As UInteger, ByVal reserved1 As UInteger, ByVal reserved2 As UInteger, ByRef ppstm As IStream) As Integer

        ' [string][in] 
        ' [unique][in] 
        ' [in] 
        ' [in] 
        ' [out] 
        Function OpenStream(ByVal pwcsName As String, ByVal reserved1 As IntPtr, ByVal grfMode As UInteger, ByVal reserved2 As UInteger, ByRef ppstm As IStream) As Integer

        ' [string][in] 
        ' [in] 
        ' [in] 
        ' [in] 
        ' [out] 
        Function CreateStorage(ByVal pwcsName As String, ByVal grfMode As UInteger, ByVal reserved1 As UInteger, ByVal reserved2 As UInteger, ByRef ppstg As IStorage) As Integer

        ' [string][unique][in] 
        ' [unique][in] 
        ' [in] 
        ' [unique][in] 
        ' [in] 
        ' [out] 
        Function OpenStorage(ByVal pwcsName As String, ByVal pstgPriority As IStorage, ByVal grfMode As UInteger, ByVal snbExclude As IntPtr, ByVal reserved As UInteger, ByRef ppstg As IStorage) As Integer

        ' [in] 
        ' [size_is][unique][in] 
        ' [unique][in] 
        ' [unique][in] 
        Function CopyTo(ByVal ciidExclude As UInteger, ByVal rgiidExclude As Guid, ByVal snbExclude As IntPtr, ByVal pstgDest As IStorage) As Integer

        ' [string][in] 
        ' [unique][in] 
        ' [string][in] 
        ' [in] 
        Function MoveElementTo(ByVal pwcsName As String, ByVal pstgDest As IStorage, ByVal pwcsNewName As String, ByVal grfFlags As UInteger) As Integer

        ' [in] 
        Function Commit(ByVal grfCommitFlags As UInteger) As Integer

        Function Revert() As Integer

        ' [in] 
        ' [size_is][unique][in] 
        ' [in] 
        ' [out] 
        Function EnumElements(ByVal reserved1 As UInteger, ByVal reserved2 As IntPtr, ByVal reserved3 As UInteger, ByRef ppenum As IEnumSTATSTG) As Integer

        ' [string][in] 
        Function DestroyElement(ByVal pwcsName As String) As Integer

        ' [string][in] 
        ' [string][in] 
        Function RenameElement(ByVal pwcsOldName As String, ByVal pwcsNewName As String) As Integer

        ' [string][unique][in] 
        ' [unique][in] 
        ' [unique][in] 
        ' [unique][in] 
        Function SetElementTimes(ByVal pwcsName As String, ByVal pctime As FILETIME, ByVal patime As FILETIME, ByVal pmtime As FILETIME) As Integer

        ' [in] 
        Function SetClass(ByVal clsid As Guid) As Integer

        ' [in] 
        ' [in] 
        Function SetStateBits(ByVal grfStateBits As UInteger, ByVal grfMask As UInteger) As Integer

        ' [out] 
        ' [in] 
        Function Stat(ByRef pstatstg As STATSTG, ByVal grfStatFlag As UInteger) As Integer

    End Interface

    <ComImport()> _
    <Guid("0000000a-0000-0000-C000-000000000046")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface ILockBytes
        ' [in] 
        ' [unique][out] 
        ' [in] 
        ' [out] 
        Function ReadAt(ByVal ulOffset As ULong, ByVal pv As IntPtr, ByVal cb As UInteger, ByRef pcbRead As IntPtr) As Integer

        ' [in] 
        ' [size_is][in] 
        ' [in] 
        ' [out] 
        Function WriteAt(ByVal ulOffset As ULong, ByVal pv As IntPtr, ByVal cb As UInteger, ByRef pcbWritten As IntPtr) As Integer

        Function Flush() As Integer

        ' [in] 
        Function SetSize(ByVal cb As ULong) As Integer

        ' [in] 
        ' [in] 
        ' [in] 
        Function LockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer

        ' [in] 
        ' [in] 
        ' [in] 
        Function UnlockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer

        ' [out] 
        ' [in] 
        Function Stat(ByRef pstatstg As STATSTG, ByVal grfStatFlag As UInteger) As Integer

    End Interface

    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")> _
    Public Interface ISequentialStream
        ' [length_is][size_is][out] 
        ' [in] 
        ' [out] 
        Function Read(ByVal pv As IntPtr, ByVal cb As UInteger, ByRef pcbRead As UInteger) As Integer

        ' [size_is][in] 
        ' [in] 
        ' [out] 
        Function Write(ByVal pv As IntPtr, ByVal cb As UInteger, ByRef pcbWritten As UInteger) As Integer

    End Interface

    <ComImport()> _
    <Guid("0000000c-0000-0000-C000-000000000046")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IStream
        Inherits ISequentialStream
        ' [in] 
        ' [in] 
        ' [out] 
        Function Seek(ByVal dlibMove As ULong, ByVal dwOrigin As UInteger, ByRef plibNewPosition As ULong) As Integer

        ' [in] 
        Function SetSize(ByVal libNewSize As ULong) As Integer

        ' [unique][in] 
        ' [in] 
        ' [out] 
        ' [out] 
        Function CopyTo(<[In]()> ByVal pstm As IStream, ByVal cb As ULong, ByRef pcbRead As ULong, ByRef pcbWritten As ULong) As Integer

        ' [in] 
        Function Commit(ByVal grfCommitFlags As UInteger) As Integer

        Function Revert() As Integer

        ' [in] 
        ' [in] 
        ' [in] 
        Function LockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer

        ' [in] 
        ' [in] 
        ' [in] 
        Function UnlockRegion(ByVal libOffset As ULong, ByVal cb As ULong, ByVal dwLockType As UInteger) As Integer

        ' [out] 
        ' [in] 
        Function Stat(ByRef pstatstg As STATSTG, ByVal grfStatFlag As UInteger) As Integer

        ' [out] 
        Function Clone(ByRef ppstm As IStream) As Integer

    End Interface

    ''' <summary>
    ''' Definition for interface IPersist.
    ''' </summary>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")> _
    Public Interface IPersist
        ''' <summary>
        ''' getClassID
        ''' </summary>
        ''' <param name="pClassID"></param>
        ' [out] 
        Sub GetClassID(ByRef pClassID As Guid)
    End Interface

    ''' <summary>
    ''' Definition for interface IPersistStream.
    ''' </summary>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000109-0000-0000-C000-000000000046")> _
    Public Interface IPersistStream
        Inherits IPersist
        ''' <summary>
        ''' GetClassID
        ''' </summary>
        ''' <param name="pClassID"></param>
        Shadows Sub GetClassID(ByRef pClassID As Guid)
        ''' <summary>
        ''' isDirty
        ''' </summary>
        ''' <returns></returns>
        <PreserveSig()> _
        Function IsDirty() As Integer
        ''' <summary>
        ''' Load
        ''' </summary>
        ''' <param name="pStm"></param>
        Sub Load(<[In]()> ByVal pStm As UCOMIStream)
        ''' <summary>
        ''' Save
        ''' </summary>
        ''' <param name="pStm"></param>
        ''' <param name="fClearDirty"></param>
        Sub Save(<[In]()> ByVal pStm As UCOMIStream, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fClearDirty As Boolean)
        ''' <summary>
        ''' GetSizeMax
        ''' </summary>
        ''' <param name="pcbSize"></param>
        Sub GetSizeMax(ByRef pcbSize As Long)
    End Interface

    <ComImport(), Guid("00020D00-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IRichEditOle
        <PreserveSig()> _
        Function GetClientSite(ByRef site As IOleClientSite) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetObjectCount() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetLinkCount() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetObject(ByVal iob As Integer, <[In](), Out()> ByVal lpreobject As REOBJECT, <MarshalAs(UnmanagedType.U4)> ByVal flags As GETOBJECTOPTIONS) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InsertObject(ByVal lpreobject As REOBJECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ConvertObject(ByVal iob As Integer, ByVal rclsidNew As Guid, ByVal lpstrUserTypeNew As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ActivateAs(ByVal rclsid As Guid, ByVal rclsidAs As Guid) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetHostNames(ByVal lpstrContainerApp As String, ByVal lpstrContainerObj As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetLinkAvailable(ByVal iob As Integer, ByVal fAvailable As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetDvaspect(ByVal iob As Integer, ByVal dvaspect As UInteger) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function HandsOffStorage(ByVal iob As Integer) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SaveCompleted(ByVal iob As Integer, ByVal lpstg As IStorage) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InPlaceDeactivate() As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ContextSensitiveHelp(ByVal fEnterMode As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetClipboardData(<[In](), Out()> ByRef lpchrg As CHARRANGE, <MarshalAs(UnmanagedType.U4)> ByVal reco As GETCLIPBOARDDATAFLAGS, ByRef lplpdataobj As IDataObject) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ImportDataObject(ByVal lpdataobj As IDataObject, ByVal cf As Integer, ByVal hMetaPict As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface


    <ComVisible(True), ComImport(), Guid("00000115-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleInPlaceUIWindow
        'IOleWindow
        <PreserveSig()> _
        Function GetWindow(<[In](), Out()> ByRef phwnd As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ContextSensitiveHelp(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fEnterMode As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        'IOleInPlaceUIWindow
        <PreserveSig()> _
        Function GetBorder(<[In](), Out(), MarshalAs(UnmanagedType.Struct)> ByRef lprectBorder As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function RequestBorderSpace(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef pborderwidths As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetBorderSpace(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef pborderwidths As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetActiveObject(<[In](), MarshalAs(UnmanagedType.[Interface])> ByRef pActiveObject As IOleInPlaceActiveObject, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszObjName As String) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("00000117-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleInPlaceActiveObject
        <PreserveSig()> _
        Function GetWindow(<[In](), Out()> ByRef phwnd As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ContextSensitiveHelp(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fEnterMode As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function TranslateAccelerator(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef lpmsg As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function OnFrameWindowActivate(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fActivate As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function OnDocWindowActivate(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fActivate As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ResizeBorder(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef prcBorder As RECT, <[In](), MarshalAs(UnmanagedType.[Interface])> ByRef pUIWindow As IOleInPlaceUIWindow, <[In](), MarshalAs(UnmanagedType.Bool)> ByVal fFrameWindow As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnableModeless(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fEnable As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <ComVisible(True), ComImport(), Guid("00000116-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleInPlaceFrame
        <PreserveSig()> _
        Function GetWindow(<[In](), Out()> ByRef phwnd As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function ContextSensitiveHelp(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fEnterMode As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function GetBorder(<Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal lprectBorder As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function RequestBorderSpace(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef pborderwidths As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetBorderSpace(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef pborderwidths As RECT) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetActiveObject(<[In](), MarshalAs(UnmanagedType.[Interface])> ByRef pActiveObject As IOleInPlaceActiveObject, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszObjName As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function InsertMenus(<[In]()> ByVal hmenuShared As IntPtr, <[In](), Out(), MarshalAs(UnmanagedType.Struct)> ByRef lpMenuWidths As Object) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetMenu(<[In]()> ByVal hmenuShared As IntPtr, <[In]()> ByVal holemenu As IntPtr, <[In]()> ByVal hwndActiveObject As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function RemoveMenus(<[In]()> ByVal hmenuShared As IntPtr) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function SetStatusText(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszStatusText As String) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function EnableModeless(<[In](), MarshalAs(UnmanagedType.Bool)> ByVal fEnable As Boolean) As <MarshalAs(UnmanagedType.I4)> Integer

        <PreserveSig()> _
        Function TranslateAccelerator(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef lpmsg As String, <[In](), MarshalAs(UnmanagedType.U2)> ByVal wID As Short) As <MarshalAs(UnmanagedType.I4)> Integer
    End Interface

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure OLEINPLACEFRAMEINFO
        Public cb As UInteger
        <MarshalAs(UnmanagedType.Bool)> _
        Public fMDIApp As Boolean
        Public hwndFrame As IntPtr
        Public haccel As IntPtr
        Public cAccelEntries As UInteger
    End Structure

    <ComVisible(True), ComImport(), Guid("00020D03-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IRichEditOleCallback
        Function GetNewStorage() As IStorage
        Sub GetInPlaceContext(ByVal lplpFrame As IOleInPlaceFrame, ByVal lplpDoc As IOleInPlaceUIWindow, ByRef lpFrameInfo As OLEINPLACEFRAMEINFO)
        Sub ShowContainerUI(<MarshalAs(UnmanagedType.Bool)> ByVal fShow As Boolean)
        Sub QueryInsertObject(ByRef lpclsid As Guid, ByVal lpstg As IStorage, ByVal cp As Integer)
        Sub DeleteObject(ByVal lpoleobj As IOleObject)
        Sub QueryAcceptData(ByVal lpdataobj As IDataObject, ByRef lpcfFormat As CLIPFORMAT, ByVal reco As UInteger, <MarshalAs(UnmanagedType.Bool)> ByVal fReally As Boolean, ByVal hMetaPict As IntPtr)
        Sub ContextSensitiveHelp(<MarshalAs(UnmanagedType.Bool)> ByVal fEnterMode As Boolean)
        Function GetClipboardData(ByRef lpchrg As CHARRANGE, ByVal reco As UInteger) As IDataObject
        Function GetDragDropEffect(<MarshalAs(UnmanagedType.Bool)> ByVal fDrag As Boolean, ByVal grfKeyState As UInteger) As UInteger
        Function GetContextMenu(ByVal seltype As UShort, ByVal lpoleobj As IOleObject, ByRef lpchrg As CHARRANGE) As IntPtr
    End Interface

#End Region

#Region "OLE API"

    <DllImport("User32.dll", CharSet:=CharSet.Auto, PreserveSig:=False)> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal message As Integer, ByVal wParam As Integer) As IRichEditOle
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Friend Shared Function GetClientRect(ByVal hWnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Boolean
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Friend Shared Function GetWindowRect(ByVal hWnd As IntPtr, <[In](), Out()> ByRef rect As Rectangle) As Boolean
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Friend Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleSetContainedObject(<MarshalAs(UnmanagedType.IUnknown)> ByVal pUnk As Object, ByVal fContained As Boolean) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleLoadPicturePath(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpszPicturePath As String, <MarshalAs(UnmanagedType.IUnknown)> <[In]()> ByVal pIUnknown As Object, ByVal dwReserved As UInteger, ByVal clrReserved As UInteger, ByRef riid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleCreateFromFile(<[In]()> ByRef rclsid As Guid, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszFileName As String, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, _
  ByVal pStg As IStorage, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleCreateFromData(ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, _
  <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleCreateStaticFromData(<MarshalAs(UnmanagedType.[Interface])> ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, _
  <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function OleCreateLinkFromData(<MarshalAs(UnmanagedType.[Interface])> ByVal pSrcDataObj As IDataObject, <[In]()> ByRef riid As Guid, ByVal renderopt As UInteger, ByRef pFormatEtc As FORMATETC, ByVal pClientSite As IOleClientSite, ByVal pStg As IStorage, _
  <MarshalAs(UnmanagedType.IUnknown)> ByRef ppvObj As Object) As Integer
    End Function

    <DllImport("ole32.dll", PreserveSig:=False)> _
    Friend Shared Function CreateILockBytesOnHGlobal(ByVal hGlobal As IntPtr, ByVal fDeleteOnRelease As Boolean, <Out()> ByRef ppLkbyt As ILockBytes) As Integer
    End Function

    <DllImport("ole32.dll")> _
    Private Shared Function StgCreateDocfileOnILockBytes(ByVal plkbyt As ILockBytes, ByVal grfMode As UInteger, ByVal reserved As UInteger, ByRef ppstgOpen As IStorage) As Integer
    End Function


#End Region

    Public Class DataObject
        Implements IDataObject
        Private mBitmap As Bitmap
        Public mpFormatetc As FORMATETC

#Region "IDataObject Members"

        Private Const S_OK As UInteger = 0
        Private Const E_POINTER As UInteger = &H80004003UI
        Private Const E_NOTIMPL As UInteger = &H80004001UI
        Private Const E_FAIL As UInteger = &H80004005UI

        Public Function GetData(ByRef pFormatetc As FORMATETC, ByRef pMedium As STGMEDIUM) As UInteger Implements ExtendedRichTextBox.IDataObject.GetData
            Dim hDst As IntPtr = mBitmap.GetHbitmap()

            pMedium.tymed = CInt(TYMED.TYMED_GDI)
            pMedium.unionmember = hDst
            pMedium.pUnkForRelease = IntPtr.Zero

            Return CUInt(S_OK)
        End Function

        Public Function GetDataHere(ByRef pFormatetc As FORMATETC, ByRef pMedium As STGMEDIUM) As UInteger Implements ExtendedRichTextBox.IDataObject.GetDataHere
            Trace.WriteLine("GetDataHere")

            pMedium = New STGMEDIUM()

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function QueryGetData(ByRef pFormatetc As FORMATETC) As UInteger Implements ExtendedRichTextBox.IDataObject.QueryGetData
            Trace.WriteLine("QueryGetData")

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function GetCanonicalFormatEtc(ByRef pFormatetcIn As FORMATETC, ByRef pFormatetcOut As FORMATETC) As UInteger Implements ExtendedRichTextBox.IDataObject.GetCanonicalFormatEtc
            Trace.WriteLine("GetCanonicalFormatEtc")

            pFormatetcOut = New FORMATETC()

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function SetData(ByRef a As FORMATETC, ByRef b As STGMEDIUM, ByVal fRelease As Boolean) As UInteger Implements ExtendedRichTextBox.IDataObject.SetData
            'mpFormatetc = pFormatectIn;
            'mpmedium = pmedium;

            Trace.WriteLine("SetData")

            Return CInt(S_OK)
        End Function

        Public Function EnumFormatEtc(ByVal dwDirection As UInteger, ByVal penum As IEnumFORMATETC) As UInteger Implements ExtendedRichTextBox.IDataObject.EnumFormatEtc
            Trace.WriteLine("EnumFormatEtc")

            Return CInt(S_OK)
        End Function

        Public Function DAdvise(ByRef a As FORMATETC, ByVal advf As Integer, ByVal pAdvSink As IAdviseSink, ByRef pdwConnection As UInteger) As UInteger Implements ExtendedRichTextBox.IDataObject.DAdvise
            Trace.WriteLine("DAdvise")

            pdwConnection = 0

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function DUnadvise(ByVal dwConnection As UInteger) As UInteger Implements ExtendedRichTextBox.IDataObject.DUnadvise
            Trace.WriteLine("DUnadvise")

            Return CUInt(E_NOTIMPL)
        End Function

        Public Function EnumDAdvise(ByRef ppenumAdvise As IEnumSTATDATA) As UInteger Implements ExtendedRichTextBox.IDataObject.EnumDAdvise
            Trace.WriteLine("EnumDAdvise")

            ppenumAdvise = Nothing

            Return CUInt(E_NOTIMPL)
        End Function

#End Region

        Public Sub New()
            mBitmap = New Bitmap(16, 16)
            mpFormatetc = New FORMATETC()
        End Sub

        Public Sub SetImage(ByVal strFilename As String)
            Try
                mBitmap = DirectCast(Bitmap.FromFile(strFilename, True), Bitmap)

                mpFormatetc.cfFormat = CLIPFORMAT.CF_BITMAP
                ' Clipboard format = CF_BITMAP
                mpFormatetc.ptd = IntPtr.Zero
                ' Target Device = Screen
                mpFormatetc.dwAspect = DVASPECT.DVASPECT_CONTENT
                ' Level of detail = Full content
                mpFormatetc.lindex = -1
                ' Index = Not applicaple
                ' Storage medium = HBITMAP handle
                mpFormatetc.tymed = TYMED.TYMED_GDI
            Catch
            End Try
        End Sub

        Public Sub SetImage(ByVal image As Image)
            Try
                mBitmap = New Bitmap(image)

                mpFormatetc.cfFormat = CLIPFORMAT.CF_BITMAP
                ' Clipboard format = CF_BITMAP
                mpFormatetc.ptd = IntPtr.Zero
                ' Target Device = Screen
                mpFormatetc.dwAspect = DVASPECT.DVASPECT_CONTENT
                ' Level of detail = Full content
                mpFormatetc.lindex = -1
                ' Index = Not applicaple
                ' Storage medium = HBITMAP handle
                mpFormatetc.tymed = TYMED.TYMED_GDI
            Catch
            End Try
        End Sub
    End Class

    ' RichEditOle wrapper and helper
    Private Class RichEditOle
        Public Const WM_USER As Integer = &H400
        Public Const EM_GETOLEINTERFACE As Integer = WM_USER + 60

        Private _richEdit As ExtendedRichTextBox
        Private _RichEditOle As IRichEditOle

        Public Sub New(ByVal richEdit As ExtendedRichTextBox)
            Me._richEdit = richEdit
        End Sub

        Private ReadOnly Property IRichEditOle() As IRichEditOle
            Get
                If Me._RichEditOle Is Nothing Then
                    Me._RichEditOle = SendMessage(Me._richEdit.Handle, EM_GETOLEINTERFACE, 0)
                End If

                Return Me._RichEditOle
            End Get
        End Property

        <DllImport("ole32.dll", PreserveSig:=False)> _
        Friend Shared Function CreateILockBytesOnHGlobal(ByVal hGlobal As IntPtr, ByVal fDeleteOnRelease As Boolean, <Out()> ByRef ppLkbyt As ILockBytes) As Integer
        End Function

        <DllImport("ole32.dll")> _
        Private Shared Function StgCreateDocfileOnILockBytes(ByVal plkbyt As ILockBytes, ByVal grfMode As UInteger, ByVal reserved As UInteger, ByRef ppstgOpen As IStorage) As Integer
        End Function

        Public Function GetObjectByIndex(ByVal objIndex As Integer) As REOBJECT
            Try
                Dim obj As New REOBJECT()
                Me.IRichEditOle.GetObject(objIndex, obj, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES)
                Return obj
            Catch generatedExceptionName As Exception
                ' it seems that invalid index was specified
                Return Nothing
            End Try
        End Function

        Public Function GetSelectedObject() As REOBJECT
            Dim obj As New REOBJECT()
            Me.IRichEditOle.GetObject(-1, obj, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES)
            Return obj
        End Function

        Public Sub InsertControl(ByVal control As Control)
            If control Is Nothing Then
                Return
            End If

            Dim guid As Guid = Marshal.GenerateGuidForType(control.[GetType]())

            '-----------------------
            Dim pLockBytes As ILockBytes
            CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

            Dim pStorage As IStorage
            StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

            Dim pOleClientSite As IOleClientSite
            Me.IRichEditOle.GetClientSite(pOleClientSite)
            '-----------------------

            '-----------------------
            Dim reoObject As New REOBJECT()

            reoObject.cp = Me._richEdit.TextLength

            reoObject.clsid = guid
            reoObject.pstg = pStorage
            reoObject.poleobj = Marshal.GetIUnknownForObject(control)
            reoObject.polesite = pOleClientSite
            reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
            reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE Or REOOBJECTFLAGS.REO_RESIZABLE)
            reoObject.dwUser = 1

            Me.IRichEditOle.InsertObject(reoObject)
            '-----------------------

            '-----------------------
            Marshal.ReleaseComObject(pLockBytes)
            Marshal.ReleaseComObject(pOleClientSite)
            Marshal.ReleaseComObject(pStorage)
            '-----------------------
        End Sub

        Public Function InsertImageFromFile(ByVal strFilename As String) As Boolean
            '-----------------------
            Dim pLockBytes As ILockBytes
            CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

            Dim pStorage As IStorage
            StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

            Dim pOleClientSite As IOleClientSite
            Me.IRichEditOle.GetClientSite(pOleClientSite)
            '-----------------------


            '-----------------------
            Dim formatEtc As New FORMATETC()

            formatEtc.cfFormat = 0
            formatEtc.ptd = IntPtr.Zero
            formatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT
            formatEtc.lindex = -1
            formatEtc.tymed = TYMED.TYMED_NULL

            Dim IID_IOleObject As New Guid("{00000112-0000-0000-C000-000000000046}")
            Dim CLSID_NULL As New Guid("{00000000-0000-0000-0000-000000000000}")

            Dim pOleObjectOut As Object

            ' I don't sure, but it appears that this function only loads from bitmap
            ' You can also try OleCreateFromData, OleLoadPictureIndirect, etc.
            Dim hr As Integer = OleCreateFromFile(CLSID_NULL, strFilename, IID_IOleObject, CUInt(OLERENDER.OLERENDER_DRAW), formatEtc, pOleClientSite, _
             pStorage, pOleObjectOut)

            If pOleObjectOut Is Nothing Then
                Marshal.ReleaseComObject(pLockBytes)
                Marshal.ReleaseComObject(pOleClientSite)
                Marshal.ReleaseComObject(pStorage)

                Return False
            End If

            Dim pOleObject As IOleObject = DirectCast(pOleObjectOut, IOleObject)
            '-----------------------


            '-----------------------
            Dim guid As New Guid()

            'guid = Marshal.GenerateGuidForType(pOleObject.GetType());
            pOleObject.GetUserClassID(guid)
            '-----------------------

            '-----------------------
            OleSetContainedObject(pOleObject, True)

            Dim reoObject As New REOBJECT()

            reoObject.cp = Me._richEdit.TextLength

            reoObject.clsid = guid
            reoObject.pstg = pStorage
            reoObject.poleobj = Marshal.GetIUnknownForObject(pOleObject)
            reoObject.polesite = pOleClientSite
            reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
            reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE Or REOOBJECTFLAGS.REO_RESIZABLE)
            reoObject.dwUser = 0

            Me.IRichEditOle.InsertObject(reoObject)
            '-----------------------

            '-----------------------
            Marshal.ReleaseComObject(pLockBytes)
            Marshal.ReleaseComObject(pOleClientSite)
            Marshal.ReleaseComObject(pStorage)
            Marshal.ReleaseComObject(pOleObject)
            '-----------------------

            Return True
        End Function

        Public Sub InsertMyDataObject(ByVal dobj As DataObject)
            If dobj Is Nothing Then
                Return
            End If

            '-----------------------
            Dim pLockBytes As ILockBytes
            Dim sc As Integer = CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

            Dim pStorage As IStorage
            sc = StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

            Dim pOleClientSite As IOleClientSite
            Me.IRichEditOle.GetClientSite(pOleClientSite)
            '-----------------------

            Dim guid As Guid = Marshal.GenerateGuidForType(dobj.[GetType]())

            Dim IID_IOleObject As New Guid("{00000112-0000-0000-C000-000000000046}")
            Dim IID_IDataObject As New Guid("{0000010e-0000-0000-C000-000000000046}")
            Dim IID_IUnknown As New Guid("{00000000-0000-0000-C000-000000000046}")

            Dim pOleObject As Object

            Dim hr As Integer = OleCreateStaticFromData(dobj, IID_IOleObject, CUInt(OLERENDER.OLERENDER_FORMAT), dobj.mpFormatetc, pOleClientSite, pStorage, _
             pOleObject)

            If pOleObject Is Nothing Then
                Return
            End If
            '-----------------------


            '-----------------------
            OleSetContainedObject(pOleObject, True)

            Dim reoObject As New REOBJECT()

            reoObject.cp = Me._richEdit.TextLength

            reoObject.clsid = guid
            reoObject.pstg = pStorage
            reoObject.poleobj = Marshal.GetIUnknownForObject(pOleObject)
            reoObject.polesite = pOleClientSite
            reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
            reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE Or REOOBJECTFLAGS.REO_RESIZABLE)
            reoObject.dwUser = 0

            Me.IRichEditOle.InsertObject(reoObject)
            '-----------------------

            '-----------------------
            Marshal.ReleaseComObject(pLockBytes)
            Marshal.ReleaseComObject(pOleClientSite)
            Marshal.ReleaseComObject(pStorage)
            Marshal.ReleaseComObject(pOleObject)
            '-----------------------
        End Sub

        Public Sub InsertOleObject(ByVal oleObject As IOleObject)
            If oleObject Is Nothing Then
                Return
            End If

            '-----------------------
            Dim pLockBytes As ILockBytes
            CreateILockBytesOnHGlobal(IntPtr.Zero, True, pLockBytes)

            Dim pStorage As IStorage
            StgCreateDocfileOnILockBytes(pLockBytes, CUInt(STGM.STGM_SHARE_EXCLUSIVE Or STGM.STGM_CREATE Or STGM.STGM_READWRITE), 0, pStorage)

            Dim pOleClientSite As IOleClientSite
            Me.IRichEditOle.GetClientSite(pOleClientSite)
            '-----------------------

            '-----------------------
            Dim guid As New Guid()

            oleObject.GetUserClassID(guid)
            '-----------------------

            '-----------------------
            OleSetContainedObject(oleObject, True)

            Dim reoObject As New REOBJECT()

            reoObject.cp = Me._richEdit.TextLength

            reoObject.clsid = guid
            reoObject.pstg = pStorage
            reoObject.poleobj = Marshal.GetIUnknownForObject(oleObject)
            reoObject.polesite = pOleClientSite
            reoObject.dvAspect = CUInt(DVASPECT.DVASPECT_CONTENT)
            reoObject.dwFlags = CUInt(REOOBJECTFLAGS.REO_BELOWBASELINE Or REOOBJECTFLAGS.REO_RESIZABLE)

            Me.IRichEditOle.InsertObject(reoObject)
            '-----------------------

            '-----------------------
            Marshal.ReleaseComObject(pLockBytes)
            Marshal.ReleaseComObject(pOleClientSite)
            Marshal.ReleaseComObject(pStorage)
            '-----------------------
        End Sub

        Public Sub UpdateObjects()
            Dim k As Integer = Me.IRichEditOle.GetObjectCount()

            If k = 0 Then
                Return
            End If

            For i As Integer = 0 To k - 1
                Dim reoObject As New REOBJECT()

                Me.IRichEditOle.GetObject(i, reoObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES)

                If reoObject.dwUser = 1 Then
                    Dim pt As Point = Me._richEdit.GetPositionFromCharIndex(reoObject.cp)
                    Dim rect As New Rectangle(pt, reoObject.sizel)

                    ' repaint
                    Me._richEdit.Invalidate(rect, False)
                End If
            Next
        End Sub
    End Class

    Public Sub InsertOleObject(ByVal oleObj As IOleObject)
        Dim ole As New RichEditOle(Me)
        ole.InsertOleObject(oleObj)
    End Sub

    Public Sub InsertControl(ByVal control As Control)
        Dim ole As New RichEditOle(Me)
        ole.InsertControl(control)
    End Sub

    Public Sub InsertMyDataObject(ByVal dobj As DataObject)
        Dim ole As New RichEditOle(Me)
        ole.InsertMyDataObject(dobj)
    End Sub

    Public Sub UpdateObjects()
        Dim ole As New RichEditOle(Me)
        ole.UpdateObjects()
    End Sub

    Public Sub InsertImage(ByVal image As Image)
        Dim dobj As New DataObject()

        dobj.SetImage(image)

        Me.InsertMyDataObject(dobj)
    End Sub

    Public Sub InsertImage(ByVal imageFile As String)
        Dim dobj As New DataObject()

        dobj.SetImage(imageFile)

        Me.InsertMyDataObject(dobj)
    End Sub

    Public Sub InsertImageFromFile(ByVal strFilename As String)
        Dim ole As New RichEditOle(Me)
        ole.InsertImageFromFile(strFilename)
    End Sub

    Public Sub InsertActiveX(ByVal strProgID As String)
        Dim t As Type = Type.GetTypeFromProgID(strProgID)
        If t Is Nothing Then
            Return
        End If

        Dim o As Object = System.Activator.CreateInstance(t)

        Dim b As Boolean = (TypeOf o Is IOleObject)

        If b Then
            Me.InsertOleObject(DirectCast(o, IOleObject))
        End If
    End Sub

    Public Function SelectedObject() As REOBJECT
        Dim ole As New RichEditOle(Me)
        Return ole.GetSelectedObject()
    End Function

#End Region

#Region "ADDITIONAL PROCESSORS"

    Protected Overrides Sub OnDragEnter(ByVal drgevent As DragEventArgs)
        'base.OnDragEnter(drgevent);

        If drgevent.Data.GetDataPresent(DataFormats.Bitmap) Then
            drgevent.Effect = DragDropEffects.Copy
        ElseIf drgevent.Data.GetDataPresent(DataFormats.FileDrop) Then
            drgevent.Effect = DragDropEffects.Move
            Dim a As Array = DirectCast(drgevent.Data.GetData(DataFormats.FileDrop), Array)
            dropPath = a.GetValue(0).ToString()
        End If
    End Sub
    Protected Overrides Sub OnDragOver(ByVal drgevent As DragEventArgs)
        'base.OnDragOver(drgevent);

        If drgevent.Data.GetDataPresent(DataFormats.Bitmap) Then
            drgevent.Effect = DragDropEffects.Copy
        ElseIf drgevent.Data.GetDataPresent(DataFormats.FileDrop) Then
            drgevent.Effect = DragDropEffects.Move
        End If
    End Sub
    Private Function IsImageExtention(ByVal ext As String) As Boolean
        Try
            If ext = ".png" OrElse ext = ".bmp" OrElse ext = ".jpg" OrElse ext = ".jpeg" OrElse ext = ".gif" OrElse ext = ".tif" OrElse ext = ".tiff" OrElse ext = ".wmf" OrElse ext = ".emf" Then
                Return True
            End If

            Return False
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function
    Protected Overrides Sub OnDragDrop(ByVal drgevent As DragEventArgs)
        If drgevent.Data.GetDataPresent(DataFormats.Bitmap) Then
            drgevent.Effect = DragDropEffects.Copy
            DoDragDrop(drgevent.Data.GetData(DataFormats.Bitmap), DragDropEffects.Copy)
        ElseIf drgevent.Data.GetDataPresent(DataFormats.FileDrop) Then
            Try
                If dropPath.Length = 0 Then
                    Return
                End If

                If System.IO.File.Exists(dropPath) Then
                    Dim fi As New System.IO.FileInfo(dropPath)
                    If fi.Extension.ToLower() = ".rtf" Then
                        Me.LoadFile(dropPath)
                        drgevent.Data.SetData(Nothing)
                        drgevent = Nothing
                        Return
                    ElseIf IsImageExtention(fi.Extension.ToLower()) Then
                        Me.InsertImage(dropPath)
                        drgevent.Data.SetData(Nothing)
                        drgevent = Nothing
                        Return
                    End If
                End If
            Catch generatedExceptionName As Exception
            End Try
        End If
        dropPath = ""
        'base.OnDragDrop(drgevent);
    End Sub
    Protected Overrides Sub OnDragLeave(ByVal e As EventArgs)
        MyBase.OnDragLeave(e)
        dropPath = ""
    End Sub

#End Region
End Class