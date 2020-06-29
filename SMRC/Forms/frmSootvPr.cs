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
    public partial class frmSootvPr : Form
    {
        public frmSootvPr()
        {
            InitializeComponent();
        }

        private void frmSootvPV_Load(object sender, EventArgs e)
        {
            my.FillDC(idComplex1, 43, " ");
            my.FillDC(idCat, 50, " ");
        }

        private void idComplex1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idComplex1.SelectedValue.ToString()))
            {
                my.FillDC(idOsr, 44, " and idcomplex = " + idComplex1.SelectedValue.ToString());
            }
        }

  

        private void idCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idCat.SelectedValue.ToString()))
            {
                my.FillDC(idCatValue, 51, " and proj_catg_type_id = " + idCat.SelectedValue.ToString());
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(idCat.SelectedValue.ToString() + "  " + idCatValue.SelectedValue.ToString());
        //}

        private void idProj_SelectedValueChanged(object sender, EventArgs e)
        {
   

        }

        private void idCatValue_SelectedValueChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idCatValue.SelectedValue.ToString()))
            {
                my.FillDC(idProj, 52, " and proj_catg_type_id = " + idCat.SelectedValue.ToString() + " " + " and proj_catg_id = " + idCatValue.SelectedValue.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (my.IsNumeric(idProj.SelectedValue.ToString()))
            {
                string s = my.FilterSel(219, this, my.sconn, " and idComplex = " + idComplex1.SelectedValue.ToString() + " and IdOsr = " + idOsr.SelectedValue.ToString());
                DataSet dsStPred = new DataSet();
                SqlDataAdapter daStPred = new SqlDataAdapter(s, my.sconn);
                dsStPred.Clear();
                daStPred.Fill(dsStPred);
                DgvProjSMR.DataSource = dsStPred.Tables[0];
                DgvProjSMR.AllowUserToAddRows = false;
                DgvProjSMR.AllowUserToDeleteRows = false;
                DgvProjSMR.EditMode = DataGridViewEditMode.EditProgrammatically;
                my.naimDG(my.headStr, DgvProjSMR, my.widthStr);
                lProjSMR.Text = "Всего: " + dsStPred.Tables[0].Rows.Count.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idProj.SelectedValue == null) { MessageBox.Show("Выберите проект в Primavera!"); return; }
            if (my.IsNumeric(idProj.SelectedValue.ToString()))
            {
                my.sc.CommandText = "exec sPrInsProj " + idComplex1.SelectedValue.ToString() + "," + idOsr.SelectedValue.ToString() + "," + idProj.SelectedValue.ToString();
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
                MessageBox.Show("Готово!");
            }
            else
            { MessageBox.Show("Выберите проект в Primavera!"); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idComplex1.SelectedValue == null) { MessageBox.Show("Выберите Инв.проект!"); return; }
            if (my.IsNumeric(idComplex1.SelectedValue.ToString()))
            {
                my.sc.CommandText = "exec sPrInsProj " + idComplex1.SelectedValue.ToString() + ",null,null,1" ;
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
                MessageBox.Show("Готово!");
            }
            else
            { MessageBox.Show("Выберите Инв.проект!"); }
        }


    }
}
