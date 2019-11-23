Imports MySql.Data.MySqlClient

Public Class Form3
#Disable Warning IDE0069
    ReadOnly SqlTable As New DataTable ' 資料表
#Enable Warning IDE0069
    Dim LoopCount As Int16

    ' 註冊使用者
    Private Sub BtReg_Click(sender As Object, e As EventArgs) Handles BtReg.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then
            Call P_OpenTable()

            ' 若未有之前已登記的用戶, 把新用戶資料, 加在資料表內
            If (SqlTable.Rows.Count = 0) Then
                Dim NQ_command As MySqlCommand = MySqlConn.CreateCommand  ' SQL 執行指令
                ' 資料表內容
                NQ_command.CommandText = "INSERT INTO user (username, userpass) VALUES ('" & TXTname.Text & "', '" & TXTpassword.Text & "')"
                NQ_command.ExecuteNonQuery()
                NQ_command.Dispose()
                MessageBox.Show("User Add, Waiting to Approve")
                Me.Close()
            Else
                MessageBox.Show("User Name in used")
                LoopCount += 1
                If LoopCount > 5 Then Me.Close()
            End If
        End If
    End Sub

    ' 使用者登入
    Private Sub BtLogin_Click(sender As Object, e As EventArgs) Handles BtLogin.Click
        If (Trim(TXTname.Text) <> "") And (Trim(TXTpassword.Text) <> "") Then
            Call P_OpenTable()

            ' 如果在客戶列表找不到用戶名 ... 或密碼不對 ... 或未經核准 ... 關閉程式(離開)
            If (SqlTable.Rows.Count = 0) OrElse
                 (SqlTable.Rows(0).Item("userpass") <> TXTpassword.Text) OrElse
                 (SqlTable.Rows(0).Item("approved") = False) Then
                MessageBox.Show("Wrong Login Name/Password")
                LoopCount += 1
                If LoopCount > 5 Then Me.Close()
            Else
                ' 客戶已通過 用戶名 及 密碼 驗證 ... 可以執行程式
                CurUserID = SqlTable.Rows(0).Item("userid")
                CurUserName = SqlTable.Rows(0).Item("username")
                LoopCount = 0
                SelectFormToOpen = 4
                '                Form4.Show()
                Me.Close()
            End If
        Else
            MessageBox.Show("Please Enter The Username and Password !!")
        End If
    End Sub

    ' 表單關閉
    Private Sub Form3_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SqlTable.Dispose()
    End Sub

    ' 列出 Approve 表單
    Private Sub BtLogin_MouseUp(sender As Object, e As MouseEventArgs) Handles BtLogin.MouseUp
        If (e.Button = MouseButtons.Right) And (Control.ModifierKeys = Keys.Shift) Then
            Form5.ShowDialog()
            'SelectFormToOpen = 5
            'Me.Close()
        End If
    End Sub

    ' 測試用
    Private Sub BtReg_MouseUp(sender As Object, e As MouseEventArgs) Handles BtReg.MouseUp
        If e.Button = MouseButtons.Right Then
            TXTname.Text = "a"
            TXTpassword.Text = "a"
            Call BtLogin_Click(sender, e)
        End If
    End Sub

    ' 查詢密碼
    Private Sub BtShowPassword_Click(sender As Object, e As EventArgs) Handles BtShowPassword.Click
        If (Trim(TXTname.Text) <> "") Then
            Call P_OpenTable()

            ' 如果在客戶列表找不到用戶名 ... 離開
            If SqlTable.Rows.Count = 0 Then
                MessageBox.Show("No User Name Here")
            Else
                ' 已找到用戶名... 列出密碼
                'MessageBox.Show(SqlTable.Rows(0).Item("userpass"))  ' 效果一
                TXTname.Text &= " >>> " & SqlTable.Rows(0).Item("userpass")  ' 效果二
                'BtShowPassword.Text = SqlTable.Rows(0).Item("userpass")  ' 效果三
                'BtShowPassword.Enabled = False  ' 效果三
            End If
        Else
            MessageBox.Show("Please Enter Username !!")
        End If
    End Sub

    Private Sub P_OpenTable()
        ' 先取得用戶名稱
        SqlTable.Clear()
        SqlAdapter.SelectCommand = New MySqlCommand("Select * FROM user WHERE (username = '" & TXTname.Text & "')", MySqlConn)
        SqlAdapter.Fill(SqlTable)
        SqlAdapter.SelectCommand.Dispose()
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectFormToOpen = 0
        TXTname.Text = ""
        TXTpassword.Text = ""
    End Sub
End Class