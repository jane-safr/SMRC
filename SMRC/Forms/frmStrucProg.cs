using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC.Forms
{
    public partial class frmStrucProg : Form
    {
        DataSet ds;
        SqlDataAdapter da; DataView dv; bool WithLoad; bool WithUp; bool AccessPodtv;
        //clsSearchInfo m_searchInfo = new clsSearchInfo();
        public frmStrucProg()
        {
            InitializeComponent();
        }

        public void spisok()
        {
           
            if (WithLoad || idStrucZag.SelectedValue == null) return;
            if (idPredpr.SelectedValue == null) { MessageBox.Show("Выберите предприятие!"); return; }
            String sel;

            Cursor = Cursors.WaitCursor;

            my.sc.CommandText = my.FilterSel(217, this, my.sconn, " and idpredpr =  " + idPredpr.SelectedValue.ToString() + " and idStrucZag =  " + idStrucZag.SelectedValue.ToString());
            my.cn.Open();
            SqlDataReader DRd = my.sc.ExecuteReader();
            DRd.Read();
            tYear.Text = DRd["year"].ToString();
            Podtv.Checked = (bool)DRd["Podtv"];
            if ((int)DRd["idUsPodtv"] != 0) FIO.Text = (string)DRd["FIO"];
            DRd.Close();
            //if (Podtv.Checked) 
            //{ Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically; }
            //else
            //{ Dgv1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2; }
            ds = new DataSet();
            ds.Clear();
            sel = my.FilterSel(216, this, my.sconn, " and idpredpr =  " + idPredpr.SelectedValue.ToString() + " and year = " + tYear.Text + " and idStrucZag =  " + idStrucZag.SelectedValue.ToString());
            //my.cn.Open();
            da = new SqlDataAdapter(sel,my.cn);
            da.Fill(ds);
            my.cn.Close();
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            WithUp = false;
            Dgv1.DataSource = null;
            Dgv1.Columns.Clear();
            Dgv1.DataSource = dv;
            Dgv1.VLadd("idPO", "ПО", "SELECT     IdEntpr, shNMEntpr FROM         Sprav.dbo.tsEntpr WHERE     (Sprav.dbo.isb(Bits, 3) = 1)  ORDER BY shNMEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 5);
            Dgv1.VLadd("idStrucNM", "ПО", "SELECT     TOP (100) PERCENT dbo.tStrucNM.idStrucNM, 'ГП ' + Sprav.dbo.tsEntpr.shNMEntpr + ' ' + dbo.tStrucNM.NMStruc AS NMStruc FROM         dbo.tStrucNM INNER JOIN    Sprav.dbo.tsEntpr ON dbo.tStrucNM.idgp = Sprav.dbo.tsEntpr.IdEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 4);
            foreach (DataGridViewColumn col in Dgv1.Columns)
            {
                if (col.ValueType.Name == "Integer")
                {
                    col.DefaultCellStyle.Format = "# ###";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }
            }
            my.naimDG(my.headStr, Dgv1, my.widthStr);
            Cursor = Cursors.Default;
            WithUp = true;
        }



        private void ToolStripButton9_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = "exec InsStruc " + idPredpr.SelectedValue.ToString() + "," + tYear.Text;
            my.sc.ExecuteScalar();
            my.cn.Close();
            spisok();

        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void frmStrucProg_Load(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = "select id_group from dostup.dbo.usersingroups where id_group = 51 and id_user = " + my.Id_us;
            if (my.sc.ExecuteScalar() == null)
            { AccessPodtv = false; }
            else { AccessPodtv = true; }
            my.cn.Close();

            WithLoad = true; WithUp = false;
            my.FillDC(idPredpr, 48, " ");
            if (my.identpr != 0) {
                string zap = idPredpr.SelectedValue.ToString();

                idPredpr.SelectedValue = my.identpr; 
                if (idPredpr.SelectedValue ==null) {idPredpr.SelectedValue = zap;}
            }
            tYear.Text = DateTime.Today.Year.ToString();
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            WithLoad = false;
            WindowState = FormWindowState.Maximized;
            spisok();
            WithUp = true;

        }

        private void idPredpr_SelectedValueChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idPredpr.SelectedValue)) { my.FillDC(idStrucZag, 49, " and idPredpr = " + idPredpr.SelectedValue); }
            //spisok();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            my.Nbut = 26;
            my.Szap = ""; 
            frmSprDGV fr = new frmSprDGV();
            fr.Withup = false;
            fr.Tag = my.Nbut;
            fr.Pform = this;
            fr.ShowDialog();
            my.FillDC(idPredpr, 48, " ");
            idPredpr_SelectedValueChanged(null, null);

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            spisok();
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Dgv1.Rows[e.RowIndex].Cells["SumSt"].Value = (double)Dgv1.Rows[e.RowIndex].Cells["Sum91Or"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["StObor91"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["SumProchZ91"].Value;
            try
            {
            GC.Collect();
            my.cn.Open();
            //if (Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "idPO")
            //{ }
            //else
            //{
                //my.sc.CommandText = @"UPDATE [smr].[dbo].[tStrucProg]   SET  " + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name + " =  " + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + ", update_date = '" + DateTime.Today.ToString() + "',update_user =" + my.Id_us + " WHERE [idStrucProg] = " + Dgv1.Rows[e.RowIndex].Cells["idStrucProg"].Value;
                my.sc.CommandText = @" exec UpdStruc '" + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name + "' ,  " + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "," + my.Id_us + " ," + Dgv1.Rows[e.RowIndex].Cells["idStrucProg"].Value;
                SqlDataReader DRd = my.sc.ExecuteReader();
                DRd.Read();
                Dgv1.Rows[e.RowIndex].Cells["ngp"].Value = (int)DRd["ngp"];
                Dgv1.Rows[e.RowIndex].Cells["nobj"].Value = (int)DRd["nobj"];
                DRd.Close();
            //}
            //my.sc.ExecuteScalar();
            my.cn.Close();
            }
            catch ( Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }


        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Dgv1.BeginEdit(true);
            //if (!Withup) { return; }
            if (WithUp & !Podtv.Checked) { Dgv1.BeginEdit(true); }
        }

        private void idPredpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (my.IsNumeric( idPredpr.SelectedValue) ) { my.FillDC(idStrucZag, 49, " and idPredpr = " + idPredpr.SelectedValue); }
            //spisok();
        }


        private void idStrucZag_SelectedValueChanged(object sender, EventArgs e)
        {
            spisok();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = "exec InsStrucPO " + idStrucZag.SelectedValue.ToString() ;
            my.sc.ExecuteScalar();
            my.cn.Close();
            spisok();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите скопировать данные в план по КС-3(КС-2)? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                my.sc.CommandText = "exec InsStrucPO " + idStrucZag.SelectedValue.ToString() + ",1," + my.Id_us;
                my.sc.ExecuteScalar();
                my.cn.Close();
                MessageBox.Show("Готово!");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
            if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                my.cn.Open();
                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    my.sc.CommandText = "delete from tStrucProg where idStrucProg  = " + selrow.Cells["idStrucProg"].Value;
                    my.sc.ExecuteScalar();
                }
                my.cn.Close();
                spisok();
            }
        }
        private void Save()
        { 
            my.cn.Open();
            my.sc.CommandText = "update tstruczag set year = " + tYear.Text + ",Podtv =" + (Podtv.Checked ? 1 : 0).ToString() + ", idUsPodtv =" + (Podtv.Checked ? my.Id_us.ToString() : "0") + " where idstruczag = " + idStrucZag.SelectedValue.ToString();
            my.sc.ExecuteScalar();
            my.cn.Close();
        }
        private void frmStrucProg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
            ds = null;
            dv = null;
            WithUp = false;
            Dgv1.DataSource = null;
            Dgv1 = null;
        }

        private void Podtv_CheckedChanged(object sender, EventArgs e)
        {
            if (Podtv.Checked)
            {
                FIO.Text = my.Id_UsName;
            }
            else { FIO.Text = ""; }
        }

        private void Podtv_Click(object sender, EventArgs e)
        {
            if (!AccessPodtv) { Podtv.Checked = !Podtv.Checked; MessageBox.Show("У Вас нет прав для выполнения этой операции!", "Внимание!") ; return; } 
        }

        private void idStrucZag_Click(object sender, EventArgs e)
        {
            if (!WithLoad & idStrucZag.SelectedValue != null) { Save(); }
        }
    }
}
