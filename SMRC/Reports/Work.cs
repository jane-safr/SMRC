using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Reflection;




namespace SMRC.Forms
{
    static class Work
    {
        public static void F3InExcelold(int IdF3, int VidF3, int TipVneshDog, bool chDrOb, bool ch84, bool ch91, Int16 chDavMat, bool rbNDS, bool rbKop, string FromIsp, string FromIspPost,

             string FromZak, string FromZakPost, int IdZakName, bool fl_2000, bool chInv, bool chActs)
        { }
    //        string appProgID = "Excel.Application";
    //        //object xlapptemplate = System.Runtime.InteropServices.Marshal.GetActiveObject(appProgID);
    //        //Type excelType = Type.GetTypeFromProgID(appProgID);
    //        //object xlapptemplate1 = Activator.CreateInstance(excelType);
    //        //object workbooks = xlapptemplate1.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlapptemplate1, null); 
    //        //object[] args = new object[1];
    //        //args[0] = "C:\\cis\\������\\�����3.xls";
    //        // ������� ������� �����
    //        //object workbook = workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, workbooks, args); 
    //        //object workbooks = xlapptemplate1.GetType().InvokeMember("C:\\cis\\������\\�����3.xls", BindingFlags.GetProperty, null, xlapptemplate1, null); 
    //        Application xlapp = new Application();
    //        Application xlapptemplate = new Application();

    //        Worksheet xlsheettemplate = null;
    //        int iorder = 0;
    //        Workbook xlbook = null;
    //        Worksheet xlsheet = null;
    //        Workbook xlbooktemplate = null;

    //        int i = 0;
    //        int �������� = 0;
    //        int ���������������� = 0;
    //        int ������ = 0;
    //        int IdDog = 0;
    //        iorder = 1;
    //        my.cn.Open();
    //        my.sc.CommandText = "select * from v_F3Dog Where idF3=" + IdF3.ToString();
    //        SqlDataReader sd = my.sc.ExecuteReader();
    //        sd.Read();
    //        IdDog = (int)sd["IdDog"];

    //        xlbooktemplate = xlapptemplate.Workbooks.Open("C:\\cis\\������\\�����3.xls", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //        //xlbooktemplate = xlapptemplate.Workbooks.Open("C:\\cis\\������\\�����3.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    //        //xlbooktemplate = xlapptemplate.Workbooks.Open("C:\\cis\\������\\�����3.xls", 0, true, 5, "", "", false, XlPlatform.xlWindows, "",true, false, 0, true, false, false);
    //        xlapp.Visible = true;

    //        //xlapptemplate.Visible = true;
    //        xlbook = xlapp.Workbooks.Add(Type.Missing);
    //        xlsheet = (Worksheet)xlbook.ActiveSheet;
    //        xlapp.ActiveWindow.DisplayZeros = false;
    //        xlsheettemplate = (Worksheet)xlbooktemplate.Worksheets.get_Item("��3�����");

    //        //������ ��������
    //        for (i = 1; i <= 8; i++)
    //        {
    //            ((Range)xlsheet.Columns[i, Type.Missing]).ColumnWidth = ((Range)xlsheettemplate.Columns[i, Type.Missing]).ColumnWidth;
    //        }
    //        xlsheettemplate.get_Range("A1", "H28").Select();


    //        ((Range)xlapptemplate.Selection).Copy(Type.Missing);
    //        ((Range)xlsheet.Cells[1, 1]).Select();
    //        xlsheet.Paste(Type.Missing, Type.Missing);
    //        xlsheettemplate.get_Range("A29", "B31").Select();
    //        ((Range)xlapptemplate.Selection).Copy(Type.Missing);
    //        xlsheet.get_Range("A29", "A29").Select();
    //        xlsheet.Paste(Type.Missing, Type.Missing);
    //        xlsheet.get_Range("A31", "H31").Select();
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''������ �������
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;

    //        //������ �����

    //        xlsheet.Cells[22, 4] = sd["RegNomer"].ToString(); //����� �������
    //        xlsheet.Cells[22, 5] = sd["PeriodEnd"]; //Date
    //        xlsheet.Cells[12, 1] = "�������: " + sd["naim"];
    //        xlsheet.get_Range(xlsheet.Cells[12, 1], xlsheet.Cells[12, 5]).Merge(Type.Missing);
    //        ((Range)xlsheet.Cells[12, 1]).WrapText = true;
    //        if (sd["naim"].ToString().Length > 60)
    //        {
    //            ((Range)xlsheet.Cells[12, 1]).RowHeight = 22.5;
    //        }

