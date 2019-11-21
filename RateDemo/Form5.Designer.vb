<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LbName = New System.Windows.Forms.ListBox()
        Me.BtAppALL = New System.Windows.Forms.Button()
        Me.BtAppOne = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LbName
        '
        Me.LbName.FormattingEnabled = True
        Me.LbName.ItemHeight = 12
        Me.LbName.Location = New System.Drawing.Point(39, 30)
        Me.LbName.Name = "LbName"
        Me.LbName.Size = New System.Drawing.Size(245, 184)
        Me.LbName.TabIndex = 0
        '
        'BtAppALL
        '
        Me.BtAppALL.Location = New System.Drawing.Point(39, 249)
        Me.BtAppALL.Name = "BtAppALL"
        Me.BtAppALL.Size = New System.Drawing.Size(112, 33)
        Me.BtAppALL.TabIndex = 1
        Me.BtAppALL.Text = "Approve ALL"
        Me.BtAppALL.UseVisualStyleBackColor = True
        '
        'BtAppOne
        '
        Me.BtAppOne.Location = New System.Drawing.Point(173, 249)
        Me.BtAppOne.Name = "BtAppOne"
        Me.BtAppOne.Size = New System.Drawing.Size(111, 33)
        Me.BtAppOne.TabIndex = 2
        Me.BtAppOne.Text = "Approve Select One"
        Me.BtAppOne.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 314)
        Me.Controls.Add(Me.BtAppOne)
        Me.Controls.Add(Me.BtAppALL)
        Me.Controls.Add(Me.LbName)
        Me.Name = "Form5"
        Me.Text = "Form5"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LbName As ListBox
    Friend WithEvents BtAppALL As Button
    Friend WithEvents BtAppOne As Button
End Class
