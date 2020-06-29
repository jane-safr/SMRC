using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SMRC.Forms
{
    public partial class frmTask : Form
    {
        public string task_code; string[] ars;
        string StartPath; DataTable dtFile; public int idcomplex = 0;
        public frmTask()
        {
            InitializeComponent();
        }

        private void frmTask_Load(object sender, EventArgs e)
        {
            dtFile = new DataTable();
            dtFile.Columns.Add("NMPdf", typeof(String));
            dtFile.Columns.Add("Path", typeof(String));
            StartPath = @"\\fs\fs\";
            my.cn.Open();
            my.sc.CommandText = "select * from Grafik.dbo.vTaskWrk where Osnovnoi = 1 and idComplex = "+idcomplex.ToString()+" and task_code ='" + task_code + "'";
            SqlDataReader dr = my.sc.ExecuteReader();
            while (dr.Read())
            {
                task_code1.Text = task_code;
                user_field_201.Text = dr["user_field_201"].ToString();
                user_field_6678.Text = dr["user_field_6678"].ToString();
                user_field_7966.Text = dr["user_field_7966"].ToString();
            }
            dr.Close();
            my.cn.Close();
            Dgv1.AllowUserToAddRows = false;
            Dgv1.AllowUserToDeleteRows = false;

            Dgv2.AllowUserToAddRows = false;
            Dgv2.AllowUserToDeleteRows = false;
            Dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Dgv3.AllowUserToAddRows = false;
            Dgv3.AllowUserToDeleteRows = false;
            Dgv3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            spisok();

        }
        private void spisok()
        {
            try
            {
                String sel;

                Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();


                sel = "exec Grafik.dbo.sGrafikAC '" + task_code + "',0" ;
                SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
                ds.Clear();
                Dgv1.DataSource = null;
                da.Fill(ds);

                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                Dgv1.DataSource = dv;
                my.naimDG("", Dgv1, "500");



                //Dgv1.Columns["bitidArch"].Visible = false;
                //for (int j = 0; j < Dgv1.RowCount; j++)
                //{

                //    if (Dgv1["bitidArch", j].Value.ToString() == "1")//| user_field_7966.Text.Contains( Dgv1["bitidArch", j].Value.ToString())
                //    {
                //        Dgv1[0, j].Style.BackColor = Color.LightBlue;
                //    }
                //}


                DataSet ds1 = new DataSet();


                sel = "exec Grafik.dbo.sGrafikAC '" + task_code + "',79"; 
                da = new SqlDataAdapter(sel, my.sconn);
                ds1.Clear();
                Dgv2.DataSource = null;
                da.Fill(ds1);

                DataView dv1 = new DataView();
                dv1.Table = ds1.Tables[0];
                Dgv2.DataSource = dv1;
                //my.naimDG("", Dgv1, "500");




                //Dgv2.Columns["bitidArch"].Visible = false;
                //for (int j = 0; j < Dgv2.RowCount; j++)
                //{

                //    if (Dgv2["bitidArch", j].Value.ToString() == "1")
                //    {
                //        Dgv2[0, j].Style.BackColor = Color.LightBlue;
                //    }
                //}

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {

                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           


            Cursor = Cursors.WaitCursor;
            try
            {
                //DirectoryInfo di = new DirectoryInfo("");
                ars = Directory.GetFiles(StartPath, "*" + ((DGVt)sender).Rows[e.RowIndex].Cells[0].Value.ToString() + "*", SearchOption.AllDirectories);
                dtFile.Clear();
                foreach (string i in ars)
                {
                    dtFile.Rows.Add(Path.GetFileName(i),i);
                }
                Dgv3.DataSource = dtFile;
                Dgv3.Columns[0].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка доступа к хранилищу или файлу, " + ex.Message + "\r\nПопробуйте обратиться к администратору сервера 'FS'");
            }
            //finally { 
            Cursor = Cursors.Default; //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Dgv3.CurrentRow == null) return;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = Dgv3.CurrentRow.Cells["Path"].Value.ToString();
            //proc.StartInfo.Arguments = Dgv3.CurrentRow.Cells["NMPdf"].Value.ToString();
            proc.Start();
        }

        private void Dgv3_DoubleClick(object sender, EventArgs e)
        {
            if (Dgv3.CurrentRow == null) return;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = Dgv3.CurrentRow.Cells["Path"].Value.ToString();
            //proc.StartInfo.Arguments = Dgv3.CurrentRow.Cells["NMPdf"].Value.ToString();
            proc.Start();
        }
        private void FilePDF(string proj)
        {
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = Dgv3.CurrentRow.Cells["Path"].Value.ToString();
            //proc.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            dtFile.Clear();
           
            for (int j = 0; j < Dgv1.RowCount; j++)
            {
                string[] ars1 = Directory.GetFiles(StartPath, "*" + Dgv1.Rows[j].Cells["Проект"].Value.ToString() + "*", SearchOption.AllDirectories);
                if (Dgv1.Rows[j].Cells[0].Value.ToString() != "")
                {
                if (ars1.Count() > 0)
                {
                    Dgv1.Rows[j].Cells["Проект"].Style.BackColor = Color.LightCoral;

                    foreach (string i in ars1)
                    {
                        dtFile.Rows.Add(Path.GetFileName(i), i);
                    }

                }
                }
            }
            
                for (int j = 0; j < Dgv2.RowCount; j++)
                {
                    if (Dgv2.Rows[j].Cells[0].Value.ToString() != "")
                    {
                        
                    string[] ars1 = Directory.GetFiles(StartPath, "*" + Dgv2.Rows[j].Cells[0].Value.ToString() + "*", SearchOption.AllDirectories);

                    if (ars1.Count() > 0)
                    {
                        Dgv2.Rows[j].Cells[0].Style.BackColor = Color.LightCoral;

                        foreach (string i in ars1)
                        {
                            dtFile.Rows.Add(Path.GetFileName(i), i);
                        }
                    }
                    }
                }
        
                    Dgv3.DataSource = dtFile;
                    Dgv3.Columns[0].Width = 400;
                    Cursor = Cursors.Default;
        }
                



    }

    }