    //        xlsheet.Cells[22, 7] = sd["Period"];
    //        xlsheet.Cells[22, 8] = sd["PeriodEnd"];
    //        xlsheet.Cells[15, 6] = sd["RegNomerDog"];


    //        if (sd["Date_1"] != DBNull.Value)
    //        {
    //            xlsheet.Cells[16, 6] = ((DateTime)sd["Date_1"]).Day;
    //            xlsheet.Cells[16, 7] = ((DateTime)sd["Date_1"]).Month;
    //            xlsheet.Cells[16, 8] = ((DateTime)sd["Date_1"]).Year;
    //        }
    //        if (sd["zak"].ToString() == "094")
    //        {
    //            xlsheet.Cells[6, 1] = "��������: " + sd["Investr"];
    //            xlsheet.Cells[6, 7] = sd["OkpoZak"];
    //            ((Range)xlsheet.Cells[6, 1]).get_Characters(10, sd["ZakName"].ToString().Length).Font.Bold = true;
    //        }
    //        xlsheet.Cells[8, 1] = "�������� (������������):  " + sd["ZakName"].ToString().Trim();

    //        ((Range)xlsheet.Cells[8, 1]).get_Characters(26, sd["ZakName"].ToString().Length).Font.Bold = true;

    //        if (sd["F3Predjav"].ToString() != "000")
    //        {
    //            xlsheet.Cells[8, 1] = xlsheet.Cells[8, 1] + " ( " + sd["F3PredjavName"].ToString().Trim() + " ) ";
    //        }

    //        xlsheet.Cells[8, 7] = sd["OkpoZak"];
    //        xlapptemplate.Visible = true; xlsheettemplate.get_Range("A1", "A1").Select();

    //        System.Windows.Forms.Clipboard.Clear();
    //        System.Threading.Thread.Sleep(3000);
    //        xlapptemplate.Quit();
    //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapptemplate);
    //        xlbooktemplate.Close(Type.Missing, Type.Missing, Type.Missing);
    //        xlapptemplate = null;
    //        GC.Collect(); GC.WaitForPendingFinalizers();
    //        GC.Collect();
    //        //xlapp.Quit();
    //        //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp);
    //        //xlapp = null; 
    //        GC.WaitForPendingFinalizers(); GC.Collect();
    //        //xlbooktemplate = null;
    //        //KillApp();
    //        //Dispose();   
    //        ////
    //        return;


    //        if (VidF3 == 1) // � ���������
    //        {
    //            if (sd["zak"].ToString() == "094")
    //            {
    //                xlsheet.Cells[10, 1] = ((Range)xlsheet.Cells[10, 1]).get_Value(Type.Missing) + sd["IspName"].ToString();
    //                ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
    //            }
    //            else
    //            {
    //                xlsheet.Cells[10, 1] = "��������� (������������): " + sd["IspName"];
    //                ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
    //            }
    //        }
    //        else
    //        {
    //            xlsheet.Cells[10, 1] = "��������� (������������): " + sd["IspName"];
    //        }

    //        System.Windows.Forms.Clipboard.Clear();
    //        sd.Close();
    //        my.cn.Close();

    //        System.Threading.Thread.Sleep(3000);
    //        //xlapptemplate.Quit();

    //        xlapp.Quit();
    //        //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapptemplate);
    //        //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp);
    //        xlapp = null;
    //        //xlapptemplate = null;
    //        GC.Collect(); GC.WaitForPendingFinalizers();
    //        GC.Collect();
    //        return;
    //        ////////System.Threading.Thread.Sleep(3000);
    //        ////////xlbooktemplate.Close(Type.Missing,Type.Missing,Type.Missing);
    //        ////////xlbooktemplate = null;
    //        ////////xlsheettemplate = null;
    //        ////////System.Threading.Thread.Sleep(3000); 

    //        ////////xlapptemplate.Quit();

    //        ////////System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapptemplate);
    //        //////////KillApp();
    //        ////////xlapptemplate = null;
    //        //////////xlbook.Close(Type.Missing, Type.Missing, Type.Missing);
    //        //////////xlbook = null;
    //        //////////xlsheettemplate = null;
    //        //////////xlapp.Quit();
    //        //////////System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp);

    //        //////////xlapptemplate = null;
    //        ////////GC.Collect(); 
    //        ////////               GC.WaitForPendingFinalizers();
    //        ////////               //xlapp.Visible = true;
    //        ////////               GC.Collect(); return;

