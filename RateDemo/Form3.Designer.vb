<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.BtLogin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTname = New System.Windows.Forms.TextBox()
        Me.TXTpassword = New System.Windows.Forms.TextBox()
        Me.BtReg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtLogin
        '
        Me.BtLogin.Location = New System.Drawing.Point(107, 120)
        Me.BtLogin.Name = "BtLogin"
        Me.BtLogin.Size = New System.Drawing.Size(114, 25)
        Me.BtLogin.TabIndex = 0
        Me.BtLogin.Text = "Login"
        Me.BtLogin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'TXTname
        '
        Me.TXTname.Location = New System.Drawing.Point(109, 28)
        Me.TXTname.Name = "TXTname"
        Me.TXTname.Size = New System.Drawing.Size(112, 22)
        Me.TXTname.TabIndex = 3
        '
        'TXTpassword
        '
        Me.TXTpassword.Location = New System.Drawing.Point(107, 69)
        Me.TXTpassword.Name = "TXTpassword"
        Me.TXTpassword.Size = New System.Drawing.Size(114, 22)
        Me.TXTpassword.TabIndex = 4
        '
        'BtReg
        '
        Me.BtReg.Location = New System.Drawing.Point(39, 118)
        Me.BtReg.Name = "BtReg"
        Me.BtReg.Size = New System.Drawing.Size(59, 26)
        Me.BtReg.TabIndex = 5
        Me.BtReg.Text = "Register"
        Me.BtReg.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 173)
        Me.Controls.Add(Me.BtReg)
        Me.Controls.Add(Me.TXTpassword)
        Me.Controls.Add(Me.TXTname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtLogin)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtLogin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTname As TextBox
    Friend WithEvents TXTpassword As TextBox
    Friend WithEvents BtReg As Button
End Class
