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


    ' 關閉程式(完全離開) .... 再次重新啟動整個程式
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    ' 關閉程式(完全離開) .... 再次重新啟動整個程式
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Close()
    End Sub

    ' 沒有使用
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Me.Close()
    End Sub

    ' 顯示 Option 視窗 (Form6)
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form6.Show()
        Me.Close()
    End Sub
End Class