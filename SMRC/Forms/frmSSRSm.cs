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
    public partial class frmSSRSm : Form
    {
        DataSet ds; SqlDataAdapter da; public  int nbut1;
        public frmSSRSm()
        {
           
            InitializeComponent();
        }

        private void frmSSRSm_Load(object sender, EventArgs e)
        {
            Text = "Сводный сметный расчет";
            my.FillDC(idComplex, 21, "");
            idComplex.SelectedValue = 0;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            Dgv1.DefaultCellStyle.WrapMode = (DataGridViewTriState)1;
        }

        private void idComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idComplex.SelectedValue))
            {
                my.FillDC(idChapter, 22, " and (idChapter = 0 or idChapter in (select idChapter from sprav.dbo.tComplexChapter where idComplex = " + idComplex.SelectedValue.ToString() + ")) ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                ds = new DataSet();
                ds.Clear();
                sel = my.FilterSel(123, this, my.sconn, " and idcomplexchapter in (select idcomplexchapter from Sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + ((int)idChapter.SelectedValue != 0 ? " and idchapter = " + idChapter.SelectedValue.ToString() : "") + ")");

                da = new SqlDataAdapter();
                DaDs dads1 = new DaDs();
                dads1.DaInd(0, sel, my.sconn, "", ds, true);
                ds.Tables[0].Columns.Add("SumSt", typeof(Double));
                da = dads1.Da[0];
                da.UpdateCommand.CommandText = "UPDATE [sprav].[dbo].[tsosr] SET [ordernom] = @p1, [osr] = @p2, [nmosr] = @p3, [str] = @p4, [mont] = @p5, [obor] = @p6, [proch] = @p7 WHERE [idosr] = @p8";
                da.InsertCommand.CommandText = "INSERT INTO [sprav].[dbo].[tsosr] ([ordernom], [osr], [nmosr], [str], [mont], [obor], [proch],[idcomplexchapter]) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7," + idcomplexchapter().ToString() + "); select   idosr,  ordernom, osr, nmosr, str, mont, obor, proch from         sprav.dbo.tsosr where idosr= SCOPE_IDENTITY()";
                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                //dv.Sort = 
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
                
                DataGridViewButtonColumn but = new DataGridViewButtonColumn();
                but.Name = "but";
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = System.Drawing.SystemColors.Control;
                //cellStyle.Format = "# ##0";
                but.DefaultCellStyle = cellStyle;

                Dgv1.Columns.Add(but);

                my.naimDG(my.headStr, Dgv1, my.widthStr);
                Double w = 0;
                for (int i = 0; i <= Dgv1.Columns.Count - 1; i++)
                { w = w + Dgv1.Columns[i].Width; }
                Width = (int)w + 50;
                Cursor = Cursors.Default;
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - 1 ).ToString();
                double Str = 0; double Mont = 0; double Obor = 0; double Proch = 0; double SumSt = 0;

                for (int i = 0; i < Dgv1.Rows.Count - 1; i++)
                {
                    Dgv1.Rows[i].Cells["SumSt"].Value = (double)Dgv1.Rows[i].Cells["Str"].Value + (double)Dgv1.Rows[i].Cells["Mont"].Value + (double)Dgv1.Rows[i].Cells["Obor"].Value + (double)Dgv1.Rows[i].Cells["Proch"].Value;
                    Str = Str + (double)Dgv1.Rows[i].Cells["Str"].Value;
                    Mont = Mont + (double)Dgv1.Rows[i].Cells["Mont"].Value;
                    Obor = Obor + (double)Dgv1.Rows[i].Cells["Obor"].Value;
                    Proch = Proch + (double)Dgv1.Rows[i].Cells["Proch"].Value;
                    SumSt = SumSt + (double)(Dgv1.Rows[i].Cells["SumSt"].Value == null ? 0.0 : Dgv1.Rows[i].Cells["SumSt"].Value);
                    Dgv1.EndEdit();
                }
                //my.Up(da, ds.Tables[0]);
                tStr.Text = Str.ToString();
                tMont.Text = Mont.ToString();
                tObor.Text = Obor.ToString();
                tProch.Text = Proch.ToString();
                tSumSt.Text = SumSt.ToString();
                Dgv1.Sort(Dgv1.Columns["OrderNom"], ListSortDirection.Ascending);
                my.cn.Open();
                my.sc.CommandText = my.FilterSel(125, this, my.sconn, " and idcomplexchapter in (select idcomplexchapter from Sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + ((int)idChapter.SelectedValue != 0 ? " and idchapter = " + idChapter.SelectedValue.ToString() : "") + ")");
                SqlDataReader sd = my.sc.ExecuteReader();
                while (sd.Read())
                { 
                    tStr91.Text = sd["Str91"].ToString();
                    tMont91.Text = sd["Mont91"].ToString();
                    tObor91.Text = sd["Obor91"].ToString();
                    tProch91.Text = sd["Proch91"].ToString();
                    tSumSt91.Text = sd["SumSt91"].ToString();
                    //tStr91 = (double)sd["Str91"];
                    //tStr91 = (double)sd["Str91"];
                    //tStr91 = (double)sd["Str91"];
                }
                sd.Close();
                my.sc.CommandText = my.FilterSel(126, this, my.sconn, " and idcomplexchapter in (select idcomplexchapter from Sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + ((int)idChapter.SelectedValue != 0 ? " and idchapter = " + idChapter.SelectedValue.ToString() : "") + ")");
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


                    //tOstMr.Text = sd["VMr91"].ToString();
                    //tOstPr.Text = sd["VPr91"].ToString();
                    //tOstOb.Text = sd["V91"].ToString();
                    //tOst.Text = sd["V91"].ToString();
                   
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
       

        private void SumAll()
        {
                  double Str = 0; double Mont = 0; double Obor = 0; double Proch = 0; double SumSt = 0;
          for (int i = 0; i < Dgv1.Rows.Count - 1; i++)
            {
                 Str= Str + (double)Dgv1.Rows[i].Cells["Str"].Value;
                 Mont = Mont + (double)Dgv1.Rows[i].Cells["Mont"].Value;
                Obor = Obor + (double)Dgv1.Rows[i].Cells["Obor"].Value;
                 Proch = Proch + (double)Dgv1.Rows[i].Cells["Proch"].Value;
              SumSt = SumSt + (double)(Dgv1.Rows[i].Cells["SumSt"].Value == null ? 0.0 : Dgv1.Rows[i].Cells["SumSt"].Value);

            }                
                 tStr.Text = Str.ToString();
                 tMont.Text = Mont.ToString();
                 tObor.Text = Obor.ToString();
                 tProch.Text = Proch.ToString();
                 tSumSt.Text = SumSt.ToString();
                 //my.Up(da, ds.Tables[0]);
        }
        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Dgv1.Rows[e.RowIndex].Cells["SumSt"].Value = (double)Dgv1.Rows[e.RowIndex].Cells["Str"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["Mont"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["Obor"].Value + (double)Dgv1.Rows[e.RowIndex].Cells["Proch"].Value;
                GC.Collect();
                my.cn.Open();
                my.Up(da, ds.Tables[0]);
                my.sc.CommandText = "UPDATE [sprav].[dbo].[tsosr] SET [ordernom] = " + Dgv1.Rows[e.RowIndex].Cells["ordernom"].Value + ", [osr] = '" + Dgv1.Rows[e.RowIndex].Cells["osr"].Value + "', [nmosr] = '" + Dgv1.Rows[e.RowIndex].Cells["nmosr"].Value + "', [str] = " + Dgv1.Rows[e.RowIndex].Cells["str"].Value + ", [mont] = " + Dgv1.Rows[e.RowIndex].Cells["mont"].Value + ", [obor] = " + Dgv1.Rows[e.RowIndex].Cells["obor"].Value + ", [proch] = " + Dgv1.Rows[e.RowIndex].Cells["proch"].Value + " WHERE [idosr] = " + Dgv1.Rows[e.RowIndex].Cells["idosr"].Value;
                my.sc.ExecuteScalar();
                my.cn.Close();
                SumAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void frmSSRSm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ds != null)
                { my.Up(da, ds.Tables[0]); }
            }
            catch (Exception ex)
            {
                
               MessageBox.Show("Ошибка!" + ex.Message);
            }
        }




        private int idcomplexchapter()
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = "select idcomplexchapter from Sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + " and idchapter = " + idChapter.SelectedValue.ToString();
                int idcomplexchapter = 0;
                if (my.sc.ExecuteScalar() != null) { idcomplexchapter = (int)my.sc.ExecuteScalar(); }
                my.cn.Close();
                return idcomplexchapter;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close();  }
                return 0;
            }
        }

        private void Dgv1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            my.Up(da, ds.Tables[0]);
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv1.CurrentCell.OwningColumn.Name == "but")
                {
                    my.Nbut = (int)Dgv1.CurrentRow.Cells[0].Value;
                    if (!my.isFormInMdi("frmSSRSmet", my.Nbut, this))
                    {
                        frmSSRSmet fr = new frmSSRSmet();
                        fr.Tag = (int)my.Nbut;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                        fr.button1_Click(null, null);
                        fr.Text = "Сметы по ОСР";
                    }
                    //MessageBox.Show(Dgv1.CurrentRow.Cells[2].Value.ToString());
                }
                if (Dgv1.CurrentRow != null)
                {
                    my.cn.Open();
                    my.sc.CommandText = my.FilterSel(125, this, my.sconn, " and sprav.dbo.tsmeti.idosr = " + Dgv1.CurrentRow.Cells[0].Value.ToString());
                    SqlDataReader sd = my.sc.ExecuteReader();
                    while (sd.Read())
                    {
                        this.label12.Text = "По ОСР(91г): Стр.раб. " + sd["Str91"].ToString() + ", Монт.раб. " + sd["Mont91"].ToString() + ", Обор.  " + sd["Obor91"].ToString() + ", Пр.раб. " + sd["Proch91"].ToString() + ", Итого " + sd["SumSt91"].ToString();
                    }
                    sd.Close();
                    my.cn.Close();
                }
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
                my.Szap = "";
                my.Nbut = 129;
                frmSprDGV fr = new frmSprDGV();
                fr.ShowDialog();
                string idcompl = idComplex.SelectedValue.ToString();
                my.FillDC(idComplex, 21, "");
                if (my.IsNumeric(my.Szap))
                { idComplex.SelectedValue = my.Szap; button1_Click(null, null); }
                else
                { idComplex.SelectedValue = idcompl; }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            //{
            //    my.showSprDGV(my.Nbut, true, true);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                my.Szap = "";
                my.Nbut = 130;
                frmSprDGV fr = new frmSprDGV();
                fr.ShowDialog();
                string idcompl = idComplex.SelectedValue.ToString();
                my.FillDC(idChapter, 22, " and (idChapter = 0 or idChapter in (select idChapter from sprav.dbo.tComplexChapter where idComplex = " + idComplex.SelectedValue.ToString() + ")) ");
                if (my.IsNumeric(my.Szap))
                {
                    my.cn.Open();
                    my.sc.CommandText = " if not exists (select 1 from sprav.dbo.tComplexChapter where idcomplex = " + idComplex.SelectedValue.ToString() + " and idchapter = " + my.Szap + "  ) insert into sprav.dbo.tComplexChapter (idcomplex,idchapter) values (" + idComplex.SelectedValue.ToString() + "," + my.Szap + ")";
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    my.FillDC(idChapter, 22, " and (idChapter = 0 or idChapter in (select idChapter from sprav.dbo.tComplexChapter where idComplex = " + idComplex.SelectedValue.ToString() + ")) ");

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = " if not exists (SELECT     1 FROM         Sprav.dbo.tsOSR INNER JOIN         Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter WHERE  Sprav.dbo.tComplexChapter.idcomplex = " + idComplex.SelectedValue.ToString() + " and    Sprav.dbo.tComplexChapter.idChapter =  " + idChapter.SelectedValue.ToString() + ") delete from sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + " and idchapter = " + idChapter.SelectedValue.ToString();
                my.sc.ExecuteScalar();
                my.cn.Close();
                my.FillDC(idChapter, 22, " and (idChapter = 0 or idChapter in (select idChapter from sprav.dbo.tComplexChapter where idComplex = " + idComplex.SelectedValue.ToString() + ")) ");


            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReps fr = new frmReps();
            my.Ustr = "";
            my.Szap = " and idcomplexchapter in (select idcomplexchapter from Sprav.dbo.tComplexChapter  where idcomplex = " + idComplex.SelectedValue.ToString() + ((int)idChapter.SelectedValue != 0 ? " and idchapter = " + idChapter.SelectedValue.ToString() : "") + ")";
            my.Nbut = 131;
            fr.MdiParent = my.MDIForm;
            my.Pform = this;
            fr.Show();
        }

        private void Dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }





 


    }
}