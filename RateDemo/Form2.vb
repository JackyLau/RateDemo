Public Class Form2

    Dim ArrButton As Guna.UI.WinForms.GunaImageButton()  ' 評價星星按鈕的陣列
    Const TextBoxDefault As String = "write down you comment"  ' 評語 (comment) TextBox 上的內定顯示文字

    '表單啟始時執行
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 複製評價星星按鈕於陣列, 以方便之後使用
        ArrButton = New Guna.UI.WinForms.GunaImageButton() {GunaImageButton1, GunaImageButton2, GunaImageButton3, GunaImageButton4, GunaImageButton5}
        GunaTextBox1.Text = TextBoxDefault
        Call P_Reset()  ' 把所有按鈕還原為未按
    End Sub

    ' 把所有按鈕還原為未按
    Private Sub P_Reset()
        Dim i As Int16
        For i = 0 To 4
            ArrButton(i).Enabled = True
        Next
        GunaTextBox1.Enabled = False
    End Sub

    ' 按下一個 "評價星星" 按鈕, 把按鈕設為反白顏色 (Disable) ... 其他按鈕還原為未按
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click, GunaImageButton2.Click, GunaImageButton3.Click, GunaImageButton4.Click, GunaImageButton5.Click
        Call P_Reset()
        sender.enabled = False
        GunaTextBox1.Enabled = True
    End Sub

    ' 返回原本視窗
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Int16

        ' 把已按下的 "評價星星" 按鈕的等級 (1-5) 記錄
        For i = 0 To 4
            If ArrButton(i).Enabled = False Then
                Form1.F2_Rate = (i + 1)
                Exit For
            End If
        Next

        ' 把評語 (comment) 記錄
        If Trim(GunaTextBox1.Text) <> TextBoxDefault Then Form1.F2_Comment = Now() & " - " & Trim(GunaTextBox1.Text)

        ' 必須要曾經評分, 才可交表格
        If Form1.F2_Rate = 0 Then
            MessageBox.Show("Rate before submit please")
        Else
            Me.Close()   ' 返回
        End If
    End Sub

    ' 把內定文字改為空白, 以方便用戶填寫評語 (comment)
    Private Sub GunaTextBox1_GotFocus(sender As Object, e As EventArgs) Handles GunaTextBox1.GotFocus
        If Trim(GunaTextBox1.Text) = TextBoxDefault Then GunaTextBox1.Text = ""
    End Sub

    ' 方便返回時顯示內定文字 .... Fix Bug for GunnaTextBox
    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Button1.Focus()
    End Sub

End Class