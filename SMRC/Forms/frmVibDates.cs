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
    public partial class frmVibDates : Form
    {
        public string idgrafik; public int Nbut; public int IdEntpr; public int IdDep;
        public frmVibDates()
        {
            InitializeComponent();
        }

        private void frmVibDates_Load(object sender, EventArgs e)
        {
            d1.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            //my.ObnPer(d2);
            d2.Value = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day + 1);
            WindowState = FormWindowState.Normal;
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ModOffice.GrafikTPRep("exec Grafik.dbo.sProjACTPRep " + idgrafik + ",'" + d1.Value.ToShortDateString() + "','" + d2.Value.ToShortDateString() + "'," + IdEntpr.ToString() + "," +IdDep.ToString());
            Cursor = Cursors.Default;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
