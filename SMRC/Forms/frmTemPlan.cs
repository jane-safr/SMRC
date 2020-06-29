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
    public partial class frmTemPlan : Form
    {
        public int idplan; bool WithOpen;
        DataSet ds;
        public frmTemPlan()
        {

            InitializeComponent();
        }

        private void frmTemPlan_Load(object sender, EventArgs e)
        {
            WithOpen = true;
            my.FillDC(IdEntpr, 8, " and sprav.dbo.isb(Bits,4) = 1 or sprav.dbo.isb(Bits,3) = 1  ");
            my.FillDC(IdOSR, 35, " and idosr in (select distinct idOSR from vPlanSm) ");
            if (idplan == 0 && my.identpr != 0) { IdEntpr.SelectedValue = my.identpr; } else { IdEntpr.SelectedValue = 0; }
            LoadPlan();
            WithOpen = false;
        }

        private void LoadPlan()
        {
            if (idplan == 0)
            {
                rb1.Checked = true;
                my.ObnPeriod(Period, rb2);
                Period.SelectedValue = DateTime.Today.AddDays(-DateTime.Today.Day + 1).AddMonths((int)((DateTime.Today.Month - 1) / 3) * 3 + 1 - DateTime.Today.Month);
            }
            else
            {
                my.sc.CommandText = "select * from tPlan where IdPlan = " + idplan.ToString();
                my.cn.Open();
                SqlDataReader DRd = my.sc.ExecuteReader();
                DRd.Read();
                NMPlan.Text = (string)DRd["NMPlan"];
                IdEntpr.SelectedValue = (int)DRd["IdEntpr"];
                if ((byte)DRd["VidPeriod"] == 1)
                {
                    rb2.Checked = true;
                }
                else
                {
                    rb1.Checked = true;
                }
                i1.Text = DRd["I1"].ToString();
                i2.Text = DRd["I2"].ToString();
                i3.Text = DRd["I3"].ToString(); 
                my.ObnPeriod(Period, rb2);
                Period.SelectedValue = (DateTime)DRd["Period"];
                chOsnovnoi.Checked = (Boolean)DRd["Osnovnoi"];
                DRd.Close();
                my.cn.Close();
            }
            
            ObnPlanSmeti();
        }

        private void ObnPlanSmeti()
        {
             SqlDataAdapter da;
            string s = "";
            s = my.FilterSel(14, this, my.sconn,"" );
            string h = my.headStr; string w = my.widthStr;
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            Dgv1.DataSource = null;
            if (rbplan.Checked)
            {
                s = s + " and idplan  = " + idplan.ToString();
                da.SelectCommand.CommandText = s;
                da.Fill(ds);
            }
            else
            {
                if (rbosr.Checked)
                {
                    s = s + " and idOsr  = " + IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (rb1.Checked ? "2" : "1") + "  and period = '" + Period.SelectedValue.ToString() + "' ";
                    da.SelectCommand.CommandText = s;
                    da.Fill(ds);
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + Period.SelectedValue.ToString() + "','" + (rb1.Checked ? ((DateTime)Period.SelectedValue).AddMonths(3).ToString() : Period.SelectedValue.ToString()) + "',0,3," + IdOSR.SelectedValue.ToString(), my.sconn);
                    da.Fill(ds);
                }
                else
                {
                    s = s + " and idOsr  = " + IdOSR.SelectedValue.ToString() + " and 1 = 5  ";
                    da.SelectCommand.CommandText = s;
                    da.Fill(ds);
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + Period.SelectedValue.ToString() + "','" + (rb1.Checked ? ((DateTime)Period.SelectedValue).AddMonths(3).ToString() : Period.SelectedValue.ToString()) + "',0,3,0" , my.sconn);
                    da.Fill(ds);
                }
            }

            //exec sNezaversh '01.06.2009','01.06.2009',2,3,167
            Dgv1.DataSource = ds.Tables[0];
            Dgv1.VLadd("idisp", "Исполнитель", "SELECT   IdPred, Name FROM         v_IzPrivlIsp  ORDER BY Name", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 5);

            for (int i = 13; i < Dgv1.Columns.Count ; i++)
            {
               Dgv1.Columns[i].DefaultCellStyle.Format = "# ###.###";
               Dgv1.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
            my.naimDG(h, Dgv1,w);
            Dgv1.AllowUserToAddRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            if (idplan == 0)
            { my.sc.CommandText = "exec NewPlan '" + NMPlan.Text + "'," + (rb1.Checked ? "2" : "1") + ", '" + Period.SelectedValue.ToString() + "'," + IdEntpr.SelectedValue.ToString(); 
            idplan = Convert.ToInt16( my.sc.ExecuteScalar());  }
            else
            { my.sc.CommandText = "update tPlan set  NMPlan = '" + NMPlan.Text + "',VidPeriod =" + (rb1.Checked ? "2" : "1") + ", period ='" + Period.SelectedValue.ToString() + "',identpr =" + IdEntpr.SelectedValue.ToString() + ", osnovnoi = "  + (chOsnovnoi.Checked ? 1 : 0).ToString() + " where idplan = " + idplan.ToString();
            my.sc.ExecuteScalar();
            }
           
            my.cn.Close();
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            my.ObnPeriod(Period, rb2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить данные? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            { Button3_Click(null, null); }
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmTemPlanVibor fr = new frmTemPlanVibor();
            fr.d1 = (DateTime)Period.SelectedValue;
            fr.idplan = idplan;
            fr.ShowDialog();
            ObnPlanSmeti();
        }

        private void Dgv1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ObnVidRab(e.RowIndex);
        }
        private void ObnVidRab(int RowIndex)
        {
            if (Dgv1.Rows.Count == 0) return;
            DataSet ds; SqlDataAdapter da;
            string s = my.FilterSel(15, this, my.sconn, " and IdPlanSm = " + Dgv1.Rows[RowIndex].Cells["IdPlanSm"].Value.ToString());
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv2.DataSource = ds.Tables[0];
            Dgv2.Columns["volent"].DefaultCellStyle.Format = "# ###.###";
            Dgv2.Columns["volent"].DefaultCellStyle.ForeColor = Color.Blue;
            my.naimDG(my.headStr, Dgv2, my.widthStr);
            Dgv2.AllowUserToAddRows = false;
            Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv2.AllowUserToDeleteRows = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
            if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    my.sc.CommandText = "delete from tPlanSm where IdPlanSm  = " + selrow.Cells["IdPlanSm"].Value;
                    my.sc.ExecuteScalar();
                }
                my.cn.Close();
                ObnPlanSmeti();
            }
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (WithOpen) { return; }
            if ((e.ColumnIndex >= 13 || Dgv1.Columns[e.ColumnIndex].Name == "idisp") && Dgv1.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightCyan)
            { Dgv1.BeginEdit(true); }
            else
          { Dgv1.EndEdit(); }
        }

        private void Dgv2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (WithOpen) { return; }
            if (Dgv2.Columns[e.ColumnIndex].Name == "volent" )
            { Dgv2.BeginEdit(true); }
            else
            { Dgv2.EndEdit(); }
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.ColumnIndex -1;
                if (i == 12 || i == 15 || i == 18) { Dgv1.CurrentRow.Cells[e.ColumnIndex + 1].Value = (double)Dgv1.CurrentRow.Cells[e.ColumnIndex].Value * (double)Dgv1.CurrentRow.Cells[e.ColumnIndex + 2].Value; }
                if (i == 13 || i == 16 || i == 19) { if ((double)Dgv1.CurrentRow.Cells[e.ColumnIndex + 1].Value != 0) { Dgv1.CurrentRow.Cells[e.ColumnIndex - 1].Value = (double)Dgv1.CurrentRow.Cells[e.ColumnIndex].Value / (double)Dgv1.CurrentRow.Cells[e.ColumnIndex + 1].Value; } else { Dgv1.CurrentRow.Cells[e.ColumnIndex-1].Value = 0; } }
                if (i == 14 || i == 17 || i == 20) { if ((double)Dgv1.CurrentRow.Cells[e.ColumnIndex].Value != 0) { Dgv1.CurrentRow.Cells[e.ColumnIndex - 1].Value = (double)Dgv1.CurrentRow.Cells[e.ColumnIndex - 1].Value * (double)Dgv1.CurrentRow.Cells[e.ColumnIndex].Value; } else { Dgv1.CurrentRow.Cells[e.ColumnIndex-1].Value = 0; } }
                my.cn.Open();
                if (Dgv1.Columns[e.ColumnIndex].Name == "idisp")
                    my.sc.CommandText = "update tPlanSm set idisp = " + Dgv1.CurrentRow.Cells["idisp"].Value.ToString() + " where idplansm = " + Dgv1.CurrentRow.Cells["idplansm"].Value.ToString();
                if (i > 11 && i < 15)
                my.sc.CommandText = "update tPlanSm set planbaz = " + Dgv1.CurrentRow.Cells["planbaz"].Value.ToString().Replace(",", ".") + ", plantek = " + Dgv1.CurrentRow.Cells["plantek"].Value.ToString().Replace(",", ".") + ", i1 = " + Dgv1.CurrentRow.Cells["i1"].Value.ToString().Replace(",", ".")
                    + " where idplansm = " + Dgv1.CurrentRow.Cells["idplansm"].Value.ToString();
                if (i > 14 && i < 18)
                    my.sc.CommandText = "update tPlanSm set planobbaz = " + Dgv1.CurrentRow.Cells["planobbaz"].Value.ToString().Replace(",", ".") + ", planobtek = " + Dgv1.CurrentRow.Cells["planobtek"].Value.ToString().Replace(",", ".") + ", i2 = " + Dgv1.CurrentRow.Cells["i2"].Value.ToString().Replace(",", ".")
                        + " where idplansm = " + Dgv1.CurrentRow.Cells["idplansm"].Value.ToString();
                if (i > 17 && i < 21)
                    my.sc.CommandText = "update tPlanSm set planPrbaz = " + Dgv1.CurrentRow.Cells["planprbaz"].Value.ToString().Replace(",", ".") + ", planprtek = " + Dgv1.CurrentRow.Cells["planprtek"].Value.ToString().Replace(",", ".") + ", i3 = " + Dgv1.CurrentRow.Cells["i3"].Value.ToString().Replace(",", ".")
                        + " where idplansm = " + Dgv1.CurrentRow.Cells["idplansm"].Value.ToString();
                my.sc.ExecuteScalar();
                my.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void Dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            my.cn.Open();
            my.sc.CommandText = " exec sUpVidRab " + Dgv2.CurrentRow.Cells["IdPlanVidWrk"].Value.ToString() + "," 
                + Dgv2.CurrentRow.Cells["VolEnt"].Value.ToString().Replace(",", ".")  ;
            double vol = (double)my.sc.ExecuteScalar();
            my.cn.Close();
            Dgv2.CurrentRow.Cells["ostfo"].Value = vol;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = " exec sPlanRecalc " + idplan.ToString() + "," + i1.Text + "," + i2.Text + "," + i3.Text;
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            ObnPlanSmeti();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NMPlan.Focus();
            DataView dv = new DataView();
            dv.Table = ds.Tables[0]; 
            ModOffice.TP(idplan,this,dv);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            NMPlan.Focus();
            ModOffice.TPRep(idplan, this);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {   ObnVidRab(0);
            ObnPlanSmeti();
        }



        private void IdOSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WithOpen) { return; }
            toolStripButton5_Click(null, null);
        }

        private void rbosr_CheckedChanged(object sender, EventArgs e)
        {
            IdOSR.Visible = rbosr.Checked;
            toolStripButton5_Click(null, null);
        }

        private void Dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Dgv1.Rows[e.RowIndex].Cells["NM"].Value.ToString() == "Незавершенка")
            {
                Dgv1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
                Dgv1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void IdEntpr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
