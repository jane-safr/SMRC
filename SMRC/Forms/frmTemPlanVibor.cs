using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC.Forms
{
    public partial class frmTemPlanVibor : Form
    {
        public DateTime d1; public int idplan;
        public frmTemPlanVibor()
        {
            InitializeComponent();
        }

        private void frmTemPlanVibor_Load(object sender, EventArgs e)
        {
            if (my.Nbut == 184) { Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            Dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                button2.Visible = true;
                button1.Text = "Добавить проект в календарный план";
            }
            ObnSmeti();
        }

        private void ObnSmeti()
        {
            DataSet ds; SqlDataAdapter da; string s ="";
            if (my.Nbut == 35) {  s = my.FilterSel(12, this, my.sconn, " and '" + d1.ToString() + "' between beginWRk and EndWRK  order by NomerSm");};
            if (my.Nbut == 184) { s = my.FilterSel(53, this, my.sconn,""); };

            string h = my.headStr; string w = my.widthStr;
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            ds.Tables[0].Columns.Add("Выбор", typeof(Boolean));
            Dgv1.DataSource = ds.Tables[0];
            my.naimDG(h, Dgv1, w);
            Dgv1.AllowUserToAddRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv1.AllowUserToDeleteRows = false;
        }

 

        private void ObnVidRab(int RowIndex)
        {

                DataSet ds; SqlDataAdapter da; string s = "";
                if (my.Nbut == 35) { s = my.FilterSel(16, this, my.sconn, " and idsm = " + Dgv1.Rows[RowIndex].Cells["idsm"].Value.ToString()); }
                if (my.Nbut == 184) { s = my.FilterSel(61, this, my.sconn, " and idComplexChapter in (SELECT  distinct   idComplexChapter FROM         sprav.dbo.tComplexChapter WHERE   idComplex = " + Dgv1.Rows[RowIndex].Cells["idcomplex"].Value.ToString() + ")"); }
                ds = new DataSet();
                da = new SqlDataAdapter(s, my.sconn);
                ds.Clear();
                da.Fill(ds);
                ds.Tables[0].Columns.Add("Выбор", typeof(Boolean));
                Dgv2.DataSource = ds.Tables[0];
                my.naimDG(my.headStr, Dgv2, my.widthStr);
                Dgv2.AllowUserToAddRows = false;
                Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
                Dgv2.AllowUserToDeleteRows = false;

        }

        private void Dgv1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ObnVidRab(e.RowIndex);
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns.Contains("IdSm"))
            {
                if (MessageBox.Show("Перейти в выбранную смету?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    my.Szap = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (!my.isFormInMdi("frmCapSm", (int)Dgv1.Rows[e.RowIndex].Cells[0].Value, my.MDIForm))
                    {
                        frmCapSm fr = new frmCapSm();
                        fr.idsm = (int)Dgv1.Rows[e.RowIndex].Cells[0].Value;
                        fr.Tag = Dgv1.Rows[e.RowIndex].Cells[0].Value;
                        fr.ShowDialog();
                        ObnSmeti();

                    }
                }
            }
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          if (((DGVt)sender).Columns[e.ColumnIndex].Name == "Выбор")  ((DGVt)sender).BeginEdit(true); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            foreach (DataGridViewRow selrow in Dgv1.Rows)
            {
                if (selrow.Cells["Выбор"].Value != DBNull.Value)
                {
                    if ((Boolean)selrow.Cells["Выбор"].Value)
                    {
                        if (my.Nbut == 35)
                        {
                            my.sc.CommandText = " exec InsSmPlan " + idplan.ToString() + "," + selrow.Cells["Idsm"].Value.ToString();
                            string s = my.sc.ExecuteScalar().ToString();
                            if (s != "OK") MessageBox.Show(s + " (" + selrow.Cells["NomerSm"].Value.ToString() + ")");
                        }
                        if (my.Nbut == 184)
                        {
                            foreach (DataGridViewRow selrow1 in Dgv2.Rows)
                            {
   
                                        my.sc.CommandText = " exec InsKpp1OSR " + idplan.ToString() + "," + selrow1.Cells["IdOSR"].Value.ToString();
                                        string s = my.sc.ExecuteScalar().ToString();
                                        if (s != "OK") MessageBox.Show(s + " (" + selrow1.Cells["ОСР"].Value.ToString() + ")");

                            }
                        }

                    }
                }
            }
            MessageBox.Show("Готово!");
            my.cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            foreach (DataGridViewRow selrow in Dgv2.Rows)
            {
                if (selrow.Cells["Выбор"].Value != DBNull.Value)
                {
                    if ((Boolean)selrow.Cells["Выбор"].Value)
                    {
                        my.sc.CommandText = " exec InsKpp1OSR " + idplan.ToString() + "," + selrow.Cells["IdOSR"].Value.ToString();
                        string s = my.sc.ExecuteScalar().ToString();
                        if (s != "OK") MessageBox.Show(s + " (" + selrow.Cells["ОСР"].Value.ToString() + ")");
                    }
                }
            }
            MessageBox.Show("Готово!");
            my.cn.Close();
        }






    }
}
