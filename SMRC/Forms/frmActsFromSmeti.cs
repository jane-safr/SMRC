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
    public partial class frmActsFromSmeti : Form
    {
        public int idsm;
        public frmActsFromSmeti()
        {
            InitializeComponent();
        }

        private void frmActsFromSmeti_Load(object sender, EventArgs e)
        {
            spisok();
        }
        private void spisok()
        {
            string s = my.FilterSel(9, null, my.sconn, " and Sprav.dbo.tsmeti.idSm = " + idsm.ToString());
            DataSet ds3 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
            ds3.Clear();
            da.Fill(ds3);
            Dgv3.DataSource = ds3.Tables[0];
            Dgv3.AllowUserToAddRows = false;
            Dgv3.Columns[0].Visible = false;
            my.naimDG(my.headStr, Dgv3, my.widthStr);
            //Dgv3.Columns[1].Visible = false;

             s = my.FilterSel(10, null, my.sconn, " and idSm = " + idsm.ToString());
            DataSet ds = new DataSet();
             da= new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];
            Dgv1.AllowUserToAddRows = false;
            Dgv1.Columns[0].Visible = false;
            Dgv1.Columns[1].Visible = false;

            s = my.FilterSel(11, null, my.sconn, " and idSm = " + idsm.ToString());
            DataSet ds2 = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds2.Clear();
            da.Fill(ds2);
            Dgv2.DataSource = ds2.Tables[0];
            Dgv2.AllowUserToAddRows = false;
            Dgv2.Columns[0].Visible = false;
            Dgv2.Columns[1].Visible = false;
        }

        private void Dgv1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Dgv1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        }

        private void Dgv2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Dgv2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv2);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Szap = " and idsm = " + SSUltraGrid1.ActiveRow.Cells["Idsm"].Value;

            long ProjID = 0;
            long LsTitleId = 0;
            //idsm = SSUltraGrid1.ActiveRow.Cells["Idsm"].Value;
            ProjID = Convert.ToInt64(my.ExeScalar("select A0ProjId from sprav.dbo.tsmeti where idsm = " + idsm));
            LsTitleId = Convert.ToInt64(my.ExeScalar("select A0LsTitleId from sprav.dbo.tsmeti where idsm = " + idsm));

            my.Szap = " and ProjID = " + ProjID + " and LsTitleId  = " + LsTitleId;
            my.Nbut = 712;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, false, true);
            }

        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Перейти в выбранный акт?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                DGVt dv = (DGVt)sender;
                int idf2 = Convert.ToInt32(dv.Rows[e.RowIndex].Cells["Idf2"].Value);
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
    }
}
