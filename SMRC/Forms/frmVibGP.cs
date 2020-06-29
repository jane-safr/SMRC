using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmVibGP : Form
    {
        public frmVibGP()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            d3.Enabled = chVvod.Checked; d4.Enabled = chVvod.Checked;
            this.Refresh();
        }

        private void frmVibGP_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void frmVibGP_Load(object sender, EventArgs e)
        {
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
            my.ObnPer(d3);
            d3.SelectedValue = my.Uper;
            my.ObnPer(d4);
            d4.SelectedValue = my.Uper;

        }

        private void TVib_Click(object sender, EventArgs e)
        {
            my.UperName = "  " + d1.Text + " - " + d2.Text;
            if (d1.Text == d2.Text)
            {
                my.UperName = d1.Text;
            }
            if (rb2.Checked)
            {
                my.Szap = " and Period >= '" + d1.SelectedValue + "' and  Period  <= '" + d2.SelectedValue + "'  and vzamen = 0";
                if (rb3.Checked)
                { my.Szap = " and [ПериодГП] >= '" + d3.SelectedValue + "' and  [ПериодГП]  <= '" + d3.SelectedValue + "' "; }
                if (rbSub.Checked) { my.Szap = "exec sGpSp '" + d1.SelectedValue + "','" + d2.SelectedValue + "'," + (my.Nbut == 52 ? 76 : 1) + ",2"; };
                if (chVvod.Checked & !rbSub.Checked)
                {
                    my.Szap = my.Szap + " and [Datebeg]  between '" + d1.SelectedValue + "' and '" + d2.SelectedValue + "'";
                }

            }
            if (sender.ToString() == "Просмотр")
            {
                frmReps fr = new frmReps();
                my.Pform = this;
                fr.MdiParent = my.MDIForm;
                fr.Show();
            }
            else
            {
                my.showSprDGV(my.Nbut, false, true);
                return;
            }
        }
    }
}
