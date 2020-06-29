using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC.Forms
{
    public partial class frmScanSm : Form
    {
        public int nbut1; public String szap1; public DataSet ds; String head; String width1;
        //clsSearchInfo m_searchInfo = new clsSearchInfo();
        SqlDataAdapter[] da = new SqlDataAdapter[3]; Form pform1; DataView dv;
        public bool Withup = true; public Form Pform;
        public frmScanSm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomerSm.Text == "")
            {
                MessageBox.Show("Вы не ввели номер сметы!");
                return;
            }
            spisok(" and  NomerPar like '%" + NomerSm.Text + "%'");
        }
        public void spisok(string szap)
        {
            try
            {
                String sel;
                if (szap == "") szap = szap1;

                Cursor = Cursors.WaitCursor;
                ds = new DataSet();
                //if (nbut1 == 3000)
                //{
                //    sel = szap;
                //}
                //else
                //{  }

                sel = my.FilterSel(700, this, my.sconn, szap);
                da[0]  = new SqlDataAdapter(sel, my.sconn);
                ds.Clear();
                Dgv1.DataSource = null;
                da[0].Fill(ds);
  
                dv = new DataView();
                dv.Table = ds.Tables[0];
                Dgv1.DataSource = dv;
                my.naimDG(my.headStr, Dgv1, my.widthStr);

                Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //GC.Collect();

                sel = my.FilterSel(701, this, my.sconn, szap);
                da[1] = new SqlDataAdapter(sel, my.sconn);
                DataSet ds1 = new DataSet();
                ds1.Clear();
                Dgv2.DataSource = null;
                da[1].Fill(ds1);

                DataView dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv2.DataSource = dv1;
                my.naimDG(my.headStr, Dgv2, my.widthStr);
                ostatok();
                Cursor = Cursors.Default;
                //tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void frmScanSm_Load(object sender, EventArgs e)
        {
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;

            Dgv2.AllowUserToAddRows = false;
            Dgv2.AllowUserToDeleteRows = false;
            Dgv2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Dgv1.DefaultCellStyle.WrapMode = (DataGridViewTriState)((int)Dgv1.DefaultCellStyle.WrapMode == 1 ? 2 : 1);
        //    GC.Collect();
        //}

        private void ostatok()
        {
            if (Dgv1.RowCount == 0) { ost.Text = "Остаток: "; return; }
            double summ = 0;string selsumm = "";double summ1 = 0;
            for (int i = 0; i < Dgv1.RowCount; i++)
            {
                summ = summ + Convert.ToDouble(Dgv1["Vip91Par", i].Value);
            }
            for (int i = 0; i < Dgv2.RowCount; i++)
            {
                summ1 = summ1 + Convert.ToDouble(Dgv2["Vip91", i].Value);
            }
            selsumm = Dgv1["Sum2001", 0].Value.ToString() + " - " + summ.ToString() + " - " + summ1.ToString() + " = " + (Convert.ToDouble(Dgv1["Sum2001", 0].Value) - summ - summ1).ToString();
            ost.Text = "Остаток: " + selsumm;
    
        }
    }
}
