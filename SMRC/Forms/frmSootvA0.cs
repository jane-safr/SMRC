using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Office = Microsoft.Office.Core;  
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;  
 

//using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;

namespace SMRC.Forms
{
    public partial class frmSootvA0 : Form
    {clsSearchInfo m_searchInfo = new clsSearchInfo();
    DataSet dsRep;
        public frmSootvA0()
        {
            InitializeComponent();
        }

        private void frmSootvA0_Load(object sender, EventArgs e)
        {
            
            ObnProj();
            my.FillDC(idComplex, 43, " ");
            my.FillDC(idComplex1, 43, " ");
            my.FillDC(idProj, 47, " ");
            idProj.SelectedValue = 343;
            my.FillDC(idOsr, 44, " and idcomplex = " + idComplex1.SelectedValue.ToString());
            //ObnSm();
            WindowState = FormWindowState.Maximized;
            d1.Value =DateTime.Today.AddMonths(-1);
            d2.Value = DateTime.Today.AddMonths(-1);
            Login.Text = my.Login.ToString();
            MM.Text = DateTime.Today.Month.ToString();
        }

        private void ObnSm()
        {
            string s = my.FilterSel(193, this, my.sconn, checkBox1.Checked ? " and idcomplex = " + idComplex1.SelectedValue.ToString() : " and idOSR = " + idOsr.SelectedValue.ToString());
            DataSet dsStPred
                = new DataSet();
            SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
            
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvSm.DataSource = dsStPred.Tables[0];
            DgvSm.AllowUserToAddRows = false;
            DgvSm.AllowUserToDeleteRows = false;
            DgvSm.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvSm, my.widthStr);
            DataView dv = new DataView();
            dv.Table = dsStPred.Tables[0];
            dv.RowFilter = " PZ = 0";
            lSm.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();
            lSm.Text = lSm.Text + ", из них пустых: " + dv.Count.ToString();

            s = my.FilterSel(194, this, my.sconn, checkBox1.Checked ? " and Sprav.dbo.tSmeti.idosr in (SELECT     Sprav.dbo.tsOSR.idOSR FROM         Sprav.dbo.tComplexChapter INNER JOIN  Sprav.dbo.tsOSR ON Sprav.dbo.tComplexChapter.idComplexChapter = Sprav.dbo.tsOSR.idComplexChapter WHERE     Sprav.dbo.tComplexChapter.idComplex = " + idComplex1.SelectedValue.ToString() + ")" : " and  Sprav.dbo.tSmeti.IdOsr = " + idOsr.SelectedValue.ToString());
            dsStPred = new DataSet();
            
            daStPred = new SqlDataAdapter(s, my.sconn);
            daStPred.SelectCommand.CommandTimeout = 3000000;
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvSmSMR.DataSource = dsStPred.Tables[0];
            DgvSmSMR.AllowUserToAddRows = false;
            DgvSmSMR.AllowUserToDeleteRows = false;
            DgvSmSMR.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvSmSMR.Sort(DgvSmSMR.Columns["ndoc"], ListSortDirection.Ascending);
            my.naimDG(my.headStr, DgvSmSMR, my.widthStr);
            lSmSMR.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

            s = my.FilterSel(195, this, my.sconn, checkBox1.Checked ? " and dbo.vA0OSR.idcomplex = " + idComplex1.SelectedValue.ToString() : " and  dbo.vA0OSR.idOSR = " + idOsr.SelectedValue.ToString());
            dsStPred = new DataSet();
            daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvSmA0.DataSource = dsStPred.Tables[0];
            DgvSmA0.AllowUserToAddRows = false;
            DgvSmA0.AllowUserToDeleteRows = false;
            DgvSmA0.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvSmA0.Sort(DgvSmA0.Columns["shifr"], ListSortDirection.Ascending);
            my.naimDG(my.headStr, DgvSmA0, my.widthStr);
            lSmA0.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();
        }

        private void ObnOSR()
        {
            string s = my.FilterSel(190, this, my.sconn, " and idComplex = " + idComplex.SelectedValue.ToString());
            DataSet dsStPred = new DataSet();
            SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvOSR.DataSource = dsStPred.Tables[0];
            DgvOSR.AllowUserToAddRows = false;
            DgvOSR.AllowUserToDeleteRows = false;
            DgvOSR.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvOSR, my.widthStr);
            lOSR.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

