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
    public partial class frmLinkWRK : Form
    {
        public frmLinkWRK()
        {
            InitializeComponent();
        }

        private void frmLinkWRK_Load(object sender, EventArgs e)
        {
            my.FillDC(idWRK, 71, " and idstatusw <> 2");
            my.FillDC(idEntpr, 7, " and     (sprav.dbo.isb(Bits, 1) > 0) OR (sprav.dbo.isb(Bits, 3) > 0) ");
            Dgv1.AllowUserToAddRows = false;
        }

        private void idWRK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.Val(idWRK.SelectedValue.ToString()) != 0)
            {
                my.sc.CommandText = "select isnull(NMWrk,'') as NMWrk from Sprav.dbo.tsW where idw =" + idWRK.SelectedValue.ToString();
                my.cn.Open();
                label2.Text = my.sc.ExecuteScalar().ToString();
                my.cn.Close();
                spisok();
            }
            

        }

        private void spisok()
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds1 = new DataSet();

                sel = my.FilterSel(708, null, my.sconn, " and idparent = " + idWRK.SelectedValue.ToString()); 
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                ds1.Clear();
                Dgv1.DataSource = null;
                da.Fill(ds1);

                DataView dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv1.DataSource = dv1;

                my.naimDG(my.headStr, Dgv1, my.widthStr);
                my.cn.Close();

                Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Cursor = Cursors.Default;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idEntpr.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Выберите предприятие!");
                return;
            }
            if (my.Val(idWRK.SelectedValue.ToString()) != 0)
            {
                my.sc.CommandText = "exec Grafik.dbo.sAddChildWRKs " + idWRK.SelectedValue.ToString() + "," + idEntpr.SelectedValue.ToString();
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
                spisok();
            }
        }

        private void Dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {

                    if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }


                 //NMTable = "";
               string NMTable = "Sprav.dbo.tsW";

                if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
                my.cn.Open();
                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    my.sc.CommandText = "exec Grafik.dbo.sDelChildWRK " + selrow.Cells["idW"].Value ;
                    my.sc.ExecuteScalar();

                }
                my.cn.Close();

            }

            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
                e.Cancel = true;
            } 
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex != 3)
                {

                    string NMTable = "";
                    NMTable = "Sprav.dbo.tsW";
                    my.sc.CommandText = "UPDATE " + NMTable + " SET " + Dgv1.Columns[e.ColumnIndex].Name + " = '" + Dgv1.CurrentCell.Value + "' WHERE (idW =" + Dgv1.CurrentRow.Cells["idW"].Value + ")";
                    my.cn.Open();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                }
                
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            } 
        }

        private void Dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3) { e.Cancel = true; }
        }
    }
}
