using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;

namespace SMRC.Forms
{
    public partial class frmGrafikMatch : Form
    {
        DataView dv; DataView dv1; int mode; bool RemOsn = false; bool flDel = false; bool Dostup = false;
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        public frmGrafikMatch()
        {
            InitializeComponent();
        }

        private void frmGrafik_Load(object sender, EventArgs e)
        {
            //ObnGr();
                        if (Tag.ToString() == "83") mode = 1;
                        if (Tag.ToString() == "84") { mode = 2; groupBox2.Visible = false; }
            my.FillDC(idComplex, 43, " ");
            //my.FillDC(idInvPr, 66, " ");
            idComplex.SelectedValue = 32;
            my.FillDC(idEntpr, 72, " ");
            Dgv1.AllowUserToAddRows = false;
            //Dgv1.AllowUserToDeleteRows = false;

            Dgv2.AllowUserToAddRows = false;
            Dgv2.AllowUserToDeleteRows = false;

            my.sc.CommandText = " exec Grafik.dbo.sDostup  " + my.Id_us + ",0";
            my.cn.Open();
            Dostup =(bool)my.sc.ExecuteScalar();
            //if (!(my.sc.ExecuteScalar() == null)) { Dostup = true; } else { Dostup = false; }
             my.cn.Close();
            RdWr(Dostup);
           
            //{
            //    Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            //    Dgv1.AllowUserToDeleteRows = false;
            //    button13.Enabled = false;
            //    butfromOsn.Enabled = false;
            //    groupBox1.Enabled = false;
            //}
            //else
            //{ Dgv1.AllowUserToDeleteRows = true; }
            Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
            
            this.WindowState = FormWindowState.Maximized;

        }
        private void RdWr(bool  Dostup)
        {
            if (Dostup)
            {
                Dgv1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            }  
            else
            {
                Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;

            }
            Dgv1.AllowUserToDeleteRows = Dostup;
            button13.Enabled = Dostup;
            butfromOsn.Enabled = Dostup;
            groupBox1.Enabled = Dostup;
        }
        public void ObnGr()
        {
            if (Tag.ToString() == "83")
            {
                my.FillDC(NMGrafik, 63, "  and idgrafik = 0 or  ((mode = 0 or mode = 1 or mode = 3) and idcomplex =" + idComplex.SelectedValue.ToString() + ")");
                my.FillDC(NMGrafik1, 63, "  and idgrafik = 0 or  ((mode = 0 or mode = 1 or mode = 3) and idcomplex =" + idComplex.SelectedValue.ToString() + ")");
            }
            if (Tag.ToString() == "84")
            {
                my.FillDC(NMGrafik, 63, " and idgrafik = 0 or (mode = 2 and idcomplex =" + idComplex.SelectedValue.ToString() + ")");
                my.FillDC(NMGrafik1, 63, " and idgrafik = 0 or (mode = 2 and idcomplex =" + idComplex.SelectedValue.ToString() + ")");
            }
        }


        public void spisok(string szap, int mode2, string szap1)
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds1 = new DataSet();

                my.sc.CommandTimeout = 30000;
                sel = "exec Grafik.dbo.sGrafik '" + szap + "'," + mode2.ToString() + ",'" + szap1 + "','" + my.Login + "'," + mode.ToString() + "," + idEntpr.SelectedValue.ToString() + "," + idDep.SelectedValue.ToString();
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);
                
                ds1.Clear();
                Dgv1.DataSource = null;
                if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv1.DataSource = dv1;

                //my.cn.Open();
                    foreach (DataGridViewColumn col in Dgv1.Columns)
                    {
                        if (col.Name =="idtask")
                        {
                            col.Visible = false;
                        }
                        my.sc.CommandText = "select grafik.dbo.fNMCol('" + col.Name + "'," + mode.ToString() + ",0)";
                        col.HeaderText = my.sc.ExecuteScalar().ToString();
                    }
                    my.cn.Close();

                Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //Dgv1.Bounds.
                lCount.Text = "Всего: " + dv1.Count.ToString();
                Cursor = Cursors.Default;
                flDel = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        public void spisok1(string szap, int mode2, string szap1)
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();

                my.sc.CommandTimeout = 30000;

