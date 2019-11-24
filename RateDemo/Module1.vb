Imports MySql.Data.MySqlClient

'###########################
'#  問卷輸入程式範例
'#  Programmer: Jacky Lau
'#  jackylau@yahoo.com
'#  Ver 1.0 ... 10/11/2019
'###########################

'Form1 ... 主表單 ... 作為列出所有產品
'Form2 ... 評刻表單 ... 客戶給予評分
'Form3 ... Login 表單 ... 客戶輸入 Name 及 Password
'Form4 ... 各項功能表單 ... Login 後列出
'Form5 ... 管理員用之批刻 (Approve) 表單
'Form6 ... 附加表單
'Form7 ... 啟始表單

Module Module1
#Disable Warning IDE0069
    Public MySqlConn As New MySqlConnection  ' MySQL 的資料庫 Connection 物件
    Public SqlAdapter As New MySqlDataAdapter ' MySQL 的資料庫 Adapter 物件
    Public SqlCommand As New MySqlCommandBuilder ' MySQL 的資料庫 自動建立 Command 物件
#Enable Warning IDE0069
    Public F2_Comment As String  ' 用作傳遞從 Form2 輸入的 Comment 資料
    Public F2_Rate As Int16  ' 用作傳遞從 Form2 輸入的 星號評價 資料

    Public CurUserID As Int16
    Public CurUserName As String

    ' 以下參數, 改回合用的
    Public Const C_SERVER As String = "LocalHost"  ' 資料庫位置 ... 便用時應改回 "LocalHost" 或 "127.0.0.1"
    Public Const C_USERNAME As String = "OneLoginName"  ' 資料庫 Login 用戶名
    Public Const C_PASSWORD As String = "OnePassWord"  ' 資料庫 Login 密碼
    Public Const C_DATABASE As String = "mydb"  ' 資料庫名稱
    Public Const C_TABLE As String = "product"  ' 資料表名稱
    Public Const C_OnlyRateOneTime As Boolean = False  ' 設定在同一次開啟程式時, 同一產品只可評價一次 (True = 只可評價一次 ... False = 可評價多次)
    Public Const C_CountExit As Int16 = 5  ' 設定離開程式可以錯誤的密碼次數  (0=無限次)

    Public MydbDataSet As New DataSet
    Public MydbDataSetBindingSource As New BindingSource

    Sub Main()
        Dim vLine() As String  ' 資料庫接入資訊

        MySqlConn.Close()

        ' 先連接資料庫
        If System.IO.File.Exists(Application.StartupPath & "\Login.user") Then
            ' 從設定檔案, 取得資料庫接入資訊 ... Line 1 = 資料庫位置, Line 2 = 登入名稱, Line 3 = 登入密碼, Line 4 = 資料庫名稱
            vLine = Split(My.Computer.FileSystem.ReadAllText("Login.user"), vbCrLf)
            MySqlConn.ConnectionString = "server=" & Trim(vLine(0)) & ";userid=" & Trim(vLine(1)) & ";password=" & Trim(vLine(2)) & ";database=" & Trim(vLine(3))
        Else
            MySqlConn.ConnectionString = "server=" & C_SERVER & ";userid=" & C_USERNAME & ";password=" & C_PASSWORD & ";database=" & C_DATABASE
        End If

        Try
            MySqlConn.Open()
        Catch ex As Exception
            MessageBox.Show("Open DataBase Error")
            Call P_Dispose()  ' 先把資源釋放
            End
        End Try

        ' 測試是否已有此資料表 (Data-Table), 若沒有, 新增一個
        SqlAdapter.SelectCommand = New MySqlCommand("SELECT TABLE_NAME FROM information_schema.tables WHERE " &
         "(TABLE_SCHEMA = '" & C_DATABASE & "') AND (TABLE_NAME = '" & C_TABLE & "')", MySqlConn)

        ' 尋找 "資料表" 列表 (Table-List)
        Try
            SqlAdapter.Fill(MydbDataSet, "DataTableList")
        Catch ex As Exception
            MessageBox.Show("Data Table List Error")
            Call P_Dispose()  ' 先把資源釋放
            End
        End Try

        SqlAdapter.SelectCommand.Dispose()  ' 釋放資源

        ' 測試是否已有此資料表 (Data-Table), 若沒有, 新增一個後, 先關閉程式
        If MydbDataSet.Tables("DataTableList").Rows.Count = 0 Then
            Dim NQ_command As MySqlCommand = MySqlConn.CreateCommand  ' SQL 執行指令

            ' 資料表內容
            NQ_command.CommandText = "CREATE TABLE " & C_TABLE & "(" &
             "productid INT(8) UNSIGNED Not NULL, " &
             "productname varchar(63) Not NULL, " &
             "productcategory varchar(63) Not NULL, " &
             "location varchar(63) Not NULL, " &
             "price DOUBLE Not NULL DEFAULT 0, " &
             "star5 Int(8) Not NULL Default 0, " &
             "star4 Int(8) Not NULL Default 0, " &
             "star3 Int(8) Not NULL Default 0, " &
             "star2 Int(8) Not NULL Default 0, " &
             "star1 Int(8) Not NULL Default 0, " &
             "comment MEDIUMTEXT Not NULL, " &
             "picture BLOB, " &
             "key(productid)" &
             ") ENGINE=MyISAM DEFAULT CHARSET=utf8"

            NQ_command.ExecuteNonQuery()
            NQ_command.Dispose()
            MessageBox.Show("New Data Table Created")
            Call P_Dispose()  ' 先把資源釋放
            End
        End If

        Form4.StartPosition = FormStartPosition.CenterScreen
        Form3.StartPosition = FormStartPosition.CenterScreen

        Form3.ShowDialog()
    End Sub


    ' 程式關閉, 把資源釋放
    Public Sub P_Dispose()
        MySqlConn.Close()
        MySqlConn.Dispose()
        SqlAdapter.Dispose()
        MydbDataSet.Dispose()
        SqlCommand.Dispose()
    End Sub
End Module

