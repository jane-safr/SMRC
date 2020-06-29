Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

''' -----------------------------------------------------------------------------
''' Project	 : MultiColumnCombo
''' Class	 : Controls.MultiColumnComboBox
''' -----------------------------------------------------------------------------
''' <summary>
''' MultiColumnCombo is a subclass of the windows forms Combobox control.  This control adds the option of images in the drop down list,
''' allows multiple columns to be in the list, allows a header to describe the columns in the list, and allows for databinding to the columns.
''' </summary>
''' <remarks>
''' For updated versions of if you have any bug fixes go to http://www.edneeis.com.  Also special thanks to Loren Lowe (lorenmlowe@yahoo.com)
''' for providing code and concept for the AutoSize feature of the columns.
''' </remarks>
''' <history>
''' 	[ed]	6/11/2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class MultiColumnComboBox
    Inherits ComboBox

    Public Event ColumnCountChanged As MultiColumnComboBox.CountChangedEventHandler

    'internal members for added properties
    Private _imageList As ImageList
    Private _imageIndexMember As String = String.Empty
    Private WithEvents _columns As New ColumnCollection
    Private _showColumns As Boolean = False
    Private _showColumnHeaders As Boolean = False
    Private _columnHeaderBorderStyle As Border3DStyle = Border3DStyle.Flat
    Private _showImageInText As Boolean = False
    Private _SelectionForeColor As Color = SystemColors.HighlightText
    Private _SelectionBackColor As Color = SystemColors.Highlight

    Private Const ScrollBarWidth As Integer = 36
    Private Const MinItemsForScrollBar As Integer = 4

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Internal flag which causes the autosizing of columns to be performed, similiar to an IsDirty flag for resizing.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ed]	6/11/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private _performResize As Boolean = True

    Protected Property PerformResize() As Boolean
        Get
            Return _performResize
        End Get
        Set(ByVal Value As Boolean)
            _performResize = Value
        End Set
    End Property

    <Description("Determines whether or not to show the image in the textbox when in DropDownList mode.")> _
    Public Property ShowImageInText() As Boolean
        Get
            Return _showImageInText
        End Get
        Set(ByVal value As Boolean)
            _showImageInText = value
        End Set
    End Property

    <Description("The image list to get images from for the list items.")> _
    Public Property ImageList() As ImageList
        Get
            Return _imageList
        End Get
        Set(ByVal value As ImageList)
            _imageList = value
        End Set
    End Property

    <Description("Indicates the property to use the index for the ImageList when getting item images.")> _
    Public Property ImageIndexMember() As String
        Get
            Return _imageIndexMember
        End Get
        Set(ByVal value As String)
            _imageIndexMember = value
        End Set
    End Property

    <Description("The column information for the list."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property Columns() As ColumnCollection
        Get
            Return _columns
        End Get
    End Property

    'if false then defaults to normal or image combo regardless of columns collection
    <Description("Determines whether or not to show the columns from the columns collection.")> _
    Public Property ShowColumns() As Boolean
        Get
            Return _showColumns
        End Get
        Set(ByVal value As Boolean)
            _showColumns = value
        End Set
    End Property

    <Description("Determines whether or not to show the column header.")> _
    Public Property ShowColumnHeader() As Boolean
        Get
            Return _showColumnHeaders
        End Get
        Set(ByVal value As Boolean)
            _showColumnHeaders = value
            Me.IntegralHeight = Not _showColumnHeaders
            If _showColumnHeaders Then
                Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable
            Else
                Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            End If
        End Set
    End Property

    <Description("Gets or sets the border style for column header.")> _
    Public Property ColumnHeaderBorderStyle() As Border3DStyle
        Get
            Return _columnHeaderBorderStyle
        End Get
        Set(ByVal value As Border3DStyle)
            _columnHeaderBorderStyle = value
        End Set
    End Property

    <Description("Sets or Gets the color of the selected item's text.")> _
    Public Property SelectionForeColor() As Color
        Get
            Return _SelectionForeColor
        End Get
        Set(ByVal Value As Color)
            _SelectionForeColor = Value
        End Set
    End Property

    <Description("Sets or Gets the color of the selected item's background.")> _
    Public Property SelectionBackColor() As Color
        Get
            Return _SelectionBackColor
        End Get
        Set(ByVal Value As Color)
            _SelectionBackColor = Value
        End Set
    End Property

    Protected Overrides Sub OnDrawItem(ByVal ea As DrawItemEventArgs)
        'this replaces the normal drawing of the dropdown list
        ea.DrawBackground()
        ea.DrawFocusRectangle()

        Dim iwidth As Integer = 0

        'test to see if height is inflated if so then this has a header
        Dim IsDrawingHeader As Boolean = (ea.Bounds.Height > Me.ItemHeight)
        Dim useTop As Integer = ea.Bounds.Y

        If IsDrawingHeader AndAlso _showColumnHeaders Then useTop = ea.Bounds.Top + Me.FontHeight

        'handle image
        Try
            Dim imageindex As Integer = -1
            'test for imagelist to avoid delay caused by exception handler
            If Not ImageList Is Nothing Then
                Dim imageSize As Size = ImageList.ImageSize
                'get imageindexmember value
                'Dim iInfo As Reflection.PropertyInfo = Items(ea.Index).GetType.GetProperty(Me.ImageIndexMember)
                'If Not iInfo Is Nothing Then
                'optionally show image in textbox when in dropdownlist mode
                Dim IsInEdit As Boolean = (ea.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit
                If (IsInEdit AndAlso _showImageInText) Or Not IsInEdit Then
                    'draw image
                    imageindex = CType(ReflectValue(Items(ea.Index), Me.ImageIndexMember), Integer)
                    'ImageList.Draw(ea.Graphics, ea.Bounds.Left, ea.Bounds.Top, imageindex)
                    ImageList.Draw(ea.Graphics, ea.Bounds.Left, useTop, imageindex)
                    iwidth = imageSize.Width
                End If
                'End If
            End If
        Catch exi As Exception
            'image drawing skipped
            Throw exi
        End Try

        'handle regular drawing
        Try
            If ea.Index <> -1 Then
                'handle columns
                'dropdownlist fix provided by David Gauerke (dlg@com-systems.com)
                'do not draw columns for textbox if in dropdownlist mode
                If _showColumns AndAlso (ea.State And DrawItemState.ComboBoxEdit) <> DrawItemState.ComboBoxEdit Then
                    Dim col As Column
                    Dim cnt As Integer
                    For Each col In Me.Columns
                        cnt += 1

                        Static prevWidth As Integer
                        If cnt = 1 Then prevWidth = ea.Bounds.X
                        Dim useX As Integer = ea.Bounds.X + col.Width
                        Dim useY As Integer = ea.Bounds.Y + ea.Bounds.Height
                        'Dim useTop As Integer = ea.Bounds.Y

                        ''test to see if height is inflated if so then this has a header
                        'Dim IsDrawingHeader As Boolean = (ea.Bounds.Height > Me.ItemHeight)

                        If IsDrawingHeader AndAlso _showColumnHeaders Then
                            'adjust top for drawing of other item parts
                            'useTop = ea.Bounds.Top + Me.FontHeight
                            Dim tmpX As Integer = useX
                            If cnt = Me.Columns.Count Then
                                'last column make sure it fills entire width
                                If iwidth = 0 Then tmpX = ea.Bounds.Width - useX
                            End If
                            Dim tmpLeft As Integer = ea.Bounds.X + prevWidth
                            'adjust headers if image is drawn
                            If cnt > 1 Then
                                tmpLeft += iwidth
                                'of this is the last column then extend it to the end regardless of set width
                                'Thanks to Trinh Ngoc Trac (trinhngoctrac@yahoo.com) for the catch and fix
                                If cnt = Me.Columns.Count Then
                                    tmpX = ea.Bounds.Width
                                End If
                            Else
                                tmpX += iwidth
                            End If
                            Dim recth As New RectangleF(tmpLeft, ea.Bounds.Top, tmpX, Me.FontHeight)
                            'Dim recth As New RectangleF((ea.Bounds.X + prevWidth) + iwidth, ea.Bounds.Top, tmpX, Me.FontHeight)
                            'draw column header background
                            ea.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), recth)
                            ControlPaint.DrawBorder3D(ea.Graphics, CType(recth.X, Integer), CType(recth.Y, Integer), CType(recth.Width, Integer), CType(recth.Height, Integer), _columnHeaderBorderStyle)

                            'use col.Header property or member as backup
                            Dim txtHeader As String = col.Header
                            If txtHeader.Length = 0 Then txtHeader = col.ColumnMember
                            'draw header text
                            ea.Graphics.DrawString(txtHeader, New Font(ea.Font, FontStyle.Bold), New SolidBrush(Color.Black), recth)
                        End If

                        'get the text from the bound object by property name in the columnmember
                        Dim display As String = Me.GetDisplayText(col.DisplayNullAs, Items(ea.Index), col.ColumnMember)
                        Dim bufferHt As Integer = 2
                        Dim rectf As New RectangleF((ea.Bounds.X + prevWidth) + iwidth, useTop, useX, Me.FontHeight + bufferHt)
                        If cnt = Me.Columns.Count Then
                            'ensure that the last columne is the full width
                            rectf.Width = ea.Bounds.Width
                        End If

                        'change drawing colors if the items is selected
                        'Thanks to Ivan Stipcevic (ivan.stipcevic@dcsl.com) for adding this feature
                        Dim isSelected As Boolean = ((ea.State And DrawItemState.Selected) = DrawItemState.Selected)
                        If isSelected Then
                            'selected so use selection colors
                            ea.Graphics.FillRectangle(New SolidBrush(Me.SelectionBackColor), rectf)
                            ea.Graphics.DrawString(display, ea.Font, New SolidBrush(Me.SelectionForeColor), rectf)

                        Else
                            'not selected so use column color
                            ea.Graphics.FillRectangle(New SolidBrush(col.Color), rectf)
                            ea.Graphics.DrawString(display, ea.Font, New SolidBrush(ea.ForeColor), rectf)

                        End If

                        If cnt > 1 Then
                            'draw the line for everyone but the first one
                            'other good colors for the line is silver and gray
                            Dim buffer As Integer = 0
                            If IsDrawingHeader AndAlso _showColumnHeaders Then
                                buffer = Me.FontHeight + 1
                                If (_columnHeaderBorderStyle And Border3DStyle.Adjust) <> Border3DStyle.Adjust Then buffer += 1
                            End If
                            'line length work around provided by David Gauerke (dlg@com-systems.com)
                            'extend past needed length to ensure proper drawing
                            ea.Graphics.DrawLine(System.Drawing.Pens.LightGray, prevWidth + iwidth, useTop + ea.Bounds.Top + buffer, prevWidth + iwidth, Me.FontHeight)
                        End If
                        'remember previous column width
                        prevWidth += col.Width
                    Next
                Else
                    'hide columns deafault to normal
                    'get the text from the bound object by property name in the columnmember
                    'Dim display As String = GetTextForItem(Items(ea.Index))
                    Dim display As String = Me.GetDisplayText("NULL", Items(ea.Index), Me.DisplayMember)
                    ea.Graphics.DrawString(display, ea.Font, New SolidBrush(ea.ForeColor), ea.Bounds.Left + iwidth, ea.Bounds.Top)
                End If
            Else
                    'draw default simplest form
                    ea.Graphics.DrawString(Me.Text, ea.Font, New SolidBrush(ea.ForeColor), Bounds.Left, Bounds.Top)
            End If
        Catch ex As Exception
            'draw default simplest form
            ea.Graphics.DrawString(Me.Text, ea.Font, New SolidBrush(ea.ForeColor), Bounds.Left, Bounds.Top)
        End Try

        MyBase.OnDrawItem(ea)
    End Sub

    Protected Overrides Sub OnMeasureItem(ByVal e As System.Windows.Forms.MeasureItemEventArgs)
        'if this is the first row then add height for the column headers
        If e.Index = 0 AndAlso _showColumnHeaders Then
            e.ItemHeight += Me.FontHeight
        End If
        MyBase.OnMeasureItem(e)
    End Sub

    Protected Overrides Sub OnDropDown(ByVal e As System.EventArgs)
        MyBase.OnDropDown(e)

        'adjust column width for DropDownWidth or AutoSize
        If Me.PerformResize Then AdjustDropDownWidth()
    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        MyBase.OnDataSourceChanged(e)

        'reset resize flag
        If Not Me.DataSource Is Nothing Then Me.PerformResize = True

    End Sub

    'this method provides a way for the developer to manually force
    'the autosize columns to refresh their width.
    Public Sub RefreshColumns()
        'reset resize flag
        Me.PerformResize = True
    End Sub

    'this method provides a way to refresh the data contains if they appear out of sync
    'this usually happens when the datasource is a simple object that does not implement IBindingList
    Public Sub RefreshDataBinding()
        'skip if there is currently no datasource
        If Me.DataSource Is Nothing Then Return

        'get old datasource
        Dim oldSource As Object = Me.DataSource
        Dim oldDisplay As String = Me.DisplayMember
        Dim oldValue As String = Me.ValueMember
        'clear current source
        Me.DataSource = Nothing
        'reset the datasource
        Me.DataSource = oldSource
        Me.DisplayMember = oldDisplay
        Me.ValueMember = oldValue

    End Sub

