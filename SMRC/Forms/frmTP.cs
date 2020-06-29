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
    public partial class frmTP : Form
    {
        DataView dv; 
        public frmTP()
        {
            InitializeComponent();
        }

        private void frmTP_Load(object sender, EventArgs e)
        {
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            //Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.WindowState = FormWindowState.Maximized;
            spisok (0);
        }

        public void spisok(int identpr)
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds1 = new DataSet();

                my.sc.CommandTimeout = 30000;
                sel = "exec Grafik.dbo.sTPAll  " + identpr.ToString() ;
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                ds1.Clear();
                Dgv1.DataSource = null;
                //if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                dv = new DataView();
                dv.Table = ds1.Tables[0];
                Dgv1.DataSource = dv;
                my.headStr = dv[0]["NMCol"].ToString();
                my.naimDG(my.headStr, Dgv1, dv[0]["WCol"].ToString());
                 my.cn.Close();
                 ucFilter1.UCFilt(dv, Dgv1, UCFilter.UCFilter.VidObj.DataGridView, my.headStr);
                //Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                lCount.Text = "Всего: " + dv.Count.ToString();
                Cursor = Cursors.Default;

            foreach ( DataGridViewColumn col in Dgv1.Columns)
                {
                if (col.Index <=12)
                {
                    col.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else if (col.Index <= 17)
                {
                    col.DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else if (col.Index <=22 )
                {
                    col.DefaultCellStyle.BackColor = Color.LightYellow;
                }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex <= 12) { e.Cancel = true; }
            else if (Dgv1.CurrentRow.Cells["Nomer"].Value.ToString() == "") { MessageBox.Show("Не указан номер сметы!"); e.Cancel = true; }
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //string NMTable = "";
            ////if (NMGrafik1.SelectedValue.ToString() == "1") { NMTable = "Grafik.dbo.tTask"; } else { NMTable = "Grafik.dbo.tTaskWrk"; }
            //NMTable = "Grafik.dbo.tTPEntpr";
            //if (Dgv1.CurrentRow.Cells["Nomer"].Value.ToString() == "") { MessageBox.Show("Не указан номер сметы!"); return; }
            if (my.IsNumeric(Dgv1.Columns[e.ColumnIndex].Name.Substring(0,1)))
            {
                int identpr;
                int vibor;
                string dbeg; string dfin;
                
                identpr = my.Val(Dgv1.Columns[e.ColumnIndex].Name);
                vibor = ((bool)Dgv1.CurrentRow.Cells[identpr.ToString()].Value ? 1 : 0);
                dbeg = (Dgv1.CurrentRow.Cells[identpr.ToString() + "beg"].Value != System.DBNull.Value ? "'" + Dgv1.CurrentRow.Cells[identpr.ToString() + "beg"].Value.ToString() + "'" : "null");
                dfin = (Dgv1.CurrentRow.Cells[identpr.ToString() + "fin"].Value != System.DBNull.Value ? "'" + Dgv1.CurrentRow.Cells[identpr.ToString() + "fin"].Value.ToString() + "'" : "null");
                my.sc.CommandText = "exec Grafik.dbo.sUpTPEntpr " + identpr + ",'" + Dgv1.CurrentRow.Cells["Nomer"].Value + "'," + vibor.ToString() + "," + dbeg + "," + dfin + ",'" + my.Login + "'";
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
            }


        }
    }
}
