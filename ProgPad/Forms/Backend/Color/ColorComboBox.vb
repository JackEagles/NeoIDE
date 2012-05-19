Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<System.Drawing.ToolboxBitmapAttribute(GetType(ComboBox))> _
Public Class gColorComboBox
    Inherits ComboBox

#Region "Events"

    Public Event HoverSelect(ByVal sender As Object, ByVal ColorText As String, ByVal ColorValue As Color)


    Private Sub gColorComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChangeCommitted
        _selectedColor = Color.FromName(Text)
    End Sub

#End Region

#Region "Initialize"

    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        '     InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DrawMode = DrawMode.OwnerDrawFixed
        MaxDropDownItems = 20
        DropDownWidth = 150
        AutoSize = False
        Width = 150
      DropDownHeight = 250
        Items.Clear()
        AddHandler ComboBox.DrawItem, New DrawItemEventHandler(AddressOf List_DrawItem)

    End Sub

    ' •——————————————————————————————————————————————————————————————————•
    ' |   Do to the DesignMode property not working in a New Sub         |
    ' |   the loading of the list of colors is in this "fake" property   |
    ' |   to stop multiple loading of the list                           |
    ' •——————————————————————————————————————————————————————————————————•
    Private _initializeColor As Boolean
    <Browsable(False)> _
    Public Property InitializeColor() As Boolean
        Get
            Return _initializeColor
        End Get
        Set(ByVal Value As Boolean)
            _initializeColor = Value
            If Not DesignMode Then
                Items.Clear()
                Dim cList As New List(Of Color)
                For Each s As String In [Enum].GetNames(GetType(KnownColor))
                    If Not Color.FromName(s).IsSystemColor Then
                        cList.Add(Color.FromName(s))
                    End If
                Next
                cList.Sort(AddressOf SortColors)
                For Each c As Color In cList
                    Items.Add(c.Name)
                Next
            End If
        End Set
    End Property

    Private Function SortColors(ByVal x As Color, ByVal y As Color) As Integer
        'To use it first add all non-system colors to a List(Of Color), 
        'sort it by calling colors.Sort(AddressOf SortColors), 
        'then add all the list colors to the combo Items. 
        Dim huecompare As Integer = x.GetHue.CompareTo(y.GetHue)
        Dim satcompare As Integer = x.GetSaturation.CompareTo(y.GetSaturation)
        Dim brightcompare As Integer = x.GetBrightness.CompareTo(y.GetBrightness)
        If huecompare <> 0 Then
            Return huecompare
        ElseIf satcompare <> 0 Then
            Return satcompare
        ElseIf brightcompare <> 0 Then
            Return brightcompare
        Else
            Return 0
        End If
    End Function

#End Region

