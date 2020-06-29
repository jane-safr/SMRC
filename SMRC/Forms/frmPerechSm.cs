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
    public partial class frmPerechSm : Form
    {

        public string sel1;
        public string sel;
        private string headstr1;
        private frmCapSm fr;
        private frmSprDGV frVip;
        DataView dv;
        bool notChange = false;
        public frmPerechSm()
        {
            InitializeComponent();
        }

        private void frmPerechSm_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            //this.Visible = false;
           // Console.WriteLine();
           //Console.Write("begin" + DateTime.Now.ToString());
            Cursor.Current = Cursors.WaitCursor;
            //this.WindowState = FormWindowState.Maximized;
            string s = my.Szap;
            Console.WriteLine();
            Console.Write("beginfrmCapSm" + DateTime.Now.ToString());
            fr = new frmCapSm();
            Console.Write("endfrmCapSm" + DateTime.Now.ToString());
            fr.TopLevel = false;
            fr.FormBorderStyle = FormBorderStyle.None;
            ((ToolStrip)fr.Controls["ToolStrip1"]).Items["TEx"].Visible = false;

            my.Szap = " and 1 = 2";
            my.Nbut = 67;
            frVip = new frmSprDGV();
            frVip.Withup = false;
            frVip.TopLevel = false;
            frVip.FormBorderStyle = FormBorderStyle.None;
            frVip.Dock = DockStyle.Fill;
            fr.Visible = true;
            frVip.Visible = true;
            tabPage1.Controls.Add(fr);
            tabPage2.Controls.Add(frVip);
            
            //nbut1 = 69;
            //Console.WriteLine();
            //Console.Write("beginspisok" + DateTime.Now.ToString());
            spisok(s);
            //Console.WriteLine();
            //Console.Write("endspisok" + DateTime.Now.ToString());
            
            Cursor.Current = Cursors.Default;
            //Console.WriteLine();
            //Console.Write("end" + DateTime.Now.ToString());
            tabControl1.Visible = true;
            //this.PerformLayout();
            //Visible = true;
             WindowState = FormWindowState.Maximized;
        
        }

        private void frmPerechSm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        public void spisok(string s)
        {
            try
            {
                //sel = my.FilterSel(nbut1, this, my.sconn, "");
                 string    sel1 = "exec  sPerechEnt " + s;
                DataSet DS = new DataSet();
                dv = new DataView();
                //Console.WriteLine();
                //Console.Write("begindataset" + DateTime.Now.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(sel1, my.sconn);
                sda.Fill(DS);
                //Console.WriteLine();
                //Console.Write("enddataset" + DateTime.Now.ToString());
                headstr1 = "Лок № сметы,Инв № сметы,Наименование сметы,Проект,Заказчик,Генподрядчик,Объект,Код объекта,Инвестиционн. проект,Глава ССР,Код ОСР,ОСР,Пункт ССР,Титул,Договор,ИстФин,Тип работ,Разработчик,ГруппаСмет,Исполнитель,В архиве,Рассылка,Рассылка по уч.,Участок,Работы завершены,Входят в ССР,ОСР текст,Вып91,ВыпТек,В учете,Подрядчик,Пусковый комплекс,Номер ГЦО,Бизнес-этап А0,Есть в А0,Статус сметы,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                my.headStr = headstr1;
                dv.Table = DS.Tables[0];
                ucFilter1.UCFilt(dv, Dgv1, UCFilter.UCFilter.VidObj.DataGridView, my.headStr);
                //Console.WriteLine();
                //Console.Write("enducFilter" + DateTime.Now.ToString());
                Dgv1.DataSource = dv;
                
                return;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private void Dgv1_SelectionChanged(object sender, EventArgs e)
        {
            if (notChange) return;
            if (Dgv1.CurrentRow == null) return;
            Cursor.Current = Cursors.WaitCursor;
            fr.idsm = (int)Dgv1.CurrentRow.Cells["IdSm"].Value;
            fr.spisok();
            string s = " and forma2.idsm = " + Dgv1.CurrentRow.Cells["IdSm"].Value.ToString();
            frVip.spisok(s);
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Dgv1.SelectedRows.Count > 1)
                {
	                if (MessageBox.Show("Вы действительно хотите изменить ОСРтекст у " + Dgv1.SelectedRows.Count + " смет?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.No)
	                {
		                return;
	                }
                    TabPage tp = (TabPage)((TabControl)fr.Controls["tabControl1"]).Controls["tabPage3"];
	                foreach (DataGridViewRow  r in Dgv1.SelectedRows)
	                {
                        my.sc.CommandText = "update sprav.dbo.tsmeti set osrtxt = '" + tp.Controls["OSRtxt"].Text + "',  isSSR = " + (((System.Windows.Forms.RadioButton)tp.Controls["groupBox1"].Controls["radioButton1"]).Checked ? 1 : (((System.Windows.Forms.RadioButton)tp.Controls["groupBox1"].Controls["radioButton2"]).Checked ? 2 : 0)).ToString() + " where IdSm = " + r.Cells["IdSm"].Value.ToString();
                        my.cn.Open();
                        my.sc.ExecuteScalar();
                        my.cn.Close();
	                }
                }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            notChange = true;
            frmReps fr = new frmReps();
            my.Pform = this;
            fr.MdiParent = my.MDIForm;
            my.Szap = "";
            my.headStr = headstr1;
            my.Nbut = 67;
            //DataTable dt = dv.ToTable();

            //dv.Table = dt;
            //DataView dv1 = new DataView();
            //dv1.Table = dt;
            fr.dv = dv;
            fr.Show();
            notChange = false;
            //ModOffice.StendKompl(dv);
        }
    }
}
