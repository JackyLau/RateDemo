﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtDisableX = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BtEnableX = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 31)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Rate Window (1)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtDisableX
        '
        Me.BtDisableX.Location = New System.Drawing.Point(159, 38)
        Me.BtDisableX.Name = "BtDisableX"
        Me.BtDisableX.Size = New System.Drawing.Size(116, 31)
        Me.BtDisableX.TabIndex = 1
        Me.BtDisableX.Text = "Disable Close ""X"" (2)"
        Me.BtDisableX.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(285, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 31)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Return (3)"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(33, 92)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 31)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Not Use (4)"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BtEnableX
        '
        Me.BtEnableX.Location = New System.Drawing.Point(159, 92)
        Me.BtEnableX.Name = "BtEnableX"
        Me.BtEnableX.Size = New System.Drawing.Size(116, 31)
        Me.BtEnableX.TabIndex = 4
        Me.BtEnableX.Text = "Enable Close ""X"" (5)"
        Me.BtEnableX.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(285, 92)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(116, 31)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Option (6)"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 157)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.BtEnableX)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.BtDisableX)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents BtDisableX As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents BtEnableX As Button
    Friend WithEvents Button6 As Button
End Class
