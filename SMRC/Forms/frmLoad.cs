using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmLoad : Form
    {
        bool WithOpen;
        public frmLoad()
        {
            InitializeComponent();
        }


private void parse(String str, int typ, ref ToolStripMenuItem MenuTool) // разбор строки на подстроки
        {
        try {
            switch ( typ)
            {
                case 1:
                    string bnm = str;
                        my.sc.CommandText = "SELECT     bTools FROM         dbo.tABbands WHERE     (bNM = '" + str + "')";
                        my.cn.Open();
                        str = (string) my.sc.ExecuteScalar();
                       my.cn.Close();
                        string s = " SELECT      idAB, idtool, tNM, tCapt, tSubBand, orderNom from  tABtools WHERE     (idtool IN (SELECT Stroka FROM dbo.IzStr('" + str + "') AS IzStr_1) ) ";
                        if (bnm == "zak1")
                        {

                            s = s + " union all SELECT     0 AS idAB, IdEntpr + 1000 AS idtool, 'GP' AS tNM, shNMEntpr1 AS tCapt, '' AS tSubBand,OrderNom FROM         dbo.vGP WHERE     (IdEntpr > 0) ORDER BY  OrderNom Desc,tCapt ";
                            ToolStripMenuItem MenuTool2 = new ToolStripMenuItem("Генподряд");
                            MenuTool2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                            MenuTool2.Tag = 0;
                            MenuTool2.Name = "";
                            MenuTool.DropDownItems.Add(MenuTool2);
                            ToolStripSeparator MenuTool3 = new ToolStripSeparator();
                            MenuTool3.Tag = 0;
                            MenuTool3.Name = "";
                            MenuTool.DropDownItems.Add(MenuTool3);
                        }
                        else
                        if (bnm == "sub1")
                        {
                            s = " SELECT      idAB, idtool, tNM, tCapt, tSubBand, CASE idtool WHEN  1000 THEN 4 when 3004 then -2 ELSE 0 END as orderNom from  tABtools WHERE     (idtool IN (SELECT Stroka FROM dbo.IzStr('" + str + "') AS IzStr_1) ) ";
                            s = s + " union all SELECT DISTINCT TOP (100) PERCENT  0 AS Expr1, Sprav.dbo.tsEntpr.IdEntpr + 3000 AS Expr2, 'Sub' AS Expr3, Sprav.dbo.tsEntpr.shNMEntpr, '' AS Expr4, Sprav.dbo.tsEntpr.OrderNom FROM         Sprav.dbo.Dogovor INNER JOIN   Sprav.dbo.tsEntpr ON Sprav.dbo.Dogovor.IdZak = Sprav.dbo.tsEntpr.IdEntpr WHERE     (Sprav.dbo.Dogovor.Vnut = 1) AND (Sprav.dbo.tsEntpr.IdEntpr <> 0) and ordernom <>-1 ORDER BY OrderNom DESC,tCapt"; }
                        else
                        { s = s + " order by ordernom"; }
                        DataSet dsB = my.GetDS(s, my.sconn);
                    DataView dvB = new DataView();
                        dvB.Table = dsB.Tables[0];
                        for (int i1 = 0 ; i1<=dvB.Count - 1; i1++)
                        {
                            ToolStripMenuItem MenuTool1 = new ToolStripMenuItem((string)dvB[i1][3], null,  new  EventHandler(this.HelpMenu_Click));
                            MenuTool1.Tag = (int)(dvB[i1][1]);
                            MenuTool1.Name = (string)dvB[i1][2];
                            //MessageBox.Show((string)dvB[i1][2]);
                            if (bnm =="Grafik")
                            {
                                my.cn.Open();
                                my.sc.CommandText = "SELECT     1 FROM   dostup.dbo.v_Dostup  WHERE     (id_ac = 233) AND Login = '" + my.Login + "'";
                             if (my.sc.ExecuteScalar() != null)
                                 MenuTool1.Enabled = true;
                             else
                                 MenuTool1.Enabled =false;
                            }
                            my.cn.Close();
                            MenuTool1.Image = (System.Drawing.Image)SMRC.Properties.Resources.ResourceManager.GetObject((string)MenuTool1.Name);
                            MenuTool.DropDownItems.Add(MenuTool1);
                            if (dvB[i1]["tSubBand"] != DBNull.Value && (string)dvB[i1]["tSubBand"] != "") { parse((string)dvB[i1]["tSubBand"], 1, ref MenuTool1); };
                        }
                        
                    break;
            }

        }
        catch (InvalidCastException e)
        {
            MessageBox.Show("MDI ABcreate-parse: " + str + e.Message);
        }
        }
        private void frmLoad_Load(object sender, EventArgs e)
        {
            WithOpen = true;
            my.FillDC(this.cUpred, 8, " and id_us = " + my.Id_us);
            DataSet ds = new DataSet();
            my.ObnPer(cUper);
            my.RemStrSost();
            ABCreate();
            cUper.SelectedValue = my.Uper;
            cUpred.SelectedValue = my.identpr;

            WithOpen = false;

        }
private void ABCreate()
{    
       DataSet ds = my.GetDS(" SELECT     * from  tABbands where bfrm = 1 and bType <= 1 order by id desc", my.sconn);
       DataView dv = new DataView();
        dv.Table = ds.Tables[0];
        for (int i = 0; i <= dv.Count-1 ; i++)
        {
            MenuStrip ms = new MenuStrip();
            ms.Name = "MenuStrip" + i;
            ms.Dock = DockStyle.Top;
            this.Controls.Add(ms);
            DataView dvB = new DataView();
            DataSet dsB;
            if ((byte)dv[i]["bType"] == 0)
            {
                dsB = my.GetDS(" SELECT     * from  tABbands WHERE     (bNM IN (SELECT Stroka FROM dbo.IzStr('" + dv[i]["bChBands"] + "') AS IzStr_1) ) order by OrderNom ", my.sconn);
                dvB.Table = dsB.Tables[0];
                for (int i1 = 0; i1 <= dvB.Count - 1; i1++)
                {
                    ToolStripMenuItem MenuTool = new ToolStripMenuItem((string)dvB[i1][2], null,  new  EventHandler(this.HelpMenu_Click));
                    MenuTool.Tag = (int)dvB[i1][0];
                    MenuTool.Name = (string)dvB[i1][1];
                    ms.Items.Add(MenuTool);
                    if (dvB[i1]["btools"] != DBNull.Value && (string)dvB[i1]["btools"] != "") { parse((string)dvB[i1]["bNm"], 1, ref MenuTool); }
                    MenuTool.Image = (System.Drawing.Image) SMRC.Properties.Resources.ResourceManager.GetObject(MenuTool.Name);
                    //MenuTool.Enabled = false;
                }
            }
            else
            {
                dsB = my.GetDS(" SELECT     * from  tABtools WHERE     (idtool IN (SELECT Stroka FROM dbo.IzStr('" + dv[i]["btools"].ToString() + "') AS IzStr_1) ) order by OrderNom  ", my.sconn);
                dvB.Table = dsB.Tables[0];
                for (int i1 = 0; i1<= dvB.Count - 1; i1++)
                {

                    switch ((string)dvB[i1][2])
                    {
                        case "Upred":
                            ToolStripControlHost cb3 = new ToolStripControlHost(cUpred);
                            ms.Items.Add(cb3);
                            break;
                        case "period":
                            ToolStripControlHost cb4 = new ToolStripControlHost(cUper);
                            ms.Items.Add(cb4);
                            break;
                        default:
                            ToolStripMenuItem MenuTool = new ToolStripMenuItem((string)dvB[i1][3], null, new EventHandler(HelpMenu_Click));
                            MenuTool.Tag = (int)dvB[i1][1];
                            MenuTool.Name = (string)dvB[i1][2];
                            MenuTool.Image = (System.Drawing.Image)SMRC.Properties.Resources.ResourceManager.GetObject(MenuTool.Name);
                            ms.Items.Add(MenuTool);
                            if (dvB[i1]["tSubBand"] != DBNull.Value && (string)dvB[i1]["tSubBand"] != "") { parse((string)dvB[i1]["tSubBand"], 1, ref MenuTool); }
                            break;
                    }
                }
            }
            dsB.Tables.Clear();
            dvB.Table.Clear();
            if (ms.Items["MMWindows"] != null) { ms.MdiWindowListItem = (ToolStripMenuItem) ms.Items["MMWindows"]; this.MainMenuStrip = ms; }
        }

    }
private void HelpMenu_Click(object sender, System.EventArgs e)
{
    ToolStripMenuItem item = (ToolStripMenuItem)sender;
    my.Szap = "";
    Console.Write(item.Name);
    if (item.Name != "SootvA0" & item.Name != "Spr")
        if (item.Name != "Reestr")
        {
//Console.Write( item.Name);
            switch (item.Name)
            {
                        //case "Prog1":
                        //    {
                        //        About fr = new About();
                        //        fr.ShowDialog();
                        //    }
                        //    break;
                        case "frmSogl":
                            try
                            {
                                //string s = "exec sRInFileNZP '','','','test','" + DateTime.Today.Year.ToString() + "','nz'";
                                my.Nbut = 1;
                                if (!my.isFormInMdi("frmSogl", my.Nbut, this))
                                {
                                    frmSogl fr = new frmSogl();
                                    fr.Tag = my.Nbut;
                                    fr.MdiParent = my.MDIForm;
                                    fr.Dock = DockStyle.Fill;
                                    //  fr.GrafikUni(s);
                                    fr.Show();
                                }

                                //  MessageBox.Show("Готово");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case "frmVibList":
                            try
                            {


                                string s = "exec sRInFileNZP '','','','test','" + DateTime.Today.Year.ToString() + "','nz'";
                                my.Nbut = 1;
                                if (!my.isFormInMdi("frmVibList", my.Nbut, this))
                                {
                                    frmVibList fr = new frmVibList();
                                    fr.Tag = my.Nbut;
                                    fr.MdiParent = my.MDIForm;
                                    fr.GrafikUni(s);
                                    fr.Show();
                                }

                                //  MessageBox.Show("Готово");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        case "Upload":
                            try
                            {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = "C:\\cis\\Сервис\\Web1SSvod.exe";
                            proc.Start();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                        case "Dostup":
                            if (!my.isFormInMdi("frmDostup", (int)item.Tag, this))
                            {
                                frmDostup fr = new frmDostup();
                                fr.Tag = (int)item.Tag;
                                my.Nbut = (int)item.Tag; ;
                                fr.MdiParent = my.MDIForm;
                                fr.Show();
                            }
                            break;
                        case "SpUgSh":
                            if (!my.isFormInMdi("frmOSR", (int)item.Tag, this))
                            {
                                frmOSR fr = new frmOSR();
                                fr.Tag = (int)item.Tag;
                                my.Nbut = (int)item.Tag; ;
                                fr.MdiParent = my.MDIForm;
                               string withupstr = my.ExeScalar("select 1 from dostup.dbo.v_Dostup where Login = '" + my.Login + "'  and id_ac=217");
                                fr.WithUp = (withupstr == "" ? false : true);
                                fr.Show();
                            }
                            break;
                        case "MSProject":
                    if (!my.isFormInMdi("frmMSProject", (int)item.Tag, this))
                    {
                        //frmMSProject fr = new frmMSProject();
                        //fr.Tag = (int)item.Tag;
                        //my.Nbut = (int)item.Tag; ;
                        //fr.MdiParent = my.MDIForm;
                        //fr.Show();
                    }
                    break;
                        case "DogOpyt":
                            my.Szap = "exec sDogOpyt";
                            frmReps fr1 = new frmReps();
                            my.Pform = this;
                            fr1.MdiParent = my.MDIForm;
                            fr1.Tag = (int)item.Tag;
                            my.Nbut = (int)item.Tag;

                            fr1.Show();
                            break;
                        case "frmTP":
                    if (!my.isFormInMdi("frmTP", (int)item.Tag, this))
                    {
                        frmTP fr = new frmTP();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "LinkWrk":
                    if (!my.isFormInMdi("frmLinkWRK", (int)item.Tag, this))
                    {
                        frmLinkWRK fr = new frmLinkWRK();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "Struc":
                    if (!my.isFormInMdi("frmStrucProg", (int)item.Tag, this))
                    {
                        frmStrucProg fr = new frmStrucProg();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "GrafikMatch":
                    if (!my.isFormInMdi("frmGrafikMatch", (int)item.Tag, this))
                    {
                        frmGrafikMatch fr = new frmGrafikMatch();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "ScanSm":
                    if (!my.isFormInMdi("frmScanSm", (int)item.Tag, this))
                    {
                        frmScanSm fr = new frmScanSm();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "PlanSmA0":
                    if (!my.isFormInMdi("frmPlanSmA0", (int)item.Tag, this))
                    {
                        frmPlanSmA0 fr = new frmPlanSmA0();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "Hierar":
                    if (!my.isFormInMdi("frmVibComplex", (int)item.Tag, this))
                    {
                        frmVibComplex fr = new frmVibComplex();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "PerechSm":
                    if (!my.isFormInMdi("frmVibIspSm", (int)item.Tag, this))
                    {
                        frmVibIspSm fr = new frmVibIspSm();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "RPredNZ":
                            if (!my.isFormInMdi("frmVibPred", (int)item.Tag, this))
                            {
                                frmVibPred fr = new frmVibPred();
                                fr.Tag = (int)item.Tag;
                                my.Nbut = (int)item.Tag; ;
                                fr.MdiParent = my.MDIForm;
                                fr.Show();
                            }
                            break;
                        case "frmVibTest":
                            if (!my.isFormInMdi("frmVibTest", (int)item.Tag, this))
                            {
                                frmVibTest fr = new frmVibTest();
                                fr.Tag = (int)item.Tag;
                                fr.Text = item.Text;
                                my.Nbut = (int)item.Tag; ;
                                fr.MdiParent = my.MDIForm;
                                fr.Dock = DockStyle.Fill;
                                fr.Show();
                            }
                            break;
                        case "RPredGP":
                            if (!my.isFormInMdi("frmVibGP", (int)item.Tag, this))
                            {
                                frmVibGP fr = new frmVibGP();
                                fr.Tag = (int)item.Tag;
                                fr.Text = item.Text;
                                my.Nbut = (int)item.Tag; ;
                                fr.MdiParent = my.MDIForm;
                                fr.Show();
                            }
                            break;
                        case "RInv":
                    if (!my.isFormInMdi("frmVibInv", (int)item.Tag, this))
                    {
                        frmVibInv fr = new frmVibInv();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "RPred":
                case "RSmet":
                case "RSmetF2F3":
                    //fr;
                    if (!my.isFormInMdi("frmVibSmet", (int)item.Tag, this))
                    {
                        frmVibSmet fr = new frmVibSmet();
                        fr.Tag = (int)2001;
                                fr.Text = item.Text;
                                my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        if (item.Name == "RPred")
                        {
                            fr.Height = 111;
                        }
                        fr.Show();
                        if (my.Nbut == 2001 | my.Nbut == 170 | my.Nbut == 2020 ) { fr.Text = "Сметное разложение"; } else { if (my.Nbut == 2002) { fr.Text = "Сводные"; } };
                    }
                    break;
                    case "RPeriod":
                        if (!my.isFormInMdi("frmVibPeriod", (int)item.Tag, this))
                        {
                            frmVibPeriod fr = new frmVibPeriod();
                            fr.Text = item.Text;
                            fr.Tag = (int)item.Tag;
                            fr.Nbut = (int)item.Tag;
                            my.Nbut = (int)item.Tag; 
                            fr.MdiParent = my.MDIForm;
                            fr.Show();
                        }
                        break;
                        case "RPer":
                            if (!my.isFormInMdi("frmVibPer", (int)item.Tag, this))
                            {
                                frmVibPer fr = new frmVibPer();
                                fr.Text = item.Text;
                                fr.Tag = (int)item.Tag;
                               // fr.Nbut = (int)item.Tag;
                                my.Nbut = (int)item.Tag;
                                fr.MdiParent = my.MDIForm;
                                fr.Show();
                            }
                            break;
                        case "A0":
                    if (!my.isFormInMdi("frmSootvA0", (int)item.Tag, this))
                    {
                        frmSootvA0 fr = new frmSootvA0();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "PlanGen":
                    if (!my.isFormInMdi("frmPlanGen", (int)item.Tag, this))
                    {
                        frmPlanGen fr = new frmPlanGen();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                    
                case "Pr":
                    if (!my.isFormInMdi("frmSootvPr", (int)item.Tag, this))
                    {
                        frmSootvPr fr = new frmSootvPr();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "A0LKV":
                    if (!my.isFormInMdi("frmA0LKV", (int)item.Tag, this))
                    {
                        frmA0LKV fr = new frmA0LKV();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "TM":
                    if (!my.isFormInMdi("frmPlans", (int)item.Tag, this))
                    {
                        frmTemPlans fr = new frmTemPlans();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "wf3":
                    {
                        frmForF3 fr = new frmForF3();
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "GP":
                    if (!my.isFormInMdi("frmDog", (int)item.Tag, this))
                    {
                        frmDog fr = new frmDog();
                        fr.Tag = (int)item.Tag;
                        my.Nbut = (int)item.Tag - 1000; ;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                    case "Sub":
                        if (!my.isFormInMdi("frmActsSub", (int)item.Tag, this))
                        {
                            frmActsSub fr = new frmActsSub();
                            fr.Tag = (int)item.Tag;
                            my.Nbut = (int)item.Tag - 3000; 
                            fr.MdiParent = my.MDIForm;
                            fr.Show();
                        }
                        break;
                        case "SSR1":
                    if (!my.isFormInMdi("frmSSRSm", 0, this))
                    {
                        frmSSRSm fr = new frmSSRSm();
                        fr.Tag = (int)0;
                        fr.nbut1 = 0;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "Koef":
                    if (!my.isFormInMdi("frmDN", 0, this))
                    {
                        frmDN fr = new frmDN();
                        fr.Tag = (int)0;
                        fr.nbut1 = 0;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "frmInvDog":
                    if (!my.isFormInMdi("frmInvDog", 0, this))
                    {
                        frmInvDog fr = new frmInvDog();
                        fr.Tag = (int)0;
                        fr.MdiParent = my.MDIForm;
                        fr.Show();
                    }
                    break;
                case "SpUgPr":
                    my.Szap = "";
                    my.Nbut = (int)item.Tag;
                    //my.Nbut = 8;
                    bool withup = true;
                    if (my.Nbut == 8 || my.Nbut == 721 || my.Nbut == 724) { withup = false; }
                    //if (my.Nbut == 704) { if (my.UserInGroup(my.Id_us,234)) ; }
                    if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
                    {
                        my.showSprDGV(my.Nbut, withup, true);
                    }
                    break;
                case "frmReasons":
                    my.Szap = "";
                    my.Nbut = (int)item.Tag;
                    //my.Nbut = 8;
                    withup = true;
                    //if (my.Nbut == 704) { if (my.UserInGroup(my.Id_us,234)) ; }
                    if (!my.isFormInMdi("frmReasons", my.Nbut, this))
                    {
                        frmReasons fr = new frmReasons();
                        fr.Tag = (int)0;
                        fr.MdiParent = my.MDIForm;
                        fr.Dock = DockStyle.Fill;
                        fr.Show();
                    }
                    break;
                        case "PreviewAkt":
                    if (!my.isFormInMdi("frmActs", my.Nbut, this))
                    {
                        Form fr = new frmActs();
                        fr.Tag = 0;
                        fr.MdiParent = my.MDIForm;
                        fr.Dock = DockStyle.Fill;
                        fr.Show();
                        int w = fr.Width;
                        int h = fr.Height;
                        fr.Dock = DockStyle.None;
                        fr.Width = w;
                        fr.Height = h;
                    } break;
                case "WindH":
                    LayoutMdi(MdiLayout.TileHorizontal); break;
                case "WindV":
                    LayoutMdi(MdiLayout.TileVertical); break;
                case "WindC":
                    LayoutMdi(MdiLayout.Cascade); break;
                case "Prog":
                            {
                                About fr = new About();fr.ShowDialog();
                                //frmReasons fr = new frmReasons(); fr.Show();


                            }
                            //if (!my.isFormInMdi("frmDiagram", 0, this))
                            //{
                            //    frmDiagram fr = new frmDiagram();
                            //    fr.Tag = (int)0;
                            //    fr.MdiParent = my.MDIForm;
                            //    fr.Show();
                            //}
                            //if (my.MDIFormCont.Visible)
                            //{
                            //    while (my.MDIFormCont.Controls.Count != 0)
                            //    {

                            //        foreach (Control fr in my.MDIFormCont.Controls)
                            //        {
                            //            //MessageBox.Show(fr.Name);
                            //            if (fr.GetType().ToString().Contains("frm"))
                            //            {
                            //                //  my.MDIFormCont.Controls.Remove(fr);
                            //                //((Form)  fr).TopLevel = true;
                            //                ((Form)fr).MdiParent = my.MDIForm;
                            //                ((Form)fr).FormBorderStyle = FormBorderStyle.Sizable;
                            //                ((Form)fr).Show();
                            //            }
                            //            else { my.MDIFormCont.Controls.Remove(fr); }

                            //        }
                            //    }
                            //    my.MDIFormCont.Hide();
                            //}
                            //else
                            //{
                            //    System.Windows.Forms.Splitter splitter1;
                            //    foreach (Form fr in my.MDIForm.MdiChildren)
                            //    {
                            //        if (!fr.Equals(my.MDIFormCont))
                            //        {
                            //            fr.MdiParent = null; fr.TopLevel = false;
                            //            my.MDIFormCont.Controls.Add(fr);
                            //            fr.Dock = DockStyle.Left;
                            //            fr.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            //            fr.Show();
                            //            splitter1 = new System.Windows.Forms.Splitter();
                            //            splitter1.Dock = System.Windows.Forms.DockStyle.Left;
                            //            //splitter1.BackColor = System.Drawing.Color.Azure;
                            //            splitter1.Size = new System.Drawing.Size(10, 562);
                            //            splitter1.BorderStyle = BorderStyle.FixedSingle;
                            //            my.MDIFormCont.Controls.Add(splitter1);
                            //        }
                            //    }
                            //    my.MDIFormCont.MdiParent = my.MDIForm;
                            //    my.MDIFormCont.Dock = DockStyle.Fill;
                            //    //my.MDIFormCont.BackColor = System.Drawing.Color.Lavender;
                            //    my.MDIFormCont.FormBorderStyle = FormBorderStyle.None;
                            //    my.MDIFormCont.Show();
                            //}
                            break;
                case "Exit1":
                    Application.Exit();
                    return;
                default:
                    //   LayoutMdi(MdiLayout.Cascade);
                    break;


            }

        }
}
        private void UNastr()
        {
            if (WithOpen) return;
            try
            {
                
                my.identpr = my.Val((cUpred.SelectedValue == null ? "0" : cUpred.SelectedValue.ToString()));
                my.UpredName = cUpred.Text;
                my.cn.Open();
                my.sc.CommandText = "select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + my.identpr;
                my.Upred = my.sc.ExecuteScalar().ToString();
                //my.cn.Close();
                //cUper.SelectedValue = (DateTime)(cUper.SelectedValue == null || cUper.SelectedValue.ToString() == "System.Data.DataRowView" ? DateTime.Today.AddDays(-DateTime.Today.Day + 1) : cUper.SelectedValue);
                my.Uper = (DateTime)(cUper.ValueMember == "" ? DateTime.Today.AddDays(-DateTime.Today.Day + 1) : cUper.SelectedValue);
                my.UperName = cUper.Text;
                my.sc.CommandText = "set dateformat dmy Update SluPolzRazn set idEntpr ='" + my.identpr + "', Period='" + my.Uper + "',Pred ='"+ my.Upred + "'  where Id_us=" + my.Id_us;
                //my.cn.Open();
                my.sc.ExecuteScalar();
                my.cn.Close();
                my.MyStr[0] = " identpr =" + my.identpr + " and month(Period) =" + my.Uper.Month + " and Year(Period) = " + my.Uper.Year;
                my.MyStr[1] = my.MyStr[0] + " and id_us=" + my.Id_us;
                my.MyStr[2] = " identpr =" + my.identpr + " ";
                my.RemStrSost();
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.Message);
                if ((int)my.cn.State == 1)
                {
                    my.cn.Close();
                }

            }
        }

        private void cUpred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!WithOpen)
            {
                UNastr();
                foreach (Form fr in my.MDIForm.MdiChildren)
                {
                    switch (fr.Name)
                    {
                        case "frmActs":
                            ((frmActs)fr).spisok();
                            break;
                        //case "frmPlanSmA0":
                        //    ((frmPlanSmA0)fr).spisok();
                        //    break;
                        //case "frmPlanGen":
                        //    ((frmPlanGen)fr).spisok();
                        //    break;
                    }
                }
            }
        }

        private void frmLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            my.ExeScalar("exec Access.dbo.sUserLogOut '" + my.Login + "',33");
            //my.cn.Open();
            //my.sc.CommandText = "exec Access.dbo.sUserLogOut '" + my.Login + "',33";
            //my.sc.ExecuteScalar();
            //my.cn.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }   
}
   


