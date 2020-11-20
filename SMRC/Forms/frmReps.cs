using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
namespace SMRC.Forms
{
    
    public partial class frmReps : Form
    {
        public DataView dv = new DataView(); String szap1; string RDSnm = ""; int nbut1; //public int vid = 0;
        DataView dvSub = new DataView();
        public Double  nds; public bool sub = false; public bool poMes = false;

        public frmReps()
        {
            InitializeComponent();
        }

        private void frmReps_Load(object sender, EventArgs e)
        {


            nbut1 = my.Nbut;
            szap1 = my.Szap;
            if (nbut1 == 182) nbut1 = 166;
            rep();
            if (nbut1 == 2002 | nbut1 == 2001 | nbut1 == 2003 | nbut1 == 170)
            {
                groupBox1.Visible = true;
                if (((frmVibSmet)my.Pform).chUch.Checked)
                { my.FillDC(DC1, 17, " and vib = 2008") ; }
                else
                { my.FillDC(DC1, 17, "  AND vib = " + (nbut1 == 170? "2001":nbut1.ToString())); }
            }
            else
            {
                my.FillDC(DC1, 17, " and vib <> 1 and vib = " + nbut1.ToString());
            }

            this.ReportViewer1.RefreshReport();
            WindowState = FormWindowState.Maximized;
            if (nbut1 != 2003 & nbut1 != 80 & nbut1 != 81 & nbut1 != 85 & nbut1 != 180 & nbut1 != 171 & nbut1 != 172 & nbut1 != 190 & nbut1 != 191 & nbut1 != 8 & nbut1 != 1 & nbut1 != 183 & nbut1 != 67 & nbut1 != 175 & nbut1 != 186 & nbut1 != 178 & nbut1 != 185 & nbut1 != 181 & nbut1 != 195)
            {
               ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout); 
            } 
            ReportViewer1.ZoomMode = ZoomMode.Percent;
            ReportViewer1.ZoomPercent = 100;
            this.ReportViewer1.RefreshReport();
            this.ReportViewer1.RefreshReport();
        }
        private void rep()
        {
            // try
            //{	   
            if (my.Nbut == 67)
                {
                    DataTable dt = dv.ToTable();
                    // dv.RowFilter = "";
                   
                    dv.Table = dt;
                    my.headStr = "Лок № сметы,Инв № сметы,Наименование сметы,Проект,Заказчик,Генподрядчик,Объект,Код объекта,Инвестиционн. проект,Глава ССР,Код ОСР,ОСР,Пункт ССР,Титул,Договор,ИстФин,Тип работ,Разработчик,ГруппаСмет,Исполнитель,В архиве,Рассылка,Рассылка по уч.,Участок,Работы завершены,Входят в ССР,ОСР текст,Вып91,ВыпТек,В учете,Подрядчик,Пусковый комплекс,Номер ГЦО,Бизнес-этап А0,Есть в А0,Статус сметы,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                    ucFilter1.UCFilt(dv, ReportViewer1, UCFilter.UCFilter.VidObj.ReportViewer, my.headStr);
                    ShowRepMy();
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(RDSnm, dv));
                    ReportViewer1.RefreshReport();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                string s = "";

            if (my.Pform.Name == "frmF3" | my.Pform.Name == "frmForF3" | my.Pform.Name == "frmActsZak")
            { s = SourceRep(); }
            else if (my.Szap.Contains("exec"))//nbut1 == 2002 | nbut1 == 2003 | nbut1 == 2004 | nbut1 == 2001 | nbut1 == 170
            {
                s = my.Szap;

                my.headStr = "Наименование,Тип договора,Номер договора,Объект,Заказчик,Участок,Прораб,ИстФин,Вып.тек.,Вып91,ДавМат,Оплата без д.м,Возврат,Оплата,,ИФО,Тип,Код стройки,,,,,Предприятие,,,,,,Вид выполнения,,,,,,,,,,,,,,,,Первичный акт,,,Инв.проект,,,,,,,Портфель,,,Создан акт КС2";
                if (nbut1 == 2001 | nbut1 == 170 | nbut1 == 2020) my.headStr = my.headStr = "Наименование,Номер сметы, Номер договора,Объект,Заказчик,Участок,Прораб,ИстФин,Вып.тек.,Вып91,Зарплата,КомпЗП,Механизмы,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,Инв.проект,,,,,,Код стройки,Портфель,,,,,,,,,,,,,блок";
                if (nbut1 == 80 | nbut1 == 85) my.headStr = "Шифр,ПО,Предприятие,Наименование,Заказчик,Тип договора";
                if (nbut1 == 81) my.headStr = "Шифр,Предприятие,Номер сметы,Код уникальный родителя,Код уникальный дочерний";
                //if (poMes)
                //    my.headStr = "Портфель,Предприятие";
                //else
                {
                    if (nbut1 == 180 | nbut1 == 195) my.headStr = "Портфель,Предприятие,Наименование,Период КС2,ССР,Оплата КС2,ПО,,,,,,,,,,,,,,,,,,Субподряд,,,,,ОСР,,Лок.номер,,,,,,,,,блоки,,,,,,,,,,,,,,,,,,,Тип,,Цвет ост.";
                    if (nbut1 == 171 | nbut1 == 190)
                        my.headStr = "Предприятие,ССР,Номер сметы,,,,Комплекс,,,,Договор,,,,,,,,,,,,,Портфель,Участок,,,,Исполнитель,,,,,,,,ОСР,,,блоки";
                    if (nbut1 == 191)
                        my.headStr = "Предприятие,,Номер сметы,,,,,,,,,,,,,,,,,,,,,,,,Дата образования НЗП,Причина НЗП,Исполнитель,Действующая смета,Статус заказчика,,Примечание,,,,,,,блоки";
                    if (nbut1 == 172)
                        my.headStr = "Предприятие,ССР,Номер сметы,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,Портфель,,,Исполнитель,ГП,Участок,Блок";
                    if (nbut1 == 183)
                        my.headStr = "Инвест.проект,Предприятие,Наименование";
                    if (nbut1 == 186)
                        my.headStr = "Наименование,Тип,Договор,Объект,Заказчик,Участк,Прораб,,,,,,,,,,,Проект";
                    if (nbut1 == 187)
                        my.headStr = ",Предприятие,Инв.проект,,,Шифр";
                    if (nbut1 == 166)
                        my.headStr = "Предприятие,Объект,Номер сметы,Наименование,Сумма 91,Сумма Тек,Субподряд,Участок,Шифр,,,,,,,,Договор,Остаток";
                    if (nbut1 == 74)
                        my.headStr = "0,КодУникИсх,СуммаИсх,КодУникДоч,Выполнение тек,СуммаДоч,Предприятие,Период,Остаток,Смета,Шифр,Договор,Номер заменяющей сметы,Вид выполнения";
                    if (nbut1 == 77)
                        my.headStr = "Комплекс,ОСР,0,0,0,Генподрядчик,Предприятие,ОСР,0,пункт титула ";
                    if (nbut1 == 192)
                        my.headStr = "Договор,Заказчик,Сумма,Предмет, Адрес,,Контакт,,Год,Тип";
                    if (nbut1 == 189)
                        my.headStr = ",Предприятие,Номер сметы,Код уникальный,Наименование,Выполнение,Проект,Договор";
                    if (nbut1 == 2007)
                        my.headStr = "Рег.номер,Заказчик,ИстФин,Служебное";
                    if (nbut1 == 2005 || nbut1 == 2019)
                        my.headStr = "Рег.номер,Наименование,Заказчик,Тип";
                    if (nbut1 == 178 | nbut1 == 185)
                        my.headStr = ",Номер сметы,Наименование,Шифр";
                }
            }
            else
            { s = my.FilterSel(nbut1, null, my.sconnReadOnly, szap1); }
              //  s = "exec SOstSmetLimit 32,'01.07.2017 0:00:00',0,1,1,0";
            SqlDataAdapter sda = new SqlDataAdapter(s, my.sconnReadOnly);
            sda.SelectCommand.CommandTimeout = 3000000;
            if (sda != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet DS = new DataSet();
                DataTable dt = new DataTable();
                    //if ((nbut1 == 171 || nbut1 == 172 || nbut1 == 180 | nbut1 == 190 | nbut1 == 191 | nbut1 == 195) && poMes)
                    //{ DataSet DS1 = new DataSet(); sda.Fill(DS1); dt = DS1.Tables[3]; dv.Table = DS1.Tables[3]; }
                    //else
                    { sda.Fill(DS); dv.Table = DS.Tables[0]; }
                    if ((nbut1 == 180 | nbut1 == 195) & DS.Tables.Count>1 & !poMes) { dvSub.Table = DS.Tables[1]; }
                
                //dv.Table = DS.Tables[0];
                ucFilter1.UCFilt(dv, ReportViewer1, UCFilter.UCFilter.VidObj.ReportViewer, my.headStr);
                if (nbut1 == 180 | nbut1 == 2005 | nbut1 == 2002 | nbut1 == 195) ucFilter1.UCFiltDvSub(dvSub);
                    // ucFilter1.UCFilt(dvSub, ReportViewer1, UCFilter.UCFilter.VidObj.ReportViewer, my.headStr);
                    ShowRepMy();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(RDSnm, dv));
                ReportViewer1.RefreshReport();
                Cursor.Current = Cursors.Default;
                sda = null;
            }
            //}
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message);
            // }

        }
        //void DemoDrillthroughEventHandler(object sender, DrillthroughEventArgs e)
        //{
        //    LocalReport report = (LocalReport)e.Report;

        //    report.SubreportProcessing +=
        //                new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
        //}
        private void frmReps_FormClosed(object sender, FormClosedEventArgs e)
        {
            dv = null;
            ReportViewer1.LocalReport.Dispose();
            ucFilter1.Dispose();
            ReportViewer1 = null;
            ucFilter1 = null;
            Dispose();
            WindowState = FormWindowState.Normal;

        }
        private void ShowRepMy()
        {
            ReportViewer1.DocumentMapCollapsed = true;
            String RepPath = "C:/cis/Reports/";
            ReportViewer1.Reset();
            ReportParameter p1 = null;
            ReportParameter pPeriod = new ReportParameter("pPeriod", my.UperName);;
            ReportParameter p3 = null;
            ReportParameter p4 = null;
            ReportParameter p5 = null;
            ReportParameter p6 = null;
            ReportParameter p7 = null;
            ReportParameter p8 = null;
            string NMIsp = "";

            if (my.Pform.Name == "frmF3" | my.Pform.Name == "frmForF3" | my.Pform.Name == "frmActsZak")
            {
                p1 = new ReportParameter("pBazGod", (my.MyStr[0] == "1" ? "  в ценах 1984г" : "  в ценах 1991г"));
                //pPeriod = new ReportParameter("pPeriod", my.UperName);
                ComboBox istfin = (ComboBox)my.Pform.GetType().InvokeMember("idIstFin", System.Reflection.BindingFlags.GetField, null, my.Pform, null);
                TextBox NMrab = (TextBox)my.Pform.GetType().InvokeMember("NMrab", System.Reflection.BindingFlags.GetField, null, my.Pform, null);
                p3 = new ReportParameter("pIstFin", istfin.Text);
                p7 = new ReportParameter("pNaimRab", NMrab.Text);
                p4 = new ReportParameter("pShifr", ("(" + my.Shapka(my.Szap, my.identpr) + ")"));
                NMIsp = (dv[0]["IspNaim"] == DBNull.Value ? "" : dv[0]["IspNaim"].ToString());
                p5 = new ReportParameter("pIsp", (NMIsp));
            }
            switch (nbut1)
            {
                case 2005:
                    {
                        RDSnm = "DataSetBuh";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_BuhAll.rdlc";
                         pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pPred });
                        SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2005", "2006"), my.sconnReadOnly);
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        dvSub.Table = DS.Tables[0];
                        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetSub", dvSub));
                        break;
                    }
                case 2019:
                    {
                        RDSnm = "DataSetBuh";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_BuhAllNew.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pPred });
                        //SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2005", "2006"), my.sconnReadOnly);
                        //DataSet DS = new DataSet();
                        //sda.Fill(DS);
                        //dvSub.Table = DS.Tables[0];
                        //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetSub", dvSub));
                        break;
                    }
                case 2007:
                    {
                        RDSnm = "DataSetBuh";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_BuhAllPodSub.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pPred });
                        SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2007", "2008"), my.sconnReadOnly);
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        dvSub.Table = DS.Tables[0];
                        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetSub", dvSub));
                        break;
                    }
                case 1:
                    {
                        ReportParameter FromIsp = new ReportParameter("FromIsp", "_____________________       " + ((frmF3)my.Pform).FromIsp.Text.Trim());
                        ReportParameter FromZak = new ReportParameter("FromZak", "_____________________       " + ((frmF3)my.Pform).FromZak.Text.Trim());

                        my.sc.CommandText = "select isnull(TipVneshDog,0) as TipVneshDog,PostZak,PostIsp from v_F3Dog Where idf3=" + ((frmF3)my.Pform).IdF3.ToString() ;
                        my.cn.Open();
                        SqlDataReader dr = my.sc.ExecuteReader();
                        dr.Read();
                        int TipVneshDog = (short)dr["TipVneshDog"];
                        string PostZak = dr["PostZak"].ToString();
                        string PostIsp = dr["PostIsp"].ToString();
                        dr.Close();
                        my.cn.Close();
                        ReportParameter PostZak1 = new ReportParameter("PostZak", PostZak);
                        ReportParameter PostIsp1 = new ReportParameter("PostIsp", PostIsp);

                        RDSnm = "DataSet1";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_ReestrUsKom.rdlc";
                        string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        ReportParameter Nom = new ReportParameter("Nom", s);
                        ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Nom, pPeriod, p3, p4, p5, p7, Proveril, FromIsp,FromZak, PostZak1, PostIsp1 });
                        break;
                    }
                case 4:
                    {
                        ReportParameter FromIsp = new ReportParameter("FromIsp", "_____________________       " + ((frmF3)my.Pform).FromIsp.Text.Trim());
                        ReportParameter FromZak = new ReportParameter("FromZak", "_____________________       " + ((frmF3)my.Pform).FromZak.Text.Trim());

                        my.sc.CommandText = "select isnull(TipVneshDog,0) as TipVneshDog,PostZak,PostIsp from v_F3Dog Where idf3=" + ((frmF3)my.Pform).IdF3.ToString();
                        my.cn.Open();
                        SqlDataReader dr = my.sc.ExecuteReader();
                        dr.Read();
                        int TipVneshDog = (short)dr["TipVneshDog"];
                        string PostZak = dr["PostZak"].ToString();
                        string PostIsp = dr["PostIsp"].ToString();
                        dr.Close();
                        my.cn.Close();
                        ReportParameter PostZak1 = new ReportParameter("PostZak", PostZak);
                        ReportParameter PostIsp1 = new ReportParameter("PostIsp", PostIsp);

                        RDSnm = "DataSet1";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_ReestrSSR.rdlc";
                        string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        ReportParameter Nom = new ReportParameter("Nom", s);
                        ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Nom, pPeriod, p3, p4, p5, p7, Proveril, FromIsp, FromZak, PostZak1, PostIsp1 });
                        break;
                    }
                case 8:
                    {
                        RDSnm = "DSWR";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rL2Ob.rdlc";
                        //string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        //ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                       ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {  pPeriod,p7});
                        break;
                    }
                case 178:
                    {
                        RDSnm = "DSMyGCO";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rOstatkiLimit.rdlc";
                        //string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        //ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                       ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 185:
                    {
                       RDSnm = "DSMyGCO";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rOstatkiLimitSmSt.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        // ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;                       
                    }

                case 67:
                    {
                        RDSnm = "DSStendComplex";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rptStendComplex.rdlc";
                        //string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        //ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, p7 });
                        break;
                    }
                case 74:
                    {
                        RDSnm = "dsParent";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rParent.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 711:
                    {
                        RDSnm = "DSEmptyProject";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rEmptyProject.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 73:
                    {
                        RDSnm = "DSComplexOSR";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rComplexOSR.rdlc";
                        break;
                    }
                case 77:
                    {
                        RDSnm = "dsOSRF3";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rOSRF3.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 168:
                    {
                        RDSnm = "DSGpSp";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rGpSp.rdlc";
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 192:
                    {
                        RDSnm = "vDogOpyt";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rDogOpyt.rdlc";
                        break;
                    }
                case 180:
                    {
                        if (poMes)
                        {
                            //RDSnm = "DataSetSvodPoMes";// as in .rdcl
                            //ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodPoMes.rdlc";
                            RDSnm = "DataSetSvKS2KS3";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnKS2KS3PoMes.rdlc";
                        }
                        else
                        {
                        RDSnm = "DataSetSvKS2KS3";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnKS2KS3.rdlc";
                        }
                        //if (nbut1 == 180 | nbut1 == 195)
                        //{
                            ReportParameter snds = new ReportParameter("nds", nds.ToString());
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { snds });
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        //  report.SetParameters(new ReportParameter[] { snds });
                        //}
                        break;
                    }
                case 195:

                    {
                        if (poMes)
                        {
                                RDSnm = "DataSetSvKS2KS3";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnKS2KS3PoMes.rdlc";
                        }
                        else
                        {

                            RDSnm = "DataSetSvKS2KS3";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnKS2KS3Short.rdlc";
                        }
                        ReportParameter snds = new ReportParameter("nds", nds.ToString());
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { snds });
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 190:
                    {
                        if (poMes)
                        {
                            RDSnm = "DataSetNZPPomes";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rNZPPomes.rdlc";
                        }
                        else
                        {
                            RDSnm = "DataSetNZP";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rNZPL2.rdlc";
                        }
                        break;
                    }
                case 191:
                    {
                    RDSnm = "DataSetNZP";// as in .rdcl
                    ReportViewer1.LocalReport.ReportPath = RepPath + "rNZPL2kratko.rdlc";
                    }
                    break;
                case 172:
                case 171:
                    {
                        if (poMes)
                        {
                            RDSnm = "DataSetNZPPomes";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rNZPPomes.rdlc";
                        }
                            else
                        {
                            RDSnm = "DataSetNZP";// as in .rdcl
                            ReportViewer1.LocalReport.ReportPath = RepPath + "rNZP.rdlc";
                        }
                        break;
                    }
                case 64:
                    {
                        RDSnm = "rPerech";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rPerech.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 189:
                    {
                        RDSnm = "DSRepNZ";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rRepNZ.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                //case 182:
                case 166:
                    {
                        RDSnm = "dtsNezaversh";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rNezaversh.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 80:
                    {
                        RDSnm = "WorkSvKv_WorkSvKv";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnijKv.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod});
                        break;
                    }
                case 183:
                    {
                        RDSnm = "WorkShah";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rShahKS2KS3.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 186:
                    {
                        RDSnm = "WorkSvAllmy";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "ShahUpr.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 187:
                    {
                        RDSnm = "sSvodnPoDog";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnPoDog.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 85:
                    {
                        RDSnm = "WorkSvKv_WorkSvKv";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnijKvSample.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 81:
                    {
                        RDSnm = "vOplNezav_vOplNezav";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rOplNezav.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        break;
                    }
                case 215:
                    {
                        RDSnm = "smrDataSet_vPlanSmA0Rep";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rPlanSmA0.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        //SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2001", "2004").Replace("R_SmetnoeRazl", "R_Svodn"), my.sconnReadOnly);
                        //DataSet DS = new DataSet();
                        //sda.Fill(DS);
                        //dvSub.Table = DS.Tables[0];
                        break;
                    }
                case 170:
                case 2020:
                case 2001:
                    {
                        RDSnm = "WorkSm_WorkSm";
                        //ReportViewer1.LocalReport.ReportPath = RepPath + "Report2.rdlc";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSmetnoeRazNew.rdlc";
                        SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2002", "2004").Replace("2001", "2004").Replace("R_SmetnoeRaz","R_Svodn").Replace("'" + my.Upred + "'", "'" + my.identpr + "'"), my.sconnReadOnly);
                        sda.SelectCommand.CommandTimeout = 3000000;
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        //if (DS.Tables[0].Rows.Count != 0)
                            dvSub.Table = DS.Tables[0];
                        nbut1 = 2001;
                        break;

                    }
                case 2004:
                    {
                        RDSnm = "smrDataSetSv_WorkSv";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnijProrab.rdlc";
                        ReportParameter pf2orf3 = new ReportParameter("pf2orf3", my.Ustr);
                        ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pf2orf3, pPred });
                        dv.Sort = "KodUnic";
                        break;
                    }                
                case 2003:
                    {
                        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                        if (my.Ustr == "(выполнение по ф №2)")
                        { ReportViewer1.LocalReport.ReportPath = RepPath + "rShahSvF2.rdlc";}
                        else
                        { ReportViewer1.LocalReport.ReportPath = RepPath + "rShahSv.rdlc"; }
                        RDSnm = "WorkSvSub_WorkSv";
                        //ReportParameter pf2orf3 = new ReportParameter("pf2orf3", my.Ustr);
                        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pf2orf3 });
                        break;
                    }
                case 2002:
                    {
                        RDSnm = "smrDataSetSv_WorkSv";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rSvodnijNew.rdlc";
                        SqlDataAdapter sda = new SqlDataAdapter(szap1.Replace("2002","2003"), my.sconnReadOnly);
                        sda.SelectCommand.CommandTimeout = 3000000;
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        dvSub.Table = DS.Tables[0];
                        dvSub.RowFilter = dv.RowFilter;
                        break;
                    }

                case 20:
                    {
                        RDSnm = "smrDataSetProch_WorkPaper";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rActDogovorProch.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, pPeriod, p4, p5, p3, p7 });
                        LocalReport report = ReportViewer1.LocalReport;
                        ReportViewer1.LocalReport.SubreportProcessing +=
                    new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
                        break;
                    }
                case 181:
                    {
                        //    RDSnm = "smrDataSetProch_WorkPaper";
                        //    ReportViewer1.LocalReport.ReportPath = RepPath + "rActDogovorProch.rdlc";
                        //    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, pPeriod, p4, p5, p3, p7 });
                        //    LocalReport report = ReportViewer1.LocalReport;
                        //    ReportViewer1.LocalReport.SubreportProcessing +=
                        //new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
                        //    break;
                        RDSnm = "DSInvPrVip";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rInvPrVip.rdlc";
                        //string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        pPeriod = new ReportParameter("pPeriod", my.UperName);
                        //ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                         ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod });
                        LocalReport report = ReportViewer1.LocalReport;
                        ReportViewer1.LocalReport.SubreportProcessing +=
                    new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
                        break;
                    }
                case 21:
                    {
                        RDSnm = "smrDataSet1_WorkUch";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rActDogovorUch.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, pPeriod, p4, p5, p3, p7 });
                        break;
                    }
                case 25:
                    {
                        RDSnm = "DataSet1";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "R_ReestrUs.rdlc";
                        string s = my.ExeScalar("SELECT     COUNT(dbo.Forma2.IdObj) AS Cou, dbo.SluNomObject.NomerPromObject FROM         dbo.Forma2 INNER JOIN    dbo.SluNomObject ON dbo.Forma2.IdObj = dbo.SluNomObject.IdObj  where forma2.idf2 in (" + my.Szap + ") GROUP BY dbo.SluNomObject.NomerPromObject");
                        ReportParameter Nom = new ReportParameter("Nom",s);
                        ReportParameter Proveril = new ReportParameter("Proveril", "_____________________       " + my.Id_UsName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Nom, pPeriod, p3,p4,p5,p7, Proveril });
                        break;
                    }
                case 13:
                    {
                        RDSnm = "smrDataSet_WorkActs";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rActDogovorDavMat.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, pPeriod, p4, p5, p3, p7 });
                        break;
                    }
                case 11:
                    {
                        RDSnm = "smrDataSet_WorkActs";
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rActDogovor.rdlc";
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, pPeriod, p4, p5, p3, p7 });

                        if (nbut1 > 2)
                        {
                            if (nbut1 == 16 || nbut1 == 18) { p8 = new ReportParameter("pIsp1", (NMIsp)); ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p8 }); };
                            String s = my.FilterSel(110, null, my.sconnReadOnly, "  AND  dbo.Forma2.IdF2 IN     (SELECT     Stroka AS IdF2     FROM          dbo.IzStr('" + my.Szap + "') AS IzStr_1) ");
                            s = my.Tbl2Str(s);
                            if (nbut1 == 19) { p6 = new ReportParameter("pF3Predjav", (s)); ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p6 }); };
                            ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p4, p5, p3, p7 });
                        }
                        else
                        {
                            //if (vid == 2)
                            //{ 
                            //    If IsNull(РаботаСФормой3.пс_ОтЗаказчика.Columns(2).Value) = False Then
                            //            Report.пДолжностьПерсоналииЗак.SetText Trim(РаботаСФормой3.пс_ОтЗаказчика.Columns(2).Value)
                            //            Report.пДолжностьПерсоналииЗак1.SetText Trim(РаботаСФормой3.пс_ОтЗаказчика.Columns(2).Value)
                            //        End If
                            //        If IsNull(РаботаСФормой3.пс_ОтИсполнителя.Columns(2).Value) = False Then
                            //            Report.пДолжностьПерсоналииИсп.SetText Trim(РаботаСФормой3.пс_ОтИсполнителя.Columns(2).Value)
                            //            Report.пДолжностьПерсоналииИсп1.SetText Trim(РаботаСФормой3.пс_ОтИсполнителя.Columns(2).Value)
                            //        End If
                            //        If IsNull(РаботаСФормой3.пс_ОтЗаказчика.Columns(1).Value) = False Then
                            //            Report.пПерсоналияЗаказчика.SetText Trim(РаботаСФормой3.пс_ОтЗаказчика.Columns(1).Value)
                            //            Report.пПерсоналияЗаказчика1.SetText Trim(РаботаСФормой3.пс_ОтЗаказчика.Columns(1).Value)
                            //        End If
                            //        If IsNull(РаботаСФормой3.пс_ОтИсполнителя.Columns(1).Value) = False Then
                            //            Report.пПерсоналияИсполнителя.SetText Trim(РаботаСФормой3.пс_ОтИсполнителя.Columns(1).Value)
                            //            Report.пПерсоналияИсполнителя1.SetText Trim(РаботаСФормой3.пс_ОтИсполнителя.Columns(1).Value)
                            //        End If
                            //}
                            //        If nbut = 1 Then Report.пНаимРабот.SetText Trim(РаботаСФормой3.п_Наименование.Text)
                            //        If nbut = 2 Then Report.пИндекс.SetText гл_Индекс: Report.пНаимРабот.SetText "''" & Trim(РаботаСФормой3.п_Наименование) & "''": Report.пПериод.SetText "на " + UperName
                        }

                        break;
                    }
                case 131:
                    {
                        RDSnm = "smrDataSet_vSSR";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rptSSR.rdlc";
                        break;
                    }
                case 175:
                    {
                        RDSnm = "DSOstSm";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rOstSm.rdlc";
                        ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod,  pPred });
                        break;
                    }
                case 132:
                    {
                        RDSnm = "smrDataSet_vSSR";// as in .rdcl
                        ReportViewer1.LocalReport.ReportPath = RepPath + "rptOSR.rdlc";
                        break;
                    }
                default:
                    //Report2.rdlc
                    //RDSnm = "smrDataSet_vSSR";// as in .rdcl
                    //ReportViewer1.LocalReport.ReportPath = RepPath + "Report2.rdlc";
                    break;
            }

        }
        void DemoSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            switch (nbut1)
            {

                case 20:
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from vobor where idf2 = " + e.Parameters[0].Values[0].ToString(), my.sconnReadOnly);
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        e.DataSources.Add(new ReportDataSource("smrDataSetObor_vObor", DS.Tables[0]));
                        break;
                    }
                case 181:
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("exec Sprav.dbo.sChain 0, " + e.Parameters[0].Values[0].ToString() + ", " + my.SzapN, my.sconnReadOnly);
                        DataSet DS = new DataSet();
                        sda.Fill(DS);
                        e.DataSources.Add(new ReportDataSource("DSChain", DS.Tables[0]));
                        break;
                    }
            }
        }


        private string SourceRep()
        {
            string strsql = null;
            {
                ComboBox istfin = (ComboBox)my.Pform.GetType().InvokeMember("idIstFin", System.Reflection.BindingFlags.GetField, null, my.Pform, null);
                if (nbut1 == 18 || nbut1 == 19 || nbut1 == 25 || nbut1 == 8 || nbut1 == 1 || nbut1 == 4)
                {
                    strsql = " set dateformat 'dmy'   exec F2_IzAktKF3SNG '" + my.Szap + "','" + my.Uper;
                    int nbut11 = nbut1;
                    if (nbut1 == 6 || nbut1 == 4)
                    {
                        nbut11 = 29;
                    }
                    else if (nbut1 == 7)
                    {
                        nbut11 = 31;
                    }
                    else if (nbut1 == 8)
                    {
                        nbut11 = 32;
                    }
                    else
                    {
                        nbut11 = 19;
                    }
                    switch (my.Pform.Name)
                    {
                        case "frmF3":
                            { strsql = strsql + "'," + Convert.ToString(((frmF3)my.Pform).IdDog) + "," + istfin.SelectedValue.ToString() + ",'" + my.Upred.ToString() + "'," + nbut11 + ",1,'" + ((frmF3)my.Pform).Nom() + "'"; break; }
                        case "frmActsZak":
                            { strsql = strsql + "'," + Convert.ToString(((frmActsZak)my.Pform).IdDog) + "," + istfin.SelectedValue.ToString() + ",'" + my.Upred.ToString() + "'," + nbut11; break; }
                        case "frmForF3":
                            { strsql = strsql + "'," + ((frmForF3)my.Pform).IdDog.SelectedValue.ToString() + "," + istfin.SelectedValue.ToString() + ",'" + my.Upred.ToString() + "'," + nbut11; break; }
                        default:
                            break;
                    }
                }
                else
                {
                    if (my.Pform.Name == "frmF3")
                    { strsql = "exec F2_IzAktKF3 '" + my.Szap + "'," + nbut1 + ",1,'" + ((frmF3)my.Pform).Nom() + "'," + my.MyStr[0]; }
                    else
                    { strsql = "exec F2_IzAktKF3 '" + my.Szap + "'," + nbut1 + ",0,''," + my.MyStr[0]; }

                }
                my.headStr = "Рег.номер,Номер сметы,Наименование,Исполнитель";

            }
            return strsql;
        }
        public void Supp(LocalReport report, int nb, int Gr)
        {

            ReportParameter pPeriod = null;
            ReportParameter pf2orf3 = new ReportParameter("pf2orf3", my.Ustr);
            ReportParameter pDirector = null;
            ReportParameter pPred = new ReportParameter("pPred", my.UpredName);
            ReportParameter p17 = null;
            ReportParameter p15 = null;
            string g3 = ""; System.Xml.XmlNode nod = null;
            string name = ReportViewer1.LocalReport.ReportPath.Substring(ReportViewer1.LocalReport.ReportPath.LastIndexOf("/") + 1);
            ReportViewer1.Reset();
            System.IO.Stream stream = null;
            stream = typeof(frmReps).Assembly.GetManifestResourceStream(@"SMRC.Reports." + name);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(stream);
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ms", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition");

            if (nbut1 == 81 || nbut1 == 180 || nbut1 == 171 || nbut1 == 172 | nbut1 == 190 | nbut1 == 195)
            {
                string NMProj  = "=Fields!ShifrInvPr.Value";
                if (nbut1 == 171 || nbut1 == 172 | nbut1 == 190)
                {
                    NMProj = "=Fields!KodDog.Value";
                    if (poMes) NMProj = "=Fields!NMComplex.Value";

                }
                switch (Gr)
                {
                    case 1:
                        RemGroup(doc, nsmgr, "=Fields!shNMEntpr.Value", NMProj, "");
                        if (poMes)
                        {
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline2_SeriesGroup']", nsmgr);
                            NodGroup(nod, "=Fields!shNMEntpr.Value", nsmgr);
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline4_SeriesGroup']", nsmgr);
                            NodGroup(nod, NMProj, nsmgr);
                            if (nbut1 == 180 | nbut1 == 195)
                            {
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline5_SeriesGroup']", nsmgr);
                                NodGroup(nod, "=Fields!shNMEntpr.Value", nsmgr);
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline7_SeriesGroup']", nsmgr);
                                NodGroup(nod, NMProj, nsmgr);
                            }
                        }
                        else
                        if (nbut1 == 171 || nbut1 == 172 | nbut1 == 190)
                        {
                            {
                                doc.SelectSingleNode("//ms:Textbox[@Name='n1']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!shNMEntpr.Value, countdistinct,Nothing)";
                                doc.SelectSingleNode("//ms:Textbox[@Name='n2']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!shNMEntpr.Value, countdistinct,Nothing) & \".\" & RunningValue(Fields!KodDog.Value, countdistinct,\"table1_Group1\")";
                                doc.SelectSingleNode("//ms:Textbox[@Name='n3']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!shNMEntpr.Value, countdistinct,Nothing) & \".\" & RunningValue(Fields!KodDog.Value, countdistinct,\"table1_Group1\") & \".\" & RunningValue(Fields!NomerSm.Value, countdistinct,\"table1_Group2\")";
                            }
                        }
                        break;
                    case 2:
                        RemGroup(doc, nsmgr, NMProj, "=Fields!shNMEntpr.Value", "");
                        if (poMes)
                        {
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline2_SeriesGroup']", nsmgr);
                            NodGroup(nod, NMProj, nsmgr);
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline4_SeriesGroup']", nsmgr);
                            NodGroup(nod, "=Fields!shNMEntpr.Value", nsmgr);
                            if (nbut1 == 180 | nbut1 == 195)
                            {
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline5_SeriesGroup']", nsmgr);
                                NodGroup(nod, NMProj, nsmgr);
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Sparkline7_SeriesGroup']", nsmgr);
                                NodGroup(nod, "=Fields!shNMEntpr.Value", nsmgr);
                            }
                        }
                        else
                        if (nbut1 == 171 || nbut1 == 172 | nbut1 == 190)
                        {
                            if (!poMes)
                            {
                                doc.SelectSingleNode("//ms:Textbox[@Name='n1']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!KodDog.Value, countdistinct,Nothing)";
                                doc.SelectSingleNode("//ms:Textbox[@Name='n2']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!KodDog.Value, countdistinct,Nothing) & \".\" & RunningValue(Fields!shNMEntpr.Value, countdistinct,\"table1_Group1\")";
                                doc.SelectSingleNode("//ms:Textbox[@Name='n3']", nsmgr).ChildNodes[2].ChildNodes[0].FirstChild.FirstChild.FirstChild.InnerText = "=RunningValue(Fields!KodDog.Value, countdistinct,Nothing) & \".\" & RunningValue(Fields!shNMEntpr.Value, countdistinct,\"table1_Group1\") & \".\" & RunningValue(Fields!NomerSm.Value, countdistinct,\"table1_Group2\")";
                            }
                        }
                        break;
                    case 5:
                        RemGroup(doc, nsmgr, "=Fields!shNMEntpr.Value", "=Fields!Shifr.Value", "");
                        doc.SelectSingleNode("//ms:Textbox[@Name='nm2']/ms:Value", nsmgr).InnerText = "=Fields!NMComplex.Value";
                        doc.SelectSingleNode("//ms:Textbox[@Name='nm1']/ms:Value", nsmgr).InnerText = "";

                        break;
                    default:
                        RemGroup(doc, nsmgr, "=Fields!Shifr.Value", "=Fields!shNMEntpr.Value", "");
                        doc.SelectSingleNode("//ms:Textbox[@Name='nm1']/ms:Value", nsmgr).InnerText = "=Fields!NMComplex.Value";
                        doc.SelectSingleNode("//ms:Textbox[@Name='nm2']/ms:Value", nsmgr).InnerText = "";

                        break;
                }
                System.IO.TextReader reader = new System.IO.StringReader(doc.OuterXml);
                ReportViewer1.LocalReport.LoadReportDefinition(reader);
                report = ReportViewer1.LocalReport;
                pPeriod = new ReportParameter("pPeriod", my.UperName);
                report.SetParameters(new ReportParameter[] { pPeriod });
                if (nbut1 == 180 || nbut1 == 171 || nbut1 == 172 | nbut1 == 190 | nbut1 == 195)
                {
                    if (nbut1 == 180 | nbut1 == 195)
                    {
                        ReportParameter snds = new ReportParameter("nds", nds.ToString());
                            report.SetParameters(new ReportParameter[] { snds });
                    }
                    ReportParameter ssub = new ReportParameter("Sub", (!sub).ToString());
                    report.SetParameters(new ReportParameter[] { ssub });
                }
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(RDSnm, dv));
                if (!poMes && (nbut1 == 180 | nbut1 == 195)) { ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetSootvKs3",dvSub));}
                ReportViewer1.RefreshReport();
                return;
            }
            switch (nb)
            {
                //case 180:

                //    break;
                case 2001:
                    ReportParameter p6 = null; ReportParameter p5 = null;
                    try
                    {


                    ////pDirector = new ReportParameter("pDirector", "Ген. директор                       " + dv[0]["Director"]);
                    ////if (dvSub.Table.Rows.Count == 0) { doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Table[@Name='table2']/ms:Details/ms:Visibility/ms:Hidden", nsmgr).InnerText = "true"; };
                    
                    doc.SelectSingleNode("//ms:Textbox[@Name='t2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";

                    pPeriod = new ReportParameter("pPeriod",  my.UperName);
                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']", nsmgr).ChildNodes[5].FirstChild.InnerText = "false";
                    switch (Gr)
                    {                     
                        case 1:// основной
                            //doc.SelectSingleNode("//ms:Textbox[@Name='Un']/ms:Value", nsmgr).InnerText = "";
                            p17 = new ReportParameter("p13", "true");
                            p15 = new ReportParameter("p11", "true");
                            p6 = new ReportParameter("p6", "false");
                            p5 = new ReportParameter("p5", "false");
                            RemGroup(doc, nsmgr, "=Fields!RegNomer.Value", "=Fields!Naim.Value", "=Fields!NomSm.Value");
                            break;
                        case 14:
                            p17 = new ReportParameter("p13", "true");
                            p15 = new ReportParameter("p11", "false");
                            p5 = new ReportParameter("p5", "true");
                            p6 = new ReportParameter("p6", "false");
                            //doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Value", nsmgr).InnerText = "Участок";
                            doc.SelectSingleNode("//ms:Textbox[@Name='textbox68']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "=\"Итого по участку  \"+Fields!Department.Value";
                            doc.SelectSingleNode("//ms:Textbox[@Name='textbox14']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Участок";
                            doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                            doc.SelectSingleNode("//ms:Textbox[@Name='textbox50']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                            doc.SelectSingleNode("//ms:Textbox[@Name='Zak']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                            doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                            RemGroup(doc, nsmgr, "=Fields!Department.Value", "=Fields!IstFin.Value", "=Fields!Zak.Value");
                            break;
                        default:
                            p17 = new ReportParameter("p13", "true");
                            p15 = new ReportParameter("p11", "false");
                            p6 = new ReportParameter("p6", "true");
                            p5 = new ReportParameter("p5", "true");

                            string nm = dv.Table.Columns[(int)DC1.SelectedValue - 1].ColumnName;
                            string nm1 = dv.Table.Columns[(int)DC1.SelectedValue -1].ColumnName;
                            switch (Gr)
                            {   case 3:
                                    nm = dv.Table.Columns[4].ColumnName;
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Заказчик, договор";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                break;
                                case 2:
                                    nm1 = dv.Table.Columns[7].ColumnName;
                                    nm = dv.Table.Columns[5].ColumnName;
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Участок";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    break;
                                case 15:
                                    nm1 = dv.Table.Columns[7].ColumnName;
                                    nm = dv.Table.Columns[6].ColumnName;
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Прораб";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    break;
                                case 5: 
                                    p6 = new ReportParameter("p6", "false");
                                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']/ms:Visibility/ms:Hidden", nsmgr).InnerText = "true";
                                    nm1 = dv.Table.Columns[4].ColumnName;
                                    nm = dv.Table.Columns[5].ColumnName;
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox50']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='Zak']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                        doc.SelectSingleNode("//ms:Textbox[@Name='textbox68']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "=\"Итого по заказчику  \"+Fields!Zak.Value"; 
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox14']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Заказчик";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    break;
                                case 9:
                                    nm1 = "ShifrP";
                                    nm = "ShifrP";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Коды стройки";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']", nsmgr).ChildNodes[5].FirstChild.InnerText = "true";
                                    break;
                                 case 10:
                                    nm1 = "Shifr";
                                    nm = "Shifr";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Инвестиционные проекты";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']", nsmgr).ChildNodes[5].FirstChild.InnerText = "true";
                                    break;
                                case 11:
                                    nm1 = "Codir4";
                                    nm = "Codir4";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Инвестиционные проекты";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']", nsmgr).ChildNodes[5].FirstChild.InnerText = "true";
                                    break;
                                case 12:
                                        nm1 = "NomSm";
                                        nm = "NomSm";
                                        doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "Сметы";
                                        doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                        doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                        doc.SelectSingleNode("//ms:Textbox[@Name='t3']", nsmgr).ChildNodes[5].FirstChild.InnerText = "true";
                                        //p15 = new ReportParameter("p11", "false");
                                        //p6 = new ReportParameter("p6", "false");
                                        //p5 = new ReportParameter("p5", "true");
                                        break;
                                    default:
                                    doc.SelectSingleNode("//ms:Textbox[@Name='t3']/ms:Visibility/ms:Hidden", nsmgr).InnerText = "true";
                                    string nm2 = "Объект";
                                    if (Gr == 6) { nm2 = "Участок"; }
                                    if (Gr == 7) { nm2 = "Прораб"; }
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = nm2;
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = "";
                                    doc.SelectSingleNode("//ms:Textbox[@Name='textbox1']", nsmgr).ChildNodes[5].ChildNodes[3].InnerText = "None";
                                    break;
                            }
                            RemGroup(doc, nsmgr, "=Fields!" + nm1 + ".Value", "=Fields!" + nm + ".Value", "=Fields!" + nm1 + ".Value"); 
                            break;}
                        
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    System.IO.TextReader reader = new System.IO.StringReader(doc.OuterXml);
                    ReportViewer1.LocalReport.LoadReportDefinition(reader);
                    report = ReportViewer1.LocalReport;
                    report.SetParameters(new ReportParameter[] { p17, p15, pPeriod, pPred, p6, p5 }); 
                    //doc.Save("C:\\cis\\Reports\\TmpReport.rdlc");

                    //if (dvSub.Table.Rows.Count == 0) { doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Table[@Name='table2']/ms:Details/ms:Visibility/ms:Hidden", nsmgr).InnerText = "true"; };
                    break;
                case 2002:
                    try
                    {

                        //doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Tablix[@Name='table1'/ms:TablixRowHierarchy]", nsmgr).InnerXml 
                        //doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Tablix[@Name='table1']/ms:TablixRowHierarchy/ms:TablixMembers/ms:TablixMember", nsmgr)
                        //doc.SelectSingleNode("//ms:Group[@Name='table1_Details_Group']", nsmgr).InnerXml
                        //doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Tablix[@Name='table1']/ms:Details/ms:Visibility", nsmgr).InnerXml = "<Hidden xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition\">true</Hidden><ToggleItem xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition\">t3</ToggleItem>";
                        doc.SelectSingleNode("//ms:Group[@Name='table1_Details_Group']", nsmgr).ParentNode.ChildNodes[2].FirstChild.InnerText = "true";
                        doc.SelectSingleNode("//ms:Group[@Name='table1_Details_Group']", nsmgr).ParentNode.ChildNodes[2].LastChild.InnerText = "t3";
                        pDirector = new ReportParameter("pDirector", "Ген. директор                       " + (dv.Count  == 0 ? "": dv[0]["Director"]));
                    //if (dvSub.Table.Rows.Count == 0) { doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Table[@Name='table2']/ms:Details/ms:Visibility/ms:Hidden", nsmgr).InnerText = "true"; };
                    switch (Gr)
                    {
                        case 3:
                            p15 = new ReportParameter("p15", "false");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по договорам  за " + my.UperName);
                            RemGroup(doc, nsmgr, "=Fields!Type.Value", "=Fields!ZakName.Value", "=Fields!RegNomer.Value");
                            break;
                        case 4:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по объектам  за " + my.UperName);
                            RemGroup(doc, nsmgr, "=Fields!Type1.Value", "=Fields!Type1.Value", "=Fields!Object.Value");
                            break;
                        case 6:

                                p15 = new ReportParameter("p15", "true");
                                p17 = new ReportParameter("p17", "true");
                                pPeriod = new ReportParameter("pPeriod", " работ и затрат по участкам за " + my.UperName);
                                RemGroup(doc, nsmgr, "=Fields!Department.Value", "=Fields!Department.Value", "=Fields!Department.Value");
                                break;
                            case 7:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по прорабам за " + my.UperName);
                            RemGroup(doc, nsmgr, "=Fields!Department.Value", "=Fields!Department.Value", "=Fields!Prorab.Value");
                            break;
                        case 8:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по ист. фин.  за " + my.UperName);
                            RemGroup(doc, nsmgr, "=Fields!ИФ.Value", "=Fields!ИФ.Value", "=Fields!ZakName.Value");
                            break;
                        case 5:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по ист. фин.  за " + my.UperName);
                            RemGroup(doc, nsmgr, "=Fields!Type.Value", "=Fields!Type.Value", "=Fields!ZakName.Value");
                            break;
                        case 9:
                            p15 = new ReportParameter("p15", "false");
                            p17 = new ReportParameter("p17", "false");
                            pPeriod = new ReportParameter("pPeriod", " работ по Кодам стройки за " + my.UperName);
                            string g0 = "=Fields!ZakName.Value";
                            string g1 = "=Fields!Shifr.Value";
                            string g2 = "=Fields!Type.Value";
                             g3 = "=Fields!NMEntprForDM.Value";

                                RemGroup(doc, nsmgr, g1, g2, g3);
                                doc.SelectSingleNode("//ms:Textbox[@Name='t0']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g0;
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Type3']", nsmgr);
                                NodGroup(nod, g0, nsmgr);
                                break;
                         case 10:
                                p15 = new ReportParameter("p15", "false");
                                p17 = new ReportParameter("p17", "false");
                                pPeriod = new ReportParameter("pPeriod", " работ по Инвестиционным проектам за " + my.UperName);
                                g0 = "=Fields!kodproj.Value";
                                g1 = "=Fields!ZakName.Value";
                                g2 = "=Fields!Type.Value";
                                g3 = "=Fields!NMEntprForDM.Value";

                                RemGroup(doc, nsmgr, g1, g2, g3);
                                doc.SelectSingleNode("//ms:Textbox[@Name='t0']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g0;
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Type3']", nsmgr);
                                NodGroup(nod, g0, nsmgr);
                                break;
                          case 11:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "true");
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по Папкам портфелей за " + my.UperName);
                            g0 = "=Fields!Codir4.Value";
                            g1 = "=Fields!ZakName.Value";
                            g2 = "=Fields!Type.Value";
                            g3 = "=Fields!NMEntprForDM.Value";

                            RemGroup(doc, nsmgr, g1, g2, g3);
                            doc.SelectSingleNode("//ms:Textbox[@Name='t0']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g0;
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Type3']", nsmgr);
                            NodGroup(nod, g0, nsmgr);
                                //RemGroup(doc, nsmgr, "=Fields!Codir4.Value", "=Fields!Type.Value", "=Fields!ZakName.Value");
                                break;
                        case 12:
                            p15 = new ReportParameter("p15", "true");
                            p17 = new ReportParameter("p17", "true");
                            pPeriod = new ReportParameter("pPeriod", " работ по сметам за " + my.UperName);
                            g0 = "=Fields!NMEntprForDM.Value";
                            g1 = "=Fields!Type.Value"; 
                            g2 = "=Fields!NMEntprForDM.Value"; 
                            g3 = "=Fields!NomerSmeti.Value"; 

                            RemGroup(doc, nsmgr, g1, g2, g3);
                            doc.SelectSingleNode("//ms:Textbox[@Name='t0']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g0;
                            nod = doc.SelectSingleNode("//ms:Group[@Name='Type3']", nsmgr);
                            NodGroup(nod, g0, nsmgr);
                            //RemGroup(doc, nsmgr, "=Fields!Codir4.Value", "=Fields!Type.Value", "=Fields!ZakName.Value");
                            break;
                            case 13:
                                p15 = new ReportParameter("p15", "true");
                                p17 = new ReportParameter("p17", "false");
                                pPeriod = new ReportParameter("pPeriod", " работ и затрат по Папкам портфелей и участков за " + my.UperName);
                                g0 = "=Fields!Codir4.Value";

                                g1 = "=Fields!Type.Value";
                                g2 = "=Fields!Department.Value";
                                g3 = "=Fields!NMEntprForDM.Value";

                                RemGroup(doc, nsmgr, g1, g2, g3);
                                doc.SelectSingleNode("//ms:Textbox[@Name='t0']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g0;
                                nod = doc.SelectSingleNode("//ms:Group[@Name='Type3']", nsmgr);
                                NodGroup(nod, g0, nsmgr);
                                //p15 = new ReportParameter("p15", "true");
                                //p17 = new ReportParameter("p17", "false");
                                //pPeriod = new ReportParameter("pPeriod", " работ и затрат по участкам за " + my.UperName);
                                //RemGroup(doc, nsmgr, "=Fields!Codir4.Value", "=Fields!Codir4.Value", "=Fields!Department.Value");
                                break;
                            default:
                            p15 = new ReportParameter("p15", "true");
                            if (my.Ustr == "(соб. силы)")
                            {
                                p17 = new ReportParameter("p17", "true");
                            }
                            else
                            {
                                p17 = new ReportParameter("p17", "false");
                            }
                            pPeriod = new ReportParameter("pPeriod", " работ и затрат по заказчикам  за " + my.UperName);
                               
                                 RemGroup(doc, nsmgr, "=Fields!Type.Value", "=Fields!Type.Value", "=Fields!Naim.Value");
                                //doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Table[@Name='table1']/ms:Details/ms:Visibility", nsmgr).InnerXml = "<Hidden xmlns=\"http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition\">true</Hidden>";
                                doc.SelectSingleNode("//ms:Group[@Name='table1_Details_Group']", nsmgr).ParentNode.ChildNodes[2].FirstChild.FirstChild.Value = "true";
                                break;
                    }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    reader = new System.IO.StringReader(doc.OuterXml);
                    ReportViewer1.LocalReport.LoadReportDefinition(reader);
                    report = ReportViewer1.LocalReport;
                    report.SetParameters(new ReportParameter[] { p17, p15, pPeriod, pDirector, pPred, pf2orf3 });
                    //doc.Save("C:\\cis\\Reports\\TmpReport.rdlc");
                    break;
                case 2003:
                    
                    switch (Gr)
                    {
                        case 1:
                           g3 = "=Fields!ZakName.Value";

                            break;
                        case 2:
                            g3 = "=Fields!RegNomer.Value";
                            break;
                        case 3:
                            g3 = "=Fields!Object.Value";
                            break;
                        case 9:
                            g3 = "=Fields!Shifr.Value";
                            break;
                        case 10:
                            g3 = "=Fields!Department.Value";
                            break;
                    }      
                    doc.SelectSingleNode("//ms:Textbox[@Name='ZakName']/ms:Value", nsmgr).InnerText = g3;
                    nod = doc.SelectSingleNode("//ms:Report/ms:Body/ms:ReportItems/ms:Matrix[@Name='matrix1']/ms:RowGroupings/ms:RowGrouping/ms:DynamicRows/ms:Grouping[@Name='matrix1_ZakName']", nsmgr);
                    NodGroup(nod, g3, nsmgr);
                    reader = new System.IO.StringReader(doc.OuterXml);
                    ReportViewer1.LocalReport.LoadReportDefinition(reader);
                    pf2orf3 = new ReportParameter("pf2orf3", my.Ustr);
                    pPeriod = new ReportParameter("pPeriod", my.UperName); ;
                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pf2orf3 });
                    break;
                //case 182:
                case 166:

                    switch (Gr)
                    {
                        case 1:
                            p17 = new ReportParameter("p17", "false");
                            p15 = new ReportParameter("p15", "false");
                            break;
                        case 2:
                            p17 = new ReportParameter("p17", "false");
                            p15 = new ReportParameter("p15", "true");
                            break;
                        case 3:
                            p17 = new ReportParameter("p17", "true");
                            p15 = new ReportParameter("p15", "true");
                            break;
                    }
                    reader = new System.IO.StringReader(doc.OuterXml);
                    ReportViewer1.LocalReport.LoadReportDefinition(reader);
                    pPeriod = new ReportParameter("pPeriod", my.UperName); ;
                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, p15,p17});
                    break;
                default:
                    reader = new System.IO.StringReader(doc.OuterXml);
                    ReportViewer1.LocalReport.LoadReportDefinition(reader);
                    // pf2orf3 = new ReportParameter("pf2orf3", my.Ustr);
                    // pPeriod = new ReportParameter("pPeriod", my.UperName); ;
                    //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pPeriod, pf2orf3 });
                    break;
            }

            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(RDSnm, dv));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("WorkSvSub_WorkSv", dvSub));
            ReportViewer1.RefreshReport();
        }
        private void RemGroup(System.Xml.XmlDocument doc, System.Xml.XmlNamespaceManager nsmgr,string g1,string g2,string g3)
        {

            System.Xml.XmlNode nod;
            doc.SelectSingleNode("//ms:Textbox[@Name='t1']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText  = g1;
            nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group1']", nsmgr);
            NodGroup(nod, g1, nsmgr);
            doc.SelectSingleNode("//ms:Textbox[@Name='t2']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g2;
            nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group2']", nsmgr);
            NodGroup(nod, g2, nsmgr);
            if (g3 != "")
            {
                doc.SelectSingleNode("//ms:Textbox[@Name='t3']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g3;
                nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group3']", nsmgr);
                NodGroup(nod, g3, nsmgr);
            }
        }

        private void RemGroup1(System.Xml.XmlDocument doc, System.Xml.XmlNamespaceManager nsmgr, string g1, string g2, string g3)
        {

            System.Xml.XmlNode nod;
            doc.SelectSingleNode("//ms:Textbox[@Name='t4']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g1;
            nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group4']", nsmgr);
            NodGroup(nod, g1, nsmgr);
            doc.SelectSingleNode("//ms:Textbox[@Name='t5']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g2;
            nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group5']", nsmgr);
            NodGroup(nod, g2, nsmgr);
            if (g3 != "")
            {
                doc.SelectSingleNode("//ms:Textbox[@Name='t6']/ms:Paragraphs/ms:Paragraph/ms:TextRuns/ms:TextRun/ms:Value", nsmgr).InnerText = g3;
                nod = doc.SelectSingleNode("//ms:Group[@Name='table1_Group6']", nsmgr);
                NodGroup(nod, g3, nsmgr);
            }
        }
        private void NodGroup(System.Xml.XmlNode nod, string text, System.Xml.XmlNamespaceManager nsmgr)
        {
            nod.LastChild.LastChild.InnerText = text;
            nod.NextSibling.LastChild.FirstChild.InnerText = text;
        }
        private void DC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(DC1.SelectedValue) && ! poMes)
            {
                ShowRepMy();
                Supp(ReportViewer1.LocalReport, nbut1, (int)DC1.SelectedValue);
            }
        }



        private void reportViewer2_ReportExport(object sender, ReportExportEventArgs e)
        {
            my.ReportExport(sender, e, ReportViewer1);
//            if (e.Extension.Name == "Excel")
//            {
//                e.Cancel = true;
//                string mimeType;
//                string encoding;
//                string fileNameExtension;
//                string[] streams;
//                Microsoft.Reporting.WinForms.Warning[] warnings;

//                byte[] pdfContent = ReportViewer1.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
//                string pdfPath = Application.StartupPath + "\\"+my.Login+"reportBarcode.xls";
//                try
//                {
//                    System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
//                    pdfFile.Write(pdfContent, 0, pdfContent.Length);
//                    pdfFile.Close();
//                    System.Diagnostics.Process.Start(pdfPath);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(@"У Вас открыт файл предыдущего экспорта в Excel. 
//Закройте или переименуйте его!" + ex.Message);
//                }

//            };

        }



        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try
            {
            if ((nbut1 == 2002 | nbut1 == 2001) & dv.RowFilter != "" & dv.RowFilter != dvSub.RowFilter) { dvSub.RowFilter = dv.RowFilter; ReportViewer1.RefreshReport(); }
            }
            catch (Exception)
            {

            }

        }

        private void ReportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            my.ReportExport(sender, e, ReportViewer1);
//            if (e.Extension.Name == "EXCELOPENXML")
//            {
//                e.Cancel = true;
//                string mimeType;
//                string encoding;
//                string fileNameExtension;
//                string[] streams;
//                Microsoft.Reporting.WinForms.Warning[] warnings;

//                byte[] pdfContent = ReportViewer1.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
//                string pdfPath = Application.StartupPath + "\\" + my.Login + "reportBarcode.xls";
//                try
//                {
//                    System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
//                    pdfFile.Write(pdfContent, 0, pdfContent.Length);
//                    pdfFile.Close();
//                    System.Diagnostics.Process.Start(pdfPath);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(@"У Вас открыт файл предыдущего экспорта в Excel. 
//Закройте или переименуйте его!" + ex.Message);
//                }

//            };
        }

        private void ucFilter1_Load(object sender, EventArgs e)
        {

        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }










        //private void GetCustomizedReportDefinition(long nb)
        //{

        //System.IO.Stream stream = typeof(frmReps).Assembly.GetManifestResourceStream(@"SMRC.Reports.rSvodnij.rdlc");
        //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        //doc.Load(stream);

        //System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
        //nsmgr.AddNamespace("ms", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");

        //doc.SelectSingleNode("//ms:Textbox[@Name='Naim']/ms:Value", nsmgr).InnerText = "=First(Fields!Object.Value)";

        //System.IO.TextReader reader = new System.IO.StringReader(doc.OuterXml);
        //reportViewer2.Reset();
        //reportViewer2.LocalReport.DataSources.Add(new ReportDataSource(RDSnm, dv));
        //reportViewer2.LocalReport.LoadReportDefinition(reader);
        //Supp(reportViewer2.LocalReport, nb, 1);
        //this.reportViewer2.RefreshReport();
        //}


    }

}