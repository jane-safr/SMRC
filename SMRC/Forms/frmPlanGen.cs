using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmPlanGen : Form
    {
        string oldkodir = "";
        public frmPlanGen()
        {
            InitializeComponent();
        }

        private void frmPlanGen_Load(object sender, EventArgs e)
        {
            my.FillDC(idComplex, 1, "");
            idComplex.SelectedValue = 19;
            spisok();
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            //Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

        }
        public void spisok()
        {
            if (my.IsNumeric(idComplex.SelectedValue))
            {
                Dgv1.EndEdit();
                DataSet ds = new DataSet();ds.Clear();
                ds = my.GetDS("set language русский; exec sSelPlanGen  " + idComplex.SelectedValue.ToString() + " , '" + my.Uper + "'", my.sconn);
                
                Dgv1.DataSource = ds.Tables[0];
                my.naimDG("Кодировка, Расшифровка,Год баз.,Год тек.,Кв баз.,Кв тек.,Месяц баз.,Месяц тек.", Dgv1, "");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = "set language русский; exec sInsPlanGen '" + my.Uper + "'," + idComplex.SelectedValue.ToString();
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            spisok();
        }

        private void idComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            spisok();
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           Dgv1.BeginEdit(true);
           if (e.ColumnIndex == 0)
           {
               oldkodir = Dgv1.Rows[e.RowIndex].Cells["kodir"].Value.ToString();
           }
            Ras(e);
            
        }
        private void Ras(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 & Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
                try
                {
                    my.cn.Open();
                    my.sc.CommandText = "select dbo.fRaskodir('" + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "')";
                    Dgv1.Rows[e.RowIndex].Cells["nm"].Value = my.sc.ExecuteScalar();
                    my.cn.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    if ((int)my.cn.State == 1) { my.cn.Close(); }
                }
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) return;
            try
            {


                my.cn.Open();
                if (e.ColumnIndex == 0)
                {
                    my.sc.CommandText =  "set language русский; exec sUpPlanGen " + idComplex.SelectedValue.ToString() + " ,'" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "','" + my.Uper.ToString() + "', 0," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["yb"].Value) ? Dgv1.Rows[e.RowIndex].Cells["yb"].Value : 0) + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["yt"].Value) ? Dgv1.Rows[e.RowIndex].Cells["yt"].Value : 0) +",'" + oldkodir + "'";
                        //"update tPlanGen set Kodir = '" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "' where  idcomplex = " + idComplex.SelectedValue.ToString() + " and period = '" + my.Uper.ToString() + "' and kodir = '" + oldkodir + "'";
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    Ras(e);
                }
                Int16 i = 3;//year
                if (e.ColumnIndex >= 2)
                {
                    int vidperiod = 0;
                    if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        vidperiod = 1;
                        my.sc.CommandText = "set language русский; exec sUpPlanGen " + idComplex.SelectedValue.ToString() + " ,'" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "','" + my.Uper.ToString() + "', " + vidperiod + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["yb"].Value) ? Dgv1.Rows[e.RowIndex].Cells["yb"].Value : 0) + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["yt"].Value) ? Dgv1.Rows[e.RowIndex].Cells["yt"].Value : 0);

                    }
                    if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        vidperiod = 2;
                        my.sc.CommandText = "set language русский; exec sUpPlanGen " + idComplex.SelectedValue.ToString() + " ,'" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "','" + my.Uper.ToString() + "', " + vidperiod + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["qb"].Value) ? Dgv1.Rows[e.RowIndex].Cells["qb"].Value : 0) + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["qt"].Value) ? Dgv1.Rows[e.RowIndex].Cells["qt"].Value : 0);

                    }
                    if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        vidperiod = 3;
                        my.sc.CommandText = "set language русский; exec sUpPlanGen " + idComplex.SelectedValue.ToString() + " ,'" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "','" + my.Uper.ToString() + "', " + vidperiod + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["mb"].Value) ? Dgv1.Rows[e.RowIndex].Cells["mb"].Value : 0) + "," + (my.IsNumeric(Dgv1.Rows[e.RowIndex].Cells["mt"].Value) ? Dgv1.Rows[e.RowIndex].Cells["mt"].Value : 0);

                    }
                    //my.sc.CommandText = "set language 'русский'; exec sUpPlanGen " + idComplex.SelectedValue.ToString() + " ,'" + Dgv1.Rows[e.RowIndex].Cells["kodir"].Value + "','" + my.Uper.ToString() + "', " + vidperiod + "," + Dgv1.Rows[e.RowIndex].Cells["planbaz"].Value + "," + Dgv1.Rows[e.RowIndex].Cells["plantek"].Value;
                    //"update tPlanGen set PlanBaz = '" + Dgv1.Rows[e.RowIndex].Cells["yb"].Value + "' where  idPlanGen = " + Dgv1.Rows[e.RowIndex].Cells["idPlanGen"].Value + " and kodir <> '" + Dgv1.Rows[e.RowIndex].Cells["idPlanGen"].Value + "'";
                    my.sc.ExecuteScalar();
                    my.cn.Close();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }


        private void frmPlanGen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dgv1.Update();
            Dgv1.EndEdit();
            Dgv1.DataSource = null;
            Dgv1 = null;
             //
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = "set language русский; exec sDelPlanGen '" + my.Uper + "'," + idComplex.SelectedValue.ToString() + ",'" + Dgv1.CurrentRow.Cells["kodir"].Value + "'";
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            spisok();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            my.sc.CommandText = "set language русский; exec R_SvodnAll '01.06." + my.Uper.Year.ToString() + "','" + my.Uper + "',0, 0,0,3,''," + idComplex.SelectedValue.ToString() ;
            my.cn.Open();
            my.sc.CommandTimeout = 120;
            my.sc.ExecuteNonQuery();
            my.cn.Close();
            Cursor = Cursors.Default;
            spisok();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (my.IsNumeric(tInd.Text) && tInd.Text.ToString() != "0"  )
            {
                for (int i = 0; i < Dgv1.Rows.Count; i++)
                {
                    double k = Convert.ToDouble(tInd.Text.ToString());
                    Dgv1["yb", i].Value = Convert.ToInt64(Dgv1["yt", i].Value) / k;
                    Dgv1["qb", i].Value = Convert.ToInt64(Dgv1["qt", i].Value) / k;
                    Dgv1["mb", i].Value = Convert.ToInt64(Dgv1["mt", i].Value) / k;
                    DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(2, i);
                    Dgv1_CellEndEdit(Dgv1,e1);
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(4, i);
                    Dgv1_CellEndEdit(Dgv1, e2);
                    DataGridViewCellEventArgs e3 = new DataGridViewCellEventArgs(6, i);
                    Dgv1_CellEndEdit(Dgv1, e3);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (my.IsNumeric(tInd.Text) && tInd.Text.ToString() != "0")
            {
                for (int i = 0; i < Dgv1.Rows.Count; i++)
                {
                    double k = Convert.ToDouble(tInd.Text.ToString());
                    Dgv1["yt", i].Value = Convert.ToInt64(Dgv1["yb", i].Value) * k;
                    Dgv1["qt", i].Value = Convert.ToInt64(Dgv1["qb", i].Value) * k;
                    Dgv1["mt", i].Value = Convert.ToInt64(Dgv1["mb", i].Value) * k;
                    DataGridViewCellEventArgs e1 = new DataGridViewCellEventArgs(2, i);
                    Dgv1_CellEndEdit(Dgv1, e1);
                    DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(4, i);
                    Dgv1_CellEndEdit(Dgv1, e2);
                    DataGridViewCellEventArgs e3 = new DataGridViewCellEventArgs(6, i);
                    Dgv1_CellEndEdit(Dgv1, e3);
                }
            }
        }

        private void tInd_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                // Если это не цифра.
                if (!Char.IsDigit(e.KeyChar))
                {
                    // Запрет на ввод более одной десятичной точки.
                    if ((e.KeyChar != '.' || tInd.Text.IndexOf(".") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }

            }
        }

        private void tInd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