    //        xlsheet.Cells[10, 7] = "";
    //        xlsheet.Cells[10, 7] = sd["OKPOIsp"];
    //        if ((bool)sd["Vnut"] || sd["zak"].ToString() == "A01" || sd["zak"].ToString() == "001" || sd["zak"].ToString() == "A09")
    //        {
    //            xlsheet.Cells[10, 1] = "��������� (������������): " + sd["IspName"];
    //            ((Range)xlsheet.Cells[10, 1]).get_Characters(26, sd["IspName"].ToString().Length).Font.Bold = true;
    //        }
    //        ((Range)xlsheet.Cells[2, 1]).NumberFormat = "@";

    //        sd.Close();
    //        my.cn.Close();

    //        //xlsheet.Cells[2, 1] = IspF3((frmF3)my.Pform);// my.Shapka(my.Szap, my.identpr);
    //        xlsheet.Cells[3, 1] = my.Ustr;
    //        // ���������� ����� 84 � 91 �����
    //        my.sc.CommandText = "F2_PrintF3Zak '" + IdF3 + "','000'," + Convert.ToInt32(chDrOb) + ",'Sum'," + VidF3.ToString() + "," + my.identpr.ToString();
    //        my.cn.Open();
    //        sd = my.sc.ExecuteReader();
    //        sd.Read();
    //        ������ = 0;
    //        �������� = 0;
    //        string ��������;
    //        if (fl_2000)
    //        {
    //            ������ = ������ + 1;
    //            xlsheet.Cells[������ + 31, 2] = "� ��� ����� � ����� 2000�.";
    //            ((Range)xlsheet.Cells[������ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
    //            xlsheet.Cells[������ + 31, 5] = sd["Sum2000SNG"];
    //            xlsheet.Cells[������ + 31, 7] = sd["Sum2000"];
    //            xlsheet.Cells[������ + 31, 4] = sd["SumSNP2000"];
    //            �������� = "A" + System.Convert.ToString(������ + 31) + ":H" + System.Convert.ToString(������ + 31);
    //            xlsheet.get_Range(��������, Type.Missing).Select();
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //            �������� = �������� + 1;
    //        }
    //        else
    //        {
    //            if (ch84)
    //            {
    //                ������ = ������ + 1;
    //                xlsheet.Cells[������ + 31, 2] = "� ����� 1984 �.";
    //                ((Range)xlsheet.Cells[������ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
    //                xlsheet.Cells[������ + 31, 5] = sd["�����84���"];
    //                xlsheet.Cells[������ + 31, 7] = sd["�����84"];
    //                �������� = "A" + System.Convert.ToString(������ + 31) + ":H" + System.Convert.ToString(������ + 31);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
    //                �������� = �������� + 1;
    //            }
    //            if (ch91)
    //            {
    //                ������ = ������ + 1;
    //                xlsheet.Cells[������ + 31, 2] = "� ����� 1991 �.";
    //                ((Range)xlsheet.Cells[������ + 31, 2]).HorizontalAlignment = Constants.xlCenter;
    //                xlsheet.Cells[������ + 31, 5] = sd["�����91���"];
    //                xlsheet.Cells[������ + 31, 7] = sd["�����91"];
    //                �������� = "A" + System.Convert.ToString(������ + 31) + ":H" + System.Convert.ToString(������ + 31);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //                �������� = �������� + 1;
    //            }
    //        }
    //        // ����� �������� 84 � 91 ���� �� ��������
    //        if (ch84 || ch91 || fl_2000)
    //        {
    //            �������� = "A" + System.Convert.ToString(������ + 31) + ":H" + System.Convert.ToString(������ + 31);
    //            xlsheet.get_Range(��������, Type.Missing).Select();
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //        }
    //        Double DavMat = (Double)sd["����������������"];
    //        sd.Close();
    //        //    ���������� = "����������"
    //        my.sc.CommandText = "exec F2_PrintF3Zak  " + IdF3 + ",'000'," + (chDrOb ? 1 : 0) + ",'" + ((chActs) ? "TabRas" : ((chInv) ? "TabInv" : "Tab")) + "'," + VidF3.ToString() + "," + my.identpr;
    //        sd = my.sc.ExecuteReader();
    //        //sd.Read();


    //        �������� = 1;
    //        i = 0;
    //        string Obj = null;
    //        string naim = null;
    //        Obj = "";
    //        bool sdR = sd.Read();
    //        while (sdR)
    //        {

    //            naim = sd["������"].ToString().Trim();//((IsNull(sd["������"])) ? "" : );

    //            int i1 = 0;