#Region "Properties"

    Private _selectedColor As Color = Color.Black
    ''' <summary>
    ''' Get or Set the currently selected Color
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Get or Set the currently selected Color")> _
    <DefaultValue(GetType(Color), "Black")> _
    <Category("Appearance gColorComboBox")> _
    Public Property SelectedColor() As Color
        Get
            Return _selectedColor
        End Get
        Set(ByVal Value As Color)
            _selectedColor = Color.FromName(GetNearestName(Value))
            Text = _selectedColor.Name
            If Not DesignMode Then
                Invalidate()
            End If
        End Set
    End Property

    Enum eHighlightStyle
        Standard
        Custom
    End Enum

    Private _highlightStyle As eHighlightStyle = eHighlightStyle.Custom
    ''' <summary>
    ''' Get or set to use standard or custom highlighting
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("Appearance gColorComboBox")> _
    <Description("Get or set to use standard or custom highlighting")> _
    <DefaultValue(GetType(eHighlightStyle), "Custom")> _
    Public Property HighlightStyle() As eHighlightStyle
        Get
            Return _highlightStyle
        End Get
        Set(ByVal Value As eHighlightStyle)
            _highlightStyle = Value
        End Set
    End Property

    Private _highlight As Color = Color.Blue
    ''' <summary>
    ''' Get or set color of the highlight bar
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("Appearance gColorComboBox")> _
    <Description("Get or set color of the highlight bar")> _
    <DefaultValue(GetType(Color), "Blue")> _
    Public Property Highlight() As Color
        Get
            Return _highlight
        End Get
        Set(ByVal Value As Color)
            _highlight = Value
        End Set
    End Property

    Private _shadow As Color = Color.AliceBlue
    ''' <summary>
    ''' Get or set color of the text shadow
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("Appearance gColorComboBox")> _
    <Description("Get or set color of the text shadow")> _
    <DefaultValue(GetType(Color), "AliceBlue")> _
    Public Property Shadow() As Color
        Get
            Return _shadow
        End Get
        Set(ByVal Value As Color)
            _shadow = Value
        End Set
    End Property

    Private _sampleWidth As Integer = 20
    ''' <summary>
    ''' Get or set Width of the Sample Rectangle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("Appearance gColorComboBox")> _
    <Description("Get or set Width of the Sample Rectangle")> _
    <DefaultValue(20)> _
    Public Property SampleWidth() As Integer
        Get
            Return _sampleWidth
        End Get
        Set(ByVal Value As Integer)
            _sampleWidth = Value
            If Not DesignMode Then Invalidate()
        End Set
    End Property

    <EditorBrowsableAttribute(EditorBrowsableState.Never)> _
    Public Shadows Property SelectedText() As String
        Get
            Return String.Empty
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    <EditorBrowsableAttribute(EditorBrowsableState.Never)> _
    Public Shadows Property SelectedValue() As Object
        Get
            Return Nothing
        End Get
        Set(ByVal value As Object)
        End Set
    End Property
#End Region

#Region "Draw Item"
    ' Handle the DrawItem event for an owner-drawn List.
    Private Sub List_DrawItem(ByVal sender As Object, _
        ByVal e As DrawItemEventArgs)

        If e.Index = -1 Then Exit Sub

        Dim CBox As ComboBox = CType(sender, ComboBox)
        Dim itemString As String = CType(CBox.Items(e.Index), String)

        Dim rectSelection As Rectangle = New Rectangle( _
            e.Bounds.X + 1, _
            e.Bounds.Y, _
            e.Bounds.Width - 3, _
            e.Bounds.Height - 1)
        Dim rectText As New Rectangle( _
            _sampleWidth + 6, _
            e.Bounds.Y, _
            e.Bounds.Width - _sampleWidth - 8, _
            e.Bounds.Height - 2)

        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)

        ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ' Draw the selection Highlight
            If _highlightStyle = eHighlightStyle.Custom Then
                rectSelection.Inflate(1, 1)
                Using lbr As LinearGradientBrush = New LinearGradientBrush( _
                    rectSelection, _
                    BackColor, _highlight, LinearGradientMode.Horizontal)
                    rectSelection.Inflate(-1, -1)
                    e.Graphics.FillRectangle(lbr, rectSelection)
                End Using
            Else
                e.Graphics.FillRectangle(Brushes.Beige, rectSelection)
                e.Graphics.DrawRectangle(Pens.Blue, rectSelection)
            End If

            RaiseEvent HoverSelect(Me, itemString, Color.FromName(itemString))

        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)
        End If

        'Draw a Color Swatch
        Using myBrush As New SolidBrush(Color.FromName(itemString))

            e.Graphics.FillRectangle(myBrush, e.Bounds.X + 3, e.Bounds.Y + 2, _sampleWidth, e.Bounds.Height - 4)
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 3, e.Bounds.Y + 2, _sampleWidth - 1, e.Bounds.Height - 5)
        End Using

        ' Draw the text in the item.
        rectText.Offset(1, 1)
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected _
          And Not (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            TextRenderer.DrawText(e.Graphics, itemString, Font, rectText, _shadow, TextFormatFlags.VerticalCenter)
        End If
        rectText.Offset(-1, -1)
        TextRenderer.DrawText(e.Graphics, itemString, Font, rectText, ForeColor, TextFormatFlags.VerticalCenter)

    End Sub
#End Region

End Class



