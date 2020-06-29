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
    public partial class frmSm : Form
    {
        public string NomerSm = "";
        public frmSm()
        {
            InitializeComponent();
        }

        private void frmSm_Load(object sender, EventArgs e)
        {
            Sm.Text = NomerSm;
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            spisok();
        }

        private void spisok()
        {
            String sel;

            Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();


            sel = "SELECT    task_code FROM         Grafik.dbo.vTaskSm WHERE     (Sm = '" + NomerSm + "')";
            SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
            ds.Clear();
            Dgv1.DataSource = null;
            da.Fill(ds);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            Dgv1.DataSource = dv;
            my.naimDG("Работа", Dgv1, "400");
        }
    }
}