    //            ((Range)xlsheet.Columns[15, Type.Missing]).Hidden = true;
    //            ((Range)xlsheet.Columns[16, Type.Missing]).Hidden = true;
    //            ((Range)xlsheet.Columns[17, Type.Missing]).Hidden = true;
    //            if (chActs || chInv)
    //            {
    //                if (Obj != naim.Trim())
    //                {
    //                    Obj = naim;
    //                    xlsheet.Cells[������ + 32 + i, 2] = naim;
    //                    ((Range)xlsheet.Cells[������ + 32 + i, 2]).Font.Bold = true;
    //                    i1 = i;
    //                    i = i + 1;
    //                    �������� = �������� + 1;
    //                }
    //                xlsheet.Cells[������ + 32 + i, 2] = sd["naim"].ToString().Trim(); // ������������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 2]).WrapText = true;

    //            }
    //            else
    //            {
    //                xlsheet.Cells[������ + 32 + i, 2] = naim;
    //                ((Range)xlsheet.Cells[������ + 32 + i, 2]).WrapText = true;
    //                ((Range)xlsheet.Cells[������ + 32 + i, 2]).Font.Bold = true;
    //                ((Range)xlsheet.Cells[������ + 32 + i, 2]).Font.Size = 9;

    //            }

    //            xlsheet.Cells[������ + 32 + i, 1] = sd["kodosr"];
    //            ((Range)xlsheet.Cells[������ + 32 + i, 1]).Font.Size = 9;
    //            xlsheet.Cells[������ + 32 + i, 3] = sd["KodZak"].ToString() + sd["Shifr"].ToString();
    //            ((Range)xlsheet.Cells[������ + 32 + i, 3]).Font.Size = 7;
    //            xlsheet.Cells[������ + 32 + i, 5] = sd["�����������"]; //� ������ ����
    //            //((Range)xlsheet.Cells[������ + 32 + i, 5]).Select();
    //            ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //            xlsheet.Cells[������ + 32 + i, 4] = sd["�����������"];
    //            ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //            xlsheet.Cells[������ + 32 + i, 7] = sd["��������"];
    //            ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";

    //            ((Range)xlsheet.Cells[������ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //            ((Range)xlsheet.Cells[������ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //            ((Range)xlsheet.Cells[������ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //            �������� = "A" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //            xlsheet.get_Range(��������, Type.Missing).Select();

    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;

    //            if (fl_2000)
    //            {
    //                i = i + 1;
    //                �������� = �������� + 1;
    //                xlsheet.Cells[������ + 32 + i, 2] = "� ��� ����� � � 2000�.";
    //                xlsheet.Cells[������ + 32 + i, 5] = (Double)sd["Sum2000SNG"] - (Double)sd["Sum2000zuSNG"] - (Double)sd["Sum2000PerRabSNG"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 4] = (Double)sd["SumSNP2000"] - (Double)sd["Sum2000zuSNP"] - (Double)sd["Sum2000PerRabSNP"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 7] = (Double)sd["Sum2000"] - (Double)sd["Sum2000zu"] - (Double)sd["Sum2000PerRab"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";
    //                �������� = "A" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //                xlsheet.get_Range(��������, Type.Missing).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //                xlsheet.get_Range(��������, Type.Missing).Font.Italic = true;
    //                xlsheet.get_Range(��������, Type.Missing).Font.Size = 8;

    //                i = i + 1;
    //                �������� = �������� + 1;
    //                xlsheet.Cells[������ + 32 + i, 2] = "���������� ����� � ������ �����";
    //                xlsheet.Cells[������ + 32 + i, 3] = "09.09.01";
    //                ((Range)xlsheet.Cells[������ + 32 + i, 3]).Font.Size = 7;
    //                xlsheet.Cells[������ + 32 + i, 5] = sd["zuSNG"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 7] = sd["zu"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 4] = sd["zuSNP"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //                �������� = "B" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //                xlsheet.get_Range(��������, Type.Missing).Font.Bold = true;
    //                �������� = "B" + System.Convert.ToString(������ + 32 + i - 2) + ":H" + System.Convert.ToString(������ + 32 + i - 2);
    //                xlsheet.get_Range(��������, Type.Missing).Font.Bold = true;
    //                xlsheet.Cells[������ + 32 + i - 2, 1] = iorder;
    //                iorder = iorder + 1;
    //                xlsheet.Cells[������ + 32 + i - 2, 3] = sd["kodosr"];
    //                xlsheet.Cells[������ + 32 + i - 2, 5] = (Double)((Range)xlsheet.Cells[������ + 32 + i - 2, 5]).get_Value(Type.Missing) - (Double)sd["zuSNG"] - (Double)sd["PerRabSNG"]; //� ������ ����
    //                xlsheet.Cells[������ + 32 + i - 2, 7] = (Double)((Range)xlsheet.Cells[������ + 32 + i - 2, 7]).get_Value(Type.Missing) - (Double)sd["zu"] - (Double)sd["PerRab"];
    //                xlsheet.Cells[������ + 32 + i - 2, 4] = (Double)((Range)xlsheet.Cells[������ + 32 + i - 2, 4]).get_Value(Type.Missing) - (Double)sd["zuSNP"] - (Double)sd["PerRabSNP"];

