using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC.Forms
{
    public partial class frmVibF3 : Form
    {
        public int iddog; public int idf3; Form pform1;
        public frmVibF3()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmVibF3_Load(object sender, EventArgs e)
        {
            this.Top = 200;
            this.Left = 300;
            rbNDS.Checked  = true;
            rbKop.Checked    = true;
            pform1 = my.Pform;
        }

        private void ch2000_CheckedChanged(object sender, EventArgs e)
        {
            if ( ch2000.Checked )
            {
                 ch84.Checked = false;
                 ch91.Checked = false;
                ch2000AEP.Checked = false;
                ch84.Enabled = false;
                 ch91.Enabled = false;
            }
            else
            {
                 ch84.Enabled = true;
                 ch91.Enabled = true;
            }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = "select isnull(TipVneshDog,0) as TipVneshDog,PostZak,PostIsp from v_F3Dog Where idf3=" +  idf3.ToString();
            my.cn.Open();
            SqlDataReader dr = my.sc.ExecuteReader();
            dr.Read();
            int TipVneshDog = (short)dr["TipVneshDog"];
            string PostZak = dr["PostZak"].ToString();
            string PostIsp = dr["PostIsp"].ToString();
            dr.Close();
            my.cn.Close();
            my.Pform = pform1;
            //if (ch2000AEP.Checked)
            //{ //my.Nbut = idf3;
            //    frmRepF3 fr = new frmRepF3();
            //    fr.F3InRep(idf3, ((frmF3)pform1).VidF3, TipVneshDog, ((frmF3)pform1).chDrOb.Checked, ch84.Checked, ch91.Checked, (Int16)(chDavMat.Checked ? 1 : 0), rbNDS.Checked, rbKop.Checked,
            //         ((frmF3)pform1).FromIsp.Text.Trim(), PostIsp, ((frmF3)pform1).FromZak.Text.Trim(), PostZak, 0, ch2000.Checked,  chActs.Checked,chOborud.Checked, ch2000AEP.Checked,tfltr.Text, ((frmF3)pform1).chNotBaseOsn.Checked);
            //    fr.MdiParent = my.MDIForm;
            //    fr.Show();
            //}
            //else
            //if (ch2000.Checked)
            //{ //my.Nbut = idf3;
                frmRepF3 fr = new frmRepF3();
                fr.F3InRep(idf3, ((frmF3)pform1).VidF3, TipVneshDog, ((frmF3)pform1).chDrOb.Checked, ch84.Checked, ch91.Checked, (Int16)(chDavMat.Checked ? 1 : 0), rbNDS.Checked, rbKop.Checked,
                     ((frmF3)pform1).FromIsp.Text.Trim(), PostIsp, ((frmF3)pform1).FromZak.Text.Trim(), PostZak, 0, ch2000.Checked, chActs.Checked, chOborud.Checked, ch2000AEP.Checked, tfltr.Text, ((frmF3)pform1).chNotBaseOsn.Checked);
                fr.MdiParent = my.MDIForm;
                fr.Show();
            //}
            //else
            //{
            //   //ModOffice.F3InExcel(idf3, ((frmF3)pform1).VidF3, TipVneshDog, ((frmF3)pform1).chDrOb.Checked, ch84.Checked, ch91.Checked, (Int16)(chDavMat.Checked ? 1 : 0), rbNDS.Checked, rbKop.Checked,
            //   //      ((frmF3)pform1).FromIsp.Text.Trim(), PostIsp, ((frmF3)pform1).FromZak.Text.Trim(), PostZak, 0, ch2000.Checked,  chActs.Checked);
            //}

        }

        private void frmVibF3_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void ch2000AEP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ch2000AEP.Checked)
            {
                this.ch84.Checked = false;
                this.ch91.Checked = false;
                this.ch2000.Checked = false;
                this.ch84.Enabled = false;
                this.ch91.Enabled = false;
            }
            else
            {
                this.ch84.Enabled = true;
                this.ch91.Enabled = true;
            }
        }
    }
}