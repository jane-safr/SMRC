using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC
{
    public partial class UCFilter : UserControl
    {
        public String sel1  = ""; 
        String s1;
        public DataView dv = new DataView(); public Object Obj1; public Int16 vid;
        String[] selzap1 = new String[20]; String[] Textbox2sel = new String[20]; Byte us; int isch; int MaxIsch;
        public UCFilter()
        {
            InitializeComponent();
        }
        private void FillTS(ToolStripComboBox ToolStripComboBox1, int id, String s1, string sconn)
        {
            String s;
            if (id < 1000)
            {
                s = "exec FillSpr  " + id.ToString() + ",'" + s1 + "'";
            }
            else
            {
                s = s1;
            }

            SqlConnection cn = new SqlConnection(sconn);
            cn.Open();
            SqlDataReader DRd = new SqlCommand(s, cn).ExecuteReader();
            while (DRd.Read())
            { ToolStripComboBox1.Items.Add(DRd.GetString(1)); }

            DRd.Close();

            cn.Close();


        }
        private void refr()
        {
            //    if (Vid == 1)
            //{// ' CrystalReport
            //            //CrystalDecisions.CrystalReports.Engine.ReportDocument report ;
            //            //report = CType(CType(Obj1, CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource, CrystalDecisions.CrystalReports.Engine.ReportDocument)
            //            //report.SetDataSource(dv)
            //            //CType(Obj1, CrystalDecisions.Windows.Forms.CrystalReportViewer).RefreshReport()
            //            }
            if (vid == 3)
            { ((Microsoft.Reporting.WinForms.ReportViewer) Obj1).RefreshReport(); }

            ToolStripTextBox2.Text = "Всего: " + dv.Count;
        }
        public void refList()
        {
                       if (my.Ustr != "")
            {
                TextBox2.Text = my.headStr;
                my.headStr = "";
                sel1 = my.Ustr;
                my.Ustr = "";
                SetFilter();
            }
        }
        private void SetFilter()
        {
            //try
            //{
            if (us == 0)
            {
                dv.RowFilter = dv.RowFilter.ToString() + (dv.RowFilter != "" ? " and (" : "(").ToString() + sel1.Trim() + ")";
                isch = isch + 1;
                //dv.RowFilter = "";
                MaxIsch = (int)MaxIsch < isch ? isch : MaxIsch;
                selzap1[isch] = dv.RowFilter;
                Textbox2sel[isch] = TextBox2.Text;
                if (MaxIsch >= 20)
                {
                    for (int i = 0; i <= 18; i++)
                    {
                        selzap1[i] = selzap1[i + 2];
                        Textbox2sel[i] = Textbox2sel[i + 2];
                    }
                    MaxIsch = MaxIsch - 2;
                    isch = isch - 2;
                }
            }
            else
            {
                dv.RowFilter = sel1;
                //' ref()
                us = 0;
            }
            if (MaxIsch > isch) { TForward.Enabled = true; } else { TForward.Enabled = false; }
            if (isch >= 1) TBack.Enabled = true;
            if (dv.Count == 0)
            {
                MessageBox.Show("Нет записей, удовлетворяющих выбранному условию!");
            }
            refr();
            sel1 = "";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка! " + ex.Message);

            //    //throw;
            //}

        }

        public void remFilter()
        {
            TextBox2.Tag = "";
            dv.RowFilter = "";
            sel1 = "";
            TextBox2.Text = "Выбрать все записи ";

            for (int i = 0; i < 20; i++)
            {
                selzap1[i] = "";
                Textbox2sel[i] = "";
            }

            Textbox2sel[0] = TextBox2.Text;
            isch = 0;
            TForward.Enabled = false;
            TBack.Enabled = false;
            MaxIsch = 0;

            TextBox2.Text = "Выбрать все записи ";
            ToolStripTextBox2.Text = "Всего: " + dv.Count.ToString();
        }

        private void TRem_Click(object sender, EventArgs e)
        {
            remFilter();
            refr();
        }

        private void TFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dv.Count != 0)
                {
                    if (ToolStripTextBox1.Text.Trim() == "")
                    {
                        MessageBox.Show("Заполните строку поиска для " + ListBox1.SelectedItems[0].ToString(), "Внимание!"); return;}


                        if (sel1 == "") { TextBox2.Text = TextBox2.Text + ", где "; }
                        if (ToolStripComboBox1.Text == "схоже с")
                        { s1 = " like '%" + ToolStripTextBox1.Text + "%'"; }
                        else
                        { s1 = " " + ToolStripComboBox1.Text + " " + (my.IsNumeric(ToolStripTextBox1.Text) ? "" : "'").ToString() + ToolStripTextBox1.Text + (my.IsNumeric(ToolStripTextBox1.Text) ? "" : "'").ToString(); }


                        sel1 = "  [" + dv.Table.Columns[ListBox1.SelectedIndices[0]].ColumnName + "]" + s1;


                        TextBox2.Text = TextBox2.Text + "  " + ListBox1.SelectedItems[0].ToString() + " " + ToolStripComboBox1.Text + " " + ToolStripTextBox1.Text + ",";
                        SetFilter();
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show("Указанный фильтр недопустим! " + ex.Message, "Ошибка!");
                sel1 = "";
                //throw;
            }
        }

        private void TSpisok_Click(object sender, EventArgs e)
        {
            try
            {
                my.Pform = (Form)Parent;
                Forms.frmList fr = new Forms.frmList();
                TreeNode node;
                if (dv.Count != 0)
                {
                    s1 = "f";
                    dv.Sort = dv.Table.Columns[ListBox1.SelectedIndices[0]].ColumnName;
                    for (int i = 0; i <= dv.Count - 1; i++)
                    {
                        if (s1.Trim() != (dv[i][ListBox1.SelectedIndex] == DBNull.Value ? "" : dv[i][ListBox1.SelectedIndex].ToString().Trim()))
                        {
                            node = fr.TreeView1.Nodes.Add((dv[i][ListBox1.SelectedIndex] == DBNull.Value ? "" : dv[i][ListBox1.SelectedIndex].ToString()).ToString());

                        }
                        s1 = (dv[i][ListBox1.SelectedIndex] == DBNull.Value ? "" : dv[i][ListBox1.SelectedIndex].ToString()).ToString();
                    }
                }
                dv.Sort = "";
                fr.TEx.Tag = dv.Table.Columns[ListBox1.SelectedIndices[0]].DataType.Name;
                fr.TreeView1.Tag = dv.Table.Columns[ListBox1.SelectedIndices[0]].ColumnName;
                sel1 = "";
                my.headStr = TextBox2.Text;
                my.cap = ListBox1.SelectedItem.ToString();
                fr.ShowDialog();
                refList();
            }
            catch (Exception)

            { }
        }

        private void TBack_Click(object sender, EventArgs e)
        {
            if (isch <= 1)
            {
                sel1 = "";
                TextBox2.Text = "Выбрать все записи";
                isch = 0;
                TBack.Enabled = false;
            }
            else
            {
                isch = isch - 1;
                sel1 = selzap1[isch];
                TextBox2.Text = Textbox2sel[isch];
            }
            us = 1;
            SetFilter();
        }

        private void TForward_Click(object sender, EventArgs e)
        {
            if (isch < 0 || selzap1[isch + 1] == "")
            {
                sel1 = "";
                TextBox2.Text = "Выбрать все записи";
            }
            else
            {
                isch = isch + 1;
                sel1 = selzap1[isch];
                TextBox2.Text = Textbox2sel[isch];
            }

            us = 1;
            SetFilter();
        }

        private void TExit_Click(object sender, EventArgs e)
        {
            switch (vid)
            {
                case 2:
                    { ((Form)((DataGridView)Obj1).Parent).Close(); }
                    break;
                case 3:
                    { ((Form)((Microsoft.Reporting.WinForms.ReportViewer)Obj1).Parent).Close(); }
                    break;
                default:
                    break;
            }
            //        Select Case vid
            //Case 1
            //    CType(CType(Obj1, CrystalDecisions.Windows.Forms.CrystalReportViewer).Parent, Form).Close()
            //if (vid == 2) { ((Form)((DataGridView)Obj1).Parent).Close(); }
            // CType(CType(Obj1, Infragistics.Win.UltraWinGrid.UltraGrid).Parent, Form).Close()
            //    Case 3
            //        CType(CType(Obj1, Microsoft.Reporting.WinForms.ReportViewer).Parent, Form).Close()

            //End Select
        }

       

        public void ZapList(String scn)
        {
            FillTS(ToolStripComboBox1, 28, " and vib = 1", scn);
            ToolStripComboBox1.SelectedItem = ToolStripComboBox1.Items[0];
            SqlConnection cn = new SqlConnection(scn);
            cn.Open();
            SqlCommand sc = new SqlCommand("SELECT     headers FROM         dbo.FilterSel WHERE idSel =" + my.Nbut.ToString(), cn);

            my.headStr = sc.ExecuteScalar().ToString();
            cn.Close();
            cn = null;
            ListBox1.Items.Clear();
            naimSp(my.headStr, ListBox1);
            ListBox1.MultiColumn = true;
            my.Ustr = "";
            us = 0;
            if (ListBox1.Items.Count > 0) { ListBox1.SelectedItem = ListBox1.Items[0]; }
        } 

        public static void naimSp(String sel, ListBox List)
        {
            try
            {
                int w = 0;
                for (int i = 0; i <= 1000; i++)
                {
                    if (w <= sel.Length)
                    {
                        string s1 = sel.Substring(w, (int)(((int)sel.IndexOf(",", w) == -1 ? sel.Length - w : (int)sel.IndexOf(",", w)- w)) );
                        s1 = (s1 == "0" ? "" : s1).ToString().Trim();
                        List.Items.Add(s1);
                        w = 1 + (int)(((int)sel.IndexOf(",", w) == -1 ? w + 20 : (int)sel.IndexOf(",", w)));
                    }
                    else
                    { return; }

                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void TForward_Click_1(object sender, EventArgs e)
        {
        if (isch < 0 || selzap1[isch + 1] == "") 
            {
            sel1 = "";
            TextBox2.Text = "Выбрать все записи";
            }
        else
        {
            isch = isch + 1;
            sel1 = selzap1[isch];
            TextBox2.Text = Textbox2sel[isch];
        }
        us = 1;
        SetFilter();
        }
    }
}
    
    
  

