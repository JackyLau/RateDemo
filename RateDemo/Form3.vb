Public Class Form3
    ' 註冊使用者
    Private Sub BtReg_Click(sender As Object, e As EventArgs) Handles BtReg.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then Form1.F3_Command = 1
        Me.Close()
    End Sub

    ' 使用者登入
    Private Sub BtLogin_Click(sender As Object, e As EventArgs) Handles BtLogin.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then
            Form1.F3_Command = 2
            Me.Close()
        Else
            MessageBox.Show("Please Enter The Username and Password !!")
        End If
    End Sub

    ' 表單關閉, 儲存 Name 及 Password, 以待到主表單 (Form1) 測試
    Private Sub Form3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.F3_Name = Trim(TXTname.Text)
        Form1.F3_Password = Trim(TXTpassword.Text)
    End Sub

    ' 列出 Approve 表單
    Private Sub BtLogin_MouseUp(sender As Object, e As MouseEventArgs) Handles BtLogin.MouseUp
        If (e.Button = MouseButtons.Right) And (Control.ModifierKeys = Keys.Shift) Then Form5.ShowDialog()
    End Sub

    ' 測試用
    Private Sub BtReg_MouseUp(sender As Object, e As MouseEventArgs) Handles BtReg.MouseUp
        If e.Button = MouseButtons.Right Then
            TXTname.Text = "a"
            TXTpassword.Text = "a"
            Form1.F3_Command = 9
            Me.Close()
        End If
    End Sub

    ' 查詢密碼
    Private Sub BtShowPassword_Click(sender As Object, e As EventArgs) Handles BtShowPassword.Click
        If (Trim(TXTname.Text) <> "") Then
            Form1.F3_Command = 4
            Me.Close()
        Else
            MessageBox.Show("Please Enter Username !!")
        End If
    End Sub
End Class