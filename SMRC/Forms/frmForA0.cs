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
    public partial class frmForA0 : Form
    {
        public frmForA0()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(my.sconn);
            string sconndev = @"Initial Catalog=A0Data;User ID=prog;Password=prog;Data Source=SQL\dev1c;Connect Timeout=30000000;";
            SqlCommand sc = new SqlCommand("select top 10 * from sprav.dbo.vForA0Contragents" , cn);

            cn.Open();
            SqlDataReader DRd = sc.ExecuteReader();
            while (DRd.Read())
            {
                my.sc.CommandText = @"exec SpAddExecutorEx @ConGUID ='" + DRd["UUID"].ToString() + "' @ConName ='" + DRd["shNMEntpr"].ToString() + "'" + 
                     " @ConINN = '" + DRd["INN"].ToString() + "'" +
                     " @ConKPP = '" + DRd["KPP"].ToString() + "'" +
                     " @ConINN = '" + DRd["INN"].ToString() + "'" +
                     " @ConINN = '" + DRd["INN"].ToString() + "'";
                //OZP.Text = Convert.ToDouble(DRd["OZP"]).ToString();ConAddrLegal
                //EM.Text = Convert.ToDouble(DRd["EM"]).ToString();
                //ZPm.Text = Convert.ToDouble(DRd["ZPm"]).ToString();
                //Mat.Text = Convert.ToDouble(DRd["Mat"]).ToString();
                //NR.Text = Convert.ToDouble(DRd["NR"]).ToString();
                //SP.Text = Convert.ToDouble(DRd["SP"]).ToString();
                //TZo.Text = Convert.ToDouble(DRd["TZo"]).ToString();
                //TZm.Text = Convert.ToDouble(DRd["TZm"]).ToString();
                //Pr.Text = Convert.ToDouble(DRd["Pr"]).ToString();
                //Ob.Text = Convert.ToDouble(DRd["Ob"]).ToString();
                //SmetnSt.Text = Convert.ToDouble(DRd["SmetnSt"]).ToString();

            }

            DRd.Close();
            DRd.Dispose();
            cn.Close();

        }
    }
}
