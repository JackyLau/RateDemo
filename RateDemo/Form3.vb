Public Class Form3
    Private Sub BtReg_Click(sender As Object, e As EventArgs) Handles BtReg.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then Form1.F3_Command = 1
        Me.Close()
    End Sub

    Private Sub BtLogin_Click(sender As Object, e As EventArgs) Handles BtLogin.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then
            Form1.F3_Command = 2
            Me.Close()
        Else
            MessageBox.Show("Please Enter The Username and Password !!")
        End If
    End Sub

    Private Sub Form3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.F3_Name = Trim(TXTname.Text)
        Form1.F3_Password = Trim(TXTpassword.Text)
    End Sub
End Class