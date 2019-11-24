Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class FmProductList
    '表單啟始時執行
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ' 設定圖表 (Chart) 的參數
        Chart1.Series.Clear()
        Chart1.Series.Add("MyChart")
        Chart1.Legends(0).Enabled = False
        'Chart1.Series("MyChart").ChartType = DataVisualization.Charting.SeriesChartType.Pie

        ' 列出產品的分組 (productcategory) 於 ComboBox .... 方法二 (若用此方法, 可不需要用以下的方法一)
        MydbDataSetQQ.Clear()
        SqlAdapter.SelectCommand = New MySqlCommand("Select productcategory FROM " & C_TABLE & " WHERE (productcategory != '') GROUP BY productcategory", MySqlConn)
        SqlAdapter.Fill(MydbDataSetQQ, "CatagoryList")
        SqlAdapter.SelectCommand.Dispose()
        ComboBox1.DataSource = MydbDataSetQQ.Tables("CatagoryList")
        ComboBox1.DisplayMember = "productcategory"
        ComboBox1.Text = ""
        ' 方法二 .... 完

        SqlAdapter.SelectCommand.Dispose()  ' 釋放資源

        ' 顯示所有產品記錄
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
        If TXTstar5.DataBindings.Count = 0 Then
            TXTstar5.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "star5")
            TXTstar4.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "star4")
            TXTstar3.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "star3")
            TXTstar2.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "star2")
            TXTstar1.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "star1")

            TXTproductID.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "productid")
            TXTproductName.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "productname")
            TXTprice.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "price")
            TXTcatagory.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "productcategory")
            TXTlocation.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "location")
            Lbltotalnumber.DataBindings.Add("Text", MydbDataSetBindingSourceQQ, "totstar")  ' 列出已評分的總數
        End If

        ' 列出使用中的用戶名稱
        TxtName.Text = CurUserName

        ' 可以拉入圖片
        PictureBox1.AllowDrop = True
    End Sub



    ' 顯示記錄 .... M_condition = 選取記錄條件
    Private Sub P_ShowRecord(ByVal M_condition As String)
        PictureBox1.Image = Nothing  ' 先把圖片回空白

        ' 按條件選取記錄 ... totstar 為已評分的總數
        MydbDataSetQQ.Tables(C_TABLE).Clear()
        SqlAdapter.SelectCommand = New MySqlCommand("Select *, (star1+star2+star3+star4+star5) As totstar FROM " & C_TABLE & " WHERE (" & M_condition & ")", MySqlConn)

        ' 連接資料表 (Data Table)
        Try
            SqlAdapter.Fill(MydbDataSetQQ, C_TABLE)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Call P_Dispose()  ' 先把資源釋放
            End
        End Try

        SqlAdapter.SelectCommand.Dispose()  ' 釋放資源

        ' 處理取回資料表內的資料, 及於列表顯示
        MydbDataSetBindingSourceQQ.DataSource = MydbDataSetQQ.Tables(C_TABLE)
        DataGridView1.DataSource = MydbDataSetBindingSourceQQ

        ' 準備更新 (Update) 之指令句語 ... (只於第一次開始資料庫時準備)
        If (IsNothing(SqlCommand.DataAdapter)) And (MydbDataSetQQ.Tables(C_TABLE).Rows.Count > 0) Then
            SqlCommand.RefreshSchema()
            SqlCommand.DataAdapter = SqlAdapter
            SqlCommand.GetUpdateCommand()
        End If

        If MydbDataSetQQ.Tables(C_TABLE).Rows.Count > 0 Then Call P_ShowPicture()  ' 若有記錄, 顯示圖片
    End Sub

    ' 顯示圖片 及 圖表 (Chart)
    Private Sub P_ShowPicture()
        Dim SQLdataRow As DataRow  ' 一筆資料的記錄
        Dim i As Int16  ' 圖表變數
        Dim Cx() As String = {"5 Star", "4 Star", "3 Star", "2 Star", "1 Star"}  ' 圖表變數 .... 列表顯示的文字
        Dim Cy(4) As Int16  ' 圖表變數 .... 內容數值

        If DataGridView1.Rows.Count > 0 Then
            ' 先取得現時的一筆資料的記錄
            SQLdataRow = MydbDataSetQQ.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)

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
            BtRate.Enabled = ((InStr(SQLdataRow.Item("rateduser").ToString, ("," & CStr(CurUserID) & ",")) = 0) Or (C_OnlyRateOneTime = False))

            ' 列出圖表 (Chart)
            For i = 1 To 5
                Cy(5 - i) = Int(100 / Val(SQLdataRow.Item("totstar").ToString) * Val(SQLdataRow.Item("star" & CStr(i)).ToString))
            Next
            Chart1.Series("MyChart").Points.DataBindXY(Cx, Cy)
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
        ' 程式關閉, 把資源釋放
        MydbDataSetQQ.Dispose()
        MydbDataSetBindingSourceQQ.Dispose()
        FmSelection.Show()
    End Sub

    ' 去 FmRating 表單, 輸入內容
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtRate.Click
        ' 必須有記錄於資料庫內, 才可進入評分頁 (FmRating)
        If MydbDataSetQQ.Tables(C_TABLE).Rows.Count > 0 Then
            F2_Rate = 0
            F2_Comment = ""
            FmRating.ShowDialog()  ' 顯示評價表單
            Call P_SaveRate()  ' 把評價的內容, 寫入資料庫以保存
        End If
    End Sub

    ' 把輸入評價的內容, 寫入資料庫以保存
    Private Sub P_SaveRate()
        Dim SQLdataRow As DataRow  ' 一筆資料的記錄

        ' 若不是新開表單, 而且是剛從 Form2 回來, 而且又已選取了 "評價星星" 才作更新
        If F2_Rate <> 0 Then

            ' 先取得現時的一筆資料的記錄
            SQLdataRow = MydbDataSetQQ.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)

            ' 在資料記錄內, 把已選取的 "評價星星" 數目加一
            SQLdataRow.Item("star" & CStr(F2_Rate)) += 1
            F2_Rate = 0

            ' 把已在此產品評價的客戶 ID 記錄
            If (SQLdataRow.Item("rateduser") & "") = "" Then SQLdataRow.Item("rateduser") = ","
            SQLdataRow.Item("rateduser") &= CStr(CurUserID) & ","

            ' 如果有寫入評語 (Comment), 加入一行新的評語 (加入於原有的評語下)
            If F2_Comment <> "" Then SQLdataRow.Item("comment") &= vbCrLf & F2_Comment

            ' 更新資料庫內容
            Try
                SqlAdapter.Update(MydbDataSetQQ, C_TABLE)
                BtRate.Enabled = False
                SqlAdapter.Fill(MydbDataSetQQ, C_TABLE)
            Catch ex As Exception
            End Try
        End If
    End Sub

    ' 當此 Form1 表單再顯示時作用, 把輸入評價的內容, 寫入資料庫以保存 .... 
    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Call P_SaveRate()
    End Sub

    ' 顯示已選取記錄的評語 (Comment) 內容
    Private Sub BTcomment_Click(sender As Object, e As EventArgs) Handles BTcomment.Click
        If MydbDataSetQQ.Tables(C_TABLE).Rows.Count > 0 Then MessageBox.Show(MydbDataSetQQ.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value).Item("comment"))
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
             (UCase(FileIO.FileSystem.GetFileInfo(V_FileName(0)).Extension) = ".JPG") AndAlso (MydbDataSetQQ.Tables(C_TABLE).Rows.Count > 0) Then
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
        SQLdataRow = MydbDataSetQQ.Tables(C_TABLE).Rows.Find(DataGridView1.CurrentRow.Cells("ID").Value)
        SQLdataRow.Item("picture") = ArrImage
        SqlAdapter.Update(MydbDataSetQQ, C_TABLE)
    End Sub

    ' 列出已選的組別
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call P_ShowRecord("productcategory = '" & ComboBox1.Text & "'")
    End Sub

    ' 顯示選擇窗 (FmSelection)
    Private Sub BtHome_Click(sender As Object, e As EventArgs) Handles BtHome.Click
        Me.Close()
    End Sub
End Class
