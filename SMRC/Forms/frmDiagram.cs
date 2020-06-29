using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SMRC.Forms
{

    public partial class frmDiagram : Form
    { string sconn; SqlConnection cn; SqlCommand sc;
        private Process myProcess = new Process();
        
        public frmDiagram()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sconn = "Initial Catalog=test;User ID=prog;Password=prog;Data Source=SQL_JANE\\JANE1;Connect Timeout=30000000;"; // +my.Szap + ";";
            cn = new SqlConnection(sconn);
            cn.ConnectionString =sconn;
            cn.Open();


            //my.sc.CommandText = "select isnull(TipVneshDog,0) as TipVneshDog,PostZak,PostIsp from v_F3Dog Where idf3=" + ((frmF3)my.Pform).IdF3.ToString();
            //my.cn.Open();
            //SqlDataReader dr = my.sc.ExecuteReader();
            //dr.Read();
            //int TipVneshDog = (short)dr["TipVneshDog"];
            //string PostZak = dr["PostZak"].ToString();
            //string PostIsp = dr["PostIsp"].ToString();
            //dr.Close();
            //my.cn.Close();

            sc = new SqlCommand("exec sRrsvodnInFile",cn);

            string path = sc.ExecuteScalar().ToString();
            cn.Close();
            myProcess.StartInfo.FileName = path;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
        }


        private void frmDiagram_Load(object sender, EventArgs e)
        {

        }

        private void frmDiagram_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            string[] TempFolder = Directory.GetFiles("C:\\Temp\\plots");
            // For each temp file:
            try
            {


            foreach (string tempFile in TempFolder)
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
            }
            catch (Exception)
            {

            }
        }

    }
}
