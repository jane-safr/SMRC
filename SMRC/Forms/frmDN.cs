using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmDN : Form
    {
        public int nbut1; bool ref1 = true; DGVt dgv; DataSet dsKoef; bool WithOpen = false;
        public frmDN()
        {
            InitializeComponent();
        }

        private void frmDN_Load(object sender, EventArgs e)
        {
            Text = "Сводный сметный расчет";
            my.FillDC(idComplex, 21, "");
            WithOpen = false;
            idComplex.SelectedValue = 2;
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv2.AllowUserToAddRows = false;
            Dgv2.AllowUserToDeleteRows = false;
            Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv3.AllowUserToAddRows = false;
            Dgv3.AllowUserToDeleteRows = false;
            Dgv3.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv4.AllowUserToAddRows = false;
            Dgv4.AllowUserToDeleteRows = false;
            Dgv4.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvOSR.AllowUserToAddRows = false;
            DgvOSR.AllowUserToDeleteRows = false;
            DgvOSR.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvComplex.AllowUserToAddRows = false;
            DgvComplex.AllowUserToDeleteRows = false;
            DgvComplex.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvOSRDC.AllowUserToAddRows = false;
            DgvOSRDC.AllowUserToDeleteRows = false;
            DgvOSRDC.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvComplexDC.AllowUserToAddRows = false;
            DgvComplexDC.AllowUserToDeleteRows = false;
            DgvComplexDC.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvKoef.AllowUserToAddRows = false;
            DgvKoef.AllowUserToDeleteRows = false;
            DGVItogDN.AllowUserToAddRows = false;
            DGVDcSm.AllowUserToDeleteRows = false;
            DGVDcSm.AllowUserToAddRows = false;
            DGVItogDN.AllowUserToDeleteRows = false;
            my.sc.CommandText = my.FilterSel(150, null, my.sconn, " and idcomplex = " + idComplex.SelectedValue.ToString());
            my.cn.Open();
           Ind.Text = my.sc.ExecuteScalar().ToString();
            my.cn.Close();
        }

        private void idComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (my.IsNumeric(idComplex.SelectedValue) == false) { return; }
                my.FillDC(idOSR, 35, " and idcomplex = " + idComplex.SelectedValue.ToString() + " or idosr = 0 ");
                WithOpen = true;
                idOSR.SelectedValue = 0;

                dsKoef = my.GetDS(my.FilterSel(147, null, my.sconn, ""), my.sconn);
                DgvKoef.DataSource = dsKoef.Tables[0];
                if (ref1) { my.naimDG(my.headStr, DgvKoef, my.widthStr); }
                //tabControl1_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка! " + ex.Message);
            }

        }
        private void spisok(string str)
        {
            DataSet ds = my.GetDS(my.FilterSel(140, null, my.sconn, str), my.sconn);
            if (Dgv1.DataSource != null) { ref1 = false; }
            ds.Tables[0].Columns.Add("Vib", Type.GetType( "System.Boolean"));
            Dgv1.DataSource = ds.Tables[0];
            if (ref1) { my.naimDG(my.headStr, Dgv1, my.widthStr); }
            DataSet ds5 = my.GetDS(my.FilterSel(145, null, my.sconn, str), my.sconn);
            DgvOSR.DataSource = ds5.Tables[0];
            if (ref1) { my.naimDG(my.headStr, DgvOSR, my.widthStr); }
            DataSet ds6 = my.GetDS(my.FilterSel(146, null, my.sconn, str), my.sconn);
            DgvComplex.DataSource = ds6.Tables[0];
            if (ref1) { my.naimDG(my.headStr, DgvComplex, my.widthStr); }
            DataSet ds7 = my.GetDS(my.FilterSel(148, null, my.sconn, str), my.sconn);
            DgvComplexDC.DataSource = ds7.Tables[0];
            if (ref1) { my.naimDG(my.headStr, DgvComplexDC, my.widthStr); }
            DataSet ds9 = my.GetDS(my.FilterSel(156, null, my.sconn, str), my.sconn);
            DGVItogDN.DataSource = ds9.Tables[0];
            if (ref1) { my.naimDG(my.headStr, DGVItogDN, my.widthStr); }
            DataSet ds8 = my.GetDS(my.FilterSel(149, null, my.sconn, str), my.sconn);
            DgvOSRDC.DataSource = ds8.Tables[0];
            if (ref1) { my.naimDG(my.headStr, DgvOSRDC, my.widthStr); }
            my.cn.Open();
            my.sc.CommandText =" SELECT     SUM(oz) AS Summa from (" +my.FilterSel(154, null, my.sconn, str)  + " ) as dd"; 
            tItog.Text = my.sc.ExecuteScalar().ToString();
            my.cn.Close();
        }


        private void Dgv1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.CurrentRow == null) { return; }
            DataSet ds1 = my.GetDS(my.FilterSel(141, null, my.sconn, " and idsm = " + Dgv1[0, e.RowIndex].Value.ToString()), my.sconn);
            Dgv2.DataSource = ds1.Tables[0];
            my.naimDG(my.headStr, Dgv2, my.widthStr);
            DataSet ds2 = my.GetDS(my.FilterSel(142, null, my.sconn, " and Код = " + Dgv1[0, e.RowIndex].Value.ToString()), my.sconn);
            Dgv3.DataSource = ds2.Tables[0];
            my.naimDG(my.headStr, Dgv3, my.widthStr);
            DataSet ds3 = my.GetDS(my.FilterSel(144, null, my.sconn, " and idsm = " + Dgv1[0, e.RowIndex].Value.ToString()), my.sconn);
            Dgv4.DataSource = ds3.Tables[0];
            my.naimDG(my.headStr, Dgv4, my.widthStr);
            DataSet ds7 = my.GetDS(my.FilterSel(157, null, my.sconn, " and idsm = " + Dgv1[0, e.RowIndex].Value.ToString()), my.sconn);
            DGVDcSm.DataSource = ds7.Tables[0];
            my.naimDG(my.headStr, DGVDcSm, my.widthStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv != null) { my.v_excel(dgv); }
        }

        private void DgvComplex_Leave(object sender, EventArgs e)
        {
            dgv = (DGVt)sender;
        }

        private void DgvKoef_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            my.sc.CommandText = "update tskoef set KNr =" + DgvKoef.CurrentRow.Cells["KNr"].Value.ToString() + ", KPn =" + DgvKoef.CurrentRow.Cells["KPn"].Value.ToString() + ", KOz=" + DgvKoef.CurrentRow.Cells["KOz"].Value.ToString() + ", KEm=" + DgvKoef.CurrentRow.Cells["KEm"].Value.ToString() + ", KSm=" + DgvKoef.CurrentRow.Cells["KSm"].Value.ToString() + " where idkoef =" + DgvKoef.CurrentRow.Cells["idkoef"].Value.ToString();
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                idOSR_SelectedValueChanged(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ras("");
        }
        private void ras(string s)
        {
            my.sc.CommandText = my.FilterSel(151, null, my.sconn, " and idcomplex = " + idComplex.SelectedValue.ToString() + s);
            my.cn.Open();
            tSum91.Text = my.sc.ExecuteScalar().ToString();
            my.sc.CommandText = my.FilterSel(155, null, my.sconn, " and idcomplex = " + idComplex.SelectedValue.ToString() + s);
            tSum912.Text = Convert.ToString(Convert.ToInt64(my.sc.ExecuteScalar()));
            my.sc.CommandText = my.FilterSel(152, null, my.sconn, " and idcomplex = " + idComplex.SelectedValue.ToString() + s);
            tDC1.Text = my.sc.ExecuteScalar().ToString();
            my.sc.CommandText = "update tind set ind = " + Ind.Text + " where idComplex =" + idComplex.SelectedValue.ToString();
            my.sc.ExecuteScalar();
            my.cn.Close();
                tDC.Text = Convert.ToString(Convert.ToDouble(tSum91.Text) * Convert.ToDouble(Ind.Text));
                //my.cn.= 100;
                tInd.Text = Convert.ToString(Math.Round(Convert.ToDouble(tDC1.Text) / Convert.ToDouble(tSum91.Text), 3));
                tDC2.Text = Convert.ToString(Convert.ToDouble(tSum912.Text) * Convert.ToDouble(Ind.Text));
                tInd2.Text = Convert.ToString(Math.Round(Convert.ToDouble(tDC1.Text) / Convert.ToDouble(tSum912.Text), 3));
                if (s == "")
                {
                    try
                    {
                        DataSet ds9 = my.GetDS(my.FilterSel(153, null, my.sconn, " and idcomplex = " + idComplex.SelectedValue.ToString() + s), my.sconn);
                        DgvOSRInd.DataSource = ds9.Tables[0];
                        my.naimDG(my.headStr, DgvOSRInd, my.widthStr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + ex.Message);
                    }
                }
                else
                { DgvOSRInd.DataSource = null; }
        }
        private void idOSR_SelectedValueChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idOSR.SelectedValue) == false || ! WithOpen ) { return; }
            if ((int)idOSR.SelectedValue == 0)
            { spisok(" and idcomplex = " + idComplex.SelectedValue.ToString()); }
            else
                spisok(" and idOSR = " + idOSR.SelectedValue.ToString());
        }

        private void DgvComplexDC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVt dg = (DGVt)sender;
           int idopred = (int) dg.Rows[e.RowIndex].Cells["IdOpred"].Value;
            my.Nbut = 141;
            //if (!my.isFormInMdi("frmSprDgv", my.Nbut, this))
            //{
                frmSprDGV fr = new frmSprDGV();
                fr.Tag = (int)my.Nbut;
                fr.Withup = false;
                fr.MdiParent = my.MDIForm;
                my.Szap = " and idopred = " + idopred.ToString();
                if ((int)idOSR.SelectedValue == 0)
                { my.Szap = my.Szap + " and idcomplex = " + idComplex.SelectedValue.ToString(); }
                else
                    my.Szap = my.Szap + " and idOSR = " + idOSR.SelectedValue.ToString();
                fr.Show();
            //}
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9) { Dgv1.BeginEdit(true); } else { Dgv1.EndEdit(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < Dgv1.Rows.Count; i++)
			{
                if (Dgv1.Rows[i].Cells[9].Value != DBNull.Value) if ((bool)Dgv1.Rows[i].Cells[9].Value) { s = s + Dgv1.Rows[i].Cells["idsm"].Value.ToString() + ","; }
			}
            if (s != "") { s = s.Substring(0, s.Length - 1); s = " and idsm in (" + s + ")"; ras(s); }
            else { MessageBox.Show("Выберите сметы!"); }
            
        }





    }
}