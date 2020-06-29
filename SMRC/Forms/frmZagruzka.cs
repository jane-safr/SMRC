using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace SMRC.Forms
{
    public partial class frmZagruzka : Form
    {
        public int mode;
        Microsoft.Office.Interop.Excel.Application ExlApp; Workbook xlbook; Worksheet WrkSht;

        public frmZagruzka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new  OpenFileDialog();

            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flName.Text = openFileDialog1.FileName;
                zagName.Text = openFileDialog1.SafeFileName.Replace(".xlsx", "").Replace(".xls", "");
                ExlApp = new Microsoft.Office.Interop.Excel.Application();
                xlbook = ExlApp.Workbooks.Open(flName.Text, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                WrkSht = (Worksheet)xlbook.ActiveSheet;
                ExlApp.Visible = true;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (my.IsNumeric(kol.Text) & WrkSht != null)
            {
                string coltxt = "";
                coltxt = ((Range)WrkSht.Cells[1, 1]).Value2.ToString();
                for (int i = 2; i < Convert.ToInt16(kol.Text)+1; i++)
                {
                    if (((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, i]).Value2 == null)
                    {
                        ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, i]).Select();
                        kol.Text = (i - 1).ToString();
                        break;
                    }
                    coltxt = coltxt + "," + ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, i]).Value2.ToString();
                }
                coltxt  = coltxt + ", idGrafik ";
                ColNM.Text = coltxt;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2_Click(null,null);
            if (ColNM.Text == "")
            {
                MessageBox.Show("Определите названия колонок!"); return;
            }
            if (!my.IsNumeric(row.Text))
            {
                MessageBox.Show("Определите количество строк!"); return;
            }

            string sel = "";
            try
            {
                Int64 idGrafik = 0;
                my.cn.Open();
                my.sc.CommandText = "select idGrafik from Grafik.dbo.tGrafik where NMGrafik = '" + zagName.Text + "'";
                if (my.sc.ExecuteScalar() != null)
                {
                    MessageBox.Show("Такой график уже имеется в базе!"); my.cn.Close(); return;
                }
                my.sc.CommandText = "exec Grafik.dbo.sNewGrafik '" + zagName.Text + "'," + idComplex.SelectedValue.ToString() + "," + mode.ToString() ;
                idGrafik = Convert.ToInt64(my.sc.ExecuteScalar());
                for (int j = 3; j < Convert.ToInt16(row.Text) + 3; j++)
                {
                    if (((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, 1]).Value2 != null)
                    {
                        sel = "insert into Grafik.dbo.tTaskWrk (" + ColNM.Text + ") values ('" + ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, 1]).Value2.ToString().Trim();
                        for (int i = 2; i < Convert.ToInt16(kol.Text) + 1; i++)
                        {
                            ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).Select();
                            if (((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, i]).Value2.ToString().ToLower().Contains("date"))
                            {
                                if (((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null) == null ||((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null).ToString() == "31.12.1899 0:00:00" | ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null).ToString() == "01.01.1900 0:00:00" | ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null) == "")
                                {
                                    sel = sel + "', 'null" ;
                                }
                                else
                                sel = sel + "', '" + ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null);
                                //((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).get_Value(null);
                            }
                            else
                                sel = sel + "', '" + (((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).Value2 != null?((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[j, i]).Value2.ToString().Replace("'",""):"");

                        }
                        sel = sel.Replace("'null'","null") + "','" + idGrafik.ToString().Trim() + "')";
                        //my.cn.Open();
                        my.sc.CommandText = sel;
                        my.sc.ExecuteScalar();
                        //}


                    }
                }
            my.cn.Close();
            ((frmGrafikMatch)my.Pform).ObnGr();
            Close();

            }
            catch (Exception ex)
            {
                if ((int)my.cn.State == 1) { my.cn.Close(); }
                MessageBox.Show("Ошибка! " + ex.Message + sel);
           }
        }

        private void frmZagruzka_Load(object sender, EventArgs e)
        {
            my.FillDC(idComplex, 43, " ");
            idComplex.SelectedValue = 32;
        }

        private void flName_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
