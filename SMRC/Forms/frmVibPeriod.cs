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
    public partial class frmVibPeriod : Form
    {
       public int Nbut ;public string NMGrafik ; public int IdEntpr; public int IdDep;
        public frmVibPeriod()
        {
            InitializeComponent();
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            my.Szap = " and Period >= '" + d1.SelectedValue.ToString() + "' and  Period  <= '" + d2.SelectedValue.ToString() + "' ";


            switch (Nbut)
            {
                case 1:
                    my.Szap = " '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'";
                    ModOffice.ReportExGrafikActs(NMGrafik, 2, my.Szap, IdEntpr, IdDep); break;
                case 2:
                    my.Szap = " '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'";
                    ModOffice.ReportExOstSmSt(NMGrafik, 2, my.Szap, d1.SelectedValue.ToString(), d2.SelectedValue.ToString(), IdEntpr, IdDep);
                    break;
                case 43:
                    my.Szap = " and Forma2.Period >= '" + d1.SelectedValue.ToString() + "' and  Forma2.Period  <= '" + d2.SelectedValue.ToString() + "' ";
                    if (!my.isFormInMdi("frmSprZapros", my.Nbut, this))
                    {
                        my.showSprZapros(my.Nbut, false, true);
                    }

                    break;
                default:
                    if (!my.isFormInMdi("frmSprZapros", my.Nbut, this))
                    {
                        my.showSprZapros(my.Nbut, false, true);
                    }


                    break;
            }
        }

        private void frmVibPeriod_Load(object sender, EventArgs e)
        {
            //this.Top = (my.MDIForm.Height - this.Height) / 3;
            //this.Left = (my.MDIForm.Width - this.Width) / 3;
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
        }

        private void frmVibPeriod_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}
