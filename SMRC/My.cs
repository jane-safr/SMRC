using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Reporting.WinForms;

static class my
{
    public static Form MDIFormCont ;
    public static int Nbut; public static string Szap; public static string SzapN; public static string Ustr; public static string Upred = "";
    public static string Login; public static string headStr; public static string widthStr; public static string cap = "";
    public static string UpredName; public static SMRC.Forms.frmLoad MDIForm; 
    public static DateTime Uper; public static string UperName; public static bool Dostup;
    public static SqlConnection cn; public static SqlCommand sc; public static Form Pform; public static SqlConnection cnjane; public static SqlConnection cnReadOnly;
    public static int Id_us; public static string Id_UsName;  public static byte Id_gr; 
    public static int Vid; public static int identpr;
    public static string sconn; public static string sconnjane; public static string sconnReadOnly;
    public static string[] MyStr = new string[5];


    public static void ObnPer(ComboBox d)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Period", typeof(DateTime));
        dt.Columns.Add("PeriodStr", typeof(String));
        DataSet ObnPer = new DataSet();
        ObnPer.Tables.Add(dt);
        DateTime d1 = new DateTime(1999, 1, 1);
        while (d1 <= DateTime.Today.AddMonths(5))
        {
            DataRow row = dt.NewRow();
            row["Period"] = d1;
            row["PeriodStr"] = d1.ToString("MMMM").ToLower() + " " + d1.ToString("yyyy").ToLower().ToLower() + " г.";
            dt.Rows.Add(row);
            d1 = d1.AddMonths(1);
        }
        d.DataSource = dt;
        d.ValueMember = dt.Columns[0].ColumnName;
        d.DisplayMember = dt.Columns[1].ColumnName;
        //return ObnPer;
    }

    public static void ReportExport(object sender, ReportExportEventArgs e,ReportViewer ReportViewer1)
    {

        if (e.Extension.Name == "EXCELOPENXML")
        {
            e.Cancel = true;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string[] streams;
            Microsoft.Reporting.WinForms.Warning[] warnings;

            byte[] pdfContent = ReportViewer1.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            string pdfPath = Application.StartupPath + "\\" + my.Login + "reportBarcode.xls";
            try
            {
                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(pdfContent, 0, pdfContent.Length);
                pdfFile.Close();
                System.Diagnostics.Process.Start(pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"У Вас открыт файл предыдущего экспорта в Excel. 
Закройте или переименуйте его!" + ex.Message);
            }

        };

    }
    public static void FillDC(ComboBox ComboBox1, int id, String s1)
    {
        DataSet ds = new DataSet(); String s;
        if (id < 1000)
        { s = "exec FillSpr  " + id + ",'" + s1 + "'"; }
        else { s = s1; }
        SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
        da.Fill(ds);
        ComboBox1.DataSource = ds.Tables[0];
        ComboBox1.ValueMember = ds.Tables[0].Columns[0].ColumnName;
        ComboBox1.DisplayMember = ds.Tables[0].Columns[1].ColumnName;
        da.Dispose();
       ds.Dispose();
    }
    public static void RemStrSost()
    {
        my.MDIForm.StatusStrip.Items[0].Text = Id_UsName;
        my.MDIForm.Refresh();
    }
    public static DataSet GetDS(string s, String sconnSm)
    {
        try
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, sconnSm);
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        catch
        { return null; }
    }
    public static bool isFormInMdi(String Name, int nbut1, Form Mdi)
    {
        bool inmdi = false;
        foreach (Form f in MDIForm.MdiChildren)
        {
            if (f.Tag != null)
            {
                if (f.Name == Name)
                {
                    if ( System.Convert.ToInt32(f.Tag) == nbut1) { f.BringToFront(); my.Pform = f; inmdi = true; }
                }
            }
        }
        return inmdi;
    }
    public static void showSprDGV(int nbut, bool Withup, bool WithSize)
    {
        SMRC.Forms.frmSprDGV fr = new SMRC.Forms.frmSprDGV();
        fr.MdiParent = MDIForm;
        if (WithSize)
        {
            fr.Dock = DockStyle.Fill;
        }
       fr.Withup = Withup;
        fr.Show();
        fr.Tag = nbut;
        //if (WithSize)
        //{
        //    int h = fr.Height;
        //    fr.Dock = DockStyle.None;
        //    fr.Height = h;
        //}
        //fr.Left = (int)(MDIForm.Width - fr.Width) / 2;
    }
    public static void showSprZapros(int nbut, bool Withup, bool WithSize)
    {
        SMRC.Forms.frmSprZapros fr = new SMRC.Forms.frmSprZapros();
        fr.MdiParent = MDIForm;
        if (WithSize)
        {
            fr.Dock = DockStyle.Fill;
        }
        
        fr.Show();
        fr.Tag = nbut;

    }
    public static String FilterSel(int Nbut1, Form fr, String cnStr, String Szap1)
    {
        SqlConnection cn = new SqlConnection(cnStr);
        String FilterSel = "";

        try
        {
            cn.Open();
            SqlCommand commandRowCount = new SqlCommand();
            commandRowCount.Connection = cn;
            if (Nbut1 == 3001)
            {
                return Szap1;
            }
            if (Nbut1 == 3000) { commandRowCount.CommandText = Szap1; }
            else
            {
                if (Nbut1 > 2000) { commandRowCount.CommandText = " exec s_FilterSel " + Nbut1 + ", '" + Szap1 + "'"; }
                else
                { commandRowCount.CommandText = "SELECT     headers, sel, caption, [width] From FilterSel WHERE     idSel =" + Nbut1; }
            }
            SqlDataReader DRd = commandRowCount.ExecuteReader();
            DRd.Read();
            if (Nbut1 == 168 | Nbut1 == 73 | Nbut1 == 711)
                FilterSel = DRd.GetString(1).ToString();
            else
            FilterSel = DRd.GetString(1).ToLower();
            if (Regex.IsMatch(FilterSel, "order by") || Regex.IsMatch(FilterSel, "group by"))
            { FilterSel = FilterSel.Replace(" where (1=1)", " where (1=1)" + Szap1);}
            else
            { FilterSel = FilterSel + (Nbut1 != 3000 ? Szap1 : ""); }
            headStr = DRd.GetString(0);
            widthStr = DRd.GetString(3);
            SzapN = DRd.GetString(2);
            if (fr != null) { fr.Text = DRd.GetString(2); }
            DRd.Close();
            DRd.Dispose();
            cn.Close();
            return FilterSel;
        }
        catch (InvalidCastException ex)
        {
            cn.Close();
            MessageBox.Show(ex.Message);
            return "";
        }
    }
    public static void naimDG(String sel, SMRC.DGVt Grid, String widthStr)
    {
        int w = 0;
        int w1 = 0;
        for (int i = 0; i <= Grid.Columns.Count - 1; i++)
        {
            if (w <= sel.Length)
            {
                if (sel.Substring(w, (int)sel.IndexOf(",", w) == -1 ? sel.Length - w : sel.IndexOf(",", w) - w).ToString().Trim() == "0") { Grid.Columns[i].Visible = false; }
                Grid.Columns[i].HeaderText = sel.Substring(w, (int)(sel.IndexOf(",", w) == -1 ? sel.Length - w : sel.IndexOf(",", w) - w));
                w = (int)sel.IndexOf(",", w) == -1 ? w + 20 : sel.IndexOf(",", w) + 1;
            }
            if (w1 <= widthStr.Length && widthStr.Length != 0)
            {
                Grid.Columns[i].Width = System.Convert.ToInt32(widthStr.Substring(w1, (int)widthStr.IndexOf(",", w1) == -1 ? widthStr.Length - w1 : widthStr.IndexOf(",", w1) - w1));
                w1 = (int)widthStr.IndexOf(",", w1) == -1 ? w1 + 20 : widthStr.IndexOf(",", w1) + 1;
            }
        }
    }
    static DataGridViewColumn m_oColumn;
    public static void search(DataGridView UG, clsSearchInfo m_searchInfo)
    {
        try
        {
            DataGridViewRow oRow = UG.CurrentRow;
            int i = oRow.Index;
            if (oRow == null) { oRow = UG.Rows[i]; }

            if (m_searchInfo.searchDirection == SearchDirectionEnum.Down)
            {
                while (oRow != null)
                {
                    i++;
                    oRow = UG.Rows[i];
                    if (MatchTextDGV(UG, oRow, m_searchInfo))
                    {
                        UG.CurrentCell = oRow.Cells[0];
                        if (m_oColumn != null)
                        {
                            UG.CurrentCell = oRow.Cells[m_oColumn.Name];
                        }
                        return;
                    }
                }
            }

            else if (m_searchInfo.searchDirection == SearchDirectionEnum.Up)
            {
                while (oRow != null)
                {
                    i--;
                    oRow = UG.Rows[i];
                    if (MatchTextDGV(UG, oRow, m_searchInfo))
                        UG.CurrentCell = oRow.Cells[0];
                    if (m_oColumn != null)
                    {
                        UG.CurrentCell = oRow.Cells[m_oColumn.Name];
                    }
                    return;
                }
            }

            else if (m_searchInfo.searchDirection == SearchDirectionEnum.All)
            {
                while (oRow != null)
                {
                    i++;
                    if (i >= UG.Rows.Count) { break; }
                    oRow = UG.Rows[i];
                    if (MatchTextDGV(UG, oRow, m_searchInfo))
                    {
                        if (m_oColumn != null)
                        {
                            if (oRow.Cells[m_oColumn.Name].Visible) { UG.CurrentCell = oRow.Cells[m_oColumn.Name]; return; }
                        }

                    }
                }

                i = 0;
                oRow = UG.Rows[i];
                while (oRow != null)
                {
                    if (MatchTextDGV(UG, oRow, m_searchInfo))
                    {
                        if (m_oColumn != null)
                        {
                            UG.CurrentCell = oRow.Cells[m_oColumn.Name];
                        }
                        return;
                    }
                    i++;
                    if (i >= UG.Rows.Count) { MessageBox.Show("Поиск закончен!"); return; }
                    oRow = UG.Rows[i];
                }

            }
            //MessageBox.Show("Просмотрены все записи до конца. Искали: '" & m_searchInfo.searchString & "' , но не нашли.", "Infragistics UltraGrid", MessageBoxButtons.OK, MessageBoxIcon.None)
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static bool MatchTextDGV(DataGridView UG, DataGridViewRow oRow, clsSearchInfo m_searchInfo)
    {
        if (oRow == null) return false;

        string strColumnKey = m_searchInfo.lookIn;
        //DataGridViewColumn oCol;

        bool bSearchAllColumns = true;
        if (strColumnKey != null) { bSearchAllColumns = false; }

        if (bSearchAllColumns)
        {
            foreach (DataGridViewColumn oCol in UG.Columns)
            {
                if (oRow.Cells[oCol.Name].Value != null && oRow.Cells[oCol.Name].Visible)
                {
                    //MessageBox.Show(oRow.Cells[oCol.Name].Value.ToString());
                    if (Match(m_searchInfo.searchString, oRow.Cells[oCol.Name].Value.ToString(), m_searchInfo))
                    {
                        m_oColumn = oCol;
                        return true;
                    }
                }
            }
        }
        else
        {
            DataGridViewColumn oCol = UG.Columns[strColumnKey];
            if (oRow.Cells[oCol.Name].Value != null && oRow.Cells[oCol.Name].Visible)
            {
                if (Match(m_searchInfo.searchString, oRow.Cells[oCol.Name].Value.ToString(), m_searchInfo))
                {
                    m_oColumn = oCol;
                    return true;
                }
            }
        }
        return false;
    }

    private static bool Match(string userString, string cellValue, clsSearchInfo m_searchInfo)
    {
        //   If our search is case insensitive, make both strings uppercase
        if (!m_searchInfo.matchCase)
        {
            userString = userString.ToUpper();
            cellValue = cellValue.ToUpper();
        }

        //   If we are searching any part of the cell value...
        if (m_searchInfo.searchContent == SearchContentEnum.AnyPartOfField)
        {
            //   If the user string is larger than the cell value, it is by definition
            //   a mismatch, so return false
            if (userString.Length > cellValue.Length)
                return false;
            else if (userString.Length == cellValue.Length)
            {
                //   If the lengths are equal, the strings must be equal as well
                if (userString == cellValue)
                    return true;
                else
                    return false;
            }
            else
            {
                //   There is probably an easier way to do this
                for (int i = 0; i <= (cellValue.Length - userString.Length); i++)
                {
                    if (userString == cellValue.Substring(i, userString.Length))
                        return true;
                }

                return false;

            }
        }
        else if (m_searchInfo.searchContent == SearchContentEnum.WholeField)
        {
            if (userString == cellValue)
                return true;
            else
                return false;
        }
        else if (m_searchInfo.searchContent == SearchContentEnum.StartOfField)
        {
            if (userString.Length >= cellValue.Length)
            {
                if (userString.Substring(0, cellValue.Length) == cellValue)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cellValue.Substring(0, userString.Length) == userString)
                    return true;
                else
                    return false;
            }

        }

        return false;

    }
    public static bool InF3(int idf2)
    {
        bool InF3 = false;
        my.sc.CommandText = "select 1 from v_F2VzjatVF3 where idf2=" + idf2;
        my.cn.Open();
        if (sc.ExecuteScalar() != null) InF3 = true;
        cn.Close();
        return InF3;
    }
    public static string  ExeScalar(string str)
    {
        string ExeScalar = "";
        my.sc.CommandText = str;
        if (my.cn.State != ConnectionState.Open)        my.cn.Open();
        var str1 = sc.ExecuteScalar();
        if (str1 != null) ExeScalar =str1.ToString();
            cn.Close();
        return ExeScalar;
    }
    public static string ExeScalar(string str, SqlConnection cn)
    {
        SqlCommand sc = new SqlCommand();
        sc.Connection = cn;
        string ExeScalar = "";
        sc.CommandText = str;
        cn.Open();
        var str1 = sc.ExecuteScalar();
        if (str1 != null) ExeScalar = str1.ToString();
        cn.Close();
        return ExeScalar;
    }
    public static bool FromSmP(int idf2)
    {
        bool FromSmP = false;
        my.sc.CommandText = "SELECT    1 FROM         dbo.Forma2 AS Forma2_1 INNER JOIN   sm_prog.dbo.Акты ON Forma2_1.KodUnic = sm_prog.dbo.Акты.КодВsdo WHERE     Forma2_1.IdF2 = " + idf2;
        my.cn.Open();
        if (sc.ExecuteScalar() != null) FromSmP = true;
        cn.Close();
        return FromSmP;
    }
    // IsNumeric Function
    public static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
        bool isNum;

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, true is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        if (Expression == null || Expression.ToString().Contains(",")) { isNum = false; }
        return isNum;
    }
    public static void Up(SqlDataAdapter da, DataTable dt)
    {

        try
        {
            if (da == null) return;
            da.Update(dt);
            dt.AcceptChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка cохранения! " + ex.Message);
            try
            {
                dt.RejectChanges();

            }
            catch (Exception ex1)
            {
                MessageBox.Show("Ошибка cохранения! " + ex1.Message);
                //throw;
            }
            //throw;
        }
    }
    public static void GetData(string selectCommand, BindingSource biSour)
    {
        try
        {

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, my.sconn);

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            biSour.DataSource = table;

        }
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }


    public static void v_excel(SMRC.DGVt dgv1)
    {
       // if (dgv1.GetClipboardContent() == null || !Clipboard.ContainsText()) return;
        //if (dgv1.GetClipboardContent() == null ) return;
        if (dgv1.RowCount == 0) return;
        dgv1.SelectAll();
        dgv1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        Clipboard.SetDataObject(dgv1.GetClipboardContent());
        Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();
        
        Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
        //WrkBk = null;
        //ExlApp.Quit(); ExlApp = null; GC.Collect(); return;
        Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
        WrkSht.Cells.NumberFormat = "@";
        WrkSht.Cells.ColumnWidth = 20;
        WrkSht.Cells.WrapText = true;
        ExlApp.Visible = true;
        WrkSht.get_Range("A1", "A1").Select();
        //WrkSht.PasteSpecial("Текст", false, false, null, null, null);  // , null --2k3
        if (Clipboard.ContainsText()) { WrkSht.PasteSpecial("Текст", false, false, null, null, null, null); }

        object m_objOpt = System.Reflection.Missing.Value;
        //if (dgv1.GetClipboardContent() == null) return;
        //dgv1.CurrentCell = dgv1.FirstDisplayedCell;
        //dgv1.SelectAll();
        //dgv1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        //Clipboard.SetDataObject(dgv1.GetClipboardContent());
        //Microsoft.Office.Interop.Excel.Workbook WrkBk; Microsoft.Office.Interop.Excel.Worksheet WrkSht;
        //Microsoft.Office.Interop.Excel.Application ExlDb = new Microsoft.Office.Interop.Excel.Application();
        //WrkBk = ExlDb.Workbooks.Add(m_objOpt);
        //WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
        //WrkSht.get_Range("A1", m_objOpt).Select();
        //
        //((Microsoft.Office.Interop.Excel.Range)ExlDb.Selection).ColumnWidth = 20;
        //((Microsoft.Office.Interop.Excel.Range)ExlDb.Selection).WrapText = true;

        //Int32 i = 0;
        //for (Int32 iCol = 1; iCol <= dgv1.Columns.Count; iCol++)
        //{
        //    if (!dgv1.Columns[iCol - 1].Visible)
        //    {

        //        ((Microsoft.Office.Interop.Excel.Range)WrkSht.Columns[iCol + i, m_objOpt]).Delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft);
        //        i = i - 1;
        //    }
        //}
        WrkSht.get_Range("A1", "A1").Select();
        ExlApp.Visible = true;
        WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
        ExlApp = null; GC.Collect();
      

    }
    public static void naimSp(String sel, ListBox List)
    {
        int w = 1;
        for (int i = 0; i <= 1000; i++)
        {
            if (w <= sel.Length)
            {
                string s1 = sel.Substring(w, (int)(((int)sel.IndexOf(",", w) == -1 ? w + 20 : (int)sel.IndexOf(",", w))) - w);
                s1 = (s1 == "0" ? "" : s1).ToString().Trim();
                List.Items.Add(s1);
                w = 1 + (int)(((int)sel.IndexOf(",", w) == -1 ? w + 20 : (int)sel.IndexOf(",", w)));
            }
            else
            { return; }

        }
    }
    public static string Shapka(String StrId,int identpr) 
    {
        my.sc.CommandText = "exec F2_IspGroupNew '" + StrId + "'," + my.Upred ;
        if (my.cn.State != ConnectionState.Open) { my.cn.Open(); }
        SqlDataReader dr = my.sc.ExecuteReader();
        string Shapka1 = "";
        string sh = ""; 
        while (dr.Read())
        {
            if (sh == "") { sh = dr["shifr"].ToString(); }
            if (dr["Isp"] != DBNull.Value)
            { Shapka1 = Shapka1 + "." + dr["Pred"].ToString(); }
    }
        dr.Close();
        cn.Close();
        my.MyStr[3] = Shapka1;
        my.SzapN = sh;
    return Shapka1 + sh;
    }
    public static string Tbl2Str(String s )
    {
my.sc.CommandText = s;
        my.cn.Open();
        SqlDataReader dr = my.sc.ExecuteReader();
        string Tbl2Str1 = "";
        while (dr.Read())
        {
            if (dr[0] != DBNull.Value)
            { Tbl2Str1 = Tbl2Str1  + dr[0].ToString()+ ","; }
    }
        dr.Close();
        cn.Close();
    if (Tbl2Str1 != "") {Tbl2Str1 = Tbl2Str1.Substring(0, Tbl2Str1.Length - 1) ;}
    return Tbl2Str1;

}
    public static void LoadTreeView(DataSet ds, TreeView treeView1, string namegroup, string idparent, string idgr, long gruser)
    {
        treeView1.Nodes.Clear();
        Dictionary<int, TreeNode> id2node = new Dictionary<int, TreeNode>();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            var node = new TreeNode();
            node.Text = ds.Tables[0].Rows[i][namegroup].ToString();
            node.Tag = ds.Tables[0].Rows[i][idparent].ToString();

           if ((int)ds.Tables[0].Rows[i][idgr] == gruser) { treeView1.SelectedNode = node; node.Expand(); node.BackColor = System.Drawing.Color.Cornsilk; }

            id2node.Add(Convert.ToInt32(ds.Tables[0].Rows[i][idgr]), node);
        }

        foreach (var node in id2node.Values)
        {
            TreeNode parent = null;
            if (id2node.TryGetValue(Convert.ToInt32(node.Tag), out parent))
            {
                parent.Nodes.Add(node);
            }
            else
            {
                treeView1.Nodes.Add(node);
            }
        }

    }

    public static DataSet PDataset(string select_statement)
    {

        //my.cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(select_statement, my.cn);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        //my.cn.Close();
        return ds;
    }
    public static void tvinit(bool vc, string str, string Cap, TreeView Tv, bool ImLst, long gruser, string NameCol)
    {
        Console.Write("TvinitStart " + DateTime.Now.TimeOfDay.ToString() + "\n");
        TreeNode n; DataSet ds = new DataSet(); DataView dv = new DataView();
        SqlDataAdapter da = new SqlDataAdapter(str, sconn);

        da.Fill(ds);
        dv.Table = ds.Tables[0];
        dv.Sort = dv.Table.Columns[1].ColumnName;
        if (dv.Count == 0)
        {
            n = Tv.Nodes.Add("0", Cap);
            n.Tag = 0;
        }
        else
        {
            if (Cap == "") { Cap = dv.Table.Rows[0]["Nomer"].ToString(); }
            n = Tv.Nodes.Add(dv[0][1].ToString(), Cap);
            n.Tag = dv[0][1].ToString();
            dv.RowFilter = "[" + dv.Table.Columns[1].ColumnName.ToString() + "] = " + dv[0][1].ToString();
            dv.Sort = "OrderNom";
            n = RecTV(dv[0][1].ToString(), n, dv, NameCol, vc, gruser);
            if (n != null) { Tv.SelectedNode = n; n.Expand(); n.BackColor = System.Drawing.Color.Cornsilk; } else { Tv.SelectedNode = Tv.Nodes[0]; Tv.Nodes[0].Expand(); }
        }
        dv.Dispose();
        ds.Dispose();
        Console.Write("TvinitFinish " + DateTime.Now.TimeOfDay.ToString() + "\n");
        //dv = null
        //ds = null
        //Debug.Print("tvinit10 " & Now.TimeOfDay.ToString);
    }
    private static TreeNode RecTV(String Parent, TreeNode currentNode, DataView dv, String NameCol, Boolean vc, long gruser)
    {
        TreeNode ND = null; TreeNode ND1 = null; TreeNode RecTV1 = null;
        try
        {
            NameCol = (NameCol == "" ? dv.Table.Columns[1].ColumnName.ToString() : NameCol);
            dv.RowFilter = "[" + NameCol + "] = " + Parent;
            String s;
            String parentnew = "-100";
            int iall = dv.Count - 1;
            for (int i = 0; i <= iall; i++)
            {
                //Console.Write("RowFilter Start " + DateTime.Now.TimeOfDay.ToString() + "\n");
                dv.RowFilter = "[" + NameCol + "] = " + Parent;
                //Console.Write("RowFilter Finish " + DateTime.Now.TimeOfDay.ToString() + "\n");
                //Dim ND As 
                //Dim ND1 As TreeNode
                if (dv[i][4] == DBNull.Value || parentnew != dv[i][0].ToString())
                {
                    s = (vc ? dv[i][0].ToString() + "  " + ((string)dv[i][2]).Trim() : ((string)dv[i][2]).Trim());
                    parentnew = dv[i][0].ToString();
                    ND = currentNode.Nodes.Add(s);
                    ND.Tag = parentnew;
                    if (ND.Tag.ToString() == gruser.ToString()) { RecTV1 = ND; }

                    if (dv[i][5] != DBNull.Value)
                    {
                        if ((int)dv[i][5] == Id_us) { if (gruser == 0) { RecTV1 = ND; } }
                    }
                    if (dv.Table.Select("[" + NameCol + "] = " + parentnew).Length > 0) { ND1 = RecTV(parentnew, ND, dv, NameCol, vc, gruser); }
                    if (ND1 != null) { RecTV1 = ND1; }
                }
                else
                {
                    if (dv[i][5] != DBNull.Value)
                    {
                        if ((int)dv[i][5] == Id_us) { if (gruser == 0) { RecTV1 = ND; } }
                    }
                }
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message); }
        return RecTV1;

    }
    public static void WrStream(string str,string path)
    {
        String hd = str;

        System.IO.StreamWriter sw = null;
        System.IO.StreamReader sr = null;
        if (!System.IO.File.Exists(path))
        { System.IO.FileStream fs = System.IO.File.Create(path); fs.Close(); }



        sr = System.IO.File.OpenText(path);

        String MyContents = sr.ReadToEnd();
        sr.Close();


        if (MyContents.Contains(str) == false)
        {

            sw = new System.IO.StreamWriter(path, true);



            String sTemp = str.Trim();

            if (sTemp.Length > 0)
            {

                sw.WriteLine(sTemp);

            }

            sw.Flush();

            sw.Close();

        }
        

    }
  
    public static void RdStream(TextBox NM, string path)
    {
        System.IO.StreamReader sr = null;

        AutoCompleteStringCollection data = new AutoCompleteStringCollection();
        if (!System.IO.File.Exists(path))
        { System.IO.FileStream fs = System.IO.File.Create(path); fs.Close(); }


        sr = System.IO.File.OpenText(path);

        while (!sr.EndOfStream)

        { data.Add(sr.ReadLine()); }



        sr.Close();

        NM.AutoCompleteCustomSource = data;

        NM.AutoCompleteSource = AutoCompleteSource.CustomSource;

        NM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    }
    public static void ObnPeriod(ComboBox d, RadioButton rb2)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Period", typeof(DateTime));
        dt.Columns.Add("PeriodStr", typeof(String));
        DataSet ObnPer = new DataSet();
        ObnPer.Tables.Add(dt);
        DateTime d1 = DateTime.Today.AddMonths(-24 - DateTime.Today.Month + 1 ).AddDays(-DateTime.Today.Day + 1);
        if (rb2.Checked)
        {
            while (d1 <= DateTime.Today.AddMonths(12))
            {
                DataRow row = dt.NewRow();
                row["Period"] = d1;
                row["PeriodStr"] = d1.ToString("MMMM").ToLower() + " " + d1.ToString("yyyy").ToLower().ToLower() + " г.";
                dt.Rows.Add(row);
                d1 = d1.AddMonths(1);
            }
        }
        else
        {
            while (d1 <= DateTime.Today.AddMonths(12))
            {
                DataRow row = dt.NewRow();
                row["Period"] = d1;
                row["PeriodStr"] = "Квартал " + ((d1.Month + 2) / 3).ToString() + " " + d1.ToString("yyyy").ToLower().ToLower() + " г.";
                dt.Rows.Add(row);
                d1 = d1.AddMonths(3);
            }
        }
        d.DataSource = dt;
        d.ValueMember = dt.Columns[0].ColumnName;
        d.DisplayMember = dt.Columns[1].ColumnName;
        //return ObnPer;
    }

    //internal static int Val(object p)
    //{
    //    throw new NotImplementedException();
    //}
    public static int Val(string value)
    {
        if (value == null) return 0;
        string returnVal = string.Empty;

        int tryInt = 0;

        MatchCollection collection = Regex.Matches(value.Trim(), "^\\d+");

        foreach (Match match in collection)
        {

            returnVal += match.ToString();

        }


        int.TryParse(returnVal, out tryInt);

        return tryInt;

    }

    public static bool KontrolA0()
    {
        bool tempKontrolA0 = false;
        DateTime d1 = new DateTime(2010, 4, 22) ;
        if (DateTime.Today < d1)
        {
            tempKontrolA0 = true;
        }
        else
        {
            tempKontrolA0 = false;
        }

        if (UserInGroup(my.Id_us, 56)) tempKontrolA0 = true;

        return tempKontrolA0;
    }

    public static bool KontrolUpr(System.DateTime d1, int identpr, int vid)
    {

        DateTime d2 = new DateTime( System.Convert.ToDateTime(DateTime.Today).AddMonths(1).Year,d1.AddMonths(1).Month,7) ;
        DateTime d3 = new DateTime(System.Convert.ToDateTime(DateTime.Today).Year, d1.AddMonths(-1).Month, 1);

        if (UserInGroup(my.Id_us, 235)) d2 = new DateTime(System.Convert.ToDateTime(DateTime.Today).AddMonths(1).Year, d1.AddMonths(1).Month, 10);

        if (System.DateTime.Today <= d2)
        {
            return true;
        }

        if (!UserInGroup(my.Id_us,52))
        {
            MessageBox.Show ("После 7-го числа текущего месяца, данные в Управленческий учет СМР можно переносить или обновлять только после контроля  Начальника отдела Учета СМР", "Внимание!");
            return false;
        }
        return true;
    }

    public static bool KontrolSMR(System.DateTime d1, int identpr, int vid)
    {
        bool tempKontrolSMR = false;
        System.DateTime d2 = DateTime.MinValue;
        System.DateTime d3 = DateTime.MinValue;
        //if (!(cn.Execute("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = 55").EOF))
        if (UserInGroup(my.Id_us, 55))
        {
            MessageBox.Show("Сохранение невозможно! ", "Внимание!");
            return false;
        }
        d2 = new DateTime(d1.Year, d1.Month, 20); 
        d3 = new DateTime(d1.Year, d1.Month, 1);
        if ((identpr == 1 | identpr == 76 | identpr == 4) & vid == 2)
        {
            return true;
        }
        if ((DateTime.Today.AddMonths(-1) <= d2 & DateTime.Today.AddMonths(-1) >= d3) | (DateTime.Today <= d2.AddDays(15)))
        {
            return true;
        }
        //if (cn.Execute("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = 49").EOF)
        if (!UserInGroup(my.Id_us,49))
        {
            MessageBox.Show("После 20-го числа текущего месяца, данные в программе можно изменить только по служебной записке предоставленной " + '\n' + "Дешкевич И.С. ", "Внимание!");
            return false;
        }
        //frmPWD.Show 1;
        //if (Nbut == 1)
        //{
            tempKontrolSMR = true;
        //}
        //else
        //{
        //    tempKontrolSMR = false;
        //}
        return tempKontrolSMR;
    }
    public static bool UserInGroup(int Id_us, int id_group)
    {
        bool isDostup = false;
        my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = " + id_group;
        if (my.cn.State != ConnectionState.Open)            my.cn.Open();
        if (sc.ExecuteScalar() != null) isDostup = true;
        cn.Close();
        return isDostup;
    }
    public static void MySpisok(int nbut1, string Szap1, Form fr, SMRC.DGVt UG)
    {
        DataSet ds = new DataSet(); DataView dv = new DataView();
        string str = my.FilterSel(nbut1, null, my.sconn, Szap1);
        SqlDataAdapter da = new SqlDataAdapter(str, sconn);

        ds.Clear();
        da.Fill(ds);

        UG.DataSource = ds.Tables[0];
        UG.AllowUserToAddRows = false;
        my.naimDG(my.headStr, UG, my.widthStr);

    }

}