#Region " Internal Methods "

    Protected Sub AdjustDropDownWidth()
        'don't adjust if there is no datasource
        If Me.Items Is Nothing Then Return
        'get content items
        Dim list As IList
        If Not Me.Items.GetType.GetInterface("IListSource") Is Nothing Then
            list = CType(Me.Items, IListSource).GetList
        Else
            list = CType(Me.Items, IList)
        End If
        'adjust AutoSize columns width
        'this method call sets any autosize column width to the width
        'of the widest string in the content list
        AutosizeColumns(list)

        'aggregate column widths
        Dim maxWidth As Integer
        For Each col As MultiColumnComboBox.Column In _columns
            maxWidth += col.Width
        Next

        'check for scrollbars to add width to adjust for them
        'I didn't find an easy way to see if scrollbars were showing so
        'I simply assume here that more than 4 items means the scrollbars are shown
        If Me.Items.Count > MinItemsForScrollBar Then
            '36 is roughly the width of the scrollbar and if not
            'used the scrollbar will overlap some of the text
            maxWidth += ScrollBarWidth
        End If

        If maxWidth > 0 Then Me.DropDownWidth = maxWidth

        'reset resize flag
        Me.PerformResize = False

    End Sub

    Private Sub AutosizeColumns(ByVal list As IList)
        'loop through items in list
        For Each item As Object In list
            'loop through columns for this item
            For Each col As MultiColumnComboBox.Column In Me.Columns
                'adjust size for this column if needed
                'col.Resize(GetTextForItem(item, col), Me)
                col.Resize(ReflectValue(item, col.ColumnMember).ToString, Me)
            Next
        Next
    End Sub

    Private Function GetDisplayText(ByVal displayNullAs As String, ByVal item As Object, ByVal member As String) As String
        'for display purposes adjust the value for nulls
        Dim value As Object = ReflectValue(item, member)
        If IsDBNull(value) Then
            Return displayNullAs
        Else
            Return value.ToString()
        End If

    End Function

    Private Function ReflectValue(ByVal item As Object, ByVal member As String) As Object
        'get the text from the bound object by property name in the columnmember
        Try
            'handle getting the property differently if the datasource is a datarowview
            If TypeOf item Is DataRowView Then
                Dim d As DataRowView = CType(item, DataRowView)
                'check for column exisitance
                If d.DataView.Table.Columns.Contains(member) Then
                    Dim value As Object = d.Item(member)
                    If IsDBNull(value) Then
                        Return DBNull.Value
                    Else
                        Return CType(d.Item(member), String)
                    End If
                End If
            End If
            'to increase performance we can check for the existance of the property first instead
            'of relying on an exception being thrown
            Dim pInfo As Reflection.PropertyInfo = item.GetType.GetProperty(member)
            If pInfo Is Nothing Then
                Return item.ToString()
            Else
                Return CType(pInfo.GetValue(item, Nothing), String)
            End If
            'display = CType(Items(ea.Index).GetType.GetProperty(col.ColumnMember).GetValue(Items(ea.Index), Nothing), String)
        Catch ext As Exception
            Return item.ToString()
        End Try
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal flags As Integer) As Boolean
    End Function

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)

        'BUG FIX: Resizes the list height for small numbers of items with a header
        '8465 is a combo command
        If m.Msg = 8465 AndAlso Me.ShowColumnHeader Then

            '7 is the list dropping down but we are after the dropdown event and the base height setting
            If m.WParam.ToInt32 >> 16 = 7 AndAlso Me.Items.Count > 0 Then
                'a dropdown event has been sent and the dropdown height set now change it
                'since the dropDownHandle is private we will use reflection to access the value anyway
                Dim fi As Reflection.FieldInfo = GetType(ComboBox).GetField("dropDownHandle", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                Dim hWnd As IntPtr = CType(fi.GetValue(Me), IntPtr)
                'get the height of all items if less than the max items
                Dim count As Integer = Me.Items.Count
                If count > Me.MaxDropDownItems Then count = Me.MaxDropDownItems
                'now adjust the height adding room for the header
                Dim ht As Integer = (Me.ItemHeight * count) + Me.ItemHeight
                'use the API call to actually set the height of the list window
                SetWindowPos(hWnd, IntPtr.Zero, 0, 0, Me.DropDownWidth, ht, 6)

            End If
        End If

    End Sub


#End Region

    Public Sub New()
        'set to ownerdraw
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
    End Sub

    Public Sub New(ByRef cbo As ComboBox)
        'assign all properties from cbo to me
        'Dim pi As Reflection.PropertyInfo
        'For Each pi In cbo.GetType.GetProperties
        '    Dim s As String = pi.Attributes.ToString
        '    If pi.CanWrite Then
        '        'On Error Resume Next 'just in case
        '        Me.GetType.GetProperty(pi.Name).SetValue(Me, pi.GetValue(cbo, Nothing), Nothing)
        '    End If
        'Next
        'TODO: have it consume ALL properties of original combo
        Me.Anchor = cbo.Anchor
        Me.BackColor = cbo.BackColor
        Me.BackgroundImage = cbo.BackgroundImage
        Me.CausesValidation = cbo.CausesValidation
        Me.ContextMenu = cbo.ContextMenu
        Me.DataSource = cbo.DataSource
        Me.DisplayMember = cbo.DisplayMember
        Me.Dock = cbo.Dock
        Me.DropDownStyle = cbo.DropDownStyle
        Me.DropDownWidth = cbo.DropDownWidth
        Me.Enabled = cbo.Enabled
        Me.Font = cbo.Font
        Me.ForeColor = cbo.ForeColor
        Me.IntegralHeight = cbo.IntegralHeight
        Dim item As Object
        For Each item In cbo.Items
            Me.Items.Add(item)
        Next
        'If cbo.Items.Count > 0 Then
        '    Dim tmp(cbo.Items.Count) As Object
        '    cbo.Items.CopyTo(tmp, 0)
        '    Me.Items.AddRange(tmp)
        'End If
        Me.MaxDropDownItems = cbo.MaxDropDownItems
        Me.MaxLength = cbo.MaxLength
        Me.Sorted = cbo.Sorted
        Me.Text = cbo.Text
        Me.TabStop = cbo.TabStop
        Me.ValueMember = cbo.ValueMember
        Me.Visible = cbo.Visible
        Me.Location = cbo.Location
        Me.Size = cbo.Size
        Me.TabIndex = cbo.TabIndex
        'set to ownerdraw
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        'switch combos
        Dim parent As Control = cbo.Parent
        parent.Controls.Remove(cbo)
        parent.Controls.Add(Me)
    End Sub

#Region " Column class and collection "

    ''' -----------------------------------------------------------------------------
    ''' Project	 : MultiColumnCombo
    ''' Class	 : Controls.MultiColumnComboBox.Column
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Column object used to setup columns within the MultiColumnComboBox.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ed]	6/11/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ''' 
    <Serializable()> _
    Public Class Column

        Private Const DefaultDisplayNullAs As String = "NULL"

        Private _Width As Integer
        Private _ColumnMember As String
        Private _Header As String
        Private _AutoSize As Boolean = False
        Private _Color As Color = SystemColors.Window
        Private _DisplayNullAs As String = DefaultDisplayNullAs

        'width of the column
        'if it exceed the width of the dropdownwidth then it will not be shown
        Public Property Width() As Integer
            Get
                Return _Width
            End Get
            Set(ByVal Value As Integer)
                _Width = Value
            End Set
        End Property

        'bound field or property that you want to display in this column
        Public Property ColumnMember() As String
            Get
                Return _ColumnMember
            End Get
            Set(ByVal Value As String)
                _ColumnMember = Value
            End Set
        End Property

        'header title
        Public Property Header() As String
            Get
                Return _Header
            End Get
            Set(ByVal Value As String)
                _Header = Value
            End Set
        End Property

        'set to try to automatically resize the column by the length of the longest text
        Public Property AutoSize() As Boolean
            Get
                Return _AutoSize
            End Get
            Set(ByVal Value As Boolean)
                _AutoSize = Value
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return _Color
            End Get
            Set(ByVal Value As Color)
                _Color = Value
            End Set
        End Property

        'text to display if the value is NULL
        Public Property DisplayNullAs() As String
            Get
                Return _DisplayNullAs
            End Get
            Set(ByVal Value As String)
                _DisplayNullAs = Value
            End Set
        End Property

        Public Sub New()
            MyBase.new()
        End Sub

        Public Sub New(ByVal columnMember As String)
            Me.New(columnMember, String.Empty)
        End Sub

        Public Sub New(ByVal columnMember As String, ByVal header As String)
            'notice that if no width is specified then it defaults to autosize
            MyBase.new()
            Me.ColumnMember = columnMember
            Me.Header = header
            Me.AutoSize = True
        End Sub

        Public Sub New(ByVal columnMember As String, ByVal width As Integer)
            Me.New(columnMember, columnMember, width)
        End Sub

        Public Sub New(ByVal columnMember As String, ByVal header As String, ByVal width As Integer)
            MyBase.new()
            Me.Width = width
            Me.ColumnMember = columnMember
            Me.Header = header
        End Sub

        Public Overridable Sub Resize(ByVal text As String, ByVal control As MultiColumnComboBox)
            If _AutoSize Then
                'get buffer to account for the line or extra space
                Dim linebuffer As Integer = 5
                'get width of content
                Dim g As Graphics = Graphics.FromHwnd(control.Handle)
                Dim sz As Drawing.SizeF = g.MeasureString(text, control.Font)
                'if content is wider than current width increase it
                Dim itemWidth As Integer = CType(sz.Width + linebuffer, Integer)
                If itemWidth > _Width Then _Width = itemWidth

                If control.ShowColumnHeader Then
                    'check if header is wider then current width
                    'if it is then adjust the width to fit the header
                    'but adjust the linebuffer to account for the header borders
                    linebuffer = 10
                    sz = g.MeasureString(Header, control.Font)
                    'if content is wider than current width increase it
                    itemWidth = CType(sz.Width + linebuffer, Integer)
                    If itemWidth > _Width Then _Width = itemWidth
                End If

            End If
        End Sub

    End Class

    ''' -----------------------------------------------------------------------------
    ''' Project	 : MultiColumnCombo
    ''' Class	 : Controls.MultiColumnComboBox.ColumnCollection
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Strongly Typed Collection object for columns within the MultiColumnComboBox.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ed]	6/11/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ''' 
    <Serializable()> _
    Public Class ColumnCollection
        Inherits CollectionBase

        Public Event CountChanged As CountChangedEventHandler

        'item
        Default Public Property Item(ByVal index As Integer) As Column
            Get
                Return CType(MyBase.List(index), Column)
            End Get
            Set(ByVal Value As Column)
                MyBase.List(index) = Value
            End Set
        End Property

        'add
        Public Function Add(ByVal item As Column) As Integer
            Return MyBase.List.Add(item)
        End Function

        'remove
        Public Sub Remove(ByVal item As Column)
            MyBase.List.Remove(item)
        End Sub

        'insert
        Public Sub Insert(ByVal index As Integer, ByVal item As Column)
            MyBase.List.Insert(index, item)
        End Sub

        'contains
        Public Function Contains(ByVal item As Column) As Boolean
            If MyBase.List.IndexOf(item) > -1 Then Return True
        End Function

        'indexof
        Public Function IndexOf(ByVal item As Column) As Integer
            Return MyBase.List.IndexOf(item)
        End Function

        Protected Overrides Sub OnClearComplete()
            MyBase.OnClearComplete()

            RaiseEvent CountChanged(Me, New MultiColumnComboBox.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Cleared))
        End Sub

        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnInsertComplete(index, value)

            RaiseEvent CountChanged(Me, New MultiColumnComboBox.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Increased, value))
        End Sub

        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            MyBase.OnRemoveComplete(index, value)

            RaiseEvent CountChanged(Me, New MultiColumnComboBox.CountChangedEventArgs(CountChangedEventArgs.ChangeTypes.Decreased, value))
        End Sub

    End Class

