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
    public partial class frmVibComplex : Form
    {
        public frmVibComplex()
        {
            InitializeComponent();
        }



        private void TVib_Click(object sender, EventArgs e)
        {
            int idcom = (int)idComplex.SelectedValue;
            if (!my.isFormInMdi("frmHierar", idcom, this))
            {
                frmHierar fr = new frmHierar();
                fr.Tag = idcom;
                my.Nbut = idcom;
                fr.idComplex = (int)idComplex.SelectedValue;
                fr.NMComplex = idComplex.Text;
                fr.MdiParent = my.MDIForm;
                //fr.Hide();
                fr.Show();
            }
        }

        private void frmVibComplex_Load(object sender, EventArgs e)
        {
            my.FillDC(idComplex, 1, " ");
            idComplex.SelectedValue = 19;
        }

        private void TEx_Click(object sender, EventArgs e)
        {

        }
    }
}
