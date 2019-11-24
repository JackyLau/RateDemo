Public Class FmStartUp
    ' 程式在此啟動 .... 開始
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Module1.Main()
        Me.Close()
    End Sub
End Class