    //                ((Range)xlsheet.Cells[������ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //                ((Range)xlsheet.Cells[������ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //                ((Range)xlsheet.Cells[������ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);

    //                i = i + 1;
    //                �������� = �������� + 1;
    //                xlsheet.Cells[������ + 32 + i, 2] = "� ��� ����� � � 2000�.";
    //                xlsheet.Cells[������ + 32 + i, 5] = sd["Sum2000zuSNG"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 7] = sd["Sum2000zu"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 4] = sd["Sum2000zuSNP"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //                �������� = "B" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //                xlsheet.get_Range(��������, Type.Missing).Font.Italic = true;


    //                i = i + 1;
    //                �������� = �������� + 1;
    //                xlsheet.Cells[������ + 32 + i, 2] = "������� �� ��������� ����������";
    //                xlsheet.Cells[������ + 32 + i, 3] = "09.09.02";
    //                ((Range)xlsheet.Cells[������ + 32 + i, 3]).Font.Size = 7;
    //                xlsheet.Cells[������ + 32 + i, 5] = sd["PerRabSNG"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 7] = sd["PerRab"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 4] = sd["PerRabSNP"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //                �������� = "B" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //                xlsheet.get_Range(��������, Type.Missing).Font.Bold = true;
    //                ((Range)xlsheet.Cells[������ + 32 + i, 15]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 4]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //                ((Range)xlsheet.Cells[������ + 32 + i, 16]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 5]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
    //                ((Range)xlsheet.Cells[������ + 32 + i, 17]).Formula = "=" + ((Range)xlsheet.Cells[������ + 32 + i, 7]).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);

    //                i = i + 1;
    //                �������� = �������� + 1;
    //                xlsheet.Cells[������ + 32 + i, 2] = "� ��� ����� � � 2000�.";
    //                xlsheet.Cells[������ + 32 + i, 5] = sd["Sum2000PerRabSNG"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 5]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 7] = sd["Sum2000PerRab"];
    //                ((Range)xlsheet.Cells[������ + 32 + i, 7]).NumberFormat = "# ##0";
    //                xlsheet.Cells[������ + 32 + i, 4] = sd["Sum2000PerRabSNP"]; //� ������ ����
    //                ((Range)xlsheet.Cells[������ + 32 + i, 4]).NumberFormat = "# ##0";
    //                �������� = "A" + System.Convert.ToString(������ + 32 + i) + ":H" + System.Convert.ToString(������ + 32 + i);
    //                xlsheet.get_Range(��������, Type.Missing).Font.Italic = true;
    //                xlsheet.get_Range(��������, Type.Missing).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //            }
    //            i = i + 1;
    //            sdR = sd.Read();
    //            �������� = �������� + 1;

    //            if ((!sdR & (chActs || chInv)) || chActs || chInv)
    //            {
    //                if (Obj != (((sd["������"] == DBNull.Value)) ? "" : sd["������"].ToString()))
    //                {
    //                    xlsheet.Cells[������ + 32 + i1, 4] = "=�������������.�����(9;D" + System.Convert.ToString(32 + i1 + 1) + ":D" + System.Convert.ToString(31 + i);
    //                    xlsheet.Cells[������ + 32 + i1, 5] = "=�������������.�����(9;E" + System.Convert.ToString(32 + i1 + 1) + ":E" + System.Convert.ToString(31 + i);
    //                    xlsheet.Cells[������ + 32 + i1, 7] = "=�������������.�����(9;G" + System.Convert.ToString(32 + i1 + 1) + ":G" + System.Convert.ToString(31 + i);
    //                    ((Range)xlsheet.Cells[������ + 32 + i1, 4]).Font.Bold = true;
    //                    ((Range)xlsheet.Cells[������ + 32 + i1, 5]).Font.Bold = true;
    //                    ((Range)xlsheet.Cells[������ + 32 + i1, 7]).Font.Bold = true;
    //                }

    //            }
    //        }
    //        �������� = �������� - 1;
    //        ���������������� = ��������;
    //        �������� = �������� + ������;

