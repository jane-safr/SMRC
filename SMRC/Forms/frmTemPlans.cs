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
    public partial class frmTemPlans : Form
    {
        public frmTemPlans()
        {
            InitializeComponent();
        }

        private void frmTemPlans_Load(object sender, EventArgs e)
        {
            if (my.Nbut == 71)
            {
                my.Nbut = 35;
                my.FillDC(IdEntpr, 8, " and sprav.dbo.isb(Bits,4) = 1 or sprav.dbo.isb(Bits,3) = 1  ");
                if (my.identpr != 0) { IdEntpr.SelectedValue = my.identpr;
                
                }  
            }
            if (my.Nbut == 72)
            {   my.Nbut = 184;
                IdEntpr.Visible = false;
                checkBox1.Checked = true;
                checkBox1.Visible = false;
            }
            ObnPlan();
        }
        private void ObnPlan()
        {
            bool chAll = checkBox1.Checked;
            DataSet ds; SqlDataAdapter da;
            string s = my.FilterSel(my.Nbut, this, my.sconn, (chAll ? "":" and dbo.tPlan.IdEntpr = " + IdEntpr.SelectedValue.ToString()));
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];
            my.naimDG(my.headStr, Dgv1, my.widthStr);
            Dgv1.AllowUserToAddRows = false;
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (my.Nbut == 35)
            {
                if (!my.isFormInMdi("frmTemPlan", (int)Dgv1.Rows[e.RowIndex].Cells[0].Value, my.MDIForm))
                {
                    frmTemPlan fr = new frmTemPlan();
                    fr.idplan = (int)Dgv1.Rows[e.RowIndex].Cells[0].Value;
                    fr.Tag = Dgv1.Rows[e.RowIndex].Cells[0].Value;
                    fr.ShowDialog();
                }
            }
            if (my.Nbut == 184)
            {
                if (!my.isFormInMdi("frmKP1", (int)Dgv1.Rows[e.RowIndex].Cells[0].Value, my.MDIForm))
                {
                    frmKP1 fr = new frmKP1();
                    fr.idplan = (int)Dgv1.Rows[e.RowIndex].Cells[0].Value;
                    fr.Tag = Dgv1.Rows[e.RowIndex].Cells[0].Value;
                    fr.ShowDialog();
                }
            }
            ObnPlan();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (my.Nbut == 35)
            {
                frmTemPlan fr = new frmTemPlan();
                fr.idplan = 0;
                fr.Tag = 0;
                fr.ShowDialog();
            }
            if (my.Nbut == 184)
            {
                frmKP1 fr = new frmKP1();
                fr.idplan = 0;
                fr.Tag = 0;
                fr.ShowDialog();
            }
            ObnPlan();
        }

        private void IdEntpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(IdEntpr.SelectedValue))
            { ObnPlan(); }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Dgv1_UserDeletingRow(null, null);
        }

        private void Dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
                my.cn.Open();
                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    if (my.Nbut == 35)
                    {
                        my.sc.CommandText = "delete from tPlan where  Idplan = " + selrow.Cells[0].Value;
                    }
                    if (my.Nbut == 184)
                    {
                        my.sc.CommandText = "delete from tKP1 where  IdKP1 = " + selrow.Cells[0].Value;
                    }
                    my.sc.ExecuteScalar();
                }
                my.cn.Close();
                ObnPlan();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ObnPlan();
        }





    }
}
