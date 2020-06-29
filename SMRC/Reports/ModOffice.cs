using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data;
using System.IO;
using System.Linq;
//using System.Windows.Forms;




namespace SMRC.Forms
{
    static class ModOffice
    {

        private static void KillApp()
        {
            //System.Diagnostics.Process.r
            System.Diagnostics.Process[] Proc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            int x = 0;
            if (Proc != null)
            {
                for (x = 0; x < Proc.Length; x++)
                {
                    if (Proc[x].MainWindowTitle == "") //в моем случае если заголовок окна был пустым, то процесс порождала моя программа
                    {
                        //Proc[x].Close();
                        Proc[x].Kill();
                    }
                }
            }
        }
        public static void TP(int idplan, Forms.frmTemPlan fr, DataView dv1)
        {

            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapp1, null);
            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\TP.xlt";

            //Пробуем открыть книгу
            Application xlapp = (Application)xlapp1;
            //System.Windows.Forms.MessageBox.Show(BindingFlags.InvokeMethod.ToString());
            object xlbooktemplate = workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, workbooks, args);
            //System.Windows.Forms.MessageBox.Show("3");
            //object oWorksheets = xlbooktemplate.GetType().InvokeMember("Plan", BindingFlags.GetProperty, null, xlbooktemplate, null);
            Workbook WrkBk = (Workbook)xlbooktemplate;
            Worksheet WrkSht = (Worksheet)WrkBk.Sheets["Plan"];
            Range rngActiveNMComplex;
            Range rngActiveOSR;
            Range rngActive = (Range)WrkSht.Cells[23, 1];
            //try
            //{
            string s = "";
            xlapp.Visible = true;

            DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
            ds.Clear();
            s = my.FilterSel(17, null, my.sconn, "");
            if (fr.rbplan.Checked)
            {
                s = s + " and idplan  = " + idplan.ToString() + " order by NMComplex, OSR,NomSm";
                da = new SqlDataAdapter(s, my.sconn);
                da.Fill(ds);
            }
            else
            {



                if (fr.rbosr.Checked)
                {
                    s = s + " and idOsr  = " + fr.IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (fr.rb1.Checked ? "2" : "1") + "  and period = '" + fr.Period.SelectedValue.ToString() + "'  order by NMComplex, OSR,NomSm";
                    da = new SqlDataAdapter(s, my.sconn);
                    da.Fill(ds);

                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3," + fr.IdOSR.SelectedValue.ToString(), my.sconn);
                    da.Fill(ds);
                }
                else
                {
                    s = s + " and 1 = 5  ";
                    da = new SqlDataAdapter(s, my.sconn);
                    da.Fill(ds);
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3,0", my.sconn);
                    da.Fill(ds);
                }

            }
            dv.Table = ds.Tables[0];
            dv.Sort = "NMComplex, OSR,NomSm";
            //{  }

            //my.sc.CommandText = s ; //my.FilterSel(17, null, my.sconn, " and idplan  = " + idplan.ToString()  + " order by NMComplex, OSR,NomSm");
            //my.cn.Open();
            //SqlDataReader dv[irow] = my.sc.ExecuteReader();

            ((Range)WrkSht.Cells[14, 5]).Value2 = ((Range)WrkSht.Cells[14, 5]).Value2 + fr.Period.Text;
            ((Range)WrkSht.Cells[12, 5]).Value2 = fr.IdEntpr.Text;
            ((Range)WrkSht.Cells[15, 5]).Value2 = fr.NMPlan.Text;


            string NMComplex = "-1"; string osr = "-1"; int i = -1; int inom = 0; int iOsr = 0; int iComplex = 0; string NomSm = "";
            int ilen = 25;
            for (int irow = 0; irow < dv.Count; irow++)
            {
                ((Range)WrkSht.Cells[17, 4]).Value2 = dv[irow]["NMComplex"].ToString();
                if (osr != dv[irow]["OSR"].ToString() && iOsr != 0)
                {
                    //Nezaversh(osr, dv, rngActive,  i);
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16);
                    //WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                    rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    for (int i1 = 6; i1 < ilen; i1++)
                    {
                        if (i1 != 17 && i1 != 20 && i1 != 23)
                        {
                            rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(i, i1).Font.Bold = true;
                        }
                        else
                        { rngActive.get_Offset(i, i1).Value2 = "/"; }
                    }
                    WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;

                }

                if (NMComplex != dv[irow]["NMComplex"].ToString())
                {
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    if (iComplex != 0)
                    {
                        rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                        rngActive.get_Offset(i, 0).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                        for (int i1 = 6; i1 < ilen; i1++)
                        {
                            if (i1 != 17 && i1 != 20 && i1 != 23)
                            {
                                rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                rngActive.get_Offset(i, i1).Font.Bold = true;
                                rngActive.get_Offset(i, 0).Font.Italic = true;
                            }
                            else
                            { rngActive.get_Offset(i, i1).Value2 = "/"; }
                        }
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                        i = i + 1;
                        bord(WrkSht, rngActive, i, ilen, 16); ;
                    }
                    NMComplex = dv[irow]["NMComplex"].ToString();

                    rngActive.get_Offset(i, 0).Value2 = NMComplex;
                    rngActive.get_Offset(i, 0).Font.Italic = true;
                    rngActiveNMComplex = rngActive.get_Offset(i, 0);
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    iComplex = i;
                    iOsr = 0;
                }
                if (osr != dv[irow]["OSR"].ToString())
                {

                    osr = dv[irow]["OSR"].ToString();
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    rngActive.get_Offset(i, 0).Value2 = osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    rngActiveOSR = rngActive.get_Offset(i, 0);
                    //i = i + 1; 
                    inom = 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    iOsr = i;
                }

                if (NomSm != dv[irow]["NomSm"].ToString())
                {
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16);

