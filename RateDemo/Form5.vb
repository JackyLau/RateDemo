Imports MySql.Data.MySqlClient

Public Class Form5
    ' 準備列出所有尚未 Approve 的客戶名
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlAdapter As New MySqlDataAdapter ' MySQL 的資料庫 Adapter 物件
        Dim SqlTable As New DataTable ' 資料表
        Dim OneRow As DataRow


        SqlAdapter.SelectCommand = New MySqlCommand("Select username FROM user WHERE (NOT approved)", Form1.MySqlConn)
        SqlTable.Clear()
        SqlAdapter.Fill(SqlTable)
        SqlAdapter.SelectCommand.Dispose()
        SqlAdapter.Dispose()
        SqlTable.Dispose()

        LbName.Items.Clear()

        For Each OneRow In SqlTable.Rows
            LbName.Items.Add(OneRow.Item("username"))
        Next
    End Sub

    ' 批准 (Approve) 一個客戶
    Private Sub BtAppOne_Click(sender As Object, e As EventArgs) Handles BtAppOne.Click
        ' 把用戶設定為可以 Login (Approved)
        If LbName.Text <> "" Then
            Dim NQ_command As MySqlCommand = Form1.MySqlConn.CreateCommand  ' SQL 執行指令
            NQ_command.CommandText = "UPDATE user SET approved = TRUE WHERE (username = '" & LbName.Text & "')"
            NQ_command.ExecuteNonQuery()
            NQ_command.Dispose()
            LbName.Items.Remove(LbName.Text)
        End If
    End Sub

    ' 批准 (Approve) 所有客戶
    Private Sub BtAppALL_Click(sender As Object, e As EventArgs) Handles BtAppALL.Click
        Dim NQ_command As MySqlCommand = Form1.MySqlConn.CreateCommand  ' SQL 執行指令
        NQ_command.CommandText = "UPDATE user SET approved = TRUE WHERE (NOT approved)"
        NQ_command.ExecuteNonQuery()
        NQ_command.Dispose()
        LbName.Items.Clear()
    End Sub

End Class