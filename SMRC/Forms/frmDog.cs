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
    public partial class frmDog : Form
    {
       public int VidDog; string UGP;
        public frmDog()
        {
            InitializeComponent();
        }
        private void spisok()
        {
            try
            {


            string   strsql;
            switch (VidDog)
            {
                case -1:    //������ �������
      strsql = " set dateformat 'dmy'  SELECT DISTINCT iddog, RegNomer, ZakName, IspName  From dbo.v_DogForF3GP WHERE  TipVneshDog= 2 and (";
        strsql = strsql + "((idPred=" + my.identpr + " and Period='" + my.Uper + "' and SnjatieSKon=0 and SnjatieSKonBudOplZak=0)";
        strsql = strsql + " or (idpred=" + my.identpr + " and SnjatieSKonBudOplZak= 1 and Period <'" + my.Uper + "' )))";
                    break;
                case 0: //������������ ��������
        strsql = "set dateformat 'dmy'  SELECT DISTINCT  IdDog, RegNomer, ZakName, IspName FROM v_DogForF3Sub WHERE identpr=" + my.identpr + " and Period='" + my.Uper + "' and idwhof3<> 15";
                         break;
                default: //���������
        strsql = "set dateformat 'dmy' SELECT   DISTINCT  iddog, RegNomer, ZakName, IspName FROM         dbo.v_DogForF3GP  LEFT OUTER JOIN                      dbo.v_F2VzjatVF3 ON dbo.v_DogForF3GP.IdF2 = dbo.v_F2VzjatVF3.IdF2  WHERE  TipVneshDog= 1 and (";
        strsql = strsql + " ((dbo.v_DogForF3GP.idpred='" + my.identpr + "' and month(Period) =" + Convert.ToDateTime(my.Uper).Month.ToString() +  " and year(Period)=" + Convert.ToDateTime(my.Uper).Year.ToString();
        strsql = strsql + "  and SnjatieSKon=0 and SnjatieSKonBudOplZak=0   and Isp ='" + UGP + "')";
        strsql = strsql + " or (IdIsp="  + my.identpr +  " and month(Period)=" + Convert.ToDateTime(my.Uper).Month.ToString() + " and year(Period)=" + Convert.ToDateTime(my.Uper).Year.ToString();
        strsql = strsql + "  and SnjatieSKon=0 and SnjatieSKonBudOplZak=0 and Isp='" + UGP + "' and ObF3=1)";
        strsql = strsql + " or (dbo.v_DogForF3GP.idPred=" + my.identpr + "  and SnjatieSKonBudOplZak=1";
        strsql = strsql + " and Isp='" + UGP + "' and Period < '" + my.Uper + "' and ((dbo.v_F2VzjatVF3.idPred = " + my.identpr + " and PeriodF3 >= '" + Convert.ToDateTime(my.Uper).AddMonths(-12)   + "' ) or dbo.v_F2VzjatVF3.IdF2 IS NULL))";
        strsql = strsql + " or (IdIsp='" + my.identpr + "'  and SnjatieSKonBudOplZak=1";
        strsql = strsql + " and Isp='" + UGP + "' and Period < '" + my.Uper + "' and ObF3=1 and (dbo.v_F2VzjatVF3.idPred = " + my.identpr + " and PeriodF3 >= '" + Convert.ToDateTime(my.Uper).AddMonths(-12) + "' ))))";
                    break;
            }
            SqlDataAdapter sda = new SqlDataAdapter(strsql,my.sconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];
            my.naimDG("0,�����,��������,�����������", Dgv1, "0,200,100,100");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmDog_Load(object sender, EventArgs e)
        {
            Dgv1.BackgroundColor = System.Drawing.SystemColors.Menu;
            VidDog = my.Nbut;
            my.sc.CommandText = "SELECT     id_gr FROM         SluPolzPred WHERE     (Id_us = " + my.Id_us.ToString() + ") AND (identpr = " + my.identpr + ")";
            my.cn.Open();
            if (my.sc.ExecuteScalar() == null) { butF3.Enabled = false; }
            my.cn.Close();
            UGP = my.ExeScalar("Select KodEntpr from Sprav.dbo.tsentpr where identpr =" + VidDog);
            switch (VidDog)
            {
                case -1:
                    Text = "�������� " + my.UpredName + " � �����������";
                    break;
                case 0:
                    Text = "�������� ���������";
                    butActs.Enabled = false;
                    break;
                default:
                    Text = "�������� � �����������";
                    break;
            }
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            spisok();
        }

        private void butActs_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = " set dateformat 'dmy'  exec  s_AktDogPodpisNew " + my.identpr.ToString() + ",'" + my.Uper + "' ," + Dgv1.CurrentRow.Cells["IdDog"].Value + ",0";
            my.Pform = this;
            my.cn.Open();
            my.Nbut = (int)Dgv1.CurrentRow.Cells["IdDog"].Value;
            if (my.sc.ExecuteScalar() != null)
            {
                my.cn.Close(); if (!my.isFormInMdi("frmActsZak", my.Nbut, my.MDIForm))
                    {
                        Form fr = new frmActsZak();
                        fr.MdiParent = my.MDIForm;
                        fr.Tag = Dgv1.CurrentRow.Cells["IdDog"].Value ;
                        fr.Show();
                    }}
            else
                    {
                        my.cn.Close(); MessageBox.Show("��� ����� �� ������ ��������, �� ������ � ������� ����� �3");
            }
            //this.Dgv1
            
            //strsql = "SELECT     TipVneshDog, TipGPDog, ObF3 FROM         sprav.dbo.VneshDog WHERE     IdDog = " & Trim(��_��������.ActiveRow.Cells("IdDog").Value)
            //If rs.State > 0 Then rs.Close
            //Set rs = cn.Execute(strsql)
            //If rs.EOF = False And rs.BOF = False Then
            //    If IsNull(rs![TipVneshDog]) = False Then
            //        ��_��������������� = rs![TipVneshDog]
            //    Else
            //        ��_��������������� = ""
            //    End If
            //    If IsNull(rs![TipGPDog]) = False Then
            //        ��_������������� = rs![TipGPDog]
            //    Else
            //        ��_������������� = ""
            //    End If
            //    If IsNull(rs![ObF3]) = False Then
            //        ��_���������3���������� = rs![ObF3]
            //    Else
            //        ��_���������3���������� = False



            //    End If
            //End If
            //If rs.State > 0 Then rs.Close
            //Set rs = Nothing
        }

        private void butF3_Click(object sender, EventArgs e)
        {
            
String strsql = "set dateformat dmy SELECT * FROM v_F3Dog WHERE iddog=" + Dgv1.CurrentRow.Cells["IdDog"].Value + " and Period='" + my.Uper + "'";
strsql = strsql + " and IdEntpr=" + my.identpr.ToString();
my.sc.CommandText = strsql;
            my.cn.Open();
            SqlDataReader dr = my.sc.ExecuteReader();
            if (!dr.Read())
            {MessageBox.Show (@"�� ������ �������� ������� ����� �3 �� ������������, 
���� � ��� ����������� ����� �� ��������������"); my.cn.Close();
        }
            else
            { 
                frmF3 fr = new frmF3();fr.IdDog = (int)Dgv1.CurrentRow.Cells["IdDog"].Value;
                fr.listBox1.Items.Add(dr["kodunic"]);
            while (dr.Read())
            {  
                fr.listBox1.Items.Add(dr["kodunic"]);
            }
            my.cn.Close();
            dr.Close();
                //�������������3.��_������������.Selected(�������������3.��_������������.ListCount - 1) = True;
               Cursor.Current = Cursors.WaitCursor;
               fr.MdiParent = my.MDIForm; 
               fr.Show(); 
                
                Cursor.Current = Cursors.Default;  
            }



        }

        private void butex_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}