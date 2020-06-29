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
    public partial class frmF3 : Form
    {
        public int IdF3; public int IdDog = 0; public int VidF3;
        public Boolean WithSave;
        int idZak; int idIsp; string ForF3; string WhoF3;
        DateTime Period; int idpred; 
        public frmF3()
        {
            InitializeComponent();
        }
        public string Nom()
        {
            string Nom = "";

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                Nom = Nom + listBox1.SelectedItems[i] + ",";
            }
            if (Nom != "") { Nom = Nom.Substring(0, Nom.Length - 1); };
            return Nom;
        }

        private void frmF3_Load(object sender, EventArgs e)
        {
            Tag = IdF3;
            WithSave = true;
            my.RdStream(NMrab, my.Login + "ActsZak1.txt");
            RdWr(my.Dostup);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            Edneeis.Controls.MultiColumnComboBox.Column i1 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i1.ColumnMember = "PersName";
            i1.AutoSize = true;
            i1.Header = "";
            FromIsp.Columns.Add(i1);
            Edneeis.Controls.MultiColumnComboBox.Column i2 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i2.ColumnMember = "PostName";
            i2.AutoSize = false;
            i2.Header = "";
            i2.Width = 200;
            FromIsp.Columns.Add(i2);
            FromIsp.ShowColumnHeader = false;
            FromIsp.ShowColumns = true;


            Edneeis.Controls.MultiColumnComboBox.Column i3 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i3.ColumnMember = "PersName";
            i3.AutoSize = true;
            i3.Header = "";
            FromZak.Columns.Add(i3);
            Edneeis.Controls.MultiColumnComboBox.Column i4 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i4.ColumnMember = "PostName";
            i4.AutoSize = false;
            i4.Header = "";
            i4.Width = 200;
            FromZak.Columns.Add(i4);
            FromZak.ShowColumnHeader = false;
            FromZak.ShowColumns = true;


        }
        private void RdWr(bool wr)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name.Substring(0, 3) == "but" || ctrl.Name.Substring(0, 2) == "Id")
                {
                    ctrl.Enabled = wr;
                }
                butDel.Enabled = wr;
                butSave.Enabled = wr;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            spisok();
        }
        public void spisok()
        {
            my.sc.CommandText = "SET DATEFORMAT dmy  SELECT * FROM v_F3Dog WHERE kodunic  in (select  stroka as IdF3 from IzStr('" + Nom() + "')) ORDER BY kodunic";
            my.cn.Open();
            SqlDataReader dr = my.sc.ExecuteReader();
            while (dr.Read())
            {
                chNotBaseOsn.Checked = (bool)dr["NotBaseOsn"];
                IdF3 = (int)dr["IdF3"];
                WhoF3 = dr["WhoF3"].ToString();
                ForF3 = dr["ForF3"].ToString();
                idZak = (int)dr["idZak"];
                idIsp = (int)dr["idIsp"];
                if ((bool)dr["Vnut"] || (short)dr["TipVneshDog"] == 3)
                {
                    VidF3 = 2;           //субподряд

                }
                else
                {
                    VidF3 = 1;                //к зак.
                }
                RegNomer.Text = dr["RegNomer"].ToString();

                IdDog = (int)dr["IdDog"];
                NMrab.Text = dr["Naim"].ToString();
                my.FillDC(idIstFin, 18, "");
                idIstFin.SelectedValue = (int)dr["IdIstFin"];
                if (VidF3 == 1)
                {
                    my.FillDC(IdF3Predjav, 24, " and (iddog = 0 or  iddog = " + IdDog.ToString() + ")");
                    IdF3Predjav.SelectedValue = (int)dr["IdF3Predjav"];
                    IdF3Predjav.Enabled = true;
                }
                else
                { IdF3Predjav.Enabled = false; }
                //my.FillDC(FromIsp, 36, " and idpred = " + idIsp.ToString());
                //my.FillDC(FromZak, 36, " and idpred = " + idZak.ToString());
                DataSet ds3 = new DataSet();
              String  s = "SELECT     IdPers, PersName, PostName FROM         sprav.dbo.v_IzPersonalF2  Where  idpred = " + idZak.ToString();
                SqlDataAdapter da1 = new SqlDataAdapter(s, my.sconn);
                da1.Fill(ds3);

                FromZak.DataSource = ds3.Tables[0];
                FromZak.DisplayMember = "PersName";
                FromZak.ValueMember = "IdPers";
                FromZak.RefreshColumns();

                DataSet ds = new DataSet();
                 s = "SELECT     IdPers, PersName, PostName FROM         sprav.dbo.v_IzPersonalF2  Where  idpred = " + idIsp.ToString();
                SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
                da.Fill(ds);

                FromIsp.DataSource = ds.Tables[0];
                FromIsp.DisplayMember = "PersName";
                FromIsp.ValueMember = "IdPers";
                FromIsp.RefreshColumns();
                FromZak.SelectedValue = (int)dr["FromZak"];
                FromIsp.SelectedValue = (int)dr["FromIsp"];
                lSum.Text = "на сумму  " + Convert.ToInt64(dr["SumTek"]).ToString() + " руб.";
                chDrOb.Checked = true;
                Dgv1.AllowUserToAddRows = false;
                Dgv1.AllowUserToDeleteRows = false;
                Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
                DataSet ds1 = my.GetDS(my.FilterSel(158, null, my.sconn, " and kodunic  in (select  stroka as IdF3 from IzStr('" + Nom() + "'))"), my.sconn);
                Dgv1.DataSource = ds1.Tables[0];
                { my.naimDG(my.headStr, Dgv1, my.widthStr); }

                DgvActs.AllowUserToAddRows = false;
                DgvActs.AllowUserToDeleteRows = false;
                //DgvActs.EditMode = DataGridViewEditMode.EditProgrammatically;
                DataSet ds2 = my.GetDS(my.FilterSel(159, null, my.sconn, " and kodunicF3  in (select  stroka as IdF3 from IzStr('" + Nom() + "'))"), my.sconn);
                DgvActs.DataSource = ds2.Tables[0];
                { my.naimDG(my.headStr, DgvActs, my.widthStr); }

            }
            dr.Close();
            my.cn.Close();
        }
        private void Save(bool PriZak)
        {
            String strsql = "";
            strsql = "UPDATE Forma3 SET IdIstFin=" + idIstFin.SelectedValue.ToString();
            if (VidF3 == 1)
            {
                strsql = strsql + ", idF3Predjav =" + IdF3Predjav.SelectedValue.ToString();
            }
            strsql = strsql + ", RegNomer ='" + RegNomer.Text + "'";
            strsql = strsql + ", Naim=" + "'" + (NMrab.Text.Length>255? NMrab.Text.Substring(0, 255) : NMrab.Text) + "'";

            strsql = strsql + ", NotBaseOsn =  " + (chNotBaseOsn.Checked ? 1: 0);
            strsql = strsql + ", update_date =  '" + DateTime.Now + "'";
            strsql = strsql + ", update_user =  '" + my.Login  + "'";

            strsql = strsql + " WHERE IdF3=" + IdF3.ToString();
            my.sc.CommandText = strsql;
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            if (!PriZak)
            {
                MessageBox.Show("Данные сохранены");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DgvActs.EndEdit();
            my.cn.Open();
            my.sc.CommandText = "exec sRecF3 " + IdF3.ToString();
            lSum.Text = "на сумму  " + Convert.ToInt64(my.sc.ExecuteScalar()).ToString() + " руб.";
            my.cn.Close();

        }

        private void butSave_Click(object sender, EventArgs e)
        {

            if (my.KontrolSMR(Period, idpred, VidF3) == false)
            {
                return;
            }
            DgvActs.EndEdit();
            Save(false);
        }

        //private void DgvActs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    my.sc.CommandText = "UPDATE SootvF2F3 SET  Summa = " + DgvActs.Rows[e.RowIndex].Cells["сумма"].Value + ", SummaBaz = " + DgvActs.Rows[e.RowIndex].Cells["сумма баз"].Value + ", ZUBaz = " + DgvActs.Rows[e.RowIndex].Cells["зу баз"].Value + ", ZUTek = " + DgvActs.Rows[e.RowIndex].Cells["зу тек"].Value + " WHERE ([IdSootv] =" + DgvActs.CurrentRow.Cells["IdSootv"].Value + ")";
        //    MessageBox.Show (my.sc.CommandText);
        //    //my.cn.Open();
        //    //my.sc.ExecuteScalar();
        //    //my.cn.Close();
        //}

        private void frmF3_FormClosing(object sender, FormClosingEventArgs e)
        {



            try
            {
                if (WithSave)
                {
                    DialogResult Otv = MessageBox.Show("Сохранить данные?", "Внимание!", MessageBoxButtons.YesNoCancel);
                    if (Otv == DialogResult.Yes) { Save(true); }
                    if (Otv == DialogResult.Cancel) { e.Cancel = true; }

                }
                my.WrStream(NMrab.Text, my.Login + "ActsZak1.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 0; DgvActs.EndEdit();
            while (i < DgvActs.RowCount)
            {
                DgvActs.Rows[i].Selected = true;
                i = i + 1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DgvActs.SelectedRows.Count > 0)
            {
                my.Nbut = IdDog;
                my.Vid = 2;
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

        private void button1_Click(object sender, EventArgs e)
        {
            my.Pform = this;
            my.Nbut = IdF3;
            if (!my.isFormInMdi("frmVibF3", my.Nbut, this))
            {
                frmVibF3 fr = new frmVibF3();
                fr.Tag = (int)my.Nbut;
                fr.idf3 = (int)my.Nbut;
                fr.iddog = IdDog;
                fr.MdiParent = my.MDIForm;
                fr.Show();
                //fr.TopLevel = false;
                //my.MDIFormCont.Controls.Add(fr);
                //fr.Show();

                //System.Windows.Forms.Splitter splitter1 = new System.Windows.Forms.Splitter();
                //splitter1.Dock = System.Windows.Forms.DockStyle.Left;
                //my.MDIFormCont.Controls.Add(splitter1);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            my.Nbut = 2;
            my.Szap = IdF3.ToString();
            if (!my.isFormInMdi("frmVibRabPeriod", my.Nbut, this))
            {
                frmVibRabPeriod fr = new frmVibRabPeriod();
                fr.Tag = my.Nbut;
                my.Pform = this;
               //fr.MdiParent = my.MDIForm;
                fr.ShowDialog();
            }
            //MessageBox.Show("Готово!");
        }

        private void butDel_Click(object sender, EventArgs e)
        {

            if (my.KontrolSMR(Period, idpred, VidF3) == false)
            {
                return;
            }
            try
            {
                string strsql = ""; 
                strsql = "SELECT top 1  1 as nm FROM v_F3OnChain WHERE idf3 =" + IdF3 + " and WhoF3 ='" + ForF3 + "'";
                
                if (my.ExeScalar(strsql) != "1" )
                {
                    if (MessageBox.Show("Удалить данную справку? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        my.ExeScalar("update forma3 set  update_date =  '" + DateTime.Now + "', update_user =  '" + my.Login + "'  WHERE IdF3=" + IdF3);
                        strsql = "Delete from Forma3 WHERE IdF3=" + IdF3;
                        listBox1.Items.Remove(listBox1.SelectedItem);

                        strsql = strsql + "; UPDATE    dbo.Forma2 Set     dbo.Forma2.VzjatVf3 = 0, Prinzak = 0 FROM         dbo.Forma2 LEFT OUTER JOIN dbo.vF3Zak ON dbo.Forma2.IdF2 = dbo.vF3Zak.IdF2  WHERE     (dbo.Forma2.VzjatVf3 = 1) AND (dbo.vF3Zak.IdF2 IS NULL)";
                        my.ExeScalar(strsql);
                            
                        if (listBox1.Items.Count == 0)
                        {
                            WithSave = false;
                            Close();
                            return;
                        }
                        listBox1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Удалить справку нельзя, акты прошли на субподряд"); //: cn.Close
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                spisok();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (my.KontrolSMR(Period, idpred, VidF3) == false)
            {
                return;
            }
            frmForF3 fr = null;


            my.sc.CommandText = "SELECT    dbo.Forma3.IdWhoF3,  dbo.Forma3.IdDog, Sprav.dbo.Dogovor.IdZak, Sprav.dbo.Dogovor.IdIsp FROM         dbo.Forma3 INNER JOIN                       Sprav.dbo.Dogovor ON dbo.Forma3.IdDog = Sprav.dbo.Dogovor.IdDog where idf3 = " + IdF3;
            my.cn.Open();
            SqlDataReader dr = my.sc.ExecuteReader();
            while (dr.Read())
            {
                                fr = new frmForF3();
                fr.MdiParent = my.MDIForm;
                if ((int)dr["IdWhoF3"] == 15)
                {
                    fr.rbZak.Checked = true;
                    fr.rbSub.Checked = false;
                }
                else
                {
                    fr.rbZak.Checked = false;
                    fr.rbSub.Checked = true;

                }
                fr.Show();
                fr.IdZak.SelectedValue = (int)dr["IdZak"];
                fr.IdIsp.SelectedValue = (int)dr["IdIsp"];
                fr.ObnDog();
                fr.IdDog.SelectedValue = (int)dr["IdDog"];
                fr.IdIstFin.SelectedValue = this.idIstFin.SelectedValue;
                fr.bF3.Text = "Добавить в справку";

                fr.IdF3 = IdF3;
                my.Pform = this;
                fr.Text = "Добавление актов в справку " + listBox1.SelectedValue;

               // fr.Focus()= true;
            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DgvActs.SelectedRows.Count == 0) DgvActs.CurrentRow.Selected = true;
            if (MessageBox.Show("Удалить выделенные строки?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //my.Up(da[0], ds.Tables[0]);
            try
            {

                foreach (DataGridViewRow selrow in DgvActs.SelectedRows)
                {

                        my.sc.CommandText = " exec dbo.DelActFromF3 " + IdF3 +"," + selrow.Cells["idf2"].Value.ToString() + ",'" + my.Login + "'";
                        my.cn.Open();
                        if (my.sc.ExecuteScalar().ToString() != "OK")

                        { MessageBox.Show("Акт удалить невозможно!"); return; }
                        my.cn.Close();
                    DgvActs.Rows.Remove(selrow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }

 
        }




        private void DgvActs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = DgvActs.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.IsInEditMode)
            {
                my.sc.CommandText = "UPDATE SootvF2F3 SET  Summa = " + DgvActs.Rows[e.RowIndex].Cells["сумма"].Value + ", SummaBaz = " + DgvActs.Rows[e.RowIndex].Cells["сумма баз"].Value + ", ZUBaz = " + DgvActs.Rows[e.RowIndex].Cells["зу баз"].Value + ", ZUTek = " + DgvActs.Rows[e.RowIndex].Cells["зу тек"].Value + " WHERE ([IdSootv] =" + DgvActs.CurrentRow.Cells["IdSootv"].Value + ")";
               // MessageBox.Show(my.sc.CommandText);
                my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
            }
        }
    }
}