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
    public partial class frmSogl : Form
    {
        clsSearchInfo m_searchInfo = new clsSearchInfo();
        int cntCol; int ColumnHeadersHeight;
        public frmSogl()
        {
            InitializeComponent();
        }

        private void frmSogl_Load(object sender, EventArgs e)
        {
            ColumnHeadersHeight = DgvSoglF3.ColumnHeadersHeight;
            my.FillDC(NomerKS3Sub, 81, " and Period = ''" + my.Uper + "'' and IdEntpr = " + my.identpr );
            DgvSoglF3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DgvSoglF3.ColumnHeadersHeight = ColumnHeadersHeight * 2;
            DgvSoglF3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            DgvSoglF3.CellPainting += new DataGridViewCellPaintingEventHandler(dgvPlannedProfile_CellPainting);

            DgvSoglF3.Paint += new PaintEventHandler(dgvPlannedProfile_Paint);
            // DgvSoglSumRazl.AllowUserToAddRows = false;

        }

       // string NomerKS3SubOld = "";
        private void NomerKS3Sub_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (NomerKS3Sub.SelectedValue == null || NomerKS3Sub.SelectedValue.ToString() == "System.Data.DataRowView") return;
            //if (NomerKS3Sub.SelectedValue.ToString()!="" )
            //{
            //    //NomerKS3SubOld = NomerKS3Sub.SelectedValue.ToString();
            //    my.FillDC(KodUnic, 82, " and Period = ''" + my.Uper + "'' and IdEntpr = " + my.identpr + " and NomerKS3Sub = ''" + NomerKS3Sub.SelectedValue + "''");
            //    my.FillDC(idDog, 16, " and iddog = ''" + my.ExeScalar(my.FilterSel(719, null, my.sconn, " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'")) + "''");
            //    my.FillDC(idIstFin, 18, " and idistfin = ''" + my.ExeScalar(my.FilterSel(720, null, my.sconn, " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'")) + "''");
            //    //  lDog.Text = my.ExeScalar(my.FilterSel(719,null, my.sconn, " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'"));
              
            //   // vSoglSumRazl();
                

            //}
        }



        private void vSoglSumRazl()
        {
            if (NomerKS3Sub.SelectedValue.ToString() != "")
            {
                my.MySpisok(231, " and Period = '" + my.Uper + "' and IdEntpr = " + my.identpr + " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'", null, DgvSoglSumRazl);

                my.MySpisok(233, " and Period = '" + my.Uper + "' and IdEntpr = " + my.identpr + " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'", null, DgvSoglF3);
                lCount.Text = "Всего: " + (int)DgvSoglF3.Rows.Count;


            }

            // throw new NotImplementedException();
        }

        private void KodUnic_SelectedValueChanged(object sender, EventArgs e)
        {
           //if (KodUnic.SelectedValue == null) return;
           // if (my.IsNumeric(KodUnic.SelectedValue.ToString()))
           // {
           //    my.MySpisok(232, " and Period = '" + my.Uper + "' and IdEntpr = " + my.identpr + " and idF3 = '" + KodUnic.SelectedValue + "'", null, DgvSoglSumRazlUchet);
           // }
        }



        private void DgvSoglF3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //}
            if ((double)DgvSoglF3["SumDelta", e.RowIndex].Value != 0)
            {
                DgvSoglF3.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (my.KontrolSMR(my.Uper, my.identpr, 2) == false)
            {
                return;
            }
            try
            {
                string strsql;
                if (DgvSoglF3.RowCount == 0 || KodUnic.SelectedValue == null )
                {
                    return;
                }

                strsql = my.ExeScalar(" exec sSogl   'Add', '" + NomerKS3Sub.SelectedValue + "','" + my.Upred + "','" + my.Uper + "'," + my.Id_us + "," + idDog.SelectedValue + "," + KodUnic.SelectedValue + "," + idIstFin.SelectedValue);

                MessageBox.Show(strsql);
                NomerKS3Sub_SelectedValueChanged(null, null);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (my.KontrolSMR(my.Uper, my.identpr, 2) == false)
            {
                return;
            }
            try
            {
                string strsql ;
                if (DgvSoglF3.RowCount == 0 || idDog.SelectedValue == null || idDog.SelectedValue.ToString() == "0")
                {
                    return;
                }

                strsql = my.ExeScalar(" exec sSogl   'Create', '" + NomerKS3Sub.SelectedValue +"','" + my.Upred+  "','" +my.Uper + "',"+ my.Id_us+ "," + idDog.SelectedValue +",0," + idIstFin.SelectedValue );
                my.ExeScalar("delete from tusf2 where id_us = " + my.Id_us + " and idgen =  smr.dbo.idpred('001')");

                MessageBox.Show(strsql);
                NomerKS3Sub_SelectedValueChanged(null, null);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
            }
        }

     
        void dgvPlannedProfile_Paint(object sender, PaintEventArgs e)
        {

             string[] quarter = { "", "Согласованные акты", "Акты из Учета СМР", "" };
            DGVt dgvPlannedProfile = (DGVt)sender;
            // string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "NovemBer", "December" };
            cntCol = 3;
            for (int k = 0; k < 24;)
            {

                Rectangle rtop = dgvPlannedProfile.GetCellDisplayRectangle(k, -1, true); //get the column header cell

                rtop.X += 1;

                rtop.Y += 1;
              //  if (k >= 3) { cntCol = 4; }
                rtop.Width = rtop.Width * cntCol - 2;
 

                rtop.Height = System.Convert.ToInt32(rtop.Height / 3) - 2;

                e.Graphics.FillRectangle(new SolidBrush(dgvPlannedProfile.ColumnHeadersDefaultCellStyle.BackColor), rtop);

                StringFormat formattop = new StringFormat();

                formattop.Alignment = StringAlignment.Center;

                formattop.LineAlignment = StringAlignment.Center;
                int kv = (k +1) / cntCol;
                e.Graphics.DrawString(quarter[kv],


                    dgvPlannedProfile.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(dgvPlannedProfile.ColumnHeadersDefaultCellStyle.ForeColor),

                    rtop,

                    formattop);
                k += cntCol;
                if (k  == 3) {cntCol = 4; }

            }

            //for (int j = 0; j < 24;)
            //{

            //    Rectangle r1 = this.dgvPlannedProfile.GetCellDisplayRectangle(j, -1, true); //get the column header cell

            //    r1.X += 1;

            //    r1.Y += 1 + 15;

            //    r1.Width = r1.Width * 2 - 2;

            //    r1.Height = System.Convert.ToInt32(r1.Height / 3) - 2;

            //    e.Graphics.FillRectangle(new SolidBrush(this.dgvPlannedProfile.ColumnHeadersDefaultCellStyle.BackColor), r1);

            //    StringFormat format = new StringFormat();

            //    format.Alignment = StringAlignment.Center;

            //    format.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString(monthes[j / 2],

            //        this.dgvPlannedProfile.ColumnHeadersDefaultCellStyle.Font,

            //        new SolidBrush(this.dgvPlannedProfile.ColumnHeadersDefaultCellStyle.ForeColor),

            //        r1,

            //        format);


            //    j += 2;

            //}

        }
        void dgvPlannedProfile_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {

                e.PaintBackground(e.CellBounds, false);



                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintContent(r2);

                e.Handled = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // DgvSoglF3.ColumnHeadersHeight = DgvSoglF3.ColumnHeadersHeight / 2;
            //KodUnic.DataSource = null;
            //NomerKS3Sub.DataSource = null;
            DgvSoglF3.DataSource = null;
            DgvSoglSumRazl.DataSource = null;
            DgvSoglSumRazlUchet.DataSource = null;
            //idIstFin.DataSource = null;
            //idDog.DataSource = null;
          //  frmSogl_Load(null, null);
            vSoglSumRazl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_searchInfo.searchString = TextBox1.Text;
            m_searchInfo.searchDirection = SearchDirectionEnum.All;
            m_searchInfo.searchContent = 0;
            m_searchInfo.matchCase = false;
            m_searchInfo.lookIn = null;
            my.search(DgvSoglF3, m_searchInfo);
            DgvSoglF3.CurrentRow.Selected = true;
        }

        private void KodUnic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KodUnic.SelectedValue == null) return;
            if (my.IsNumeric(KodUnic.SelectedValue.ToString()))
            {
                my.MySpisok(232, " and Period = '" + my.Uper + "' and IdEntpr = " + my.identpr + " and idF3 = '" + KodUnic.SelectedValue + "'", null, DgvSoglSumRazlUchet);
            }
        }

        private void NomerKS3Sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NomerKS3Sub.SelectedValue == null || NomerKS3Sub.SelectedValue.ToString() == "System.Data.DataRowView" || NomerKS3Sub.SelectedValue.ToString() == "") return;
            int iddog =0; int idistfin=0;
            Cursor.Current = Cursors.WaitCursor;
            String strsql = "select distinct idistfin, iddog from dbo.vSoglF3  where NomerKS3Sub ='" + NomerKS3Sub.SelectedValue + "'";
            my.cn.Open();
            my.sc.CommandText = strsql;
            SqlDataReader DRd = my.sc.ExecuteReader();
            DRd.Read();
            
            if (DRd["iddog"] != DBNull.Value)
            {
                iddog = (int)DRd["iddog"];
                idistfin = (int)DRd["idistfin"];
            }

            DRd.Close();
            DRd.Dispose();
            my.cn.Close();

            //   if (NomerKS3Sub.SelectedValue.ToString() != "")
            //    {
            //NomerKS3SubOld = NomerKS3Sub.SelectedValue.ToString();
            my.FillDC(KodUnic, 82, " and Period = ''" + my.Uper + "'' and IdEntpr = " + my.identpr + " and NomerKS3Sub = ''" + NomerKS3Sub.SelectedValue + "''");
                my.FillDC(idDog, 16, " and iddog = " + iddog.ToString());
                my.FillDC(idIstFin, 18, " and idistfin = " + idistfin);
            //  lDog.Text = my.ExeScalar(my.FilterSel(719,null, my.sconn, " and NomerKS3Sub = '" + NomerKS3Sub.SelectedValue + "'"));

            // vSoglSumRazl();
            Cursor.Current = Cursors.Default;

            //  }

        }
    }
}
