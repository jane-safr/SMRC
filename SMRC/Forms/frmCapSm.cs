using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC
{
    public partial class frmCapSm : Form
    {
        public Int32 idsm = 0; public int IdSmPr = 0;string iddog = "0"; string idzak = "0";
        DataView dvObj; bool Rec;
        int idOSR = 0; int idobject = 0;
        bool WithOpen; bool BlockT; bool GrGCO;
        //String Id_UsName; String SzapN; String widthStr; String headStr;
        //SqlConnection my.cn; SqlCommand my.sc;  String my.sconn = "Initial Catalog=smr;User ID=prog;Password=prog;Data Source=SQL\\A0;Connect Timeout=100;";
        int Id_us = -1; long idArch;
        DataSet dsStPred; SqlDataAdapter daStPred; string Login;
        DataSet dsVidRab; SqlDataAdapter daVidRab;

        public frmCapSm()
        {
            InitializeComponent();
        }

        private void frmCapSm_Load(object sender, EventArgs e)
        {
            Console.Write("start " + DateTime.Now.TimeOfDay.ToString() + "\n");
            GrGCO = false;
            Login = SystemInformation.UserName.ToString();
            my.cn = new SqlConnection(my.sconn);
            my.cn.Open();
            my.sc = new SqlCommand("select * from dostup.dbo.v_Dostup where Login = '" + Login + "' ", my.cn);

            int dostup = (int)my.sc.ExecuteScalar();
            SqlDataReader sd = my.sc.ExecuteReader();
            sd.Read();
            Id_us = (int)sd["id_us"];
            //my.Id_UsName = sd["fio"].ToString();
            //my.cn.Close();
            sd.Close();

            WithOpen = true;
            Dgv1.AllowUserToAddRows = false; Dgv1.AllowUserToDeleteRows = false; Dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            DataSet dsObj = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT     idobj  FROM         sprav.dbo.SprObject WHERE     (Vib = 1)", my.sconn);
            da.Fill(dsObj);
            dvObj = new DataView();
            dvObj.Table = dsObj.Tables[0];
            my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 39";
            //my.cn.Open();
            if (my.sc.ExecuteScalar() == null) { chRecalc.Enabled = false; Rec = false; } else { Rec = true; }

            my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 40";

            if (my.sc.ExecuteScalar() == null) { chWorkFull.Enabled = false; } else { chWorkFull.Enabled = true; }

            my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 48";
            if (my.sc.ExecuteScalar() == null) { chBlock.Enabled = false; NeIspolzovat.Enabled = false; } else { chBlock.Enabled = true; NeIspolzovat.Enabled = true; }

            my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 41";

            if (my.sc.ExecuteScalar() == null)
            {
                OSRtxt.Enabled = false;
                groupBox1.Enabled = false;
                BlockT = false;
            }
            else
            {
                BlockT = true;
                OSRtxt.Enabled = true;
                groupBox1.Enabled = true;
                chInSmr.Enabled = true;
                toolStrip2.Enabled = true;
            }
            my.cn.Close();
            //Console.Write("middle " + DateTime.Now.TimeOfDay.ToString() + "\n");
            my.FillDC(IdStatus, 41, " and vid = 11 ");
            my.FillDC(IdZak, 7, " and    ((Bits & 1) > 0)");
            my.FillDC(IdGP, 7, " and  bits & 4 > 0 or identpr = 0 ");
            my.FillDC(IdPodr, 7, " and  bits & 3 > 0 or identpr = 0 ");
            my.FillDC(IdIstFin, 18, " ");
            my.FillDC(IdPrice, 30, " ");
            my.FillDC(idWRK, 31, " ");
            my.FillDC(IdRazr, 7, " and  sprav.dbo.isb(Bits,10) = 1 or identpr = 0  or identpr = 0   ");
            my.FillDC(IdWrkVid, 32, " ");
            my.FillDC(IdInvPr, 66, " ");
            my.FillDC(IdMark, 41, " and vid = 23 ");
            my.FillDC(IdStatusZak, 76, " ");
            my.FillDC(IdNSI, 41, " and vid= 21 ");
            my.FillDC(IdBlock, 41, " and vid= 22 ");
            my.FillDC(IdReason, 79, "");

            //FillDC(IdSmPr, 42, " and IdSm = 0 OR  idStatus = 1");
            //Console.Write("end fill " + DateTime.Now.TimeOfDay.ToString() + "\n");


            if (!my.UserInGroup(Id_us, 41))
            {
                OSRtxt.Enabled = false;
                groupBox1.Enabled = false;
                BlockT = false;
            }
            else
            {
                BlockT = true;
                OSRtxt.Enabled = true;
                groupBox1.Enabled = true;
                chInSmr.Enabled = true;
                toolStrip2.Enabled = true;
                GrGCO = true;
            }
            Console.Write("start spisok " + DateTime.Now.TimeOfDay.ToString() + "\n");
            spisok();
            Console.Write("end spisok " + DateTime.Now.TimeOfDay.ToString() + "\n");
            if (NeIspolzovat.Checked) { chBlock.Enabled = false; }
            WithOpen = false;
            IdDog_SelectedIndexChanged(null, null);
            Console.Write("end " + DateTime.Now.TimeOfDay.ToString() + "\n");
            this.Focus();
        }
        public void spisok()
        {
            if (idsm == 0) return;
            SqlConnection cn = new SqlConnection(my.sconn);
            SqlCommand sc = new SqlCommand("select * from sprav.dbo.vtSmeti where IdSm=" + idsm, cn);

            cn.Open();
            SqlDataReader DRd = sc.ExecuteReader();
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter("select * from sprav.dbo.vtSmeti where IdSm=" + idsm,my.sconn); 
            //da.Fill(ds);

            DRd.Read();
            BeginWRK.Text = (DRd["BeginWRK"] == null ? "" : DRd["BeginWRK"].ToString());
            EndWRK.Text = (DRd["EndWRK"] == null ? "" : DRd["EndWRK"].ToString());
            if ((byte)DRd["isSSR"] == 1) { radioButton1.Checked = true; } else { radioButton1.Checked = false; }
            if ((byte)DRd["isSSR"] == 2) { radioButton2.Checked = true; } else { radioButton2.Checked = false; }
            LastLogin.Text = (string)DRd["LastLogin"];
            LastLoginOSR.Text = (string)DRd["LastLoginOSR"];
            LastLoginInvPr.Text = (string)DRd["LastLoginInvPr"];
            //Console.Write("spisokLastLoginOSR " + DateTime.Now.TimeOfDay.ToString() + "\n");

            idOSR = (int)DRd["idOSR"] + 1000;
            if (idOSR == 0) { idOSR = -1; }
            Nomer.Text = (string)DRd["Nomer"];
            Prim.Text = (string)DRd["Prim"];
            //Mat.Text = DRd["Mat"].ToString();
            NMSmeti.Text = (string)DRd["NMSmeti"];
            NomerPO.Text = (string)DRd["NomerPO"];

            IdStatus.SelectedValue = DRd["IdStatus"];
            IdInvPr.SelectedValue = DRd["IdInvPr"];
            IdMark.SelectedValue = DRd["IdMark"];
            idzak = DRd["IdZak"].ToString();
            IdZak.SelectedValue = (int)DRd["IdZak"];

            //Console.Write("spisokLastLoginOSR0 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            Ndoc.Text = (string)DRd["ndoc"];
            OSRtxt.Text = (string)DRd["OSRtxt"];
            IdObj.SelectedValue = DRd["IdObj"];

            //Console.Write("spisokLastLoginOSR01 " + DateTime.Now.TimeOfDay.ToString() + "\n");
            IdNSI.SelectedValue = DRd["IdNSI"];
            IdBlock.SelectedValue = DRd["IdBlock"];
            IdReason.SelectedValue = DRd["IdReason"];
            //FillDC(IdSmPr, 42, " and IdSm = 0 OR  idStatus = 1");
            IdSmPr = (int)DRd["IdSmPr"];
            NMUtvSm.Text = (string)DRd["NMUtvSm"];

           // Console.Write("spisokLastLoginOSR02 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            IdGP.SelectedValue = DRd["IdGP"];
            //FillDC(IdPodr, 7, " and  bits & 16 > 0 or identpr = 0 ");

           // Console.Write("spisokLastLoginOSR1 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            IdPodr.SelectedValue = DRd["Idpod"];

            IdIstFin.SelectedValue = DRd["IdIstFin"];

            IdPrice.SelectedValue = DRd["IdPrice"];
            IdStatusZak.SelectedValue = DRd["IdStatusZak"];
            IdCeh.SelectedValue = DRd["IdCeh"];
            ObnDog();
            iddog = DRd["IdDog"].ToString();
            IdDog.SelectedValue = DRd["IdDog"];

            idWRK.SelectedValue = DRd["idWRK"];

            IdRazr.SelectedValue = DRd["IdRazr"];

            IdWrkVid.SelectedValue = DRd["IdWrkVid"];

            PunktTiTulStr.Text = (string)DRd["PunktTiTulStr"];
            Osn.Text = (string)DRd["Osn"];
            InvNomer.Text = (string)DRd["InvNomer"];

           // Console.Write("spisokInvNomer " + DateTime.Now.TimeOfDay.ToString() + "\n");

            chInSmr.Checked = (bool)DRd["InSmr"];
            // страница доп. данных 
            KoefLZ.Text = DRd["KoefLZ"].ToString();
            PonKoef.Text = (DRd["PonKoef"] == null ?  "": DRd["PonKoef"].ToString());
            BazStObor.Text = DRd["BazStObor"].ToString();
            SumBazOr.Text = DRd["SumBazOr"].ToString();
            SumTekOr.Text = DRd["SumTekOr"].ToString();
            Sum91Or.Text = DRd["Sum91Or"].ToString();
            SumMR.Text = DRd["SumMR"].ToString();
            SumMR2001.Text = DRd["SumMR2001"].ToString();

           // Console.Write("SumMR2001 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            SumProchz.Text = DRd["SumProchz"].ToString();
            SumMR91.Text = DRd["SumMR91"].ToString();
            SumProchz91.Text = DRd["SumProchZ91"].ToString();
            SumMRTek.Text = DRd["SumMRTek"].ToString();
            SumProchzTek.Text = DRd["SumProchZTek"].ToString();
            StObor91.Text = DRd["StObor91"].ToString();
            StOborTek.Text = DRd["StOborTek"].ToString();
            SumProchz2001.Text = DRd["SumProchZ2001"].ToString();
            StObor2001.Text = DRd["StObor2001"].ToString();
            Sum2001.Text = DRd["Sum2001"].ToString();

            //Console.Write("Sum2001 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            SumProchZOst08.Text = DRd["SumProchZOst08"].ToString();
            StOborOst08.Text = DRd["StOborOst08"].ToString();
            SumOst08.Text = DRd["SumOst08"].ToString();
            SumMROst08.Text = DRd["SumMROst08"].ToString();
            SmZp.Text = DRd["SmZp"].ToString();
            NTR.Text = DRd["NTR"].ToString();
            chWithZU.Checked = (bool)DRd["WithZU"];
            tabControl1.TabIndex = 1;
            //RecalcIdUs.Text = DRd["fio"].ToString(); 
            RecalcIdUs.Text = (string)DRd["RecalcIdUsFIO"];
            chRecalc.Checked = (bool)DRd["Recalc"];
            chWorkFull.Checked = (bool)DRd["WorkFull"];
            chBlock.Checked = (bool)DRd["Block"];
            NeIspolzovat.Checked = (bool)DRd["NeIspolzovat"];
            RegNomer.Text = (string)DRd["RegNomer"];
           // Console.Write("spisokRegNomer " + DateTime.Now.TimeOfDay.ToString() + "\n");
            ObnPr();
            ObnStPred();
            ObnVidRab();

            //Console.Write("spisokObnStPred " + DateTime.Now.TimeOfDay.ToString() + "\n");

            OZP.Text = DRd["OZP"].ToString();
            EM.Text = DRd["EM"].ToString();
            ZPm.Text = DRd["ZPm"].ToString();
            Mat.Text = DRd["Mat"].ToString();
            NR.Text = DRd["NR"].ToString();
            SP.Text = DRd["SP"].ToString();
            TZo.Text = DRd["TZo"].ToString();
            TZm.Text = DRd["TZm"].ToString();
            Pr.Text = DRd["Pr"].ToString();
            Ob.Text = DRd["Ob"].ToString();
            SmetnSt.Text = DRd["SmetnSt"].ToString();
            PrichinaNZP.Text = DRd["PrichinaNZP"].ToString();
            DateStartNZP.Text = DRd["DateStartNZP"].ToString();
            SmetaD.Text = DRd["SmetaD"].ToString();
            Otv.Text = DRd["Otv"].ToString();


            DRd.Close();
            cn.Close();
            my.cn.Open();

            
            my.sc.CommandText = "SELECT     IdArch FROM         dbo.vACSmet where nloc = '" + Nomer.Text + "' and ndoc = '" + Ndoc.Text + "'";
            if (my.sc.ExecuteScalar() == null)
            {
                my.cn.Close();
                button4.Enabled = false;

            }
            else
            {
                idArch = (long)my.sc.ExecuteScalar(); button4.Enabled = true;
                if (!Rec)
                {
                    Nomer.Enabled = false;
                    Ndoc.Enabled = false;
                }
            }
            if ((int)my.cn.State == 1) { my.cn.Close(); }
            //Console.Write("spisokNdoc " + DateTime.Now.TimeOfDay.ToString() + "\n");
            FindObj();
            if (System.Text.RegularExpressions.Regex.IsMatch(Nomer.Text.ToLower(), "пересчет") || System.Text.RegularExpressions.Regex.IsMatch(Nomer.Text.ToLower(), "командировочные")) { chInSmr.Enabled = true; }
            //Console.Write("spisokFindObj " + DateTime.Now.TimeOfDay.ToString() + "\n");
            checkBox1_CheckedChanged(null, null);
            //Console.Write("spisokend " + DateTime.Now.TimeOfDay.ToString() + "\n");
        }
        public void ObnDog()
        {
            if (IdZak.SelectedValue == null)
            { my.FillDC(IdDog, 29, " and Iddog = 0 or  Zak = " + idzak); }
            else
            { my.FillDC(IdDog, 29, " and Iddog = 0 or  Zak = " + IdZak.SelectedValue); }
        }
        private void ObnPr()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT      Proj as Проект FROM         dbo.vACSmetPr where idSm = " + idsm.ToString(), my.sconn);
            da.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];
            my.naimDG("Проекты", Dgv1, "500");
        }

        public void ObnStPred()
        {
            string s = my.FilterSel(109, null, my.sconn, " and idSm = " + idsm.ToString());
            dsStPred = new DataSet();
            daStPred = new SqlDataAdapter(s, my.sconn);
            dsStPred.Clear();
            daStPred.Fill(dsStPred);
            Dgv2.DataSource = dsStPred.Tables[0];
            Dgv2.AllowUserToAddRows = false;
            Dgv2.VLadd("IdEntpr", "Предприятие", "SELECT   IdEntpr, shNMEntpr FROM         Sprav.dbo.tsEntpr WHERE     (Bits & 2 > 0) or identpr = 0 ORDER BY shNMEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 3);
            //
            my.naimDG(my.headStr, Dgv2, my.widthStr);

            SqlCommandBuilder cb = new SqlCommandBuilder(daStPred);
            cb.QuotePrefix = "[";
            cb.QuoteSuffix = "]";
            daStPred.DeleteCommand = cb.GetDeleteCommand();
            daStPred.UpdateCommand = cb.GetUpdateCommand();
            daStPred.InsertCommand = cb.GetInsertCommand();
            //cb = null;

        }
        public void ObnVidRab()
        {
            string s = my.FilterSel(183, null, my.sconn, " and idSm = " + idsm.ToString());
            dsVidRab = new DataSet();
            daVidRab = new SqlDataAdapter(s, my.sconn);
            dsVidRab.Clear();
            daVidRab.Fill(dsVidRab);
            Dgv3.DataSource = dsVidRab.Tables[0];
            Dgv3.AllowUserToAddRows = false;
            Dgv3.VLadd("IdEntpr", "Предприятие", "SELECT   IdEntpr, shNMEntpr FROM         Sprav.dbo.tsEntpr  WHERE     (Bits & 2 > 0) or identpr = 0ORDER BY shNMEntpr", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 3);
            //
            my.naimDG(my.headStr, Dgv3, my.widthStr);
            daVidRab.UpdateCommand = new SqlCommand();
            daVidRab.UpdateCommand.Connection = my.cn;
            daVidRab.UpdateCommand.CommandText = "UPDATE sprav.dbo.tSmetiVidRab SET  Vol = @p1, identpr = @p2 WHERE ([idSmVidRab] = @p3) ";
            daVidRab.UpdateCommand.Parameters.Add("@p1", SqlDbType.Float, 0, "Vol");
            daVidRab.UpdateCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "IdEntpr");
            daVidRab.UpdateCommand.Parameters.Add("@p3", SqlDbType.Int, 0, "idSmVidRab");

        }

        private bool FindObj()
        {
            bool fo = true;
            if (IdObj.SelectedValue == null) return false;
            if ((int)my.cn.State != 1) { my.cn.Open(); }

            dvObj.RowFilter = "idobj = " + IdObj.SelectedValue.ToString();
            if (dvObj.Count != 0)
            {
                if (!BlockT & !WithOpen)
                {
                    return false;
                }

                my.sc.CommandText = "SELECT     Sprav.dbo.tOsrObject.IdOsr,Sprav.dbo.tOsrObject.IdObj, Sprav.dbo.tsOSR.NMOSR FROM         Sprav.dbo.tOsrObject INNER JOIN  Sprav.dbo.tsOSR ON Sprav.dbo.tOsrObject.IdOsr = Sprav.dbo.tsOSR.idOSR where idobj = " + IdObj.SelectedValue;

                SqlDataReader DRd = my.sc.ExecuteReader();
                while (DRd.Read())
                {
                    if ((int)DRd["idOSR"] != idOSR - 1000)
                    {
                        if (MessageBox.Show(@"Заменить ОСР по смете на 
''" + (string)DRd["NMOSR"] + "''?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            my.sc.CommandText = " set language 'русский' update sprav.dbo.tsmeti set idosr = " + DRd["idOSR"].ToString() + ", lastloginOSR = '" + Login + "', lastDateOSR = '" + DateTime.Now + "' where idsm = " + idsm.ToString();
                            idOSR = (int)DRd["idOSR"] + 1000;
                            DRd.Close();
                            my.sc.ExecuteScalar();

                            break;
                        }
                    }
                }
                DRd.Dispose();
                my.sc.CommandText = "select * from vacsm where nomer = '" + Nomer.Text + "' and ndoc ='" + Ndoc.Text + "'";
                if (my.sc.ExecuteScalar() == null)
                {
                    MessageBox.Show("Смета "+ Nomer.Text + " не заведена в центральном архиве! ", "Предупреждение!");
                    if (chBlock.Checked)
                    { chInSmr.Enabled = false; }
                    else
                    { if (!chRecalc.Checked) { chInSmr.Enabled = false; } else { chInSmr.Enabled = true; } }
                    my.cn.Close();
                    toolStrip2.Enabled = false;
                    chInSmr.Enabled = false;
                    return fo;
                }
                toolStrip2.Enabled = BlockT;
            }
            chInSmr.Enabled = true;
            my.cn.Close();
            return fo;
        }

        //private void FillDC(ComboBox ComboBox1, int id, String s1)
        //{
        //    DataSet ds = new DataSet(); String s;
        //    if (id < 1000)
        //    { s = "exec FillSpr  " + id + ",'" + s1 + "'"; }
        //    else { s = s1; }
        //    SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
        //    da.Fill(ds);
        //    ComboBox1.DataSource = ds.Tables[0];
        //    ComboBox1.ValueMember = ds.Tables[0].Columns[0].ColumnName;
        //    ComboBox1.DisplayMember = ds.Tables[0].Columns[1].ColumnName;
        //    da.Dispose();
        //    ds.Dispose();
        //}


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!my.IsNumeric(IdObj.SelectedValue)) return;
            my.cn.Open();
            my.sc.CommandText = "select 1 from sprav.dbo.tOsrObject where idosr = " + Convert.ToString(idOSR - 1000) + " and idobj =  " + IdObj.SelectedValue.ToString();
            if (my.sc.ExecuteScalar() != null)
            {
                my.sc.CommandText = "select isnull((select idOsrObject  from sprav.dbo.tOsrObject where idosr = " + Convert.ToString(idOSR - 1000) + " and idobj =  " + IdObj.SelectedValue.ToString() + "),0) as dd";
                idOSR = (int)my.sc.ExecuteScalar() + 400000;
            }
            treeView1.Nodes.Clear();
            String sel;
            sel = my.FilterSel(66, null, my.sconn, "");
            my.LoadTreeView(my.PDataset(sel), treeView1,"namegroup","parent","idgr",idOSR);
            //my.tvinit(checkBox1.Checked, sel, "", treeView1, false, idOSR, "");
            my.cn.Close();
        }

        private void IdDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WithOpen) return;
            if (IdDog.SelectedValue == null ||!my.IsNumeric(IdDog.SelectedValue)) return;
            if (my.cn.State == ConnectionState.Closed) my.cn.Open();
            my.sc.CommandText = my.FilterSel(138, null, my.sconn, " and iddog = " + iddog);
            lDogSt.Text = (string)my.sc.ExecuteScalar();
            my.cn.Close();
        }


        private void IdZak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IdZak.SelectedValue == null) return;
            if (!my.IsNumeric(IdZak.SelectedValue)) return;
            my.FillDC(IdObj, 33, " and idzak = " + IdZak.SelectedValue.ToString() + " or idobj = 0");
            my.FillDC(IdCeh, 34, " and idzak = " + IdZak.SelectedValue.ToString() + " or idceh= 0");
            ObnDog();
        }
        private bool Save()
        {
            try
            {
                bool Save1;
                //
                my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 154");
                if (my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 154") == "1") { MessageBox.Show("У Вас нет прав для выполнения этой операции!", "Внимание!"); return false; }

                if (Nomer.Text == "" || NMSmeti.Text == "")
                {
                    MessageBox.Show("Обязательно задайте номер и наименование сметы", "Внимание!");
                    return false;
                }
                if (IdDog.Text == "" || (int)IdDog.SelectedValue == 0)
                {
                    MessageBox.Show("Обязательно выберите договор!");
                    return false;
                }
                if (IdInvPr.Text == "" || (int)IdInvPr.SelectedValue == 0)
                {
                    MessageBox.Show("Обязательно выберите Инвест.проект!");
                    return false;
                }
                if (my.ExeScalar("select idstatus from sprav.dbo.tsmeti where idsm =" + idsm) != IdStatus.SelectedValue.ToString() & (int)IdStatus.SelectedValue == 4)
                {
                    MessageBox.Show("Подчиненные сметы могут создаваться только в автоматическом режиме!");


                    return false;
                }

                if (my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = 241")=="1")
                {
                    MessageBox.Show("У Вас нет прав на сохранение шапки сметы!");
                    return false;
                }
                if (IdObj.SelectedValue == null)
                {
                    MessageBox.Show("Выберите объект!");
                    return false;
                }
                my.cn.Open();
                my.sc.CommandText = "exec Sprav.dbo.SaveCapSm " + idsm.ToString() + ",'" + Nomer.Text.Trim() + "',0,'" + NMSmeti.Text.Trim() + "','" +
               IdZak.SelectedValue.ToString() + "','" + IdObj.SelectedValue.ToString() + "','" + IdGP.SelectedValue.ToString() + "','" + IdPodr.SelectedValue.ToString() + "','" +
                IdIstFin.SelectedValue.ToString() + "','" + IdCeh.SelectedValue.ToString() + "','" + Osn.Text.Trim() + "','" +
               InvNomer.Text.ToString() + "',1,'" + PunktTiTulStr.Text + "','" + Ndoc.Text + "'";
                string otv = (string)my.sc.ExecuteScalar();
                if (otv == "IsNomer")
                {
                    MessageBox.Show("В базе данных уже существует смета с таким номером. Измените номер сметы.");
                    Save1 = false;
                }
                else
                {
                    if (otv == "IsActs")
                    {
                        MessageBox.Show(@"По смете обнаружены подписанные акты. 
    Изменения на них не распространяются");
                        Save1 = true;
                    }
                    else
                    { Save1 = true; }
                }
                string ddd = RegNomer.Text.ToString();
                string s = "";
                s = "update  sprav.dbo.tSmeti  set BazStObor = " + BazStObor.Text.Replace(",", ".") +
                ", SumBazOr = " + SumBazOr.Text.Replace(",", ".") + ", SumTekOr = " + SumTekOr.Text.Replace(",", ".") +
                ",WithZU = " + (chWithZU.Checked ? "1" : "0") + ",Sum91Or = " + Sum91Or.Text.Replace(",", ".") +
                ",SumMR2001 = " + SumMR2001.Text.Replace(",", ".") + ",SumMR = " + SumMR.Text.Replace(",", ".") + " ,SumProchZ = " + SumProchz.Text.Replace(",", ".") + " ,NTR = " + NTR.Text.Replace(",", ".") + " ,SmZp = " + SmZp.Text +
                ",IdDog = " + IdDog.SelectedValue + " ,IdWrk = " + my.Val(idWRK.SelectedValue.ToString()) + " ,IdRazr = " + my.Val(IdRazr.SelectedValue.ToString()) + " ,IdStatus = " + my.Val(IdStatus.SelectedValue.ToString()) +
                ",InSmr =" + (chInSmr.Checked ? "1" : "0") + ",Osrtxt ='" + OSRtxt.Text + "'" +
                ",IdInvPr =" + IdInvPr.SelectedValue +
                ",SumMR91 = " + my.Val(SumMR91.Text.Replace(",", ".")) + " ,SumProchZ91 = " + my.Val(SumProchz91.Text.Replace(",", ".")) + " ,StObor91 = " + my.Val(StObor91.Text.Replace(",", ".")) +
                ",SumMRTek = " + my.Val(SumMRTek.Text.Replace(",", ".")) + " ,SumProchZTek = " + my.Val(SumProchzTek.Text.Replace(",", ".")) + " ,StOborTek = " + my.Val(StOborTek.Text.Replace(",", ".")) +
                ",Sum2001 = " + my.Val(Sum2001.Text.Replace(",", ".")) + " ,SumProchZ2001 = " + my.Val(SumProchz2001.Text.Replace(",", ".")) + " ,StObor2001 = " + my.Val(StObor2001.Text.Replace(",", ".")) +
                ",SumOst08 = " + my.Val(SumOst08.Text.Replace(",", ".")) + " ,SumProchZOst08 = " + my.Val(SumProchZOst08.Text.Replace(",", ".")) + " ,StOborOst08 = " + my.Val(StOborOst08.Text.Replace(",", ".")) +
                ",SumMROst08 = " + my.Val(SumMROst08.Text.Replace(",", ".")) +
                ",IdBlock= " + IdBlock.SelectedValue.ToString() + ",IdReason= " + IdReason.SelectedValue.ToString() +
                ",IdNSI= " + IdNSI.SelectedValue.ToString() + ",IdWrkVid = " + my.Val(IdWrkVid.SelectedValue.ToString()) + ",KoefLZ= " + my.Val(KoefLZ.Text.Replace(",", ".")) + ",PonKoef= " + (PonKoef.Text == ""? "NULL": PonKoef.Text) + ",Idprice= " + my.Val(IdPrice.SelectedValue.ToString()) +
                ", Lastlogin=" + "'" + Login + "' , idsmpr=" + IdSmPr +
                ", RegNomer = '" + RegNomer.Text.ToString() + "', WorkFull = " + (chWorkFull.Checked ? "1" : "0") + ", isSSR = " + (radioButton1.Checked ? 1 : (radioButton2.Checked ? 2 : 0)) + ",Mat = " + my.Val(Mat.Text.Replace(",", ".")) +
                ", NomerPO =  '" + NomerPO.Text + "', idMark = " + IdMark.SelectedValue.ToString() +
                ", Prim =  '" + Prim.Text + "'" +
                ", update_date =  '" + DateTime.Now + "'" +
                ", update_user =  '" + my.Login + "'" +
                ",OZP= " + OZP.Text + ",EM= " + EM.Text + ",ZPm= " + ZPm.Text +
                ",NR= " + NR.Text + ",SP= " + SP.Text + ",TZo= " + TZo.Text +
                ",TZm= " + TZm.Text +
                ",IdStatusZak = " + my.Val(IdStatusZak.SelectedValue.ToString()) + ",SmetaD= '" + SmetaD.Text + "'" + ",Otv= '" + Otv.Text + "'" + 
                ",SmetnSt= " + SmetnSt.Text  + ",Pr= " + Pr.Text + ",Ob= " + Ob.Text + ",PrichinaNZP= '" + PrichinaNZP.Text + "',DateStartNZP= " + "'" + DateStartNZP.Text + "'" + 
                ", BeginWRK = " + (BeginWRK.Text == "" ? "NULL" : "'" + BeginWRK.Text + "'") + ", EndWRK = " + (EndWRK.Text == "" ? "NULL" : "'" + EndWRK.Text + "'") + " where IdSm = " + idsm.ToString();
                my.sc.CommandText = s;
                my.sc.ExecuteScalar();

                my.cn.Close();
                return Save1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Проверьте введенное значение! " + ex.Message);
                if (my.cn.State == ConnectionState.Open) { my.cn.Close(); }
                return false;

            }


        }




        private void RecSum()
        {
            Ob.Text = ((IdPrice.SelectedValue.ToString() == "1") ? BazStObor.Text : StObor2001.Text);
            Pr.Text = ((IdPrice.SelectedValue.ToString() == "1") ? SumProchz.Text : SumProchz2001.Text);
            PZ.Text = Convert.ToString(my.Val(OZP.Text) + my.Val(EM.Text) + my.Val(Mat.Text) + my.Val(Ob.Text) + my.Val(Pr.Text));
            Itog.Text = Convert.ToString(my.Val(OZP.Text) + my.Val(EM.Text) + my.Val(Mat.Text) + my.Val(Ob.Text) + my.Val(Pr.Text) + my.Val(NR.Text) + my.Val(SP.Text));
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = " update sprav.dbo.tsmeti set isSSR = 0 where idsm = " + idsm;
            my.sc.ExecuteScalar();
            my.cn.Close();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void IdObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!my.IsNumeric(IdObj.SelectedValue)) return;

            if ((int)IdObj.SelectedValue != idobject && !WithOpen)
            { if (!FindObj()) { IdObj.SelectedValue = idobject; } }
        }

        private void IdPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (WithOpen) return;
                my.cn.Open();
                my.sc.CommandText = "select idprice from sprav.dbo.tsmeti where idsm = " + idsm.ToString();
                if (IdPrice.SelectedValue != my.sc.ExecuteScalar())
                {
                    my.sc.CommandText = " update sprav.dbo.tsmeti set idprice = " + IdPrice.SelectedValue.ToString() + "  where idsm = " + idsm;
                    my.sc.ExecuteScalar();
                    if ((int)IdPrice.SelectedValue == 2)
                    {
                        if (t84.Text != "0")
                        {
                            Sum2001.Text = SumBazOr.Text; SumBazOr.Text = "0";
                            StObor2001.Text = BazStObor.Text; BazStObor.Text = "0";
                            SumProchz2001.Text = SumProchz.Text; SumProchz.Text = "0";
                        }
                    }

                    else
                    {
                        if (t2001.Text != "0")
                        {
                            SumBazOr.Text = Sum2001.Text; Sum2001.Text = "0";
                            SumProchz2001.Text = StObor2001.Text; StObor2001.Text = "0";
                            SumProchz.Text = SumProchz2001.Text; SumProchz2001.Text = "0";
                        }
                    }

                }

                my.cn.Close();
            }
            catch (Exception)
            {

                if (my.cn.State == ConnectionState.Open) my.cn.Close();
            }

        }
        private void sumAll(string s)
        {
            try
            {
                if (s == "84") { t1.Text = System.Math.Round(Convert.ToDouble(SumBazOr.Text) * Convert.ToDouble(KoefLZ.Text), 0).ToString(); t84.Text = Convert.ToString(Convert.ToDouble(SumBazOr.Text) + Convert.ToDouble(BazStObor.Text) + Convert.ToDouble(SumProchz.Text) + Convert.ToDouble(t1.Text)); }
                if (s == "91") { t2.Text = System.Math.Round(Convert.ToDouble(Sum91Or.Text) * Convert.ToDouble(KoefLZ.Text), 0).ToString(); t91.Text = Convert.ToString(Convert.ToDouble(Sum91Or.Text) + Convert.ToDouble(StObor91.Text) + Convert.ToDouble(SumProchz91.Text) + Convert.ToDouble(t2.Text)); }
                if (s == "2001") { t3.Text = System.Math.Round(Convert.ToDouble(Sum2001.Text) * Convert.ToDouble(KoefLZ.Text), 0).ToString(); t2001.Text = Convert.ToString(Convert.ToDouble(Sum2001.Text) + Convert.ToDouble(StObor2001.Text) + Convert.ToDouble(SumProchz2001.Text) + Convert.ToDouble(t3.Text)); }
                if (s == "tek") { t4.Text = System.Math.Round(Convert.ToDouble(SumTekOr.Text) * Convert.ToDouble(KoefLZ.Text), 0).ToString(); ttek.Text = Convert.ToString(Convert.ToDouble(SumTekOr.Text) + Convert.ToDouble(StOborTek.Text) + Convert.ToDouble(SumProchzTek.Text) + Convert.ToDouble(t4.Text)); }
                if (s == "Ost08") { t5.Text = System.Math.Round(Convert.ToDouble(SumOst08.Text) * Convert.ToDouble(KoefLZ.Text), 0).ToString(); TOst08.Text = Convert.ToString(Convert.ToDouble(SumOst08.Text) + Convert.ToDouble(StOborOst08.Text) + Convert.ToDouble(SumProchZOst08.Text) + Convert.ToDouble(t5.Text)); }

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void KoefLZ_TextChanged(object sender, EventArgs e)
        {
            sumAll("84");
            sumAll("91");
            sumAll("tek");
            sumAll("Ost08");
            sumAll("2001");
        }

        private void KoefLZ_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
                if (tb.Text == "0") { tb.Text = ""; }
            }
            catch (Exception)
            {

            }
        }

        private void SumBazOr_TextChanged(object sender, EventArgs e)
        {
            sumAll("84");
            RecSum();

        }

        private void chRecalc_CheckedChanged(object sender, EventArgs e)
        {

            if (!WithOpen)
            {
                my.cn.Open();

                if (chRecalc.Checked)
                {
                    chInSmr.Enabled = true;
                    my.sc.CommandText = "update sprav.dbo.tsmeti set Recalc = 1,recalcidus = " + Id_us.ToString() + " where idsm = " + idsm;
                    my.sc.ExecuteScalar();
                    my.sc.CommandText = "select fio from dostup.dbo.users where id_us = " + Id_us.ToString();
                    RecalcIdUs.Text = my.sc.ExecuteScalar().ToString();

                }
                else
                {
                    my.sc.CommandText = "update sprav.dbo.tsmeti set Recalc = 0 ,recalcidus = 0 where idsm = " + idsm;
                    my.sc.ExecuteScalar();
                    RecalcIdUs.Text = "";
                }
                my.cn.Close();
            }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            //frmCapSm_FormClosing(null, null);
            if (MessageBox.Show("Сохранить данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes) { if (Save() == false) { return; } }
            Control ctl = this;
            while (!(ctl.Parent == null || ctl.GetType().BaseType.Name == "Form"))
            { ctl = ctl.Parent; }
            ((Form)ctl).Close();
            //UCFrmSm.UserControl1.d  Close();
        }

        private void Sum2001_TextChanged(object sender, EventArgs e)
        {
            sumAll("2001");
        }

        private void Sum91Or_TextChanged(object sender, EventArgs e)
        {
            sumAll("91");
        }

        private void SumTekOr_TextChanged(object sender, EventArgs e)
        {
            sumAll("tek");
        }

        private void SumBazOr_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            if (my.IsNumeric(tb.Text) == false)
            {
                tb.Text = "0";
            }
        }

        private void Nomer_TextChanged(object sender, EventArgs e)
        {
            if (Nomer.Text.Contains("пересчет") || Nomer.Text.Contains("командировочные")) { chInSmr.Enabled = true; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //my.cn.Open();
            //проверка для Захарченко
            string ss = null;
            ss = my.FilterSel(210, this, my.sconn, " and idSm = " + idsm.ToString()); ;

            int idobject = 0;
            if (treeView1.SelectedNode == null) { MessageBox.Show("Выберите комлекс!", "Внимание!"); return; }
            idOSR = Convert.ToInt32(treeView1.SelectedNode.Tag);
            if (idOSR < 1000) { MessageBox.Show("Выбор не верен!", "Внимание!"); return; }
            if (my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = 158") != "")
            {
                if (my.ExeScalar(ss + " and idosr =" + System.Convert.ToString(idOSR - 1000).ToString()) != "")
                    BlockT = true;
                //// конец проверки
            }
            if (!BlockT)
            {
                if (my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 154") != "") { MessageBox.Show("У Вас нет прав для выполнения этой операции", "Внимание!"); return; }
            }


            if (idOSR >= 400000)
            {
                my.sc.CommandText = "SELECT  IdObj  FROM  sprav.dbo.tOsrObject WHERE   IdOsrObject = " + Convert.ToString(idOSR - 400000);
                idobject = Convert.ToInt32(my.ExeScalar("SELECT  IdObj  FROM  sprav.dbo.tOsrObject WHERE   IdOsrObject = " + Convert.ToString(idOSR - 400000)));
                idOSR = Convert.ToInt32(treeView1.SelectedNode.Parent.Tag) - 1000;
                if (IdObj.SelectedValue == null || idobject != (int)IdObj.SelectedValue)
                {
                    if (IdObj.SelectedValue == null) { IdObj.SelectedValue = 0; }
                    dvObj.RowFilter = "idobj = " + IdObj.SelectedValue.ToString();
                    if (dvObj.Count != 0)
                    {
                        if (!BlockT & !WithOpen)
                        {
                            MessageBox.Show("Вы не имеете прав на эту операцию!");
                            return;
                        }
                    }

                    if (MessageBox.Show(@"Объект по смете не совпадает с объектом по проекту!
Заменить " + IdObj.Text + " на выбранный?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.No) { return; }
                }
                else
                {
                    my.ExeScalar(" update sprav.dbo.tsmeti set idosr = " + idOSR.ToString() + ", lastloginOSR = '" + Login + "', lastDateOSR = '" + DateTime.Now + "' where idsm = " + idsm); 
                    return;
                }
                
                if (my.ExeScalar("SELECT     1 FROM         smr.dbo.Forma2 INNER JOIN   smr.dbo.MoveF2 ON smr.dbo.Forma2.IdF2 = smr.dbo.MoveF2.IdF2 WHERE     (smr.dbo.MoveF2.PodpZak = 1) and idsm = " + idsm) != "") { MessageBox.Show("По смете обнаружены подписанные акты. Смена объекта невозможна!"); return; }
                my.ExeScalar(" update sprav.dbo.tsmeti set idosr = " + idOSR.ToString() + ", idobj = " + idobject.ToString() + ", lastloginOSR = '" + Login + "', lastDateOSR = '" + DateTime.Now + "' where idsm = " + idsm);
                IdObj.SelectedValue = idobject;
                idOSR = idOSR + 1000;
                checkBox1_CheckedChanged(null, null);
            }
            else
            {
                my.ExeScalar(" update sprav.dbo.tsmeti set idosr = " + Convert.ToString(idOSR - 1000) + ", lastloginOSR = '" + Login + "', lastDateOSR = '" + DateTime.Now + "' where idsm = " + idsm);

                checkBox1_CheckedChanged(null, null);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            my.cn.Open();
            my.sc.CommandText = "select 1 from dostup.dbo.usersingroups where id_user = " + Id_us.ToString() + " and id_group = 154";
            if (my.sc.ExecuteScalar() != null) { MessageBox.Show("У Вас нет прав для выполнения этой операции", "Внимание!"); return; }
            idOSR = -1;
            my.sc.CommandText = " update sprav.dbo.tsmeti set idosr = 0 where idsm = " + idsm;
            my.sc.ExecuteScalar();
            my.cn.Close();
            checkBox1_CheckedChanged(null, null);
        }

        private void chBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (chBlock.Checked)
            {
                chInSmr.Enabled = false;
            }
            //If Not WithOpen Then
            if (!WithOpen)
            {
                my.cn.Open();
                if (!chBlock.Checked)
                {
                    chInSmr.Enabled = true;
                    my.sc.CommandText = "update sprav.dbo.tsmeti set Block = 0 where idsm = " + idsm.ToString();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    chRecalc_CheckedChanged(null, null);
                }
                else
                {
                    chInSmr.Checked = false;
                    chInSmr.Enabled = false;
                    my.sc.CommandText = "update sprav.dbo.tsmeti set Block = 1 where idsm = " + idsm.ToString();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                }
            }
        }



        private void IdStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IdStatus.SelectedValue.ToString() == "1")
            {
                //IdSmPr.Visible = false;
                NMUtvSm.Visible = false;
                button5.Visible = false;
                label33.Visible = false;
                IdSmPr = 0;
                if (!GrGCO)
                {
                    IdStatus.Enabled = false;
                }
            }
            else
            {
                //IdSmPr.Visible = true;
                NMUtvSm.Visible = true;
                label33.Visible = true;
                chInSmr.Visible = true;
                button5.Visible = true;
            }

        }

        private void SumOst08_TextChanged(object sender, EventArgs e)
        {
            sumAll("Ost08");
        }
        private void frmCapSm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dsStPred.HasChanges()) { my.Up(daStPred, dsStPred.Tables[0]); };
            if (dsVidRab.HasChanges()) { my.Up(daVidRab, dsVidRab.Tables[0]); };
            //if (MessageBox.Show("Сохранить данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{ if (Save() == false)
            //    { e.Cancel = true; return; }
            //}
        }

        private void Dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BeginWRK.Focus();
            if (dsStPred.HasChanges())
            { my.Up(daStPred, dsStPred.Tables[0]); };
        }


        private void Dgv3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BeginWRK.Focus();
            if (dsVidRab.HasChanges()) { my.Up(daVidRab, dsVidRab.Tables[0]); };
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            RegNomer.Focus();
            if (dsStPred.HasChanges()) { my.Up(daStPred, dsStPred.Tables[0]); };
            my.sc.CommandText = "exec Sprav.dbo.NewSmetiEnt " + idsm.ToString();
            my.cn.Open();
            if (my.sc.ExecuteScalar().ToString() == "Is0") { MessageBox.Show("В смете данные по одному предприятию должны быть в единственном числе! (пусто)"); };
            my.cn.Close();
            ObnStPred();
        }

        private void Dgv2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Dgv2.SelectedRows.Count == 0) { Dgv2.CurrentRow.Selected = true; }
            my.cn.Open();
            foreach (DataGridViewRow selrow in Dgv2.SelectedRows)
            {
                my.sc.CommandText = " delete from sprav.dbo.tSmetiEnt where idsment = " + selrow.Cells[0].Value;
                my.sc.ExecuteScalar();
            }
            my.cn.Close();
            ObnStPred();
        }

        private void Dgv3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Dgv3.SelectedRows.Count == 0) { Dgv3.CurrentRow.Selected = true; }
            my.cn.Open();
            foreach (DataGridViewRow selrow in Dgv3.SelectedRows)
            {
                my.sc.CommandText = " delete from sprav.dbo.tSmetiVidRab where idSmVidRab = " + selrow.Cells[0].Value;
                my.sc.ExecuteScalar();
            }
            my.cn.Close();
            ObnVidRab();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dgv2_UserDeletingRow(null, null);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить записи  из таблицы  ? ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dgv3_UserDeletingRow(null, null);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            my.Nbut = 30;
            my.Ustr = idsm.ToString();
            my.showSprDGV(my.Nbut, true, true);
            ObnVidRab();
        }



        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //toolStripButton7_Click(null, null);
            my.cn.Open();
            my.sc.CommandText = " exec sCopyTSmetiEnt " + idsm.ToString() + "," + Dgv2.CurrentRow.Cells["identpr"].Value.ToString();
            my.sc.ExecuteScalar();

            my.cn.Close();
            ObnStPred();

        }

        private void Mat_TextChanged(object sender, EventArgs e)
        {
            RecSum();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(my.sconn);
            SqlCommand sc = new SqlCommand("select * from vA0Smeti where idsm =" + idsm, cn);

            cn.Open();
            SqlDataReader DRd = sc.ExecuteReader();

            while (DRd.Read())
            {
                OZP.Text = Convert.ToDouble(DRd["OZP"]).ToString();
                EM.Text = Convert.ToDouble(DRd["EM"]).ToString();
                ZPm.Text = Convert.ToDouble(DRd["ZPm"]).ToString();
                Mat.Text = Convert.ToDouble(DRd["Mat"]).ToString();
                NR.Text = Convert.ToDouble(DRd["NR"]).ToString();
                SP.Text = Convert.ToDouble(DRd["SP"]).ToString();
                TZo.Text = Convert.ToDouble(DRd["TZo"]).ToString();
                TZm.Text = Convert.ToDouble(DRd["TZm"]).ToString();
                Pr.Text = Convert.ToDouble(DRd["Pr"]).ToString();
                Ob.Text = Convert.ToDouble(DRd["Ob"]).ToString();
                SmetnSt.Text = Convert.ToDouble(DRd["SmetnSt"]).ToString();

            }
            DRd.Close();
            cn.Close();
        }

        private void IdObj_Click(object sender, EventArgs e)
        {
            try
            {

            IdObj.Width = 580;
            idobject = my.Val(IdObj.SelectedValue.ToString());

            }
            catch (Exception)
            {

            }
        }

        private void IdObj_Leave(object sender, EventArgs e)
        {
            IdObj.Width = 332;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                my.cn.Open();
                my.sc.CommandText = "update sm_prog.dbo.СлужПользРазное set idarch=" + idArch + " where Код=" + Id_us;
                my.sc.ExecuteScalar();
                my.cn.Close();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "C:\\cis\\kiscard.exe";
                proc.Start();
                //Shell "C:\\cis\\kiscard.exe", Microsoft.VisualBasic.Constants.vbNormalFocus;

            }
            catch (Exception)
            {


            }

        }

        private void NeIspolzovat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!WithOpen)
                {
                    if (NeIspolzovat.Checked)
                    {
                        if (MessageBox.Show("Вы уверены, что смета не должна использоваться? Смета будет заблокирована.", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                           my.ExeScalar( "update sprav.dbo.tsmeti set Block = 1,NeIspolzovat = 1 where idsm = " + idsm);
                           chBlock.Checked = true;
                           chBlock.Enabled = false;
                        }
                    }
                    else
                    {
                        my.ExeScalar("update sprav.dbo.tsmeti set NeIspolzovat = 0 where idsm = " + idsm);
                        chBlock.Enabled = true;
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            my.Szap = "";
            my.Nbut = 707;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.Pform = this;
                my.showSprDGV(my.Nbut, false, false);
            }
        }

        private void frmCapSm_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите заменить текущую смету на другую?" + System.Environment.NewLine + "Акты из учета перенесутся на выбранную смету, связь с программой А0 сохранится." + System.Environment.NewLine + "Текущая смета будет удалена! ", string.Empty, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            my.Szap = "";
            my.Nbut = 139;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.Pform = this;
                my.Ustr   = idsm.ToString();
                my.showSprDGV(my.Nbut, false, false);
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((my.ExeScalar("select 1 from dostup.dbo.usersingroups where id_user = " + Id_us + " and id_group = 154") != "1"))
            {

                MessageBox.Show("У Вас нет прав для выполнения этой операции");
                return;
            }
            my.Szap = " and idsm = " + idsm;
            my.Nbut = 109;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.Pform = this;
                my.Ustr = idsm.ToString();
                my.showSprDGV(my.Nbut, false, false);
            }
        }

        private void label63_Click(object sender, EventArgs e)
        {

        }
    }
}