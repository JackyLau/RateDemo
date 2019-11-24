Public Class FmOption
    ' 模擬表單
    Private Sub BtClose_Click(sender As Object, e As EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    ' 關閉表單, 列出選項表單
    Private Sub Form6_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FmSelection.Show()
    End Sub
End Class