                    rngActive.get_Offset(i, 0).Value2 = inom;
                    rngActive.get_Offset(i, 1).Value2 = dv[irow]["KodOSR"].ToString();
                    rngActive.get_Offset(i, 2).Value2 = dv[irow]["Object"].ToString();
                    rngActive.get_Offset(i, 3).Value2 = dv[irow]["KodZak"].ToString();
                    rngActive.get_Offset(i, 4).Value2 = dv[irow]["NomSm"].ToString();
                    rngActive.get_Offset(i, 10).Value2 = (double)dv[irow]["StSm91"] + (double)dv[irow]["StOb91"];
                    rngActive.get_Offset(i, 11).Value2 = (double)dv[irow]["StSm91"];
                    rngActive.get_Offset(i, 12).Value2 = (double)dv[irow]["StOb91"];
                    rngActive.get_Offset(i, 13).Value2 = (double)dv[irow]["Ost91"] + (double)dv[irow]["OstOb91"];
                    rngActive.get_Offset(i, 14).Value2 = (double)dv[irow]["Ost91"];
                    rngActive.get_Offset(i, 15).Value2 = (double)dv[irow]["OstOb91"];
                    rngActive.get_Offset(i, 16).Value2 = (double)dv[irow]["PlanBaz"] + (double)dv[irow]["PlanObBaz"];
                    rngActive.get_Offset(i, 17).Value2 = "/";
                    rngActive.get_Offset(i, 18).Value2 = (double)dv[irow]["PlanTek"] + (double)dv[irow]["PlanObTek"];
                    rngActive.get_Offset(i, 19).Value2 = (double)dv[irow]["PlanBaz"];
                    rngActive.get_Offset(i, 20).Value2 = "/";
                    rngActive.get_Offset(i, 21).Value2 = (double)dv[irow]["PlanTek"];
                    rngActive.get_Offset(i, 22).Value2 = (double)dv[irow]["PlanObBaz"];
                    rngActive.get_Offset(i, 23).Value2 = "/";
                    rngActive.get_Offset(i, 24).Value2 = (double)dv[irow]["PlanObTek"];
                    rngActive.get_Offset(i, 25).Value2 = (double)dv[irow]["i1"];
                    rngActive.get_Offset(i, 26).Value2 = dv[irow]["Isp"].ToString();
                    rngActive.get_Offset(i, 5).Value2 = dv[irow]["NMSmeti"].ToString();
                    if ((int)dv[irow]["CountSm"] > 1)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i + (int)dv[irow]["CountSm"], 0)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i + (int)dv[irow]["CountSm"], 1)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i + (int)dv[irow]["CountSm"], 2)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 3), rngActive.get_Offset(i + (int)dv[irow]["CountSm"], 3)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 4), rngActive.get_Offset(i + (int)dv[irow]["CountSm"], 4)).Merge(Type.Missing);
                    }
                }

                if ((int)dv[irow]["CountSm"] > 1) { i = i + 1; bord(WrkSht, rngActive, i, ilen, 16); ; }

                rngActive.get_Offset(i, 5).Value2 = ((int)dv[irow]["CountSm"] > 1 ? dv[irow]["NMVidWrk"].ToString() : dv[irow]["NMSmeti"].ToString());
                rngActive.get_Offset(i, 6).Value2 = dv[irow]["NMEdIzm"].ToString();
                rngActive.get_Offset(i, 7).Value2 = (double)dv[irow]["VolSm"];
                rngActive.get_Offset(i, 8).Value2 = (double)dv[irow]["OstFO"];
                rngActive.get_Offset(i, 9).Value2 = (double)dv[irow]["VolEnt"];


                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 6)).Font.Size = 8;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 6)).WrapText = true;
                if (dv[irow]["NM"].ToString() == "Незавершенка") { WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Font.Color = -11480942; }

                NomSm = dv[irow]["NomSm"].ToString();
                NMComplex = dv[irow]["NMComplex"].ToString();
                osr = dv[irow]["osr"].ToString();
                inom = inom + 1;
                //i = i + 1;
            }
            //while (dv[irow].Read())
            //{



            //}
            if (iOsr != 0)
            {

                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                rngActive.get_Offset(i, 0).Font.Italic = true;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Всего: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;

                rngActive.get_Offset(i, 0).Value2 = "Всего с НДС: ";
                double nds = 1.20;
                rngActive.get_Offset(i, 0).Font.Bold = true;

                for (int i1 = 17; i1 < ilen; i1++)
                {
                    if (i1 == 18 || i1 == 21 || i1 == 24)
                    {
                        //System.Windows.Forms.MessageBox.Show("=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")*" + nds.ToString().Replace(",","."));
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")*" + nds.ToString().Replace(".", ",");
                        //System.Windows.Forms.MessageBox.Show("2");
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, i1).Font.Italic = true;
                        //System.Windows.Forms.MessageBox.Show("3");
                    }
                }
                //System.Windows.Forms.MessageBox.Show("22");
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 16), rngActive.get_Offset(i, ilen + 1)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
            }
            //i = i + 1;
            //}
            //catch (Exception ex)
            //{

            //     System.Windows.Forms.MessageBox.Show(ex.Message);
            //     if ((int)my.cn.State == 1) { my.cn.Close(); }
            //     //WrkBk = null;
            //     //WrkSht = null;
            //     //xlapp = null;
            //     //rngActive = null;
            //     //rngActiveNMComplex = null;
            //     //rngActiveOSR = null;
            //     KillApp();
            //     GC.Collect();
            //     // Вызываем сборщик мусора для немедленной очистки памяти
            //     GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //     GC.Collect();
            //}

            my.cn.Close();

            WrkBk = null;
            WrkSht = null;
            xlapp = null;
            rngActive = null;
            rngActiveNMComplex = null;
            rngActiveOSR = null;
            KillApp();
            GC.Collect();
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect();
            //System.Windows.Forms.MessageBox.Show("2");

        }

        private static void Nezaversh(string osr, DataView dv, Range rngActive, int i)
        {
            if (dv.Count == 0) return;
            if (osr != "")
            {
                dv.RowFilter = "osr = " + osr;
            }
            dv.Sort = "NMComplex, OSR,NomSm";
        }
        public static void proba()
        {
            Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

            //Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
            ExlApp.Visible = true;
            //Application xlapp = new Application();
            // Worksheet  xlWorkSheet= null;
            Workbook xlbook = ExlApp.Workbooks.Open("C:\\cis\\Сервис\\Hierar.xltx", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Worksheet xlWorkSheet = (Worksheet)xlbook.ActiveSheet;
            Microsoft.Office.Interop.Excel.Shapes shape = (Microsoft.Office.Interop.Excel.Shapes)xlWorkSheet.Shapes;
            for (int shap = 1; shap <= shape.Count; shap++)
            {
                Microsoft.Office.Interop.Excel.Shape singleShape = (Microsoft.Office.Interop.Excel.Shape)(shape.Item(shap));
                //singleShape.Nodes.Parent
                //singleShape.TextEffect.Text = "hghfgy";
                //string fontName = singleShape.TextEffect.FontName;

            }


        }

        public static void F3InExcel(int IdF3, int VidF3, int TipVneshDog, bool chDrOb, bool ch84, bool ch91, Int16 chDavMat, bool rbNDS, bool rbKop, string FromIsp, string FromIspPost,
                    string FromZak, string FromZakPost, int IdZakName, bool fl_2000,  bool chActs)
        {

            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapptemplate = Activator.CreateInstance(excelType);
            object workbooks = xlapptemplate.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapptemplate, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\Форма3.xls";
            //Пробуем открыть книгу
            object xlbooktemplate = workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, workbooks, args);
            object oWorksheets = xlbooktemplate.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, xlbooktemplate, null);
            // Задаем имя страницы
            args[0] = "КС3Новая";
            // Получаем ссылку на страницу с именем "КС3Новая"
            object xlsheettemplate = oWorksheets.GetType().InvokeMember(
              "Item", BindingFlags.GetProperty, null, oWorksheets, args);

            Application xlapp = new Application();

            int iorder = 0;
            Workbook xlbook = null;
            Worksheet xlsheet = null;

            int i = 0;
            int КолСтрок = 0;
            int КолСтрокОбъектов = 0;
            int Отступ = 0;
            int IdDog = 0;
            iorder = 1;
            my.cn.Open();
            my.sc.CommandText = "select * from v_F3Dog Where idF3=" + IdF3.ToString();
            SqlDataReader sd = my.sc.ExecuteReader();
            sd.Read();
            IdDog = (int)sd["IdDog"];

            xlapp.Visible = true;

            xlbook = xlapp.Workbooks.Add(Type.Missing);
            xlsheet = (Worksheet)xlbook.ActiveSheet;
            xlapp.ActiveWindow.DisplayZeros = false;

            //ширина столбцов
            for (i = 1; i <= 8; i++)
            {
                ((Range)xlsheet.Columns[i, Type.Missing]).ColumnWidth = ((Range)((Worksheet)xlsheettemplate).Columns[i, Type.Missing]).ColumnWidth;
            }
            ((Worksheet)xlsheettemplate).get_Range("A1", "H28").Select();


            ((Range)((Application)xlapptemplate).Selection).Copy(Type.Missing);
            ((Range)xlsheet.Cells[1, 1]).Select();
            xlsheet.Paste(Type.Missing, Type.Missing);
            System.Windows.Forms.Clipboard.Clear();
            ((Worksheet)xlsheettemplate).get_Range("A29", "B31").Select();
            ((Range)((Application)xlapptemplate).Selection).Copy(Type.Missing);
            xlsheet.get_Range("A29", "A29").Select();
            xlsheet.Paste(Type.Missing, Type.Missing);
            System.Windows.Forms.Clipboard.Clear();
            xlsheet.get_Range("A31", "H31").Select();
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''нижняя граница
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;

            //данные шапки

            xlsheet.Cells[22, 4] = sd["RegNomer"].ToString(); //номер справки
            xlsheet.Cells[22, 5] = sd["PeriodEnd"]; //Date
            xlsheet.Cells[12, 1] = "Стройка: " + sd["naim"];
            xlsheet.get_Range(xlsheet.Cells[12, 1], xlsheet.Cells[12, 5]).Merge(Type.Missing);
            ((Range)xlsheet.Cells[12, 1]).WrapText = true;
            if (sd["naim"].ToString().Length > 60)
            {
                ((Range)xlsheet.Cells[12, 1]).RowHeight = 22.5;
            }

            xlsheet.Cells[22, 7] = sd["Period"];
            xlsheet.Cells[22, 8] = sd["PeriodEnd"];
            xlsheet.Cells[15, 6] = sd["RegNomerDog"];

            //((Application)xlapptemplate).Visible = true; ((Worksheet)xlsheet).get_Range("A1", "A1").Select();
            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(4000);
            //((Application)xlapptemplate).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(workbooks);
            //Marshal.ReleaseComObject(oWorksheets);
            //Marshal.ReleaseComObject(xlsheettemplate);
            //Marshal.ReleaseComObject(xlbooktemplate);
            //Marshal.ReleaseComObject(xlapptemplate);

            //((Application)xlapp).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(xlsheet);
            //Marshal.ReleaseComObject(xlbook);
            //Marshal.ReleaseComObject(xlapp);
            //GC.Collect();
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //GC.Collect();
            //return;

            if (sd["Date_1"] != DBNull.Value)
            {
                xlsheet.Cells[16, 6] = ((DateTime)sd["Date_1"]).Day;
                xlsheet.Cells[16, 7] = ((DateTime)sd["Date_1"]).Month;
                xlsheet.Cells[16, 8] = ((DateTime)sd["Date_1"]).Year;
            }
            if (sd["zak"].ToString() == "094")
            {
                xlsheet.Cells[6, 1] = "Инвестор: " + sd["Investr"];
                xlsheet.Cells[6, 7] = sd["OkpoZak"];
                ((Range)xlsheet.Cells[6, 1]).get_Characters(10, sd["ZakName"].ToString().Length).Font.Bold = true;
            }
            xlsheet.Cells[8, 1] = "Заказчик (генподрядчик):  " + sd["ZakName"].ToString().Trim();

            ((Range)xlsheet.Cells[8, 1]).get_Characters(26, sd["ZakName"].ToString().Length).Font.Bold = true;

            if (sd["F3Predjav"].ToString() != "000")
            {
                xlsheet.Cells[8, 1] = xlsheet.Cells[8, 1] + " ( " + sd["F3PredjavName"].ToString().Trim() + " ) ";
            }

            xlsheet.Cells[8, 7] = sd["OkpoZak"];

            //((Application)xlapptemplate).Visible = true; ((Worksheet)xlsheet).get_Range("A1", "A1").Select();
            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(5000);
            //((Application)xlapptemplate).Quit();((Application)xlapp).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(workbooks);
            //Marshal.ReleaseComObject(oWorksheets);
            //Marshal.ReleaseComObject(xlsheettemplate);
            //Marshal.ReleaseComObject(xlbooktemplate);
            //Marshal.ReleaseComObject(xlapptemplate);


            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(xlsheet);
            //Marshal.ReleaseComObject(xlbook);
            //Marshal.ReleaseComObject(xlapp);
            //GC.Collect();
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //GC.Collect();
            //return;



            if (VidF3 == 1) // к заказчику
            {
                if (sd["zak"].ToString() == "094")
                {
                    xlsheet.Cells[10, 1] = ((Range)xlsheet.Cells[10, 1]).get_Value(Type.Missing) + sd["IspName"].ToString();
                    ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
                }
                else
                {
                    xlsheet.Cells[10, 1] = "Подрядчик (субподрядчик): " + sd["IspName"];
                    ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
                }
            }
            else
            {
                xlsheet.Cells[10, 1] = "Подрядчик (субподрядчик): " + sd["IspName"];
            }
            //((Application)xlapptemplate).Visible = true; ((Worksheet)xlsheet).get_Range("A1", "A1").Select();
            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(4000);
            //((Application)xlapptemplate).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(workbooks);
            //Marshal.ReleaseComObject(oWorksheets);
            //Marshal.ReleaseComObject(xlsheettemplate);
            //Marshal.ReleaseComObject(xlbooktemplate);
            //Marshal.ReleaseComObject(xlapptemplate);

            //((Application)xlapp).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(xlsheet);
            //Marshal.ReleaseComObject(xlbook);
            //Marshal.ReleaseComObject(xlapp);
            //GC.Collect();
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //GC.Collect();
            //return;


            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(3000);
            //((Application)xlapptemplate).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(workbooks);
            //Marshal.ReleaseComObject(oWorksheets);
            //Marshal.ReleaseComObject(xlsheettemplate);
            //Marshal.ReleaseComObject(xlbooktemplate);
            //Marshal.ReleaseComObject(xlapptemplate);
            //GC.Collect();
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //GC.Collect();
            //return;



            xlsheet.Cells[10, 7] = "";
            xlsheet.Cells[10, 7] = sd["OKPOIsp"];
            if ((bool)sd["Vnut"] || sd["zak"].ToString() == "A01" || sd["zak"].ToString() == "001" || sd["zak"].ToString() == "A09")
            {
                xlsheet.Cells[10, 1] = "Подрядчик (субподрядчик): " + sd["IspName"];
                ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
            }
            ((Range)xlsheet.Cells[2, 1]).NumberFormat = "@";

            sd.Close();
            my.cn.Close();

            xlsheet.Cells[2, 1] = IspF3((frmF3)my.Pform);// my.Shapka(my.Szap, my.identpr);
            xlsheet.Cells[2, 1] = my.SzapN;
            xlsheet.Cells[3, 1] = my.MyStr[3];
            // заполнение строк 84 и 91 годов
            my.sc.CommandText = "F2_PrintF3Zak '" + IdF3 + "','000'," + Convert.ToInt32(chDrOb) + ",'Sum'," + VidF3.ToString() + "," + my.identpr.ToString();
            my.cn.Open();
            sd = my.sc.ExecuteReader();
            sd.Read();
            Отступ = 0;
            КолСтрок = 0;
            string Диапазон;

            if (fl_2000)
            {
                Отступ = Отступ + 1;
                xlsheet.Cells[Отступ + 31, 2] = "в том числе в ценах 2000г.";
                ((Range)xlsheet.Cells[Отступ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
                xlsheet.Cells[Отступ + 31, 5] = sd["Sum2000SNG"];
                xlsheet.Cells[Отступ + 31, 7] = sd["Sum2000"];
                xlsheet.Cells[Отступ + 31, 4] = sd["SumSNP2000"];
                Диапазон = "A" + System.Convert.ToString(Отступ + 31) + ":H" + System.Convert.ToString(Отступ + 31);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
                КолСтрок = КолСтрок + 1;
            }
            else
            {
                if (ch84)
                {
                    Отступ = Отступ + 1;
                    xlsheet.Cells[Отступ + 31, 2] = "в ценах 1984 г.";
                    ((Range)xlsheet.Cells[Отступ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
                    xlsheet.Cells[Отступ + 31, 5] = sd["Сумма84СНГ"];
                    xlsheet.Cells[Отступ + 31, 7] = sd["Сумма84"];
                    Диапазон = "A" + System.Convert.ToString(Отступ + 31) + ":H" + System.Convert.ToString(Отступ + 31);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
                    КолСтрок = КолСтрок + 1;
                }
                if (ch91)
                {
                    Отступ = Отступ + 1;
                    xlsheet.Cells[Отступ + 31, 2] = "в ценах 1991 г.";
                    ((Range)xlsheet.Cells[Отступ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
                    xlsheet.Cells[Отступ + 31, 5] = sd["Сумма91СНГ"];
                    xlsheet.Cells[Отступ + 31, 7] = sd["Сумма91"];
                    Диапазон = "A" + System.Convert.ToString(Отступ + 31) + ":H" + System.Convert.ToString(Отступ + 31);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
                    КолСтрок = КолСтрок + 1;
                }
            }

            // жирно отделить 84 и 91 годы от объектов
            if (ch84 || ch91 || fl_2000)
            {
                Диапазон = "A" + System.Convert.ToString(Отступ + 31) + ":H" + System.Convert.ToString(Отступ + 31);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
            }
            Double DavMat = (Double)sd["ДавальчМатериалы"];
            sd.Close();
            //    ВидСправки = "КЗаказчику"
            my.sc.CommandText = "exec F2_PrintF3Zak  " + IdF3 + ",'000'," + (chDrOb ? 1 : 0) + ",'" + ((chActs) ? "TabRas" : "Tab") + "'," + VidF3.ToString() + "," + my.identpr;
            sd = my.sc.ExecuteReader();
            //sd.Read();


            КолСтрок = 1;
            i = 0;
            string Obj = null;
            string naim = null;
            Obj = "";
            bool sdR = sd.Read();

            while (sdR)
            {

                naim = sd["Объект"].ToString().Trim();//((IsNull(sd["Объект"])) ? "" : );

                int i1 = 0;

                ((Range)xlsheet.Columns[15, Type.Missing]).Hidden = true;
                ((Range)xlsheet.Columns[16, Type.Missing]).Hidden = true;
                ((Range)xlsheet.Columns[17, Type.Missing]).Hidden = true;
                if (chActs )
                {
                    if (Obj != naim.Trim())
                    {
                        Obj = naim;
                        xlsheet.Cells[Отступ + 32 + i, 2] = naim;
                        ((Range)xlsheet.Cells[Отступ + 32 + i, 2]).Font.Bold = true;
                        i1 = i;
                        i = i + 1;
                        КолСтрок = КолСтрок + 1;
                    }
                    xlsheet.Cells[Отступ + 32 + i, 2] = sd["naim"].ToString().Trim(); // наименование акта
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 2]).WrapText = true;

                }
                else
                {
                    xlsheet.Cells[Отступ + 32 + i, 2] = naim;
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 2]).WrapText = true;
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 2]).Font.Bold = true;
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 2]).Font.Size = 9;

                }

                xlsheet.Cells[Отступ + 32 + i, 1] = sd["kodosr"];
                ((Range)xlsheet.Cells[Отступ + 32 + i, 1]).Font.Size = 9;
                xlsheet.Cells[Отступ + 32 + i, 3] = sd["KodZak"].ToString() + sd["Shifr"].ToString();
                ((Range)xlsheet.Cells[Отступ + 32 + i, 3]).Font.Size = 7;
                xlsheet.Cells[Отступ + 32 + i, 5] = sd["СуммаТекСНГ"]; //с начала года
                //((Range)xlsheet.Cells[Отступ + 32 + i, 5]).Select();
                ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                xlsheet.Cells[Отступ + 32 + i, 4] = sd["СуммаТекСНП"];
                ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                xlsheet.Cells[Отступ + 32 + i, 7] = sd["СуммаТек"];
                ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";

                ((Range)xlsheet.Cells[Отступ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                ((Range)xlsheet.Cells[Отступ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                ((Range)xlsheet.Cells[Отступ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                Диапазон = "A" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();

                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;

                if (fl_2000)
                {
                    i = i + 1;
                    КолСтрок = КолСтрок + 1;
                    xlsheet.Cells[Отступ + 32 + i, 2] = "в том числе в ц 2000г.";
                    xlsheet.Cells[Отступ + 32 + i, 5] = (Double)sd["Sum2000SNG"] - (Double)sd["Sum2000zuSNG"] - (Double)sd["Sum2000PerRabSNG"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 4] = (Double)sd["SumSNP2000"] - (Double)sd["Sum2000zuSNP"] - (Double)sd["Sum2000PerRabSNP"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 7] = (Double)sd["Sum2000"] - (Double)sd["Sum2000zu"] - (Double)sd["Sum2000PerRab"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";
                    Диапазон = "A" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Italic = true;
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Size = 8;

                    i = i + 1;
                    КолСтрок = КолСтрок + 1;
                    xlsheet.Cells[Отступ + 32 + i, 2] = "Удорожание работ в зимнее время";
                    xlsheet.Cells[Отступ + 32 + i, 3] = "09.09.01";
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 3]).Font.Size = 7;
                    xlsheet.Cells[Отступ + 32 + i, 5] = sd["zuSNG"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 7] = sd["zu"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 4] = sd["zuSNP"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                    Диапазон = "B" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Bold = true;
                    Диапазон = "B" + System.Convert.ToString(Отступ + 32 + i - 2) + ":H" + System.Convert.ToString(Отступ + 32 + i - 2);
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Bold = true;
                    xlsheet.Cells[Отступ + 32 + i - 2, 1] = iorder;
                    iorder = iorder + 1;
                    xlsheet.Cells[Отступ + 32 + i - 2, 3] = sd["kodosr"];
                    xlsheet.Cells[Отступ + 32 + i - 2, 5] = (Double)((Range)xlsheet.Cells[Отступ + 32 + i - 2, 5]).get_Value(Type.Missing) - (Double)sd["zuSNG"] - (Double)sd["PerRabSNG"]; //с начала года
                    xlsheet.Cells[Отступ + 32 + i - 2, 7] = (Double)((Range)xlsheet.Cells[Отступ + 32 + i - 2, 7]).get_Value(Type.Missing) - (Double)sd["zu"] - (Double)sd["PerRab"];
                    xlsheet.Cells[Отступ + 32 + i - 2, 4] = (Double)((Range)xlsheet.Cells[Отступ + 32 + i - 2, 4]).get_Value(Type.Missing) - (Double)sd["zuSNP"] - (Double)sd["PerRabSNP"];

                    ((Range)xlsheet.Cells[Отступ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);

                    i = i + 1;
                    КолСтрок = КолСтрок + 1;
                    xlsheet.Cells[Отступ + 32 + i, 2] = "в том числе в ц 2000г.";
                    xlsheet.Cells[Отступ + 32 + i, 5] = sd["Sum2000zuSNG"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 7] = sd["Sum2000zu"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 4] = sd["Sum2000zuSNP"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                    Диапазон = "B" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Italic = true;


                    i = i + 1;
                    КолСтрок = КолСтрок + 1;
                    xlsheet.Cells[Отступ + 32 + i, 2] = "Затраты по перевозке работников";
                    xlsheet.Cells[Отступ + 32 + i, 3] = "09.09.02";
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 3]).Font.Size = 7;
                    xlsheet.Cells[Отступ + 32 + i, 5] = sd["PerRabSNG"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 7] = sd["PerRab"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 4] = sd["PerRabSNP"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                    Диапазон = "B" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Bold = true;
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);

                    i = i + 1;
                    КолСтрок = КолСтрок + 1;
                    xlsheet.Cells[Отступ + 32 + i, 2] = "в том числе в ц 2000г.";
                    xlsheet.Cells[Отступ + 32 + i, 5] = sd["Sum2000PerRabSNG"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 5]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 7] = sd["Sum2000PerRab"];
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 7]).NumberFormat = "# ##0";
                    xlsheet.Cells[Отступ + 32 + i, 4] = sd["Sum2000PerRabSNP"]; //с начала года
                    ((Range)xlsheet.Cells[Отступ + 32 + i, 4]).NumberFormat = "# ##0";
                    Диапазон = "A" + System.Convert.ToString(Отступ + 32 + i) + ":H" + System.Convert.ToString(Отступ + 32 + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Font.Italic = true;
                    xlsheet.get_Range(Диапазон, Type.Missing).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                }
                i = i + 1;
                sdR = sd.Read();
                КолСтрок = КолСтрок + 1;

                if (sdR & chActs )
                {
                    if (Obj != (((sd["Объект"] == DBNull.Value)) ? "" : sd["Объект"].ToString()))
                    {
                        xlsheet.Cells[Отступ + 32 + i1, 4] = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;D" + System.Convert.ToString(32 + i1 + 1) + ":D" + System.Convert.ToString(31 + i);
                        xlsheet.Cells[Отступ + 32 + i1, 5] = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;E" + System.Convert.ToString(32 + i1 + 1) + ":E" + System.Convert.ToString(31 + i);
                        xlsheet.Cells[Отступ + 32 + i1, 7] = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;G" + System.Convert.ToString(32 + i1 + 1) + ":G" + System.Convert.ToString(31 + i);
                        ((Range)xlsheet.Cells[Отступ + 32 + i1, 4]).Font.Bold = true;
                        ((Range)xlsheet.Cells[Отступ + 32 + i1, 5]).Font.Bold = true;
                        ((Range)xlsheet.Cells[Отступ + 32 + i1, 7]).Font.Bold = true;
                    }

                }
            }

            КолСтрок = КолСтрок - 1;
            КолСтрокОбъектов = КолСтрок;
            КолСтрок = КолСтрок + Отступ;

            // сумма по строчкам
            ((Range)xlsheet.Cells[КолСтрок + 32, 7]).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;Q" + System.Convert.ToString(32 + Отступ) + ":Q" + System.Convert.ToString(31 + КолСтрок) + ")";
            ((Range)xlsheet.Cells[КолСтрок + 32, 7]).Font.Bold = true;
            ((Range)xlsheet.Cells[30, 7]).Formula = "=СУММ(Q" + System.Convert.ToString(32 + Отступ) + ":Q" + System.Convert.ToString(31 + КолСтрок) + ")";
            ((Range)xlsheet.Cells[30, 7]).Font.Bold = true;
            ((Range)xlsheet.Cells[30, 5]).Formula = "=СУММ(P" + System.Convert.ToString(32 + Отступ) + ":P" + System.Convert.ToString(31 + КолСтрок) + ")";
            ((Range)xlsheet.Cells[30, 5]).Font.Bold = true;
            ((Range)xlsheet.Cells[30, 4]).Formula = "=СУММ(O" + System.Convert.ToString(32 + Отступ) + ":O" + System.Convert.ToString(31 + КолСтрок) + ")";
            ((Range)xlsheet.Cells[30, 4]).Font.Bold = true;
            xlsheet.Cells[КолСтрок + 32, 5] = "Итого";
            ((Range)xlsheet.Cells[КолСтрок + 32, 5]).HorizontalAlignment = Constants.xlRight;
            ((Range)xlsheet.Cells[КолСтрок + 32, 5]).Font.Bold = true;
            if (chDavMat == 1)
            {
                xlsheet.Cells[КолСтрок + 33, 7] = sd["ДавальчМатериалы"];
                ((Range)xlsheet.Cells[КолСтрок + 33, 7]).Font.Bold = true;
                xlsheet.Cells[КолСтрок + 33, 5] = "Давальческие материалы";
                ((Range)xlsheet.Cells[КолСтрок + 33, 5]).HorizontalAlignment = Constants.xlRight;
                ((Range)xlsheet.Cells[КолСтрок + 33, 5]).Font.Bold = true;
                xlsheet.Cells[КолСтрок + 34, 5] = "Оплата ";
                ((Range)xlsheet.Cells[КолСтрок + 33, 5]).HorizontalAlignment = Constants.xlRight;
                ((Range)xlsheet.Cells[КолСтрок + 34, 5]).Font.Bold = true;
                xlsheet.Cells[КолСтрок + 34, 7] = (Double)((Range)xlsheet.Cells[КолСтрок + 32, 7]).get_Value(Type.Missing) - (Double)((Range)xlsheet.Cells[КолСтрок + 33, 7]).get_Value(Type.Missing);
                ((Range)xlsheet.Cells[КолСтрок + 37, 7]).Font.Bold = true;
            }
            Диапазон = "F" + System.Convert.ToString(КолСтрок + 32) + ":H" + System.Convert.ToString(32 + КолСтрок + chDavMat * 2);
            xlsheet.get_Range(Диапазон, Type.Missing).Select();
            for (i = 1; i <= (1 + chDavMat * 2); i++)
            {
                Диапазон = "F" + System.Convert.ToString(КолСтрок + 31 + i) + ":H" + System.Convert.ToString(31 + КолСтрок + i);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();

                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''нижняя граница
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
            }

            int nds = 0;
            nds = 20;
            if (my.Uper.Year >= 2004 || my.Uper.Year < 2019)
            {
                nds = 18;
            }

            if (rbNDS) //c НДС
            {
                xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 5] = "Сумма НДС";
                ((Range)xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 5]).HorizontalAlignment = Constants.xlRight;
                ((Range)xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 5]).Font.Bold = true;
                xlsheet.Cells[КолСтрок + 34 + chDavMat * 2, 5] = "Итого с учетом НДС";
                ((Range)xlsheet.Cells[КолСтрок + 34 + chDavMat * 2, 5]).HorizontalAlignment = Constants.xlRight;
                ((Range)xlsheet.Cells[КолСтрок + 34 + chDavMat * 2, 5]).Font.Bold = true;

                if (rbKop) //с копейками
                {
                    Диапазон = "G" + System.Convert.ToString(30 + Отступ - 1) + ":G" + System.Convert.ToString(КолСтрок + 34 + chDavMat * 2);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).NumberFormat = "# ##0,00";
                    if (!fl_2000)
                    {
                        ((Range)xlapp.Selection).Font.Bold = true;
                    }
                    xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 7] = Math.Floor((Double)((Range)xlsheet.Cells[КолСтрок + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) * nds + 0.5) / 100; //НДС
                }
                else
                {
                    Диапазон = "G" + System.Convert.ToString(30 + Отступ) + ":G" + System.Convert.ToString(КолСтрок + 34 + chDavMat * 2);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).NumberFormat = "# ##0";
                    Диапазон = "G" + System.Convert.ToString(КолСтрок + 33 + chDavMat * 2) + ":G" + System.Convert.ToString(КолСтрок + 34 + chDavMat * 2);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).NumberFormat = "# ##0.00";
                    ((Range)xlapp.Selection).Font.Bold = true;
                    xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 7] = (int)Math.Floor((Double)((Range)xlsheet.Cells[КолСтрок + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) * nds + 0.5) / 100;
                }
                for (i = 1; i <= 3 + chDavMat * 2; i++)
                {
                    Диапазон = "F" + System.Convert.ToString(КолСтрок + 31 + i) + ":H" + System.Convert.ToString(31 + КолСтрок + i);
                    xlsheet.get_Range(Диапазон, Type.Missing).Select();
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''нижняя граница
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                    ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
                }
                xlsheet.Cells[КолСтрок + 34 + chDavMat * 2, 7] = (Double)((Range)xlsheet.Cells[КолСтрок + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) + (Double)((Range)xlsheet.Cells[КолСтрок + 33 + chDavMat * 2, 7]).get_Value(Type.Missing);
                ((Range)xlsheet.Cells[КолСтрок + 34 + chDavMat * 2, 7]).Font.Bold = true;


            }
            else
            {
                Диапазон = "G" + System.Convert.ToString(30 + Отступ) + ":G" + System.Convert.ToString(КолСтрок + 32 + chDavMat * 2);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();
                if (rbKop)
                {
                    ((Range)xlapp.Selection).NumberFormat = "# ##0,00";
                }
                else
                {
                    ((Range)xlapp.Selection).NumberFormat = "# ##0";
                }
            }

            for (i = 1; i <= 5; i++)
            {
                Диапазон = ((char)(i + 65)).ToString() + "29:" + ((char)(i + 65)).ToString() + System.Convert.ToString(КолСтрок + 31);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
            }
            if (rbNDS) //с ндс
            {
                Диапазон = "F32:H" + System.Convert.ToString(КолСтрок + 34 + DavMat * 2);
                //if (IdDog == 2503)
                //{
                //    xlsheet.Cells[КолСтрок + 35 + DavMat * 2, 2] = "За оказание услуг удерживается";
                //    xlsheet.Cells[КолСтрок + 36 + DavMat * 2, 2] = "14.0% от " + xlsheet.Cells[КолСтрок + 32 + DavMat * 2, 7] + "=";
                //    xlsheet.Cells[КолСтрок + 36 + DavMat * 2, 3] = (Double)xlsheet.Cells[КолСтрок + 32 + DavMat * 2, 7] * 0.14 + "руб.";
                //    xlsheet.Cells[КолСтрок + 37 + DavMat * 2, 2] = "НДС="; 
                //    xlsheet.Cells[КолСтрок + 37 + DavMat * 2, 3] = (int)Math.Floor(Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[КолСтрок + 36 + DavMat * 2, 3]) * nds + 0.5) / 100 + "руб.";
                //    xlsheet.Cells[КолСтрок + 38 + DavMat * 2, 2] = "с НДС="; 
                //    xlsheet.Cells[КолСтрок + 38 + DavMat * 2, 3] = (Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[КолСтрок + 37 + DavMat * 2, 3]) + Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[КолСтрок + 36 + DavMat * 2, 3])) + "руб.";
                //    //        КолСтрок = КолСтрок + 4
                //}
            }
            else
            {
                Диапазон = "F32:H" + System.Convert.ToString(КолСтрок + 32 + DavMat * 2);
            }

            xlsheet.get_Range(Диапазон, Type.Missing).Select();
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;



            // жирное очертание данных в таблице.
            Диапазон = "C29:H" + System.Convert.ToString(КолСтрок + 31);
            xlsheet.get_Range(Диапазон, Type.Missing).Select();

            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThick;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThick;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThick;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThick;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThick;
            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;

            //подписи
            if (IdDog == 2503)
            {
                КолСтрок = КолСтрок + 4;
            }
            args[0] = "Подписи";
            // Получаем ссылку на страницу с именем "КС3Новая"
            xlsheettemplate = oWorksheets.GetType().InvokeMember(
             "Item", BindingFlags.GetProperty, null, oWorksheets, args);

            ((Worksheet)xlsheettemplate).Activate();



            ((Worksheet)xlsheettemplate).get_Range("A1", "H2").Select();
            ((Range)((Application)xlapptemplate).Selection).Copy(Type.Missing);
            Диапазон = "A" + System.Convert.ToString(КолСтрок + 37 + DavMat * 2) + ":H" + System.Convert.ToString(КолСтрок + 38 + DavMat * 2);
            xlsheet.get_Range(Диапазон, Type.Missing).Select();
            xlsheet.Paste(Type.Missing, Type.Missing);
            System.Windows.Forms.Clipboard.Clear();
            xlsheet.Cells[КолСтрок + 37 + DavMat * 2, 3] = FromIspPost;
            xlsheet.Cells[КолСтрок + 37 + DavMat * 2, 8] = FromIsp;

            ((Worksheet)xlsheettemplate).get_Range("A3:H6", Type.Missing).Select();
            ((Range)((Application)xlapptemplate).Selection).Copy(Type.Missing);
            Диапазон = "A" + System.Convert.ToString(КолСтрок + 39 + DavMat * 2) + ":H" + System.Convert.ToString(КолСтрок + 41 + DavMat * 2);
            xlsheet.get_Range(Диапазон, Type.Missing).Select();
            xlsheet.Paste(Type.Missing, Type.Missing);
            System.Windows.Forms.Clipboard.Clear();


            if (IdZakName == 1376 | IdZakName == 670) //КПР и реконструкция
            {
                ((Worksheet)xlsheettemplate).get_Range("C4:H6", Type.Missing).Select();
                ((Range)((Application)xlapptemplate).Selection).Copy(Type.Missing);
                Диапазон = "C" + System.Convert.ToString(КолСтрок + 43 + DavMat * 2) + ":H" + System.Convert.ToString(КолСтрок + 44 + DavMat * 2);
                xlsheet.get_Range(Диапазон, Type.Missing).Select();
                xlsheet.Paste(Type.Missing, Type.Missing);
                System.Windows.Forms.Clipboard.Clear();
                ((Range)xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3]).RowHeight = 31.5;
                xlsheet.get_Range(xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3], xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 6]).Merge(Type.Missing);
                xlsheet.get_Range(xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3], xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 6]).WrapText = true;
                xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3] = FromZakPost;
                xlsheet.Cells[КолСтрок + 43 + DavMat * 2, 3] = "Начальник ОД";
                xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 8] = FromZak;
                xlsheet.Cells[КолСтрок + 43 + DavMat * 2, 8] = "Медников А.К.";
            }
            else
            {
                xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3] = FromZakPost;
                xlsheet.get_Range(xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3], xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 6]).Merge(Type.Missing);
                xlsheet.get_Range(xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3], xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 6]).WrapText = true;
                ((Range)xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 3]).RowHeight = 28.5;
                xlsheet.Cells[КолСтрок + 40 + DavMat * 2, 8] = FromZak;
            }
            //((Application)xlapptemplate).Visible = true;  ((Worksheet)xlsheettemplate).get_Range("A1", "A1").Select();
            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(3000);
            //((Application)xlapptemplate).Quit();
            //// Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(workbooks);
            //Marshal.ReleaseComObject(oWorksheets);
            //Marshal.ReleaseComObject(xlsheettemplate);
            //Marshal.ReleaseComObject(xlbooktemplate);
            //Marshal.ReleaseComObject(xlapptemplate);
            //GC.Collect();
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //GC.Collect();
            //return;
            xlapp.WindowState = XlWindowState.xlMaximized;

            // установки печати...


            xlsheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
            xlsheet.PageSetup.TopMargin = 25;
            xlsheet.PageSetup.LeftMargin = 25;
            xlsheet.PageSetup.RightMargin = 12;
            xlsheet.PageSetup.BottomMargin = 25;
            my.cn.Close();
            //((Application)xlapptemplate).Visible = true; ((Worksheet)xlsheettemplate).get_Range("A1", "A1").Select();
            //System.Windows.Forms.Clipboard.Clear();
            //System.Threading.Thread.Sleep(4000);
            ((Application)xlapptemplate).Quit();
            // Уничтожение объекта Excel.
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(oWorksheets);
            Marshal.ReleaseComObject(xlsheettemplate);
            Marshal.ReleaseComObject(xlbooktemplate);
            Marshal.ReleaseComObject(xlapptemplate);
            Marshal.ReleaseComObject(xlsheet);
            Marshal.ReleaseComObject(xlbook);
            Marshal.ReleaseComObject(xlapp);
            workbooks = null;
            oWorksheets = null;
            xlsheettemplate = null;
            xlbooktemplate = null;
            xlapptemplate = null;
            xlsheet = null;
            xlbook = null;
            xlapp = null; KillApp();
            GC.Collect();
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect();

            //if (xlsheettemplate == null) { return; } else { System.Threading.Thread.Sleep(4000); }

        }

        private static void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private static String IspF3(frmF3 pform)
        {
            string Szap = "";
            for (int i = 0; i < pform.DgvActs.Rows.Count; i++)
            {
                Szap = Szap + pform.DgvActs.Rows[i].Cells[0].Value + ",";
            }
            Szap = Szap.Substring(0, Szap.Length - 1);
            return my.Shapka(Szap, my.identpr);
        }

        internal static void StendKompl(DataView dv)
        {
            //try
            //{
            int idsm = 0;
            int zapsm = 0;
            zapsm = 0;
            int inom = 0; int i = 0; int ii = 0;
            int lcol = 0;
            lcol = 75;
            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapp1, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\Стендовый комплекс НИТИ.xlt";
            //Пробуем открыть книгу
            Application xlapp = (Application)xlapp1;
            Workbook WrkBk = (Workbook)workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, workbooks, args);

            Worksheet WrkSht = (Worksheet)WrkBk.Sheets["StComplex"];
            dv.Sort = "NMComplex, NMChapter, OSR, Object,[Лок № сметы],[Инв № сметы]";
            xlapp.WindowState = XlWindowState.xlMaximized;
            xlapp.Visible = true;
            //
            Range rngActive = (Range)WrkSht.Cells[7, 1];
            rngActive.Select();
            i = 0;
            ii = 0;
            WrkSht.get_Range(rngActive.get_Offset(i - 6, 1), rngActive.get_Offset(i - 6, 1)).Font.Bold = true;
            WrkSht.get_Range(rngActive.get_Offset(i - 6, 1), rngActive.get_Offset(i - 6, 1)).Font.Italic = true;
            WrkSht.get_Range(rngActive.get_Offset(i - 6, 1), rngActive.get_Offset(i - 6, 1)).Font.Size = 12;
            rngActive.get_Offset(i - 6, 1).Value2 = System.DateTime.Today;


            string nmcomplex = null;
            string NMChapter = null;
            string OSR = "";
            string Object = null; int iOsr = 0;
            for (int isc = 0; isc < dv.Count; isc++)
            {

                // jane
                if (OSR != "" & OSR != dv[isc]["OSR"].ToString())
                {
                    i = i + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 2)).Font.Bold = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Size = 12;
                    rngActive.get_Offset(i, 1).Value2 = "Итого по " + OSR;
                    for (var i1 = 7; i1 <= lcol; i1++)
                    {
                        rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + (rngActive.get_Offset(iOsr, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + (rngActive.get_Offset(i - 1, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.ColorIndex = 15;
                    }
                    i = i + 2;
                }
                if (nmcomplex != dv[isc]["NMComplex"].ToString()) //Комплекс
                {
                    i = i + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Bold = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Size = 12;
                    rngActive.get_Offset(i, 2).Value2 = dv[isc]["NMComplex"];
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 5)).Merge(Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.Color = Microsoft.VisualBasic.Information.RGB(70, 250, 250);
                    i = i + 1;
                }
                if (NMChapter != dv[isc]["NMChapter"].ToString()) //Глава
                {
                    if (i > 2)
                    {
                        i = i + 1;
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Bold = true;
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Italic = true;
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Size = 12;
                        rngActive.get_Offset(i, 1).Value2 = NMChapter + "                Итого";
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 5)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.Color = Microsoft.VisualBasic.Information.RGB(300, 300, 220);
                        for (var i1 = 7; i1 <= lcol; i1++)
                        {
                            // rngActive.get_Offset(i, i1).Select();
                            rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + rngActive.get_Offset(ii, i1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + rngActive.get_Offset(i - 1, i1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(i, i1).Font.Bold = true;
                        }

                        ii = i;
                        i = i + 1;
                    }
                    i = i + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Bold = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Size = 12;
                    rngActive.get_Offset(i, 2).Value2 = dv[isc]["NMChapter"];
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 5)).Merge(Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.Color = Microsoft.VisualBasic.Information.RGB(200, 228, 180);
                    i = i + 1;
                }
                if (OSR != dv[isc]["OSR"].ToString()) //ОСР
                {



                    i = i + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 2)).Font.Bold = true;
                    rngActive.get_Offset(i, 1).Value2 = dv[isc]["OSR"];
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 2)).Font.Size = 12;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 2)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Size = 12;
                    rngActive.get_Offset(i, 2).Value2 = dv[isc]["NMOSR"];
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 4)).Merge(Type.Missing);
                    rngActive.get_Offset(i + 1, 2).Value2 = "в т.ч.";
                    i = i + 2;
                    iOsr = i;
                }

                if (Object != dv[isc]["Object"].ToString()) //Объект
                {
                    i = i + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Bold = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Italic = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 2)).Font.Size = 12;
                    rngActive.get_Offset(i, 2).Value2 = dv[isc]["Object"];
                    WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i, 3)).Merge(Type.Missing);
                    i = i + 1;
                }
                string uch = null;
                if (idsm == (int)dv[isc]["IdSm"])
                {
                    int imy = 0;
                    WrkSht.get_Range(rngActive.get_Offset(i - 1, 0), rngActive.get_Offset(i, 0)).Merge(Type.Missing);
                    for (imy = 0; imy <= 13; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }
                    for (imy = 29; imy <= 39; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }
                    for (imy = 43; imy <= 44; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }

                }
                else
                {
                    inom = inom + 1;
                    rngActive.get_Offset(i, 0).Value2 = inom;
                    rngActive.get_Offset(i, 3).Value2 = dv[isc]["Инв № сметы"];
                    rngActive.get_Offset(i, 4).Value2 = dv[isc]["Лок № сметы"];
                    rngActive.get_Offset(i, 5).WrapText = true;
                    rngActive.get_Offset(i, 5).Value2 = dv[isc]["NMSmeti"];
                    rngActive.get_Offset(i, 6).Value2 = dv[isc]["osn"];
                    rngActive.get_Offset(i, 6).WrapText = true;
                    rngActive.get_Offset(i, 7).Formula = "=СУММ(" + (rngActive.get_Offset(i, 8)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + (rngActive.get_Offset(i, 11)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 8).Value2 = ((dv[isc]["SumBazOr1"].ToString() == "0") ? "" : dv[isc]["SumBazOr1"]); //Сметная стоимость (в ценах 1984 г. тыс. руб.) СМР
                    rngActive.get_Offset(i, 9).Value2 = ((dv[isc]["BazStObor"].ToString() == "0") ? "" : dv[isc]["BazStObor"]); //Сметная стоимость (в ценах 1984 г. тыс. руб.) Оборудование
                    rngActive.get_Offset(i, 10).Value2 = ((dv[isc]["SumProchz"].ToString() == "0") ? "" : dv[isc]["SumProchz"]); //Сметная стоимость (в ценах 1984 г. тыс. руб.) ПНР
                    rngActive.get_Offset(i, 12).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 13)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 16)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 13).Value2 = ((dv[isc]["Sum91Or1"].ToString() == "0") ? "" : dv[isc]["Sum91Or1"]); //Сметная стоимость (в ценах 1991 г. тыс. руб.) СМР
                    rngActive.get_Offset(i, 14).Value2 = ((dv[isc]["StObor91"].ToString() == "0") ? "" : dv[isc]["StObor91"]); //Сметная стоимость (в ценах 1991 г. тыс. руб.) Оборудование
                    rngActive.get_Offset(i, 15).Value2 = ((dv[isc]["SumProchz91"].ToString() == "0") ? "" : dv[isc]["SumProchz91"]); //Сметная стоимость (в ценах 1991 г. тыс. руб.) ПНР
                    rngActive.get_Offset(i, 32).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 33)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 36)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 33).Value2 = ((dv[isc]["OstVip841"].ToString() == "0") ? "" : dv[isc]["OstVip841"]); //Остаток (в ц. 1984 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) СМР
                    rngActive.get_Offset(i, 35).Value2 = ((dv[isc]["OstVipPr84"].ToString() == "0") ? "" : dv[isc]["OstVipPr84"]); //Остаток (в ц. 1984 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) ПНР

                    rngActive.get_Offset(i, 37).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 38)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 41)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 38).Value2 = ((dv[isc]["OstVip911"].ToString() == "0") ? "" : dv[isc]["OstVip911"]); //Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) СМР
                    rngActive.get_Offset(i, 39).Value2 = ((dv[isc]["OstOb91"].ToString() == "0") ? "" : dv[isc]["OstOb91"]); //Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) Оборудование
                    rngActive.get_Offset(i, 40).Value2 = ((dv[isc]["OstVipPr91"].ToString() == "0") ? "" : dv[isc]["OstVipPr91"]); //Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) ПНР

                    rngActive.get_Offset(i, 44).Value2 = dv[isc]["Dr"];
                    rngActive.get_Offset(i, 48).Value2 = dv[isc]["NdocOUTtxt"];
                    rngActive.get_Offset(i, 48).WrapText = true;
                    rngActive.get_Offset(i, 49).Value2 = dv[isc]["Ngco"];
                    int sdvig = 0;
                    sdvig = 1;
                    //                rngActive.get_Offset(i, 49) = IIf(dv[isc]("SumTekOst08") = 0, "", dv[isc]("SumTekOst08"))
                    rngActive.get_Offset(i, 49 + sdvig).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 50 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 52 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 50 + sdvig).Value2 = ((dv[isc]["SumOst08"].ToString() == "0") ? "" : dv[isc]["SumOst08"]);
                    rngActive.get_Offset(i, 51 + sdvig).Value2 = ((dv[isc]["StOborOst08"].ToString() == "0") ? "" : dv[isc]["StOborOst08"]);
                    rngActive.get_Offset(i, 52 + sdvig).Value2 = ((dv[isc]["SumProchZOst08"].ToString() == "0") ? "" : dv[isc]["SumProchZOst08"]);

                    rngActive.get_Offset(i, 54 + sdvig).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 55 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 57 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 55 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 50 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 23)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); //Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) СМР
                    rngActive.get_Offset(i, 56 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 51 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 24)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); // = rngActive.get_Offset(i, 0).Columns(49).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() & "-" & rngActive.get_Offset(i, 0).Columns(24).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ' IIf(dv[isc]("OstOb91") = 0, "", dv[isc]("OstOb9108")) 'Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) Оборудование
                    rngActive.get_Offset(i, 57 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 52 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 25)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); // = IIf(dv[isc]("OstVipPr91") = 0, "", dv[isc]("OstVipPr91")) 'Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) ПНР

                    rngActive.get_Offset(i, 59 + sdvig).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 60 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 62 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 60 + sdvig).Value2 = ((dv[isc]["Sum2001"].ToString() == "0") ? "" : dv[isc]["Sum2001"]);
                    rngActive.get_Offset(i, 61 + sdvig).Value2 = ((dv[isc]["StObor2001"].ToString() == "0") ? "" : dv[isc]["StObor2001"]);
                    rngActive.get_Offset(i, 62 + sdvig).Value2 = ((dv[isc]["SumProchZ2001"].ToString() == "0") ? "" : dv[isc]["SumProchZ2001"]);

                    //rngActive.get_Offset(i, 70 + sdvig).Select();
                    rngActive.get_Offset(i, 69 + sdvig).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 70 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 72 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, 70 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 60 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 66)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); //Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) СМР
                    rngActive.get_Offset(i, 71 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 61 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 67)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); // = rngActive.get_Offset(i, 0).Columns(49).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() & "-" & rngActive.get_Offset(i, 0).Columns(24).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ' IIf(dv[isc]("OstOb91") = 0, "", dv[isc]("OstOb9108")) 'Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) Оборудование
                    rngActive.get_Offset(i, 72 + sdvig).Formula = "=" + ((Range)rngActive.get_Offset(i, 62 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + ((Range)rngActive.get_Offset(i, 68)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString(); // = IIf(dv[isc]("OstVipPr91") = 0, "", dv[isc]("OstVipPr91")) 'Остаток (в ц. 1991 г. тыс.руб.) СМР'Выполнение (в тек.ц. тыс. руб.) ПНР



                    rngActive.get_Offset(i, 75).Value2 = dv[isc]["InvNomer"];

                }
                rngActive.get_Offset(i, 44).Value2 = ((dv[isc]["Исполнитель"] == "(пусто)") ? " " : dv[isc]["Исполнитель"]) + "  " + dv[isc]["Участок"];
                rngActive.get_Offset(i, 17).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 18)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 21)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, 18).Value2 = ((dv[isc]["Vip84"].ToString() == "0") ? "" : dv[isc]["Vip84"]); //Выполнение на 01.09.2005г.(в ц. 1984 г. тыс. руб.) СМР
                rngActive.get_Offset(i, 20).Value2 = ((dv[isc]["Vip84Pr"].ToString() == "0") ? "" : dv[isc]["Vip84Pr"]); //Выполнение на 01.09.2005г.(в ц. 1984 г. тыс. руб.) ПНР
                rngActive.get_Offset(i, 21).Value2 = ((dv[isc]["ZimUdor84"].ToString() == "0") ? "" : dv[isc]["ZimUdor84"]);

                rngActive.get_Offset(i, 22).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 23)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i, 26)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, 23).Value2 = ((dv[isc]["Vip91"].ToString() == "0") ? "" : dv[isc]["Vip91"]); //Выполнение на 01.09.2005г.(в ц. 1991 г. тыс. руб.) СМР
                rngActive.get_Offset(i, 25).Value2 = ((dv[isc]["Vip91Pr"].ToString() == "0") ? "" : dv[isc]["Vip91Pr"]); //Выполнение на 01.09.2005г.(в ц. 1991 г. тыс. руб.) ПНР
                rngActive.get_Offset(i, 26).Value2 = ((dv[isc]["ZimUdor91"].ToString() == "0") ? "" : dv[isc]["ZimUdor91"]);

                rngActive.get_Offset(i, 27).Formula = "=СУММ(" + ((Range)rngActive.get_Offset(i, 28)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + rngActive.get_Offset(i, 31).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, 28).Value2 = ((dv[isc]["VipTek"].ToString() == "0") ? "" : dv[isc]["VipTek"]); //Выполнение (в тек.ц. тыс. руб.) СМР
                rngActive.get_Offset(i, 30).Value2 = ((dv[isc]["VipTekPr"].ToString() == "0") ? "" : dv[isc]["VipTekPr"]); //Выполнение на 01.09.2005г.(в тек.ц. тыс. руб.) ПНР
                rngActive.get_Offset(i, 31).Value2 = ((dv[isc]["ZimUdor"].ToString() == "0") ? "" : dv[isc]["ZimUdor"]);


                rngActive.get_Offset(i, 65).Formula = "=СУММ(" + rngActive.get_Offset(i, 66).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + rngActive.get_Offset(i, 69).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, 66).Value2 = ((dv[isc]["Vip2001"].ToString() == "0") ? "" : dv[isc]["Vip2001"]); //Выполнение на 01.09.2005г.(в ц. 1991 г. тыс. руб.) СМР
                rngActive.get_Offset(i, 68).Value2 = ((dv[isc]["Vip2001Pr"].ToString() == "0") ? "" : dv[isc]["Vip2001Pr"]); //Выполнение на 01.09.2005г.(в ц. 1991 г. тыс. руб.) ПНР
                rngActive.get_Offset(i, 69).Value2 = ((dv[isc]["ZimUdor2001"].ToString() == "0") ? "" : dv[isc]["ZimUdor91"]);

                rngActive.get_Offset(i, 29).Value2 = ((dv[isc]["OborTek"].ToString() == "0") ? "" : dv[isc]["OborTek"]);
                rngActive.get_Offset(i, 42).Value2 = dv[isc]["NTR"];
                rngActive.get_Offset(i, 43).Value2 = dv[isc]["TR"];
                rngActive.get_Offset(i, 44).WrapText = true;

                rngActive.get_Offset(i, 44).WrapText = true; //Исполнитель
                rngActive.get_Offset(i, 46).Value2 = dv[isc]["OSRTXT"];
                rngActive.get_Offset(i, 47).Value2 = dv[isc]["OSR"];
                rngActive.get_Offset(i, 46).WrapText = true;
                rngActive.get_Offset(i, 47).WrapText = true;

                i = i + 1;
                nmcomplex = dv[isc]["NMComplex"].ToString();
                NMChapter = dv[isc]["NMChapter"].ToString();
                OSR = dv[isc]["OSR"].ToString();
                Object = dv[isc]["Object"].ToString();
                uch = ((dv[isc]["Исполнитель"].ToString() == "(пусто)") ? " " : dv[isc]["Исполнитель"].ToString()) + "  " + dv[isc]["Участок"].ToString(); //dv[isc]("Участок")
                idsm = (int)dv[isc]["IdSm"];
                if (dv[isc]["NMDep"].ToString() != "" & zapsm != idsm)
                {
                    rngActive.get_Offset(i, 44).Value2 = "рассылка: " + dv[isc]["NMDep"];
                    WrkSht.get_Range(rngActive.get_Offset(i - 1, 0), rngActive.get_Offset(i, 0)).Merge(Type.Missing);
                    for (var imy = -2; imy <= 13; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }
                    for (var imy = 29; imy <= 39; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }
                    for (var imy = 43; imy <= 44; imy++)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                    }
                    rngActive.get_Offset(i, 44).WrapText = true;
                    i = i + 1;
                }
                rngActive.get_Offset(i, 44).WrapText = true;
                //rsstr.MoveNext();
                //isc = isc + 1;
                if (isc + 1 < dv.Count)
                {
                    while (uch == ((dv[isc + 1]["Исполнитель"] == "(пусто)") ? " " : dv[isc + 1]["Исполнитель"]) + "  " + dv[isc + 1]["Участок"] & zapsm == (int)dv[isc + 1]["IdSm"])
                    {
                        isc = isc + 1;
                        if (isc + 1 == dv.Count)
                        {
                            break;
                        }
                    }

                    if (idsm == (int)dv[isc + 1]["IdSm"] & uch == ((dv[isc + 1]["Исполнитель"].ToString() == "(пусто)") ? " " : dv[isc + 1]["Исполнитель"].ToString()) + "  " + dv[isc + 1]["Участок"].ToString())
                    {
                        zapsm = idsm;
                        //        i = i + 1
                        while (uch == ((dv[isc + 1]["Исполнитель"].ToString() == "(пусто)") ? " " : dv[isc + 1]["Исполнитель"].ToString()) + "  " + dv[isc + 1]["Участок"].ToString() & idsm == (int)dv[isc + 1]["IdSm"])
                        {
                            i = i + 1;
                            rngActive.get_Offset(i - 1, 44).Value2 = rngActive.get_Offset(i - 1, 44) + ", " + dv[isc + 1]["NMDep"];
                            uch = ((dv[isc + 1]["Исполнитель"].ToString() == "(пусто)") ? " " : dv[isc + 1]["Исполнитель"]) + "  " + dv[isc + 1]["Участок"];
                            isc = isc + 1;
                            if (isc + 1 == dv.Count)
                            {
                                break;
                            }
                        }
                        i = i - 1;
                        WrkSht.get_Range(rngActive.get_Offset(i - 1, 0), rngActive.get_Offset(i, 0)).Merge(Type.Missing);
                        for (var imy = -2; imy <= 13; imy++)
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                        }
                        for (var imy = 29; imy <= 39; imy++)
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                        }
                        for (var imy = 43; imy <= 44; imy++)
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i - 1, 3 + imy), rngActive.get_Offset(i, 3 + imy)).Merge(Type.Missing);
                        }
                        i = i + 1;
                    }
                }
            }
            // jane
            if (OSR != "")
            {
                i = i + 1;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 2)).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Italic = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Size = 12;
                rngActive.get_Offset(i, 1).Value2 = "Итого по " + OSR;
                for (var i1 = 7; i1 <= lcol; i1++) //- 1
                {
                    rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + (rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + (rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i, i1).Font.Bold = true;
                    WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.ColorIndex = 15;
                }
                i = i + 2;
            }
            i = i + 1;
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Bold = true;
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Italic = true;
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Size = 12;
            rngActive.get_Offset(i, 1).Value2 = NMChapter + "                Итого";
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 5)).Merge(Type.Missing);
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.Color = Microsoft.VisualBasic.Information.RGB(300, 300, 220);
            for (var i1 = 7; i1 <= lcol; i1++) //- 1
            {
                //rngActive.get_Offset(i - 1, i1 + 1).Select();
                //System.Windows.Forms.MessageBox.Show((rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString());
                //System.Windows.Forms.MessageBox.Show((rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")");
                rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + (rngActive.get_Offset(ii, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + (rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, i1).Font.Bold = true;
            }
            i = i + 2;

            for (var i1 = 7; i1 <= lcol; i1++) //- 1 'всего
            {
                rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + (rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + (rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                rngActive.get_Offset(i, i1).Font.Bold = true;
            }
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Bold = true;
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Italic = true;
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 1)).Font.Size = 12;
            rngActive.get_Offset(i, 1).Value2 = " ВСЕГО";
            WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, lcol)).Interior.Color = Microsoft.VisualBasic.Information.RGB(70, 250, 250);

            Range rngInput = WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, lcol)); //отметить все и разлиновать
            rngInput.Select();
            rngInput.Borders.LineStyle = XlLineStyle.xlContinuous;
            rngInput.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
            rngInput.VerticalAlignment = Constants.xlCenter;
            //rngInput.AutoFit;
            xlapp.ActiveWindow.Zoom = 75;
            xlapp.ActiveWindow.DisplayZeros = false;
            rngActive.Select();
            //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            //}
            //catch
            //{
            //    goto ex;
            //}
            //ex:
            xlapp = null;
            WrkBk = null;
            WrkSht = null;
            rngActive = null;
            rngInput = null;

        }

        //}
        //}
        //}
        internal static void TPRep(int idplan, frmTemPlan fr)
        {
            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapp1, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\TPRep.xlt";
            //Пробуем открыть книгу
            Application xlapp = (Application)xlapp1;
            object xlbooktemplate = workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, workbooks, args);
            Workbook WrkBk = (Workbook)xlbooktemplate;
            Worksheet WrkSht = (Worksheet)WrkBk.Sheets["Rep"];
            xlapp.Visible = true;
            string s = ""; //DataView dv = new DataView();
            s = my.FilterSel(17, null, my.sconn, "");
            DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
            ds.Clear();
            s = my.FilterSel(17, null, my.sconn, "");
            if (fr.rbplan.Checked)
            {
                s = s + " and idplan  = " + idplan.ToString() + " order by NMComplex, OSR,NomSm";
                da = new SqlDataAdapter(s, my.sconn);
                da.Fill(ds);
            }
            else
            {



                if (fr.rbosr.Checked)
                {
                    s = s + " and idOsr  = " + fr.IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (fr.rb1.Checked ? "2" : "1") + "  and period = '" + fr.Period.SelectedValue.ToString() + "'  order by NMComplex, OSR,NomSm";
                    da = new SqlDataAdapter(s, my.sconn);
                    da.Fill(ds);

                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3," + fr.IdOSR.SelectedValue.ToString(), my.sconn);
                    da.Fill(ds);
                }
                else
                {
                    s = s + " and 1 = 5  ";
                    da = new SqlDataAdapter(s, my.sconn);
                    da.Fill(ds);
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3,0", my.sconn);
                    da.Fill(ds);
                }

            }
            dv.Table = ds.Tables[0];
            dv.Sort = "NMComplex, OSR,NomSm";
            //if (fr.rbplan.Checked)
            //{ s = s + " and idplan  = " + idplan.ToString() + " order by NMComplex, OSR,NomSm"; }
            //else
            //{

            //    SqlDataAdapter da;
            //    DataSet ds = new DataSet();
            //    if (fr.rbosr.Checked)
            //    {
            //        s = s + " and idOsr  = " + fr.IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (fr.rb1.Checked ? "2" : "1") + "  and period = '" + fr.Period.SelectedValue.ToString() + "'  order by NMComplex, OSR,NomSm";
            //        da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3," + fr.IdOSR.SelectedValue.ToString(), my.sconn);
            //        da.Fill(ds);
            //    }
            //    else
            //    {
            //        s = s + " and 1 = 5  ";
            //        da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3,0", my.sconn);
            //        da.Fill(ds);
            //    }
            //    dv.Table = ds.Tables[0];
            //}
            ////

            //my.sc.CommandText = s;
            //my.cn.Open();
            //SqlDataReader dv[irow] = my.sc.ExecuteReader();
            Range rngActive = (Range)WrkSht.Cells[23, 1];
            ((Range)WrkSht.Cells[14, 4]).Value2 = ((Range)WrkSht.Cells[14, 4]).Value2 + fr.Period.Text;
            ((Range)WrkSht.Cells[12, 4]).Value2 = fr.IdEntpr.Text;
            ((Range)WrkSht.Cells[15, 4]).Value2 = fr.NMPlan.Text;
            Range rngActiveNMComplex;
            Range rngActiveOSR;

            string NMComplex = "-1"; string osr = "-1"; int i = -1; int inom = 0; int iOsr = 0; int iComplex = 0; string NomSm = "";
            int ilen = 28;
            for (int irow = 0; irow < dv.Count - 1; irow++)
            {
                ((Range)WrkSht.Cells[17, 4]).Value2 = dv[irow]["NMComplex"].ToString();
                if (osr != dv[irow]["OSR"].ToString() && iOsr != 0)
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    for (int i1 = 6; i1 < ilen; i1++)
                    {
                        if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                        {
                            rngActive.get_Offset(i, i1).Formula = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(i, i1).Font.Bold = true;
                        }
                        else
                        { rngActive.get_Offset(i, i1).Value2 = "/"; }
                    }
                    WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;

                }

                if (NMComplex != dv[irow]["NMComplex"].ToString())
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    if (iComplex != 0)
                    {
                        rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                        rngActive.get_Offset(i, 0).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                        for (int i1 = 6; i1 < ilen; i1++)
                        {
                            if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                            {
                                rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                rngActive.get_Offset(i, i1).Font.Bold = true;
                                rngActive.get_Offset(i, 0).Font.Italic = true;
                            }
                            else
                            { rngActive.get_Offset(i, i1).Value2 = "/"; }
                        }
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                        i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    }
                    NMComplex = dv[irow]["NMComplex"].ToString();

                    rngActive.get_Offset(i, 0).Value2 = NMComplex;
                    rngActive.get_Offset(i, 0).Font.Italic = true;
                    rngActiveNMComplex = rngActive.get_Offset(i, 0);
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    iComplex = i;
                    iOsr = 0;
                }
                if (osr != dv[irow]["OSR"].ToString())
                {

                    osr = dv[irow]["OSR"].ToString();
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    rngActiveOSR = rngActive.get_Offset(i, 0);
                    //i = i + 1; 
                    inom = 1;
                    iOsr = i;
                }

                if (NomSm != dv[irow]["NomSm"].ToString())
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = inom;
                    inom = inom + 1;
                }

                rngActive.get_Offset(i, 1).Value2 = dv[irow]["KodOSR"].ToString();
                rngActive.get_Offset(i, 2).Value2 = dv[irow]["Object"].ToString();
                rngActive.get_Offset(i, 3).Value2 = dv[irow]["KodZak"].ToString();
                rngActive.get_Offset(i, 4).Value2 = dv[irow]["NomSm"].ToString();
                rngActive.get_Offset(i, 5).Value2 = dv[irow]["NMSmeti"].ToString();
                rngActive.get_Offset(i, 6).Value2 = (double)dv[irow]["StSm91"] + (double)dv[irow]["StOb91"];
                rngActive.get_Offset(i, 7).Value2 = dv[irow]["StSm91"].ToString();
                rngActive.get_Offset(i, 8).Value2 = dv[irow]["StOb91"].ToString();
                rngActive.get_Offset(i, 9).Value2 = (double)dv[irow]["PlanBaz"] + (double)dv[irow]["PlanObBaz"];
                rngActive.get_Offset(i, 10).Value2 = "/";
                rngActive.get_Offset(i, 11).Value2 = (double)dv[irow]["PlanTek"] + (double)dv[irow]["PlanObTek"];
                rngActive.get_Offset(i, 12).Value2 = dv[irow]["PlanBaz"].ToString();
                rngActive.get_Offset(i, 13).Value2 = "/";
                rngActive.get_Offset(i, 14).Value2 = dv[irow]["PlanTek"].ToString();
                rngActive.get_Offset(i, 15).Value2 = dv[irow]["PlanObBaz"].ToString();
                rngActive.get_Offset(i, 16).Value2 = "/";
                rngActive.get_Offset(i, 17).Value2 = dv[irow]["PlanObTek"].ToString();
                rngActive.get_Offset(i, 18).Value2 = dv[irow]["i1"].ToString();

                rngActive.get_Offset(i, 19).Value2 = (double)dv[irow]["SMR91"] + (int)dv[irow]["SMROb91"];
                rngActive.get_Offset(i, 20).Value2 = "/";
                rngActive.get_Offset(i, 21).Value2 = (double)dv[irow]["SMRTek"] + (double)dv[irow]["SMROb"];
                rngActive.get_Offset(i, 22).Value2 = dv[irow]["SMR91"].ToString();
                rngActive.get_Offset(i, 23).Value2 = "/";
                rngActive.get_Offset(i, 24).Value2 = dv[irow]["SMRTek"].ToString();
                rngActive.get_Offset(i, 25).Value2 = dv[irow]["SMROb91"].ToString();
                rngActive.get_Offset(i, 26).Value2 = "/";
                rngActive.get_Offset(i, 27).Value2 = dv[irow]["SMROb"].ToString();
                rngActive.get_Offset(i, 28).Value2 = (double)dv[irow]["SMR91"] + (int)dv[irow]["SMROb91"];

                rngActive.get_Offset(i, 29).Value2 = dv[irow]["Isp"].ToString();
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 7)).Font.Size = 8;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 7)).WrapText = true;

                NomSm = dv[irow]["NomSm"].ToString();
                NMComplex = dv[irow]["NMComplex"].ToString();
                osr = dv[irow]["osr"].ToString();
                //i = i + 1;

            }
            if (osr != "-1")
            {

                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                rngActive.get_Offset(i, 0).Font.Italic = true;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Всего: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Всего с НДС: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                double nds = 1.20;
                for (int i1 = 11; i1 < ilen; i1++)
                {
                    if (i1 == 11 || i1 == 14 || i1 == 17 || i1 == 21 || i1 == 24 || i1 == 27)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ") * " + nds.ToString().Replace(".", ",");
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                }
                WrkSht.get_Range(rngActive.get_Offset(0, 16), rngActive.get_Offset(i, ilen + 1)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;

            }
            my.cn.Close();
            WrkBk = null;
            WrkSht = null;
            xlapp = null;
            rngActive = null;
            rngActiveNMComplex = null;
            rngActiveOSR = null;
            KillApp();
            GC.Collect();
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        private static void bord(Worksheet WrkSht, Range rngActive, int i, int ilen, int NumberCol)
        {
            WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, NumberCol - 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
            WrkSht.get_Range(rngActive.get_Offset(i, ilen), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
            WrkSht.get_Range(rngActive.get_Offset(i, NumberCol - 1), rngActive.get_Offset(i, ilen + 1)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            WrkSht.get_Range(rngActive.get_Offset(i, NumberCol - 1), rngActive.get_Offset(i, ilen + 1)).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            for (int i2 = NumberCol; i2 < ilen; i2++)
            {
                i2 = i2 + 2;
                WrkSht.get_Range(rngActive.get_Offset(i, i2), rngActive.get_Offset(i, i2)).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                if (i2 == 17 && NumberCol < 10)
                {
                    i2 = i2 + 1;
                    WrkSht.get_Range(rngActive.get_Offset(i, i2), rngActive.get_Offset(i, i2)).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                }
            }
        }
        public static void TPold(int idplan, Forms.frmTemPlan fr)
        {
            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapp1, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\TP.xlt";
            //Пробуем открыть книгу
            Application xlapp = (Application)xlapp1;
            object xlbooktemplate = workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, workbooks, args);
            //object oWorksheets = xlbooktemplate.GetType().InvokeMember("Plan", BindingFlags.GetProperty, null, xlbooktemplate, null);
            Workbook WrkBk = (Workbook)xlbooktemplate;
            Worksheet WrkSht = (Worksheet)WrkBk.Sheets["Plan"];
            Range rngActiveNMComplex;
            Range rngActiveOSR;
            Range rngActive = (Range)WrkSht.Cells[23, 1];
            //try
            //{
            string s = "";
            xlapp.Visible = true;
            DataView dv = new DataView();
            s = my.FilterSel(17, null, my.sconn, "");
            if (fr.rbplan.Checked)
            { s = s + " and idplan  = " + idplan.ToString() + " order by NMComplex, OSR,NomSm"; }
            else
            {

                SqlDataAdapter da;
                DataSet ds = new DataSet();
                if (fr.rbosr.Checked)
                {
                    s = s + " and idOsr  = " + fr.IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (fr.rb1.Checked ? "2" : "1") + "  and period = '" + fr.Period.SelectedValue.ToString() + "'  order by NMComplex, OSR,NomSm";
                    //s = s + " and idOsr  = " + IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (rb1.Checked ? "2" : "1") + "  and period = '" + Period.SelectedValue.ToString() + "' ";
                    //da.SelectCommand.CommandText = s;
                    //da.Fill(ds);

                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3," + fr.IdOSR.SelectedValue.ToString(), my.sconn);
                    da.Fill(ds);
                }
                else
                {
                    s = s + " and 1 = 5  ";
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3,0", my.sconn);
                    da.Fill(ds);
                }
                dv.Table = ds.Tables[0];
            }

            //{  }

            my.sc.CommandText = s; //my.FilterSel(17, null, my.sconn, " and idplan  = " + idplan.ToString()  + " order by NMComplex, OSR,NomSm");
            my.cn.Open();
            SqlDataReader sd = my.sc.ExecuteReader();

            ((Range)WrkSht.Cells[14, 5]).Value2 = ((Range)WrkSht.Cells[14, 5]).Value2 + fr.Period.Text;
            ((Range)WrkSht.Cells[12, 5]).Value2 = fr.IdEntpr.Text;
            ((Range)WrkSht.Cells[15, 5]).Value2 = fr.NMPlan.Text;


            string NMComplex = "-1"; string osr = "-1"; int i = -1; int inom = 0; int iOsr = 0; int iComplex = 0; string NomSm = "";
            int ilen = 25;
            while (sd.Read())
            {
                ((Range)WrkSht.Cells[17, 4]).Value2 = sd["NMComplex"].ToString();
                if (osr != sd["OSR"].ToString() && iOsr != 0)
                {
                    Nezaversh(osr, dv, rngActive, i);
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16);
                    //WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                    rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    for (int i1 = 6; i1 < ilen; i1++)
                    {
                        if (i1 != 17 && i1 != 20 && i1 != 23)
                        {
                            rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(i, i1).Font.Bold = true;
                        }
                        else
                        { rngActive.get_Offset(i, i1).Value2 = "/"; }
                    }
                    WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;

                }

                if (NMComplex != sd["NMComplex"].ToString())
                {
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    if (iComplex != 0)
                    {
                        rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                        rngActive.get_Offset(i, 0).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                        for (int i1 = 6; i1 < ilen; i1++)
                        {
                            if (i1 != 17 && i1 != 20 && i1 != 23)
                            {
                                rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                rngActive.get_Offset(i, i1).Font.Bold = true;
                                rngActive.get_Offset(i, 0).Font.Italic = true;
                            }
                            else
                            { rngActive.get_Offset(i, i1).Value2 = "/"; }
                        }
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                        i = i + 1;
                        bord(WrkSht, rngActive, i, ilen, 16); ;
                    }
                    NMComplex = sd["NMComplex"].ToString();

                    rngActive.get_Offset(i, 0).Value2 = NMComplex;
                    rngActive.get_Offset(i, 0).Font.Italic = true;
                    rngActiveNMComplex = rngActive.get_Offset(i, 0);
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    iComplex = i;
                    iOsr = 0;
                }
                if (osr != sd["OSR"].ToString())
                {

                    osr = sd["OSR"].ToString();
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    rngActive.get_Offset(i, 0).Value2 = osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    rngActiveOSR = rngActive.get_Offset(i, 0);
                    //i = i + 1; 
                    inom = 1;
                    bord(WrkSht, rngActive, i, ilen, 16); ;
                    iOsr = i;
                }

                if (NomSm != sd["NomSm"].ToString())
                {
                    i = i + 1;
                    bord(WrkSht, rngActive, i, ilen, 16);

                    rngActive.get_Offset(i, 0).Value2 = inom;
                    rngActive.get_Offset(i, 1).Value2 = sd["KodOSR"].ToString();
                    rngActive.get_Offset(i, 2).Value2 = sd["Object"].ToString();
                    rngActive.get_Offset(i, 3).Value2 = sd["KodZak"].ToString();
                    rngActive.get_Offset(i, 4).Value2 = sd["NomSm"].ToString();
                    rngActive.get_Offset(i, 10).Value2 = (double)sd["StSm91"] + (double)sd["StOb91"];
                    rngActive.get_Offset(i, 11).Value2 = (double)sd["StSm91"];
                    rngActive.get_Offset(i, 12).Value2 = (double)sd["StOb91"];
                    rngActive.get_Offset(i, 13).Value2 = (double)sd["Ost91"] + (double)sd["OstOb91"];
                    rngActive.get_Offset(i, 14).Value2 = (double)sd["Ost91"];
                    rngActive.get_Offset(i, 15).Value2 = (double)sd["OstOb91"];
                    rngActive.get_Offset(i, 16).Value2 = (double)sd["PlanBaz"] + (double)sd["PlanObBaz"];
                    rngActive.get_Offset(i, 17).Value2 = "/";
                    rngActive.get_Offset(i, 18).Value2 = (double)sd["PlanTek"] + (double)sd["PlanObTek"];
                    rngActive.get_Offset(i, 19).Value2 = (double)sd["PlanBaz"];
                    rngActive.get_Offset(i, 20).Value2 = "/";
                    rngActive.get_Offset(i, 21).Value2 = (double)sd["PlanTek"];
                    rngActive.get_Offset(i, 22).Value2 = (double)sd["PlanObBaz"];
                    rngActive.get_Offset(i, 23).Value2 = "/";
                    rngActive.get_Offset(i, 24).Value2 = (double)sd["PlanObTek"];
                    rngActive.get_Offset(i, 25).Value2 = (double)sd["i1"];
                    rngActive.get_Offset(i, 26).Value2 = sd["Isp"].ToString();
                    rngActive.get_Offset(i, 5).Value2 = sd["NMSmeti"].ToString();
                    if ((int)sd["CountSm"] > 1)
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i + (int)sd["CountSm"], 0)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i + (int)sd["CountSm"], 1)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 2), rngActive.get_Offset(i + (int)sd["CountSm"], 2)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 3), rngActive.get_Offset(i + (int)sd["CountSm"], 3)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i, 4), rngActive.get_Offset(i + (int)sd["CountSm"], 4)).Merge(Type.Missing);
                    }
                }

                if ((int)sd["CountSm"] > 1) { i = i + 1; bord(WrkSht, rngActive, i, ilen, 16); ; }

                rngActive.get_Offset(i, 5).Value2 = ((int)sd["CountSm"] > 1 ? sd["NMVidWrk"].ToString() : sd["NMSmeti"].ToString());
                rngActive.get_Offset(i, 6).Value2 = sd["NMEdIzm"].ToString();
                rngActive.get_Offset(i, 7).Value2 = (double)sd["VolSm"];
                rngActive.get_Offset(i, 8).Value2 = (double)sd["OstFO"];
                rngActive.get_Offset(i, 9).Value2 = (double)sd["VolEnt"];


                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 6)).Font.Size = 8;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 6)).WrapText = true;

                NomSm = sd["NomSm"].ToString();
                NMComplex = sd["NMComplex"].ToString();
                osr = sd["osr"].ToString();
                inom = inom + 1;
                //i = i + 1;

            }
            if (iOsr != 0)
            {

                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                rngActive.get_Offset(i, 0).Font.Italic = true;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;
                rngActive.get_Offset(i, 0).Value2 = "Всего: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 17 && i1 != 20 && i1 != 23)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1;
                bord(WrkSht, rngActive, i, ilen, 16); ;

                rngActive.get_Offset(i, 0).Value2 = "Всего с НДС: ";
                double nds = 1.20;
                rngActive.get_Offset(i, 0).Font.Bold = true;

                for (int i1 = 17; i1 < ilen; i1++)
                {
                    if (i1 == 18 || i1 == 21 || i1 == 24)
                    {
                        //System.Windows.Forms.MessageBox.Show("=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")*" + nds.ToString().Replace(",","."));
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")*" + nds.ToString().Replace(".", ",");
                        //System.Windows.Forms.MessageBox.Show("2");
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, i1).Font.Italic = true;
                        //System.Windows.Forms.MessageBox.Show("3");
                    }
                }
                //System.Windows.Forms.MessageBox.Show("22");
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 16), rngActive.get_Offset(i, ilen + 1)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
            }
            //i = i + 1;
            //}
            //catch (Exception ex)
            //{

            //     System.Windows.Forms.MessageBox.Show(ex.Message);
            //     if ((int)my.cn.State == 1) { my.cn.Close(); }
            //     //WrkBk = null;
            //     //WrkSht = null;
            //     //xlapp = null;
            //     //rngActive = null;
            //     //rngActiveNMComplex = null;
            //     //rngActiveOSR = null;
            //     KillApp();
            //     GC.Collect();
            //     // Вызываем сборщик мусора для немедленной очистки памяти
            //     GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            //     GC.Collect();
            //}

            my.cn.Close();

            WrkBk = null;
            WrkSht = null;
            xlapp = null;
            rngActive = null;
            rngActiveNMComplex = null;
            rngActiveOSR = null;
            KillApp();
            GC.Collect();
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect();
            //System.Windows.Forms.MessageBox.Show("2");

        }
        internal static void TPRepold(int idplan, frmTemPlan fr)
        {
            string appProgID = "Excel.Application";
            Type excelType = Type.GetTypeFromProgID(appProgID);
            object xlapp1 = Activator.CreateInstance(excelType);
            object workbooks = xlapp1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapp1, null);

            object[] args = new object[1];
            args[0] = "C:\\cis\\Сервис\\TPRep.xlt";
            //Пробуем открыть книгу
            Application xlapp = (Application)xlapp1;
            object xlbooktemplate = workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, workbooks, args);
            Workbook WrkBk = (Workbook)xlbooktemplate;
            Worksheet WrkSht = (Worksheet)WrkBk.Sheets["Rep"];
            xlapp.Visible = true;
            string s = ""; DataView dv = new DataView();
            s = my.FilterSel(17, null, my.sconn, "");
            if (fr.rbplan.Checked)
            { s = s + " and idplan  = " + idplan.ToString() + " order by NMComplex, OSR,NomSm"; }
            else
            {

                SqlDataAdapter da;
                DataSet ds = new DataSet();
                if (fr.rbosr.Checked)
                {
                    s = s + " and idOsr  = " + fr.IdOSR.SelectedValue.ToString() + " and Osnovnoi = 1 and VidPeriod = " + (fr.rb1.Checked ? "2" : "1") + "  and period = '" + fr.Period.SelectedValue.ToString() + "'  order by NMComplex, OSR,NomSm";
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3," + fr.IdOSR.SelectedValue.ToString(), my.sconn);
                    da.Fill(ds);
                }
                else
                {
                    s = s + " and 1 = 5  ";
                    da = new SqlDataAdapter("set language 'русский' exec sNezaversh '" + fr.Period.SelectedValue.ToString() + "','" + (fr.rb1.Checked ? ((DateTime)fr.Period.SelectedValue).AddMonths(3).ToString() : fr.Period.SelectedValue.ToString()) + "',0,3,0", my.sconn);
                    da.Fill(ds);
                }
                dv.Table = ds.Tables[0];
            }
            //

            my.sc.CommandText = s;
            my.cn.Open();
            SqlDataReader sd = my.sc.ExecuteReader();
            Range rngActive = (Range)WrkSht.Cells[23, 1];
            ((Range)WrkSht.Cells[14, 4]).Value2 = ((Range)WrkSht.Cells[14, 4]).Value2 + fr.Period.Text;
            ((Range)WrkSht.Cells[12, 4]).Value2 = fr.IdEntpr.Text;
            ((Range)WrkSht.Cells[15, 4]).Value2 = fr.NMPlan.Text;
            Range rngActiveNMComplex;
            Range rngActiveOSR;

            string NMComplex = "-1"; string osr = "-1"; int i = -1; int inom = 0; int iOsr = 0; int iComplex = 0; string NomSm = "";
            int ilen = 28;
            while (sd.Read())
            {
                ((Range)WrkSht.Cells[17, 4]).Value2 = sd["NMComplex"].ToString();
                if (osr != sd["OSR"].ToString() && iOsr != 0)
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    for (int i1 = 6; i1 < ilen; i1++)
                    {
                        if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                        {
                            rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(i, i1).Font.Bold = true;
                        }
                        else
                        { rngActive.get_Offset(i, i1).Value2 = "/"; }
                    }
                    WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;

                }

                if (NMComplex != sd["NMComplex"].ToString())
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    if (iComplex != 0)
                    {
                        rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                        rngActive.get_Offset(i, 0).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                        for (int i1 = 6; i1 < ilen; i1++)
                        {
                            if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                            {
                                rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                rngActive.get_Offset(i, i1).Font.Bold = true;
                                rngActive.get_Offset(i, 0).Font.Italic = true;
                            }
                            else
                            { rngActive.get_Offset(i, i1).Value2 = "/"; }
                        }
                        WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                        i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    }
                    NMComplex = sd["NMComplex"].ToString();

                    rngActive.get_Offset(i, 0).Value2 = NMComplex;
                    rngActive.get_Offset(i, 0).Font.Italic = true;
                    rngActiveNMComplex = rngActive.get_Offset(i, 0);
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    iComplex = i;
                    iOsr = 0;
                }
                if (osr != sd["OSR"].ToString())
                {

                    osr = sd["OSR"].ToString();
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = osr;
                    rngActive.get_Offset(i, 0).Font.Bold = true;
                    rngActiveOSR = rngActive.get_Offset(i, 0);
                    //i = i + 1; 
                    inom = 1;
                    iOsr = i;
                }

                if (NomSm != sd["NomSm"].ToString())
                {
                    i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                    rngActive.get_Offset(i, 0).Value2 = inom;
                    inom = inom + 1;
                }

                rngActive.get_Offset(i, 1).Value2 = sd["KodOSR"].ToString();
                rngActive.get_Offset(i, 2).Value2 = sd["Object"].ToString();
                rngActive.get_Offset(i, 3).Value2 = sd["KodZak"].ToString();
                rngActive.get_Offset(i, 4).Value2 = sd["NomSm"].ToString();
                rngActive.get_Offset(i, 5).Value2 = sd["NMSmeti"].ToString();
                rngActive.get_Offset(i, 6).Value2 = (double)sd["StSm91"] + (double)sd["StOb91"];
                rngActive.get_Offset(i, 7).Value2 = sd["StSm91"].ToString();
                rngActive.get_Offset(i, 8).Value2 = sd["StOb91"].ToString();
                rngActive.get_Offset(i, 9).Value2 = (double)sd["PlanBaz"] + (double)sd["PlanObBaz"];
                rngActive.get_Offset(i, 10).Value2 = "/";
                rngActive.get_Offset(i, 11).Value2 = (double)sd["PlanTek"] + (double)sd["PlanObTek"];
                rngActive.get_Offset(i, 12).Value2 = sd["PlanBaz"].ToString();
                rngActive.get_Offset(i, 13).Value2 = "/";
                rngActive.get_Offset(i, 14).Value2 = sd["PlanTek"].ToString();
                rngActive.get_Offset(i, 15).Value2 = sd["PlanObBaz"].ToString();
                rngActive.get_Offset(i, 16).Value2 = "/";
                rngActive.get_Offset(i, 17).Value2 = sd["PlanObTek"].ToString();
                rngActive.get_Offset(i, 18).Value2 = sd["i1"].ToString();

                rngActive.get_Offset(i, 19).Value2 = (double)sd["SMR91"] + (int)sd["SMROb91"];
                rngActive.get_Offset(i, 20).Value2 = "/";
                rngActive.get_Offset(i, 21).Value2 = (double)sd["SMRTek"] + (double)sd["SMROb"];
                rngActive.get_Offset(i, 22).Value2 = sd["SMR91"].ToString();
                rngActive.get_Offset(i, 23).Value2 = "/";
                rngActive.get_Offset(i, 24).Value2 = sd["SMRTek"].ToString();
                rngActive.get_Offset(i, 25).Value2 = sd["SMROb91"].ToString();
                rngActive.get_Offset(i, 26).Value2 = "/";
                rngActive.get_Offset(i, 27).Value2 = sd["SMROb"].ToString();
                rngActive.get_Offset(i, 28).Value2 = (double)sd["SMR91"] + (int)sd["SMROb91"];

                rngActive.get_Offset(i, 29).Value2 = sd["Isp"].ToString();
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 7)).Font.Size = 8;
                WrkSht.get_Range(rngActive.get_Offset(i, 1), rngActive.get_Offset(i, 7)).WrapText = true;

                NomSm = sd["NomSm"].ToString();
                NMComplex = sd["NMComplex"].ToString();
                osr = sd["osr"].ToString();
                //i = i + 1;

            }
            if (osr != "-1")
            {

                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + osr;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iOsr, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 15;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Итого по " + NMComplex;
                rngActive.get_Offset(i, 0).Font.Italic = true;
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iComplex, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Всего: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                for (int i1 = 6; i1 < ilen; i1++)
                {
                    if (i1 != 10 && i1 != 13 && i1 != 16 && i1 != 20 && i1 != 23 && i1 != 26)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                    else
                    { rngActive.get_Offset(i, i1).Value2 = "/"; }
                }
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, ilen + 1)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;
                i = i + 1; bord(WrkSht, rngActive, i, ilen, 9);
                rngActive.get_Offset(i, 0).Value2 = "Всего с НДС: ";
                rngActive.get_Offset(i, 0).Font.Bold = true;
                double nds = 1.20;
                for (int i1 = 11; i1 < ilen; i1++)
                {
                    if (i1 == 11 || i1 == 14 || i1 == 17 || i1 == 21 || i1 == 24 || i1 == 27)
                    {
                        rngActive.get_Offset(i, i1).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i - 1, i1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ") * " + nds.ToString().Replace(".", ",");
                        rngActive.get_Offset(i, i1).Font.Bold = true;
                        rngActive.get_Offset(i, 0).Font.Italic = true;
                    }
                }
                WrkSht.get_Range(rngActive.get_Offset(0, 16), rngActive.get_Offset(i, ilen + 1)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(0, 1), rngActive.get_Offset(i, ilen + 1)).WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(i, 0), rngActive.get_Offset(i, ilen + 1)).Interior.ColorIndex = 40;

            }
            my.cn.Close();
            WrkBk = null;
            WrkSht = null;
            xlapp = null;
            rngActive = null;
            rngActiveNMComplex = null;
            rngActiveOSR = null;
            KillApp();
            GC.Collect();
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true); GC.Collect(); GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        public static void GrafikRep(string szap, int idcomplex)
        {
            try
            {

                // return;
                my.cn.Open();
                my.sc.CommandText = szap;
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                ds.Clear();
                da = new SqlDataAdapter(szap, my.sconn);
                da.Fill(ds);
                dv.Table = ds.Tables[0];
                DataView dvclon = new DataView();
                dvclon.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }

                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.NumberFormat = "@";
                WrkSht.Cells.ColumnWidth = 20;
                WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, 1];
                rngActive.get_Offset(0, 0).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Merge(Type.Missing);
                rngActive.get_Offset(0, 0).Value2 = "Сравнение программы Холдинга с данными из Центрального Архива.";
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Select();
                rngActive = rngActive.get_Offset(2, 0);
                rngActive.get_Offset(0, 0).Value2 = "ID работы";
                rngActive.get_Offset(0, 1).Value2 = "Наименование работы";
                rngActive.get_Offset(0, 2).Value2 = "Статус АЭП";
                rngActive.get_Offset(0, 3).Value2 = "Статус раб";
                rngActive.get_Offset(0, 4).Value2 = "Наличие проекта АЭП";
                rngActive.get_Offset(0, 5).Value2 = "Наличие проекта в ЦА";
                int iwrk = 6;
                rngActive.get_Offset(0, iwrk).Value2 = "Наличие смет АЭП";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Наличие смет в ЦА";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Старт ЦП";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Старт раб";

                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Финиш раб";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Финиш ЦП";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Строительная готовность";

                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Наличие оборудования";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Ед.изм. ФО";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "ФО всего";

                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "ФО остаток";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "ФО план";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "См. стоимость баз. всего";

                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "См. стоимость баз. остаток";
                //iwrk = iwrk + 1;
                //rngActive.get_Offset(0, iwrk).Value2 = "См. стоимость баз. план";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "Коэф. перевода в тек.цены";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "См. стоимость тек. всего";
                iwrk = iwrk + 1;
                rngActive.get_Offset(0, iwrk).Value2 = "См. стоимость тек. остаток";
                int lcol = iwrk;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Font.Bold = true;
                rngActive = rngActive.get_Offset(1, 0);
                rngActive.Select();
                string task_code = ""; string Smeta = "";
                int i = 0; int izap = 0;
                for (i = 0; i < dv.Count; i++)
                {
                    if (task_code != dv[i]["task_code"].ToString())
                    {


                        rngActive.get_Offset(izap, 0).Value2 = dv[i]["task_code"].ToString();
                        rngActive.get_Offset(izap, 0).Font.Bold = true;
                        rngActive.get_Offset(izap, 1).Value2 = dv[i]["task_name"].ToString();
                        rngActive.get_Offset(izap, 1).Font.Bold = true;
                        iwrk = 2;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["status_code"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["wrkstatus_code"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_7966"].ToString();
                        iwrk = iwrk + 2;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_6678"].ToString();
                        iwrk = iwrk + 2;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["base_start_date"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["wrkstart_date"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["wrkend_date"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["base_end_date"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_307"].ToString();
                        rngActive.get_Offset(izap, iwrk).Select();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_6680"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_6223"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["wrkuser_field_307"].ToString();
                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["user_field_306"].ToString();

                        iwrk = iwrk + 1;
                        rngActive.get_Offset(izap, iwrk).Value2 = dv[i]["wrkuser_field_306"].ToString();

                        //rngActive.get_Offset(izap, 3).Value2 = dv[i]["user_field_7966"].ToString();

                        //-- Проекты, которых нет в смете
                        string sel = "exec Grafik.dbo.sGrafikPr '1','oneuser_field_7966','" + dv[i]["task_code"].ToString() + "',null," + idcomplex.ToString();
                        SqlDataAdapter da1 = new SqlDataAdapter(sel, my.sconn);
                        DataSet ds1 = new DataSet();
                        ds1.Clear();
                        da1.Fill(ds1);

                        DataView dv1 = new DataView();
                        dv1.Table = ds1.Tables[0];

                        for (int i1 = 0; i1 < dv1.Count; i1++)
                        {
                            dvclon.RowFilter = "";
                            if (dv1[i1]["Проект"].ToString() == "" | dv[i]["task_code"].ToString() == "")
                            {
                                break;
                            }
                            dvclon.RowFilter = "task_code = '" + dv[i]["task_code"].ToString() + "' and proj = '" + dv1[i1]["Проект"].ToString() + "'";
                            if (dvclon.Count == 0)
                            {
                                if (dv1[i1]["bitidArch"].ToString() == "1")
                                {
                                    //rngActive.get_Offset(izap, 7).Select();
                                    rngActive.get_Offset(izap, 7).Value2 = "-";
                                    rngActive.get_Offset(izap, 5).Value2 = dv1[i1]["Проект"].ToString();
                                    rngActive.get_Offset(izap, 5).Interior.ColorIndex = 37;
                                    Smeta = "-";
                                    izap = izap + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        ((Range)rngActive.get_Offset(izap, 0)).Font.ColorIndex = 2;
                    }



                    if (Smeta != dv[i]["Smeta"].ToString())
                    {
                        rngActive.get_Offset(izap, 7).Value2 = dv[i]["Ndoc"].ToString();
                        if (dv[i]["idsm"].ToString() != "")
                        {
                            my.sc.CommandText = "exec Grafik.dbo.sOstPlan " + dv[i]["id"].ToString() + "," + dv[i]["idsm"].ToString() + ",'01.01.1999','" + DateTime.Today.ToShortDateString() + "'";
                            SqlDataReader sd = my.sc.ExecuteReader();
                            sd.Read();
                            int i1 = iwrk + 1;
                            rngActive.get_Offset(i, i1).Value2 = (int)sd["Sum2001"];
                            i1 = i1 + 1;
                            rngActive.get_Offset(i, i1).Value2 = (Double)sd["Ost2001"];

                            //i1 = i1 + 1;
                            //rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlan2001"];
                            i1 = i1 + 1;
                            rngActive.get_Offset(i, i1).Value2 = (Double)sd["KoefPlan"];
                            i1 = i1 + 1;
                            rngActive.get_Offset(i, i1).Value2 = (Double)sd["SumTek"];

                            i1 = i1 + 1;
                            rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstTek"];
                            sd.Close();
                        }
                        //rngActive.get_Offset(izap, 2).Value2 = dv[i]["Smeta"].ToString();
                    }
                    rngActive.get_Offset(izap, 0).Value2 = dv[i]["task_code"].ToString();
                    rngActive.get_Offset(izap, 5).Value2 = dv[i]["proj"].ToString();
                    if (dv[i]["bitproj"].ToString() == "1")
                    {
                        rngActive.get_Offset(izap, 5).Interior.ColorIndex = 37;
                    }

                    task_code = dv[i]["task_code"].ToString();
                    Smeta = dv[i]["Smeta"].ToString();
                    izap = izap + 1;
                }
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(izap, lcol)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(izap, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;
                //WrkSht.get_Range(rngActive.get_Offset(izap, 0), rngActive.get_Offset(izap, 5)).Interior.ColorIndex = 40;
                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    my.cn.Close();
                }

            }

        }

        public static void GrafikPdf(string szap)
        {
            try
            {

                // return;
                my.cn.Open();
                my.sc.CommandText = szap;
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                ds.Clear();
                da = new SqlDataAdapter(szap, my.sconn);
                da.Fill(ds);
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }

                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.NumberFormat = "@";
                WrkSht.Cells.ColumnWidth = 20;
                WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, 1];
                rngActive.get_Offset(0, 0).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Merge(Type.Missing);
                rngActive.get_Offset(0, 0).Value2 = "Наличие файлов pdf к проектам.";
                rngActive = rngActive.get_Offset(2, 0);
                rngActive.get_Offset(0, 0).Value2 = "Проект из графика";
                //rngActive.get_Offset(0, 1).Value2 = "Проект из Архива";
                rngActive.get_Offset(0, 1).Value2 = "Файл Pdf";
                rngActive.get_Offset(0, 2).Value2 = "Проект/Смета";
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Font.Bold = true;
                rngActive = rngActive.get_Offset(1, 0);
                rngActive.Select();
                int i = 0;
                for (i = 0; i < dv.Count; i++)
                {
                    rngActive.get_Offset(i, 0).Value2 = dv[i]["Proj"].ToString();
                    string[] ars1 = System.IO.Directory.GetFiles(@"\\fs\fs\", "*" + dv[i]["Proj"].ToString() + "*", SearchOption.AllDirectories);
                    if (dv[i]["Proj"].ToString() != "")
                    {
                        if (ars1.Count() > 0)
                        {
                            rngActive.get_Offset(i, 1).Value2 = "есть";
                        }
                        else
                        {
                            rngActive.get_Offset(i, 1).Value2 = "нет";
                        }
                    }
                    rngActive.get_Offset(i, 2).Value2 = dv[i]["PrSm"].ToString();
                }
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i, 2)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i, 2)).Borders.LineStyle = XlLineStyle.xlContinuous;




                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    my.cn.Close();
                }

            }

        }
        public static void ReportExGrafik(string idGrafik, int mode,string StrDate,string NMGrafik, int IdEntpr, int IdDep)
        {
            try
            {

                // return;
                my.cn.Open();
                my.sc.CommandTimeout = 3000000;
                my.sc.CommandText = "exec Grafik.dbo.sProjAC " + idGrafik + ",''," + mode.ToString() + ",'" + StrDate + "'," + IdEntpr.ToString() + "," + IdDep.ToString();
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                SqlDataAdapter da5;
                //SqlDataReader rd = my.sc.ExecuteReader();

                ds.Clear();
                da5 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                da5.Fill(ds);
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }

                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.NumberFormat = "@";
                WrkSht.Cells.ColumnWidth = 20;
                WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, 1];
                rngActive.get_Offset(0, 0).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Merge(Type.Missing);
                rngActive.get_Offset(0, 0).Value2 = "Проекты из архива по ЛАЭС-2. " + NMGrafik;
                rngActive = rngActive.get_Offset(2, 0);
                rngActive.get_Offset(0, 0).Value2 = "Id работы";
                //rngActive.get_Offset(0, 1).Value2 = "Проект из Архива";
                rngActive.get_Offset(0, 1).Value2 = "Наименование работы";
                rngActive.get_Offset(0, 2).Value2 = "Проект";
                int sdvig = 1;
                rngActive.get_Offset(0, 3).Value2 = "Название проекта";
                rngActive.get_Offset(0, 3 + sdvig).Value2 = "Название сметы";
                rngActive.get_Offset(0, 4 + sdvig).Value2 = "Тип проекта";
                rngActive.get_Offset(0, 5 + sdvig).Value2 = "Вид работы";
                rngActive.get_Offset(0, 6 + sdvig).Value2 = "Ед.измерения";
                rngActive.get_Offset(0, 7 + sdvig).Value2 = "Объем";
                rngActive.get_Offset(0, 8 + sdvig).Value2 = "Организация исполнитель";
                rngActive.get_Offset(0, 9 + sdvig).Value2 = "Архивный №";
                rngActive.get_Offset(0, 10 + sdvig).Value2 = "Локальный № СД";
                //rngActive.get_Offset(0, 11).Value2 = "Наименование СД";
                rngActive.get_Offset(0, 11 + sdvig).Value2 = "Базовая цена";
                rngActive.get_Offset(0, 12 + sdvig).Value2 = "Выполнено";
                rngActive.get_Offset(0, 13 + sdvig).Value2 = "Остаток КС2";
                rngActive.get_Offset(0, 14 + sdvig).Value2 = "Остаток КС3";
                rngActive.get_Offset(0, 15 + sdvig).Value2 = "Дата заведения карточки";
                rngActive.get_Offset(0, 16 + sdvig).Value2 = (StrDate == "start_date" ? "Старт" : (StrDate == "wrkstart_date" ? "Старт (раб)" : "Старт ЦП"));
                rngActive.get_Offset(0, 17 + sdvig).Value2 = (StrDate == "start_date" ? "Финиш" : (StrDate == "wrkstart_date" ? "Финиш (раб)" : "Финиш ЦП"));
                rngActive.get_Offset(0, 18 + sdvig).Value2 = "Статус работы";
                sdvig = 2;
                rngActive.get_Offset(0, 18 + sdvig).Value2 = "Статус работы (раб)";
                rngActive.get_Offset(0, 19 + sdvig).Value2 = "Старт КТ2";
                rngActive.get_Offset(0, 20 + sdvig).Value2 = "Финиш КТ2";
                rngActive.get_Offset(0, 21 + sdvig).Value2 = "Организация - исполнитель";
                rngActive.get_Offset(0, 22 + sdvig).Value2 = "Фактический - исполнитель";
                rngActive.get_Offset(0, 23 + sdvig).Value2 = "Ответственный ПО";
                rngActive.get_Offset(0, 24 + sdvig).Value2 = "Оборудование";
                rngActive.get_Offset(0, 25 + sdvig).Value2 = "Примечание";
                rngActive.get_Offset(0, 26 + sdvig).Value2 = "Наименование физ. Объема";
                rngActive.get_Offset(0, 27 + sdvig).Value2 = "Ед. изм.";
                rngActive.get_Offset(0, 28 + sdvig).Value2 = "ФО - по ПСД";
                rngActive.get_Offset(0, 29 + sdvig).Value2 = "ФО - план";
                rngActive.get_Offset(0, 30 + sdvig).Value2 = "ФО - факт";
                rngActive.get_Offset(0, 31 + sdvig).Value2 = "ФО - остаток";
                rngActive.get_Offset(0, 32 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddMonths(-1).AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 33 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 34 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 35 + sdvig).Value2 = "Базовая цена 1";
                rngActive.get_Offset(0, 36 + sdvig).Value2 = "Выполнено 1";
                rngActive.get_Offset(0, 37 + sdvig).Value2 = "Остаток КС2 1";
                rngActive.get_Offset(0, 38 + sdvig).Value2 = "Остаток КС3 1";

                int lcol = 38 + sdvig;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Font.Bold = true;
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Select();
                rngActive = rngActive.get_Offset(1, 0);
                //rngActive.Select();
                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; string Ndoc = ""; int izapwrk = -1; string build = ""; int izapbuild = -1; int izapwrkend = -1;
                int[] idsm = new int[3000];
                int idsmind = 0;
                string[] Proc = new string[13];
                Proc[1] = "remain_equip_qtykt2";
                Proc[1] = "remain_equip_qtykt2";
                Proc[2] = "total_equip_qtykt2";
                Proc[3] = "act_equip_qtykt2";
                Proc[4] = "remain_work_qtykt2";
                Proc[5] = "total_work_qtykt2";
                Proc[6] = "target_costkt2";
                Proc[7] = "backt2";
                Proc[8] = "target_equip_costkt2";
                Proc[9] = "remain_costkt2";
                Proc[10] = "total_costkt2";
                Proc[11] = "act_costkt2";
                Proc[12] = "base_equip_costkt2";
                sdvig = 1;
                WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                //if (dv.Count != 0)
                //{
                //    rngActive.get_Offset(i2, 0).Value2 = dv[i]["build"].ToString();
                //    WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Font.Bold = true;
                //    izapbuild = i2;
                //    i2 = i2 + 1;
                //}
                for (i = 0; i < dv.Count; i++)
                {
                    if (idwrk != dv[i]["idWRK"].ToString()) { izapwrkend = i2; }  
                    if (build != dv[i]["build"].ToString())
                    {
                        if (izapbuild != -1 & izapbuild != i2 - 1)
                        {
                            rngActive.get_Offset(izapbuild, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapbuild, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapbuild, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapbuild, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapbuild, 36 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 11 + sdvig).Value2;
                            rngActive.get_Offset(izapbuild, 37 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 12 + sdvig).Value2;
                            rngActive.get_Offset(izapbuild, 38 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 13 + sdvig).Value2;
                            rngActive.get_Offset(izapbuild, 39 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 14 + sdvig).Value2;

                            //WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Select();
                            WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Hidden = true;
                        }
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["build"].ToString();
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Font.Bold = true;
                        izapbuild = i2;
                        izapwrk = -1;
                        i2 = i2 + 1;
                        //WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;

                    }
                    if (idwrk != dv[i]["idWRK"].ToString())
                    {
                        //if (dv[i]["idWRK"].ToString() == "12UGS.E.BJ0.A-1020") System.Windows.Forms.MessageBox.Show("лл");
                        if (izapwrk != -1 & izapwrk != i2 - 1)
                        {
                            rngActive.get_Offset(izapwrk, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapwrkend - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapwrk, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapwrkend - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapwrk, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapwrkend - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapwrk, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapwrkend - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            rngActive.get_Offset(izapwrk, 36 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 11 + sdvig).Value2;
                            rngActive.get_Offset(izapwrk, 37 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 12 + sdvig).Value2;
                            rngActive.get_Offset(izapwrk, 38 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 13 + sdvig).Value2;
                            rngActive.get_Offset(izapwrk, 39 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 14 + sdvig).Value2;

                            WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(izapwrkend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(izapwrkend - 1, lcol)).Rows.Hidden = true;
                        }
                        //rngActive.get_Offset(izapwrk, 11).Select();
                        izapwrk = i2;
                        WrkSht.get_Range(rngActive.get_Offset(i2, 1), rngActive.get_Offset(i2, 10)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 10)).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["idWRK"].ToString();
                        my.sc.CommandText = "select Grafik.[dbo].[Rst2Str](" + dv[i]["idW"].ToString() + ",7)";
                        rngActive.get_Offset(i2, 11).Value2 = my.sc.ExecuteScalar();
                        rngActive.get_Offset(i2, 1).Value2 = dv[i]["NMWRK"].ToString();
                        sdvig = 1;
                        if (dv[i]["start_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 16 + sdvig).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 17 + sdvig).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        rngActive.get_Offset(i2, 18 + sdvig).Value2 = dv[i]["status_codeAEP"].ToString();
                        sdvig = 2;
                        rngActive.get_Offset(i2, 18 + sdvig).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                        if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkstart_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 19 + sdvig).Value2 = ((DateTime)dv[i]["wrkstart_datekt2"]).ToShortDateString();
                        if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkend_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 20 + sdvig).Value2 = ((DateTime)dv[i]["wrkend_datekt2"]).ToShortDateString();
                        rngActive.get_Offset(i2, 21 + sdvig).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                        rngActive.get_Offset(i2, 22 + sdvig).Value2 = dv[i]["user_field_5846kt2"].ToString();
                        rngActive.get_Offset(i2, 23 + sdvig).Value2 = dv[i]["user_field_5847kt2"].ToString();
                        rngActive.get_Offset(i2, 24 + sdvig).Value2 = dv[i]["user_field_201kt2"].ToString();
                        rngActive.get_Offset(i2, 25 + sdvig).Value2 = dv[i]["user_field_6678kt2"].ToString();
                        rngActive.get_Offset(i2, 26 + sdvig).Value2 = dv[i]["user_field_6680kt2"].ToString();
                        rngActive.get_Offset(i2, 27 + sdvig).Value2 = dv[i]["user_field_6223kt2"].ToString();
                        rngActive.get_Offset(i2, 28 + sdvig).Value2 = dv[i]["user_field_308kt2"].ToString();
                        rngActive.get_Offset(i2, 29 + sdvig).Value2 = dv[i]["user_field_307kt2"].ToString();
                        rngActive.get_Offset(i2, 30 + sdvig).Value2 = dv[i]["user_field_309kt2"].ToString();
                        rngActive.get_Offset(i2, 31 + sdvig).Value2 = dv[i]["user_field_306kt2"].ToString();

                        if (DateTime.Today.Month != 1)
                            rngActive.get_Offset(i2, 32 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month - 1]].ToString();
                        else
                            rngActive.get_Offset(i2, 32 + sdvig).Value2 = dv[i][Proc[12]].ToString();
                        rngActive.get_Offset(i2, 33 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month]].ToString();
                        if (DateTime.Today.Month != 12)
                            rngActive.get_Offset(i2, 34 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month + 1]].ToString();
                        else
                            rngActive.get_Offset(i2, 34 + sdvig).Value2 = dv[i][Proc[ 1]].ToString();

                        //--color
                        try
                        {


                            my.sc.CommandText = "exec Grafik.dbo.sProjAC " + idGrafik + ",'" + dv[i]["idWRK"].ToString() + "'," + mode.ToString();
                        DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                        ds1.Clear();
                        da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);

                        da1.Fill(ds1);
                        dv1.Table = ds1.Tables[0];
                        int i5;
                        if (mode != 0)
                        {
                            int status = 0; string ndoc = "";
                            dv1.RowFilter = "IdStatusRab <> 5 and IdstatusRab <> 6";
                            if (dv1.Count != 0 && dv1[0]["NDoc"].ToString() != "")
                            { status = 1; }
                            for (i5 = 0; i5 < dv1.Count; i5++)
                            {
                                ndoc = ndoc + dv1[i5]["NDoc"].ToString();
                            }
                            
                            if (ndoc.Contains("TL") | ndoc.Contains("TA"))
                            { status = 2; }
                            if (status == 0) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 3; }
                            if (status == 1) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 6; }
                            if (status == 2) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35; }
                        }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message + ". Работа " + dv[i]["idWRK"].ToString());
                            
                        }
                        Ndoc = "";
                        i2 = i2 + 1;
                    }
                    //if (build != dv[i]["build"].ToString())
                    //{
                    //    if (izapbuild != -1 & izapbuild != i2 - 1)
                    //    {
                    //        rngActive.get_Offset(izapbuild, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    //        rngActive.get_Offset(izapbuild, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    //        rngActive.get_Offset(izapbuild, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    //        rngActive.get_Offset(izapbuild, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    //        rngActive.get_Offset(izapbuild, 36 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 11 + sdvig).Value2;
                    //        rngActive.get_Offset(izapbuild, 37 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 12 + sdvig).Value2;
                    //        rngActive.get_Offset(izapbuild, 38 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 13 + sdvig).Value2;
                    //        rngActive.get_Offset(izapbuild, 39 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 14 + sdvig).Value2;

                    //        //WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Select();
                    //        WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //        WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Hidden = true;

                    //    }
                    //    rngActive.get_Offset(i2, 0).Value2 = dv[i]["build"].ToString();
                    //    WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Font.Bold = true;
                    //    izapbuild = i2;
                    //    i2 = i2 + 1;
                    //    //WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;

                    //}
                    if (Ndoc != dv[i]["Ndoc"].ToString() & dv[i]["Ndoc"].ToString() != "")
                    {

                        rngActive.get_Offset(i2, 2).Value2 = dv[i]["NDoc"].ToString();
                        rngActive.get_Offset(i2, 3).Value2 = dv[i]["NMDoc"].ToString();
                        if ((int)dv[i]["idStatusRab"] == 6)
                        { WrkSht.get_Range(rngActive.get_Offset(i2, 2), rngActive.get_Offset(i2, 2)).Interior.ColorIndex = 33; }
                        if ((int)dv[i]["idStatusRab"] == 5)
                        { WrkSht.get_Range(rngActive.get_Offset(i2, 2), rngActive.get_Offset(i2, 2)).Interior.ColorIndex = 44; }
                        sdvig = 1;

                        rngActive.get_Offset(i2, 4 + sdvig).Value2 = dv[i]["CodeWrk"].ToString();
                        rngActive.get_Offset(i2, 5 + sdvig).Value2 = dv[i]["NMVidWRK"].ToString();
                        rngActive.get_Offset(i2, 6 + sdvig).Value2 = dv[i]["NMEdIzm"].ToString();
                        rngActive.get_Offset(i2, 7 + sdvig).Value2 = dv[i]["vol"].ToString();
                        rngActive.get_Offset(i2, 8 + sdvig).Value2 = dv[i]["shNMEntpr"].ToString();
                        rngActive.get_Offset(i2, 9 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                        if (dv[i]["DateBeg"] != DBNull.Value) rngActive.get_Offset(i2, 15 + sdvig).Value2 = ((DateTime)dv[i]["DateBeg"]).ToShortDateString();
                        if (dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 16 + sdvig).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 17 + sdvig).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        rngActive.get_Offset(i2, 18 + sdvig).Value2 = dv[i]["status_codeAEP"].ToString();
                        rngActive.get_Offset(i2, 19 + sdvig).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                        sdvig = 2;
                        if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkstart_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 19 + sdvig).Value2 = ((DateTime)dv[i]["wrkstart_datekt2"]).ToShortDateString();
                        if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkend_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 20 + sdvig).Value2 = ((DateTime)dv[i]["wrkend_datekt2"]).ToShortDateString();
                        rngActive.get_Offset(i2, 21 + sdvig).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                        rngActive.get_Offset(i2, 22 + sdvig).Value2 = dv[i]["user_field_5846kt2"].ToString();
                        rngActive.get_Offset(i2, 23 + sdvig).Value2 = dv[i]["user_field_5847kt2"].ToString();

                        rngActive.get_Offset(i2, 29 + sdvig).Value2 = dv[i]["user_field_307kt2"].ToString();

                        i1 = i2;
                        //--smeti
                        my.sc.CommandText = "SELECT  idsm,NMSmeti,   NomerSm,  Sum2001 + SumProchZ2001 as Sum2001, Vip91,Ost2001, Ost91Zak,IdStatus FROM         smr.dbo.vACSm WHERE  IdArch = '" + dv[i]["IdArch"].ToString() + "'";
                        DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                        ds1.Clear();
                        da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                        da1.Fill(ds1);
                        dv1.Table = ds1.Tables[0];
                        sdvig = 1;
                        if (dv1.Count > 0)
                        {
                            int i3 = 0; i4 = i2;

                            for (i3 = 0; i3 < dv1.Count; i3++)
                            {
                                bool issm = false;
                                if ((int)dv1[i3]["IdSm"] != 0)
                                {
                                    for (int i5 = 0; i5 < idsm.Count(); i5++)
                                    {
                                        if (idsm[i5] == 0) { break; }
                                        if (idsm[i5] == (int)dv1[i3]["IdSm"]) { issm = true; }
                                    }
                                    string NMSmeti = dv1[i3]["NMSmeti"].ToString();
                                    rngActive.get_Offset(i4, 10 + sdvig).Value2 = dv1[i3]["NomerSm"].ToString();
                                    //if (NMSmeti.ToLower().Contains("аннулирована"))
                                    //{ WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 35; }
                                    //if (NMSmeti.ToLower().StartsWith("аннулир") | NMSmeti.ToLower().StartsWith("(аннулир") | NMSmeti.ToLower().StartsWith("(отозвана"))
                                    if (dv1[i3]["IdStatus"].ToString() == "2" || dv1[i3]["IdStatus"].ToString() == "4")
                                    { WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 44; }
                                    rngActive.get_Offset(i2, 3 + sdvig).Value2 = NMSmeti;
                                    if (!issm)
                                    {
                                        idsm[idsmind] = (int)dv1[i3]["IdSm"];
                                        idsmind = idsmind + 1;

                                        //rngActive.get_Offset(i4, 11).Value2 = dv1[i3]["NMdoc"].ToString();

                                        rngActive.get_Offset(i2, 11 + sdvig).Value2 = dv1[i3]["Sum2001"].ToString();
                                        rngActive.get_Offset(i2, 12 + sdvig).Value2 = dv1[i3]["Vip91"].ToString();
                                        rngActive.get_Offset(i2, 13 + sdvig).Value2 = dv1[i3]["Ost2001"].ToString();
                                        rngActive.get_Offset(i2, 14 + sdvig).Value2 = dv1[i3]["Ost91Zak"].ToString();
                                        i4 = i4 + 1;
                                    }
                                    else
                                    {
                                        WrkSht.get_Range(rngActive.get_Offset(i4, 11 + sdvig), rngActive.get_Offset(i4, 14 + sdvig)).Interior.ColorIndex = 37;
                                    }
                                }
                            }


                        }
                    }

                    if (Ndoc == dv[i]["Ndoc"].ToString() & dv[i]["Ndoc"].ToString() != "")
                    {
                        i1 = i1 + 1;
                        rngActive.get_Offset(i1, 5 + sdvig).Value2 = dv[i]["NMVidWRK"].ToString();
                        rngActive.get_Offset(i1, 6 + sdvig).Value2 = dv[i]["NMEdIzm"].ToString();
                        rngActive.get_Offset(i1, 7 + sdvig).Value2 = dv[i]["vol"].ToString();
                        rngActive.get_Offset(i1, 8 + sdvig).Value2 = dv[i]["shNMEntpr"].ToString();
                        rngActive.get_Offset(i1, 9 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                        rngActive.get_Offset(i2, 12 + sdvig).Value2 = ((DateTime)dv[i]["DateBeg"]).ToShortDateString();


                    }
                    if (i1 > i4) { i4 = i1; }
                    if (i2 == i4) { i2 = i2 + 1; } else { if (i2 < i4) { i2 = i4; } }
                    //if (i1 > i2) { i2 = i1; }
                    // i2 = i2 + 1; 


                    idwrk = dv[i]["idWRK"].ToString();
                    Ndoc = dv[i]["Ndoc"].ToString();
                    build = dv[i]["Build"].ToString();
                }
                sdvig = 1;
                //WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, 2)).HorizontalAlignment = Constants.xlCenter;
                if (izapwrk != i2 - 1)
                {
                    rngActive.get_Offset(izapwrk, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(izapwrk, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(izapwrk, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(izapwrk, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(izapwrk, 36 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 11 + sdvig).Value2;
                    rngActive.get_Offset(izapwrk, 37 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 12 + sdvig).Value2;
                    rngActive.get_Offset(izapwrk, 38 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 13 + sdvig).Value2;
                    rngActive.get_Offset(izapwrk, 39 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 14 + sdvig).Value2;

                    WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Hidden = true;
                }
                //i2 = i2 + 1;

                    if ( izapbuild != i2 - 1)
                    {
                        rngActive.get_Offset(izapbuild, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(izapbuild, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(izapbuild, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(izapbuild, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapbuild + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        rngActive.get_Offset(izapbuild, 36 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 11 + sdvig).Value2;
                        rngActive.get_Offset(izapbuild, 37 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 12 + sdvig).Value2;
                        rngActive.get_Offset(izapbuild, 38 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 13 + sdvig).Value2;
                        rngActive.get_Offset(izapbuild, 39 + sdvig).Value2 = rngActive.get_Offset(izapbuild, 14 + sdvig).Value2;

                        //WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Select();
                        WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(izapbuild + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Hidden = true;

                    }
                    //rngActive.get_Offset(i2, 0).Value2 = dv[i]["build"].ToString();
                    //WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Font.Bold = true;
                    //izapbuild = i2;
                    //i2 = i2 + 1;
                    //WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;


                {
                    rngActive.get_Offset(i2, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                    rngActive.get_Offset(i2, 36 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 36 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 36 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 37 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 37 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 37 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 38 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 38 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 38 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    rngActive.get_Offset(i2, 39 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 39 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 39 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                }
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;


                WrkSht.get_Range(rngActive.get_Offset(-1, 11 + sdvig), rngActive.get_Offset(i2, 14 + sdvig)).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 36 + sdvig), rngActive.get_Offset(i2, 39 + sdvig)).NumberFormat = "# ##0";

                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    my.cn.Close();
                }

            }

        }
        public static void ReportExGrafikObor(string idGrafik, int mode, string StrDate, string NMGrafik, int IdEntpr, int IdDep)
        {
            try
            {

                // return;
                my.cn.Open();
                my.sc.CommandTimeout = 3000000;
                my.sc.CommandText = "exec Grafik.dbo.sProjAC " + idGrafik + ",''," + mode.ToString() + ",'" + StrDate + "'," + IdEntpr.ToString() + "," + IdDep.ToString();
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                SqlDataAdapter da5;
                //SqlDataReader rd = my.sc.ExecuteReader();

                ds.Clear();
                da5 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                da5.Fill(ds);
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }

                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.NumberFormat = "@";
                WrkSht.Cells.ColumnWidth = 20;
                WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, 1];
                rngActive.get_Offset(0, 0).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Merge(Type.Missing);
                rngActive.get_Offset(0, 0).Value2 = "Проекты из архива по ЛАЭС-2. " + NMGrafik;
                rngActive = rngActive.get_Offset(2, 0);
                rngActive.get_Offset(0, 0).Value2 = "Id работы";
                //rngActive.get_Offset(0, 1).Value2 = "Проект из Архива";
                rngActive.get_Offset(0, 1).Value2 = "Наименование работы";
                //rngActive.get_Offset(0, 2).Value2 = "Проект";
                //int sdvig = 1;
                //rngActive.get_Offset(0, 3).Value2 = "Название проекта";
                //rngActive.get_Offset(0, 3 + sdvig).Value2 = "Название сметы";
                //rngActive.get_Offset(0, 4 + sdvig).Value2 = "Тип проекта";
                //rngActive.get_Offset(0, 5 + sdvig).Value2 = "Вид работы";
                //rngActive.get_Offset(0, 6 + sdvig).Value2 = "Ед.измерения";
                //rngActive.get_Offset(0, 7 + sdvig).Value2 = "Объем";
                //rngActive.get_Offset(0, 8 + sdvig).Value2 = "Организация исполнитель";
                //rngActive.get_Offset(0, 9 + sdvig).Value2 = "Архивный №";
                rngActive.get_Offset(0, 2).Value2 = "Локальный № СД";
                //rngActive.get_Offset(0, 11).Value2 = "Наименование СД";
                //rngActive.get_Offset(0, 11 + sdvig).Value2 = "Базовая цена";
                //rngActive.get_Offset(0, 12 + sdvig).Value2 = "Выполнено";
                //rngActive.get_Offset(0, 13 + sdvig).Value2 = "Остаток КС2";
                //rngActive.get_Offset(0, 14 + sdvig).Value2 = "Остаток КС3";
                //rngActive.get_Offset(0, 15 + sdvig).Value2 = "Дата заведения карточки";
                rngActive.get_Offset(0, 3).Value2 = (StrDate == "start_date" ? "Старт" : (StrDate == "wrkstart_date" ? "Старт (раб)" : "Старт ЦП"));
                rngActive.get_Offset(0, 4).Value2 = (StrDate == "start_date" ? "Финиш" : (StrDate == "wrkstart_date" ? "Финиш (раб)" : "Финиш ЦП"));
                //rngActive.get_Offset(0, 5).Value2 = "Статус работы";
                //sdvig = 2;
                rngActive.get_Offset(0, 5).Value2 = "Статус работы (раб)";
                rngActive.get_Offset(0, 6).Value2 = "Старт КТ2";
                rngActive.get_Offset(0, 7).Value2 = "Финиш КТ2";
                rngActive.get_Offset(0, 8).Value2 = "Организация - исполнитель";
                rngActive.get_Offset(0, 9).Value2 = "Фактический - исполнитель";
                rngActive.get_Offset(0, 10).Value2 = "Проект на оборудование";
                rngActive.get_Offset(0, 11).Value2 = "Наименование оборудования";
                rngActive.get_Offset(0, 12).Value2 = "Ед. изм.";
                rngActive.get_Offset(0, 13).Value2 = "Кол-во";
                rngActive.get_Offset(0, 14).Value2 = "Масса, един.";
                rngActive.get_Offset(0, 15).Value2 = "Высотная отметка";
                rngActive.get_Offset(0, 16).Value2 = "№ сметы ";
                rngActive.get_Offset(0, 17).Value2 = "Дог. факт:";
                rngActive.get_Offset(0, 18).Value2 = "Дата поставки";
                rngActive.get_Offset(0, 19).Value2 = "Акт вх.контроля: ";
                rngActive.get_Offset(0, 20).Value2 = "Дир. срок. Текущий " ;
                rngActive.get_Offset(0, 21).Value2 = "Дир. срок. из годовой СП ";
                rngActive.get_Offset(0, 22).Value2 = "Планируемый срок поставки ";
                rngActive.get_Offset(0, 23).Value2 = "Ответственный поставщик";
                rngActive.get_Offset(0, 24).Value2 = "Гр. поставки: срок. поставки:";
                rngActive.get_Offset(0, 25).Value2 = "Гр. поставки:  срок. начала монтажа ";

                int lcol = 26;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Font.Bold = true;
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Select();
                rngActive = rngActive.get_Offset(1, 0);
                //rngActive.Select();
                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; string Ndoc = ""; int izapwrk = -1;
                int[] idsm = new int[3000];
                int idsmind = 0;
                //string[] Proc = new string[13];
                //Proc[1] = "remain_equip_qtykt2";
                //Proc[1] = "remain_equip_qtykt2";
                //Proc[2] = "total_equip_qtykt2";
                //Proc[3] = "act_equip_qtykt2";
                //Proc[4] = "remain_work_qtykt2";
                //Proc[5] = "total_work_qtykt2";
                //Proc[6] = "target_costkt2";
                //Proc[7] = "backt2";
                //Proc[8] = "target_equip_costkt2";
                //Proc[9] = "remain_costkt2";
                //Proc[10] = "total_costkt2";
                //Proc[11] = "act_costkt2";
                //Proc[12] = "base_equip_costkt2";
            int    sdvig = 1;
                for (i = 0; i < dv.Count; i++)
                {
                    if (idwrk != dv[i]["idWRK"].ToString())
                    {
                        //if (dv[i]["idWRK"].ToString() == "12UGS.E.BJ0.A-1020") System.Windows.Forms.MessageBox.Show("лл");
                        //if (izapwrk != -1 & izapwrk != i2 - 1)
                        //{
                        //    rngActive.get_Offset(izapwrk, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //    rngActive.get_Offset(izapwrk, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //    rngActive.get_Offset(izapwrk, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //    rngActive.get_Offset(izapwrk, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //    rngActive.get_Offset(izapwrk, 36 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 11 + sdvig).Value2;
                        //    rngActive.get_Offset(izapwrk, 37 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 12 + sdvig).Value2;
                        //    rngActive.get_Offset(izapwrk, 38 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 13 + sdvig).Value2;
                        //    rngActive.get_Offset(izapwrk, 39 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 14 + sdvig).Value2;

                        //}
                        //rngActive.get_Offset(izapwrk, 11).Select();
                        izapwrk = i2;
                        //WrkSht.get_Range(rngActive.get_Offset(i2, 1), rngActive.get_Offset(i2, 10)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 10)).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["idWRK"].ToString();
                        if (dv[i]["idWRK"].ToString() =="10UJA.T.JMR.A-2990")
                        {my.sc.CommandText = "select Grafik.[dbo].[Rst2Str](" + dv[i]["idW"].ToString() + ",7)";}
                        my.sc.CommandText = "select Grafik.[dbo].[Rst2Str](" + dv[i]["idW"].ToString() + ",7)";
                        rngActive.get_Offset(i2, 2).Value2 = my.sc.ExecuteScalar();
                        rngActive.get_Offset(i2, 1).Value2 = dv[i]["NMWRK"].ToString();
                        //sdvig = 1;
                        if (dv[i]["start_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 3).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 4).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        //rngActive.get_Offset(i2, 5).Value2 = dv[i]["status_codeAEP"].ToString();
                        //sdvig = 2;
                        rngActive.get_Offset(i2,5).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                        if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkstart_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 6).Value2 = ((DateTime)dv[i]["wrkstart_datekt2"]).ToShortDateString();
                        if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkend_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 7).Value2 = ((DateTime)dv[i]["wrkend_datekt2"]).ToShortDateString();
                        rngActive.get_Offset(i2, 8).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                        rngActive.get_Offset(i2, 9).Value2 = dv[i]["user_field_5846kt2"].ToString();

                        //--color
                        try
                        {


                            my.sc.CommandText = "exec Grafik.dbo.sProjAC " + idGrafik + ",'" + dv[i]["idWRK"].ToString() + "'," + mode.ToString();
                            DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                            ds1.Clear();
                            da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);

                            da1.Fill(ds1);
                            dv1.Table = ds1.Tables[0];
                            int i5;
                            if (mode != 0)
                            {
                                int status = 0; string ndoc = "";
                                dv1.RowFilter = "IdStatusRab <> 5 and IdstatusRab <> 6";
                                if (dv1.Count != 0 && dv1[0]["NDoc"].ToString() != "")
                                { status = 1; }
                                for (i5 = 0; i5 < dv1.Count; i5++)
                                {
                                    ndoc = ndoc + dv1[i5]["NDoc"].ToString();
                                }

                                if (ndoc.Contains("TL") | ndoc.Contains("TA"))
                                { status = 2; }
                                if (status == 0) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 9)).Interior.ColorIndex = 3; }
                                if (status == 1) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 9)).Interior.ColorIndex = 6; }
                                if (status == 2) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 9)).Interior.ColorIndex = 35; }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message + ". Работа " + dv[i]["idWRK"].ToString());

                        }
                        Ndoc = "";
                        i2 = i2 + 1;
                    }

                        ////////////////////obor
                        try
                        {

                            string strSql = @"SELECT       *
FROM            Grafik.dbo.vSvodnaja
where [Код монтажной работы текущий] = '" + dv[i]["idWRK"].ToString() + "'";
                            my.sc.CommandText = strSql;
                            DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                            ds1.Clear();
                            da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);

                            da1.Fill(ds1);
                            dv1.Table = ds1.Tables[0];
                            int i5;

                                
                                for (i5 = 0; i5 < dv1.Count; i5++)
                                {
                                    //i2 = i2 + 1;
                                    rngActive.get_Offset(i2, 10).Value2 = dv1[i5]["№ ИТТ-номер позиции по спецификации ИТТ"].ToString();
                                    rngActive.get_Offset(i2, 11).Value2 = dv1[i5]["Наименование оборудования"].ToString();
                                    rngActive.get_Offset(i2, 12).Value2 = dv1[i5]["Ед# изм#"].ToString();
                                    rngActive.get_Offset(i2, 13).Value2 = dv1[i5]["Кол-во"].ToString();
                                    rngActive.get_Offset(i2, 14).Value2 = dv1[i5]["Масса, един#"].ToString();
                                    rngActive.get_Offset(i2, 15).Value2 = dv1[i5]["Высотная отметка"].ToString();
                                    rngActive.get_Offset(i2, 16).Value2 = dv1[i5]["№ сметы"].ToString();
                                    if (dv1[i5]["Дог# факт::"] != DBNull.Value) rngActive.get_Offset(i2, 17).Value2 = ((DateTime)dv1[i5]["Дог# факт::"]).ToShortDateString();
                                    if (dv1[i5]["Дата поставки"] != DBNull.Value) rngActive.get_Offset(i2, 18).Value2 = ((DateTime)dv1[i5]["Дата поставки"]).ToShortDateString();
                                    rngActive.get_Offset(i2, 19).Value2 = dv1[i5]["Акт вх#контроля:"].ToString();
                                    if (dv1[i5]["Дир# срок# текущий"] != DBNull.Value) rngActive.get_Offset(i2, 20).Value2 = ((DateTime)dv1[i5]["Дир# срок# текущий"]).ToShortDateString();
                                    rngActive.get_Offset(i2, 21).Value2 = dv1[i5]["Дир# срок# из годовой СП"].ToString();
                                    rngActive.get_Offset(i2, 22).Value2 = dv1[i5]["Планируемый срок поставки"].ToString();
                                    rngActive.get_Offset(i2, 23).Value2 = dv1[i5]["Ответственный поставщик"].ToString();
                                    if (dv1[i5]["Гр# поставки: срок# поставки:"] != DBNull.Value) rngActive.get_Offset(i2, 24).Value2 = ((DateTime)dv1[i5]["Гр# поставки: срок# поставки:"]).ToShortDateString();
                                    if (dv1[i5]["Гр# поставки:  срок# начала монтажа"] != DBNull.Value) rngActive.get_Offset(i2, 25).Value2 = ((DateTime)dv1[i5]["Гр# поставки:  срок# начала монтажа"]).ToShortDateString();
                                    i2 = i2 + 1;

                                }


                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message + ". Работа " + dv[i]["idWRK"].ToString());

                        }




                     
                    //if (Ndoc != dv[i]["Ndoc"].ToString() & dv[i]["Ndoc"].ToString() != "")
                    //{

                    //    rngActive.get_Offset(i2, 2).Value2 = dv[i]["NDoc"].ToString();
                    //    rngActive.get_Offset(i2, 3).Value2 = dv[i]["NMDoc"].ToString();
                    //    if ((int)dv[i]["idStatusRab"] == 6)
                    //    { WrkSht.get_Range(rngActive.get_Offset(i2, 2), rngActive.get_Offset(i2, 2)).Interior.ColorIndex = 33; }
                    //    if ((int)dv[i]["idStatusRab"] == 5)
                    //    { WrkSht.get_Range(rngActive.get_Offset(i2, 2), rngActive.get_Offset(i2, 2)).Interior.ColorIndex = 44; }
                    //    sdvig = 1;

                    //    rngActive.get_Offset(i2, 4 + sdvig).Value2 = dv[i]["CodeWrk"].ToString();
                    //    rngActive.get_Offset(i2, 5 + sdvig).Value2 = dv[i]["NMVidWRK"].ToString();
                    //    rngActive.get_Offset(i2, 6 + sdvig).Value2 = dv[i]["NMEdIzm"].ToString();
                    //    rngActive.get_Offset(i2, 7 + sdvig).Value2 = dv[i]["vol"].ToString();
                    //    rngActive.get_Offset(i2, 8 + sdvig).Value2 = dv[i]["shNMEntpr"].ToString();
                    //    rngActive.get_Offset(i2, 9 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                    //    rngActive.get_Offset(i2, 15 + sdvig).Value2 = dv[i]["DateBeg"].ToString();
                    //    rngActive.get_Offset(i2, 16 + sdvig).Value2 = dv[i]["start_date"].ToString();
                    //    rngActive.get_Offset(i2, 17 + sdvig).Value2 = dv[i]["end_date"].ToString();
                    //    rngActive.get_Offset(i2, 18 + sdvig).Value2 = dv[i]["status_codeAEP"].ToString();
                    //    rngActive.get_Offset(i2, 19 + sdvig).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                    //    sdvig = 2;
                    //    if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00") rngActive.get_Offset(i2, 19 + sdvig).Value2 = dv[i]["wrkstart_datekt2"].ToString();
                    //    if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00") rngActive.get_Offset(i2, 20 + sdvig).Value2 = dv[i]["wrkend_datekt2"].ToString();
                    //    rngActive.get_Offset(i2, 21 + sdvig).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                    //    rngActive.get_Offset(i2, 22 + sdvig).Value2 = dv[i]["user_field_5846kt2"].ToString();
                    //    rngActive.get_Offset(i2, 23 + sdvig).Value2 = dv[i]["user_field_5847kt2"].ToString();

                    //    rngActive.get_Offset(i2, 29 + sdvig).Value2 = dv[i]["user_field_307kt2"].ToString();

                    //    i1 = i2;
                    //    //--smeti
                    //    my.sc.CommandText = "SELECT  idsm,NMSmeti,   NomerSm,  Sum2001 + SumProchZ2001 as Sum2001, Vip91,Ost2001, Ost91Zak,IdStatus FROM         smr.dbo.vACSm WHERE  IdArch = '" + dv[i]["IdArch"].ToString() + "'";
                    //    DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                    //    ds1.Clear();
                    //    da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                    //    da1.Fill(ds1);
                    //    dv1.Table = ds1.Tables[0];
                    //    sdvig = 1;
                    //    if (dv1.Count > 0)
                    //    {
                    //        int i3 = 0; i4 = i2;

                    //        for (i3 = 0; i3 < dv1.Count; i3++)
                    //        {
                    //            bool issm = false;
                    //            if ((int)dv1[i3]["IdSm"] != 0)
                    //            {
                    //                for (int i5 = 0; i5 < idsm.Count(); i5++)
                    //                {
                    //                    if (idsm[i5] == 0) { break; }
                    //                    if (idsm[i5] == (int)dv1[i3]["IdSm"]) { issm = true; }
                    //                }
                    //                string NMSmeti = dv1[i3]["NMSmeti"].ToString();
                    //                rngActive.get_Offset(i4, 10 + sdvig).Value2 = dv1[i3]["NomerSm"].ToString();
                    //                //if (NMSmeti.ToLower().Contains("аннулирована"))
                    //                //{ WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 35; }
                    //                //if (NMSmeti.ToLower().StartsWith("аннулир") | NMSmeti.ToLower().StartsWith("(аннулир") | NMSmeti.ToLower().StartsWith("(отозвана"))
                    //                if (dv1[i3]["IdStatus"].ToString() == "2" || dv1[i3]["IdStatus"].ToString() == "4")
                    //                { WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 44; }
                    //                rngActive.get_Offset(i2, 3 + sdvig).Value2 = NMSmeti;
                    //                if (!issm)
                    //                {
                    //                    idsm[idsmind] = (int)dv1[i3]["IdSm"];
                    //                    idsmind = idsmind + 1;

                    //                    //rngActive.get_Offset(i4, 11).Value2 = dv1[i3]["NMdoc"].ToString();

                    //                    rngActive.get_Offset(i2, 11 + sdvig).Value2 = dv1[i3]["Sum2001"].ToString();
                    //                    rngActive.get_Offset(i2, 12 + sdvig).Value2 = dv1[i3]["Vip91"].ToString();
                    //                    rngActive.get_Offset(i2, 13 + sdvig).Value2 = dv1[i3]["Ost2001"].ToString();
                    //                    rngActive.get_Offset(i2, 14 + sdvig).Value2 = dv1[i3]["Ost91Zak"].ToString();
                    //                    i4 = i4 + 1;
                    //                }
                    //                else
                    //                {
                    //                    WrkSht.get_Range(rngActive.get_Offset(i4, 11 + sdvig), rngActive.get_Offset(i4, 14 + sdvig)).Interior.ColorIndex = 37;
                    //                }
                    //            }
                    //        }


                    //    }
                    //}

                    //if (Ndoc == dv[i]["Ndoc"].ToString() & dv[i]["Ndoc"].ToString() != "")
                    //{
                    //    i1 = i1 + 1;
                    //    rngActive.get_Offset(i1, 5 + sdvig).Value2 = dv[i]["NMVidWRK"].ToString();
                    //    rngActive.get_Offset(i1, 6 + sdvig).Value2 = dv[i]["NMEdIzm"].ToString();
                    //    rngActive.get_Offset(i1, 7 + sdvig).Value2 = dv[i]["vol"].ToString();
                    //    rngActive.get_Offset(i1, 8 + sdvig).Value2 = dv[i]["shNMEntpr"].ToString();
                    //    rngActive.get_Offset(i1, 9 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                    //    rngActive.get_Offset(i2, 12 + sdvig).Value2 = dv[i]["DateBeg"].ToString();


                    //}
                    if (i1 > i4) { i4 = i1; }
                    if (i2 == i4) { i2 = i2 + 1; } else { if (i2 < i4) { i2 = i4; } }
                    //if (i1 > i2) { i2 = i1; }
                    // i2 = i2 + 1; 


                    idwrk = dv[i]["idWRK"].ToString();
                    Ndoc = dv[i]["Ndoc"].ToString();
                }
                sdvig = 1;
                //WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, 2)).HorizontalAlignment = Constants.xlCenter;
                //if (izapwrk != i2 - 1)
                //{
                //    rngActive.get_Offset(izapwrk, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(izapwrk, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(izapwrk, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(izapwrk, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(izapwrk, 36 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 11 + sdvig).Value2;
                //    rngActive.get_Offset(izapwrk, 37 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 12 + sdvig).Value2;
                //    rngActive.get_Offset(izapwrk, 38 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 13 + sdvig).Value2;
                //    rngActive.get_Offset(izapwrk, 39 + sdvig).Value2 = rngActive.get_Offset(izapwrk, 14 + sdvig).Value2;
                //}
                ////i2 = i2 + 1;
                //{
                //    rngActive.get_Offset(i2, 11 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 11 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 12 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 12 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 13 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 13 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 14 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 14 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                //    rngActive.get_Offset(i2, 36 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 36 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 36 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 37 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 37 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 37 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 38 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 38 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 38 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                //    rngActive.get_Offset(i2, 39 + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, 39 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, 39 + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                //}
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;


                WrkSht.get_Range(rngActive.get_Offset(-1, 11 + sdvig), rngActive.get_Offset(i2, 14 + sdvig)).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 36 + sdvig), rngActive.get_Offset(i2, 39 + sdvig)).NumberFormat = "# ##0";

                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    my.cn.Close();
                }

            }

        }
        public static void ReportExGrafikActs(string idGrafik, int mode, string szap, int IdEntpr, int IdDep)
        {
            try
            {

                // return;
                my.cn.Open();
                my.sc.CommandTimeout = 3000000;
                my.sc.CommandText = "exec Grafik.dbo.sProjAC " + idGrafik + ",''," + mode.ToString() + ",null," + IdEntpr.ToString() + "," + IdDep.ToString();
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                SqlDataAdapter da5;
                //SqlDataReader rd = my.sc.ExecuteReader();

                ds.Clear();
                da5 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                da5.Fill(ds);
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }

                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.NumberFormat = "@";
                WrkSht.Cells.ColumnWidth = 20;
                //WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[1, 1];
                rngActive.get_Offset(0, 0).Font.Bold = true;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, 5)).Merge(Type.Missing);
                rngActive.get_Offset(0, 0).Value2 = "Проекты из архива по ЛАЭС-2.";
                rngActive = rngActive.get_Offset(2, 0);
                rngActive.get_Offset(0, 0).Value2 = "Id работы";
                //rngActive.get_Offset(0, 1).Value2 = "Проект из Архива";
                rngActive.get_Offset(0, 1).Value2 = "Наименование работы";
                rngActive.get_Offset(0, 2).Value2 = "Инвентарный № сметы";
                int sdvig = 1;
                rngActive.get_Offset(0, 3).Value2 = "Наименование сметы проектное";
                rngActive.get_Offset(0, 3 + sdvig).Value2 = "Наименование сметы в ГЦО";
                rngActive.get_Offset(0, 4 + sdvig).Value2 = "Организация исполнитель по ЦА";
                rngActive.get_Offset(0, 5 + sdvig).Value2 = "Архивный №";
                rngActive.get_Offset(0, 6 + sdvig).Value2 = "Дата заведения карточки";
                rngActive.get_Offset(0, 7 + sdvig).Value2 = "Локальный № СД";
                rngActive.get_Offset(0, 8 + sdvig).Value2 = "№ подсметы";
                rngActive.get_Offset(0, 9 + sdvig).Value2 = "№ акта";
                rngActive.get_Offset(0, 10 + sdvig).Value2 = "Организация - исполнитель";
                //rngActive.get_Offset(0, 11).Value2 = "Наименование СД";
                rngActive.get_Offset(0, 11 + sdvig).Value2 = "Фактический - исполнитель по акту";
                rngActive.get_Offset(0, 12 + sdvig).Value2 = "Статус работы по КС-3";
                rngActive.get_Offset(0, 13 + sdvig).Value2 = "Статус работы по КС-2";
                rngActive.get_Offset(0, 14 + sdvig).Value2 = "Статус работы по ФО(раб)";
                rngActive.get_Offset(0, 15 + sdvig).Value2 = "Старт по графику";
                rngActive.get_Offset(0, 16 + sdvig).Value2 = "Финиш по графику";
                rngActive.get_Offset(0, 17 + sdvig).Value2 = "Старт ФО(раб)";
                rngActive.get_Offset(0, 18 + sdvig).Value2 = "Финиш ФО(раб)";
                sdvig = 2;

                rngActive.get_Offset(0, 18 + sdvig).Value2 = "Ответственный ПО";
                rngActive.get_Offset(0, 19 + sdvig).Value2 = "Примечание";
                rngActive.get_Offset(0, 20 + sdvig).Value2 = "Статус плана";
                rngActive.get_Offset(0, 21 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddMonths(-1).AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 22 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 23 + sdvig).Value2 = "Процент выполнения на " + DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day + 1).ToShortDateString();
                rngActive.get_Offset(0, 24 + sdvig).Value2 = "Базовая цена";
                rngActive.get_Offset(0, 25 + sdvig).Value2 = "Выполнено КС2";
                rngActive.get_Offset(0, 26 + sdvig).Value2 = "Выполнено КС3";
                rngActive.get_Offset(0, 27 + sdvig).Value2 = "Остаток КС2";
                rngActive.get_Offset(0, 28 + sdvig).Value2 = "Остаток КС3";
                rngActive.get_Offset(0, 29 + sdvig).Value2 = "Базовая цена 1";
                rngActive.get_Offset(0, 30 + sdvig).Value2 = "Выполнено КС2 1";
                rngActive.get_Offset(0, 31 + sdvig).Value2 = "Выполнено КС3 1";
                rngActive.get_Offset(0, 32 + sdvig).Value2 = "Остаток КС2 1";
                rngActive.get_Offset(0, 33 + sdvig).Value2 = "Остаток КС3 1";
                rngActive.get_Offset(0, 34 + sdvig).Value2 = "Текущая цена";
                rngActive.get_Offset(0, 35 + sdvig).Value2 = "Текущее выполнение КС2";
                rngActive.get_Offset(0, 36 + sdvig).Value2 = "Текущее выполнение КС3";
                rngActive.get_Offset(0, 37 + sdvig).Value2 = "Текущий остаток КС2";
                rngActive.get_Offset(0, 38 + sdvig).Value2 = "Текущий остаток КС3";

                int lcol = 38 + sdvig;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Font.Bold = true;
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Select();
                rngActive = rngActive.get_Offset(1, 0);
                //rngActive.Select();
                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; int IdSm = 0; int izapwrk = -1; int izapwrkend = -1; int izapsm = -1; int izapsmend = -1; int zIdSmPr = 0; int iIdSmPr = -1;
                int izaposr = -1; int izapch = -1; int izaposrend = -1;
                string NMChapter = ""; string NMOSR = "";
                int[] idsm = new int[3000];
                int idsmind = 0;
                string[] Proc = new string[13];
                Proc[1] = "remain_equip_qtykt2";
                Proc[1] = "remain_equip_qtykt2";
                Proc[2] = "total_equip_qtykt2";
                Proc[3] = "act_equip_qtykt2";
                Proc[4] = "remain_work_qtykt2";
                Proc[5] = "total_work_qtykt2";
                Proc[6] = "target_costkt2";
                Proc[7] = "backt2";
                Proc[8] = "target_equip_costkt2";
                Proc[9] = "remain_costkt2";
                Proc[10] = "total_costkt2";
                Proc[11] = "act_costkt2";
                Proc[12] = "base_equip_costkt2";
                sdvig = 1;
                WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                for (i = 0; i < dv.Count; i++)
                {

                    if (IdSm != (int)dv[i]["IdSm"]) { izapsmend = i2; }
                    if (NMOSR != dv[i]["NMChapter"].ToString()) { izaposrend = i2; }
                    if (idwrk != dv[i]["idWRK"].ToString()) { izapwrkend = i2; }                    
                    if (zIdSmPr != (int)dv[i]["IdSmPr"])
                    {
                        if (zIdSmPr != 0)
                        {
                            rngActive.get_Offset(i2, 2).Value2 = "Итого по блоку смет:";
                            WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).EntireRow.Hidden = true;
                            //j1 = 7;
                            for (int J = 24; J <= lcol; J++)
                            {
                                rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                                //rngActive.get_Offset(i, J).Formula = "=SUBTOTAL(9," + rngActive.get_Offset(iIdSmPr + 1, J).Address + ":" + rngActive.Offset(i - 1, J).Address + ")";
                            }

                            WrkSht.get_Range(rngActive.get_Offset(iIdSmPr, 2), rngActive.get_Offset(i2 - 1, 2)).Interior.ColorIndex = 15;
                            i2 = i2 + 1;

                        }

                        iIdSmPr = i2;
                    }
                    if (NMChapter != dv[i]["NMChapter"].ToString())
                    {
                        sdvig = 2;
                        if (izapch != -1 & izapch != i2 - 1)
                        {
                            for (int izap = 24; izap <= lcol - sdvig; izap++)
                            {
                                rngActive.get_Offset(izapch, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        //WrkSht.Range(rngActive.Offset(n2 + 1, 0), rngActive.Offset(IIf(n1 < n2, i - 1, n1 - 1), lcol)).Rows.Group
                        izapch = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMChapter"].ToString();
                        rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;
                        //NMChapter = "";

                        izapwrkend = i2;
                        NMOSR = "";
                        i2 = i2 + 1;
                    }
                    if (NMOSR != dv[i]["NMOSR"].ToString())
                    {
                        sdvig = 2;
                        if (izaposr != -1 & izaposr != i2 - 1 & izaposr < izaposrend)
                        {
                            for (int izap = 24; izap <= lcol - sdvig; izap++)
                            {
                                rngActive.get_Offset(izaposr, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izaposrend - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).EntireRow.Hidden = true;
                        }
                        izaposr = i2;
                        izaposrend = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMOSR"].ToString();
                        iIdSmPr = i2 + 1;
                        //rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;

                        i2 = i2 + 1;
                    }


                    if (idwrk != dv[i]["idWRK"].ToString())
                    {
                        //if (dv[i]["idWRK"].ToString() == "12UGS.E.BJ0.A-1020") System.Windows.Forms.MessageBox.Show("лл");
                        if (izapwrk != -1 & izapwrk != i2 - 1 & izapwrk < izapwrkend)
                        {
                            sdvig = 2;
                            for (int izap = 24; izap <= lcol - sdvig; izap++)
                            {
                                if (izap < 29 | izap > 33)
                                {
                                    rngActive.get_Offset(izapwrk, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                }
                                else
                                {
                                    rngActive.get_Offset(izapwrk, izap + sdvig).Value2 = rngActive.get_Offset(izapwrk, izap + sdvig - 5).Value2;
                                }
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(izapwrkend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(izapwrkend - 1, lcol)).EntireRow.Hidden = true;
                            WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;

                        }
                        izapwrk = i2;
                        iIdSmPr = i2 + 1;
                        //WrkSht.get_Range(rngActive.get_Offset(i2, 1), rngActive.get_Offset(i2, 10)).Merge(Type.Missing);
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 10)).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["idWRK"].ToString();
                        rngActive.get_Offset(i2, 1).Value2 = dv[i]["NMWRK"].ToString();
                        if ((int)dv[i]["isgr"] == 1)
                        { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35; }
                        sdvig = 1;
                        rngActive.get_Offset(i2, 14 + sdvig).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                        if (dv[i]["start_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 15 + sdvig).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 16 + sdvig).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkstart_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 17 + sdvig).Value2 = ((DateTime)dv[i]["wrkstart_datekt2"]).ToShortDateString();
                        if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkend_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 18 + sdvig).Value2 = ((DateTime)dv[i]["wrkend_datekt2"]).ToShortDateString();

                        sdvig = 2;

                        //rngActive.get_Offset(i2, 21 + sdvig).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                        //rngActive.get_Offset(i2, 22 + sdvig).Value2 = dv[i]["user_field_5846kt2"].ToString();
                        rngActive.get_Offset(i2, 18 + sdvig).Value2 = dv[i]["user_field_5847kt2"].ToString();
                        rngActive.get_Offset(i2, 19 + sdvig).Value2 = dv[i]["user_field_6678kt2"].ToString();
                        //rngActive.get_Offset(i2, 24 + sdvig).Value2 = dv[i]["user_field_201kt2"].ToString();

                        rngActive.get_Offset(i2, 20 + sdvig).Value2 = dv[i]["status_codeAEP"].ToString();
                        rngActive.get_Offset(i2, 21 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month - 1]].ToString();
                        rngActive.get_Offset(i2, 22 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month]].ToString();
                        rngActive.get_Offset(i2, 23 + sdvig).Value2 = dv[i][Proc[DateTime.Today.Month + 1]].ToString();


                        IdSm = 0;
                        i2 = i2 + 1;
                    }

                    if (IdSm != (int)dv[i]["IdSm"])
                    {
                        if (izapsm != -1 & izapsm != izapsmend - 1 & izapsm < izapsmend)
                        {
                            sdvig = 2;
                            for (int izap = 25; izap <= lcol - 4; izap++)
                            {
                                if (izap != 27 & izap != 28 & izap != 34)
                                {
                                    if (izap < 29 | izap > 34)
                                    {
                                        rngActive.get_Offset(izapsm, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapsm + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapsmend - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                    }
                                    else
                                    {
                                        //rngActive.get_Offset(izapsm, izap + sdvig).Value2 = rngActive.get_Offset(izapsm, izap + sdvig - 5).Value2;
                                    }
                                }
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).EntireRow.Hidden = true;

                        }
                        izapsm = i2;

                        rngActive.get_Offset(i2, 2).Value2 = dv[i]["NDoc"].ToString();
                        rngActive.get_Offset(i2, 3).Value2 = dv[i]["NMDoc"].ToString();
                        sdvig = 1;

                        rngActive.get_Offset(i2, 4 + sdvig).Value2 = dv[i]["shNMEntpr"].ToString();
                        rngActive.get_Offset(i2, 5 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                        rngActive.get_Offset(i2, 6 + sdvig).Value2 = dv[i]["DateBeg"].ToString();

                        //sdvig = 1;


                        //rngActive.get_Offset(i2, 5 + sdvig).Value2 = dv[i]["NarchTxt"].ToString();
                        //rngActive.get_Offset(i2, 6 + sdvig).Value2 = dv[i]["DateBeg"].ToString();

                        rngActive.get_Offset(i2, 10 + sdvig).Value2 = dv[i]["actv_code_zvdj4o3o5_d26p9flvo8eu6_3o8uxra_idAEP"].ToString();
                        rngActive.get_Offset(i2, 14 + sdvig).Value2 = dv[i]["wrkstatus_codeKT2"].ToString();
                        if (dv[i]["start_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 15 + sdvig).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"].ToString() != "01.01.1900 0:00:00" & dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 16 + sdvig).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        if (dv[i]["wrkstart_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkstart_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 17 + sdvig).Value2 = ((DateTime)dv[i]["wrkstart_datekt2"]).ToShortDateString();
                        if (dv[i]["wrkend_datekt2"].ToString() != "01.01.1900 0:00:00" & dv[i]["wrkend_datekt2"] != DBNull.Value) rngActive.get_Offset(i2, 18 + sdvig).Value2 = ((DateTime)dv[i]["wrkend_datekt2"]).ToShortDateString();

                        //smeti
                        bool issm = false;
                        for (int i5 = 0; i5 < idsm.Count(); i5++)
                        {
                            if (idsm[i5] == 0) { break; }
                            if (idsm[i5] == (int)dv[i]["IdSm"]) { issm = true; }
                        }
                        string NMSmeti = dv[i]["NMSmeti"].ToString();
                        rngActive.get_Offset(i2, 7 + sdvig).Value2 = dv[i]["NomerSm"].ToString();
                        rngActive.get_Offset(i2, lcol + 1).Value2 = dv[i]["IdSmPr"];
                        //if (zIdSmPr != (int)dv[i]["IdSmPr"] & (int)dv[i]["IdSmPr"] != 0)
                        //{

                        //    iIdSmPr = i2;
                        //}
                        //if (NMSmeti.ToLower().Contains("аннулирована"))
                        //if (dv[i]["IdStatus"].ToString()=="2")
                        //{ WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 35; }
                        bool annulir = false;
                        //if (NMSmeti.ToLower().StartsWith("аннулир") | NMSmeti.ToLower().StartsWith("(аннулир") | NMSmeti.ToLower().StartsWith("(отозвана"))
                        if (dv[i]["IdStatus"].ToString() == "2" || dv[i]["IdStatus"].ToString() == "4")
                        { WrkSht.get_Range(rngActive.get_Offset(i2, 3 + sdvig), rngActive.get_Offset(i2, 3 + sdvig)).Interior.ColorIndex = 44; annulir = true; }
                        rngActive.get_Offset(i2, 3 + sdvig).Value2 = NMSmeti;
                        sdvig = 2;
                        if (!issm)
                        {
                            idsm[idsmind] = (int)dv[i]["IdSm"];
                            idsmind = idsmind + 1;
                            if (!annulir)
                            {
                                sdvig = 1;
                                rngActive.get_Offset(i2, 12 + sdvig).Value2 = dv[i]["Statusks3"].ToString();
                                rngActive.get_Offset(i2, 13 + sdvig).Value2 = dv[i]["Statusks2"].ToString();
                                sdvig = 2;
                                rngActive.get_Offset(i2, 24 + sdvig).Value2 = dv[i]["Sum2001"].ToString();

                                rngActive.get_Offset(i2, 27 + sdvig).Value2 = dv[i]["Ost2001"].ToString();
                                rngActive.get_Offset(i2, 28 + sdvig).Value2 = dv[i]["Ost91Zak"].ToString();

                                rngActive.get_Offset(i2, 34 + sdvig).Value2 = dv[i]["SumTek"].ToString();

                                rngActive.get_Offset(i2, 37 + sdvig).Value2 = dv[i]["OstTek"].ToString();
                                rngActive.get_Offset(i2, 38 + sdvig).Value2 = dv[i]["OstTekZak"].ToString();
                            }

                            //--acts
                            try
                            {

                                my.sc.CommandText = "set language 'русский' exec SOstSmetActs " + szap + ", " + dv[i]["IdSm"].ToString();
                                DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                                ds1.Clear();
                                da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                                da1.Fill(ds1);
                                dv1.Table = ds1.Tables[0];
                                sdvig = 2;


                                for (int i3 = 0; i3 < dv1.Count; i3++)
                                {
                                    i2 = i2 + 1;
                                    rngActive.get_Offset(i2, 8 + sdvig).Value2 = dv1[i3]["KodUnic"].ToString();
                                    rngActive.get_Offset(i2, 10 + sdvig).Value2 = dv1[i3]["ShNmEntpr"].ToString();
                                    rngActive.get_Offset(i2, 25 + sdvig).Value2 = dv1[i3]["Vip91"].ToString();
                                    rngActive.get_Offset(i2, 26 + sdvig).Value2 = dv1[i3]["Vipzak"].ToString();
                                    rngActive.get_Offset(i2, 35 + sdvig).Value2 = dv1[i3]["VipTek"].ToString();
                                    rngActive.get_Offset(i2, 36 + sdvig).Value2 = dv1[i3]["VipTekZak"].ToString();
                                    rngActive.get_Offset(i2, 16 + sdvig).Value2 = dv1[i3]["Period"].ToString();
                                }    
                            }
                            catch (Exception ex)
                            {

                                System.Windows.MessageBox.Show(ex.Message + ". Работа " + dv[i]["idWRK"].ToString());
                            }
                        }
                        else
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i2, 27 + sdvig), rngActive.get_Offset(i2, 38 + sdvig)).Interior.ColorIndex = 37;
                        }

                        i2 = i2 + 1;
                        idwrk = dv[i]["idWRK"].ToString();
                        NMOSR = dv[i]["NMOSR"].ToString();
                        NMChapter = dv[i]["NMChapter"].ToString();
                        IdSm = (int)dv[i]["IdSm"];
                        zIdSmPr = (int)dv[i]["IdSmPr"];
                        //rngActive.Offset(i).EntireRow.Hidden = True
                    }
                }
                //sdvig = 1;
                //WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, 2)).HorizontalAlignment = Constants.xlCenter;
                //if (zIdSmPr != (int)dv[i]["IdSmPr"])
                //{
                //    if (zIdSmPr != 0)
                //    {
                //        rngActive.get_Offset(i2, 2).Value2 = "Итого по блоку смет:";
                //        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).EntireRow.Hidden = true;
                //        //j1 = 7;
                //        for (int J = 24; J <= lcol; J++)
                //        {
                //            rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                //            //rngActive.get_Offset(i, J).Formula = "=SUBTOTAL(9," + rngActive.get_Offset(iIdSmPr + 1, J).Address + ":" + rngActive.Offset(i - 1, J).Address + ")";
                //        }

                //        WrkSht.get_Range(rngActive.get_Offset(iIdSmPr + 1, 2), rngActive.get_Offset(i2 - 1, 2)).Interior.ColorIndex = 15;
                //        i2 = i2 + 1;

                //    }
                //    iIdSmPr = i2;
                //}
                sdvig = 2;
                if (izapch != -1 & izapch != i2 - 1)
                {
                    for (int izap = 24; izap <= lcol - sdvig; izap++)
                    {
                        rngActive.get_Offset(izapch, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }

                if (izaposr != -1 & izaposr != i2 - 1)
                {
                    for (int izap = 24; izap <= lcol - sdvig; izap++)
                    {
                        rngActive.get_Offset(izaposr, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }
                if (izapwrk != i2 - 1)
                {
                    sdvig = 2;
                    for (int izap = 24; izap <= lcol - sdvig; izap++)
                    {

                        rngActive.get_Offset(izapwrk, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapwrk + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapwrk + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }
                if (izapsm != -1 & izapsm != i2 - 1)
                {
                    sdvig = 2;
                    for (int izap = 25; izap <= lcol - 4; izap++)
                    {
                        if (izap != 27 & izap != 28 & izap != 34)
                        {
                            if (izap < 29 | izap > 34)
                            {
                                rngActive.get_Offset(izapsm, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapsm + 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            else
                            {
                                rngActive.get_Offset(izapsm, izap + sdvig).Value2 = rngActive.get_Offset(izapsm, izap + sdvig - 5).Value2;
                            }
                        }
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;

                }
                {
                    sdvig = 2;
                    for (int izap = 24; izap <= lcol - sdvig; izap++)
                    {
                        //if (izap < 29 | izap > 33)
                        //{
                        rngActive.get_Offset(i2, izap + sdvig).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap + sdvig)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //}
                        //else
                        //{
                        //    rngActive.get_Offset(i2, izap + sdvig).Value2 = rngActive.get_Offset(i2, izap + sdvig - 5).Value2;
                        //}
                    }
                }

                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;


                //WrkSht.get_Range(rngActive.get_Offset(-1, 11 + sdvig), rngActive.get_Offset(i2, 14 + sdvig)).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 21 + sdvig), rngActive.get_Offset(i2, lcol)).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 2), rngActive.get_Offset(i2, 19)).WrapText = true;

                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();

            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    my.cn.Close();
                }

            }

        }
        internal static void GrafikTPRep(string szap)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = szap;
                my.sc.CommandTimeout = 30000;
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                ds.Clear();
                da = new SqlDataAdapter(my.sc);
                //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
                da.Fill(ds);
                //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }
                //my.cn.Close();
                int lcol = 33;
                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();
                ExlApp.Visible = true;
                Workbook WrkBk = ExlApp.Workbooks.Open("C:\\cis\\Сервис\\TemPlanRep.xlt", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Worksheet WrkSht = (Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[9, 1];

                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; int IdSm = 0; int izapwrk = -1; int izapwrkend = -1; int izapsm = -1; int izapsmend = -1; int zIdSmPr = 0; int iIdSmPr = -1;
                int izaposr = -1; int izapch = -1; int izaposrend = -1;
                string NMChapter = ""; string NMOSR = "";
                WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                //int sdvig = 0;
                //rngActive.get_Offset(0, 0).Select();
                //int i;
                for (i = 0; i < dv.Count; i++)
                {
                    if (IdSm != (int)dv[i]["IdSm"]) { izapsmend = i2; }
                    if (NMOSR != dv[i]["NMChapter"].ToString()) { izaposrend = i2; }
                    if (idwrk != dv[i]["idWRK"].ToString()) { izapwrkend = i2; }
                    if (NMChapter != dv[i]["NMChapter"].ToString())
                    {

                        if (izapch != -1 & izapch != i2 - 1)
                        {
                            for (int izap = 20; izap <= 31; izap++)
                            {
                                rngActive.get_Offset(izapch, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        //WrkSht.Range(rngActive.Offset(n2 + 1, 0), rngActive.Offset(IIf(n1 < n2, i - 1, n1 - 1), lcol)).Rows.Group
                        izapch = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMChapter"].ToString();
                        rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;
                        //NMChapter = "";

                        izapwrkend = i2;
                        NMOSR = "";
                        i2 = i2 + 1;
                    }
                    if (NMOSR != dv[i]["NMOSR"].ToString())
                    {

                        if (izaposr != -1 & izaposr != i2 - 1 & izaposr < izaposrend)
                        {
                            for (int izap = 20; izap <= 31; izap++)
                            {
                                rngActive.get_Offset(izaposr, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izaposrend - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).EntireRow.Hidden = true;
                        }
                        izaposr = i2;
                        izaposrend = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMOSR"].ToString();
                        //rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;

                        i2 = i2 + 1;
                    }
                    if (IdSm != (int)dv[i]["IdSm"])
                    {
                        i1 = 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Osn"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["NMOSR"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["nDoc"].ToString() + " " + dv[i]["nomerSm"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["NMSmeti"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Sum2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = 0 /*dv[i]["StObor2001"].ToString()*/;
                        i1 = 20;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 3)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 6)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 2;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 3)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 6)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Vip91"].ToString();
                        i1 = i1 + 2;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Oplata"].ToString();


                        if (dv[i]["Result"].ToString() == "нет в факте")
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35;
                        }
                        if (dv[i]["Result"].ToString() == "нет в плане")
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 3;
                        }
                        //  i1 = i1 + 1;
                        // rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        //i1 = i1 + 1;
                        //  rngActive.get_Offset(i2, i1).Value2 = dv[i]["Ost2001"].ToString();
                        //  i1 = i1 + 1;
                        //  rngActive.get_Offset(i2, i1).Value2 = 0 /*dv[i]["StObor2001"].ToString()*/;
                        i2 = i2 + 1;
                    }
                    rngActive.get_Offset(i2, 0).Value2 = dv[i]["idWrk"].ToString();
                    rngActive.get_Offset(i2, 4).Value2 = dv[i]["nmWrk"].ToString();
                    if (dv[i]["Result"].ToString() == "нет в факте")
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35;
                    }
                    if (dv[i]["Result"].ToString() == "нет в плане")
                    {
                        WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 3;
                    }
                    //rngActive.get_Offset(i2, 9).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                    //rngActive.get_Offset(i2, 10).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();

                    //if (dv[i]["wrkstatus_codekt2"].ToString() == "Завершена")
                    //{
                    //    WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35;
                    //}
                    //if (status == 1) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 6; }
                    //if (status == 2) { WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35; }

                    i2 = i2 + 1;
                    idwrk = dv[i]["idWRK"].ToString();
                    NMOSR = dv[i]["NMOSR"].ToString();
                    NMChapter = dv[i]["NMChapter"].ToString();
                    IdSm = (int)dv[i]["IdSm"];
                    zIdSmPr = (int)dv[i]["IdSmPr"];
                }


                if (izapch != -1 & izapch != i2 - 1)
                {
                    for (int izap = 20; izap <= 31; izap++)
                    {
                        rngActive.get_Offset(izapch, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }

                if (izaposr != -1 & izaposr != i2 - 1)
                {
                    for (int izap = 20; izap <= 31; izap++)
                    {
                        rngActive.get_Offset(izaposr, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }
                for (int izap = 20; izap <= 31; izap++)
                {
                    rngActive.get_Offset(-1, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                }
                my.cn.Close();
                WrkSht.get_Range(rngActive.get_Offset(-1, 1), rngActive.get_Offset(i2, lcol)).HorizontalAlignment = Constants.xlCenter;
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(-1, 1), rngActive.get_Offset(i2, lcol)).Cells.WrapText = true;
                //WrkSht.Cells.WrapText = true;
                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    my.cn.Close();
                }

            }

        }
        internal static void GrafikTPNew(string szap, double ind, string d2, string dend, string idgrafik, string StrDate,int IdEntpr, int IdDep )
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = szap+ "," + IdEntpr.ToString() +"," + IdDep.ToString();
                my.sc.CommandTimeout = 300000;
                DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
                ds.Clear();
                da = new SqlDataAdapter(my.sc);
                //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
                da.Fill(ds);
                //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
                dv.Table = ds.Tables[0];
                if (dv.Count == 0) { my.cn.Close(); return; }
                //my.cn.Close();
                int lcol = 58;
                Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();
                ExlApp.Visible = true;
                Workbook WrkBk = ExlApp.Workbooks.Open("C:\\cis\\Сервис\\TemPlan.xlt", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Worksheet WrkSht = (Worksheet)WrkBk.ActiveSheet;
                //WrkSht.Cells.WrapText = true;
                ExlApp.Visible = true;

                Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[7, 1];

                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; int IdSm = 0; int izapwrk = -1; int izapwrkend = -1; int izapsm = -1; int izapsmend = -1; int zIdSmPr = 0; int iIdSmPr = -1;
                int izaposr = -1; int izapch = -1; int izaposrend = -1;
                string NMChapter = ""; string NMOSR = "";
                WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                //string NMIsp = ""; int izapIsp = -1; int izapIspend = 0;
                //int sdvig = 0;
                //rngActive.get_Offset(0, 0).Select();
                //int i;
             
                for (i = 0; i < dv.Count; i++)
                {
                    if (IdSm != (int)dv[i]["IdSm"]) { izapsmend = i2; }
                    if (zIdSmPr != (int)dv[i]["IdSmPr"])
                    {
                        if (zIdSmPr != 0)
                        {
                            SqlCommand sc = new SqlCommand();
                            sc.CommandText = szap.Replace("0,'", zIdSmPr.ToString()+",'");
                            DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                            ds1.Clear();
                            sc.CommandTimeout = 300000;
                            //sconn = "Initial Catalog=smr;User ID=prog;Password=prog;Data Source=tslst;Connect Timeout=30000000;"
                            da1 = new SqlDataAdapter(sc.CommandText, my.sconn);
                            da1.Fill(ds1);
                            dv1.Table = ds1.Tables[0];
                            //sdvig = 2;


                            for (int i3 = 0; i3 < dv1.Count; i3++)
                            {
                                rngActive.get_Offset(i2, 0).Value2 = dv1[i3]["idWrk"].ToString();

                                rngActive.get_Offset(i2, 8).Value2 = dv1[i3]["nmWrk"].ToString();
                                rngActive.get_Offset(i2, 7).Value2 = dv1[i3]["nomerSm"].ToString();
                                if (dv1[i3]["start_date"] != DBNull.Value)  rngActive.get_Offset(i2, 9).Value2 = ((DateTime)dv1[i3]["start_date"]).ToShortDateString();
                                if (dv1[i3]["end_date"] != DBNull.Value)  rngActive.get_Offset(i2, 10).Value2 = ((DateTime)dv1[i3]["end_date"]).ToShortDateString();
                                rngActive.get_Offset(i2, 55).Value2 = dv1[i3]["user_field_5846kt2"].ToString();
                                rngActive.get_Offset(i2, 58).Value2 = dv1[i3]["RegNomer"].ToString();


                                if (dv1[i3]["wrkstatus_codekt2"].ToString() == "Завершена")
                                {
                                    WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 0)).Interior.ColorIndex = 35;
                                }

                                i2 = i2 + 1;
                            }

                            rngActive.get_Offset(i2, 6).Value2 = "Итого по блоку смет:";
                            for (int J = 31; J <= 51; J++)
                            {
                                rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                            }


                            WrkSht.get_Range(rngActive.get_Offset(iIdSmPr, 6), rngActive.get_Offset(i2 - 1, 6)).Interior.ColorIndex = 15;
                            i2 = i2 + 1;

                        }

                        iIdSmPr = i2;
                    }
                    if (NMOSR != dv[i]["NMOSR"].ToString()) { izaposrend = i2; }
                    if (idwrk != dv[i]["idWRK"].ToString()) { izapwrkend = i2; }
                    //if (NMIsp != dv[i]["user_field_5846kt2"].ToString())     { izapIspend = i2; }
                    if (NMChapter != dv[i]["NMChapter"].ToString())
                    {

                        if (izapch != -1 & izapch != i2 - 1)
                        {
                            for (int izap = 31; izap <= 51; izap++)
                            {
                                rngActive.get_Offset(izapch, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        //WrkSht.Range(rngActive.Offset(n2 + 1, 0), rngActive.Offset(IIf(n1 < n2, i - 1, n1 - 1), lcol)).Rows.Group
                        izapch = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMChapter"].ToString();
                        rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;
                        //NMChapter = "";

                        izapwrkend = i2;
                        NMOSR = "";
                        i2 = i2 + 1;
                    }
                    if (NMOSR != dv[i]["NMOSR"].ToString())
                    {

                        if (izaposr != -1 & izaposr != i2 - 1 & izaposr < izaposrend)
                        {
                            for (int izap = 31; izap <= 51; izap++)
                            {
                                rngActive.get_Offset(izaposr, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izaposrend - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).EntireRow.Hidden = true;
                        }
                        izaposr = i2;
                        izaposrend = i2;
                        iIdSmPr = i2 + 1;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMOSR"].ToString();
                        //rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;

                        i2 = i2 + 1;
                    }
                    //if (NMIsp != dv[i]["user_field_5846kt2"].ToString())
                    //{

                    //    if (izapIsp != -1 & izapIsp != i2 - 1 & izapIsp < izapIspend)
                    //    {
                    //        for (int izap = 31; izap <= 51; izap++)
                    //        {
                    //            rngActive.get_Offset(izapIsp, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapIsp + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapIspend - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    //        }
                    //        WrkSht.get_Range(rngActive.get_Offset(izapIsp + 1, 0), rngActive.get_Offset(izapIspend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //        WrkSht.get_Range(rngActive.get_Offset(izapIsp + 1, 0), rngActive.get_Offset(izapIspend - 1, lcol)).EntireRow.Hidden = true;
                    //    }
                    //    izapIsp = i2;
                    //    izapIspend = i2;
                    //    iIdSmPr = i2 + 1;

                    //    rngActive.get_Offset(i2, 0).Value2 = dv[i]["user_field_5846kt2"].ToString();
                    //    //rngActive.get_Offset(i2, 0).Font.Bold = true;
                    //    //rngActive.get_Offset(i2, 0).Font.Italic = true;

                    //    i2 = i2 + 1;
                    //}
                    if (IdSm != (int)dv[i]["IdSm"])
                    {
                        i1 = 5;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Osn"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["ndoc"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["nomerSm"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["NMSmeti"].ToString();
                        i1 = 31;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Sum2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Ost2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 =dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 4)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 4)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        my.sc.CommandText = "exec sProjTPOst " + idgrafik + "," + dv[i]["IdSm"].ToString() + ",'" + d2 + "','" + dend + "','" + StrDate + "'";
                         //my.sc.CommandText =  my.sc.CommandText + " ,isnull(smr.dbo.fOstSmTPNew(vAcSmAll.IdSm, 'Ost91zak', @d2,@dend,@idGrafik,@strDate),0) + isnull(smr.dbo.fOstSmTPNew(vAcSmAll.IdSm, 'OstProch91zak', @d2,@dend,@idGrafik,@strDate),0) as Ost2001TPzak" ;
                        DataView dv2 = new DataView(); DataSet ds2 = new DataSet(); SqlDataAdapter da2;
                        ds2.Clear();
                        my.sc.CommandTimeout = 300000;

                        da2 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                        da2.Fill(ds2);
                        dv2.Table = ds2.Tables[0];
                        rngActive.get_Offset(i2, i1).Value2 = dv2[0]["Ost2001TP"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = (int)((double)dv2[0]["Ost2001TP"]*ind);
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 1)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["Ost2001zak"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 4)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Formula = "=" + ((Range)rngActive.get_Offset(i2, i1 + 2)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "+" + ((Range)rngActive.get_Offset(i2, i1 + 4)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv2[0]["Ost2001TPzak"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = (int)((double)dv2[0]["Ost2001TPzak"] * ind);
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        rngActive.get_Offset(i2, i1).Value2 = dv[i]["StObor2001"].ToString();
                        i1 = i1 + 1;
                        //rngActive.get_Offset(i2, i1).Value2 =(double)ind;
                        rngActive.get_Offset(i2, 55).Value2 = dv[i]["user_field_5846kt2"].ToString();
                        rngActive.get_Offset(i2, 58).Value2 = dv[i]["RegNomer"].ToString();
                        if ((bool)dv[i]["WorkFull"]) 
                        {WrkSht.get_Range(rngActive.get_Offset(i2, 8), rngActive.get_Offset(i2, 8)).Interior.ColorIndex = 6;}
                    }
                    if (dv[i]["IdSmPr"].ToString() == "0")
                    {
                        if (IdSm != (int)dv[i]["IdSm"]) i2 = i2 + 1;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["idWrk"].ToString();

                        rngActive.get_Offset(i2, 8).Value2 = dv[i]["nmWrk"].ToString();
                        rngActive.get_Offset(i2, 7).Value2 = dv[i]["nomerSm"].ToString();
                        if (dv[i]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 9).Value2 = ((DateTime)dv[i]["start_date"]).ToShortDateString();
                        if (dv[i]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 10).Value2 = ((DateTime)dv[i]["end_date"]).ToShortDateString();
                        rngActive.get_Offset(i2, 55).Value2 = dv[i]["user_field_5846kt2"].ToString();
                        rngActive.get_Offset(i2, 58).Value2 = dv[i]["RegNomer"].ToString();


                        if (dv[i]["wrkstatus_codekt2"].ToString() == "Завершена")
                        {
                            WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, 0)).Interior.ColorIndex = 35;
                        }
                    }

                    i2 = i2 + 1;
                    idwrk = dv[i]["idWRK"].ToString();
                    NMOSR = dv[i]["NMOSR"].ToString();
                    NMChapter = dv[i]["NMChapter"].ToString();
                    IdSm = (int)dv[i]["IdSm"];
                    zIdSmPr = (int)dv[i]["IdSmPr"];
                    //NMIsp = dv[i]["user_field_5846kt2"].ToString();
                }
             

                    if (zIdSmPr != 0)
                    {
                        //my.sc.CommandText = szap + "," + zIdSmPr.ToString();
                        //DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                        //ds1.Clear();
                        //da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
                        //da1.Fill(ds1);
                        //dv1.Table = ds1.Tables[0];
                        SqlCommand sc = new SqlCommand();
                        sc.CommandText = szap.Replace("0,'", zIdSmPr.ToString() + ",'");
                        DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
                        ds1.Clear();
                        sc.CommandTimeout = 300000;
                        //sconn = "Initial Catalog=smr;User ID=prog;Password=prog;Data Source=tslst;Connect Timeout=30000000;"
                        da1 = new SqlDataAdapter(sc.CommandText, my.sconn);
                        da1.Fill(ds1);
                        dv1.Table = ds1.Tables[0];



                        for (int i3 = 0; i3 < dv1.Count; i3++)
                        {
                            rngActive.get_Offset(i2, 0).Value2 = dv1[i3]["idWrk"].ToString();

                            rngActive.get_Offset(i2, 8).Value2 = dv1[i3]["nmWrk"].ToString();
                            rngActive.get_Offset(i2, 7).Value2 = dv1[i3]["nomerSm"].ToString();
                            if (dv1[i3]["start_date"] != DBNull.Value) rngActive.get_Offset(i2, 9).Value2 = ((DateTime)dv1[i3]["start_date"]).ToShortDateString();
                            if (dv1[i3]["end_date"] != DBNull.Value) rngActive.get_Offset(i2, 10).Value2 = ((DateTime)dv1[i3]["end_date"]).ToShortDateString();
   
                            rngActive.get_Offset(i2, 55).Value2 = dv1[i3]["user_field_5846kt2"].ToString();
                            rngActive.get_Offset(i2, 58).Value2 = dv1[i3]["RegNomer"].ToString();


                            if (dv1[i3]["wrkstatus_codekt2"].ToString() == "Завершена")
                            {
                                WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).Interior.ColorIndex = 35;
                            }

                            i2 = i2 + 1;
                        }

                        rngActive.get_Offset(i2, 6).Value2 = "Итого по блоку смет:";
                        for (int J = 31; J <= 51; J++)
                        {
                            rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                        }


                        WrkSht.get_Range(rngActive.get_Offset(iIdSmPr, 6), rngActive.get_Offset(i2 - 1, 6)).Interior.ColorIndex = 15;
                        i2 = i2 + 1;

                    }

                    iIdSmPr = i2;

                if (izapch != -1 & izapch != i2 - 1)
                {
                    for (int izap = 31; izap <= 52; izap++)
                    {
                        rngActive.get_Offset(izapch, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }

                if (izaposr != -1 & izaposr != i2 - 1)
                {   
                    for (int izap = 31; izap <= 51; izap++)
                    {
                        rngActive.get_Offset(izaposr, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }
                for (int izap = 31; izap <= 51; izap++)
                {
                    rngActive.get_Offset(-1, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                }
                my.cn.Close();
                WrkSht.get_Range(rngActive.get_Offset(-1, 1), rngActive.get_Offset(i2, 4)).HorizontalAlignment = Constants.xlCenter;
                
                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;
                WrkSht.get_Range(rngActive.get_Offset(-1, 1), rngActive.get_Offset(i2, lcol)).Cells.WrapText = true;
                WrkSht.get_Range(rngActive.get_Offset(-2, 0), rngActive.get_Offset(i2, lcol)).AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);
                WrkSht.get_Range(rngActive.get_Offset(-1, 11), rngActive.get_Offset(i2, 54)).NumberFormat = "# ##0";
               


                PivotCache pivotCache = WrkBk.PivotCaches().Add(XlPivotTableSourceType.xlDatabase, ((Range)rngActive.get_Offset(-2, 0)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2, lcol)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString());
                Worksheet WrkSht2 = (Worksheet)WrkBk.Sheets[2];   
                PivotTables pivotTables = (PivotTables)WrkSht2.PivotTables(Missing.Value);
                PivotTable pivotTable = pivotTables.Add(pivotCache, (Microsoft.Office.Interop.Excel.Range)WrkSht2.Cells[1, 1], "PivotTable1", Missing.Value, Missing.Value);
                WrkSht2.Activate();
               //pivotTable.SmallGrid = false;
                        pivotTable.TableStyle = "PivotStyleLight1";

                //adding page field
                        //PivotField pageField = (PivotField)pivotTable.PivotFields("ParentName");
                        //pageField.Orientation = XlPivotFieldOrientation.xlPageField;

                //adding row field
                        PivotField rowField = (PivotField)pivotTable.PivotFields("33");
                        rowField.Caption = "Исполнитель";
                       rowField.Orientation = XlPivotFieldOrientation.xlRowField;

                //adding data field

                       PivotField dataField = pivotTable.AddDataField(pivotTable.PivotFields("16"), "Сметная стоимость  в базисной цене", XlConsolidationFunction.xlSum);
                       dataField.NumberFormat = "# ##0";
                       dataField = pivotTable.AddDataField(pivotTable.PivotFields("19"), "Ожидаемый остаток сметной стоимости", XlConsolidationFunction.xlSum);
                       dataField.NumberFormat = "# ##0";
                       dataField = pivotTable.AddDataField(pivotTable.PivotFields("22"), "Принятый план освоения КВЛ", XlConsolidationFunction.xlSum);
                       dataField.NumberFormat = "# ##0";
                        pivotTable.DataPivotField.Orientation = XlPivotFieldOrientation.xlColumnField;

                    //With ActiveSheet.PivotTables("PivotTable1").PivotFields("Исполнитель")
      ((PivotItem) rowField.PivotItems("(blank)")).Visible = false;
    //End With
   //((Range)WrkSht2.Columns[0,1]).Select();
    //Selection.NumberFormat = "#,##0";
                //WrkSht.Cells[6, 1]
   //WrkSht2.get_Range(rngActive.get_Offset(-1, 11), rngActive.get_Offset(i2, 54)).NumberFormat = "# ##0";

                WrkSht.Activate();
                //WrkSht.Activate();
                //pivotCache.CreatePivotTable(
                ////PivotCaches pCaches = WrkBk.PivotCaches();
                ////PivotCache pCache = pCaches.Add(..Create(XlPivotTableSourceType.xlDatabase, "Sheet1!A1:B7", XlPivotTableVersionList.xlPivotTableVersion2000);
                //Console.ReadLine();
                /*
                 *   Excel.Workbook book = this.Application.ActiveWorkbook ;
      Excel.Worksheet sheet= book.Worksheets [1] as Excel.Worksheet ;
      Excel.PivotCaches pCaches= book.PivotCaches ();
      Excel.PivotCache pCache = pCaches.Create(Excel.XlPivotTableSourceType.xlDatabase, "Sheet1!A1:B7", Excel.XlPivotTableVersionList.xlPivotTableVersion14 );
      Excel.Range rngDes = sheet.get_Range("C1");
      Excel.PivotTable pTable = pCache.CreatePivotTable(TableDestination: rngDes , TableName: "PivotTable1", DefaultVersion: Excel.XlPivotTableVersionList.xlPivotTableVersion14);
      Excel.PivotField fieldQ = pTable.PivotFields("Question");
      Excel.PivotField fieldA = pTable.PivotFields("Answer");

      fieldQ.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
      fieldQ.Position = 1;
      fieldA.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
      fieldA.Position = 2
                 */

                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
            }
            catch (Exception ex)
            {
                if (my.cn.State == ConnectionState.Open)
                {
                    
                    my.cn.Close();
                }
System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        internal static void GrafikTP(string szap, DateTime d1, DateTime d2)
        {
            my.cn.Open();
            my.sc.CommandText = szap;
            my.sc.CommandTimeout = 30000;
            DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
            ds.Clear();
            da = new SqlDataAdapter(my.sc);
            //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
            da.Fill(ds);
            //Console.WriteLine("1  " + DateTime.Now.TimeOfDay.ToString());
            dv.Table = ds.Tables[0];
            if (dv.Count == 0) { my.cn.Close(); return; }
            //my.cn.Close();
            int lcol = 48;
            Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();
            ExlApp.Visible = true;
            Workbook WrkBk = ExlApp.Workbooks.Open("C:\\cis\\Сервис\\TemPlan.xlt", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Worksheet WrkSht = (Worksheet)WrkBk.ActiveSheet;
            WrkSht.Cells.WrapText = true;
            ExlApp.Visible = true;

            Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[6, 1];
            //rngActive.get_Offset(0, 0).Select();
            int i;
            for (i = 0; i < dv.Count; i++)
            {
                int i1 = 0;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["task_code"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["shifr"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["PunktTiTulStr"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["OSR"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["NMObject"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["user_field_7966"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["Ndoc"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["nloc"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["NMSmeti"].ToString();
                i1 = i1 + 1;
                if (dv[i]["base_start_date"] != DBNull.Value)
                    rngActive.get_Offset(i, i1).Value2 = ((DateTime)dv[i]["base_start_date"]).ToShortDateString();
                i1 = i1 + 1;
                if (dv[i]["base_end_date"] != DBNull.Value)
                    rngActive.get_Offset(i, i1).Value2 = ((DateTime)dv[i]["base_end_date"]).ToShortDateString();

                i1 = 31;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["SumAll"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["Sum2001"].ToString();
                i1 = i1 + 1;
                rngActive.get_Offset(i, i1).Value2 = dv[i]["StObor2001"].ToString();
                //my.cn.Open();
                if (dv[i]["idsm"].ToString() != "0")
                {
                    my.sc.CommandText = "exec Grafik.dbo.sOstPlan " + dv[i]["id"].ToString() + "," + dv[i]["idsm"].ToString() + ",'" + d1.ToShortDateString() + "','" + d2.ToShortDateString() + "'";
                    SqlDataReader sd = my.sc.ExecuteReader();
                    sd.Read();
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["Ost2001"];
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["Ost2001"];

                    i1 = i1 + 2;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlan2001"] + (Double)sd["OstPlanObor2001"];
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlan2001"];
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlanObor2001"];

                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlanTek"] + (Double)sd["OstPlanOborTek"];
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlanTek"];
                    i1 = i1 + 1;
                    rngActive.get_Offset(i, i1).Value2 = (Double)sd["OstPlanOborTek"];
                    sd.Close();
                }
            }
            my.cn.Close();
            WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, lcol)).HorizontalAlignment = Constants.xlCenter;
            WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(i, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;

            WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
            ExlApp = null; GC.Collect();
        }



        internal static void ReportExOstSmSt(string idGrafik, int mode, string szap, string d1, string d2,int IdEntpr, int IdDep)
        {
            //try
            //{

            // return;
            my.cn.Open();
            my.sc.CommandTimeout = 3000000;
            //exec SOstSmetLimit 32,'01.03.2012',0,0,1,1
            my.sc.CommandText = "set dateformat 'dmy'  exec smr.dbo.SOstSmetLimit 32,'" + DateTime.Now.Date.ToString() + "',0,3,1,1," + idGrafik + "," + IdEntpr.ToString() + "," + IdDep.ToString();
            DataView dv = new DataView(); DataSet ds = new DataSet(); SqlDataAdapter da;
            SqlDataAdapter da5;
            //SqlDataReader rd = my.sc.ExecuteReader();

            ds.Clear();
            da5 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
            da5.Fill(ds);
            dv.Table = ds.Tables[0];
            if (dv.Count == 0) { my.cn.Close(); return; }

            Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook WrkBk = ExlApp.Workbooks.Open("C:\\cis\\Сервис\\Сводный реестр остатков сметной стоимости по графику.xlt", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Worksheet WrkSht = (Worksheet)WrkBk.ActiveSheet;
            //Microsoft.Office.Interop.Excel.Workbook WrkBk = ExlApp.Workbooks.Add(System.Reflection.Missing.Value2);
            //Microsoft.Office.Interop.Excel.Worksheet WrkSht = (Microsoft.Office.Interop.Excel.Worksheet)WrkBk.ActiveSheet;
            //WrkSht.Cells.NumberFormat = "@";
            //WrkSht.Cells.ColumnWidth = 20;
            //WrkSht.Cells.WrapText = true;
            ExlApp.Visible = true;

            Microsoft.Office.Interop.Excel.Range rngActive = (Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[8, 1];
            ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[2, 1]).Value2 ="Сводный реестр остатков сметной стоимости по коду стройки 02.001.000 Ленинградская АЭС-2 " ;
            //((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[4, 21]).Value2 = ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[4, 21]).Value2.ToString().Replace("хх.хх.хххх", (DateTime.Now.Date).AddMonths(1).ToShortDateString());
            //((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[4, 24]).Value2 = ((Microsoft.Office.Interop.Excel.Range)WrkSht.Cells[4, 24]).Value2.ToString().Replace("хх.хх.хххх", (DateTime.Now.Date).AddMonths(1).ToShortDateString());
 // WrkSht.Cells(4, 13).Value2 = Replace(WrkSht.Cells(4, 13).Value2, "хх.хх.хххх", DateAdd("m", 1, d2))
 //WrkSht.Cells(4, 16).Value2 = Replace(WrkSht.Cells(4, 16).Value2, "хх.хх.хххх", DateAdd("m", 1, d2))
 

                            int lcol = 27;
                WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Font.Bold = true;
                //WrkSht.get_Range(rngActive.get_Offset(0, 0), rngActive.get_Offset(0, lcol)).Select();
                rngActive = rngActive.get_Offset(1, 0);
                //rngActive.Select();
                int i = 0; int i2 = 0; int i1 = 0; int i4 = 0;
                string idwrk = ""; int IdSm = 0; int izapwrk = -1; int izapwrkend = -1; int izapsm = -1; int izapsmend = -1; int zIdSmPr = 0; int iIdSmPr = -1;
                int izaposr = -1; int izapch = -1; int izaposrend = -1;
                string NMChapter = ""; string NMOSR = "";
                int[] idsm = new int[3000];
                int idsmind = 0;
                //string[] Proc = new string[13];
                //Proc[1] = "remain_equip_qtykt2";
                //Proc[1] = "remain_equip_qtykt2";
                //Proc[2] = "total_equip_qtykt2";
                //Proc[3] = "act_equip_qtykt2";
                //Proc[4] = "remain_work_qtykt2";
                //Proc[5] = "total_work_qtykt2";
                //Proc[6] = "target_costkt2";
                //Proc[7] = "backt2";
                //Proc[8] = "target_equip_costkt2";
                //Proc[9] = "remain_costkt2";
                //Proc[10] = "total_costkt2";
                //Proc[11] = "act_costkt2";
                //Proc[12] = "base_equip_costkt2";
                //sdvig = 1;
                WrkSht.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                for (i = 0; i < dv.Count; i++)
                {

                    if (IdSm != (int)dv[i]["IdSm"]) { izapsmend = i2; }
                        if (zIdSmPr != (int)dv[i]["IdSmPr"])
                    {
                        if (zIdSmPr != 0)
                        {
                            rngActive.get_Offset(i2, 1).Value2 = "Итого по блоку смет:";
                            //WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).EntireRow.Hidden = true;
                            //j1 = 7;
                            for (int J = 7; J <= lcol - 8; J++)
                            {
                                rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                                //rngActive.get_Offset(i, J).Formula = "=SUBTOTAL(9," + rngActive.get_Offset(iIdSmPr + 1, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + ":" + rngActive.get_Offset(i - 1, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + ")";
                            }
                            rngActive.get_Offset(i2, 20).Formula = "=" + rngActive.get_Offset(i2, 7).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 10).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;
                            rngActive.get_Offset(i2, 21).Formula = "=" + rngActive.get_Offset(i2, 8).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 11).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                            rngActive.get_Offset(i2, 22).Formula = "=" + rngActive.get_Offset(i2, 9).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 12).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                            rngActive.get_Offset(i2, 23).Formula = "=" + rngActive.get_Offset(i2, 7).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 13).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                            rngActive.get_Offset(i2, 24).Formula = "=" + rngActive.get_Offset(i2, 8).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 14).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                            rngActive.get_Offset(i2, 25).Formula = "=" + rngActive.get_Offset(i2, 9).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 15).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();


                            WrkSht.get_Range(rngActive.get_Offset(iIdSmPr, 1), rngActive.get_Offset(i2 - 1, 1)).Interior.ColorIndex = 15;
                            i2 = i2 + 1;

                        }

                        iIdSmPr = i2;
                    }               
                    if (NMOSR != dv[i]["NMChapter"].ToString()) { izaposrend = i2; }
                    //if (idwrk != dv[i]["idWRK"].ToString()) { izapwrkend = i2; }

                    if (NMChapter != dv[i]["NMChapter"].ToString())
                    {
                        //sdvig = 2;
                        if (izapch != -1 & izapch != i2 - 1)
                        {
                            for (int izap = 4; izap <= lcol-2 ; izap++)
                            {
                                rngActive.get_Offset(izapch, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        //WrkSht.Range(rngActive.get_Offset(n2 + 1, 0), rngActive.get_Offset(IIf(n1 < n2, i - 1, n1 - 1), lcol)).Rows.Group
                        izapch = i2;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["NMChapter"].ToString();
                        rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;
                        //NMChapter = "";

                        izapwrkend = i2;
                        NMOSR = "";
                        i2 = i2 + 1;
                    }
                    if (NMOSR != dv[i]["NMOSR"].ToString())
                    {
                        //sdvig = 2;
                        if (izaposr != -1 & izaposr != i2 - 1 & izaposr < izaposrend)
                        {
                            for (int izap = 7; izap <= lcol-2 ; izap++)
                            {
                                rngActive.get_Offset(izaposr, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izaposrend - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(izaposrend - 1, lcol)).EntireRow.Hidden = true;
                        }
                        izaposr = i2;
                        izaposrend = i2;
                        iIdSmPr = i2+1;
                        rngActive.get_Offset(i2, 0).Value2 = dv[i]["OSR"].ToString() + " " +dv[i]["NMOSR"].ToString();
                        rngActive.get_Offset(i2, 5).Value2 = dv[i]["St91"].ToString() ;
                        rngActive.get_Offset(i2, 6).Value2 = dv[i]["StPr91"].ToString();
                        rngActive.get_Offset(i2, 4).Formula = "=" + rngActive.get_Offset(i2, 5).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + " + " + rngActive.get_Offset(i2, 6).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                        //rngActive.get_Offset(i2, 0).Font.Bold = true;
                        rngActive.get_Offset(i2, 0).Font.Italic = true;

                        i2 = i2 + 1;
                    }




                    if (IdSm != (int)dv[i]["IdSm"])
                    {
                        if (izapsm != -1 & izapsm != izapsmend - 1 & izapsm < izapsmend)
                        {
                            //sdvig = 2;
                            for (int izap = 17; izap <= 19; izap++)
                            {
                                //if (izap != 27 & izap != 28 & izap != 34)
                                //{
                                    //if (izap < 29 | izap > 34)
                                    //{
                                        rngActive.get_Offset(izapsm, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapsm + 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapsmend - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                                    //}
                                    //else
                                    //{
                                    //    rngActive.get_Offset(izapsm, izap ).Value2 = rngActive.get_Offset(izapsm, izap  - 5).Value2;
                                    //}
                                //}
                            }
                            WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                            WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).EntireRow.Hidden = true;

                        }
                        izapsm = i2;
                        //iIdSmPr = i2;
                         int J = 1;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["NomerSm"];
	rngActive.get_Offset(i2, J).WrapText = true;
	J = J + 2;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["NMSmeti"];
	rngActive.get_Offset(i2, J).WrapText = true;

	J = J + 5;
    if ((int)dv[i]["IdStatus"] != 2 & (int)dv[i]["IdStatus"] != 4)
	{
		rngActive.get_Offset(i2, J).Value2 = dv[i]["SmStoimSMR"];
		J = J + 1;
		rngActive.get_Offset(i2, J).Value2 = dv[i]["SmStoimPr"];
        rngActive.get_Offset(i2, J - 2).Formula = "=" + rngActive.get_Offset(i2, J - 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + " + " + rngActive.get_Offset(i2, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
	}
	else
	{
        WrkSht.get_Range(rngActive.get_Offset(i2, 1), rngActive.get_Offset(i2 , 1)).Interior.ColorIndex = 15;
		J = J + 1;
	}

	J = J + 2;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["vip91"];
	J = J + 1;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["vip91Pr"];
	rngActive.get_Offset(i2, J - 2).Formula = "=" + rngActive.get_Offset(i2, J - 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + " + " + rngActive.get_Offset(i2, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;
	J = J + 2;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["vipzak"];
	J = J + 1;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["vipzakPr"];
	rngActive.get_Offset(i2, J - 2).Formula = "=" + rngActive.get_Offset(i2, J - 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + " + " + rngActive.get_Offset(i2, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;

    J = J + 4;
    if ((int)dv[i]["IdStatus"] != 2 & (int)dv[i]["IdStatus"] != 4)
	{

			J = J + 1;
			rngActive.get_Offset(i2, J).Formula = "=" + rngActive.get_Offset(i2, J + 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + " + " + rngActive.get_Offset(i2, J + 2).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;
            rngActive.get_Offset(i2, J + 1).Value2 = (double)dv[i]["Ost91"] - (double)dv[i]["OstProch91"];
			rngActive.get_Offset(i2, J + 2).Value2 = dv[i]["OstProch91"];

			J = J + 3;
			rngActive.get_Offset(i2, J).Formula = "=" + rngActive.get_Offset(i2, J + 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + " - " + rngActive.get_Offset(i2, J + 2).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() ;
            rngActive.get_Offset(i2, J + 1).Value2 = (double)dv[i]["Ost91zak"] - (double)dv[i]["OstProch91zak"];
			rngActive.get_Offset(i2, J + 2).Value2 = dv[i]["OstProch91zak"];

		J = J + 2;

	}
	else
	{
	J = J + 6;
	}
	J = J + 1;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["DogovorSm"];
	J = J + 1;
	rngActive.get_Offset(i2, J).Value2 = dv[i]["DogovorF2"];



    //--acts
    //if (dv[i]["IdSm"].ToString() == "61812") System.Windows.MessageBox.Show("61812");
    my.sc.CommandText = "set language 'русский' exec sF2 '" + d1 + "','" + d2 + "', " + dv[i]["IdSm"].ToString();
    DataView dv1 = new DataView(); DataSet ds1 = new DataSet(); SqlDataAdapter da1;
    ds1.Clear();
    da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
    da1.Fill(ds1);
    dv1.Table = ds1.Tables[0];
    //sdvig = 2;


    for (int i3 = 0; i3 < dv1.Count; i3++)
    {
        i2 = i2 + 1;
        rngActive.get_Offset(i2, 16).NumberFormat = "@";
        rngActive.get_Offset(i2, 16).Value2 = dv1[i3]["KodUnic"].ToString();
        J = 18;
        rngActive.get_Offset(i2, J).Value2 = dv1[i3]["vip91"];
        J = J + 1;
        rngActive.get_Offset(i2, J).Value2 = dv1[i3]["vip91Pr"];
        rngActive.get_Offset(i2, J - 2).Formula = "=" + rngActive.get_Offset(i2, J - 1).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + " + " + rngActive.get_Offset(i2, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();


    }

    //if ((int)dv[i]["IdStatus"] != 2 || (dv1.Count != 0 & (int)dv[i]["IdStatus"] == 2 & (int)dv[i]["IdSmPr"] == 0))
    //{
        //--works
        my.sc.CommandText = "set language 'русский' exec smr.dbo.sSmWrk  " + dv[i]["IdSm"].ToString() + "," + idGrafik;
        ds1 = new DataSet();
        ds1.Clear();
        da1 = new SqlDataAdapter(my.sc.CommandText, my.sconn);
        da1.Fill(ds1);
        dv1.Table = ds1.Tables[0];
        //sdvig = 2;


        for (int i3 = 0; i3 < dv1.Count; i3++)
        {
            i2 = i2 + 1;
            //rngActive.get_Offset(i2, 16).NumberFormat = "@";
            rngActive.get_Offset(i2, 1).Value2 = dv[i]["NomerSm"];
            rngActive.get_Offset(i2, 2).Value2 = dv1[i3]["IdWrk"].ToString(); //dv1[i3]["KodUnic"].ToString();
            rngActive.get_Offset(i2, 3).Value2 = dv1[i3]["nmWrk"].ToString(); //dv1[i3]["KodUnic"].ToString();
            //my.sc.CommandText = "SELECT     1 FROM         Grafik.dbo.vCntWrk WHERE     (idWrk = '" + dv1[i3]["IdWrk"].ToString() + "') AND (idGrafik = "+idGrafik+")  " ;
            if ((int)dv1[i3]["cnt"] > 1) 
            { WrkSht.get_Range(rngActive.get_Offset(i2, 2), rngActive.get_Offset(i2, 2)).Interior.ColorIndex = 15; };
        }
    //}


                        i2 = i2 + 1;
                        //idwrk = dv[i]["idWRK"].ToString();
                        NMOSR = dv[i]["NMOSR"].ToString();
                        NMChapter = dv[i]["NMChapter"].ToString();
                        IdSm = (int)dv[i]["IdSm"];
                        zIdSmPr = (int)dv[i]["IdSmPr"];
                        //rngActive.get_Offset(i).EntireRow.Hidden = True
                    }
                }
                //sdvig = 1;
                //WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, 2)).HorizontalAlignment = Constants.xlCenter;
                izapsmend = i2;
                if (zIdSmPr != 0)
                {
                    rngActive.get_Offset(i2, 1).Value2 = "Итого по блоку смет:";
                    //WrkSht.get_Range(rngActive.get_Offset(i2, 0), rngActive.get_Offset(i2, lcol)).EntireRow.Hidden = true;
                    //j1 = 7;
                    for (int J = 7; J <= lcol-8; J++)
                    {
                        rngActive.get_Offset(i2, J).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(iIdSmPr, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, J)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                        //rngActive.get_Offset(i, J).Formula = "=SUBTOTAL(9," + rngActive.get_Offset(iIdSmPr + 1, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + ":" + rngActive.get_Offset(i - 1, J).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString()  + ")";
                    }
                    rngActive.get_Offset(i2, 20).Formula = "=" + rngActive.get_Offset(i2, 7).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 10).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                    rngActive.get_Offset(i2, 21).Formula = "=" + rngActive.get_Offset(i2, 8).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 11).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                    rngActive.get_Offset(i2, 22).Formula = "=" + rngActive.get_Offset(i2, 9).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 12).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                    rngActive.get_Offset(i2, 23).Formula = "=" + rngActive.get_Offset(i2, 7).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 13).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                    rngActive.get_Offset(i2, 24).Formula = "=" + rngActive.get_Offset(i2, 8).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 14).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();
                    rngActive.get_Offset(i2, 25).Formula = "=" + rngActive.get_Offset(i2, 9).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + "-" + rngActive.get_Offset(i2, 15).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString();

                    WrkSht.get_Range(rngActive.get_Offset(iIdSmPr , 1), rngActive.get_Offset(i2 - 1, 1)).Interior.ColorIndex = 15;
                    i2 = i2 + 1;

                }
                //sdvig = 2;
                if (izapch != -1 & izapch != i2 - 1)
                {
                    for (int izap = 4; izap <= lcol-2 ; izap++)
                    {
                        rngActive.get_Offset(izapch, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapch + 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //WrkSht.get_Range(rngActive.get_Offset(izapch + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }

                if (izaposr != -1 & izaposr != i2 - 1)
                {
                    for (int izap = 7; izap <= lcol-2 ; izap++)
                    {
                        rngActive.get_Offset(izaposr, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izaposr + 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izaposr + 1, 0), rngActive.get_Offset(i2 - 1, lcol)).EntireRow.Hidden = true;
                    //WrkSht.get_Range(rngActive.get_Offset(izapwrk, 0), rngActive.get_Offset(izapwrk, lcol)).EntireRow.Hidden = true;
                }
                
                if (izapsm != -1 & izapsm != izapsmend - 1 & izapsm < izapsmend)
                {
                    //sdvig = 2;
                    for (int izap = 17; izap <= 19; izap++)
                    {
                        //if (izap != 27 & izap != 28 & izap != 34)
                        //{
                        //if (izap < 29 | izap > 34)
                        //{
                        rngActive.get_Offset(izapsm, izap).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(izapsm + 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(izapsmend - 1, izap)).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";
                        //}
                        //else
                        //{
                        //    rngActive.get_Offset(izapsm, izap ).Value2 = rngActive.get_Offset(izapsm, izap  - 5).Value2;
                        //}
                        //}
                    }
                    WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).Rows.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    WrkSht.get_Range(rngActive.get_Offset(izapsm + 1, 0), rngActive.get_Offset(izapsmend - 1, lcol)).EntireRow.Hidden = true;

                }

                {
                    //sdvig = 2;
                    for (int izap = 7; izap <= lcol-2 ; izap++)
                    {

                        rngActive.get_Offset(i2, izap ).Value2 = "=ПРОМЕЖУТОЧНЫЕ.ИТОГИ(9;" + ((Range)rngActive.get_Offset(0, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ":" + ((Range)rngActive.get_Offset(i2 - 1, izap )).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing).ToString() + ")";

                    }
                }

                WrkSht.get_Range(rngActive.get_Offset(-1, 0), rngActive.get_Offset(i2, lcol)).Borders.LineStyle = XlLineStyle.xlContinuous;


                //WrkSht.get_Range(rngActive.get_Offset(-1, 11 ), rngActive.get_Offset(i2, 14 )).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 21 ), rngActive.get_Offset(i2, lcol)).NumberFormat = "# ##0";
                WrkSht.get_Range(rngActive.get_Offset(-1, 2), rngActive.get_Offset(i2, 19)).WrapText = true;

                WrkSht = null; WrkBk = null;   /*ExlApp.Quit();*/
                ExlApp = null; GC.Collect();
                my.cn.Close();

            //}
            //catch (Exception ex)
            //{
            //    if (my.cn.State == ConnectionState.Open)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //        my.cn.Close();
            //    }

            //}

        }

    }
}
