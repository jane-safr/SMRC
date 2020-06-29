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
    public partial class frmPlanSmA0 : Form
    {
        string szap1; int nbut1; string head; string width1; DataView dv;
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        public frmPlanSmA0()
        {
            
            InitializeComponent();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            my.Nbut = 18;
            my.Szap = ""; //" and PeriodKS2 = '" + my.Uper + "'";
            frmSprDGV fr = new frmSprDGV();
            fr.Withup = false;
            fr.Tag = my.Nbut;
            fr.Pform = this;
            fr.Show();
        }
        public void spisok()
        {
            try
            {
                szap1 = " and PeriodKS2 = '" + my.Uper + "'";
                string sel = my.FilterSel(nbut1, this, my.sconn, szap1);

                SqlDataAdapter da = new SqlDataAdapter("set language 'русский' " + sel, my.sconn);
               dv = new DataView();
               DataSet ds = new DataSet();
               da.Fill(ds);
                dv.Table = ds.Tables[0];
                Dgv1.DataSource = dv;
                my.naimDG(my.headStr, Dgv1, my.widthStr);
                head = my.headStr;
                width1 = my.widthStr;
                Cursor = Cursors.Default;
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();
                //Dgv1.Columns["periodks2"].DefaultCellStyle.Format = "##.##.####";
                //Dgv1.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
                Dgv1.Columns["periodks2"].DefaultCellStyle.ForeColor = Color.Blue;
                Dgv1.Columns["prim"].DefaultCellStyle.ForeColor = Color.Blue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void frmPlanSmA0_Load(object sender, EventArgs e)
        {
            Dgv1.AllowUserToAddRows = false;
            nbut1 = 214;

            spisok();
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0) return;
            if (Dgv1.SelectedRows.Count == 0) Dgv1.CurrentRow.Selected = true;

            if (MessageBox.Show("Удалить выделенные сметы?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Int32 MinNomStr = 777;
                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    MinNomStr = selrow.Index;
                    my.cn.Open();
                    my.sc.ExecuteScalar();
                    my.sc.CommandText = "delete from tPlanSmA0 where IdPlanSmA0 = " + selrow.Cells[0].Value.ToString();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                }
                spisok();
                if (MinNomStr > 1) Dgv1.CurrentCell = Dgv1.Rows[MinNomStr - 1].Cells[2];
            }


        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = "UPDATE tPlanSmA0 SET  PeriodKS2 = '" + Dgv1.Rows[e.RowIndex].Cells["PeriodKS2"].Value + "',Prim = '" + Dgv1.Rows[e.RowIndex].Cells["Prim"].Value + "' WHERE IdPlanSmA0 = " + Dgv1.Rows[e.RowIndex].Cells["IdPlanSmA0"].Value;
                my.sc.ExecuteScalar();
                my.cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка!" + ex.Message);
            }
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor == Color.Blue)
            { Dgv1.BeginEdit(true); }
            else
            { Dgv1.EndEdit(); }
        }

        private void Dgv1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    Dgv1.CurrentCell = Dgv1.Rows[e.RowIndex].Cells["PeriodKS2"];
            //}
            //catch
            //{ }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            my.Szap = Dgv1.Rows[Dgv1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            if (!my.isFormInMdi("frmCapSm", (int)Dgv1.Rows[Dgv1.CurrentCell.RowIndex].Cells[0].Value, my.MDIForm))
            {
                frmCapSm fr = new frmCapSm();
                fr.idsm = (int)Dgv1.Rows[Dgv1.CurrentCell.RowIndex].Cells["idsm"].Value;
                //fr.MdiParent = my.MDIForm;
                fr.Tag = fr.idsm;
                fr.ShowDialog();
                //spisok();

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmReps fr = new frmReps();
            my.Ustr = "";
            my.Szap = "'" + my.Uper + "'";
            my.Nbut = 215;
            fr.MdiParent = my.MDIForm;
            my.Pform = this;
            fr.Show();
        }

        private void tsFilter_Click(object sender, EventArgs e)
        {
            try
            {
                String s2 = "";
                if (tstText.Text == "") { dv.RowFilter = ""; tslCount.Text = "Всего " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString(); return; }

                if (!Dgv1.Columns[System.Convert.ToInt32(tsFilter.Tag.ToString())].ValueType.IsValueType)
                {
                    s2 = dv.Table.Columns[System.Convert.ToInt32(tsFilter.Tag.ToString())].ColumnName + " like '%" + tstText.Text + "%'";
                }
                else
                { s2 = dv.Table.Columns[System.Convert.ToInt32(tsFilter.Tag.ToString())].ColumnName + " = " + tstText.Text; }

                dv.RowFilter = s2;
                tslCount.Text = "Всего " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Необходимо поставить курсор на ячейку, к которой надо применить фильтр!");

                //throw;
            }
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = tstText.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(Dgv1, m_searchInfo);
            Dgv1.CurrentRow.Selected = true;
        }

        private void Dgv1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //tsFilter.Tag = Dgv1.CurrentCell.ColumnIndex;
                //label1.Text = "фильтр по колонке " + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].HeaderText;
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsFilter.Tag = Dgv1.CurrentCell.ColumnIndex;
            label1.Text = "фильтр по колонке " + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].HeaderText;
        }



        private void tstText_DoubleClick(object sender, EventArgs e)
        {
            tstText.Text = "";
            tsFilter_Click(null, null);
        }
    }
}
