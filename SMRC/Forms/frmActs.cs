using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmActs : Form
    {
        String sel;
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        string headStr = ""; string widthStr = ""; 
        public frmActs()
        {
            InitializeComponent();
        }

        private void frmActs_Load(object sender, EventArgs e)
        {
            Console.Write("start " + DateTime.Now.TimeOfDay.ToString());
            sel = my.FilterSel(7, null, my.sconn, "");
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            widthStr = my.widthStr;
            headStr = my.headStr;
            spisok();
            Console.Write("finish " + DateTime.Now.TimeOfDay.ToString());
        }
        public void spisok()
        {
            Console.Write("start spisok" +DateTime.Now.TimeOfDay.ToString());
            New.Enabled = my.KontrolA0();
            Move.Enabled = my.KontrolA0();
            Copy.Enabled = my.KontrolA0();
            RemPeriod.Enabled = my.KontrolA0();
            string str = "";
            bool All = flAll.Checked;
            bool never = flNev.Checked;
            bool NotPodp = flNotPodp.Checked;
            bool NotReal = flNotReal.Checked;
            if (All && !never && !NotPodp)
            { //обычный список по предприятию
                str = sel + " where " + my.MyStr[0];
            }
            else
                if (!All && !never && !NotPodp)
                { //обычный список по пользователю
                    str = sel + " where " + my.MyStr[1];
                }
                else
                    if (All && never)
                    {
                        str = sel + " where   Zatr <> dbo. SumZatr(idF2,0) and " + my.MyStr[0];
                    }
                    else
                        if (!All && never)
                        {
                            str = sel + " where  Zatr <> dbo. SumZatr(idF2,0) and " + my.MyStr[1];
                        }
                        else
                            if (All && NotPodp)
                            {
                                str = sel + " where " + my.MyStr[0] + " and PodpZak<>1";
                            }
                            else if (!All && NotPodp)
                            {

                                str = sel + " where " + my.MyStr[1] + " and PodpZak<>1";
                            }

            if(NotReal)
            {
                if(str.Contains("where"))
                {
                    str = str + " and [Снятие под реализацию] <>1 ";
                }
                else
                {
                    str = str + " where  [Снятие под реализацию] <>1 ";
                }
            }



          
            //bool ref1 = true;
            //if (Dgv1.DataSource != null) { ref1 = false; }



            DataSet ds = my.GetDS(str, my.sconn);
           BindingSource biSour = new BindingSource();
           biSour.DataSource = ds.Tables[0]; 
            Dgv1.DataSource = biSour;

            my.naimDG(headStr, Dgv1, widthStr);
            // my.GetData(str, biSour);
            //Dgv1.DataSource = ds.Tables[0];
            //if (ref1) { my.naimDG(my.headStr, Dgv1, my.widthStr); }
            my.Pform = this;
            my.sc.CommandText = "SELECT     id_gr FROM         SluPolzPred WHERE     (Id_us = " + my.Id_us + ") and  (identpr = " + my.identpr + ")";
            my.cn.Open();
            foreach (DataGridViewColumn col in Dgv1.Columns)
            {
                if (col.ValueType.IsValueType) { col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight; }
            }

            if (my.sc.ExecuteScalar() != null & my.sc.ExecuteScalar() != DBNull.Value) { if ((int)my.sc.ExecuteScalar() == 0) { GroupBox1.Enabled = false; } else { GroupBox1.Enabled = true; } }
            my.cn.Close();
            Console.Write("finish spisok" + DateTime.Now.TimeOfDay.ToString());

        }

        private void flAll_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
            spisok();
            Console.WriteLine("2   " + DateTime.Now.TimeOfDay.ToString());
        }

        private void flNev_CheckedChanged(object sender, EventArgs e)
        {
            if (flNev.Checked) { flNotPodp.Checked = false; }
        spisok();
        }

        private void flNotPodp_CheckedChanged(object sender, EventArgs e)
        {
            if (flNotPodp.Checked) { flNev.Checked = false; }
        spisok();
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        m_searchInfo.searchString = TextBox1.Text ;
        m_searchInfo.searchDirection = SearchDirectionEnum.All ;
        m_searchInfo.searchContent = 0 ;
        m_searchInfo.matchCase = false;
        m_searchInfo.lookIn = null ;
        my.search(Dgv1, m_searchInfo);
        Dgv1.CurrentRow.Selected = true;
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {if (Dgv1.Rows.Count == 0) return;
        if (Dgv1.SelectedRows.Count == 0) Dgv1.CurrentRow.Selected = true;

        if (MessageBox.Show("Удалить выделенные документы?","Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes) 
        {
            Int32 MinNomStr = 777;
            foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
            {     MinNomStr = selrow.Index;
                if (my.InF3((int)selrow.Cells[0].Value)) {
                    MessageBox.Show("Удалить акт " + selrow.Cells["KodUnic"].Value.ToString() + " нельзя, поскольку он взят в справку формы №3");
                    return;}
                else if (my.ExeScalar("select idF2 from SootvF2Parent where idF2 =" + selrow.Cells["IdF2"].Value) != "")
                {
                        MessageBox.Show("К акту " + selrow.Cells["KodUnic"].Value.ToString() + " добавлены дочерние акты. Удалите сначала их!"); return;
                    }
                //    else if (my.FromSmP((int)selrow.Cells[0].Value))
                //{
                //    if (MessageBox.Show("Акт " + selrow.Cells["KodUnic"].Value.ToString() + " составлен в С.Д.М. Все равно Удалить?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //}

                    //my.sc.CommandText = " update sm_prog.dbo.Акты set КодВsdo = '' where КодВsdo = '" + Dgv1.CurrentRow.Cells["KodUnic"].Value.ToString() + "'";

                    my.ExeScalar("update Forma2 set  update_date ='" + DateTime.Now + "'" + ", update_user ='" + my.Login + "' WHERE IdF2=" + selrow.Cells[0].Value.ToString() + "; DELETE FROM Forma2 WHERE IdF2=" + selrow.Cells[0].Value.ToString());

                //    my.cn.Open();
                //my.sc.ExecuteScalar();
                //my.sc.CommandText = "DELETE FROM Forma2 WHERE IdF2=" + selrow.Cells[0].Value.ToString();
                //my.sc.ExecuteScalar();
                //my.cn.Close();
            }
            spisok();
            if (MinNomStr > 1) Dgv1.CurrentCell = Dgv1.Rows[MinNomStr - 1].Cells[2];
        }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {if (Dgv1.SelectedRows.Count != 1) {
            MessageBox.Show("Выделите акт, который надо скопировать!", "Внимание!");
            return;
        }
        if (MessageBox.Show("Добавить новый акт, скопировав данные текущего ?","Внимание!", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        my.Nbut = 111;
        my.Szap = " and id_us = " + my.Id_us;
        frmSprDGV fr = new frmSprDGV();
        fr.Withup = false;
        fr.Tag = my.Nbut;
        fr.ShowDialog();
        if (!my.IsNumeric(my.Szap)) return;
        Int16 ValData   = 0;
        if (MessageBox.Show("Копировать числовые данные ?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes) ValData = 1;
        my.sc.CommandText = "exec F2_CopyAkt " + Dgv1.CurrentRow.Cells[0].Value.ToString() + "," + my.Id_us + "," + ValData + ",'000'," + my.Szap;
        my.cn.Open();
        my.sc.ExecuteScalar();
        my.cn.Close();
        spisok();
        MessageBox.Show("Готово!");
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            if (Dgv1.RowCount == 0) return;
            if (Dgv1.SelectedRows.Count == 0)
            { Dgv1.CurrentRow.Selected = true; }
            int nbut = 6;
            if (sender.ToString() == "Перенос на другой месяц") nbut = 13;
            if (!my.isFormInMdi("frmVibRabPeriod", nbut, this))
            {
                frmVibRabPeriod fr = new frmVibRabPeriod();
                fr.Tag = nbut;
                fr.DGVKol = Dgv1.SelectedRows;
                my.Nbut = (int)fr.Tag;
                my.Pform = this;
                //fr.MdiParent = my.MDIForm;
                fr.ShowDialog();
            }
            MessageBox.Show("Готово!");


        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
                   //'признак Подписан
        Int64 idf2 = 0;
        if (Dgv1.Rows.Count > 0) {
            if (Dgv1.SelectedRows.Count == 0) Dgv1.CurrentRow.Selected = true;
            foreach (DataGridViewRow selRow in Dgv1.SelectedRows)
            {
                if (my.InF3((int)selRow.Cells[0].Value) ==false ) {
                    if ((bool)selRow.Cells[1].Value == false ) {
                        my.sc.CommandText = "UPDATE MoveF2 SET PodpZak=1, DatePodpZak=getdate() where idf2='" + selRow.Cells[0].Value.ToString() + "'";}
                    else
                    { my.sc.CommandText = "UPDATE MoveF2 SET PodpZak=0 where IdF2='" + selRow.Cells[0].Value.ToString() + "'";}
                   
                    my.cn.Open();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                }
                idf2 = (int)selRow.Cells[0].Value;
            }
            spisok();
 
            for (Int32 i = 0 ; i <=Dgv1.Rows.Count - 1;i++) {
                if ((int)Dgv1.Rows[i].Cells["idf2"].Value == idf2) { Dgv1.CurrentCell = Dgv1.Rows[i].Cells[1]; Dgv1.Rows[i].Selected = true; break; }
            }
        }
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            if (Dgv1.CurrentRow == null) return;
        my.Szap = " and idf2 = " + Dgv1.CurrentRow.Cells["Idf2"].Value.ToString();
        my.Nbut = 108;
        if (!my.isFormInMdi("frmSprDGV", (int)Dgv1.CurrentRow.Cells["Idf2"].Value, this))
        {
            my.showSprDGV((int)Dgv1.CurrentRow.Cells["Idf2"].Value, false, false);
        }
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            spisok();
        }

        private void ToolStripButton10_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ToolStripButton2_Click(null,null);
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
        if (Dgv1.SelectedRows.Count != 1) { MessageBox.Show("Выберите один документ","Внимание!");}
        else {
            if (! my.isFormInMdi("frmAct", (int)Dgv1.CurrentRow.Cells[0].Value, this)) {
                frmAct fr = new frmAct();
                fr.idf2 = (int)Dgv1.CurrentRow.Cells[0].Value;
                fr.Tag = (int)Dgv1.CurrentRow.Cells[0].Value;
                fr.MdiParent = my.MDIForm;
                my.Pform = this;
                fr.Show();
        }
        }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            my.sc.CommandText = "set dateformat dmy exec sF2NewAkt " + my.identpr.ToString() + ",'" + my.Uper.ToString() + "'," + my.Id_us.ToString();
            my.cn.Open();
            frmAct fr = new frmAct();
            fr.idf2 = Convert.ToInt32(my.sc.ExecuteScalar());
            my.cn.Close();
            spisok();
            fr.Tag = (int)fr.idf2;
            fr.MdiParent = my.MDIForm;
            my.Pform = this;
            fr.Show();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgv1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //switch (switch_on)
            //{
            //    default:
            //}
            if ((int)Dgv1["IdStatus", e.RowIndex].Value == 0)
            {
                Dgv1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            }
            else
            if ((int)Dgv1["InProg", e.RowIndex].Value == 1)
            {
                Dgv1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Brown;
            }
            else
            if ((int)Dgv1["InProg", e.RowIndex].Value == 2)
            {
                Dgv1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            }
            //else

            //Console.Write("RowPrePaint " + DateTime.Now.TimeOfDay.ToString() + "\n");
        }

        private void A0_Click(object sender, EventArgs e)
        {

            my.Szap = " and pred = '" + my.Upred + "' and year = " + my.Uper.Year + " and month = " + my.Uper.Month;
            my.Nbut = 209;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, false, false);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flNotReal_CheckedChanged(object sender, EventArgs e)
        {
            spisok();
        }
    }


        }    
