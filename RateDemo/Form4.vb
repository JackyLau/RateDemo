﻿Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form1.F4_ReturnToMain = False
    End Sub

    ' 顯示主視窗 (Form1)
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Form1.F4_FromMain Then Form1.Show()  ' 由主視窗 (Form1) 叫出此 Form 的 (Form4), 再 Show 回主視窗 (Form1) 
        Form1.F4_ReturnToMain = True
        Me.Close()
    End Sub

    ' 關閉時動作
    Private Sub Form4_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' 若不是按任何按鈕關閉的 ... 程式結束
        If Not Form1.F4_ReturnToMain Then
            Call Form1.P_Dispose()
            End
        End If
    End Sub
End Class