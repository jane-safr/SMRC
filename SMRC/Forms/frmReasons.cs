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
    public partial class frmReasons : Form
    {
        FontStyle style; String sel1 = ""; String s1 = ""; Byte us; DataView  dv;
        string selG; string RowFilter; string[] itemsT; string items;
        public frmReasons()
        {
            InitializeComponent();
        }

        private void frmReasons_Load(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 0)
            {
                ListBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
                 items = " |Локальный номер|Инв.нoмер сметы|Наименование сметы|Действующая смета|Статус у заказчика|Основание|Выполнено в БЦ|Выполнено в ТЦ|Исполнитель|Причина НЗП|Примечание|Объект|Проект|Дата образования НЗП|Блок";
                string[] itemsF = items.ToString().Split('|');
                string items1 = " |Nomer|NDoc|NMSmeti|SmetaD|StatusZak|Osn|Vip91|VipTek|Ispol|Reason|Prim|Object|KodDog|DateStartNZP|block";
                itemsT = items1.ToString().Split('|');
                ListBox1.DataSource = itemsF;
                ListBox1.SelectedItem = null;
                style = new FontStyle();
                style |= FontStyle.Bold;
                RefR();
                us = 1;
                selG = "SELECT  cast(0 as bit) as Vib,     Nomer, NDoc, NMSmeti, SmetaD, StatusZak, Osn, Vip91, VipTek, Ispol, Reason, Prim, Object, KodDog,DateStartNZP,block,idsm FROM  Sprav.dbo.vSmetiReason where (1=1) ";
               
            }
        }
        private void ListBox1_DrawItem(object sender,
System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Gray);//Choose the color

            e.DrawBackground();
            //  if (e.Index != 0)
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 10.0F, style), Brushes.DarkSlateGray, e.Bounds, StringFormat.GenericDefault);
            //DarkSlateGray DarkSlateGray
        }

        private void button1_Click(object sender, EventArgs e)
        {
            my.Szap = "";
            my.Nbut = 716;
            //my.Nbut = 8;
            bool withup = true;
            my.Pform = this;
              //if (my.Nbut == 704) { if (my.UserInGroup(my.Id_us,234)) ; }
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, withup, true);
            }
        }
        public void RefR() { my.FillDC(idReason, 79, ""); my.FillDC(idStatus, 80, ""); my.FillDC(IdBlock, 41, " and vid= 22 "); }
        private void frmReasons_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBox1.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Выберите поле для фильтра! ", "Внимание!"); return;
                }
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Заполните строку поиска для " + ListBox1.SelectedItems[0].ToString(), "Внимание!"); return;
                }


                if (sel1 == "") { TextBox2.Text = TextBox2.Text + " где "; }
                { s1 = " like '%" + textBox1.Text + "%'"; }


                sel1 = "  [" + itemsT[ListBox1.SelectedIndices[0]] + "]" + s1;


                TextBox2.Text = TextBox2.Text + "  " + ListBox1.SelectedItems[0].ToString() + " содержит " + textBox1.Text + ",";
                SetFilter();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Указанный фильтр недопустим! " + ex.Message, "Ошибка!");
                sel1 = "";
                //throw;
            }
        }
        private void remFilter()
        {
            TextBox2.Tag = "";
            RowFilter = "";
            Dgv1.DataSource = null;
            label1.Text = "";
            sel1 = "";
            TextBox2.Text = "Выбрать все сметы ";

            //for (int i = 0; i < 20; i++)
            //{
            //    selzap1[i] = "";
            //    Textbox2sel[i] = "";
            //}

            //Textbox2sel[0] = TextBox2.Text;
            //isch = 0;
            //TForward.Enabled = false;
            //TBack.Enabled = false;
            //MaxIsch = 0;

            TextBox2.Text = "Выбрать все записи ";
            if (dv == null)
                label1.Text = "";
            else
                label1.Text = "Всего: " + dv.Count.ToString();
        }
        private void  SetDv(string flt)
        {
            DataSet ds = my.GetDS(selG + flt, my.sconn);
            dv = new DataView();
            dv.Table = ds.Tables[0];
            Dgv1.DataSource = null;
            Dgv1.DataSource = dv;
                label1.Text = "Всего: " + dv.Count.ToString();
            Dgv1.Columns["idsm"].Visible = false;
            Dgv1.Columns["DateStartNZP"].DefaultCellStyle.ForeColor = Color.Blue;
            Dgv1.Columns["Vib"].DefaultCellStyle.ForeColor = Color.Blue;
            Dgv1.Columns["SmetaD"].DefaultCellStyle.ForeColor = Color.Blue;
            Dgv1.Columns["Prim"].DefaultCellStyle.ForeColor = Color.Blue;
            my.naimDG(items.ToString().Replace("|",","), Dgv1, "");
        }
        private void SetFilter()
        {
            try
            {
                //if (us == 0)
                //{
                //    RowFilter = RowFilter.ToString() + " and " + (RowFilter != "" ? " and (" : "(").ToString() + sel1 + ")";
                //    //isch = isch + 1;
                //    ////dv.RowFilter = "";
                //    //MaxIsch = (int)MaxIsch < isch ? isch : MaxIsch;
                //    //selzap1[isch] = dv.RowFilter;
                //    //Textbox2sel[isch] = TextBox2.Text;
                //    //if (MaxIsch >= 20)
                //    //{
                //    //    for (int i = 0; i <= 18; i++)
                //    //    {
                //    //        selzap1[i] = selzap1[i + 2];
                //    //        Textbox2sel[i] = Textbox2sel[i + 2];
                //    //    }
                //    //    MaxIsch = MaxIsch - 2;
                //    //    isch = isch - 2;
                //    //}
                //}
                //else
                //{
                    RowFilter = RowFilter + " and " + sel1;
                    //' ref()
                //    us = 0;
                //}
                SetDv(RowFilter);

                //if (MaxIsch > isch) { TForward.Enabled = true; } else { TForward.Enabled = false; }
                //if (isch >= 1) TBack.Enabled = true;
                if (dv.Count == 0)
                {
                    MessageBox.Show("Нет записей, удовлетворяющих выбранному условию!");
                }
                //if (dvSub != null)
                //{ dvSub.RowFilter = dv.RowFilter; }
                //refr();
               // sel1 = "";
                //head = head1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);

                //throw;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            remFilter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow selRow in Dgv1.Rows)
                {
                    if (Convert.ToBoolean(selRow.Cells["Vib"].Value))
                    {
                        my.ExeScalar("update Sprav.dbo.tsmeti set idReason = " + idReason.SelectedValue.ToString() + ",  update_date ='" + DateTime.Now + "'" + ", update_user ='" + my.Login + "' where IdSm = " + selRow.Cells["IdSm"].Value);
                        selRow.Cells["Vib"].Value = 0;
                        selRow.Cells["Reason"].Value = idReason.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
            Cursor.Current = Cursors.Default;
            //Dgv1.Refresh();
            //SetDv(RowFilter);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow selRow in Dgv1.Rows)
                {
                    if (Convert.ToBoolean(selRow.Cells["Vib"].Value))
                    {
                        my.ExeScalar("update Sprav.dbo.tsmeti set idStatusZak = " + idStatus.SelectedValue.ToString() + ",  update_date ='" + DateTime.Now + "'" + ", update_user ='" + my.Login + "' where IdSm = " + selRow.Cells["IdSm"].Value);
                        selRow.Cells["Vib"].Value = 0;
                        selRow.Cells["StatusZak"].Value = idStatus.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //e.ColumnIndex
            if (Dgv1.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor == Color.Blue) { Dgv1.BeginEdit(true); }
        }

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns[e.ColumnIndex].Name != "Vib")
            {
                string strzap = "update Sprav.dbo.tsmeti set " + Dgv1.Columns[e.ColumnIndex].Name + " = '" + Dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' where IdSm = " + Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value.ToString();
                my.ExeScalar(strzap);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            my.Szap = "";
            my.Nbut = 717;
            //my.Nbut = 8;
            bool withup = true;
            my.Pform = this;
            //if (my.Nbut == 704) { if (my.UserInGroup(my.Id_us,234)) ; }
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, withup, true);
            }
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns.Contains("IdSm"))
            {
                if (MessageBox.Show("Перейти в выбранную смету?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    my.Szap = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (!my.isFormInMdi("frmCapSm", (int)Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value, my.MDIForm))
                    {
                        frmCapSm fr = new frmCapSm();
                        fr.MdiParent = my.MDIForm;
                        fr.idsm = (int)Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value;
                        fr.Tag = Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value;
                        fr.Show();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            my.Nbut = 191;
            if (!my.isFormInMdi("frmVibPred", my.Nbut, this))
            {
                frmVibPred fr = new frmVibPred();
                fr.Tag = my.Nbut;
                fr.MdiParent = my.MDIForm;
                fr.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selRow in Dgv1.Rows)
            {
                selRow.Cells["Vib"].Value = checkBox1.Checked;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
             Cursor.Current = Cursors.WaitCursor;
            try
            {


                foreach (DataGridViewRow selRow in Dgv1.Rows)
                {
                    if (Convert.ToBoolean(selRow.Cells["Vib"].Value))
                    {
                        my.ExeScalar("update Sprav.dbo.tsmeti set idBlock = " + IdBlock.SelectedValue.ToString() + ",  update_date ='" + DateTime.Now + "'" + ", update_user ='" + my.Login + "' where IdSm = " + selRow.Cells["IdSm"].Value);
                        selRow.Cells["Vib"].Value = 0;
                        selRow.Cells["block"].Value = IdBlock.Text;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
                if(my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
            Cursor.Current = Cursors.Default;
        }

       
    }
}
