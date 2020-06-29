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
    public partial class frmVibDate : Form
    {
        public string idgrafik; public int Nbut; public int IdEntpr; public int IdDep;
        public frmVibDate()
        {
            InitializeComponent();
        }

        private void frmVibDate_Load(object sender, EventArgs e)
        {
            my.FillDC(NMEnt, 69, " ");
            my.FillDC(StrDate, 70, " and NmCol like ''%start%''");
            d2.Value = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day + 1);
            WindowState = FormWindowState.Normal;
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //ModOffice.GrafikTPNew("дд", 0, d2.Value.ToShortDateString(), dend.Value.ToShortDateString(), idgrafik.ToString(), StrDate.SelectedValue.ToString());
            ModOffice.GrafikTPNew("exec Grafik.dbo.sProjACTP " + idgrafik + ",'','" + d2.Value.ToShortDateString() + "','" + dend.Value.ToShortDateString() + "','" + NMEnt.SelectedValue + "',0,'" + StrDate.SelectedValue + "'", Convert.ToDouble(ind.Text.ToString()), d2.Value.ToShortDateString(), dend.Value.ToShortDateString(),idgrafik.ToString(),StrDate.SelectedValue.ToString(),IdEntpr,IdDep);
            Cursor = Cursors.Default;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
