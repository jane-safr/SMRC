using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmForF3 : Form
    {
        public int IdF3; DataSet ds;
        //public int IdDog = 0;
        public frmForF3()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in DgvActs.SelectedRows)
                {
                    DgvActs.Rows.Remove(dr);
                }
                SumF3();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmForF3_Load(object sender, EventArgs e)
        {
            my.FillDC(IdZak, 7, " and identpr in (SELECT DISTINCT IdZak FROM  Sprav.dbo.Dogovor WHERE  (IdDog = 0) OR (Vnut = 1) OR (VneshDog = 1))");
            my.FillDC(IdIsp, 7, " and identpr in (SELECT DISTINCT IdIsp FROM  Sprav.dbo.Dogovor WHERE  (IdDog= 0) OR (Vnut = 1) OR (VneshDog = 1))");
            my.FillDC(IdIstFin, 18, " ");

            DataTable dt = new DataTable();
            dt.Columns.Add("IdF2", typeof(Int32));
            dt.Columns.Add("�������", typeof(String));
            dt.Columns.Add("��������", typeof(Double));
            dt.Columns.Add("������", typeof(Double));
            dt.Columns.Add("�������", typeof(Double));
            dt.Columns.Add("Ost", typeof(Double));
            ds = new DataSet();
            ds.Tables.Add(dt);

            DgvActs.DataSource = dt;
            DgvActs.Columns[0].Visible = false;
            DgvActs.Columns[5].Visible = false;
            DgvActs.Columns[1].Width = 80;
            DgvActs.Columns[2].Width = 80;
            DgvActs.Columns[3].Width = 80;
            DgvActs.Columns[4].Width = 80;
            DgvActs.AllowUserToAddRows = false;
            my.RdStream(NMrab, my.Login + "ActsZak1.txt");
        }
        public void ObnDog()
        {
            //On Error GoTo ex:
            if (!my.IsNumeric(IdIsp.SelectedValue) || !my.IsNumeric(IdZak.SelectedValue)) return;
            String strsql = "";
            strsql = strsql + " and IdZak = " + IdZak.SelectedValue.ToString();
            strsql = strsql + " and IdIsp = " + IdIsp.SelectedValue.ToString();
            if (rbZak.Checked)
            {

                //'������ �������
                strsql = " set dateformat 'dmy'  SELECT DISTINCT iddog, RegNomer, ZakName, IspName  From dbo.v_DogForF3GP WHERE  (TipVneshDog= 2 and (";
                strsql = strsql + "((idPred=" + my.identpr.ToString() + " and Period='" + my.Uper.ToString() + "' and SnjatieSKon=0 and SnjatieSKonBudOplZak=0)";
                strsql = strsql + " or (idpred=" + my.identpr.ToString() + " and SnjatieSKonBudOplZak= 1 and Period <'" + my.Uper.ToString() + "' ))))  AND (IdZak = " + IdZak.SelectedValue.ToString() + ") AND  (IdIsp = " + IdIsp.SelectedValue.ToString() + ") ";
                //'���������
                strsql = strsql + " union all SELECT   DISTINCT  iddog, RegNomer, ZakName, IspName FROM         dbo.v_DogForF3GP  LEFT OUTER JOIN                      dbo.v_F2VzjatVF3 ON dbo.v_DogForF3GP.IdF2 = dbo.v_F2VzjatVF3.IdF2  WHERE  TipVneshDog= 1 and (";
                strsql = strsql + " ((dbo.v_DogForF3GP.idpred=" + my.identpr.ToString() + " and month(Period) =" + my.Uper.Month.ToString() + " and year(Period)=" + my.Uper.Year;
                strsql = strsql + "  and SnjatieSKon=0 and SnjatieSKonBudOplZak=0  and IdVidDogEnt =" + IdIsp.SelectedValue.ToString() + ")";
                strsql = strsql + " or (idIsp='" + my.identpr.ToString() + "' and month(Period)=" + my.Uper.Month.ToString() + " and year(Period)=" + my.Uper.Year;
                strsql = strsql + "  and SnjatieSKon=0 and SnjatieSKonBudOplZak=0 and IdVidDogEnt=" + IdIsp.SelectedValue.ToString() + " and ObF3=1)";
                strsql = strsql + " or (dbo.v_DogForF3GP.idpred=" + my.identpr.ToString() + " and SnjatieSKonBudOplZak=1";
                strsql = strsql + " and IdVidDogEnt='" + IdIsp.SelectedValue.ToString() + "' and Period < '" + my.Uper.ToString() + "' and ((dbo.v_F2VzjatVF3.idPred = '" + my.identpr.ToString() + "' and PeriodF3 >= '" + my.Uper.AddMonths(-12) + "' ) or dbo.v_F2VzjatVF3.IdF2 IS NULL))";
                strsql = strsql + " or (idIsp=" + my.identpr.ToString() + "  and SnjatieSKonBudOplZak=1";
                strsql = strsql + " and IdVidDogEnt=" + IdIsp.SelectedValue.ToString() + " and Period < '" + my.Uper.ToString() + "' and ObF3=1))) AND (IdZak = " + IdZak.SelectedValue.ToString() + ") AND  (IdIsp = " + IdIsp.SelectedValue.ToString() + ") ";
                my.FillDC(IdDog, 1000, strsql);
            }
            else
            { strsql = strsql + " and idStatDog <> 4  and (Vnut = 1 or VneshDog = 1) ";
                my.FillDC(IdDog, 16, strsql);
            }
            //Set Me.SSUltraGrid1.DataSource = Nothing
            //Set Me.��_����.DataSource = Nothing

            //If Not r.EOF Then r.MoveFirst
            //Do Until r.EOF
            //r.Delete
            //r.MoveNext
            //Loop
            //SumF3
            //Set Me.��_����.DataSource = r
            ////ex:
        }

        private void idZak_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObnDog();
        }

        private void IdIsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObnDog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChDr.Visible = false;
            ObnDog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChDr.Visible = true;
            ObnDog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string strsql = ""; DataSet ds1;

                if (rbSub.Checked)
                {
                    strsql = "set dateformat dmy exec F2_FindActs " + IdZak.SelectedValue.ToString() + " , '" + tKodUnic.Text + "'," + Microsoft.VisualBasic.Conversion.Val(this.tSum.Text) + ", " + my.identpr.ToString();
                    ds1 = my.GetDS(strsql, my.sconn);
                    dgVt1.DataSource = ds1.Tables[0];
                }
                else
                {

                    strsql = "set dateformat 'dmy'  exec  s_AktDogPodpis '" + my.Upred + "','" + my.Uper + "' ," + IdDog.SelectedValue + "," + IdIstFin.SelectedValue;
                    ds1 = my.GetDS(strsql, my.sconn);
                    DataView dv = new DataView();
                    dv.Table = ds1.Tables[0];
                    dv.RowFilter = ((tKodUnic.Text.Trim(' ') != "") ? " ������� like '" + tKodUnic.Text.Trim(' ') + "*'" : "") + ((my.IsNumeric(tSum.Text)) ? ((this.tKodUnic.Text.Trim(' ') != "") ? " and " : "") + " ����� = " + tSum.Text : "");
                    dgVt1.DataSource = dv;

                    //    // JANE ���������� ������ �3
                    //    //'''''''''''''''''''''''''''''''''
                    bool ObF3 = Convert.ToBoolean(my.ExeScalar("Select ObF3 from sprav.dbo.VneshDog where IdDog =" + IdDog.SelectedValue));
                    //  ado_rs1.Open , cn;

                    if (ObF3 == true)
                    {
                        string isp = my.ExeScalar("Select Isp from sprav.dbo.Dogovor where IdDog=" + IdDog.SelectedValue);
                        if (isp != "")
                        {
                            if (isp != my.Upred)
                            {
                                bF3.Enabled = false;
                            }
                            else
                            {
                                bF3.Enabled = true;
                            }
                        }
                    }
                }
                dgVt1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "idf2 = " + dgVt1.SelectedRows[0].Cells["IdF2"].Value;
                if (dv.Count != 0)
                {
                    return;
                }
                dv.RowFilter = "";
                DataRow r = ds.Tables[0].Rows.Add();
                // r.AddNew();
                if (rbZak.Checked)
                {
                    r["idf2"] = dgVt1.SelectedRows[0].Cells["IdF2"].Value;
                    r["�������"] = dgVt1.SelectedRows[0].Cells["�������"].Value;
                    r["��������"] = dgVt1.SelectedRows[0].Cells["�����"].Value;
                    r["������"] = dgVt1.SelectedRows[0].Cells["�����"].Value;
                    r["�������"] = 0;
                    r["Ost"] = 0;
                    DgvActs.Columns["��������"].Visible = false;
                    DgvActs.Columns["�������"].Visible = false;
                }
                else
                {
                    r["idf2"] = dgVt1.SelectedRows[0].Cells["IdF2"].Value;
                    r["�������"] = dgVt1.SelectedRows[0].Cells["�������"].Value;
                    r["��������"] = dgVt1.SelectedRows[0].Cells["��������"].Value;
                    r["������"] = dgVt1.SelectedRows[0].Cells["�������"].Value;
                    r["�������"] = 0; 
                    r["Ost"] = dgVt1.SelectedRows[0].Cells["�������"].Value;
                    DgvActs.Columns["��������"].Visible = true;
                    DgvActs.Columns["�������"].Visible = true;
                }
                // r.Update();
                SumF3();

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void SumF3()
        {
            //SSRow selRow = null;
            long Poluch = 0;
            long Otd = 0;
            long Ost = 0;
            for (int i = 0; i < DgvActs.Rows.Count; i++)
            {
                Poluch =Poluch + my.Val(DgvActs.Rows[i].Cells["��������"].Value.ToString());
                if (DgvActs.Rows[i].Cells["������"].Value.ToString() != "")
                {
                    Otd = Otd + Convert.ToInt64(DgvActs.Rows[i].Cells["������"].Value);
                }
                if (DgvActs.Rows[i].Cells["�������"].Value.ToString() != "")
                {
                    Ost = Ost + Convert.ToInt64(DgvActs.Rows[i].Cells["�������"].Value);
                }

            }

            lblSum.Text = "�������� = " + Poluch + ", ������ = " + Otd + ", ������� = " + Ost;

        }

        private void bF3_Click(object sender, EventArgs e)
        {
            try
            {
                if (my.Val(IdDog.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("�������� �������!", "��������!");
                    return;
                }
                if (my.Val(IdIstFin.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("�������� �������� ��������������!", "��������!");
                    return;
                }
                if ( DgvActs.Rows.Count == 0)
                {
                    MessageBox.Show("�������� ���� ��� �������� �����3!", "��������!");
                    return;
                }
                double Sum91 = 0;
                double SumTek = 0;
                string strsql = "";
                //int i = 0;

                //    ���������, ���� ���������� ����� = 0 �� �3 �� ������
                SumTek = 0;
                Sum91 = 0;
               // Set selRow = ��_����.GetRow(ssChildRowFirst);
                long IdEnt = 0;
                if (!this.ChDr.Checked)
                {
                    IdEnt = my.identpr;
                }
                else
                {
                    IdEnt = 0;
                }

                for (int i = 0; i < DgvActs.Rows.Count; i++)
                {

                    if (DgvActs.Rows[i].Cells["������"].Value.ToString() != "")
                    {
                        SumTek = SumTek + Convert.ToInt64(DgvActs.Rows[i].Cells["������"].Value);
                    }
                }

                if (SumTek == 0)
                {
                    if (MessageBox.Show("����� �� ����� = 0! ���������� ������ ������� ����� �3?", "��������!", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                if (this.bF3.Text != "�������� � �������")
                {

                    strsql = "exec F2NewF3 " + IdEnt + ",'" + my.Uper + "','" + my.Id_us + "','" + IdDog.SelectedValue + "',0,'" + (rbZak.Checked ? "15" : IdZak.SelectedValue) + "','" + IdIsp.SelectedValue + "'";
                    IdF3 = Convert.ToInt32( my.ExeScalar(strsql));
                    my.ExeScalar("UPDATE Forma3 SET idIstFin=" + my.Val(IdIstFin.SelectedValue.ToString()) + " WHERE idf3 =" + IdF3);
                }

                //���������� � �� �� ������ ��������� ���� �������
                //�������� � "�������������2�3"
                for (int i = 0; i < DgvActs.Rows.Count; i++)
                {

                    if (DgvActs.Rows[i].Cells["������"].Value.ToString() != "")
                    {
                        strsql = "INSERT INTO SootvF2F3 (idf2,idf3,Summa) VALUES (" + DgvActs.Rows[i].Cells["idf2"].Value + "," + IdF3 + "," + DgvActs.Rows[i].Cells["������"].Value + ")";
                    }
                }

                my.ExeScalar(strsql);
                strsql = "UPDATE Forma3 SET ";
                strsql = strsql + " Sum91= Sum91 + " + Sum91 + ", SumTek=SumTek + " + SumTek + " WHERE Idf3=" + IdF3;
                my.ExeScalar(strsql);

                my.ExeScalar("delete from tusf2 where id_us = " + my.Id_us + " and idgen = " + IdZak.SelectedValue);

                MessageBox.Show("������ !");
                foreach (DataGridViewRow dr in DgvActs.Rows)
                {
                    DgvActs.Rows.Remove(dr);
                }
                SumF3();
     
                //���_����������_Click
                if (this.bF3.Text == "�������� � �������")
                {
                    if (my.Pform.Name == "frmF3")
                    {
                        ((frmF3)my.Pform).spisok();
                        Close();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}


