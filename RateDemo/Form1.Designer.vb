<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TXTproductID = New System.Windows.Forms.TextBox()
        Me.TXTproductName = New System.Windows.Forms.TextBox()
        Me.TXTprice = New System.Windows.Forms.TextBox()
        Me.TXTstar5 = New System.Windows.Forms.TextBox()
        Me.TXTstar4 = New System.Windows.Forms.TextBox()
        Me.TXTstar3 = New System.Windows.Forms.TextBox()
        Me.TXTstar2 = New System.Windows.Forms.TextBox()
        Me.TXTstar1 = New System.Windows.Forms.TextBox()
        Me.TXTinput = New System.Windows.Forms.TextBox()
        Me.BTpart = New System.Windows.Forms.Button()
        Me.BTfull = New System.Windows.Forms.Button()
        Me.BTreset = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MydbDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BTcomment = New System.Windows.Forms.Button()
        Me.MydbDataSet = New WindowsApplication2.mydbDataSet()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Lbltotalnumber = New System.Windows.Forms.Label()
        Me.TXTcatagory = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTlocation = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtHome = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Product Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Price (RM):"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(492, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(274, 164)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "5 star:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(133, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "4 star:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(198, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "3 star:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(263, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "2 star:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(328, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "1 star:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(544, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 29)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Rate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TXTproductID
        '
        Me.TXTproductID.Enabled = False
        Me.TXTproductID.Location = New System.Drawing.Point(139, 21)
        Me.TXTproductID.Name = "TXTproductID"
        Me.TXTproductID.Size = New System.Drawing.Size(105, 22)
        Me.TXTproductID.TabIndex = 11
        '
        'TXTproductName
        '
        Me.TXTproductName.Enabled = False
        Me.TXTproductName.Location = New System.Drawing.Point(138, 106)
        Me.TXTproductName.Name = "TXTproductName"
        Me.TXTproductName.Size = New System.Drawing.Size(335, 22)
        Me.TXTproductName.TabIndex = 12
        '
        'TXTprice
        '
        Me.TXTprice.Enabled = False
        Me.TXTprice.Location = New System.Drawing.Point(137, 145)
        Me.TXTprice.Name = "TXTprice"
        Me.TXTprice.Size = New System.Drawing.Size(106, 22)
        Me.TXTprice.TabIndex = 13
        '
        'TXTstar5
        '
        Me.TXTstar5.Enabled = False
        Me.TXTstar5.Location = New System.Drawing.Point(101, 197)
        Me.TXTstar5.Name = "TXTstar5"
        Me.TXTstar5.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar5.TabIndex = 14
        '
        'TXTstar4
        '
        Me.TXTstar4.Enabled = False
        Me.TXTstar4.Location = New System.Drawing.Point(166, 197)
        Me.TXTstar4.Name = "TXTstar4"
        Me.TXTstar4.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar4.TabIndex = 15
        '
        'TXTstar3
        '
        Me.TXTstar3.Enabled = False
        Me.TXTstar3.Location = New System.Drawing.Point(231, 197)
        Me.TXTstar3.Name = "TXTstar3"
        Me.TXTstar3.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar3.TabIndex = 16
        '
        'TXTstar2
        '
        Me.TXTstar2.Enabled = False
        Me.TXTstar2.Location = New System.Drawing.Point(296, 197)
        Me.TXTstar2.Name = "TXTstar2"
        Me.TXTstar2.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar2.TabIndex = 17
        '
        'TXTstar1
        '
        Me.TXTstar1.Enabled = False
        Me.TXTstar1.Location = New System.Drawing.Point(361, 197)
        Me.TXTstar1.Name = "TXTstar1"
        Me.TXTstar1.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar1.TabIndex = 18
        '
        'TXTinput
        '
        Me.TXTinput.Location = New System.Drawing.Point(56, 433)
        Me.TXTinput.Name = "TXTinput"
        Me.TXTinput.Size = New System.Drawing.Size(418, 22)
        Me.TXTinput.TabIndex = 19
        '
        'BTpart
        '
        Me.BTpart.Location = New System.Drawing.Point(544, 414)
        Me.BTpart.Name = "BTpart"
        Me.BTpart.Size = New System.Drawing.Size(176, 29)
        Me.BTpart.TabIndex = 20
        Me.BTpart.Text = "Search by Part"
        Me.BTpart.UseVisualStyleBackColor = True
        '
        'BTfull
        '
        Me.BTfull.Location = New System.Drawing.Point(544, 446)
        Me.BTfull.Name = "BTfull"
        Me.BTfull.Size = New System.Drawing.Size(176, 29)
        Me.BTfull.TabIndex = 21
        Me.BTfull.Text = "Search by Full Name"
        Me.BTfull.UseVisualStyleBackColor = True
        '
        'BTreset
        '
        Me.BTreset.Location = New System.Drawing.Point(480, 432)
        Me.BTreset.Name = "BTreset"
        Me.BTreset.Size = New System.Drawing.Size(58, 24)
        Me.BTreset.TabIndex = 22
        Me.BTreset.Text = "Reset"
        Me.BTreset.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(56, 246)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(418, 162)
        Me.DataGridView1.TabIndex = 23
        '
        'BTcomment
        '
        Me.BTcomment.Location = New System.Drawing.Point(364, 145)
        Me.BTcomment.Name = "BTcomment"
        Me.BTcomment.Size = New System.Drawing.Size(110, 26)
        Me.BTcomment.TabIndex = 24
        Me.BTcomment.Text = "Display Comment"
        Me.BTcomment.UseVisualStyleBackColor = True
        '
        'MydbDataSet
        '
        Me.MydbDataSet.DataSetName = "mydbDataSet"
        Me.MydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(56, 467)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(417, 20)
        Me.ComboBox1.TabIndex = 25
        '
        'Lbltotalnumber
        '
        Me.Lbltotalnumber.AutoSize = True
        Me.Lbltotalnumber.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltotalnumber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lbltotalnumber.Location = New System.Drawing.Point(411, 194)
        Me.Lbltotalnumber.Name = "Lbltotalnumber"
        Me.Lbltotalnumber.Size = New System.Drawing.Size(62, 25)
        Me.Lbltotalnumber.TabIndex = 26
        Me.Lbltotalnumber.Text = "00000"
        '
        'TXTcatagory
        '
        Me.TXTcatagory.Enabled = False
        Me.TXTcatagory.Location = New System.Drawing.Point(138, 60)
        Me.TXTcatagory.Name = "TXTcatagory"
        Me.TXTcatagory.Size = New System.Drawing.Size(105, 22)
        Me.TXTcatagory.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(84, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 12)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Category :"
        '
        'TXTlocation
        '
        Me.TXTlocation.Enabled = False
        Me.TXTlocation.Location = New System.Drawing.Point(357, 60)
        Me.TXTlocation.Name = "TXTlocation"
        Me.TXTlocation.Size = New System.Drawing.Size(116, 22)
        Me.TXTlocation.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(303, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 12)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Location :"
        '
        'BtHome
        '
        Me.BtHome.Location = New System.Drawing.Point(12, 13)
        Me.BtHome.Name = "BtHome"
        Me.BtHome.Size = New System.Drawing.Size(54, 28)
        Me.BtHome.TabIndex = 31
        Me.BtHome.Text = "Home"
        Me.BtHome.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(296, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "User Name:"
        '
        'TxtName
        '
        Me.TxtName.Enabled = False
        Me.TxtName.Location = New System.Drawing.Point(357, 21)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(116, 22)
        Me.TxtName.TabIndex = 33
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(480, 249)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(285, 158)
        Me.Chart1.TabIndex = 37
        Me.Chart1.Text = "Chart1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 505)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtHome)
        Me.Controls.Add(Me.TXTlocation)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTcatagory)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Lbltotalnumber)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BTcomment)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BTreset)
        Me.Controls.Add(Me.BTfull)
        Me.Controls.Add(Me.BTpart)
        Me.Controls.Add(Me.TXTinput)
        Me.Controls.Add(Me.TXTstar1)
        Me.Controls.Add(Me.TXTstar2)
        Me.Controls.Add(Me.TXTstar3)
        Me.Controls.Add(Me.TXTstar4)
        Me.Controls.Add(Me.TXTstar5)
        Me.Controls.Add(Me.TXTprice)
        Me.Controls.Add(Me.TXTproductName)
        Me.Controls.Add(Me.TXTproductID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "User Name:"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TXTproductID As TextBox
    Friend WithEvents TXTproductName As TextBox
    Friend WithEvents TXTprice As TextBox
    Friend WithEvents TXTstar5 As TextBox
    Friend WithEvents TXTstar4 As TextBox
    Friend WithEvents TXTstar3 As TextBox
    Friend WithEvents TXTstar2 As TextBox
    Friend WithEvents TXTstar1 As TextBox
    Friend WithEvents TXTinput As TextBox
    Friend WithEvents BTpart As Button
    Friend WithEvents BTfull As Button
    Friend WithEvents BTreset As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MydbDataSetBindingSource As BindingSource
    Friend WithEvents BTcomment As Button
    Friend WithEvents MydbDataSet As mydbDataSet
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Lbltotalnumber As Label
    Friend WithEvents TXTcatagory As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTlocation As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents BtHome As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
