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
    public partial class frmLSSmeti : Form
    {
        DataView dv1;
        public int ProjID; public int LSTitleID; public int idsm; int LSStrTitleID;
        public frmLSSmeti()
        {
            InitializeComponent();
            Dgv1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);


        }
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
         {
             Font ft = new Font(e.CellStyle.Font, FontStyle.Bold);
             if (e.RowIndex == this.Dgv1.NewRowIndex && e.ColumnIndex < 4) { e.PaintBackground(e.CellBounds, false); e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds); e.Graphics.DrawString("", this.Dgv1.Font, Brushes.Black, e.CellBounds.Left + 2, e.CellBounds.Top + 2); e.Handled = true; }
             if (e.RowIndex == this.Dgv1.NewRowIndex && e.ColumnIndex == 4) { e.PaintBackground(e.CellBounds, false); e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds); e.Graphics.DrawString("Итого:", ft, Brushes.Black, e.CellBounds.Left + 2, e.CellBounds.Top + 2); e.Handled = true; }
             if (e.RowIndex == this.Dgv1.NewRowIndex && e.ColumnIndex >4)
             {
                 e.PaintBackground(e.CellBounds, false);

                 //e.PaintBackground(e.CellBounds, true);
                 //e.PaintContent(e.CellBounds);
                 //Rectangle rc = e.CellBounds;
                 //rc.Inflate(-2, -2);
                 //rc.Offset(-1, -1);

                 e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                 //StringFormat sf = new StringFormat();

                 //sf.Alignment = StringAlignment.Center;
                 //StringFormat sf = new StringFormat();

                 //e.Paint(e.CellBounds, e.PaintParts);
                 e.CellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                 
                 e.Graphics.DrawString(String.Format("{0,22:0,0.###}", dv1.Table.Compute("Sum([" + dv1.Table.Columns[e.ColumnIndex].ColumnName + "])", "")), ft, Brushes.Black, e.CellBounds.Left + 2, e.CellBounds.Top + 2);
                 e.CellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                  e.Handled = true;
            }
        }

        private void frmLSSmeti_Load(object sender, EventArgs e)
        {
            spisok();
            foreach (DataGridViewColumn col in Dgv1.Columns)
            {
                if (col.ValueType.Name == "Double")
                {
                    //col.DefaultCellStyle.Format = "### ### ##0.000"
;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }
                if (col.ValueType.Name == "Int64")
                {
                    col.DefaultCellStyle.Format = "### ### ##0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }
            }
            //TotalSum();
        }

        private void spisok()
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds1 = new DataSet();

                my.sc.CommandTimeout = 30000;
                sel = "exec smr.dbo.sA0SmString " + ProjID.ToString() + "," + LSTitleID.ToString();
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                ds1.Clear();
                Dgv1.DataSource = null;
                //if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv1.DataSource = dv1;

                WindowState = FormWindowState.Maximized;
                my.cn.Close();
               my.naimDG("0", Dgv1,"0,50,200,400,50");

                Dgv1.AllowUserToDeleteRows = false;
                Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;

                Cursor = Cursors.Default;
                if (Dgv1.Rows.Count > 1)
                {
                    LSStrTitleID = (int)Dgv1.Rows[0].Cells[0].Value;
                    spisokActs();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 & e.RowIndex < Dgv1.RowCount - 1)
            {
                LSStrTitleID = (int)Dgv1.Rows[e.RowIndex].Cells[0].Value;
                spisokActs();
            }

        }
        private void spisokActs()
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds1 = new DataSet();

                my.sc.CommandTimeout = 30000;
                sel = "exec smr.dbo.sA0ActsPozString  " + ProjID.ToString() + "," + LSTitleID.ToString() + "," + LSStrTitleID.ToString();
                my.sc.CommandText = sel;
                my.sc.Connection = my.cn;
                my.cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(my.sc);

                ds1.Clear();
                Dgv2.DataSource = null;
                //if (Dgv1.Columns.Count > 0) Dgv1.Columns.Remove("ButtonColumnName");
                da.Fill(ds1);

                DataView dv2 = new DataView();
                dv2.Table = ds1.Tables[0];
                Dgv2.DataSource = dv2;

                my.cn.Close();
                my.naimDG("0", Dgv2, "");
                Dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Dgv2.AllowUserToAddRows = false;
                Dgv2.AllowUserToDeleteRows = false;
                Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
                Cursor = Cursors.Default;

                //TotalSum();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }










    }
}
