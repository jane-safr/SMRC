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
    public partial class frmVibPer : Form
    {
        int nbut1;
        public frmVibPer()
        {
            InitializeComponent();
        }

        private void frmVibPer_Load(object sender, EventArgs e)
        {
            nbut1 = my.Nbut;
            d1.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            d2.Value = d1.Value.AddMonths(1);
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            my.Szap = " and DateBeg1  >= '" + d1.Value.ToString() + "' and  DateBeg1   <= '" + d2.Value.ToString() + "' ";
            if (!my.isFormInMdi("frmSprZapros", my.Nbut, this))
            {
                my.showSprZapros(my.Nbut, false, true);
            }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
