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
    public partial class frmSprZapros : Form
    {
        public int nbut1;  public string szap1;
        String head; String width1; public DataSet ds; DataView dv;
        public frmSprZapros()
        {
            InitializeComponent();
        }


        private void frmSprZapros_Load(object sender, EventArgs e)
        {
            nbut1 = my.Nbut;
            szap1 = my.Szap;
            Tag = nbut1;
            spisok(szap1);
            my.Pform = this;
            Dgv1.AllowUserToAddRows = false; Dgv1.AllowUserToDeleteRows = false; Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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

                SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
                da.Fill(ds);
                dv = new DataView();
                dv.Table = ds.Tables[0];
                Dgv1.DataSource = dv;
                    my.naimDG(my.headStr, Dgv1, my.widthStr);

                head = my.headStr;
                width1 = my.widthStr;
                Cursor = Cursors.Default;
                tslCount.Text = "Всего: " + ((int)Dgv1.Rows.Count - (Dgv1.AllowUserToAddRows ? 1 : 0)).ToString();

                ucFilter1.UCFilt(dv, Dgv1, UCFilter.UCFilter.VidObj.DataGridView, my.headStr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AutoH_Click(object sender, EventArgs e)
        {
            Dgv1.DefaultCellStyle.WrapMode = (DataGridViewTriState)((int)Dgv1.DefaultCellStyle.WrapMode == 1 ? 2 : 1);
            GC.Collect();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            my.v_excel(Dgv1);
        }
    }
}
