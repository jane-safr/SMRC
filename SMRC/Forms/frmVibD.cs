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
    public partial class frmVibD : Form
    {
        public string idgrafik; public int Nbut; public string NMGrafik; public int IdEntpr; public int IdDep;
        public frmVibD()
        {
            InitializeComponent();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            if (Nbut == 1)
            { ModOffice.ReportExGrafik(idgrafik.ToString(), 1, StrDate.SelectedValue.ToString(), NMGrafik,IdEntpr,IdDep); }
            if (Nbut == 2)
            { ModOffice.ReportExGrafikObor(idgrafik.ToString(), 1, StrDate.SelectedValue.ToString(), NMGrafik, IdEntpr, IdDep); }
        }

        private void frmVibD_Load(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Normal;
            my.FillDC(StrDate, 70, " and NmCol like ''%start%''");
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
