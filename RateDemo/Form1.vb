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

Public Class Form1
#Disable Warning IDE0069
    Public MySqlConn As New MySqlConnection  ' MySQL 的資料庫 Connection 物件
    Private ReadOnly SqlAdapter As New MySqlDataAdapter ' MySQL 的資料庫 Adapter 物件
    Private ReadOnly SqlCommand As New MySqlCommandBuilder ' MySQL 的資料庫 自動建立 Command 物件
#Enable Warning IDE0069
    Private ArrRated As New ArrayList ' 已評分

    Public F2_Comment As String  ' 用作傳遞從 Form2 輸入的 Comment 資料
    Public F2_Rate As Int16  ' 用作傳遞從 Form2 輸入的 星號評價 資料

    Public F3_Name As String  ' 用作傳遞從 Form3 輸入的 Name 資料
    Public F3_Password As String   ' 用作傳遞從 Form3 輸入的 Password 資料
    Public F3_Command As Int16   ' 用作傳遞從 Form3 輸入的指令 ... 0=離開, 1=登記, 2=登入
    Public F4_FromMain As Boolean  ' 用作設定是否由主視窗 (Form1) 叫出選擇窗 (Form4)
    Public F4_ReturnToMain As Boolean  ' 用作設定是否由選擇窗 (Form4), 返回主視窗 (Form1)

    ' 以下參數, 改回合用的
    Const C_SERVER As String = "LocalHost"  ' 資料庫位置 ... 便用時應改回 "LocalHost" 或 "127.0.0.1"
    Const C_USERNAME As String = "OneLoginName"  ' 資料庫 Login 用戶名
    Const C_PASSWORD As String = "OnePassWord"  ' 資料庫 Login 密碼
    Const C_DATABASE As String = "mydb"  ' 資料庫名稱
    Const C_TABLE As String = "product"  ' 資料表名稱
    Const C_OnlyRateOneTime As Boolean = False  ' 設定在同一次開啟程式時, 同一產品只可評價一次 (True = 只可評價一次 ... False = 可評價多次)



    '表單啟始時執行
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vLine() As String  ' 資料庫接入資訊

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

        Call P_Login()

        ' 設定幾個按鈕的額外資訊
        ToolTip1.SetToolTip(BTreset, "Show all Records")
        ToolTip1.SetToolTip(BTpart, "Case Insensitive")
        ToolTip1.SetToolTip(BTfull, "Case Sensitive")

        ' 令顯示的列表內容不可給用戶自行改變, 亦不顯示最後加入新記錄的空格
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToResizeRows = False

        ' 設定只需要列出的資料行
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Category", .DataPropertyName = "productcategory"})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ID", .DataPropertyName = "productid"})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Name", .DataPropertyName = "productname"})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Price", .DataPropertyName = "price"})

        ' 列出產品的分組 (productcategory) 於 ComboBox .... 方法二 (若用此方法, 可不需要用以下的方法一)
        SqlAdapter.SelectCommand = New MySqlCommand("Select productcategory FROM " & C_TABLE & " WHERE (productcategory != '') GROUP BY productcategory", MySqlConn)
        SqlAdapter.Fill(MydbDataSet, "CatagoryList")
        SqlAdapter.SelectCommand.Dispose()
        ComboBox1.DataSource = MydbDataSet.Tables("CatagoryList")
        ComboBox1.DisplayMember = "productcategory"
        ComboBox1.Text = ""
        ' 方法二 .... 完

        ' 顯示所有記錄
        F2_Rate = 0
        Call P_ShowRecord("True")

        '' 列出產品的分組 (productcategory) 於 ComboBox .... 方法一 (若用此方法, 可不需要用以上的方法二)
        'ComboBox1.Items.Clear()
        'For Each OneRow As DataRow In MydbDataSet.Tables(C_TABLE).Rows
        '    If (OneRow("productcategory") & "" <> "") AndAlso (ComboBox1.FindStringExact(OneRow("productcategory")) = -1) Then
        '        ComboBox1.Items.Add(OneRow("productcategory"))
        '    End If
        'Next
        '' 方法一 .... 完

        ' 設定 TextBox 自動顯示選取的一筆記錄的內容
        TXTstar5.DataBindings.Add("Text", MydbDataSetBindingSource, "star5")
        TXTstar4.DataBindings.Add("Text", MydbDataSetBindingSource, "star4")
        TXTstar3.DataBindings.Add("Text", MydbDataSetBindingSource, "star3")
        TXTstar2.DataBindings.Add("Text", MydbDataSetBindingSource, "star2")
        TXTstar1.DataBindings.Add("Text", MydbDataSetBindingSource, "star1")

        TXTproductID.DataBindings.Add("Text", MydbDataSetBindingSource, "productid")
        TXTproductName.DataBindings.Add("Text", MydbDataSetBindingSource, "productname")
        TXTprice.DataBindings.Add("Text", MydbDataSetBindingSource, "price")
        TXTcatagory.DataBindings.Add("Text", MydbDataSetBindingSource, "productcategory")
        TXTlocation.DataBindings.Add("Text", MydbDataSetBindingSource, "location")

        Lbltotalnumber.DataBindings.Add("Text", MydbDataSetBindingSource, "totstar")  ' 列出已評分的總數

        TxtName.DataBindings.Add("Text", MydbDataSet.Tables("UserList"), "username")

        PictureBox1.AllowDrop = True
    End Sub


    ' 登記/登入用戶
    Private Sub P_Login()
        Dim Goodbye As Boolean  ' 關閉程式(離開)

        F3_Name = ""
        F3_Password = ""
        F3_Command = 0  ' 用作傳遞從 Form3 輸入的指令 ... 0=離開, 1=登記, 2=登入
        Goodbye = False

        ' 列出 .. 登記/登入 .. 的表格
        Form3.ShowDialog()

        If F3_Command = 0 Then
            Goodbye = True  ' 關閉程式(離開)
        Else
            ' 先取得用戶名稱
            SqlAdapter.SelectCommand = New MySqlCommand("Select * FROM user WHERE (username = '" & F3_Name & "')", MySqlConn)
            SqlAdapter.Fill(MydbDataSet, "UserList")
            SqlAdapter.SelectCommand.Dispose()

            If F3_Command = 2 Then
                ' 如果在客戶列表找不到用戶名 ... 或密碼不對 ... 或未經核准 ... 關閉程式(離開)
                If (MydbDataSet.Tables("UserList").Rows.Count = 0) OrElse
                 (MydbDataSet.Tables("UserList").Rows(0).Item("userpass") <> F3_Password) OrElse
                 (MydbDataSet.Tables("UserList").Rows(0).Item("approved") = False) Then
                    MessageBox.Show("Wrong Login Name/Password")
                    Goodbye = True
                Else
                    ' 客戶已通過 用戶名 及 密碼 驗證 ... 可以執行程式
                    F4_FromMain = False
                    F4_ReturnToMain = False
                    Form4.ShowDialog()
                End If
            ElseIf F3_Command = 1 Then
                ' 若未有之前已登記的用戶, 把新用戶資料, 加在資料表內
                If (MydbDataSet.Tables("UserList").Rows.Count = 0) Then
                    Dim NQ_command As MySqlCommand = MySqlConn.CreateCommand  ' SQL 執行指令
                    ' 資料表內容
                    NQ_command.CommandText = "INSERT INTO user (username, userpass) VALUES ('" & F3_Name & "', '" & F3_Password & "')"
                    NQ_command.ExecuteNonQuery()
                    NQ_command.Dispose()

                    MessageBox.Show("User Add, Waiting to Approve")
                Else
                    MessageBox.Show("User Name in used")
                End If
                Goodbye = True  ' 關閉程式(離開)
            End If
        End If

        ' 關閉程式(離開)
        If Goodbye Then
            Call P_Dispose()  ' 先把資源釋放
            End
        End If
    End Sub


    ' 顯示記錄 .... M_condition = 選取記錄條件
    Private Sub P_ShowRecord(ByVal M_condition As String)

        PictureBox1.Image = Nothing  ' 先把圖片回空白

        ' 按條件選取記錄 ... totstar 為已評分的總數
        MydbDataSet.Tables(C_TABLE).Clear()
        SqlAdapter.SelectCommand = New MySqlCommand("Select *, (star1+star2+star3+star4+star5) As totstar FROM " & C_TABLE & " WHERE (" & M_condition & ")", MySqlConn)

        ' 連接資料表 (Data Table)
        Try
            SqlAdapter.Fill(MydbDataSet, C_TABLE)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Call P_Dispose()  ' 先把資源釋放
            End
        End Try

        SqlAdapter.SelectCommand.Dispose()  ' 釋放資源

        ' 處理取回資料表內的資料, 及於列表顯示
        MydbDataSetBindingSource.DataSource = MydbDataSet.Tables(C_TABLE)
        DataGridView1.DataSource = MydbDataSetBindingSource

        ' 準備更新 (Update) 之指令句語 ... (只於第一次開始資料庫時準備)
        If (IsNothing(SqlCommand.DataAdapter)) And (MydbDataSet.Tables(C_TABLE).Rows.Count > 0) Then
            SqlCommand.RefreshSchema()
            SqlCommand.DataAdapter = SqlAdapter
            SqlCommand.GetUpdateCommand()
        End If

        If MydbDataSet.Tables(C_TABLE).Rows.Count > 0 Then Call P_ShowPicture()  ' 若有記錄, 顯示圖片
    End Sub

    ' 顯示圖片 ..... V_row = 資料表的行號
    Private Sub P_ShowPicture()
        Dim SQLdataRow As DataRow  ' 一筆資料的記錄

        If DataGridView1.Rows.Count > 0 Then
            ' 先取得現時的一筆資料的記錄
            SQLdataRow = MydbDataSet.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)

            ' 有圖片才顯示
            If SQLdataRow.Item("picture").ToString = "" Then
                PictureBox1.Image = Nothing
            Else
                Dim ImgBytes As Byte() = SQLdataRow.Item("picture")  ' 照片的二進制資料陣列
                ' 若已有舊照片, 先釋放資源
                If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
                PictureBox1.Image = Image.FromStream(New System.IO.MemoryStream(ImgBytes))
            End If

            ' 設定是否可以投票 ... 若此用戶已投票於此產品, 不可以再投票
            Button1.Enabled = (InStr(SQLdataRow.Item("rateduser").ToString, ("," & CStr(MydbDataSet.Tables("UserList").Rows(0).Item("userid")) & ",")) = 0)
        End If
    End Sub

    ' 已選取了一筆記錄, 把內容顯示出來
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then Call P_ShowPicture()  ' 若不是按了列表的頂部, 顯示圖片
    End Sub

    ' 顯示所有記錄
    Private Sub BTreset_Click(sender As Object, e As EventArgs) Handles BTreset.Click
        ComboBox1.Text = ""
        TXTinput.Text = ""
        Call P_ShowRecord("True")
    End Sub


    ' 顯示產品名稱部份相同的記錄
    Private Sub BTpart_Click(sender As Object, e As EventArgs) Handles BTpart.Click
        Call P_ShowRecord("UPPER(productname) Like '%" & UCase(Trim(TXTinput.Text)) & "%'")
    End Sub

    ' 顯示產品名稱完全相同的記錄 (大小寫都要相同)
    Private Sub BTfull_Click(sender As Object, e As EventArgs) Handles BTfull.Click
        Call P_ShowRecord("BINARY productname = '" & Trim(TXTinput.Text) & "'")
    End Sub

    ' 程式關閉
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call P_Dispose()  ' 把資源釋放
    End Sub

    ' 程式關閉, 把資源釋放
    Public Sub P_Dispose()
        MySqlConn.Close()
        MySqlConn.Dispose()
        SqlAdapter.Dispose()
        MydbDataSet.Dispose()
        SqlCommand.Dispose()
        ArrRated = Nothing
    End Sub

    ' 去 Form2 表單, 輸入內容
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 測試是否已在此次評分同一產品 ... 及必須有記錄於資料庫內 ... 合乎條件才可進入評分頁 (Form2)
        If ((ArrRated.Contains(DataGridView1.CurrentRow.Cells("ID").Value) = False) Or (C_OnlyRateOneTime = False)) And
         (MydbDataSet.Tables(C_TABLE).Rows.Count > 0) Then
            F2_Rate = 0
            F2_Comment = ""
            Form2.ShowDialog()
        End If
    End Sub

    ' 把輸入的內容, 寫入資料庫以保存 .... 當此 Form1 表單再顯示時作用
    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim SQLdataRow As DataRow  ' 一筆資料的記錄

        ' 若不是新開表單, 而且是剛從 Form2 回來, 而且又已選取了 "評價星星" 才作更新
        If F2_Rate <> 0 Then

            ' 先取得現時的一筆資料的記錄
            SQLdataRow = MydbDataSet.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)
            ' 在資料記錄內, 把已選取的 "評價星星" 數目加一
            SQLdataRow.Item("star" & CStr(F2_Rate)) += 1
            ' 把已在此產品評價的客戶 ID 記錄
            If (SQLdataRow.Item("rateduser") & "") = "" Then SQLdataRow.Item("rateduser") = ","
            SQLdataRow.Item("rateduser") &= MydbDataSet.Tables("UserList").Rows(0).Item("userid") & ","
            ' 如果有寫入評語 (Comment), 加入一行新的評語 (加入於原有的評語下)
            If F2_Comment <> "" Then SQLdataRow.Item("comment") &= vbCrLf & F2_Comment
            ' 更新資料庫內容
            SqlAdapter.Update(MydbDataSet, C_TABLE)

            ' 加進入已評分產品記錄群內
            If C_OnlyRateOneTime Then ArrRated.Add(DataGridView1.CurrentRow.Cells("ID").Value)
            F2_Rate = 0

            SqlAdapter.Fill(MydbDataSet, C_TABLE)
            Button1.Enabled = False
        End If
    End Sub

    ' 顯示已選取記錄的評語 (Comment) 內容
    Private Sub BTcomment_Click(sender As Object, e As EventArgs) Handles BTcomment.Click
        If MydbDataSet.Tables(C_TABLE).Rows.Count > 0 Then MessageBox.Show(MydbDataSet.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value).Item("comment"))
    End Sub


    ' 當有檔案拉入, 顯示出可拉入的 ICON, 確定是檔案 (不是其他物件), 確定只有一個檔案, 確定不是資料匣, 確定是 JPG 檔
    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim vfilename() As String = e.Data.GetData(DataFormats.FileDrop)  ' 拉入的檔案名
            If (vfilename.Length = 1) AndAlso (FileIO.FileSystem.DirectoryExists(vfilename(0)) = False) AndAlso
             (UCase(FileIO.FileSystem.GetFileInfo(vfilename(0)).Extension) = ".JPG") Then e.Effect = DragDropEffects.Copy
        End If
    End Sub


    ' 有檔案拉入照片匡, 顯示拉入的照片, 及儲存該照片於現時記錄
    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim V_FileName() As String  ' 拉入的檔案名 (照片存放位置)

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            V_FileName = e.Data.GetData(DataFormats.FileDrop)
            ' 確定是檔案 (不是其他物件), 確定只有一個檔案, 而又不是資料匣, 亦確定是 JPG 檔, 亦已有記錄於資料庫
            If (V_FileName.Length = 1) AndAlso (FileIO.FileSystem.DirectoryExists(V_FileName(0)) = False) AndAlso
             (UCase(FileIO.FileSystem.GetFileInfo(V_FileName(0)).Extension) = ".JPG") AndAlso (MydbDataSet.Tables(C_TABLE).Rows.Count > 0) Then
                ' 顯示照片
                Call P_ShowPhoto(V_FileName(0))
                ' 儲存該照片於現時記錄
                Call P_SavePhoto()
            End If
        End If
    End Sub

    ' 顯示照片 ..... One_FileName = 照片的檔案名
    Private Sub P_ShowPhoto(ByVal One_FileName As String)
        ' 若已有舊照片, 先釋放資源
        If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
        ' 顯示照片
        PictureBox1.Image = Image.FromFile(One_FileName)
    End Sub

    ' 儲存該照片於現時記錄
    Private Sub P_SavePhoto()

        Dim Mstream As New System.IO.MemoryStream()  ' 照片的數碼內容 
        Dim ArrImage() As Byte  ' 照片的二進制資料陣列
        Dim SQLdataRow As DataRow  ' 一筆資料的記錄

        ' 取得照片的數碼內容 
        PictureBox1.Image.Save(Mstream, Imaging.ImageFormat.Jpeg)
        ArrImage = Mstream.GetBuffer()
        Mstream.Close()
        Mstream.Dispose()

        ' 把照片放在列表內 ... 再在資料庫更新記錄
        SQLdataRow = MydbDataSet.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)
        SQLdataRow.Item("picture") = ArrImage
        SqlAdapter.Update(MydbDataSet, C_TABLE)
    End Sub

    ' 列出已選的組別
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call P_ShowRecord("productcategory = '" & ComboBox1.Text & "'")
    End Sub

    ' 顯示選擇窗 (Form4)
    Private Sub BtHome_Click(sender As Object, e As EventArgs) Handles BtHome.Click
        F4_FromMain = True
        F4_ReturnToMain = False
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
