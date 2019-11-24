Imports System.Runtime.InteropServices

Public Class FmSelection
    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Shared Function EnableMenuItem(ByVal Menu As IntPtr, ByVal EnableItem As Integer, ByVal Enable As Integer) As Integer
    'End Function

    '<DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)>
    'Private Shared Function GetSystemMenu(ByVal WindowHandle As IntPtr, ByVal Reset As Integer) As IntPtr
    'End Function

    ' 顯示/不顯示視窗的關閉 "X" 按鈕的 API
    Private Declare Function EnableMenuItem Lib "user32" (ByVal Menu As IntPtr, ByVal EnableItem As Integer, ByVal Enable As Integer) As Integer
    Private Declare Function GetSystemMenu Lib "user32" (ByVal WindowHandle As IntPtr, ByVal Reset As Integer) As IntPtr

    Dim CloseMe As Boolean  ' 是否要馬上關閉此視窗

    ' 不顯示視窗的關閉 "X" 按鈕 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtDisableX.Click
        EnableMenuItem(GetSystemMenu(Me.Handle, 0), &HF060, 1)
    End Sub

    ' 重新顯示視窗的關閉 "X" 按鈕 
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BtEnableX.Click
        EnableMenuItem(GetSystemMenu(Me.Handle, 0), &HF060, 0)
    End Sub

    ' 顯示產品目錄列表視窗
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call P_OpenForm(FmProductList)
    End Sub

    ' 再次啟動登入視窗
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call P_OpenForm(FmLogin)
    End Sub

    ' 沒有使用
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Me.Close()
    End Sub

    ' 顯示 Option 視窗 (Form6)
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call P_OpenForm(FmOption)
    End Sub

    ' 共用程序, 開啟視窗, 關閉自己
    Private Sub P_OpenForm(ByRef OneForm As Form)
        CloseMe = True
        OneForm.Show()
        Me.Close()
    End Sub

    ' 開啟本視窗時, 設定自動關閉時間
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CloseMe = C_FastClose  ' 設定是否在按 "X" 時馬上關閉程式
        Timer1.Interval = 5000
        Timer1.Enabled = True
    End Sub

    ' 關閉(離開) .... 按 X 關閉視窗時, 先開啟登入 (Login) 視窗
    Private Sub Form4_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Timer1.Enabled = False
        If Not CloseMe Then Call P_OpenForm(FmLogin)
    End Sub

    ' 時間到達, 開啟登入 (Login) 視窗
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call P_OpenForm(FmLogin)
    End Sub
End Class