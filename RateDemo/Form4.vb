Imports System.Runtime.InteropServices

Public Class Form4

    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Shared Function EnableMenuItem(ByVal Menu As IntPtr, ByVal EnableItem As Integer, ByVal Enable As Integer) As Integer
    'End Function

    '<DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)>
    'Private Shared Function GetSystemMenu(ByVal WindowHandle As IntPtr, ByVal Reset As Integer) As IntPtr
    'End Function

    Private Declare Function EnableMenuItem Lib "user32" (ByVal Menu As IntPtr, ByVal EnableItem As Integer, ByVal Enable As Integer) As Integer
    Private Declare Function GetSystemMenu Lib "user32" (ByVal WindowHandle As IntPtr, ByVal Reset As Integer) As IntPtr

    ' 不顯示視窗的關閉 "X" 按鈕 
    Private Sub BtDisableX_Click(sender As Object, e As EventArgs) Handles BtDisableX.Click
        EnableMenuItem(GetSystemMenu(Me.Handle, 0), &HF060, 1)
    End Sub

    ' 重新顯示視窗的關閉 "X" 按鈕 
    Private Sub BtEnableX_Click(sender As Object, e As EventArgs) Handles BtEnableX.Click
        EnableMenuItem(GetSystemMenu(Me.Handle, 0), &HF060, 0)
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form1.F4_ReturnToMain = False
    End Sub

    ' 顯示主視窗 (Form1)
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' 由主視窗 (Form1) 叫出此 Form 的 (Form4), 再 Show 回主視窗 (Form1) 
        If Form1.F4_FromMain Then Form1.Show()
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

    ' 關閉程式(完全離開) .... 再次重新啟動整個程式
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.F4_ReturnToMain = False
        Process.Start("RateDemo.exe")
        Me.Close()
    End Sub

    ' 列出附加表單
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form6.ShowDialog()
    End Sub
End Class