    //        // ����� �� ��������
    //        ((Range)xlsheet.Cells[�������� + 32, 7]).Formula = "=�������������.�����(9;Q" + System.Convert.ToString(32 + ������) + ":Q" + System.Convert.ToString(31 + ��������) + ")";
    //        ((Range)xlsheet.Cells[�������� + 32, 7]).Font.Bold = true;
    //        ((Range)xlsheet.Cells[30, 7]).Formula = "=����(Q" + System.Convert.ToString(32 + ������) + ":Q" + System.Convert.ToString(31 + ��������) + ")";
    //        ((Range)xlsheet.Cells[30, 7]).Font.Bold = true;
    //        ((Range)xlsheet.Cells[30, 5]).Formula = "=����(P" + System.Convert.ToString(32 + ������) + ":P" + System.Convert.ToString(31 + ��������) + ")";
    //        ((Range)xlsheet.Cells[30, 5]).Font.Bold = true;
    //        ((Range)xlsheet.Cells[30, 4]).Formula = "=����(O" + System.Convert.ToString(32 + ������) + ":O" + System.Convert.ToString(31 + ��������) + ")";
    //        ((Range)xlsheet.Cells[30, 4]).Font.Bold = true;
    //        xlsheet.Cells[�������� + 32, 5] = "�����";
    //        ((Range)xlsheet.Cells[�������� + 32, 5]).HorizontalAlignment = Constants.xlRight;
    //        ((Range)xlsheet.Cells[�������� + 32, 5]).Font.Bold = true;
    //        if (chDavMat == 1)
    //        {
    //            xlsheet.Cells[�������� + 33, 7] = sd["����������������"];
    //            ((Range)xlsheet.Cells[�������� + 33, 7]).Font.Bold = true;
    //            xlsheet.Cells[�������� + 33, 5] = "������������ ���������";
    //            ((Range)xlsheet.Cells[�������� + 33, 5]).HorizontalAlignment = Constants.xlRight;
    //            ((Range)xlsheet.Cells[�������� + 33, 5]).Font.Bold = true;
    //            xlsheet.Cells[�������� + 34, 5] = "������ ";
    //            ((Range)xlsheet.Cells[�������� + 33, 5]).HorizontalAlignment = Constants.xlRight;
    //            ((Range)xlsheet.Cells[�������� + 34, 5]).Font.Bold = true;
    //            xlsheet.Cells[�������� + 34, 7] = (Double)((Range)xlsheet.Cells[�������� + 32, 7]).get_Value(Type.Missing) - (Double)((Range)xlsheet.Cells[�������� + 33, 7]).get_Value(Type.Missing);
    //            ((Range)xlsheet.Cells[�������� + 37, 7]).Font.Bold = true;
    //        }
    //        �������� = "F" + System.Convert.ToString(�������� + 32) + ":H" + System.Convert.ToString(32 + �������� + chDavMat * 2);
    //        xlsheet.get_Range(��������, Type.Missing).Select();
    //        for (i = 1; i <= (1 + chDavMat * 2); i++)
    //        {
    //            �������� = "F" + System.Convert.ToString(�������� + 31 + i) + ":H" + System.Convert.ToString(31 + �������� + i);
    //            xlsheet.get_Range(��������, Type.Missing).Select();

    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''������ �������
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //        }

    //        int nds = 0;
    //        nds = 20;
    //        if (my.Uper.Year >= 2004)
    //        {
    //            nds = 18;
    //        }

    //        if (rbNDS) //c ���
    //        {
    //            xlsheet.Cells[�������� + 33 + chDavMat * 2, 5] = "����� ���";
    //            ((Range)xlsheet.Cells[�������� + 33 + chDavMat * 2, 5]).HorizontalAlignment = Constants.xlRight;
    //            ((Range)xlsheet.Cells[�������� + 33 + chDavMat * 2, 5]).Font.Bold = true;
    //            xlsheet.Cells[�������� + 34 + chDavMat * 2, 5] = "����� � ������ ���";
    //            ((Range)xlsheet.Cells[�������� + 34 + chDavMat * 2, 5]).HorizontalAlignment = Constants.xlRight;
    //            ((Range)xlsheet.Cells[�������� + 34 + chDavMat * 2, 5]).Font.Bold = true;

