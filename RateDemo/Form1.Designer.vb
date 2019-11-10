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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Product Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Price (RM):"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(492, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 135)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "5 star:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(138, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "4 star:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "3 star:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(264, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "2 star:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(331, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "1 star:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(544, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 21)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Rate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TXTproductID
        '
        Me.TXTproductID.Enabled = False
        Me.TXTproductID.Location = New System.Drawing.Point(155, 15)
        Me.TXTproductID.Name = "TXTproductID"
        Me.TXTproductID.Size = New System.Drawing.Size(105, 22)
        Me.TXTproductID.TabIndex = 11
        '
        'TXTproductName
        '
        Me.TXTproductName.Enabled = False
        Me.TXTproductName.Location = New System.Drawing.Point(154, 49)
        Me.TXTproductName.Name = "TXTproductName"
        Me.TXTproductName.Size = New System.Drawing.Size(320, 22)
        Me.TXTproductName.TabIndex = 12
        '
        'TXTprice
        '
        Me.TXTprice.Enabled = False
        Me.TXTprice.Location = New System.Drawing.Point(153, 88)
        Me.TXTprice.Name = "TXTprice"
        Me.TXTprice.Size = New System.Drawing.Size(106, 22)
        Me.TXTprice.TabIndex = 13
        '
        'TXTstar5
        '
        Me.TXTstar5.Enabled = False
        Me.TXTstar5.Location = New System.Drawing.Point(101, 126)
        Me.TXTstar5.Name = "TXTstar5"
        Me.TXTstar5.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar5.TabIndex = 14
        '
        'TXTstar4
        '
        Me.TXTstar4.Enabled = False
        Me.TXTstar4.Location = New System.Drawing.Point(171, 126)
        Me.TXTstar4.Name = "TXTstar4"
        Me.TXTstar4.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar4.TabIndex = 15
        '
        'TXTstar3
        '
        Me.TXTstar3.Enabled = False
        Me.TXTstar3.Location = New System.Drawing.Point(239, 126)
        Me.TXTstar3.Name = "TXTstar3"
        Me.TXTstar3.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar3.TabIndex = 16
        '
        'TXTstar2
        '
        Me.TXTstar2.Enabled = False
        Me.TXTstar2.Location = New System.Drawing.Point(297, 126)
        Me.TXTstar2.Name = "TXTstar2"
        Me.TXTstar2.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar2.TabIndex = 17
        '
        'TXTstar1
        '
        Me.TXTstar1.Enabled = False
        Me.TXTstar1.Location = New System.Drawing.Point(364, 126)
        Me.TXTstar1.Name = "TXTstar1"
        Me.TXTstar1.Size = New System.Drawing.Size(20, 22)
        Me.TXTstar1.TabIndex = 18
        '
        'TXTinput
        '
        Me.TXTinput.Location = New System.Drawing.Point(56, 384)
        Me.TXTinput.Name = "TXTinput"
        Me.TXTinput.Size = New System.Drawing.Size(418, 22)
        Me.TXTinput.TabIndex = 19
        '
        'BTpart
        '
        Me.BTpart.Location = New System.Drawing.Point(544, 365)
        Me.BTpart.Name = "BTpart"
        Me.BTpart.Size = New System.Drawing.Size(130, 28)
        Me.BTpart.TabIndex = 20
        Me.BTpart.Text = "Search by Part"
        Me.BTpart.UseVisualStyleBackColor = True
        '
        'BTfull
        '
        Me.BTfull.Location = New System.Drawing.Point(544, 397)
        Me.BTfull.Name = "BTfull"
        Me.BTfull.Size = New System.Drawing.Size(130, 28)
        Me.BTfull.TabIndex = 21
        Me.BTfull.Text = "Search by Full Name"
        Me.BTfull.UseVisualStyleBackColor = True
        '
        'BTreset
        '
        Me.BTreset.Location = New System.Drawing.Point(480, 383)
        Me.BTreset.Name = "BTreset"
        Me.BTreset.Size = New System.Drawing.Size(58, 24)
        Me.BTreset.TabIndex = 22
        Me.BTreset.Text = "Reset"
        Me.BTreset.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(56, 197)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(618, 162)
        Me.DataGridView1.TabIndex = 23
        '
        'BTcomment
        '
        Me.BTcomment.Location = New System.Drawing.Point(364, 88)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 464)
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
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MydbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
