Public Class FmStartUp

    ' 開始啟動程式
    Private Sub TmStartUp_Tick(sender As Object, e As EventArgs) Handles TmStartUp.Tick
        TmStartUp.Enabled = False
        Call MdRateDemo.Main()
        Me.Close()
    End Sub

    ' 圓型表單
    Private Sub FmStartUp_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim DrawCir As System.Drawing.Graphics = Me.CreateGraphics()
        DrawCir.FillEllipse(System.Drawing.Brushes.Yellow, 0, 0, Me.ClientSize.Width - 5, Me.ClientSize.Height - 5)
    End Sub
End Class