using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmVibInv : Form
    {
        int nbut1 = 0; int ind = 0;
        public frmVibInv()
        {
            InitializeComponent();
        }

        private void frmVibInv_Load(object sender, EventArgs e)
        {
            nbut1 = my.Nbut;
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
            my.FillDC(IdComplex, 62, "");
            IdComplex.SelectedValue = 32;
            if (nbut1 == 77 )
            { Height = 148; }
            if ( nbut1 == 73)
            { Height = 115; }
            if (nbut1 == 178 | nbut1 == 185)
            {
                this.groupBox1.Visible = true;
                d1.Visible = false; label2.Visible = false;
                //this.Frame2.Top = 800;
                //this.пс_Период(2).BoundColumn = r.Fields[0].Name;
                //this.пс_Период(2).ListField = r.Fields[1].Name;
                //Set this.пс_Период(2).RowSource = r;
                //this.пс_Период(2).BoundText = Uper;
                //this.Height = 2800;
                my.FillDC (IdPrice, 39, " and vid = 17");
                IdPrice.SelectedValue = 1;
            }
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            my.Nbut = nbut1;
            //my.UpredName = IdEnt.Text;
            frmReps fr = new frmReps();
            my.Pform = this;
            switch (nbut1)
            {
                case 77: my.Szap = "set dateformat dmy exec sReestrOSRF3 " + IdComplex.SelectedValue.ToString() + ", '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'"; break;
                case 73: my.Szap = " and idcomplex =" + IdComplex.SelectedValue.ToString() ; break;
                case 185:
                case 178: my.UperName = (Convert.ToDateTime (d2.Text)).AddMonths(1).ToString("dd.MM.yyyy"); my.Szap = "exec SOstSmetLimit " + IdComplex.SelectedValue.ToString() + ",'" + d2.SelectedValue.ToString() + "'," + IdDog.SelectedValue + "," + ind + "," + IdPrice.SelectedValue + (nbut1==185? ",1":",0"); break;
            }
            fr.MdiParent = my.MDIForm;
            fr.Show();
        }

        private void frmVibInv_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IdComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!my.IsNumeric(IdComplex.SelectedValue)) return;
            if (nbut1 == 178 | nbut1 == 185)
            {
                string strsql = "";

                if (nbut1 == 178)
                {
                    strsql = "SELECT  iddog,   RegNomer1 FROM         dbo.vDogLimit where 1 = 1 ";
                }
                if (nbut1 == 185)
                {
                    strsql = "SELECT  iddog,   RegNomer1 FROM         dbo.vDogLimitAll where 1 = 1 ";
                }

                DataSet ds = new DataSet();
                strsql = strsql + " and iddog  = 0 or iddog in (SELECT DISTINCT dbo.Forma2.IdDog FROM         dbo.Forma2 INNER JOIN        Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm INNER JOIN     Sprav.dbo.tsOSR ON Sprav.dbo.tSmeti.IdOsr = Sprav.dbo.tsOSR.idOSR INNER JOIN        Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter WHERE     (Sprav.dbo.tComplexChapter.idComplex = " + IdComplex.SelectedValue + ") OR   (dbo.Forma2.IdDog = 0))   order by RegNomer1";
                SqlDataAdapter da = new SqlDataAdapter(strsql, my.cn);
                da.Fill(ds);
                IdDog.DataSource = ds.Tables[0];
                IdDog.ValueMember = "iddog";
                IdDog.DisplayMember = "RegNomer1";
                da.Dispose();
                ds.Dispose();
                IdDog.SelectedValue = 0;

            }
        }

        private void radioButton0_CheckedChanged(object sender, EventArgs e)
        {
            string NameRB = ((RadioButton)sender).Name;

            ind =Convert.ToInt16(NameRB.Substring(NameRB.Length - 1));
            if (radioButton2.Checked)
            {
                IdDog.Enabled = true;
            }
            else
            {
                IdDog.Enabled = false;
                IdDog.SelectedValue = 0;
            }
        }
    }
}
