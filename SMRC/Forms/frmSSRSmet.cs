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
    public partial class frmSSRSmet : Form
    {
        DataSet ds; SqlDataAdapter da;
        public frmSSRSmet()
        {
            InitializeComponent();
        }

        private void frmSSRSmet_Load(object sender, EventArgs e)
        {
                        my.FillDC(idOSR, 23, "");
            idOSR.SelectedValue = my.Nbut;
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
        }

        private void idOSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            if (my.IsNumeric(idOSR.SelectedValue))
            {
                my.FillDC(idChapter, 10, " and (idobj = 0 or idobj in (select idobj from sprav.dbo.tOsrObject where idOsr = " + idOSR.SelectedValue.ToString() + ")) ");
            }

        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv1.CurrentCell.OwningColumn.Name == "but")
                {
                    my.Nbut = 128;
                    //if (!my.isFormInMdi("frmSprDgv", my.Nbut, this))
                    //{
                    frmSprDGV fr = new frmSprDGV();
                    fr.Tag = (int)my.Nbut;
                    fr.Withup = false;
                    fr.MdiParent = my.MDIForm;
                    my.Szap = " and idsm = " + Dgv1.CurrentRow.Cells[0].Value.ToString();
                    fr.Show();
                }
                if (Dgv1.CurrentRow != null)
                {
                    my.cn.Open();
                    my.sc.CommandText = my.FilterSel(126, this, my.sconn, " and sprav.dbo.tsmeti.idsm = " + Dgv1.CurrentRow.Cells[0].Value.ToString());
                    SqlDataReader sd = my.sc.ExecuteReader();
                    while (sd.Read())
                    {

                        this.label12.Text = "Освоено по смете(91г): Стр.раб. " + sd["VSr91"].ToString() + ", Монт.раб. " + sd["VMr91"].ToString() + ", Обор.  " + sd["VOb91"].ToString() + ", Пр.раб. " + sd["VPr91"].ToString() + ", Итого " + sd["V91"].ToString();
                    }
                    sd.Close();
                    my.cn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                //throw;
            }
                //MessageBox.Show(Dgv1.CurrentRow.Cells[2].Value.ToString());
            //}
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!my.IsNumeric(idOSR.SelectedValue)) return;
                String sel;

                Cursor = Cursors.WaitCursor;
                ds = new DataSet();
                ds.Clear();
                sel = my.FilterSel(124, this, my.sconn, " and idosr =  " + idOSR.SelectedValue.ToString() + ((int)idChapter.SelectedValue != 0 ? " and idobj = " + idChapter.SelectedValue.ToString() : ""));

                da = new SqlDataAdapter();
                DaDs dads1 = new DaDs();
                dads1.DaInd(0, sel, my.sconn, "", ds, true);
                ds.Tables[0].Columns.Add("SumSt", typeof(Double));
                da = dads1.Da[0];
                da.UpdateCommand.CommandText = "";//"UPDATE [sprav].[dbo].[tsmeti] SET  [ndoc] = @p2, [nomer] = @p3, [nmsmeti] = @p4, [sum91or] = @p5, [summr91] = @p6, [stobor91] = @p7, [sumprochz91] = @p8 WHERE [idsm] = @p9";
                da.InsertCommand.CommandText = "";
                da.DeleteCommand.CommandText = "";
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                Dgv1.DataSource = null;
                Dgv1.Columns.Clear();
                Dgv1.DataSource = dv;
                foreach (DataGridViewColumn col in Dgv1.Columns)
                {
                    if (col.ValueType.Name == "Double")
                    {
                        col.DefaultCellStyle.Format = "# ###";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    }
                }
                Dgv1.VLadd("IsSSR", "Входят в ССР", "SELECT     idIsSSR, NMIsSSR FROM  sprav.dbo.tsIsSSR", my.sconn, SMRC.DGVt.TypeVL.ComboBoxDropDown, 6);
                DataGridViewButtonColumn but = new DataGridViewButtonColumn();
                but.Name = "but";
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = System.Drawing.SystemColors.Control;

                but.DefaultCellStyle = cellStyle;

                Dgv1.Columns.Add(but);

                my.naimDG(my.headStr, Dgv1, my.widthStr);
                Double w = 0;
                for (int i = 0; i <= Dgv1.Columns.Count - 1; i++)
                { w = w + Dgv1.Columns[i].Width; }
                Width = (int)w + 50;
                Cursor = Cursors.Default;
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - 1).ToString();
                double Str = 0; double Mont = 0; double Obor = 0; double Proch = 0; double SumSt = 0;

                for (int i = 0; i < Dgv1.Rows.Count - 1; i++)
                {
                    Dgv1.Rows[i].Cells["SumSt"].Value = (double)Dgv1.Rows[i].Cells["Sum91Or"].Value + (double)Dgv1.Rows[i].Cells["StObor91"].Value + (double)Dgv1.Rows[i].Cells["SumProchZ91"].Value;
                    Str = Str + (double)Dgv1.Rows[i].Cells["Sum91Or"].Value - (double)Dgv1.Rows[i].Cells["SumMR91"].Value;
                    Mont = Mont + (double)Dgv1.Rows[i].Cells["SumMR91"].Value;
                    Obor = Obor + (double)Dgv1.Rows[i].Cells["StObor91"].Value;
                    Proch = Proch + (double)Dgv1.Rows[i].Cells["SumProchZ91"].Value;
                    SumSt = SumSt + (double)(Dgv1.Rows[i].Cells["SumSt"].Value == null ? 0.0 : Dgv1.Rows[i].Cells["SumSt"].Value);
                    Dgv1.EndEdit();
                }
                //my.Up(da, ds.Tables[0]);
                tStr91.Text = Str.ToString();
                tMont91.Text = Mont.ToString();
                tObor91.Text = Obor.ToString();
                tProch91.Text = Proch.ToString();
                tSumSt91.Text = SumSt.ToString();
                my.cn.Open();
                my.sc.CommandText = my.FilterSel(127, this, my.sconn, " and idosr  = " + idOSR.SelectedValue.ToString());
                SqlDataReader sd = my.sc.ExecuteReader();
                while (sd.Read())
                {
                    tStr.Text = sd["Str"].ToString();
                    tMont.Text = sd["Mont"].ToString();
                    tObor.Text = sd["Obor"].ToString();
                    tProch.Text = sd["Proch"].ToString();
                    tSumSt.Text = sd["SumSt"].ToString();

                }
                sd.Close();
                my.sc.CommandText = my.FilterSel(126, this, my.sconn, " and sprav.dbo.tsmeti.idosr  = " + idOSR.SelectedValue.ToString());
                sd = my.sc.ExecuteReader();
                while (sd.Read())
                {
                    tVSr91.Text = sd["VSr91"].ToString();
                    tVMr91.Text = sd["VMr91"].ToString();
                    tVPr91.Text = sd["VPr91"].ToString();
                    tVOb91.Text = sd["VOb91"].ToString();
                    tV91.Text = sd["V91"].ToString();
                    tOstSr.Text = Convert.ToString(Convert.ToDouble(tStr91.Text) - (int)sd["VSr91"]);
                    tOstMr.Text = Convert.ToString(Convert.ToDouble(tMont91.Text) - (int)sd["VMr91"]);
                    tOstPr.Text = Convert.ToString(Convert.ToDouble(tProch91.Text) - (int)sd["VPr91"]);
                    tOstOb.Text = Convert.ToString(Convert.ToDouble(tObor91.Text) - (int)sd["VOb91"]);
                    tOst.Text = Convert.ToString(Convert.ToDouble(tSumSt91.Text) - (int)sd["V91"]);
                }
                sd.Close();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                //throw;
            }

        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Dgv1.Rows[i].Cells["SumSt"].Value = (double)Dgv1.Rows[i].Cells["Sum91Or"].Value + (double)Dgv1.Rows[i].Cells["StObor91"].Value + (double)Dgv1.Rows[i].Cells["SumProchZ91"].Value;

                Dgv1.Rows[e.RowIndex].Cells["SumSt"].Value = (double)Dgv1.Rows[e.RowIndex].Cells["Sum91Or"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["StObor91"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["SumProchZ91"].Value ;
                GC.Collect();
                my.cn.Open();
                //my.Up(da, ds.Tables[0]);
                my.sc.CommandText = "UPDATE [sprav].[dbo].[tsmeti] SET  [ndoc] = '" + Dgv1.Rows[e.RowIndex].Cells["ndoc"].Value + "', [nomer] = '" + Dgv1.Rows[e.RowIndex].Cells["nomer"].Value + "', [nmsmeti] = '" + Dgv1.Rows[e.RowIndex].Cells["nmsmeti"].Value + "', [OsrTxt] = '" + Dgv1.Rows[e.RowIndex].Cells["OsrTxt"].Value + "', [sum91or] = " + Dgv1.Rows[e.RowIndex].Cells["sum91or"].Value + ", [summr91] = " + Dgv1.Rows[e.RowIndex].Cells["summr91"].Value + ", [stobor91] = " + Dgv1.Rows[e.RowIndex].Cells["stobor91"].Value + ", [sumprochz91] = " + Dgv1.Rows[e.RowIndex].Cells["sumprochz91"].Value + ", [IsSSR] = " + Dgv1.Rows[e.RowIndex].Cells[5].Value + " WHERE [idsm] = " + Dgv1.Rows[e.RowIndex].Cells["idsm"].Value;
                my.sc.ExecuteScalar();
                my.cn.Close();
                SumAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка!" + ex.Message);
            }
        }

        private void SumAll()
        {
            double Str = 0; double Mont = 0; double Obor = 0; double Proch = 0; double SumSt = 0;
            for (int i = 0; i < Dgv1.Rows.Count - 1; i++)
            {
                Str = Str + (double)Dgv1.Rows[i].Cells["Sum91Or"].Value - (double)Dgv1.Rows[i].Cells["summr91"].Value;
                Mont = Mont + (double)Dgv1.Rows[i].Cells["summr91"].Value;
                Obor = Obor + (double)Dgv1.Rows[i].Cells["StObor91"].Value;
                Proch = Proch + (double)Dgv1.Rows[i].Cells["SumProchZ91"].Value;
                SumSt = SumSt + (double)(Dgv1.Rows[i].Cells["SumSt"].Value == null ? 0.0 : Dgv1.Rows[i].Cells["SumSt"].Value);

            }
            tStr91.Text = Str.ToString();
            tMont91.Text = Mont.ToString();
            tObor91.Text = Obor.ToString();
            tProch91.Text = Proch.ToString();
            tSumSt91.Text = SumSt.ToString();
            //my.Up(da, ds.Tables[0]);
        }

        private void Dgv1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                my.Szap = "";
                my.Nbut = 58;
                frmSprDGV fr = new frmSprDGV();
                fr.Withup = false;
                fr.ShowDialog();
                string idcompl = idOSR.SelectedValue.ToString();
                my.FillDC(idChapter, 10, " and (idobj = 0 or idobj in (select idobj from sprav.dbo.tOsrObject where idOsr = " + idOSR.SelectedValue.ToString() + ")) ");
                if (my.IsNumeric(my.Szap))
                {
                    my.cn.Open();
                    my.sc.CommandText = " if not exists (select 1 from sprav.dbo.tOsrObject where idOsr = " + idChapter.SelectedValue.ToString() + " and idobj = " + my.Szap + "  ) insert into sprav.dbo.tOsrObject (idosr,idobj) values (" + idOSR.SelectedValue.ToString() + "," + my.Szap + ")";
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    my.FillDC(idChapter, 10, " and (idobj = 0 or idobj in (select idobj from sprav.dbo.tOsrObject where idOsr = " + idOSR.SelectedValue.ToString() + ")) ");

                    idChapter.SelectedValue = my.Szap; button1_Click(null, null);
                }
                else
                { idChapter.SelectedValue = idcompl; }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = " delete from sprav.dbo.tOsrObject  where idosr = " + idOSR.SelectedValue.ToString() + " and idobj = " + idChapter.SelectedValue.ToString();
                my.sc.ExecuteScalar();
                my.cn.Close();
                my.FillDC(idChapter, 10, " and (idobj = 0 or idobj in (select idobj from sprav.dbo.tOsrObject where idOsr = " + idOSR.SelectedValue.ToString() + ")) ");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                my.Szap = " and idosr = 0";
                my.Nbut = 124;
                frmSprDGV fr = new frmSprDGV();
                fr.Withup = false;
                fr.ShowDialog();
                string idcompl = idOSR.SelectedValue.ToString();
                if (my.IsNumeric(my.Szap))
                {
                    my.cn.Open();
                    my.sc.CommandText = " update  sprav.dbo.tsmeti set idosr = " + idOSR.SelectedValue.ToString() + " where idsm = " +my.Szap;
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    button1_Click(null, null);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = " update  sprav.dbo.tsmeti set idosr = 0  where idsm = " + Dgv1.CurrentRow.Cells["idsm"].Value.ToString();
            my.sc.ExecuteScalar();
            my.cn.Close();
            button1_Click(null, null);
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReps fr = new frmReps();
            my.Pform = this;
            my.Ustr = "";
            my.Szap = " and   idOsr = " + idOSR.SelectedValue.ToString() ;
            my.Nbut = 132;
            fr.MdiParent = my.MDIForm;
            fr.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}