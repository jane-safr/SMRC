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
    public partial class frmVibPred : Form
    {
        public frmVibPred()
        {
            InitializeComponent();
        }

        private void chRas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmVibPred_Load(object sender, EventArgs e)
        {
            if (my.Nbut == 171 || my.Nbut == 172 | my.Nbut == 190 )
            { this.Height = 160; chSNds.Visible = false; chSub.Text = "по годам"; }
            else
            {
                my.FillDC(idComplex, 62, "");
                idComplex.SelectedValue = 0;
            }
            if (my.Nbut == 166 | my.Nbut == 182 | my.Nbut == 711 )
            { this.Height = 160; chSNds.Visible = false; chSub.Visible = false; chPoMes.Visible = false; label1.Visible = false; }
            if (my.Nbut == 175 | my.Nbut == 187| my.Nbut == 191)
            { chSNds.Visible = false; chOldCodir.Visible = false; chSub.Visible = false; chPoMes.Visible = false; }
            my.FillDC(IdEnt, 8, " and sprav.dbo.isb(Bits,4) = 1 or sprav.dbo.isb(Bits,3) = 1  or idEntpr = 0");
            IdEnt.SelectedValue = 0;

            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            frmReps fr = new frmReps();
            my.Pform = this;
            my.UpredName = IdEnt.Text;
            my.UperName = "  " + d1.Text + " - " + d2.Text;
            if (d1.Text == d2.Text)
            {
                my.UperName = d1.Text;
            }
            switch (my.Nbut)
            {
                case 180:
                case 195:
                    if (chPoMes.Checked)
                    {
                        my.Szap = "exec SSvodnPoMes '" + d1.SelectedValue + "','" + d2.SelectedValue + "'," + IdEnt.SelectedValue + "," + idComplex.SelectedValue + "," + (chOldCodir.Checked ? 1 : 0);
                        //return;
                    }
                    else
                    {
                        my.Szap = "exec SSvodn '" + d1.SelectedValue + "','" + d2.SelectedValue + "'," + IdEnt.SelectedValue + ",1," + idComplex.SelectedValue + "," + (chOldCodir.Checked ? 1 : 0) + "," + (chSub.Checked ? 1 : 0);
                    }
                    if (chSNds.Checked) fr.nds = 1.20; else fr.nds = 1;
                    break;
                case 191:
                case 190:
                case 172:
                case 166:
                case 182:
                case 171:
                    if (chPoMes.Checked)
                    {
                        my.Szap = "exec sNezavershKratko '" + ((my.Nbut == 171 || my.Nbut == 190) ? "01.07.2008" : "01.09.2007") + "','" + d1.SelectedValue + "','" + d2.SelectedValue + "', " + ((my.Nbut == 171 || my.Nbut == 190) ? 4 : 5) + ",'" + IdEnt.Text + "'";
                    }
                    else
                    {
                        my.Szap = "exec sNezaversh '" + d1.SelectedValue + "','" + d2.SelectedValue + "'," + IdEnt.SelectedValue + "," + (my.Nbut == 182 ? 2 : (my.Nbut == 166? 0: (my.Nbut == 171  | my.Nbut == 190 | my.Nbut == 191) ? 4 : 5)) + ",0," + (chSub.Checked ? 0 : 1) + ",'" + IdEnt.Text + "'," + (chOldCodir.Checked ? 1 : 0) + ",0";
                    }
                    break;
                case 175:
                    my.Szap = "exec SOstSmet '" + d1.SelectedValue + "','" + d2.SelectedValue + "','" + IdEnt.Text + "'," + idComplex.SelectedValue;
                    break;
                case 187:
                    my.Szap = "exec SSvodnPoDog  '" + d1.SelectedValue + "','" + d2.SelectedValue + "','" + IdEnt.SelectedValue + "',1," + idComplex.SelectedValue;
                    break;
                default:
                    break;
            }

            if (chSub.Checked) fr.sub = true; else fr.sub = false;
            if (chPoMes.Checked) fr.poMes = true; else fr.poMes= false;

            fr.MdiParent = my.MDIForm;
            fr.Show();

        }

        private void frmVibPred_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void chPoMes_CheckedChanged(object sender, EventArgs e)
        {
            bool ch = chPoMes.Checked;
            chSub.Enabled = !ch;
            chOldCodir.Enabled = !ch;
            chSNds.Enabled = !ch;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVibPred_FormClosing(object sender, FormClosingEventArgs e)
        {
            my.UperName = my.MDIForm.cUper.Text;
            my.UpredName = my.MDIForm.cUpred.Text;
        }
    }
}
