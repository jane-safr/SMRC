using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmActsSub : Form
    {
        DataView dvActs;
        string gp = "";
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        public frmActsSub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = textBox1.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(DgvActs, m_searchInfo);
            DgvActs.CurrentRow.Selected = true;
        }

        private void frmActsSub_Load(object sender, EventArgs e)
        {
            //Set objRowLoop = new clsRowLoop();
            string strsql = "";
            //SSRow Row1 = null;

            //ПриОткрытии = true;

            this.Top = 0;
            this.Left = 0;
            switch (my.Nbut)
            {
                case 4:
                   Text  = "Субподряд " + my.UpredName;
                    gp = my.Upred;
                    break;
                case 0:
                   gp= my.Szap;
                    break;
                default:

                    my.sc.CommandText = "SELECT     Name, pred FROM         dbo.VidGPDog WHERE    IdVidDog = " + my.Nbut.ToString();
                    my.cn.Open();
                    SqlDataReader dr = my.sc.ExecuteReader();
                    if (!dr.Read())
                    {
                        MessageBox.Show(@"Нет данных по выбранному договору!");
                        my.cn.Close();
                    }
                    else
                    {

                        Text = "Субподряд " + dr[0].ToString().Substring(10, dr[0].ToString().Length  - 10);
                        gp = dr[1].ToString();
                        my.cn.Close();
                        dr.Close();
                    }
                    break;
            }


            //Set rs = null;
            //this.ркн_ТекМес = true;
            rbTekMes.Checked = true;
            strsql = "SELECT  iddog,Zak,  RegNomer, ZakName, IspName, Date_1,Isp,PredmetDog,Srok FROM v_DogForAktSub WHERE ((Zak='" + ((gp == "1726" | gp == "1725") ? "002" : gp) + "' and Vnut=1)";
            strsql = strsql + " or (Zak='" + gp + "' and VneshDog=1)) order by ZakName, IspName,RegNomer";
            //rs.CursorLocation = adUseClient;
            SqlDataAdapter sda = new SqlDataAdapter(strsql, my.sconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            idDog.DataSource = ds.Tables[0];
            idDog.ValueMember = "IdDog";
            idDog.DisplayMember = "RegNomer";
            Edneeis.Controls.MultiColumnComboBox.Column i3 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i3.ColumnMember = "RegNomer";
            i3.AutoSize = true;
            this.idDog.Columns.Add(i3);
            Edneeis.Controls.MultiColumnComboBox.Column i4 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i4.ColumnMember = "ZakName";
            i4.Width = 100;
            this.idDog.Columns.Add(i4);
            Edneeis.Controls.MultiColumnComboBox.Column i5 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i5.ColumnMember = "IspName";
            i5.Width = 100;
            this.idDog.Columns.Add(i5);
            Edneeis.Controls.MultiColumnComboBox.Column i6 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i6.ColumnMember = "Date_1";
            i6.Width = 100;
            this.idDog.Columns.Add(i6);
            Edneeis.Controls.MultiColumnComboBox.Column i7 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i7.ColumnMember = "PredmetDog";
            i7.Width = 400;
            this.idDog.Columns.Add(i7);
            idDog.ShowColumns = true;
            sda.Dispose();
            ds.Dispose();
            idDog.SelectedValue = 0;
            my.FillDC(idIstFin, 18, "");
            //DgvActs.DataSource = ds.Tables[0];
            SpisokObj();
            SpisokUsF2();
            SelAkts();
            checkBox1_CheckedChanged(null, null);
            RdWr(my.Dostup);

        }

        private void RemSum(double Summa)
        {
            //INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#
            //SSRow selRow = null;
            if (DgvActs.SelectedRows.Count == 0)
            {
                DgvActs.CurrentRow.Selected = true;
            }
            foreach (DataGridViewRow selRow in DgvActs.SelectedRows)
            {
                selRow.Cells["Отдать"].Value = Summa;

            }
            CountSelect();
        }
        private void RdWr(bool wr)
        {
            btnF3.Enabled = wr;
        }

        private void spisok(string Period)
        {
            string strsql = null;
            strsql = "set dateformat dmy exec F2_IzAktSub '" + gp + "','" + my.Upred  + "','" + Period + "','" + my.Uper + "'";

            SqlDataAdapter sda = new SqlDataAdapter(strsql, my.sconn);
            sda.SelectCommand.CommandTimeout = 9000;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dvActs = new DataView();
            dvActs.Table = ds.Tables[0];

            DgvActs.Columns.Add("Отдать", "Отдать");
            DgvActs.Columns.Add("Отдать б.ц.", "Отдать б.ц.");
            DgvActs.Columns.Add("Остаток", "Остаток");
            DgvActs.Columns.Add("ЗУ Баз", "ЗУ Баз");
            DgvActs.Columns.Add("ЗУ Тек", "ЗУ Тек");
            DgvActs.DataSource = dvActs;
            DgvActs.Columns["IdF2"].Visible = false;
            DgvActs.Columns["ost"].Visible = false;
            DgvActs.Columns["Pred"].Visible = false;
            DgvActs.Columns["kodunic"].HeaderText = "Код акта";
            DgvActs.Columns["Остаток"].DisplayIndex = 10;
            DgvActs.Columns["ЗУ Тек"].DisplayIndex = 9;
            DgvActs.Columns["ЗУ Баз"].DisplayIndex = 8;
            DgvActs.Columns["Отдать б.ц."].DisplayIndex = 7;
            DgvActs.Columns["Отдать"].DisplayIndex = 6;
            foreach (DataGridViewColumn dgvc in DgvActs.Columns)
            {
                if (dgvc.Name == "Отдать" | dgvc.Name == "Отдать б.ц." | dgvc.Name == "ЗУ Баз" | dgvc.Name == "ЗУ Тек")
                {
                    dgvc.DefaultCellStyle.ForeColor = Color.Blue;
                    dgvc.ReadOnly = false;
                }
                else
                {
                    dgvc.ReadOnly = true;
                }
                dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvc.ValueType =Type.GetType("double");
                dgvc.DefaultCellStyle.Format = "N2";
            }
            CountSelect();


        }
        private void SelAkts()
        {
            //throw new NotImplementedException();
            //int rowIndex = -1;
            //DataSet ds = new DataSet();
            DataTable dt = (DataTable)DgvUsF2.DataSource;
           // ds.Tables[0] = (DataTable)DgvUsF2.DataSource ;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                 DataGridViewRow row = DgvActs.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["IdF2"].Value.ToString().Equals(dt.Rows[i]["IdF2"].ToString()))
                   .FirstOrDefault();

                if (row != null)
                {
                    DgvActs.Rows[row.Index].Selected = true;
                    row.Cells["Отдать"].Value = dt.Rows[i]["Summa"].ToString();
                    row.Cells["Отдать б.ц."].Value = dt.Rows[i]["SummaBaz"].ToString();
                }
            }



        }

        private void SpisokUsF2()
        {
            string strsql = my.FilterSel(106, null, my.sconn, " and id_us = " + my.Id_us + " and idgen = smr.dbo.idpred('" +gp+ "')");

            SqlDataAdapter sda = new SqlDataAdapter(strsql, my.sconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DgvUsF2 .DataSource = ds.Tables[0];
            my.naimDG(my.headStr, DgvUsF2, "");
        }

        private void SpisokObj()
        {
            string sel1 = "";
            string strsql = my.FilterSel(107, null, my.sconn, "");
            if (strsql.ToUpper().Contains("* GROUP BY *")) 
            {
                sel1 = strsql.ToUpper().Replace(" GROUP BY ", " where id_us = " + my.Id_us  + " and idgen = smr.dbo.idpred('" + gp + "') GROUP BY ");
            }

            SqlDataAdapter sda = new SqlDataAdapter(strsql, my.sconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DgvObj.DataSource = ds.Tables[0];
            my.naimDG(my.headStr, DgvObj,"");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chDr.Checked)
            { dvActs.RowFilter = "pred ='" + my.Upred + "'"; } else dvActs.RowFilter = ""; 
        }

        private void rbTekMes_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (rbTekMes.Checked == true)
            {
              spisok("TekMes");
            }
            else
            {
                spisok("Mes");
            }

            checkBox1_CheckedChanged(null,null);
            Cursor.Current = Cursors.Default;
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            if (my.KontrolSMR(my.Uper, my.identpr, 2) == false)
            {
                return;
            }
            try
            {

                double Sum91 = 0;
                double SumTek = 0;
                string strsql = null;
                int i = 0;

                if (DgvActs.RowCount == 0 || idDog.SelectedValue == null || idDog.SelectedValue.ToString()  == "0" )
                {
                    return;
                }
                if (DgvActs.SelectedRows.Count == 0)
                {
                    return;
                }
                //    проверяем, если отдаваемая сумма = 0 то ф3 не делаем
                SumTek = 0;
                Sum91 = 0;
                foreach (DataGridViewRow selRow in DgvActs.SelectedRows)
                {
                    SumTek = SumTek + Convert.ToDouble( selRow.Cells["Отдать"].Value);
                    Sum91 = Sum91 + Convert.ToDouble(selRow.Cells["Выполнение91"].Value);
                }
                if (SumTek == 0)
                {
                    return;
                }
                long IdF3 = 0;

                if (btnF3.Text != "Доб. в Ф3")
                {

                    IdF3 = Convert.ToInt64(my.ExeScalar("exec F2_NewF3 '" + my.Upred + "','" + my.Uper + "','" + my.Id_us + "','" + idDog.SelectedValue + "',0,'" + gp + "',''"));
                    //IdF3 = Convert.ToInt64(my.ExeScalar("exec F2_NewF31 '001', '01.01.2017 0:00:00', '1', '137589', 0, '001', ''"));
                    my.ExeScalar("UPDATE Forma3 SET idIstFin=" + idIstFin.SelectedValue + " WHERE idf3 =" + IdF3);
                }

            string result = "";
                foreach (DataGridViewRow selRow in DgvActs.SelectedRows)
                {
                result = my.ExeScalar("exec sDogParChild " + idDog.SelectedValue + "," + selRow.Cells["idf2"].Value);
                if (result != "") 
                {
                    MessageBox.Show(result);
                }
                    my.ExeScalar("INSERT INTO SootvF2F3 (idf2,idf3,Summa,SummaBaz,ZUBaz, ZUTek) VALUES ('" + selRow.Cells["idf2"].Value + "','" + IdF3 + "'," + selRow.Cells["Отдать"].Value + "," + selRow.Cells["Отдать б.ц."].Value + "," + selRow.Cells["ЗУ Баз"].Value + "," + selRow.Cells["ЗУ Тек"].Value + ")");

            }
            strsql = "UPDATE Forma3 SET ";
            strsql = strsql + " Sum91= Sum91 + " + Sum91 + ", SumTek=SumTek + " + SumTek + " WHERE Idf3=" + IdF3;
                my.ExeScalar(strsql);
                my.ExeScalar("delete from tusf2 where id_us = " + my.Id_us + " and idgen =  smr.dbo.idpred('" + gp + "')");

            MessageBox.Show( "Готово !");
            rbTekMes_CheckedChanged(null, null);

            //if (btnF3.Text == "Доб. в Ф3")
            //{
            //    if (Pform.Name == "РаботаСФормой3")
            //    {
            //        Pform.Обновление;
            //        Close();
            //    }
            //}
            return;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelAkts();
            SpisokObj();
        }

        private void DgvActs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
          if (DgvActs["Отдать", e.RowIndex].Value ==null)
            { DgvActs["Отдать", e.RowIndex].Value = "0";
                DgvActs["Отдать б.ц.", e.RowIndex].Value = "0";
                DgvActs["ЗУ Баз", e.RowIndex].Value = "0";
                DgvActs["ЗУ Тек", e.RowIndex].Value = "0";
                DgvActs["Остаток", e.RowIndex].Value = DgvActs["ost", e.RowIndex].Value;
            }
          

       }

        private void button2_Click(object sender, EventArgs e)
        {

            if (DgvActs.SelectedRows.Count == 0)
            {
                DgvActs.CurrentRow.Selected = true;
            }
            foreach (DataGridViewRow selRow in DgvActs.SelectedRows)
            {
                selRow.Cells["Отдать"].Value = selRow.Cells["Получено"].Value ;
                selRow.Cells["Отдать б.ц."].Value = selRow.Cells["Выполнение91"].Value ;
            }
             CountSelect();
        }

        private void CountSelect()
        {
            double Получено = 0;
            double Отдать = 0;
            double Остаток = 0;
            try
            {


            foreach (DataGridViewRow  selRow in DgvActs.SelectedRows)
            {
                Получено = Получено + (double)selRow.Cells["Получено"].Value;
                if (selRow.Cells["Отдать"].Value != null)
                {
                    Отдать = Отдать + Convert.ToDouble( selRow.Cells["Отдать"].Value);
                }
                if (selRow.Cells["Остаток"].Value != null)
                {
                    Остаток = Остаток + Convert.ToDouble(selRow.Cells["Остаток"].Value);
                }
                if (Convert.ToDouble(selRow.Cells["Отдать"].Value) != 0)
                {
                    my.ExeScalar("exec sUsF2 " + my.Id_us + "," + selRow.Cells["IdF2"].Value + "," + selRow.Cells["Отдать"].Value + " , '" + gp + "'");
                }
            }
            lblSelect.Text = "По выделенному:  Получено = " + Получено + ", Отдать = " + Отдать + ", Остаток = " + Остаток;

            }
            catch (Exception)
            {
            }
            SpisokObj();
            SpisokUsF2();
        }

        private void txtVvodSum_Leave(object sender, EventArgs e)
        {
            try
            {
            if (txtVvodSum.Text != "")
            { RemSum(Convert.ToDouble(txtVvodSum.Text)); }
            }
            catch (Exception)
            {
            }

        }

        private void DgvActs_SelectionChanged(object sender, EventArgs e)
        {
            CountSelect();
        }

        private void DgvActs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (!my.IsNumeric(DgvActs[e.ColumnIndex, e.RowIndex].Value))
            //{ MessageBox.Show("Неправильный ввод суммы!"); DgvActs[e.ColumnIndex, e.RowIndex].Value = 0;  }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выделенные строки?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in DgvUsF2.SelectedRows)
                {
                    my.ExeScalar("delete from tusf2 where idusf2 =" + selRow.Cells["idusf2"].Value);

                }
                SpisokUsF2();
                SpisokObj();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            my.v_excel(DgvActs);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtVvodSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.ToString() == "\r")
            { idDog.Focus(); }

        }

        private void txtVvodSum_Validated(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!my.IsNumeric(tb.Text))
            { tb.Text = ""; }
        }

        private void DgvActs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvActs[e.ColumnIndex, e.RowIndex].Value != null && DgvActs[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Отдать")
            {
                if (!my.IsNumeric(DgvActs[e.ColumnIndex, e.RowIndex].Value))
                { MessageBox.Show("Неправильный ввод суммы!"); DgvActs[e.ColumnIndex, e.RowIndex].Value = 0; }
                { DgvActs["Остаток", e.RowIndex].Value = (double)DgvActs["Ost", e.RowIndex].Value - Convert.ToDouble(DgvActs[e.ColumnIndex, e.RowIndex].Value); }
            }
        }
    }
}
