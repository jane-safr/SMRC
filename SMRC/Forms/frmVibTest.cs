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
    public partial class frmVibTest : Form
    {
        DataSet ds; DataView dv;
        public frmVibTest()
        {
            InitializeComponent();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             string sel = my.FilterSel(713, this, my.sconn, " and dbo.vLastDogovor.RegNomer LIKE '%" + Text1.Text + "%'"); 

            SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
            ds = new DataSet();
            da.Fill(ds);
            dv = new DataView();
            dv.Table = ds.Tables[0];
            Dgv1.DataSource = dv;
            my.naimDG(my.headStr, Dgv1, my.widthStr);

            //head = my.headStr;
            //width1 = my.widthStr;
            Cursor = Cursors.Default;
            tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
