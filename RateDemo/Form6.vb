Public Class Form6

    Private Sub BtClose_Click(sender As Object, e As EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub Form6_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form4.Show()
    End Sub
End Class