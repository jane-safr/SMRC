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
    public partial class frmKP : Form
    {
        public int idplan; bool WithOpen;
        DataSet ds;
        SqlDataAdapter da;
        public frmKP()
        {
            InitializeComponent();
        }

        private void frmKP1_Load(object sender, EventArgs e)
        {
            WithOpen = true;
            LoadPlan();
            WithOpen = false;
        }

        private void LoadPlan()
        {
            //if (idplan == 0)
            //{
            //    rb1.Checked = true;
            //    my.ObnPeriod(Period, rb2);
            //    Period.SelectedValue = DateTime.Today.AddDays(-DateTime.Today.Day + 1).AddMonths((int)((DateTime.Today.Month - 1) / 3) * 3 + 1 - DateTime.Today.Month);
            //    this.NMPlan.Text = "Календарный план I уровня";
            //}
            //else
            //{
            my.sc.CommandText = "select * from tKP where IdKP = " + idplan.ToString();
            my.cn.Open();
            SqlDataReader DRd = my.sc.ExecuteReader();
            DRd.Read();
            NMPlan.Text = (string)DRd["NMKP"];
            if ((byte)DRd["VidPeriod"] == 1)
            {
                rb2.Checked = true;
            }
            else
            {
                rb1.Checked = true;
            }
            my.ObnPeriod(Period, rb2);
            Period.SelectedValue = (DateTime)DRd["Period"];
            DRd.Close();
            my.cn.Close();
               
            //}
            ObnPlan();
        }

        private void ObnPlan()
        {
 
            string s = "";
            s = my.FilterSel(186, this, my.sconn, "");
            string h = my.headStr; string w = my.widthStr;
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            Dgv1.DataSource = null;

                s = s + " and idkp  = " + idplan.ToString();
                da.SelectCommand.CommandText = s;
                da.Fill(ds);

            Dgv1.DataSource = ds.Tables[0];
            Dgv1.VLadd("idisp", "Исполнитель", "SELECT   IdPred, Name FROM         v_IzPrivlIsp  ORDER BY Name", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 13);

            Dgv1.Columns[5].DefaultCellStyle.Format = "dd.MM.yyyy";

            for (int i = 12; i < Dgv1.Columns.Count; i++)
            {
                //Dgv1.Columns[i].DefaultCellStyle.Format = "# ###.###";
                Dgv1.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
            my.naimDG(h, Dgv1, w);
            Dgv1.AllowUserToAddRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;

            da = new SqlDataAdapter("SELECT       IdKPOSR, DateBeg, Prodol, IdIsp, IdEdIzm, Vol, IdPr, Sdvig, IdPosl, Usl FROM         dbo.tKPOSR", my.sconn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            cb.QuotePrefix = "[";
            cb.QuoteSuffix = "]";
            da.UpdateCommand = cb.GetUpdateCommand();
 
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            if (idplan == 0)
            {
                my.sc.CommandText = "insert into TKP (NMKP) values ('" + NMPlan.Text + "' ) select ident_current('tKP1')";
                idplan = Convert.ToInt16(my.sc.ExecuteScalar());
            }
            else
            {
                my.sc.CommandText = "update TKP set  NMKP = '" + NMPlan.Text   + "' where idkp = " + idplan.ToString() ;
                my.sc.ExecuteScalar();
            }

            my.cn.Close();
        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmTemPlanVibor fr = new frmTemPlanVibor();
            fr.d1 = (DateTime)Period.SelectedValue;
            fr.idplan = idplan;
            fr.ShowDialog();
            ObnPlan();

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
                    my.sc.CommandText = "delete from tKPOsr where  IdKpOsr = " + selrow.Cells[0].Value;
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

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (WithOpen) { return; }
            if (Dgv1.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor == Color.Blue)
            { Dgv1.BeginEdit(true); }
            else
            { Dgv1.EndEdit(); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            NMPlan.Focus();
            if (ds.HasChanges()) { my.Up(da, ds.Tables[0]); };
        }


        private void frmKP1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dgv1_CellEndEdit(null, null);
            if (MessageBox.Show("Сохранить данные? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            { Button3_Click(null, null); }
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
                        fr.idsm = (int)Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value;
                        fr.Tag = Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value;
                        fr.ShowDialog();

                    }
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ObnPlan();
        }

        //private void toolStripButton5_Click(object sender, EventArgs e)
        //{
        //    if (Dgv1.CurrentRow == null) return;
        //    my.cn.Open();
        //    my.sc.CommandText = "exec InsKppOSR " + Dgv1.CurrentRow.Cells["Idkp1"].Value.ToString() + "," + Dgv1.CurrentRow.Cells["Idosr"].Value.ToString();
        //    my.sc.ExecuteScalar();
        //    my.cn.Close();
        //    if (!my.isFormInMdi("frmKP1", (int)Dgv1.CurrentRow.Cells["Idkp1"].Value, my.MDIForm))
        //    {
        //        frmKP1 fr = new frmKP1();
        //        fr.idplan = (int)Dgv1.CurrentRow.Cells["Idkp1"].Value;
        //        fr.Tag = Dgv1.CurrentRow.Cells["Idkp1"].Value;
        //        fr.ShowDialog();
        //    }

        //}
    }
}