            s = my.FilterSel(191, this, my.sconn, " and  Sprav.dbo.tComplexChapter.idComplex = " + idComplex.SelectedValue.ToString());
            dsStPred = new DataSet();
            daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvOSRSMR.DataSource = dsStPred.Tables[0];
            DgvOSRSMR.AllowUserToAddRows = false;
            DgvOSRSMR.AllowUserToDeleteRows = false;
            DgvOSRSMR.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvOSRSMR, my.widthStr);
            lOSRSMR.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

            s = my.FilterSel(192, this, my.sconn, " and  dbo.vA0Proj.idComplex = " + idComplex.SelectedValue.ToString());
            dsStPred = new DataSet();
            daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvOSRA0.DataSource = dsStPred.Tables[0];
            DgvOSRA0.AllowUserToAddRows = false;
            DgvOSRA0.AllowUserToDeleteRows = false;
            DgvOSRA0.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvOSRA0, my.widthStr);
            lOSRA0.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();
        }

        private void ObnProj()
        {
            string s = my.FilterSel(187, this, my.sconn, "");
            DataSet dsStPred = new DataSet();
            SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvProj.DataSource = dsStPred.Tables[0];
            DgvProj.AllowUserToAddRows = false;
            DgvProj.AllowUserToDeleteRows = false;
            DgvProj.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvProj, my.widthStr);
            lProj.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

             s = my.FilterSel(188, this, my.sconn, "");
             dsStPred = new DataSet();
             daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvProjSMR.DataSource = dsStPred.Tables[0];
            DgvProjSMR.AllowUserToAddRows = false;
            DgvProjSMR.AllowUserToDeleteRows = false;
            DgvProjSMR.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvProjSMR, my.widthStr);
            lProjSMR.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

            s = my.FilterSel(189, this, my.sconn, "");
            dsStPred = new DataSet();
            daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            DgvProjA0.DataSource = dsStPred.Tables[0];
            DgvProjA0.AllowUserToAddRows = false;
            DgvProjA0.AllowUserToDeleteRows = false;
            DgvProjA0.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvProjA0, my.widthStr);
            lProjA0.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите связать проекты " + DgvProjSMR.CurrentRow.Cells["NMComplex"].Value.ToString() + " и " + DgvProjA0.CurrentRow.Cells["ProjName"].Value.ToString() + "?","Внимание!",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                my.sc.CommandText = "exec sA0Sootv " + DgvProjSMR.CurrentRow.Cells["IdComplex"].Value.ToString() + "," + DgvProjA0.CurrentRow.Cells["ProjId"].Value.ToString();
                my.sc.ExecuteScalar();
                my.cn.Close();
                ObnProj(); 
            }
        }

        private void idComplex_SelectedValueChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idComplex.SelectedValue.ToString()))
            {
                 ObnOSR();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите связать ОСР " + DgvOSRSMR.CurrentRow.Cells["NMOSR"].Value.ToString() + " и " + DgvOSRA0.CurrentRow.Cells["OSName"].Value.ToString() + "?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                my.sc.CommandText = "exec sA0Sootv " + DgvOSRSMR.CurrentRow.Cells["IdOSR"].Value.ToString() + "," + idComplex.SelectedValue.ToString() + "," + DgvOSRA0.CurrentRow.Cells["OSTitleID"].Value.ToString() + ",0,1";
                my.sc.ExecuteScalar();
                my.cn.Close();
                ObnOSR();
            }
        }

        private void idOsr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idOsr.SelectedValue.ToString()))
            {
               // ObnSm();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите связать смету " + DgvSmSMR.CurrentRow.Cells["nomer"].Value.ToString() + " и " + DgvSmA0.CurrentRow.Cells["Shifr"].Value.ToString() + "?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                my.sc.CommandText = "exec sA0Sootv " + DgvSmSMR.CurrentRow.Cells["IdSm"].Value.ToString() + ",0," + idOsr.SelectedValue.ToString() + "," + DgvSmA0.CurrentRow.Cells["LSTitleID"].Value.ToString() + ",2";
                my.sc.ExecuteScalar();
                my.cn.Close();
                ObnSm();
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

   
            string s = my.FilterSel(199, this, my.sconn, "");
            my.sc.CommandText = s;
            my.cn.Open();
            SqlDataReader sd = my.sc.ExecuteReader();
            sd.Read();
            s = "Всего смет в А0 (за исключением Черновиков смет) - " + sd["CountAll"].ToString() + @".
" + "Заполнены локальные и инвентарные номера - " + sd["CountA0"].ToString() + @". Связанных с Учетом СМР - " + sd["CountAllSv"].ToString() + @". "; label11.Text = s;
            if (sd["CountNotSmr"].ToString() != "0") label6.Text = "Неточно введенных - " + sd["CountNotSmr"].ToString() + ".";
            sd.Close();
            my.cn.Close();
            
            //DataSet dsStPred = new DataSet();
            //SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
            int ind = 196;
            if (((System.Windows.Forms.Button)sender).Name == "bDist") { ind = 197; }
            if (((System.Windows.Forms.Button)sender).Name == "bNotSmr") {  ind = 198;}
            s = my.FilterSel(ind, this, my.sconn, "");
            DataSet dsStPred = new DataSet();
            SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            DgvDoubl.DataSource = null;
            daStPred.Fill(dsStPred);
            DgvDoubl.DataSource = dsStPred.Tables[0];
            DgvDoubl.AllowUserToAddRows = false;
            DgvDoubl.AllowUserToDeleteRows = false;
            DgvDoubl.EditMode = DataGridViewEditMode.EditProgrammatically;
            my.naimDG(my.headStr, DgvDoubl, my.widthStr);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ObnProj();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ObnOSR();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ObnSm();
        }

        private void idComplex1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idComplex1.SelectedValue.ToString()))
            {
                my.FillDC(idOsr, 44, " and idcomplex = " + idComplex1.SelectedValue.ToString());
                //MessageBox.Show(idOsr.SelectedValue.ToString() + ' ' + idOsr.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            idOsr.Enabled = !checkBox1.Checked;
            label4.Enabled = !checkBox1.Checked;
            button3.Enabled = !checkBox1.Checked;
            ObnSm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = "exec RemRecChern";
            my.sc.CommandText = s;
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            button5_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = textBox1.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            if (DgvSmSMR.CurrentRow == null) ObnSm();
            my.search(DgvSmSMR, m_searchInfo);
            DgvSmSMR.CurrentRow.Selected = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            m_searchInfo.searchString = textBox1.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            if (DgvSmA0.CurrentRow == null) ObnSm();
            my.search(DgvSmA0, m_searchInfo);
            DgvSmA0.CurrentRow.Selected = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ////checkBox2.Checked = false;
            ////checkBox4.Checked = !checkBox4.Checked;
            d1.Enabled = checkBox4.Checked;
            d2.Enabled = checkBox2.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ////checkBox4.Checked = false;
            ////checkBox2.Checked = !checkBox2.Checked;
            d2.Enabled = checkBox2.Checked;
            d1.Enabled = checkBox4.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            idProj.Enabled = checkBox3.Checked;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {



            string s = "set language 'русский' exec sA0Podtv " + (d1.Enabled ? "'" + d1.Value.ToString() + "'" : "NULL") + "," + (d2.Enabled ? "'" + d2.Value.ToString() + "'" : "NULL") + "," + (checkBox3.Checked ? idProj.SelectedValue.ToString(): "0");
                DataSet dsStPred = new DataSet();
                SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
                dsStPred.Clear();
                DgvRazn.DataSource = null;
                daStPred.Fill(dsStPred);
                DgvRazn.DataSource = dsStPred.Tables[0];
                DgvRazn.AllowUserToAddRows = false;
                DgvRazn.AllowUserToDeleteRows = false;
                DgvRazn.EditMode = DataGridViewEditMode.EditProgrammatically;
                lRazn.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();
                //my.naimDG(my.headStr, DgvRazn, my.widthStr);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            my.v_excel(DgvRazn);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            my.v_excel(DgvProj);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                string s = my.FilterSel(218, this, my.sconn, " and Comment like '%" + Login.Text +"_"+ MM.Text + "%'"  );
                dsRep = new DataSet();
                SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
                dsRep.Clear();
                DgvRep.DataSource = null;
                daStPred.Fill(dsRep);
                DgvRep.DataSource = dsRep.Tables[0];
                DgvRep.AllowUserToAddRows = false;
                DgvRep.AllowUserToDeleteRows = false;
                DgvRep.EditMode = DataGridViewEditMode.EditProgrammatically;
                my.naimDG(my.headStr, DgvRep, my.widthStr);

                lRep.Text = "Всего: " + dsRep.Tables[0].Rows.Count.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
             button13_Click(null,null);
            DataView dv = new DataView();
            dv.Table = dsRep.Tables[0];
            if (DgvRep.RowCount == 0) return;

            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty, null, xlapp1, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\Отчет по занесению смет.xlt";
            //Пробуем открыть книгу
            //Application xlapp = (Application)xlapp1;
            Microsoft.Office.Interop.Excel.Workbook WrkBk = (Microsoft.Office.Interop.Excel.Workbook)workbooks.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, workbooks, args);
            Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.Sheets["Отчет"];
            Microsoft.Office.Interop.Excel.Application ExlApp;
            ExlApp = (Microsoft.Office.Interop.Excel.Application)xlapp1;

            ExlApp.Visible = true;

            Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[2, 1];
            rngActive.Select();
            rngActive.get_Offset(-1, 1).Value2 =Login.Text.ToString();
            rngActive.get_Offset(0, 1).Value2 = "Отчет  по занесению смет по ПСС-4 в программу АО. C 22." + (Convert.ToInt16(MM.Text) < 11 ? "0" : "") + (Convert.ToInt16(MM.Text) - 1).ToString() + " - 20." + (Convert.ToInt16(MM.Text) < 10 ? "0" : "") + MM.Text.ToString();
            for (int i = 0; i < 38; i++)
            {
                if (i>= dv.Count)
                {
                    break;
                }
                rngActive.get_Offset(i + 3, 1).Value2 = dv[i][1];
                rngActive.get_Offset(i + 3, 2).Value2 = dv[i][2];
                rngActive.get_Offset(i + 3, 3).Value2 = dv[i][3];
            }

            for (int i = 38; i < 76; i++)
            {
                if (i >= dv.Count)
                {
                    break;
                }
                rngActive.get_Offset(i + 3-38, 1+4).Value2 = dv[i][1];
                rngActive.get_Offset(i + 3-38, 2+4).Value2 = dv[i][2];
                rngActive.get_Offset(i + 3-38, 3+4).Value2 = dv[i][3];
            }


            WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
            ExlApp = null; GC.Collect();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        //private void button13_Click(object sender, EventArgs e)
        //{
        //  //ModOffice.proba();
        //    //MyWPF.
        //}

        //private void button14_Click(object sender, EventArgs e)
        //{
        //    Microsoft.Office.Core.DiagramNode dgnRoot = null;
        //    Microsoft.Office.Core.Shape shpDiagram = null;
        //    Microsoft.Office.Core.DiagramNode dgnNext = null;
        //    int intCount = 0;
        //    //int slideId = Globals.ThisAddIn.Application.ActiveWindow.Selection.SlideRange.SlideID; 

        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbooks wbs = app.Workbooks;
        //    Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel.Worksheet ws = app.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

        //    //Add organization chart to current document
        //    //TODO: INSTANT C# TODO TASK: Instant C# could not resolve the named parameters in the following line:
        //    //ORIGINAL LINE: Set shpDiagram = ActiveSheet.Shapes.AddDiagram(Type:=msoDiagramOrgChart, Left:=10, Top:=15, Width:=400, Height:=475)
        //    shpDiagram = Microsoft.Office.Interop.Excel.Shapes.AddDiagram( Microsoft.Office.Core.MsoDiagramType.msoDiagramOrgChart, 10, 15, 400, 475);

        //    //Add three child nodes to organization chart
        //    dgnRoot = shpDiagram.DiagramNode.Children.AddNode(1, Microsoft.Office.Core.MsoDiagramNodeType.msoDiagramNode);

        //    for (intCount = 1; intCount <= 3; intCount++)
        //    {
        //        dgnRoot.Children.AddNode(1, Microsoft.Office.Core.MsoDiagramNodeType.msoDiagramNode);
        //    }

        //    //Access the node immediately following
        //    //the first diagram node
        //    dgnNext = dgnRoot.Children.Item(1).NextNode();

        //    //Add three child nodes to the node immediately
        //    //following the first diagram node
        //    for (intCount = 1; intCount <= 3; intCount++)
        //    {
        //        dgnNext.Children.AddNode(0, Microsoft.Office.Core.MsoDiagramNodeType.msoDiagramNode);
        //    }
        //    Microsoft.Office.Interop.Excel.Application app = new
        //Microsoft.Office.Interop.Excel.Application();
        //    app.Visible = false;
        //    Microsoft.Office.Interop.Excel.Workbooks wbs = app.Workbooks;
        //    Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(Type.Missing);

        //    Microsoft.Office.Interop.Excel.Range range = app.get_Range("A1", "C6");
        //    range.Value2 = new
        //object[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 }, { 4, 4, 4 }, { 5, 5, 5 }, { 6, 6, 6 } };
        //    Microsoft.Office.Interop.Excel.Worksheet ws = app.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

        //    Microsoft.Office.Interop.Excel.Shape shape =
        //ws.Shapes.AddChart(Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnClustered, Type.Missing,
        //Type.Missing, Type.Missing, Type.Missing) as Microsoft.Office.Interop.Excel.Shape;
        //    shape.Chart.SetSourceData(range, Type.Missing);
        //    shape.Chart.ChartArea.Copy();

        //    object missing = Type.Missing;
        //    object FALSE = false;
        //    object dataType = Word.WdPasteDataType.wdPasteOLEObject;
        //    object palcement = Word.WdOLEPlacement.wdInLine;

        //    this.Application.Selection.PasteSpecial(ref missing, ref FALSE,
        //ref palcement, ref FALSE,
        //        ref dataType, ref missing, ref missing);


        //}












    }
}