    //            if (rbKop) //� ���������
    //            {
    //                �������� = "G" + System.Convert.ToString(30 + ������ - 1) + ":G" + System.Convert.ToString(�������� + 34 + chDavMat * 2);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).NumberFormat = "# ##0,00";
    //                if (!fl_2000)
    //                {
    //                    ((Range)xlapp.Selection).Font.Bold = true;
    //                }
    //                xlsheet.Cells[�������� + 33 + chDavMat * 2, 7] = Math.Floor((Double)((Range)xlsheet.Cells[�������� + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) * nds + 0.5) / 100; //���
    //            }
    //            else
    //            {
    //                �������� = "G" + System.Convert.ToString(30 + ������) + ":G" + System.Convert.ToString(�������� + 34 + chDavMat * 2);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).NumberFormat = "# ##0";
    //                �������� = "G" + System.Convert.ToString(�������� + 33 + chDavMat * 2) + ":G" + System.Convert.ToString(�������� + 34 + chDavMat * 2);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).NumberFormat = "# ##0.00";
    //                ((Range)xlapp.Selection).Font.Bold = true;
    //                xlsheet.Cells[�������� + 33 + chDavMat * 2, 7] = (int)Math.Floor((Double)((Range)xlsheet.Cells[�������� + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) * nds + 0.5) / 100;
    //            }
    //            for (i = 1; i <= 3 + chDavMat * 2; i++)
    //            {
    //                �������� = "F" + System.Convert.ToString(�������� + 31 + i) + ":H" + System.Convert.ToString(31 + �������� + i);
    //                xlsheet.get_Range(��������, Type.Missing).Select();
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; //''������ �������
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
    //                ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;
    //            }
    //            xlsheet.Cells[�������� + 34 + chDavMat * 2, 7] = (Double)((Range)xlsheet.Cells[�������� + 32 + chDavMat * 2, 7]).get_Value(Type.Missing) + (Double)((Range)xlsheet.Cells[�������� + 33 + chDavMat * 2, 7]).get_Value(Type.Missing);
    //            ((Range)xlsheet.Cells[�������� + 34 + chDavMat * 2, 7]).Font.Bold = true;


    //        }
    //        else
    //        {
    //            �������� = "G" + System.Convert.ToString(30 + ������) + ":G" + System.Convert.ToString(�������� + 32 + chDavMat * 2);
    //            xlsheet.get_Range(��������, Type.Missing).Select();
    //            if (rbKop)
    //            {
    //                ((Range)xlapp.Selection).NumberFormat = "# ##0,00";
    //            }
    //            else
    //            {
    //                ((Range)xlapp.Selection).NumberFormat = "# ##0";
    //            }
    //        }

    //        for (i = 1; i <= 5; i++)
    //        {
    //            �������� = ((char)(i + 65)).ToString() + "29:" + ((char)(i + 65)).ToString() + System.Convert.ToString(�������� + 31);
    //            xlsheet.get_Range(��������, Type.Missing).Select();
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;
    //            ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
    //        }
    //        if (rbNDS) //� ���
    //        {
    //            �������� = "F32:H" + System.Convert.ToString(�������� + 34 + DavMat * 2);
    //            //if (IdDog == 2503)
    //            //{
    //            //    xlsheet.Cells[�������� + 35 + DavMat * 2, 2] = "�� �������� ����� ������������";
    //            //    xlsheet.Cells[�������� + 36 + DavMat * 2, 2] = "14.0% �� " + xlsheet.Cells[�������� + 32 + DavMat * 2, 7] + "=";
    //            //    xlsheet.Cells[�������� + 36 + DavMat * 2, 3] = (Double)xlsheet.Cells[�������� + 32 + DavMat * 2, 7] * 0.14 + "���.";
    //            //    xlsheet.Cells[�������� + 37 + DavMat * 2, 2] = "���="; 
    //            //    xlsheet.Cells[�������� + 37 + DavMat * 2, 3] = (int)Math.Floor(Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[�������� + 36 + DavMat * 2, 3]) * nds + 0.5) / 100 + "���.";
    //            //    xlsheet.Cells[�������� + 38 + DavMat * 2, 2] = "� ���="; 
    //            //    xlsheet.Cells[�������� + 38 + DavMat * 2, 3] = (Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[�������� + 37 + DavMat * 2, 3]) + Microsoft.VisualBasic.Conversion.Val(xlsheet.Cells[�������� + 36 + DavMat * 2, 3])) + "���.";
    //            //    //        �������� = �������� + 4
    //            //}
    //        }
    //        else
    //        {
    //            �������� = "F32:H" + System.Convert.ToString(�������� + 32 + DavMat * 2);
    //        }

    //        xlsheet.get_Range(��������, Type.Missing).Select();
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThin;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThin;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;


