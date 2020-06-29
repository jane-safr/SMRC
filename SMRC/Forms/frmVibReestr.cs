using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmVibReestr : Form
    {
        int iddog; int nbut1;Form pform1;
        public frmVibReestr()
        {
            InitializeComponent();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            SMRC.DGVt dg = (SMRC.DGVt)pform1.GetType().InvokeMember("DgvActs", System.Reflection.BindingFlags.GetField, null, pform1, null);
            my.Szap = "";
            int kol = dg.SelectedRows.Count;
            if (kol == 0) return;
            for (int i = 0; i < kol; i++)
            {
                my.Szap = my.Szap + dg.SelectedRows[i].Cells[0].Value + ",";
            }
            my.Szap = my.Szap.Substring(0, my.Szap.Length - 1);
            my.Nbut = nbut1;
            //switch (nbut1)
            //{
                //case 1:
                //case 4:
                //case 8:
                //case 20:
                //case 13:
                //case 21:
                //case 25:
                //case 11:
                //    {
                        frmReps fr = new frmReps();
                        my.Ustr = "";
                        my.MyStr[0] = (rb84.Checked ? "1" : "2");
                        fr.MdiParent = my.MDIForm;
                        my.Pform = pform1;
                        fr.Show();
                        //break;
                //    }
                //default:
                //    break;
            //}
            //if nbut1 = 17 Or nbut1 = 23 Or nbut1 = 28 Then
            //    nbut = nbut1 + 2
            //ElseIf nbut1 = 20 Then
            //    nbut = nbut1
            //ElseIf nbut1 = 0 Then
            //    nbut = 2
            //Else
            //    nbut = nbut1 + IIf(nbut1 = 11, фл_ДавальчМатериалы, 0) 
            //End If




            //If nbut = 2 Or nbut = 6 Then reestr: Exit Sub
            //If nbut1 = 1 Then reestrUsKom: Exit Sub
            //If nbut1 = 2 Then reestrUsKom1: Exit Sub
            //If nbut1 = 3 Then reestrSUS: Exit Sub
            //If nbut1 = 5 Then nbut = nbut1: reestr2000: Exit Sub
            //If nbut1 = 6 Then nbut = nbut1: reestr2000: Exit Sub
            //Set fr = New CR
            // fr.Show
            //ex:

        }

        private void frmVibReestr_Load(object sender, EventArgs e)
        {
            iddog = my.Nbut;
            //vid = my.Vid;
            pform1 = my.Pform;
            Top = 0; Left = 0;
            my.sc.CommandText = "SELECT * FROM sprav.dbo.Dogovor WHERE IdDog=" + iddog.ToString(); my.cn.Open();
            System.Data.SqlClient.SqlDataReader DRd = my.sc.ExecuteReader();
            DRd.Read();

            if ((bool)DRd["Vnut"])
            {
                chT2.Visible = false;
                chT2.Checked = false;
            }
            else
            {
                if ((int)DRd["idIsp"] != 1)
                { chT2.Enabled = true; }
                else
                { chT2.Enabled = false; }
            }
            DRd.Close();
            my.cn.Close();
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
               groupBox3.Visible = true;
               nbut1 = Convert.ToInt32( ((RadioButton)sender).Tag);
               if (nbut1 == 11) { groupBox3.Visible = true; } else { groupBox3.Visible = false; }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVibReestr_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }


    }
}