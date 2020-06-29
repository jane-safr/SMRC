using Microsoft.Reporting.WinForms;
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
    public partial class frmRepF3 : Form
    {
        int IdF3; int VidF3; int TipVneshDog; bool chDrOb; bool ch84; bool ch91; Int16 chDavMat; bool rbNDS; bool rbKop; string FromIsp; string FromIspPost;
            string FromZak; string FromZakPost; int IdZakName; bool ch_2000; bool chActs;
        bool chObor; bool ch_2000AEP;  string tfltr; bool NotBaseOsn;
        string Szap;
        public frmRepF3()
        {
            InitializeComponent();
        }

        void DemoSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            if (chObor)
            {
                //try
                //{

                    // SqlDataAdapter sda = new SqlDataAdapter("select top 2 * from WorkObor ", my.sconn);
                    SqlDataAdapter sda = new SqlDataAdapter("select  * from WorkObor where idf3 in (" + IdF3 + ") and '" + e.Parameters[0].Values[0].ToString() + "' like  '%' + object + '%'", my.sconn);
                    DataSet DS = new DataSet();
                    sda.Fill(DS);
                    e.DataSources.Add(new ReportDataSource("DSWork", DS.Tables[0]));

                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.Message);
                //}
            }

        }
        private void frmRepF3_Load(object sender, EventArgs e)
        {


            ReportParameter PostZak = new ReportParameter("PostZak", FromZakPost.ToString());
            ReportParameter PostIsp = new ReportParameter("PostIsp", FromIspPost.ToString());
            ReportParameter NameZak = new ReportParameter("NameZak", FromZak.ToString());
            ReportParameter NameIsp = new ReportParameter("NameIsp", FromIsp.ToString());
            ReportParameter KodPr = new ReportParameter("KodPr", ("(" + IspF3((frmF3)my.Pform) + ")"));
            ReportParameter sKop = new ReportParameter("sKop", rbKop.ToString());
            ReportParameter DavMat = new ReportParameter("DavMat", (chDavMat == 1).ToString());
            ReportParameter nds = new ReportParameter("nds", (rbNDS ? 18 : 1).ToString());
            ReportParameter Obor = new ReportParameter("Obor", chObor.ToString());

            Szap = ((frmF3)my.Pform).Nom();
            string s = "exec F2_PrintF3Zak  " + IdF3 + ",'"+my.Upred+"'," + (chDrOb ? 1 : 0) + ",'" + ((chActs) ? "TabRas" :  "Tab") + "'," + VidF3.ToString() + "," + "0,'AEP','" + Szap + "','" + tfltr + "'";
            SqlDataAdapter sda = new SqlDataAdapter(s, my.cn);


                DataSet ds = new DataSet();
                sda.Fill(ds);
                this.reportViewer1.Reset();
                this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            if (ch_2000AEP)
                this.reportViewer1.LocalReport.ReportPath = "C:/cis/Reports/rF3AEP.rdlc";
            else
            if (ch_2000)
                this.reportViewer1.LocalReport.ReportPath = "C:/cis/Reports/rF3ATEI.rdlc";
            else
            {
                this.reportViewer1.LocalReport.ReportPath = "C:/cis/Reports/rF3.rdlc";
                ReportParameter p84 = new ReportParameter("p84", ch84.ToString());
                ReportParameter p91 = new ReportParameter("p91", ch91.ToString());
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p84,p91 });
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSF3Ras", ds.Tables[0]));

            s = "select * from v_F3Dog Where idF3=" + IdF3.ToString();
            sda = new SqlDataAdapter(s, my.sconn);
            DataSet ds1 = new DataSet();
            sda.Fill(ds1);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetF3Dog", ds1.Tables[0]));


            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PostZak,PostIsp,NameIsp,NameZak, KodPr,sKop,nds, DavMat, Obor });
            WindowState = FormWindowState.Maximized;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.SubreportProcessing +=
        new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
            this.reportViewer1.RefreshReport();

        }
        private static String IspF3(frmF3 pform)
        {
            String Szap = "";
            for (int i = 0; i < pform.DgvActs.Rows.Count; i++)
            {
                Szap = Szap + pform.DgvActs.Rows[i].Cells[0].Value + ",";
            }
            Szap = Szap.Substring(0, Szap.Length - 1);
            return my.Shapka(Szap, my.identpr);
        }

        public  void F3InRep(int _IdF3, int _VidF3, int _TipVneshDog, bool _chDrOb, bool _ch84, bool _ch91, Int16 _chDavMat, bool _rbNDS, bool _rbKop, string _FromIsp, string _FromIspPost,
            string _FromZak, string _FromZakPost, int _IdZakName, bool _fl_2000,  bool _chActs,bool _chObor, bool _ch_2000AEP,string _tfltr,bool _NotBaseOsn)
        {
            IdF3 = _IdF3; VidF3 = _VidF3; TipVneshDog = _TipVneshDog; chDrOb =_chDrOb;
            ch84 = _ch84;  ch91 = _ch91; chDavMat = _chDavMat; rbNDS =_rbNDS;
            rbKop = _rbKop;  FromIsp = _FromIsp;  FromIspPost = _FromIspPost;
            FromZak = _FromZak; FromZakPost = _FromZakPost;  IdZakName = _IdZakName;
            ch_2000 = _fl_2000;chActs = _chActs;
            chObor = _chObor;  ch_2000AEP = _ch_2000AEP; tfltr = _tfltr;NotBaseOsn =_NotBaseOsn;
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            my.ReportExport(sender, e, reportViewer1);
        }
    }
}
