using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmInvDog : Form
    {
        SqlDataAdapter[] da = new SqlDataAdapter[3];
        DataSet ds ;
        string sel = "";
        public frmInvDog()
        {
            InitializeComponent();
        }

        private void frmInvDog_Load(object sender, EventArgs e)
        {
            my.FillDC(idComplex, 62, "");
            idComplex.SelectedValue = 32;
            sel = my.FilterSel(66, null, my.sconn, "");
        }

        private void idComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //return;
            if (my.IsNumeric(idComplex.SelectedValue))
            {
                if (ds != null && ds.HasChanges()) { my.Up(da[0], ds.Tables[0]); }
                DataView dv;
                ds = new DataSet();
                da[0] = new SqlDataAdapter();
                DaDs dads1 = new DaDs();
                string sel = my.FilterSel(703, null, my.sconn, " and iddog in (SELECT DISTINCT dbo.Forma2.IdDog FROM         dbo.Forma2 INNER JOIN        Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm INNER JOIN     Sprav.dbo.tsOSR ON Sprav.dbo.tSmeti.IdOsr = Sprav.dbo.tsOSR.idOSR INNER JOIN        Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter WHERE     (Sprav.dbo.tComplexChapter.idComplex = " + idComplex.SelectedValue + ") OR   (dbo.Forma2.IdDog = 0))");
                dads1.DaInd(0, "set language 'русский' " + sel, my.sconn, "", ds, true);
                da[0] = dads1.Da[0];
                dv = new DataView();
                dv.Table = ds.Tables[0];
                //Dgv1.DataSource = null;
                Dgv1.DataSource = dv;
                Dgv1.Columns[0].Visible = false;

                // my.MySpisok(703, " and iddog in (SELECT DISTINCT dbo.Forma2.IdDog FROM         dbo.Forma2 INNER JOIN        Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm INNER JOIN     Sprav.dbo.tsOSR ON Sprav.dbo.tSmeti.IdOsr = Sprav.dbo.tsOSR.idOSR INNER JOIN        Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter WHERE     (Sprav.dbo.tComplexChapter.idComplex = " + idComplex.SelectedValue + ") OR   (dbo.Forma2.IdDog = 0))",this,Dgv1);
            }

        }

        private void frmInvDog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ds.HasChanges()) { my.Up(da[0], ds.Tables[0]); }
        }
    }
}

 