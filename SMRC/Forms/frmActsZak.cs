using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMRC.Forms
{
    public partial class frmActsZak : Form
    {
        //string[] autoList;
        clsSearchInfo m_searchInfo = new clsSearchInfo();
       public int IdDog = 0; int VidDog; //bool Active;
        public int IdF3;
        public frmActsZak()
        {
            InitializeComponent();
        }

        private void frmActsZak_Load(object sender, EventArgs e)
        {
            //Active = False
            //objRowLoop = new clsRowLoop;

            Text = "Работа с актами по договору  " + ((frmDog) my.Pform).Dgv1.CurrentRow.Cells[1].Value;
            IdDog = (int)((frmDog)my.Pform).Dgv1.CurrentRow.Cells["IdDog"].Value;
            VidDog = ((frmDog)my.Pform).VidDog;
            RdWr(my.Dostup);
            my.sc.CommandText = "SELECT     id_gr FROM         SluPolzPred WHERE     (Id_us = " + my.Id_us.ToString() + ") AND (identpr = " + my.identpr.ToString() + ")";
            my.cn.Open();
            if (my.sc.ExecuteScalar() != DBNull.Value && (int)my.sc.ExecuteScalar() == 0) { RdWr(false); }
            my.cn.Close();
            my.FillDC(idIstFin, 18, "");
            spisok();

            my.RdStream(NMrab, my.Login + "ActsZak1.txt");
            Top = 0;Left = 0;
        }


           
        

 



        private void  RdWr(bool wr)
        {
            tsbF3.Enabled = wr;
        }
        private void spisok()
        {
            try
            {

            string strsql = " set dateformat 'dmy'  exec  s_AktDogPodpisNew " + my.identpr.ToString() + ",'" + my.Uper + "' ," + IdDog.ToString() + "," + idIstFin.SelectedValue.ToString();
            DataSet ds = my.GetDS(strsql, my.sconn);
            DgvActs.DataSource = ds.Tables[0];
            DgvActs.Columns["IdIstFin"].Visible = false;
            DgvActs.Columns["IdF2"].Visible = false;
            DgvActs.Columns["Vip91"].Visible = false;
            DgvActs.DataSource = ds.Tables[0];
            DgvActs.Columns[0].Visible = false;
            DgvActs.AllowUserToAddRows = false;
            my.sc.CommandText = "Select ObF3 from sprav.dbo.VneshDog where IdDog =" + IdDog.ToString();
            my.cn.Open();
            if (my.sc.ExecuteScalar() != DBNull.Value && (bool)my.sc.ExecuteScalar() )
            {
                my.sc.CommandText = "Select idIsp from sprav.dbo.Dogovor where IdDog=" + IdDog.ToString();
                if (my.sc.ExecuteScalar() != DBNull.Value && (int)my.sc.ExecuteScalar() != my.identpr)
                { tsbF3.Enabled = false; }
            }
            my.cn.Close();

            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open) my.cn.Close();
                MessageBox.Show(ex.Message);
            }

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = TextBox1.Text ;
            m_searchInfo.searchDirection = SearchDirectionEnum.All ;
            m_searchInfo.searchContent = 0 ;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null ;
            my.search(DgvActs, m_searchInfo);
            DgvActs.CurrentRow.Selected = true;
        }

        private void frmActsZak_FormClosing(object sender, FormClosingEventArgs e)
        {
            my.WrStream(NMrab.Text, my.Login + "ActsZak1.txt");
        }

        private void NMrab_Leave(object sender, EventArgs e)
        {
            my.WrStream(NMrab.Text, my.Login + "ActsZak1.txt");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int i = 0; DgvActs.EndEdit(); 
            while( i < DgvActs.RowCount)
            { DgvActs.Rows[i].Selected = (bool)DgvActs.Rows[i].Cells["Выбор"].Value;
            i = i + 1;}
        }

        private void tsbSelAll_Click(object sender, EventArgs e)
        {
            int i = 0; DgvActs.EndEdit(); 
            while (i < DgvActs.RowCount )
            {
                DgvActs.Rows[i].Selected = true;
                i = i + 1;
            }
        }

        private void tsbSelRem_Click(object sender, EventArgs e)
        {
            int i = 0; DgvActs.EndEdit();
            while (i < DgvActs.RowCount )
            {
                DgvActs.Rows[i].Cells["Выбор"].Value = false;
                i = i + 1;
            }
        }

        private void tsbEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalcSel()
        {
            double Sum = 0;
            if (DgvActs.SelectedRows.Count == 0 )
            {LSum.Visible = false;}
            else
            {LSum.Visible = true;}
            foreach (DataGridViewRow selrow in DgvActs.SelectedRows)
            { Sum = Sum + (double)selrow.Cells["Сумма"].Value; }

            LSum.Text = "По выделенному:  Сумма = " + Sum;
        }

        private void Dgv1_SelectionChanged(object sender, EventArgs e)
        {
            CalcSel();
        }

        private void idIstFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(idIstFin.SelectedValue)) { spisok(); };
        }

        private void tsbReestr_Click(object sender, EventArgs e)
        {
            if (DgvActs.SelectedRows.Count > 0)
            {
                my.Nbut = IdDog;
                my.Vid = 1;
                my.Pform = this;
                if (!my.isFormInMdi("frmVibReestr", my.Nbut, this))
                {
                    frmVibReestr fr = new frmVibReestr();
                    fr.Tag = (int)my.Nbut;
                    fr.MdiParent = my.MDIForm;
                    fr.Show();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одного акта!");
            }
        }

        private void tsbF3_Click(object sender, EventArgs e)
        {
            if (my.KontrolSMR(my.Uper, my.identpr, 0) == false)
            {
                return;
            }
          
            //On Error GoTo ex

            string strsql = "";
            double Sum91;
            double SumTek;

            if (DgvActs.Rows.Count > 0)
            {

                    strsql = "set dateformat 'dmy' exec F2_NewF3 '" + my.Upred + "','" + my.Uper + "','" + my.Id_us + "'," + IdDog + "," + VidDog; //& ",'015'," &
                IdF3 = Convert.ToInt32( my.ExeScalar(strsql));
                    Sum91 = 0;
                    SumTek = 0;
                   my.ExeScalar( "UPDATE Forma3 SET IdIstFin='" + idIstFin.SelectedValue  + "', Naim = '" + NMrab.Text + "'   WHERE Idf3=" + IdF3);

                foreach (DataGridViewRow selrow in DgvActs.SelectedRows)
                {
                    Sum91 = Sum91 + System.Convert.ToDouble(selrow.Cells["Vip91"].Value); 
                    SumTek = SumTek + System.Convert.ToDouble(selrow.Cells["Сумма"].Value);
                    strsql = "INSERT INTO SootvF2F3 (idF2,IdF3,Summa) VALUES (" + selrow.Cells["IdF2"].Value + "," + IdF3 + "," + selrow.Cells["Сумма"].Value + "); UPDATE Forma2 SET VzjatvF3=1 WHERE idf2='" + selrow.Cells["idf2"].Value + "'";
                    my.ExeScalar(strsql);
                }

                MessageBox.Show("Готово !");
                spisok();


            }
       // ex:
        }
    }
}