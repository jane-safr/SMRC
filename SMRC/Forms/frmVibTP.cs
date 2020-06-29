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
    public partial class frmVibTP : Form
    {
        public string NMGrafik; public int idcomplex;
        public frmVibTP()
        {
            InitializeComponent();
        }

        private void frmVibTP_Load(object sender, EventArgs e)
        {
            my.FillDC(nm1,64,"");
            nm1.SelectedValue = "base_start_date";
            my.FillDC(nm2, 64, "");
            nm2.SelectedValue = "base_end_date";
            my.FillDC(nm3, 65, " and idGrafik = " + NMGrafik);
            //my.ObnPer(d1);
            d1.Value = DateTime.Today.AddDays(-DateTime.Today.Day+1);
            //my.ObnPer(d2);
            d2.Value = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day + 1);
            WindowState = FormWindowState.Normal;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string szap = " and " + nm1.SelectedValue.ToString() + " <= ''" + d2.Value.ToString() + "'' and " + nm2.SelectedValue.ToString() + " >= ''" + d1.Value.ToString() + "''";
            string szap2 = "";
            if (checkBox1.Checked) szap2 =  " and user_field_6680 = ''" +nm3.SelectedValue.ToString() + "''";
            ModOffice.GrafikTP("exec Grafik.dbo.sTemPlan '" + NMGrafik + "','" + szap + "','TP'," + (chAllWrk.Checked ? 1 : 0).ToString() + "," + idcomplex.ToString() + ",'" + szap2 + "'", d1.Value, d2.Value);
            Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            nm3.Enabled = checkBox1.Checked;
        }
    }
}
