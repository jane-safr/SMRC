using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmVibSmet : Form
    {
        int nbut1; string Upred;
        public frmVibSmet()
        {
            InitializeComponent();
        }

        private void frmVibSmet_Load(object sender, EventArgs e)
        {
            this.Top = (my.MDIForm.Height - this.Height) / 3;
            this.Left = (my.MDIForm.Width - this.Width) / 3;
            nbut1 = my.Nbut;
            if (nbut1 == 2003 || nbut1 == 80 || nbut1 == 81 || nbut1 == 85 || nbut1 == 64 || nbut1 == 183 | nbut1 == 74 | nbut1 == 186)
            {
                IdEnt.Visible = false;
                label1.Visible = false;
            }
            if (nbut1 == 2002)
            {
                this.chPr.Visible = true;
                this.chUch.Visible = true;
            }
            if (nbut1 == 2001)
            {
                this.chPr.Visible = true;
                chPr.Text = "Вр.здания и сооружения";
                //this.chUch.Visible = true;
            }
            if (nbut1 == 80 || nbut1 == 85)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                Height = 120;
            }
            my.FillDC(IdEnt, 8, " and sprav.dbo.isb(Bits,4) = 1 or sprav.dbo.isb(Bits,3) = 1  or idEntpr = 0 ");
            IdEnt.SelectedValue = my.identpr;
            //DataSet ds = new DataSet();
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
            if (nbut1 == 189) d1.SelectedValue = "01.01."+ DateTime.Today.Year.ToString();
            //ds.Dispose();
        }

        private void frmVibSmet_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {

            Upred = my.ExeScalar("select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + IdEnt.SelectedValue.ToString());
            my.Nbut = nbut1;
            my.UpredName = IdEnt.Text;
            frmReps fr = new frmReps();
            my.Pform = this;
            my.Szap = " '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" + ((nbut1 == 2003 | nbut1 == 80 | nbut1 == 85) ? "0" : (nbut1 == 2001 | nbut1 == 2020 ? Upred : IdEnt.SelectedValue.ToString()) ) + "' , " + ((this.radioButton0.Checked) ? 0 : 1) + "," + ((this.radioButton2.Checked) ? 0 : 1);
            if (groupBox2.Visible == false & nbut1 != 80 & nbut1 != 85)
            {
                my.Szap = " '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" +  IdEnt.SelectedValue.ToString() + "' , " + ((this.radioButton0.Checked) ? 0 : 1);
            }

            my.UperName = "  " + d1.Text + " - " + d2.Text;
            if (d1.Text == d2.Text)
            {
                my.UperName = d1.Text;
            }
            //if (nbut1 == 2002 | nbut1 == 2003 | nbut1 == 2001 | nbut1 == 170 | nbut1 == 80 | nbut1 == 81 | nbut1 == 85)
            //{
                if (this.radioButton3.Checked)
                {
                    my.Ustr = "(соб. силы)";
                }
                else
                {
                    if (this.radioButton0.Checked)
                    {
                        my.Ustr = "(выполнение по ф №2)";
                    }
                    else
                    {
                        my.Ustr = "(выполнение уточненное)";
                    }
                }
                if (chPr.Checked & nbut1 != 2001)
                {
                    my.Nbut = 2004;
                }
           
                switch (nbut1)
                {
                    case 80: my.Szap = "set dateformat dmy exec r_svodnall " + my.Szap + ",4"; break;
                    case 85: my.Szap = "set dateformat dmy exec r_svodnall " + my.Szap + ",4"; break;
                    case 81: my.Szap = "set dateformat dmy exec sOplNezav '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'"; break;
                    case 2003: my.Szap = "set dateformat dmy exec r_svodnall " + my.Szap + ""; break;
                    case 2002: my.Szap = "set dateformat dmy exec r_svodn " + my.Szap + ",2002," + (chPr.Checked ? 1 : 0); break;
                case 2020:
                    case 2001: my.Szap = "set dateformat dmy exec R_SmetnoeRaz " + my.Szap + "," + (nbut1 ==2001  ? nbut1.ToString() : "2002") + (nbut1 == 2001? "," + (chPr.Checked ? 1 : 0) : ""); break;
                    case 170: my.Szap = "set dateformat dmy exec sNezaversh  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'," + IdEnt.SelectedValue.ToString() + ",1"; break;
                case 2007:
                case 2005: my.Szap = "set dateformat dmy exec R_Buh  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" + Upred + "'," + my.Nbut.ToString(); break;
                case 2019: my.Szap = "set dateformat dmy exec R_Buh  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" + Upred + "'," + my.Nbut.ToString(); break;

                case 64:  my.Szap = "'" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'"; break;
                case 183:
                    my.Szap = "set dateformat dmy exec SSvodn  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'"; break;
                case 186:
                    my.Szap = "exec smrUpr.dbo.r_svodnall  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "',0,0,0"; break;
                case 189:
                    my.Szap = "exec sRepNZ  '" + d1.SelectedValue.ToString() + "','" + ((DateTime)d2.SelectedValue).AddMonths(1).AddDays(-1).ToString() + "',"+IdEnt.SelectedValue.ToString(); break;
                case 74:
                    my.Szap = "set dateformat dmy exec RSvodnZam  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "',0,1"; break;
                // case 2007: my.Szap = "set dateformat dmy exec R_Buh  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" + Upred + "'," + my.Nbut.ToString(); break;
                case 31:
                    my.Szap = " and Period >= '" + d1.SelectedValue.ToString() + "' and  Period  <= '" + d2.SelectedValue.ToString() + "'" + (Upred == "000" ? "" : "  and Pred = '" + Upred + "'");
                    my.Szap = my.Szap + " GROUP BY IdSm, Nomer, Object, Naim, SumBaz, SumTek, Zak, Sum91Or, PredName, Dogf2, DESCr, SumBazOr, SumTekOr, BazStObor, Osn";
                    my.showSprDGV(my.Nbut, false, true);
                    return;
                case 711:
                    my.Szap = " and Period >= '" + d1.SelectedValue.ToString() + "' and  Period  <= '" + d2.SelectedValue.ToString() + "'" + (Upred == "000" ? "" : "  and Pred = '" + Upred + "'");
                    break;
                case 181:
                    my.Szap = "exec sInvPrVip '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'," + IdEnt.SelectedValue.ToString();
                    my.SzapN = "'" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "'," + IdEnt.SelectedValue.ToString();
                    break;
                case 192:
                   
                    break;
                case 193:
                    my.Szap = "exec sForNZNotPrivjazki  '" + d1.SelectedValue.ToString() + "','" + d2.SelectedValue.ToString() + "','" + Upred + "'" ;
                    my.Nbut = 3000;
                    my.showSprDGV(my.Nbut, false, true);
                    return;
                default:
                    if (!my.isFormInMdi("frmSprZapros", my.Nbut, this))
                    {
                        my.showSprZapros(my.Nbut, false, true);
                    }
                    return;
            }
            fr.MdiParent = my.MDIForm;
            fr.Show();

        }

        private void frmVibSmet_FormClosing(object sender, FormClosingEventArgs e)
        {
            my.UperName = my.MDIForm.cUper.Text;
            my.UpredName = my.MDIForm.cUpred.Text;
        }
    }
}