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
    public partial class frmReports : Form
    {
        public string nm; public int idcomplex;
        public frmReports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ModOffice.GrafikRep("exec Grafik.dbo.sGrafikPr '" + NMGrafik.SelectedValue + "','Projuser_field_6678','',null," + idcomplex.ToString(), idcomplex);
            Cursor = Cursors.Default;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            my.FillDC(NMGrafik, 63, "");
            NMGrafik.SelectedValue = nm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ModOffice.GrafikPdf("exec Grafik.dbo.sGrafikPr '" + NMGrafik.SelectedValue + "','proj','',null," + idcomplex.ToString());
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmVibTP fr = new frmVibTP();
            //fr.MdiParent = my.MDIForm;
            fr.NMGrafik = NMGrafik.SelectedValue.ToString();
            fr.idcomplex = idcomplex;
            fr.ShowDialog();
        }


    }
}
