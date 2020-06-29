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
    public partial class frmSprDGV : Form
    {
        public int nbut1; public String szap1; public DataSet ds; String head; String width1;
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        SqlDataAdapter[] da = new SqlDataAdapter[3]; Form pform1; DataView dv;
        public bool Withup = true; public Form Pform;
        public frmSprDGV()
        {
            InitializeComponent();
        }
        public void spisok(string szap)
        {
            try
            {
                String sel;
                if (szap == "") szap = szap1;

                Cursor = Cursors.WaitCursor;
                ds = new DataSet();
                if (nbut1 == 3000)
                {
                    sel = szap;
                }
                else
                { sel = my.FilterSel(nbut1, this, my.sconn, szap); }


                da[0] = new SqlDataAdapter();
                DaDs dads1 = new DaDs();
                dads1.DaInd(0, "set language 'русский' " + sel, my.sconn, "", ds, Withup);
                if (Withup) da[0] = dads1.Da[0];
                dv = new DataView();
                dv.Table = ds.Tables[0];
                //Dgv1.DataSource = null;
               Dgv1.DataSource = dv;
                if(nbut1 == 704)
                {   Dgv1.VLadd("idgp", "Генподрядчик", "SELECT    IdEntpr, shNMEntpr FROM         sprav.dbo.tsEntpr ORDER BY shNMEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 6);
                    Dgv1.VLadd("idinvzak", "Фактический заказчик","SELECT     idInvZak, NMInvZak FROM         Sprav.dbo.tsInvZak" , my.sconn, SMRC.DGVt.TypeVL.ComboBox, 7);
                    Dgv1.VLadd("idotv", "Ответственный", "SELECT    IdEntpr, shNMEntpr FROM         sprav.dbo.tsEntpr  ORDER BY shNMEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 8);
                }
                if (nbut1 == 8)
                { if (Dgv1.Columns.Count == dv.Table.Columns.Count) { CreateButton(); my.naimDG(my.headStr, Dgv1, my.widthStr); } }
                else
                if (my.widthStr != null)
                { my.naimDG(my.headStr, Dgv1, my.widthStr); }
                head = my.headStr;
                width1 = my.widthStr;
                Cursor = Cursors.Default;
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        void CreateButton()
        {               //button
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Акты";
            col.Name = "Акты ";

            //if (Dgv1.Columns.Count == dv.Table.Columns.Count)
            Dgv1.Columns.Add(col);

            Dgv1.Columns["Акты "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv1.Columns["Акты"].Visible = false;
            Dgv1.Columns["Акты "].DisplayIndex = 4;

            //Dgv1.Columns["Акты "].HeaderCell.Style =

            //DataGridViewButtonCell colBut= new DataGridViewButtonCell() ;
            //Dgv1.Columns[3].CellTemplate = (DataGridViewCell)colBut;
        }

        public void zap()
        {
            try
            {
                if (nbut1 == 111)
                {
                    for (Int32 i = 0; i <= Dgv1.Rows.Count - 1; i++)
                    {
                        if (Dgv1.Rows[i].Cells["identpr"].Value.ToString() == my.identpr.ToString()) { Dgv1.CurrentCell = Dgv1.Rows[i].Cells[1]; Dgv1.Rows[i].Selected = true; break; }
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void frmSprDGV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Withup) { if (ds.HasChanges()) { my.Up(da[0], ds.Tables[0]); };  }
            if (nbut1 == 716 | nbut1 == 717) { ((frmReasons)pform1).RefR(); }
        }

        private void frmSprDGV_Load(object sender, EventArgs e)
        {
            try
            {
                nbut1 = my.Nbut;
                szap1 = my.Szap;
                Tag = nbut1;
                spisok(szap1);
                pform1 = my.Pform;
                my.Pform = this;
                Double w = 0;
                for (int i = 0; i <= Dgv1.Columns.Count - 1; i++)
                { w = w + Dgv1.Columns[i].Width; }
                Width = (int)w + 55;
                // Dgv1.VirtualMode = true;
                if (!Withup) { tsbDel.Visible = false; tsbAdd.Visible = false; Dgv1.AllowUserToAddRows = false; Dgv1.AllowUserToDeleteRows = false; Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically; }
                if (my.Nbut == 8) { tsbAdd.Visible = true; tsbDel.Visible = true; }
                //if (nbut1 == 67) { Dgv1.Columns[2].}
                zap();
                //if (nbut1 != 124 && nbut1 != 8) Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
                ////throw;
            }
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (nbut1)
            {
                case 139:
                    try
                    {

                 
                    string idsm = Dgv1.Rows[e.RowIndex].Cells["idsm"].Value.ToString();
                    //my.Szap = Dgv1.Rows[e.RowIndex].Cells["idsm"].Value.ToString() ;
                   my.ExeScalar("exec RemSm " + idsm  + "," + my.Ustr);
                    foreach (Form fr2 in my.MDIForm.MdiChildren)
                    {
                        if (fr2.Name == "frmAct")
                        {
                            if (((frmAct)fr2).idSm.ToString() == my.Ustr)
                            {
                                fr2.Close();
                            }
                        }
                    }
                    Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                    
                case 712:
                    try
                    {
                        my.Szap = " and LSStrNumb = " + Dgv1.Rows[e.RowIndex].Cells["LSStrNumb"].Value + " and ProjID = " + Dgv1.Rows[e.RowIndex].Cells["ProjID"].Value + " and LSTitleID = " + Dgv1.Rows[e.RowIndex].Cells["LSTitleID"].Value;
                        my.Nbut = 714;
                        if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
                        {
                            my.showSprDGV(my.Nbut, false, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case 707:
                    ((frmCapSm)pform1).IdSmPr = (int)Dgv1.Rows[e.RowIndex].Cells["idSm"].Value;
                    ((frmCapSm)pform1).NMUtvSm.Text = my.ExeScalar("select  LTRIM(NDoc) + ' (' + Nomer + ')'  as NM from sprav.dbo.tsmeti where idsm = " + Dgv1.Rows[e.RowIndex].Cells["idSm"].Value.ToString());
                    Close();
                    break;
                case 209:
                    string res1 = "";
                    if ((int)Dgv1.Rows[e.RowIndex].Cells["busOpId"].Value != 29)
                    {
                        MessageBox.Show("Операция невозможна на данном бизнес-этапе!");
                        return;
                    }
                    if (Dgv1.Rows[e.RowIndex].Cells["Op"].Value.ToString() == "Нет данных")
                    {
                        MessageBox.Show("Невозможно загрузить пустой акт!");
                        return;
                    }
                    for (int i = 1; i <= 10; i++)
                    {
                        my.cn.Open();
                        my.sc.CommandText = "exec smr.dbo.sA0InsAct " + Dgv1.Rows[e.RowIndex].Cells["ProjID"].Value + "," + Dgv1.Rows[e.RowIndex].Cells["LSTitleID"].Value + "," + my.Id_us;
                        res1 = (string)my.sc.ExecuteScalar();
                        //my.cn.Close();

                        if (res1 == "Готово!")
                        {
                            i = 10;
                        }
                        else
                        {
                            i = i + 1;
                        }
                    }
                    if (!(Microsoft.VisualBasic.Information.IsNumeric(res1)))
                    {

                        MessageBox.Show(res1);
                    }
                    if (!(Microsoft.VisualBasic.Information.IsNumeric(res1)) & res1 != "Готово!")
                    {
                        my.cn.Close();
                        return;
                    }
                    my.sc.CommandText = "SELECT     dbo.Forma2.IdF2 FROM         dbo.Forma2 INNER JOIN                       Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm WHERE     (dbo.Forma2.A0LsTitleId = " + Dgv1.Rows[e.RowIndex].Cells["LSTitleID"].Value + ") AND (Sprav.dbo.tSmeti.A0ProjId = " + Dgv1.Rows[e.RowIndex].Cells["ProjID"].Value + ")";
                    if (my.sc.ExecuteScalar() == DBNull.Value || my.sc.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Акт не может быть открыт в Учете СМР!");
                    }
                    else
                    {

                        int idf2 = Convert.ToInt32(my.sc.ExecuteScalar());
                        if (!my.isFormInMdi("frmAct", idf2, my.MDIForm))
                        {
                            frmAct fr1 = new frmAct();
                            fr1.idf2 = idf2;
                            my.cn.Close();
                            fr1.Tag = idf2;
                            fr1.MdiParent = my.MDIForm;
                            fr1.Show();
                        }
                    }
                    Cursor = Cursors.Default;
                    break;
                case 18:
                    if (my.Id_UsName == "") { MessageBox.Show("У Вас нет прав для выполнения этой операции!"); return; }
                    if (MessageBox.Show("Добавить выбранную смету в план?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        my.Szap = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        my.cn.Open();
                        my.sc.CommandText = " exec InsPlanSmA0 " + Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString() + ",'" + my.Uper + "','" + my.Id_UsName + "'";
                        MessageBox.Show((string)my.sc.ExecuteScalar());
                        my.cn.Close();
                    }
    ((frmPlanSmA0)Pform).spisok();
                    Close();
                    break;
                case 26:
                        if (my.Id_UsName == "") { MessageBox.Show("У Вас нет прав для выполнения этой операции!"); return; }
                        if (MessageBox.Show("Добавить выбранное предприятие в планируемые предприятия?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            my.Szap = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
                            my.cn.Open();
                            //my.sc.CommandText = " insert into tStrucPredpr (idpredpr) values (" + Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString() + ")";
                            //my.sc.ExecuteScalar();
                            my.sc.CommandText = " exec InsStruc " + Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString() + "," + DateTime.Today.Year.ToString();
                            my.sc.ExecuteScalar();
                            my.cn.Close();
                        }
    ((frmStrucProg)Pform).spisok();
                        Close();
                    break;
                default:
                    break;
            }


            if (Dgv1.Columns.Contains("Idf2"))
            {
                if (MessageBox.Show("Перейти в выбранный акт?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int idf2 = Convert.ToInt32(Dgv1.Rows[e.RowIndex].Cells["Idf2"].Value);
                    if (!my.isFormInMdi("frmAct", idf2, my.MDIForm))
                    {
                        frmAct fr1 = new frmAct();
                        fr1.idf2 = idf2;
                        fr1.Tag = idf2;
                        fr1.MdiParent = my.MDIForm;
                        fr1.Show();
                    }
                }
            }

                if (nbut1 == 111 || nbut1 == 129 || nbut1 == 130 || nbut1 == 58 || nbut1 == 124)
            {
                my.Szap = Dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();

                Close();
            }
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

        private void Dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Withup) return;
            if (ds.HasChanges())
            {
                my.Up(da[0], ds.Tables[0]);
            }
        }

        private void tsExcel_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = tstText.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(Dgv1, m_searchInfo);
            Dgv1.CurrentRow.Selected = true;
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AutoH_Click(object sender, EventArgs e)
        {
            Dgv1.DefaultCellStyle.WrapMode = (DataGridViewTriState)((int)Dgv1.DefaultCellStyle.WrapMode == 1 ? 2 : 1);
            //Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GC.Collect();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (nbut1 == 8)
            {

                my.sc.CommandText = "exec sNewSmeta 10,0,1," + my.Id_us.ToString() + ",1 ";
                my.cn.Open();

                my.Szap = my.sc.ExecuteScalar().ToString();
                my.cn.Close();
                int idsm = Convert.ToInt32(my.Szap);
                if (!my.isFormInMdi("frmCapSm", idsm, my.MDIForm))
                {
                    frmCapSm fr = new frmCapSm();
                    fr.MdiParent = my.MDIForm;
                    fr.idsm = idsm;
                    fr.Tag = my.Szap;
                    fr.Show();

                }
            }
            //if (nbut1 == 704)
            //{
            //    DataRow dr = ds.Tables[0].Rows.Add();
            //    //my.sc.CommandText = "exec sNewSmeta 10,0,1," + my.Id_us.ToString() + ",1 ";
            //    //my.cn.Open();

            //    //my.Szap = my.sc.ExecuteScalar().ToString();
            //    //my.cn.Close();
            //    //int idsm = Convert.ToInt32(my.Szap);
            //    //if (!my.isFormInMdi("frmCapSm", idsm, my.MDIForm))
            //    //{
            //    //    frmCapSm fr = new frmCapSm();
            //    //    fr.MdiParent = my.MDIForm;
            //    //    fr.idsm = idsm;
            //    //    fr.Tag = my.Szap;
            //    //    fr.Show();

            //    //}
            //}
            //else
            {
                DataRow dr = ds.Tables[0].Rows.Add();
                dr[1] = ' ';
                Dgv1.CurrentCell = Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[1];
                Dgv1.BeginEdit(true);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (Dgv1.SelectedRows.Count == 0) Dgv1.CurrentRow.Selected = true;
            if (MessageBox.Show("Удалить выделенные строки?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //my.Up(da[0], ds.Tables[0]);
            try
            {

                foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
                {
                    if (nbut1 == 8)
                    {
                        my.sc.CommandText = " exec dbo.DelSm " + selrow.Cells["idsm"].Value.ToString() + ",'" + my.Login + "'";
                        my.cn.Open();
                        if (my.sc.ExecuteScalar().ToString() != "OK")

                        { MessageBox.Show("Смету удалить невозможно!"); return; }
                        my.cn.Close();
                    }
                    Dgv1.Rows.Remove(selrow);
                }
                //MessageBox.Show(da[0].DeleteCommand.ToString() );

                if (Withup) { my.Up(da[0], ds.Tables[0]); }
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if ((int)my.cn.State == 1) { my.cn.Close(); }
            }
        }

        private void Dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!Withup) { return; }
            if (Dgv1.EditMode != DataGridViewEditMode.EditProgrammatically) { Dgv1.BeginEdit(true); }
        }



        private void Dgv1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tsFilter.Tag = Dgv1.Columns[e.ColumnIndex].Name;//Dgv1.CurrentCell.ColumnIndex;
                //MessageBox.Show(Dgv1.Columns[e.ColumnIndex].Name);
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void Dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            tsbDel_Click(null, null);
            e.Cancel = true;
        }

        private void tsFilter_Click(object sender, EventArgs e)
        {
            try
            {
                String s2 = "";
                if (tstText.Text == "") { dv.RowFilter = ""; tslCount.Text = "Всего " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString(); return; }

                if (!Dgv1.Columns[tsFilter.Tag.ToString()].ValueType.IsValueType)
                {
                    s2 = "[" + dv.Table.Columns[tsFilter.Tag.ToString()].ColumnName +"]" + " like '%" + tstText.Text + "%'";
                }
                else
                { s2 = "[" + dv.Table.Columns[tsFilter.Tag.ToString()].ColumnName + "]" + " = " + tstText.Text; }

                dv.RowFilter = s2;
                tslCount.Text = "Всего " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Необходимо поставить курсор на ячейку, к которой надо применить фильтр!");

                //throw;
            }
        }

        private void tstText_DoubleClick(object sender, EventArgs e)
        {
            tstText.Text = "";
            tsFilter_Click(null, null);

        }

        private void Dgv1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (ds.HasChanges())
            {
                my.Up(da[0], ds.Tables[0]);
            }
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            tsFilter.Tag = Dgv1.Columns[e.ColumnIndex].Name;
            lbl1.Text = "фильтр по колонке " + Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].HeaderText;

            if (Dgv1.Columns[e.ColumnIndex].Name == "Акты ")
            {
                int col = Dgv1.CurrentCell.ColumnIndex;
                int row = Dgv1.CurrentCell.RowIndex;
                int idsm = (int)Dgv1.Rows[e.RowIndex].Cells["IdSm"].Value;
                if (!my.isFormInMdi("frmActsFromSmeti", idsm, my.MDIForm))
                {
                    frmActsFromSmeti fr = new frmActsFromSmeti();
                    fr.MdiParent = my.MDIForm;
                    fr.Dock = DockStyle.Fill;
                    fr.idsm = idsm;
                    fr.Tag = my.Szap;
                    fr.Show();

                }
                //MessageBox.Show("Button in Cell[" +
                //    col.ToString() + "," +
                //    row.ToString() + "] has been clicked");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            spisok(szap1);
        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}