#End Region

#Region " ColumnCountChanged Event Support "

    'event delegate for CountChanged event
    Public Delegate Sub CountChangedEventHandler(ByVal sender As Object, ByVal e As CountChangedEventArgs)

    ''' -----------------------------------------------------------------------------
    ''' Project	 : MultiColumnCombo
    ''' Class	 : Controls.MultiColumnComboBox.CountChangedEventArgs
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Event arguments for the CountChanged Event of the ColumnCollection object.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ed]	6/11/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class CountChangedEventArgs
        Inherits EventArgs

        Public Enum ChangeTypes
            [Increased]
            [Decreased]
            [Cleared]
        End Enum

        Private _ChangeType As ChangeTypes
        Private _Item As Object

        Public Property ChangeType() As ChangeTypes
            Get
                Return _ChangeType
            End Get
            Set(ByVal Value As ChangeTypes)
                _ChangeType = Value
            End Set
        End Property

        Public Property Item() As Object
            Get
                Return _Item
            End Get
            Set(ByVal Value As Object)
                _Item = Value
            End Set
        End Property

        Public Sub New(ByVal changetype As ChangeTypes)
            Me.New(changetype, Nothing)
        End Sub

        Public Sub New(ByVal changetype As ChangeTypes, ByVal item As Object)
            MyBase.new()
            _ChangeType = changetype
            _Item = item
        End Sub

    End Class

    'bubble up the countchanged event for the columns collection
    Private Sub _columns_CountChanged(ByVal sender As Object, ByVal e As CountChangedEventArgs) Handles _columns.CountChanged
        OnColumnCountChanged(e)
    End Sub

    Protected Sub OnColumnCountChanged(ByVal e As CountChangedEventArgs)
        RaiseEvent ColumnCountChanged(Me, e)
    End Sub

#End Region

End Class