                sel = "exec Grafik.dbo.sGrafik '" + szap + "'," + mode2.ToString() + ",'" + szap1 + "','" + my.Login + "'," + mode.ToString();
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);
                ds.Clear();
                Dgv2.DataSource = null;
                da.Fill(ds);

                dv = new DataView();
                dv.Table = ds.Tables[0];
                Dgv2.DataSource = dv;
                //my.naimDG("0,ID работы," + (mode != 0 ? "," : "") + "Статус работы ," + (mode != 0 ? "," : "") + "Код WBS ," + (mode != 0 ? "," : "") + "Название работы ," + (mode != 0 ? "," : "") + "(*)Старт ," + (mode != 0 ? "," : "") + "(*)Старт по ЦП проекта ," + (mode != 0 ? "," : "") + "(*)Финиш ," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП проекта ," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП1 ," + (mode != 0 ? "," : "") + "Организация - исполнитель ," + (mode != 0 ? "," : "") + "1A Сметная стоимость (д/дог. 2009) ," + (mode != 0 ? "," : "") + "1A Сметы (д/дог 2009) ," + (mode != 0 ? "," : "") + "Сметы ," + (mode != 0 ? "," : "") + "1L № действующей сметы ," + (mode != 0 ? "," : "") + "1L Откорректированный доп 2010 ," + (mode != 0 ? "," : "") + "1АМ Сметы выданные в производство ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - ост.(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - по завершении(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - факт(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - ост.(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - по завершении(h) ," + (mode != 0 ? "," : "") + "FACT_TEST_Код документа ," + (mode != 0 ? "," : "") + "(*)План. общая стоимость(руб) ," + (mode != 0 ? "," : "") + "(*)План. стоим. по завершении (BAC)(руб) ," + (mode != 0 ? "," : "") + "(*)План. стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "ФО - план ," + (mode != 0 ? "," : "") + "Ед. изм. ," + (mode != 0 ? "," : "") + "ФО - остаток ," + (mode != 0 ? "," : "") + "ФО - по завершении ," + (mode != 0 ? "," : "") + "ФО - факт ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - ост.(руб) ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - по завершении(руб) ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - факт(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - общая стоимость(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - отклонение по общей стоимости(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП1 - стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП1 - общая стоимость(руб) ," + (mode != 0 ? "," : "") + "Delete This Row", Dgv2, "0,150");
                //my.naimDG("0,ID работы," + (mode != 0 ? "," : "") + "Статус работы ," + (mode != 0 ? "," : "") + "Статус работы (раб) ," + (mode != 0 ? "," : "") + "Планируемый Старт/Финиш (раб) ," + (mode != 0 ? "," : "") + "Код WBS ," + (mode != 0 ? "," : "") + "Название работы ," + (mode != 0 ? "," : "") + "(*)Старт ," + (mode != 0 ? "," : "") + "(*)Старт (раб) ," + (mode != 0 ? "," : "") + "(*)Старт по ЦП проекта ," + (mode != 0 ? "," : "") + "(*)Финиш ," + (mode != 0 ? "," : "") + "(*)Финиш (раб) ," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП проекта ," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП1 ," + (mode != 0 ? "," : "") + "Организация - исполнитель ," + (mode != 0 ? "," : "") + "1A Сметная стоимость (д/дог. 2009) ," + (mode != 0 ? "," : "") + "1A Сметы (д/дог 2009) ," + (mode != 0 ? "," : "") + "Сметы ," + (mode != 0 ? "," : "") + "1L № действующей сметы ," + (mode != 0 ? "," : "") + "1L Откорректированный доп 2010 ," + (mode != 0 ? "," : "") + "1АМ Сметы выданные в производство ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - ост.(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - по завершении(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - факт(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - ост.(h) ," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - по завершении(h) ," + (mode != 0 ? "," : "") + "FACT_TEST_Код документа ," + (mode != 0 ? "," : "") + "(*)План. общая стоимость(руб) ," + (mode != 0 ? "," : "") + "(*)План. стоим. по завершении (BAC)(руб) ," + (mode != 0 ? "," : "") + "(*)План. стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "ФО - план ," + (mode != 0 ? "," : "") + "ФО - план (раб) ," + (mode != 0 ? "," : "") + "Ед. изм. ," + (mode != 0 ? "," : "") + "ФО - остаток ," + (mode != 0 ? "," : "") + "ФО - остаток (раб) ," + (mode != 0 ? "," : "") + "ФО - по завершении ," + (mode != 0 ? "," : "") + "ФО - по завершении (раб) ," + (mode != 0 ? "," : "") + "ФО - факт ," + (mode != 0 ? "," : "") + "ФО - факт (раб) ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - ост.(руб) ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - по завершении(руб) ," + (mode != 0 ? "," : "") + "(*)Стоимость общая - факт(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - общая стоимость(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП - отклонение по общей стоимости(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП1 - стоимость нетруд. рес.(руб) ," + (mode != 0 ? "," : "") + "(*)ЦП1 - общая стоимость(руб) ," + (mode != 0 ? "," : "") + "Delete This Row", Dgv2, "0,150");
                //my.naimDG("0,ID работы," + (mode != 0 ? "," : "") + "Статус работы," + (mode != 0 ? "," : "") + "Статус работы (раб)," + (mode != 0 ? "," : "") + "Планируемый Старт/Финиш (раб)," + (mode != 0 ? "," : "") + "Код WBS," + (mode != 0 ? "," : "") + "Название работы," + (mode != 0 ? "," : "") + "(*)Старт," + (mode != 0 ? "," : "") + "(*)Старт (раб)," + (mode != 0 ? "," : "") + "(*)Старт по ЦП проекта," + (mode != 0 ? "," : "") + "(*)Финиш," + (mode != 0 ? "," : "") + "(*)Финиш (раб)," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП проекта," + (mode != 0 ? "," : "") + "(*)Финиш по ЦП1," + (mode != 0 ? "," : "") + "Организация - исполнитель," + (mode != 0 ? "," : "") + "1A Сметная стоимость (д/дог. 2009)," + (mode != 0 ? "," : "") + "1A Сметы (д/дог 2009)," + (mode != 0 ? "," : "") + "Сметы," + (mode != 0 ? "," : "") + "1L № действующей сметы," + (mode != 0 ? "," : "") + "1L Откорректированный доп 2010," + (mode != 0 ? "," : "") + "1АМ Сметы выданные в производство," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - ост.(h)," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - по завершении(h)," + (mode != 0 ? "," : "") + "(*)Кол-во нетруд. рес. - факт(h)," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - ост.(h)," + (mode != 0 ? "," : "") + "(*)Кол-во труд. рес. - по завершении(h)," + (mode != 0 ? "," : "") + "FACT_TEST_Код документа," + (mode != 0 ? "," : "") + "(*)План. общая стоимость(руб)," + (mode != 0 ? "," : "") + "(*)План. стоим. по завершении (BAC)(руб)," + (mode != 0 ? "," : "") + "(*)План. стоимость нетруд. рес.(руб)," + (mode != 0 ? "," : "") + "ФО - план," + (mode != 0 ? "," : "") + "ФО - план (раб)," + (mode != 0 ? "," : "") + "Ед. изм.," + (mode != 0 ? "," : "") + "ФО - остаток," + (mode != 0 ? "," : "") + "ФО - остаток (раб)," + (mode != 0 ? "," : "") + "ФО - по завершении," + (mode != 0 ? "," : "") + "ФО - по завершении (раб)," + (mode != 0 ? "," : "") + "ФО - факт," + (mode != 0 ? "," : "") + "ФО - факт (раб)," + (mode != 0 ? "," : "") + "(*)Стоимость общая - ост.(руб)," + (mode != 0 ? "," : "") + "(*)Стоимость общая - по завершении(руб)," + (mode != 0 ? "," : "") + "(*)Стоимость общая - факт(руб)," + (mode != 0 ? "," : "") + "(*)ЦП - стоимость нетруд. рес.(руб)," + (mode != 0 ? "," : "") + "(*)ЦП - общая стоимость(руб)," + (mode != 0 ? "," : "") + "(*)ЦП - отклонение по общей стоимости(руб)," + (mode != 0 ? "," : "") + "(*)ЦП1 - стоимость нетруд. рес.(руб)," + (mode != 0 ? "," : "") + "(*)ЦП1 - общая стоимость(руб)," + (mode != 0 ? "," : "") + "Delete This Row", Dgv2, "0,150");

                //DataSet dscol = new DataSet();
                //DataView dvv = new DataView();
                
                //da = new SqlDataAdapter("select tGrafik.mode FROM    tGrafik  WHERE     tGrafik.idGrafik = " + NMGrafik1.SelectedValue.ToString(), my.sconn);
                //da.Fill(dscol);
                //dvv.Table = dscol.Tables[0];
                //for (int i = 0; i < dscol.Tables[0].Columns.Count-1; i++)
                //{
                //my.cn.Open(); 
                //my.cn.Open();
                //my.sc.CommandText = "select mode FROM    Grafik.dbo.tGrafik  WHERE    idGrafik = " + NMGrafik1.SelectedValue.ToString();
                //byte mode1 = (byte)my.sc.ExecuteScalar();
                //my.cn.Close();
                try
                {

                foreach (DataGridViewColumn col in Dgv2.Columns)
                {
                    if (col.Name == "idtask")
                    {
                        col.Visible = false;
                    }

                    my.sc.CommandText = "select grafik.dbo.fNMCol('" + col.Name + "'," + mode.ToString() + ",0)";
                        col.HeaderText = my.sc.ExecuteScalar().ToString();

                    if (col.Name.Length > 2 && col.Name.Substring(0, 3) == "bit")
                    {
                        Dgv2.Columns[col.Name].Visible = false;
                    }
                }
               
                }
                catch (Exception)
                {

                }
                my.cn.Close();
                Dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                lCount1.Text = "Всего: " + dv.Count.ToString();
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        //private void remfromosn()
        //{
        //    //if (NMGrafik1.SelectedValue == null) return;

        //    //if (NMGrafik1.SelectedValue.ToString() == "1")
        //    //{
        //    //    butfromOsn.Enabled = true;
        //    //}
        //    //else
        //    //{ butfromOsn.Enabled = false; }
        //}
        private void NMGrafik_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (my.IsNumeric(NMGrafik.SelectedValue.ToString()))
                {
                    RemOsn = false;
                    //remfromosn();
                    
                    my.cn.Open();
                    my.sc.CommandText = "SELECT     Osnovnoi,mode,grafik.dbo.fOsnGr() as NMOsn FROM         grafik.dbo.tGrafik WHERE     idGrafik = " + NMGrafik.SelectedValue.ToString();
                     SqlDataReader DRd = my.sc.ExecuteReader();

                     DRd.Read();
                     {
                         chOsn.Checked = (bool)DRd["Osnovnoi"];
                         label5.Text = DRd["NMOsn"].ToString();
                         //byte m = (byte)DRd["mode"];
                         //if (m == 1) { rbAEP.Checked = true; mode = 1; }
                         //if (m == 3) { rbKT2.Checked = true; mode = 3; }
                     }
                     DRd.Close();
                    
                     my.sc.CommandText = " exec Grafik.dbo.sDostup  " + my.Id_us + "," + NMGrafik.SelectedValue;

                     //my.cn.Open();
                     Dostup = (bool)my.sc.ExecuteScalar();
                     //if (!(my.sc.ExecuteScalar() == null)) { Dostup = true; } else { Dostup = false; }
                     //my.cn.Close();
                     
                    my.cn.Close();
                    //spisok(NMGrafik.SelectedValue.ToString(), 0, "");
                    RdWr(Dostup);
                    RemOsn = true;
                    groupBox1.Enabled = Dostup;
                    //if (chOsn.Checked & mode != 3)
                    //{
                    //    groupBox1.Enabled = false;
                    //}
                    //else if (!chOsn.Checked & mode == 3)
                    //{
                    //    groupBox1.Enabled = false;
                    //}
                    //else
                    //{
                    //    groupBox1.Enabled = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }

        }

        private void NMGrafik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(NMGrafik1.SelectedValue.ToString()))
            {
                //remfromosn();
                spisok1(NMGrafik1.SelectedValue.ToString(), 0, "");
            }
        }
                        

        private void button1_Click(object sender, EventArgs e)
        {
            spisok(NMGrafik1.SelectedValue.ToString(), 1, NMGrafik.SelectedValue.ToString());
            colorRazl(Dgv1);
            spisok1(NMGrafik.SelectedValue.ToString(), 1, NMGrafik1.SelectedValue.ToString());
            //colorRazl(Dgv2);
        }
        private void colorRazl(DGVt dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Name.Substring(0, 3) == "bit")
                {
                    dgv.Columns[i].Visible = false;
                    for (int j = 0; j < dgv.RowCount; j++)
                    {

                        if (dgv[i, j].Value.ToString() == "1")
                        {
                            dgv[i - 1, j].Style.BackColor = Color.LightBlue;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button14_Click(Dgv1, dv1, "");
        }


        private void button14_Click(DGVt dgv, DataView dv, string sort)
        {

            //try
            //{

            if (Dgv1.RowCount == 0) return;
            if (sort != "")
            {
                dv.Sort = sort;
            }
            Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
            WrkSht.Cells.NumberFormat = "@";
            WrkSht.Cells.ColumnWidth = 20;
            WrkSht.Cells.WrapText = true;
            ExlApp.Visible = true;



            Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[3, 1];
            rngActive.Select();
            int iex = 0;

            rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[3, 1];
            for (int i = 0; i < dv.Table.Columns.Count; i++)
            {
                if (dgv.Columns[i].Name.Substring(0, 3) != "bit")
                {
                    rngActive.get_Offset(-2, iex).Value2 = dgv.Columns[i].Name;
                    if (dgv.Columns[i].Name != dgv.Columns[i].HeaderText) rngActive.get_Offset(-1, iex).Value2 = dgv.Columns[i].HeaderText;
                    if (dgv.Columns[i].Name.ToLower().Contains("date"))
                    {
                        WrkSht.get_Range(rngActive.get_Offset(0, iex), rngActive.get_Offset(dgv.RowCount, iex)).NumberFormat = "ДД.ММ.ГГГГ";
                    }
                }
                for (int j = 0; j < dv.Count; j++)
                {
                    if (dgv.Columns[i].Name.Substring(0, 3) != "bit")
                    { rngActive.get_Offset(j, iex).Value2 = dv[j][i].ToString(); }//dgv[i, j].Value; }
                    else
                    {
                        if (dv[j][i].ToString() == "1")
                        {
                            //rngActive.get_Offset(j , iex-1).Select();
                            rngActive.get_Offset(j, iex - 1).Interior.ColorIndex = 37;
                        }
                    }
                }


                if (dgv.Columns[i].Name.Substring(0, 3) != "bit") iex = iex + 1;

            }

            WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
            ExlApp = null; GC.Collect();
            //MessageBox.Show("Готово!");
            //}
            //catch (Exception ex)
            //{
            //    if ((int)my.cn.State == 1) { my.cn.Close(); }
            //    MessageBox.Show("Ошибка! " + ex.Message);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button14_Click(Dgv1, dv1, "idtask");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            dv.RowFilter = "task_code = '" + Dgv1.CurrentRow.Cells["task_code"].Value.ToString() + "'";
            colorRazl(Dgv2);
            }
            catch (Exception)
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dv.RowFilter = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            my.Pform = this;
            frmZagruzka fr = new frmZagruzka();
            if (Tag.ToString() == "83")fr.mode = 1;
            if (Tag.ToString() == "84") fr.mode = 2; 
            fr.Show();
            //fr.idComplex.SelectedValue = idComplex.SelectedValue;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            ObnGr();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                dv.RowFilter = "task_code = '" + Dgv1.CurrentRow.Cells["task_code"].Value.ToString() + "'";
                my.cn.Open();
                my.sc.CommandText = "exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '" + Dgv2[Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name, 0].Value.ToString() + "' ," + Dgv1.CurrentRow.Cells["idtask"].Value.ToString() +"," + NMGrafik1.SelectedValue.ToString();
                if (my.sc.ExecuteScalar().ToString() == "1")
                {
                    Dgv1.CurrentCell.Value = Dgv2[Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name, 0].Value.ToString();
                    Dgv1.CurrentCell.Style.BackColor = Color.LightBlue;
                }
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Sravn("user_field_7966");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Sravn("user_field_6678");
        }
        private void Sravn(string fl)
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();


                sel = "exec Grafik.dbo.sGrafikPr '" + NMGrafik.SelectedValue + "','" + fl + "'";
                SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
                ds.Clear();
                Dgv1.DataSource = null;
                if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds);

                dv1 = new DataView();
                dv1.Table = ds.Tables[0];
                Dgv1.DataSource = dv1;
                my.naimDG("0,ID работы,Статус работы ,Код WBS ,Название работы ,(*)Старт ,(*)Старт по ЦП проекта ,(*)Финиш ,(*)Финиш по ЦП проекта ,(*)Финиш по ЦП1 ,Организация - исполнитель ,1A Сметная стоимость (д/дог. 2009) ,1A Сметы (д/дог 2009) ,Сметы ,1L № действующей сметы ,1L Откорректированный доп 2010 ,1АМ Сметы выданные в производство ,(*)Кол-во нетруд. рес. - ост.(h) ,(*)Кол-во нетруд. рес. - по завершении(h) ,(*)Кол-во нетруд. рес. - факт(h) ,(*)Кол-во труд. рес. - ост.(h) ,(*)Кол-во труд. рес. - по завершении(h) ,FACT_TEST_Код документа ,(*)План. общая стоимость(руб) ,(*)План. стоим. по завершении (BAC)(руб) ,(*)План. стоимость нетруд. рес.(руб) ,ФО - план ,Ед. изм. ,ФО - остаток ,ФО - по завершении ,ФО - факт ,(*)Стоимость общая - ост.(руб) ,(*)Стоимость общая - по завершении(руб) ,(*)Стоимость общая - факт(руб) ,(*)ЦП - стоимость нетруд. рес.(руб) ,(*)ЦП - общая стоимость(руб) ,(*)ЦП - отклонение по общей стоимости(руб) ,(*)ЦП1 - стоимость нетруд. рес.(руб) ,(*)ЦП1 - общая стоимость(руб) ,Delete This Row", Dgv1, "");

                Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


                Dgv1.Columns["bitidArch"].Visible = false;
                for (int j = 0; j < Dgv1.RowCount; j++)
                {

                    if (Dgv1["bitidArch", j].Value.ToString() == "1")
                    {
                        Dgv1["task_code", j].Style.BackColor = Color.LightBlue;
                    }
                }


                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {

                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns[e.ColumnIndex].Name != "Smeta")
            {
                frmTask fr = new frmTask();
                fr.task_code = Dgv1.Rows[e.RowIndex].Cells["task_code"].Value.ToString();
                fr.idcomplex = (int)idComplex.SelectedValue;
                fr.ShowDialog();
            }
            else
            {
                frmSm fr = new frmSm();
                fr.NomerSm = Dgv1.Rows[e.RowIndex].Cells["Smeta"].Value.ToString();
                fr.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0) { return; }
            if (Dgv1.CurrentCell == null) { Dgv1.CurrentCell = Dgv1.FirstDisplayedCell; }
            m_searchInfo.searchString = TextBox1.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(Dgv1, m_searchInfo);
            //Dgv1.CurrentRow.Selected = true;
            Dgv1.CurrentCell.Selected = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            frmReports fr = new frmReports();
            fr.idcomplex = (int)idComplex.SelectedValue;
            //fr.MdiParent = my.MDIForm;

            fr.nm = NMGrafik.SelectedValue.ToString();
            fr.ShowDialog();
            //fr.WindowState = FormWindowState.Normal;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (chOsn.Checked)
            {
                MessageBox.Show ("Вы не можете удалить основной график!");
                return;
            }
            if (NMGrafik.Text == "График 2011 года по договору")
            {
                return;
            }
            if (MessageBox.Show("Вы уверены, что хотите удалить график '" + NMGrafik.Text + "'?", "", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
            {
                return;
            }
            my.sc.CommandText = "select id_group from dostup.dbo.usersingroups where id_group = 234 and id_user = " + my.Id_us;
            my.cn.Open();
            if (my.sc.ExecuteScalar() == null)
            {
                MessageBox.Show("У Вас нет прав для выполнения этой операции!");
                my.cn.Close();
                return;
            }
            my.sc.CommandText = "delete FROM Grafik.dbo.tgrafik WHERE     idGrafik = '" + NMGrafik.SelectedValue.ToString() + "'";

            //my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            ObnGr();
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                string NMTable = "";
                //if (NMGrafik1.SelectedValue.ToString() == "1") { NMTable = "Grafik.dbo.tTask"; } else { NMTable = "Grafik.dbo.tTaskWrk"; }
                NMTable = "Grafik.dbo.tTaskWrk";
                my.sc.CommandText = "UPDATE " + NMTable + " SET " + Dgv1.Columns[e.ColumnIndex].Name + " = '" + Dgv1.CurrentCell.Value + "' WHERE (id =" + Dgv1.CurrentRow.Cells["idtask"].Value + ")";
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void Dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (flDel)
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo)!= DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }      
                
                
                    string NMTable = "";
                    NMTable = "Grafik.dbo.tTaskWrk";

                    if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
                    my.cn.Open();
                    foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                    {
                        my.sc.CommandText = "delete from " + NMTable + "  WHERE (id =" + selrow.Cells["idtask"].Value + ")";
                        my.sc.ExecuteScalar();

                    }   
                    my.cn.Close();
                    lCount.Text = "Всего: " + (dv1.Count-1).ToString();
                    flDel = false;
                
                //else
                //    e.Cancel = true;
            }

            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
                e.Cancel = true;
            }   
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv1.Columns[e.ColumnIndex].Name == "ButtonColumnName" )
                {
                    frmWrk fr = new frmWrk();
                    DataGridViewRow dr = Dgv1.CurrentRow;
                    fr.Proj.Text = dr.Cells["NDoc"].Value.ToString();
                    fr.idWrk.Text = dr.Cells["idWrk"].Value.ToString();
                    fr.vol.Text = dr.Cells["vol"].Value.ToString();
                    fr.ShowDialog();
                    //if (Dgv1.CurrentRow.Cells["Narch"].Value.ToString() == "")
                    //{
                    //    if (MessageBox.Show("Вы уверены, что хотите привязать работу " + Dgv1.CurrentRow.Cells["IdWRK"].Value.ToString() + " к проекту " + Dgv1.CurrentRow.Cells["Ndoc"].Value.ToString() + "?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //    { my.sc.CommandText = "";
                        
                    //    }
                    //}
                }
                else
                {
                    ltask_code.Text = Dgv1.CurrentRow.Cells["task_code"].Value.ToString();
                    flDel = true;
                }

            }
            catch (Exception)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmColumns fr = new frmColumns();
            fr.mode = mode;
            fr.ShowDialog();
            spisok(NMGrafik.SelectedValue.ToString(), 0, "");
            spisok1(NMGrafik1.SelectedValue.ToString(), 0, "");

        }

        private void idComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idComplex.SelectedValue.ToString()))
            {
                ObnGr();
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                dv.RowFilter = "task_code = '" + Dgv1.CurrentRow.Cells["task_code"].Value.ToString() + "'";
                //my.cn.Open();
                string sel  = "exec Grafik.dbo.sUpField '', '' ," + Dgv1.CurrentRow.Cells["idtask"].Value.ToString() + "," + NMGrafik1.SelectedValue.ToString();
                SqlDataAdapter da1 = new SqlDataAdapter(sel, my.sconn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                DataGridViewRow dr = Dgv1.CurrentRow;

                for (int i = 0; i < dr.Cells.Count; i++)
                {
                    for (int i1 = 0; i1 < ds1.Tables[0].Columns.Count; i1++)
                    {
                        if (Dgv1.Columns[dr.Cells[i].ColumnIndex].Name == ds1.Tables[0].Columns[i1].ColumnName & dr.Cells[i].Value.ToString() != ds1.Tables[0].Rows[0][i1].ToString())
                        {
                            dr.Cells[i].Value = ds1.Tables[0].Rows[0][i1].ToString(); break;
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void chOsn_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                if (RemOsn )
            {
                if (chOsn.Checked && MessageBox.Show("Вы уверены, что хотите изменить статус основного графика? Основной график может быть один в каждом Инвест.проекте!", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    my.cn.Open();
                    my.sc.CommandText = "exec Grafik.dbo.sRemOsn " + NMGrafik.SelectedValue.ToString() + "," + (chOsn.Checked ? 1 : 0).ToString() + "," + (rbAEP.Checked ? 1 :3).ToString();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    NMGrafik_SelectedIndexChanged(null, null);
                }
                else
                {
                    RemOsn = false;
                    chOsn.Checked = !chOsn.Checked;
                    RemOsn = true;
                }
            }
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            if (Dgv1.CurrentCell == null || Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name == "")
            {
                return;
            }

            Act("exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '0' ,0," + NMGrafik1.SelectedValue.ToString() + "," + NMGrafik.SelectedValue.ToString() +",'dob'");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv2.CurrentRow == null)
                {
                    return;
                }
                //if (Dgv2.SelectedRows.Count == 0) { Dgv2.CurrentRow.Selected = true; }
                //my.cn.Open();
                //foreach (DataGridViewRow selrow in Dgv2.SelectedRows)
                //{
                //    my.sc.CommandText = "exec Grafik.dbo.sInsGr " + NMGrafik.SelectedValue.ToString() + ", " + selrow.Cells["idtask"].Value.ToString();
                //    my.sc.ExecuteScalar();
                //}
                //my.cn.Close();
                // spisok(NMGrafik.SelectedValue.ToString(), 0, "");

                ActAll("exec Grafik.dbo.sInsGr " + NMGrafik.SelectedValue.ToString() + ", ", "idtask", Dgv2);

            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Dgv2.Rows.Count == 0) { return; }
            if (Dgv2.CurrentCell == null) { Dgv2.CurrentCell = Dgv2.FirstDisplayedCell; }
            m_searchInfo.searchString = textBox2.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(Dgv2, m_searchInfo);
            //Dgv2.CurrentRow.Selected = true;
            Dgv2.CurrentCell.Selected = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            spisok(NMGrafik.SelectedValue.ToString(), 0, "");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (Dgv1.CurrentRow == null)
            {
                return;
            }
            //    my.cn.Open();
            //    my.sc.CommandText = "exec Grafik.dbo.sInsGr " + NMGrafik1.SelectedValue.ToString() + ", " + Dgv1.CurrentRow.Cells["idtask"].Value.ToString();
            //    my.sc.ExecuteScalar();
            //    my.cn.Close();
            //    spisok1(NMGrafik1.SelectedValue.ToString(), 0, "");
            //}
            //catch (Exception ex)
            //{
            //    if ((int)my.cn.State == 1) { my.cn.Close(); }
            //    MessageBox.Show("Ошибка! " + ex.Message);
            //}
            ActAll("exec Grafik.dbo.sInsGr " + NMGrafik1.SelectedValue.ToString() + ", " , "idtask",Dgv1);
            //spisok1(NMGrafik1.SelectedValue.ToString(), 0, "");
        }

        private void ActAll(string Szap,string nmCells, DGVt dg  )
        {
            try
            {

                if (dg.SelectedRows.Count == 0) { dg.CurrentRow.Selected = true; }
                my.cn.Open();
                foreach (DataGridViewRow selrow in dg.SelectedRows)
                {
                    my.sc.CommandText = Szap + selrow.Cells[nmCells].Value.ToString();
                    //my.sc.CommandText = "delete from " + NMTable + "  WHERE (id =" + selrow.Cells["idtask"].Value + ")";
                    my.sc.ExecuteScalar();

                }
                my.cn.Close();
                if (dg.Name == "Dgv1")
                { spisok1(NMGrafik1.SelectedValue.ToString(), 0, ""); }
                else
                {
                    spisok(NMGrafik.SelectedValue.ToString(), 0, "");
                }
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name == "")
            {
                return;
            }
            //    my.cn.Open();
            //    my.sc.CommandText = "exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '0' ,0,0," + NMGrafik.SelectedValue.ToString();
            //    my.sc.ExecuteScalar();
            //    my.cn.Close();
            //    spisok(NMGrafik.SelectedValue.ToString(), 0, "");
            //}
            //catch (Exception ex)
            //{
            //    if ((int)my.cn.State == 1) { my.cn.Close(); }
            //    MessageBox.Show("Ошибка! " + ex.Message);
            //}
            Act("exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '0' ,0,0," + NMGrafik.SelectedValue.ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name == "")
            //    {
            //        return;
            //    }
            //    my.cn.Open();
            //    my.sc.CommandText = "exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '0' ,0,0," + NMGrafik.SelectedValue.ToString();
            //    my.sc.ExecuteScalar();
            //    my.cn.Close();
            //    spisok(NMGrafik.SelectedValue.ToString(), 0, "");
            //}
            //catch (Exception ex)
            //{
            //    if ((int)my.cn.State == 1) { my.cn.Close(); }
            //    MessageBox.Show("Ошибка! " + ex.Message);
            //}
            Act("exec Grafik.dbo.sOrderNomGrafik " + NMGrafik.SelectedValue.ToString() + "," + NMGrafik1.SelectedValue.ToString());
        }

        private void Act(string Szap)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = Szap;
                my.sc.ExecuteScalar();
                my.cn.Close();
                spisok(NMGrafik.SelectedValue.ToString(), 0, "");
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                my.sc.CommandTimeout = 30000;
                  string sel = "exec Grafik.dbo.sFindDouble " + NMGrafik.SelectedValue.ToString();
              //sel = "exec Grafik.dbo.sGrafik '" + szap + "'," + mode2.ToString() + ",'" + szap1 + "','" + my.Login + "'," + mode.ToString();
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                DataSet ds1 = new DataSet();

               //SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
                ds1.Clear();
                Dgv1.DataSource = null;
                if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv1.DataSource = dv1;
                //my.cn.Open();
                foreach (DataGridViewColumn col in Dgv1.Columns)
                {
                    if (col.Name == "idtask")
                    {
                        col.Visible = false;
                    }
                    my.sc.CommandText = "select grafik.dbo.fNMCol('" + col.Name + "'," + mode.ToString() + ",0)";
                    col.HeaderText = my.sc.ExecuteScalar().ToString();
                    if (col.HeaderText == "") col.Visible = false;
                }
                my.cn.Close();
                lCount.Text = "Всего: " + dv1.Count.ToString();
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                int idgr = 0;
                my.cn.Open();
                my.sc.CommandText = "exec Grafik.dbo.sForPred " + NMGrafik.SelectedValue.ToString();
                 idgr = (int)my.sc.ExecuteScalar();
                my.cn.Close();
                ObnGr();
                NMGrafik.SelectedValue = idgr;
                spisok(NMGrafik.SelectedValue.ToString(), 0, "");
            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
            //Act("exec sForPred " + NMGrafik.SelectedValue.ToString());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button14_Click(Dgv1, dv1, "OrderNom");
        }

        private void button23_Click(object sender, EventArgs e)
            {
                //try
                //{
                if (Dgv1.CurrentCell == null ||Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name == "")
                {
                    return;
                }

                Act("exec Grafik.dbo.sUpField '" + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name + "', '0' ,0," + NMGrafik1.SelectedValue.ToString() + "," + NMGrafik.SelectedValue.ToString() + ",'zam'");
            }

        //private void button24_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{

        //    //    my.sc.CommandTimeout = 30000;
        //    //    my.sc.CommandText = "exec Grafik.dbo.sAddTaskWRK " + idComplex.SelectedValue.ToString();
        //    //    my.sc.Connection = my.cn;
        //    //    my.cn.Open();
        //    //    SqlDataAdapter da = new SqlDataAdapter(my.sc);

        //    //    DataSet ds1 = new DataSet();

        //    //    ds1.Clear();
        //    //    Dgv1.DataSource = null;
        //    //    da.Fill(ds1);

        //    //    dv1 = new DataView();
        //    //    dv1.Table = ds1.Tables[0];
        //    //    Dgv1.DataSource = dv1;

        //    //    my.cn.Close();
        //    //    lCount.Text = "Всего: " + dv1.Count.ToString();


        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    if ((int)my.cn.State == 1) { my.cn.Close(); }
        //    //    MessageBox.Show("Ошибка! " + ex.Message);
        //    //}

        //}

        private void доToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sel("exec Grafik.dbo.sAddTaskWRK " + idComplex.SelectedValue.ToString());
            //try
            //{

            //    my.sc.CommandTimeout = 30000;
            //    my.sc.CommandText = "exec Grafik.dbo.sAddTaskWRK " + idComplex.SelectedValue.ToString();
            //    my.sc.Connection = my.cn;
            //    my.cn.Open();
            //    SqlDataAdapter da = new SqlDataAdapter(my.sc);

            //    DataSet ds1 = new DataSet();

            //    ds1.Clear();
            //    Dgv1.DataSource = null;
            //    da.Fill(ds1);

            //    dv1 = new DataView();
            //    dv1.Table = ds1.Tables[0];
            //    Dgv1.DataSource = dv1;

            //    my.cn.Close();
            //    lCount.Text = "Всего: " + dv1.Count.ToString();


            //}
            //catch (Exception ex)
            //{
            //    if ((int)my.cn.State == 1) { my.cn.Close(); }
            //    MessageBox.Show("Ошибка! " + ex.Message);
            //}
        }

        private void связатьРаботыСПроектомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sel("exec Grafik.dbo.sProjAC " + NMGrafik.SelectedValue.ToString());
            my.naimDG("0,ID работы,Наименование работы,Проект,Название проекта,Вид работ,Исполнитель,Объем,Архивный номер,0,0,0,0",Dgv1,"");
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.Name = "ButtonColumnName"; 
            buttonCol.HeaderText = "Связать"; 
            buttonCol.Text = "";
            Dgv1.Columns.Add(buttonCol);
            //foreach (DataGridViewRow row in Dgv1.Rows)
            //{
            //    var button = (Button)row.Cells["ButtonColumnName"].Value;
            //    row.Cells["ButtonColumnName"].Value = "Связать";
            //}// button is null here! } 

        }
        private void Sel(string Cmd)
        {
            try
            {
                my.sc.CommandTimeout = 30000;
                my.sc.CommandText = Cmd;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                DataSet ds1 = new DataSet();

                ds1.Clear();
                Dgv1.DataSource = null;
                if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv1.DataSource = dv1;

                my.cn.Close();
                lCount.Text = "Всего: " + dv1.Count.ToString();


            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void проектыИзЦАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sel("exec Grafik.dbo.sArch " + idComplex.SelectedValue.ToString());
            //my.naimDG("Архивный номер,Наименование работы,Проект", Dgv1, "");

        }

        private void отчетВExcelПоОсновномуГрафикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModOffice.ReportExGrafik(NMGrafik.SelectedValue.ToString(),0,"", NMGrafik.Text,(int)idEntpr.SelectedValue,(int)idDep.SelectedValue);
        }


        private void отчетВExcelПоВыбранномуГрафикувсеИзЦАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nbut1 = 1;
            if (sender.ToString().Contains("обор")) { nbut1 = 2; }
            if (!my.isFormInMdi("frmVibD", nbut1, this))
            {
                frmVibD fr = new frmVibD();
                fr.Tag = nbut1;
                fr.Nbut = nbut1;
                my.Szap = "";
                fr.NMGrafik = NMGrafik.Text;
                fr.idgrafik = NMGrafik.SelectedValue.ToString();
                fr.IdEntpr = (int)idEntpr.SelectedValue;
                fr.IdDep = (int)idDep.SelectedValue;
                fr.MdiParent = my.MDIForm;
                fr.Show();
            }
            //ModOffice.ReportExGrafik(NMGrafik.SelectedValue.ToString(), 1);
        }

        private void rbAEP_CheckedChanged(object sender, EventArgs e)
        {
            //if (RemOsn)
            //{
            //    if (rbAEP.Checked)
            //    {
            //        if (mode != 1)
            //        {
            //            if (MessageBox.Show("Вы действительно хотите изменить вид графика на график АЭР?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                mode = 1; spisok(NMGrafik.SelectedValue.ToString(), 0, ""); sExec("exec Grafik.dbo.sRemOsn " + NMGrafik.SelectedValue.ToString() + "," + (chOsn.Checked ? 1 : 0).ToString() + "," + mode.ToString());
            //            }
            //        }
            //    }
            //    if (rbKT2.Checked)
            //    {
            //        if (mode != 3)
            //        {
            //            if (MessageBox.Show("Вы действительно хотите изменить вид графика на график КТ2?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                mode = 3; spisok(NMGrafik.SelectedValue.ToString(), 0, ""); sExec("exec Grafik.dbo.sRemOsn " + NMGrafik.SelectedValue.ToString() + "," + (chOsn.Checked ? 1 : 0).ToString() + "," + mode.ToString());
            //            }
            //        }
            //    }
            //}
            if (rbAEP.Checked) { mode = 1; }
            if (rbKT2.Checked) { mode = 3; }

        }
        
        private void sExec(string  up)
        {            
            my.sc.CommandText = up;
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
        }

        private void отчетВExcelСРасшифровкойПоАктамToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    if (!my.isFormInMdi("frmVibPeriod", 1, this))
            {
                frmVibPeriod fr = new frmVibPeriod();
                fr.Tag = 1;
                fr.Nbut = 1;
                my.Szap = "";
                fr.NMGrafik = NMGrafik.SelectedValue.ToString();
                fr.IdEntpr = (int)idEntpr.SelectedValue;
                fr.IdDep = (int)idDep.SelectedValue;
                fr.MdiParent = my.MDIForm;
                //fr.d1.Enabled = false;
                fr.Show();
            }    


            //
        }

        private void тематическоеПланированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!my.isFormInMdi("frmVibDate", 1, this))
            {
                frmVibDate fr = new frmVibDate();
                fr.Tag = 1;
                fr.Nbut = 1;
                my.Szap = "";
                fr.idgrafik = NMGrafik.SelectedValue.ToString();
                fr.IdEntpr = (int)idEntpr.SelectedValue;
                fr.IdDep = (int)idDep.SelectedValue;
                fr.MdiParent = my.MDIForm;
                fr.Show();
            }
        }

        private void тематическоеПланированиеОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!my.isFormInMdi("frmVibDates", 1, this))
            {
                frmVibDates fr = new frmVibDates();
                fr.Tag = 1;
                fr.Nbut = 1;
                my.Szap = "";
                fr.idgrafik = NMGrafik.SelectedValue.ToString();
                fr.IdEntpr = (int)idEntpr.SelectedValue;
                fr.IdDep = (int)idDep.SelectedValue;
                fr.MdiParent = my.MDIForm;
                fr.Show();
            }
        }

        private void остаткиСметнойСтоимостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!my.isFormInMdi("frmVibPeriod", 2, this))
            {
                frmVibPeriod fr = new frmVibPeriod();
                fr.Tag = 1;
                fr.Nbut = 2;
                my.Szap = "";
                fr.NMGrafik = NMGrafik.SelectedValue.ToString();
                fr.MdiParent = my.MDIForm;
                fr.IdEntpr = (int)idEntpr.SelectedValue;
                fr.IdDep = (int)idDep.SelectedValue;
                //fr.d1.Enabled = false;
                fr.Show();
            }  
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.MSProject.ApplicationClass projApp = null;
            //projApp = new Microsoft.Office.Interop.MSProject.ApplicationClass();
            //projApp.FileOpenEx(StrFileName, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, PjPoolOpen.pjDoNotOpenPool, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);


        }

        private void idEntpr_SelectedValueChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idEntpr.SelectedValue))
            {
                my.FillDC(idDep, 73, " and (Bits <> 0 and identpr = " + idEntpr.SelectedValue +") or iddep = 0" );
            }
        }





    }
}