    //        // ������ ��������� ������ � �������.
    //        �������� = "C29:H" + System.Convert.ToString(�������� + 31);
    //        xlsheet.get_Range(��������, Type.Missing).Select();

    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].Weight = XlBorderWeight.xlThick;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeLeft].ColorIndex = Constants.xlAutomatic;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThick;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlThick;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeRight].ColorIndex = Constants.xlAutomatic;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThick;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeTop].ColorIndex = Constants.xlAutomatic;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThick;
    //        ((Range)xlapp.Selection).Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = Constants.xlAutomatic;

    //        //�������
    //        if (IdDog == 2503)
    //        {
    //            �������� = �������� + 4;
    //        }
    //        xlsheettemplate = (Worksheet)xlbooktemplate.Worksheets.get_Item("�������");
    //        xlsheettemplate.Activate();
    //        xlsheettemplate.get_Range("A1", "H2").Select();
    //        ((Range)xlapptemplate.Selection).Copy(Type.Missing);
    //        �������� = "A" + System.Convert.ToString(�������� + 37 + DavMat * 2) + ":H" + System.Convert.ToString(�������� + 38 + DavMat * 2);
    //        xlsheet.get_Range(��������, Type.Missing).Select();
    //        xlsheet.Paste(Type.Missing, Type.Missing);

    //        xlsheet.Cells[�������� + 37 + DavMat * 2, 3] = FromIspPost;
    //        xlsheet.Cells[�������� + 37 + DavMat * 2, 8] = FromIsp;

    //        xlsheettemplate.get_Range("A3:H6", Type.Missing).Select();
    //        ((Range)xlapptemplate.Selection).Copy(Type.Missing);
    //        �������� = "A" + System.Convert.ToString(�������� + 39 + DavMat * 2) + ":H" + System.Convert.ToString(�������� + 41 + DavMat * 2);
    //        xlsheet.get_Range(��������, Type.Missing).Select();
    //        xlsheet.Paste(Type.Missing, Type.Missing);

    //        if (IdZakName == 1376 | IdZakName == 670) //��� � �������������
    //        {
    //            xlsheettemplate.get_Range("C4:H6", Type.Missing).Select();
    //            ((Range)xlapptemplate.Selection).Copy(Type.Missing);
    //            �������� = "C" + System.Convert.ToString(�������� + 43 + DavMat * 2) + ":H" + System.Convert.ToString(�������� + 44 + DavMat * 2);
    //            xlsheet.get_Range(��������, Type.Missing).Select();
    //            xlsheet.Paste(Type.Missing, Type.Missing);
    //            ((Range)xlsheet.Cells[�������� + 40 + DavMat * 2, 3]).RowHeight = 31.5;
    //            xlsheet.get_Range(xlsheet.Cells[�������� + 40 + DavMat * 2, 3], xlsheet.Cells[�������� + 40 + DavMat * 2, 6]).Merge(Type.Missing);
    //            xlsheet.get_Range(xlsheet.Cells[�������� + 40 + DavMat * 2, 3], xlsheet.Cells[�������� + 40 + DavMat * 2, 6]).WrapText = true;
    //            xlsheet.Cells[�������� + 40 + DavMat * 2, 3] = FromZakPost;
    //            xlsheet.Cells[�������� + 43 + DavMat * 2, 3] = "��������� ��";
    //            xlsheet.Cells[�������� + 40 + DavMat * 2, 8] = FromZak;
    //            xlsheet.Cells[�������� + 43 + DavMat * 2, 8] = "�������� �.�.";
    //        }
    //        else
    //        {
    //            xlsheet.Cells[�������� + 40 + DavMat * 2, 3] = FromZakPost;
    //            xlsheet.get_Range(xlsheet.Cells[�������� + 40 + DavMat * 2, 3], xlsheet.Cells[�������� + 40 + DavMat * 2, 6]).Merge(Type.Missing);
    //            xlsheet.get_Range(xlsheet.Cells[�������� + 40 + DavMat * 2, 3], xlsheet.Cells[�������� + 40 + DavMat * 2, 6]).WrapText = true;
    //            ((Range)xlsheet.Cells[�������� + 40 + DavMat * 2, 3]).RowHeight = 28.5;
    //            xlsheet.Cells[�������� + 40 + DavMat * 2, 8] = FromZak;
    //        }
    //        xlapp.WindowState = XlWindowState.xlMaximized;
    //        xlapp.Visible = true;
    //        // ��������� ������...
    //        xlsheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
    //        xlsheet.PageSetup.TopMargin = 25;
    //        xlsheet.PageSetup.LeftMargin = 25;
    //        xlsheet.PageSetup.RightMargin = 12;
    //        xlsheet.PageSetup.BottomMargin = 25;
    //        my.cn.Close();
    //        //ex:
    //        xlapp = null;
    //        System.Windows.Forms.Clipboard.Clear();
    //        xlsheettemplate = null;
    //        xlbooktemplate = null;


    //        //xlapptemplate = null;
    //        //xlapptemplate.Application.Quit();



    //        xlbook = null;
    //        xlsheet = null;
    //        xlsheettemplate = null;
    //        xlapptemplate.Visible = true; xlapptemplate.Quit(); xlbooktemplate = null;
    //        GC.Collect();
    //    }
    //}
}}