using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SMRC.Forms
{
    public partial class frmAct : Form
    {
        public int idf2; int identpr; bool NotRem; DataSet ds; SqlDataAdapter da; bool Save1; int idsm; Form pform1; bool WithLoad; bool Upr;DateTime Period;
         DataSet dskorr; SqlDataAdapter dakorr; string UGP;string kodunic; string IdVidDog; int idprorabC = 0;
        public frmAct()
        {
            InitializeComponent();


        }

        private void frmAct_Load(object sender, EventArgs e)
        {
            WithLoad = true;
          
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("start", typeof(DateTime));
            DateTime.Today.GetDateTimeFormats(); 

            Console.Write("start1 " + DateTime.Now.TimeOfDay.ToString() + "\n");
          
            pform1 = my.Pform;
            Top = 0;
            TabControl1.TabIndex = 1;
            my.sc.CommandText = "Select * from v_Forma2 Where idF2  =" + idf2.ToString();
            my.cn.Open();
            SqlDataReader DRd = my.sc.ExecuteReader();
            DRd.Read();
            if (DRd["PeriodUpr"] != DBNull.Value)
            {
                PeriodUpr.Text = Convert.ToDateTime(DRd["PeriodUpr"]).ToString("dd.MM.yyyy");
            }
            RealZak.Checked = (bool)DRd["RealZak"];
            Period = (DateTime)DRd["Period"];
           
            my.FillDC(IdPrice,30,"");
            IdPrice.SelectedValue = DRd["IdPrice"];
            RdWrAfterZak((int)DRd["idzak"]);
            my.FillDC(idZak, 7, " and sprav.dbo.isb(Bits,0) = 1 or identpr = 0 ");
            idZak.SelectedValue = DRd["idZak"];
            Shifr.Text = (string)DRd["Shifr"];
            ObnObject();
            IdObj.SelectedValue = DRd["idObj"];
            my.FillDC(idGP, 9, "");
            idGP.SelectedValue = DRd["idGp"];
           
            int iddog1 = (int)DRd["iddog"];
            string dogname = (string)(DRd["DogName"] == DBNull.Value ? "" : DRd["DogName"].ToString());
            ObnF3Predjav();
            idF3Predjav.SelectedValue = DRd["idF3Predjav"];
            Edneeis.Controls.MultiColumnComboBox.Column i1 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i1.ColumnMember = "Nomer";
            i1.AutoSize = true;
            i1.Header = "Номер";
            this.idSm.Columns.Add(i1);
            Edneeis.Controls.MultiColumnComboBox.Column i2 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i2.ColumnMember = "NMSmeti";
            i2.AutoSize = false;
            i2.Header = "Наименование";
            i2.Width = 400;
            this.idSm.Columns.Add(i2);
            this.idSm.ShowColumnHeader = true;
            idSm.ShowColumns = true;
            Console.Write("start2 " + DateTime.Now.TimeOfDay.ToString());
            identpr = (int)DRd["IdPred"];
            //ObnSmeta();
            my.FillDC(idDep, 25, " and identpr = 0 or identpr = " + identpr.ToString());
            my.FillDC(idIstFin, 18, "");
            Console.Write("start21 " + DateTime.Now.TimeOfDay.ToString() + "\n");
            idIstFin.SelectedValue = (int)DRd["IdIstFin"];

            KodUnic.Text = "Внутр. номер    " + DRd["KodUnic"].ToString();
            kodunic = DRd["KodUnic"].ToString();
            RegNomer.Text = (string)(DRd["RegNomer"] == DBNull.Value ? "" : DRd["RegNomer"].ToString());
            chOplDrGP.Checked = (bool)DRd["OplDrGP"];
            idSm.SelectedValue = (int)DRd["IdSm"];
            Console.Write("start28 " + DateTime.Now.TimeOfDay.ToString() + "\n");
            ObnSmeta();
            Console.Write("start281 " + DateTime.Now.TimeOfDay.ToString() + "\n");
            if (DRd["IdSm"] != DBNull.Value)
            {
                idSm.Text = DRd["Nomer"].ToString();
            }
            else
            { idSm.Text = ""; }
            Naim.Text = DRd["Naim"].ToString();
            ObnPrivIspol();
            my.FillDC( IdEntForPO, 7, " and identpr = 0 or IdEntParent = " + identpr) ;
            IdEntForPO.SelectedValue = (int)DRd["IdEntForPO"];
            my.FillDC(IdEntprForDM, 7, "");

            IdEntprForDM.SelectedValue = (int)DRd["IdEntprForDM"];
            Console.Write("start29 " + DateTime.Now.TimeOfDay.ToString() + "\n");

            if ((short)DRd["SvCh"] == 1)
            {
                idDep.Enabled = true;
                rbSv.Checked = true;
                F2Priv.Enabled = false;
                IdFromPriv.Enabled = false;
                if ((int)DRd["IdIsp"] != 0)
                {
                    idDep.SelectedValue = (int)DRd["Iddep"];
                    if ((int)DRd["IdProrab"] == 0)
                    {
                        chProrab.Checked = false; idProrab.Enabled = false;
                    }
                    else
                    {

                        chProrab.Checked = true; idProrab.SelectedValue = (int)DRd["Idprorab"]; 
                    }
                }
                else
                { idProrab.Enabled = false; chProrab.Checked = false; }

                chSnjatie.Enabled = false;
            }
            else
            {
                if ((short)DRd["SvCh"] == 2)
                {
                    idDep.Enabled = false;
                    rbPriv.Checked = true;
                    F2Priv.Enabled = true;
                    IdFromPriv.Enabled = true;
                    chProrab.Enabled = false; chProrab.Enabled = false;
                    if (DRd["Priv"] != null)
                    {
                        F2Priv.SelectedValue = (int)DRd["F2Priv"];
                        IdFromPriv.SelectedValue = (int)DRd["IdFromPriv"];
                    }
                    else
                    {
                        F2Priv.SelectedValue = 0;
                        IdFromPriv.SelectedValue = 0;
                    }

                    if ((int)DRd["F2Priv"] != 0)
                    {
                        chSnjatie.Enabled = true;
                        chSnjatie.Checked = (bool)DRd["Snjatie"];
                    }
                    else
                    { chSnjatie.Enabled = false; }

                }
                else
                {
                    chProrab.Enabled = false; idProrab.Enabled = false;
                    idDep.Enabled = false; F2Priv.Enabled = false; IdFromPriv.Enabled = false;
                    chSnjatie.Enabled = false;
                    idDep.SelectedValue = 0;
                }
            }
            smrUpr.Checked =(bool)DRd["smrUpr"];
            LoginSmrUpr.Text = DRd["LoginSmrUpr"].ToString();
            Console.Write("start3 " + DateTime.Now.TimeOfDay.ToString());
            //   В Т О Р А Я         С Т Р А Н И Ц А      "  РА С К Л А Д К А        С Т О И М О С Т И "
            textBox0.Text = DRd["Vip84"].ToString();
            textBox1.Text = DRd["Vip91"].ToString();
            textBox2.Text = DRd["VipTek"].ToString();
            textBox3.Text = DRd["VozvratMat"].ToString();
            textBox4.Text = DRd["DavMat"].ToString();
            ObnOplatu();
            textBox7.Text = DRd["OsnZp"].ToString();
            textBox8.Text = DRd["Meh"].ToString();
            textBox9.Text = DRd["Mat"].ToString();
            textBox10.Text = DRd["Nakl"].ToString();
            textBox11.Text = DRd["Planov"].ToString();
            textBox12.Text = DRd["KompZp"].ToString();
            textBox13.Text = DRd["KompMeh"].ToString();
            textBox14.Text = DRd["KompMat"].ToString();
            textBox15.Text = DRd["VremZd"].ToString();
            textBox16.Text = DRd["ZimUdor"].ToString();
            textBox17.Text = DRd["PerevRab"].ToString();
            textBox18.Text = DRd["KomRash"].ToString();
            textBox19.Text = DRd["PodvHar"].ToString();
            textBox20.Text = DRd["NeprRash"].ToString();
            textBox21.Text = DRd["ProzhVGost"].ToString();
            textBox22.Text = DRd["SostSmet"].ToString();
            textBox23.Text = DRd["OtchVDorFond"].ToString();
            textBox24.Text = DRd["ProchRash"].ToString();
            textBox41.Text = DRd["PrinZak84"].ToString();
            textBox42.Text = DRd["PrinZak91"].ToString();
            textBox25.Text = DRd["PrinZak"].ToString();
            textBox26.Text = DRd["Vip84Pr"].ToString();
            textBox27.Text = DRd["Vip91Pr"].ToString();
            textBox28.Text = DRd["KomRash91"].ToString();
            textBox29.Text = DRd["ZimUdor91"].ToString();
            textBox30.Text = DRd["PerevRab91"].ToString();
            textBox31.Text = DRd["Vip91PN"].ToString();
            textBox32.Text = DRd["VipTekPN"].ToString();
            textBox33.Text = DRd["Vip84PN"].ToString();
            textBox40.Text = DRd["ZpMeh"].ToString();
            textBox6.Text = DRd["ZimUdor84"].ToString();
            textBox34.Text = DRd["Mr84"].ToString();
            textBox35.Text = DRd["Mr91"].ToString();
            textBox36.Text = DRd["MrTek"].ToString();
            textBox37.Text = DRd["Sr84"].ToString();
            textBox38.Text = DRd["Sr91"].ToString();
            textBox39.Text = DRd["SrTek"].ToString();
            textBox43.Text = DRd["OborTek"].ToString();
            textBox44.Text = DRd["ZVahMetod"].ToString(); 
            textBox45.Text = DRd["ZPerebaz"].ToString(); 
            textBox46.Text = DRd["ZProch"].ToString();

            textBox306.Text = DRd["TR"].ToString();

            //''   Т Р Е Т Ь Я      С Т Р А Н И Ц А      "  П Р О Ч И Е    Д А Н Н Ы Е  "
            if ((int)DRd["idStatus"] == 0 || (int)DRd["idSmPr"] == 0) { ChVzamen.Enabled =false; };
            ChVzamen.Checked = (bool)DRd["Vzamen"];
            chSnjatieSKon.Checked = (bool)DRd["SnjatieSKon"];
            chSnjatieSKonBudOplZak.Checked = (bool)DRd["SnjatieSKonBudOplZak"];
            chSnjatieNotSub.Checked = (bool)DRd["SnjatieNotSub"];
            flNetitul.Checked = (bool)DRd["flNetitul"];
            chAvans.Checked = (bool)DRd["Avans"];
            chSkr.Checked = (bool)DRd["Skr"];
            chVklVSmRazlTekMes.Checked = (bool)DRd["VklVSmRazlTekMes"];
            chBankProc.Checked = (bool)(DRd["BankProc"] == DBNull.Value ? false : true);
            Prim.Text = (DRd["Prim"] == null ? "" : DRd["Prim"].ToString());
            ChIskluch.Checked = (bool)DRd["IskluchNZ"];
            flSnjatieNZP.Checked = (bool)DRd["flSnjatieNZP"];
            //''движение акта
            chVremProc.Checked = (bool)DRd["VremProc"];
            chPodpCur.Checked = (bool)DRd["PodpCur"];
            if (chPodpCur.Checked)
            {
                DatePodpCur.Visible = true;
                if (DRd["DatePodpCur"] != null)
                {
                    DatePodpCur.Text = Convert.ToDateTime(DRd["DatePodpCur"]).ToString("dd.MM.yyyy");
                 }
            }
            else
            {
                DatePodpCur.Visible = false;
            }

            chPolNZ.Checked = (DRd["DateNZ"]!= DBNull.Value) ;
            if (chPolNZ.Checked)
            {
                DatePolNZ.Visible = true;
                if (DRd["DateNZ"] != DBNull.Value)
                {
                    DatePolNZ.Text = Convert.ToDateTime(DRd["DateNZ"]).ToString("dd.MM.yyyy");
                }
            }
            else
            {
                DatePolNZ.Visible = false;
            }

            chPodpForF3.Checked = (bool)DRd["PodpForF3"];
            if (chPodpForF3.Checked)
            {
                DatePodpForF3.Visible = true;
                if (DRd["DatePodpForF3"] != DBNull.Value)
                {
                    DatePodpForF3.Text = Convert.ToDateTime(DRd["DatePodpForF3"]).ToString("dd.MM.yyyy");
                }
            }
            else
            {
                DatePodpForF3.Visible = false;
            }

            chPostChern.Checked = (bool)DRd["PostChern"];
            chOtprZak.Checked = (bool)DRd["OtprZak"];
            chPodpZak.Checked = (bool)DRd["PodpZak"];
            Console.Write("start4 " + DateTime.Now.TimeOfDay.ToString());
            if (chPostChern.Checked)
            {
                DatePostChern.Visible = true;
                if (DRd["DatePostChern"] != null)
                {
                    DatePostChern.Text = Convert.ToDateTime(DRd["DatePostChern"]).ToString("dd.MM.yyyy") ;
                }
            }                else
                { DatePostChern.Visible = false; }

            if (chOtprZak.Checked)
            {
                DateOtprZak.Visible = true;
                if (DRd["DateOtprZak"] != null)
                {
                    DateOtprZak.Text = Convert.ToDateTime(DRd["DateOtprZak"]).ToString("dd.MM.yyyy");
                }
                
            }else
                { DateOtprZak.Visible = false; }
            if (chPodpZak.Checked)
            {
                DatePodpZak.Visible = true;
                if (DRd["DatePodpZak"] != null)
                {
                    DatePodpZak.Text = Convert.ToDateTime(DRd["DatePodpZak"]).ToString("dd.MM.yyyy") ;
                }
                
            }
else
                { DatePodpZak.Visible = false; }

            LastLogin.Text = DRd["LastLogin"].ToString();

            my.FillDC(idPodpKS6, 41, " and vid = 19 ");
            idPodpKS6.SelectedValue = DRd["idPodpKS6"].ToString(); 
            my.FillDC(idPrichinaNZP, 41, " and vid = 20 ");
            idPrichinaNZP.SelectedValue = DRd["idPrichinaNZP"].ToString();

            if (DRd["A0LsTitleId"].ToString()!= "0")
            {
                lSoob.Text = "Акт составлен в программе А0";
                lSoob.Visible = true;
            }
            DRd.Close();
            DRd.Dispose();
            my.cn.Close();
            Edneeis.Controls.MultiColumnComboBox.Column i3 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i3.ColumnMember = "RegNomer";
            i3.AutoSize = true;
            this.idDog.Columns.Add(i3);
            Edneeis.Controls.MultiColumnComboBox.Column i4 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i4.ColumnMember = "ZakName";
            i4.Width = 100;
            this.idDog.Columns.Add(i4);
            Edneeis.Controls.MultiColumnComboBox.Column i5 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i5.ColumnMember = "IspName";
            i5.Width = 100;
            this.idDog.Columns.Add(i5);
            Edneeis.Controls.MultiColumnComboBox.Column i6 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i6.ColumnMember = "Date_1";
            i6.Width = 100;
            this.idDog.Columns.Add(i6);
            Edneeis.Controls.MultiColumnComboBox.Column i7 = new Edneeis.Controls.MultiColumnComboBox.Column();
            i7.ColumnMember = "PredmetDog";
            i7.Width = 400;
            this.idDog.Columns.Add(i7);
            idDog.ShowColumns = true;
            UGP = my.ExeScalar("select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + idGP.SelectedValue);
            IdVidDog = my.ExeScalar("SELECT IdVidDog FROM dbo.VidGPDog WHERE  Pred = '" + UGP + "'");
            if (IdVidDog == "") { IdVidDog = "4"; }
            //UGP = my.ExeScalar("select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + idGP.SelectedValue);
            ObnDog();
            
            Console.Write("start5 " + DateTime.Now.TimeOfDay.ToString());

            ////Сметная программа
            //my.cn.Open();
            //my.sc.CommandText = "SELECT     1 FROM         sm_prog.dbo.Акты INNER JOIN  dbo.Forma2 ON sm_prog.dbo.Акты.КодВsdo = dbo.Forma2.KodUnic where idf2 = " + idf2.ToString();
            //if (my.sc.ExecuteScalar() != null)
            //{
            //    idZak.Enabled = false;
            //    IdObj.Enabled = false;
            //    idDog.Enabled = false;
            //    idGP.Enabled = false;
            //    idSm.Enabled = false;
            //    Naim.Enabled = false;
            //    idIstFin.Enabled = false;
            //    foreach (Control ctl in tableLayoutPanel1.Controls)
            //    {

            //        if (ctl.GetType().Name == "TextBox" && ctl.Name != "textBox6") { ctl.Enabled = false; }
            //    }

            //    foreach (Control ctl in tableLayoutPanel2.Controls)
            //    {

            //        if (ctl.GetType().Name == "TextBox" && tableLayoutPanel2.GetRow(ctl) < 10) { ctl.Enabled = false; }
            //    }



            //    lSoob.Text = "Акт составлен в сметной программе";
            //    lSoob.Visible = true;
            //}
            //else
            //{ lSoob.Text = ""; }

            //my.cn.Open();
            //my.sc.CommandText = "SELECT     1 FROM         dostup.dbo.UsersInGroups  WHERE     (id_group = 43) AND id_user = " + my.Id_us.ToString();
            if (my.UserInGroup(my.Id_us, 43))
            {
                textBox1.Enabled = true;
                textBox0.Enabled = true;
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                foreach (Control ctl in tableLayoutPanel2.Controls)
                {

                    if (ctl.GetType().Name == "TextBox") { ctl.Enabled = true; }
                }
            }
            //my.cn.Close();

            if (!my.UserInGroup(my.Id_us,53) )
            {
                ChIskluch.Enabled = false;
                btnZakrNZ.Enabled = false;
            }
            if (!my.UserInGroup(my.Id_us, 54))
            {
                smrUpr.Enabled = false;
            }
            else
            {
                if (smrUpr.Checked )
                {
                    smrUpr.Enabled = false;
                }
                else
                {
                    smrUpr.Enabled = true;
                }
            }

            if (my.InF3(idf2))
            {
                idZak.Enabled = false; IdObj.Enabled = false;
                idDog.Enabled = false; idSm.Enabled = false;
                idGP.Enabled = false;
                textBox3.Enabled = false; textBox4.Enabled = false;
            }
            idDog.SelectedValue = iddog1; idDog.Text = dogname;
            Dgv1.AllowUserToAddRows = false;
            Dgv3.AllowUserToAddRows = false;
            ObnObor();
            ObnKorrActs();
            lblKorr.Text = my.ExeScalar("select dbo.fOstParent (" + idf2  +")");
            my.ObnPer(PeriodUpr);
            PeriodUpr.SelectedValue = my.Uper;
            //zap();
            if (identpr != my.identpr) { RdWr(false); } else { RdWr(my.Dostup); }
            NotRem = false;
            textBox16.Enabled = true;
            Button2.Enabled = my.KontrolA0();
            idSm.Enabled = Button2.Enabled;
            if (my.UserInGroup(my.Id_us,52) & smrUpr.Checked)
            {
                button7.Enabled = true;
                button8.Enabled = true;
            }
            if (my.ExeScalar("exec sZakrNZ " + idf2 + "," + my.Id_us + ",1") == "1")
            {
                btnZakrNZ.Text = "НЗ закрыто!";
            }
            Save1 = true;
            Upr = smrUpr.Checked;
            WithLoad = false;
            Console.Write("finish1 " + DateTime.Now.TimeOfDay.ToString());

        }
        //private void zap()
        //{
        //    //On Error Resume Next
        //   // Dgv3.VLadd("idf2child", "Корректирующий акт", "SELECT     Idf2, kodunic FROM         forma2  where idobj = " + IdObj.SelectedValue + "  order by kodunic", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
        //    //SSUltraGrid2.Bands(0).Columns["idwho"].ValueList = VL("SELECT     Identpr, shNMentpr FROM         sprav.dbo.tsentpr order by shNMentpr", "idwho", SSUltraGrid2, cn1);
        //    //SSUltraGrid2.Bands(0).Columns["idfor"].ValueList = VL("SELECT     Identpr, shNMentpr FROM         sprav.dbo.tsentpr order by shNMentpr", "idfor", SSUltraGrid2, cn1);
        //    //SSUltraGrid3.Bands(0).Columns["idf2child"].ValueList = VL("SELECT     Idf2, kodunic FROM         forma2 where idobj = " + пс_Объект.BoundText + "   order by kodunic", "idf2", SSUltraGrid3, cn1);
        //}
        private void ObnObor()
        {
            //MySpisok 47, " and IdF2 = " & IdF2 & " order by OrderNom", Nothing, Me.SSUltraGrid1, cn1

            string s = my.FilterSel(47, this, my.sconn, " and IdF2 = " + idf2.ToString() + " order by OrderNom");
            ds = new DataSet();
            da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];


            Dgv1.VLadd("IdMarka", "Марка", "SELECT     IdMarka, NMMarka FROM         archtd.dbo.tsMarka order by NMMarka", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 4);
            my.naimDG(my.headStr, Dgv1, my.widthStr);
            da.UpdateCommand = new SqlCommand();
            da.UpdateCommand.Connection = my.cn;
            da.UpdateCommand.CommandText = "UPDATE dbo.tObor SET  OrderNom = @p1, NMObor = @p2,IdMarka = @p3, Price = @p4  WHERE ([IdObor] = @p5) ";
            da.UpdateCommand.Parameters.Add("@p1", SqlDbType.TinyInt, 0, "OrderNom");
            da.UpdateCommand.Parameters.Add("@p2", SqlDbType.VarChar, 255, "NMObor");
            da.UpdateCommand.Parameters.Add("@p3", SqlDbType.Int, 0, "IdMarka");
            da.UpdateCommand.Parameters.Add("@p4", SqlDbType.Decimal, 18, "Price");
            da.UpdateCommand.Parameters.Add("@p5", SqlDbType.Int, 0, "IdObor");
            

        }
        private void RdWrAfterZak(int idZak)
        {
            if (idZak != 0)
            {
                idSm.Enabled = true;
                idDog.Enabled = true;
                Naim.Enabled = true;
                lDataDog.Enabled = true;
                IdObj.Enabled = true;
            }
            else
            {
                idSm.Enabled = false;
                idDog.Enabled = false;
                lDataDog.Enabled = false;
                IdObj.Enabled = false;
            }
        }
        private void ObnProrab()
        {
            my.FillDC(idProrab, 26, " and iddep = " + idDep.SelectedValue.ToString());
        }
        private void ObnSmeta()
        {
            try
            {


            DataSet ds = new DataSet();
            String s = "SELECT     IdSm, Nomer, NMSmeti FROM         dbo.vIzSmetaSm Where idSm = 0 or ( IdObj=" + (IdObj.SelectedValue == null ? "0" : IdObj.SelectedValue.ToString()) + ") and idZak = " + idZak.SelectedValue.ToString() + " order by nomer";
            SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
            da.Fill(ds);

            idSm.DataSource = ds.Tables[0];
            idSm.DisplayMember = "Nomer";
            idSm.ValueMember = "IdSm";
            idSm.RefreshColumns();
            }
            catch (Exception)
            {


            }

        }
        private void ObnF3Predjav()
        { if (idDog.SelectedValue != null) { my.FillDC(idF3Predjav, 24, " and iddog = " + idDog.SelectedValue.ToString()); } }

        private void ObnPrivIspol()
        { my.FillDC(F2Priv, 27, ""); my.FillDC(IdFromPriv, 27, ""); }

        private void ObnDog()
        {
            try
            {


            String strsql;
            if (idGP.SelectedValue.ToString() == "-1")
            {
                strsql = "Select distinct   IdDog,  RegNomer, ZakName, IspName, Date_1, PredmetDog, TipVneshDog  from v_IzDogF2 Where ";
                strsql = strsql + "((idFactZak=" + idZak.SelectedValue.ToString() + " AND TipVneshDog='2' ";
                strsql = strsql + "And idIsp=" + my.identpr.ToString() + ") ";
                strsql = strsql + "OR (TipVneshDog='2'  ";
                strsql = strsql + " AND idZak=" + idZak.SelectedValue.ToString() + ") or (IdDog=0)) ";
                strsql = strsql + "ORDER BY RegNomer";
            }
            else
            {
                strsql = "Select distinct   IdDog,  RegNomer, ZakName, IspName, Date_1, PredmetDog, TipVneshDog from v_IzDogF2  Where ";
                strsql = strsql + "((idFactZak=" + "'" + idZak.SelectedValue.ToString() + "'" + " AND TipVneshDog='1' ";
                strsql = strsql + " AND TipGPDog='2' AND CodGP='" + UGP + "') ";
                strsql = strsql + " OR (TipVneshDog='1' AND TipGPDog='1' AND  CodGP ='" + UGP + "'";
                strsql = strsql + " AND idZak=" + "'" + idZak.SelectedValue.ToString() + "'" + ") or (IdDog=0))";
                strsql = strsql + " ORDER BY RegNomer";
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strsql, my.cn);
            da.Fill(ds);
            idDog.DataSource = ds.Tables[0];
            idDog.ValueMember = "IdDog";
            idDog.DisplayMember = "RegNomer";
            da.Dispose();
            ds.Dispose();
            }
            catch (Exception)
            {


            }
        }

        //private void idProrab_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //ObnProrab();
        //    //idProrab.SelectedValue = 0;
        //}

        private void chProrab_CheckedChanged(object sender, EventArgs e)
        {
            if (chProrab.Checked)
            {
                idProrab.Enabled = true;
                ObnProrab();
            }
            else
            {
                idProrab.Enabled = false;
                idProrab.SelectedValue = 0;
            }
        }

        private void idDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!my.IsNumeric(idDog.SelectedValue)) return;
            idF3Predjav.SelectedValue = 0;
            if (idDog.Text != "(пусто)")
            {
                String strsql = "select * from v_IzDogF2 where IdDog =" + idDog.SelectedValue;
                my.cn.Open();
                my.sc.CommandText = strsql;
                SqlDataReader DRd = my.sc.ExecuteReader();
                DRd.Read();
                if (DRd["iddog"] != DBNull.Value)
                {
                    lDataDog.Text = (string)(DRd["Date_1"] == DBNull.Value ? "" : "от " + DRd["Date_1"].ToString());
                    if (DRd["TipVneshDog"].ToString() == "1")
                    {
                        chSnjatieSKon.Enabled = true;
                        chSnjatieSKonBudOplZak.Enabled = true;
                    }
                    else
                    {
                        chSnjatieSKon.Checked = false; chSnjatieSKon.Enabled = false;
                        chSnjatieSKonBudOplZak.Checked = false; chSnjatieSKonBudOplZak.Enabled = false;
                    }
                    lStoroni.Text = "Стороны:      " + DRd["ZakName"].ToString() + "     и     " + DRd["IspName"].ToString();
                }

                DRd.Close();
                DRd.Dispose();
                my.cn.Close();
            }
            else
            {
                chSnjatieSKon.Checked = false; chSnjatieSKon.Enabled = false;
                chSnjatieSKonBudOplZak.Checked = false;
                lStoroni.Text = "Стороны:      ";
                lDataDog.Text = "";
            }
            ObnF3Predjav();

        }

        private void textBox15_Click(object sender, EventArgs e)
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

        private void textBox15_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            if (tb.Text != "")
            {
                if (tb.Name != "textBox2" && tb.Name != "textBox25") { tb.Text = System.Math.Round(Convert.ToDouble(tb.Text)).ToString(); };
                if (tb.Name == "textBox2" || tb.Name == "textBox3" || tb.Name == "textBox4")
                {
                    ObnOplatu();
                }
            }
            else
            { tb.Text = "0"; }
        }
        private void ObnOplatu()
        {
            textBox5.Text = Convert.ToString(Convert.ToDouble(textBox2.Text) - (Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox4.Text)));
        }
        private void ObnObject()
        {
            try
            {
            my.FillDC(IdObj, 10, " and idZak=" + idZak.SelectedValue.ToString() + " or IdObj=0 ");
            }
            catch (Exception)
            {

            }

        }

        private void idZak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save1)
            {
                RdWrAfterZak(idZak.SelectedIndex);
                ObnObject();
                IdObj.SelectedValue = 0;
                ObnDog();
                idDog.SelectedValue = 0;
                ObnF3Predjav();
                idF3Predjav.SelectedValue = 0;
                ObnSmeta();
                  idSm.SelectedValue = 0;
           }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Dgv1_UserDeletingRow(null, null);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RegNomer.Focus();
            if (ds.HasChanges()) { my.Up(da, ds.Tables[0]); };
            my.sc.CommandText = "insert into tObor (  IdF2, OrderNom) select " + idf2.ToString() + ", isnull(max(ordernom),0) + 1 from tobor where idf2 = " + idf2.ToString();
            my.cn.Open();
            my.sc.ExecuteScalar();
            my.cn.Close();
            ObnObor();
            Dgv1.CurrentCell = Dgv1.Rows[Dgv1.RowCount - 1].Cells[1];
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            Save(0);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Dgv1.SelectedRows.Count == 0) { Dgv1.CurrentRow.Selected = true; }
            my.cn.Open();
            foreach (DataGridViewRow selrow in Dgv1.SelectedRows)
            {
                my.sc.CommandText = "delete from tobor where  IdObor = " + selrow.Cells[0].Value;
                my.sc.ExecuteScalar();
            }
            my.cn.Close();
            ObnObor();
            //e.Cancel = true;

        }
        private void ObnSvCh()
        {
            if (rbSv.Checked == true)
            {
                idDep.Enabled = true;
                OchUch();
                OchPriv();
                F2Priv.Enabled = false;
                IdFromPriv.Enabled = false;
                chProrab.Enabled = true;
                idProrab.SelectedValue = 0;
            }
            else
            {
                OchUch();
                idDep.Enabled = false;
                idProrab.SelectedValue = 0;
                chProrab.Checked = false;
                //chProrab.Enabled = false;
                idProrab.Enabled = false;
                F2Priv.Enabled = true;
                IdFromPriv.Enabled = true;
                chProrab.Enabled = true;
                OchPriv();
                idProrab.SelectedValue = 0;
            }
        }

        private void OchPriv()
        {
            F2Priv.SelectedValue = 0;
            IdFromPriv.SelectedValue = 0;
            chSnjatie.Checked = false;
            chSnjatie.Enabled = false;
        }
        private void OchUch()
        {
            idProrab.SelectedValue = 0;
            chProrab.Checked = false;
            idDep.SelectedValue = 0;
        }

        private void rbPriv_CheckedChanged(object sender, EventArgs e)
        {
            if (Save1 == true) ObnSvCh();
        }

        private void Save(int AfterClose)
        {
            try
            {
                if (!my.KontrolSMR(Period, my.identpr, 0)) return;
            if (ds.HasChanges()) { my.Up(da, ds.Tables[0]); };
            if (dskorr.HasChanges()) { my.Up(dakorr, dskorr.Tables[0]); };
            lblKorr.Text = my.ExeScalar("select dbo.fOstParent (" + idf2 + ")");
            if (idSm.SelectedValue == null | (int)idSm.SelectedValue == 0) { MessageBox.Show("Не заполнено поле сметы. Сохранение невозможно!"); return; }
            String strsql; //String str1;
            strsql = "";
            if (!my.InF3(idf2))
            {
                strsql = "UPDATE Forma2 SET idZak=" + idZak.SelectedValue.ToString() + ", IdObj=" + IdObj.SelectedValue.ToString() + ",";
                strsql = strsql + " VozvratMat=" + textBox3.Text + "," + " DavMat=" + textBox4.Text + ",";
            }

            else
            { strsql = "UPDATE Forma2 SET"; }

            strsql = strsql + " VipTek=" + textBox2.Text + ",";

            strsql = strsql + " Shifr='" + Shifr.Text + "',";
            if (idF3Predjav.SelectedValue == null || idF3Predjav.SelectedValue.ToString() == "")
            { strsql = strsql + " idF3Predjav=0,"; }
            else
            { strsql = strsql + " idF3Predjav=" + idF3Predjav.SelectedValue.ToString() + ","; }

            strsql = strsql + " IdDog=" + idDog.SelectedValue.ToString() + ",";
                strsql = strsql + " IdVidDog=" + IdVidDog + ",";
                strsql = strsql + " IdGP=" + idGP.SelectedValue.ToString() + ",";
            strsql = strsql + " Vip84=" + textBox0.Text + ",";
            strsql = strsql + " Vip91=" + textBox1.Text + ",";
            strsql = strsql + " Vip84Pr=" + textBox26.Text + ",";
            strsql = strsql + " Vip91Pr=" + textBox27.Text + ",";
            strsql = strsql + " KomRash91=" + textBox28.Text + ",";
            strsql = strsql + " ZimUdor91=" + textBox29.Text + ",";
            strsql = strsql + " PerevRab91=" + textBox30.Text + ",";
            strsql = strsql + " Vip91PN=" + textBox31.Text + ",";
            strsql = strsql + " VipTekPN=" + textBox32.Text + ",";
            strsql = strsql + " Vip84PN=" + textBox33.Text + ",";
            strsql = strsql + " ZpMeh=" + textBox40.Text + ",";

            strsql = strsql + " ZimUdor84=" + textBox6.Text + ",";
            strsql = strsql + " Mr84=" + textBox34.Text + ",";
            strsql = strsql + " Mr91=" + textBox35.Text + ",";
            strsql = strsql + " MrTek=" + textBox36.Text + ",";
            strsql = strsql + " Sr84=" + textBox37.Text + ",";
            strsql = strsql + " Sr91=" + textBox38.Text + ",";
            strsql = strsql + " SrTek=" + textBox39.Text + ",";
            strsql = strsql + " OborTek=" + textBox43.Text + ",";
            strsql = strsql + " ZVahMetod=" + textBox44.Text + ",";
            strsql = strsql + " ZPerebaz=" + textBox45.Text + ",";
            strsql = strsql + " ZProch=" + textBox46.Text + ",";

            strsql = strsql + " IdSm=" + idSm.SelectedValue.ToString();
            strsql = strsql + ", IdIstFin=" + idIstFin.SelectedValue.ToString();
            strsql = strsql + ", idprice =" + IdPrice.SelectedValue;
            strsql = strsql + ", OplDrGP =" + (chOplDrGP.Checked ? "1" : "0");
            strsql = strsql + ", IskluchNZ = " + (ChIskluch.Checked ? "1" : "0");
            strsql = strsql + ", flSnjatieNZP= " + (flSnjatieNZP.Checked ? "1" : "0") ;

                strsql = strsql + ", Naim=" + "'" + Naim.Text + "'";
            if (RegNomer.Text != "" && RegNomer.Text != null)
            {
                strsql = strsql + ", RegNomer=" + RegNomer.Text;
            }
            else
            { strsql = strsql + ", RegNomer=NULL"; }

            if (rbSv.Checked)
            {
                strsql = strsql + ", SvCh=1";
                my.cn.Open();
                int idisp; int idprorabC = 0;
                if (chProrab.Checked && idProrab.SelectedValue != null )
                {
                       // if ((int) idProrab.SelectedValue !=0)
                    idprorabC = (int)idProrab.SelectedValue;
                }


                    string s = "";
                    if (idprorabC != 0)
                        s = "select idisp from ispol  WHERE Idprorab=" + idprorabC.ToString() + " and iddep = " + idDep.SelectedValue.ToString();
                    else
                        s = "SELECT    top 1    dbo.Ispol.IdIsp FROM dbo.Ispol INNER JOIN dbo.Prorab ON dbo.Ispol.IdProrab = dbo.Prorab.IdProrab  WHERE dbo.Prorab.Prorab='" + idProrab.Text + "' and dbo.Ispol.iddep = " + idDep.SelectedValue.ToString();
                my.sc.CommandText = s;
                idisp = (int)my.sc.ExecuteScalar();
                    if (idisp == 0) { MessageBox.Show("Не выбран исполнитель. Сохранение невозможно!"); return; }

                    strsql = strsql + ", IdIsp=" + idisp.ToString();
                my.sc.CommandText = "DELETE FROM F2Priv WHERE IdF2=" + idf2.ToString();
                my.sc.ExecuteScalar();
                my.cn.Close();
            }
            if (rbPriv.Checked)
            {
                strsql = strsql + ", SvCh=2";
            }
            //' вторая страница
            strsql = strsql + "," + " OsnZp=" + textBox7.Text;
            strsql = strsql + ", Meh=" + textBox8.Text + ", Mat=" + textBox9.Text + ", Nakl=" + textBox10.Text + ", Planov=" + textBox11.Text;
            strsql = strsql + ", KompZp=" + textBox12.Text + ", KompMeh=" + textBox13.Text + ", KompMat=" + textBox14.Text;
            strsql = strsql + ", VremZd=" + textBox15.Text + ", ZimUdor=" + textBox16.Text + ", PerevRab=" + textBox17.Text;
            strsql = strsql + ", KomRash=" + textBox18.Text + ", PodvHar=" + textBox19.Text + ", NeprRash=" + textBox20.Text + ", ProzhVGost=" + textBox21.Text;
            strsql = strsql + ", SostSmet=" + textBox22.Text + ", OtchVDorFond=" + textBox23.Text + ", ProchRash=" + textBox24.Text + ", TR=" + textBox306.Text + ", PrinZak = " + textBox25.Text + ", PrinZak84 = " + textBox41.Text + ", PrinZak91 = " + textBox42.Text;
            //strsql = strsql + ", ZVahMetod=" + textBox44.Text + ",";
            //strsql = strsql + " ZPerebaz=" + textBox45.Text + ",";
            //strsql = strsql + " ZProch=" + textBox46.Text ;
            //'третья страница
            strsql = strsql + ", Snjatie=" + (chSnjatie.Checked ? "1" : "0") + ", SnjatieSKon=" + (chSnjatieSKon.Checked ? "1" : "0") + ", SnjatieSKonBudOplZak=" + (chSnjatieSKonBudOplZak.Checked ? "1" : "0") + ", Vzamen =" + (ChVzamen.Checked ? "1" : "0") + ", VremProc =" + (chVremProc.Checked ? "1" : "0") + ", Avans=" + (chAvans.Checked ? "1" : "0") + ", Skr=" + (chSkr.Checked ? "1" : "0");
            strsql = strsql + ", SnjatieNotSub=" + (chSnjatieNotSub.Checked ? "1" : "0");
            strsql = strsql + ", VklVSmRazlTekMes=" + (chVklVSmRazlTekMes.Checked ? "1" : "0") + ", Prim=" + "'" + Prim.Text + "'";
            strsql = strsql + ", BankProc=" + (chBankProc.Checked ? "1" : "0");
            strsql = strsql + ", PodpCur=" + (chPodpCur.Checked ? "1" : "0") + ", flNetitul=" + (flNetitul.Checked ? "1" : "0");
            strsql = strsql + ", RealZak=" + (RealZak.Checked ? "1" : "0");

                if (chPodpCur.Checked)
                {
                    strsql = strsql + ", DatePodpCur=" + "'" + DatePodpCur.Text + "'";
                }
                else
                {
                    strsql = strsql + ", DatePodpCur=NULL";
                }
                if (chPolNZ.Checked)
                {
                    strsql = strsql + ", DateNZ=" + "'" + DatePolNZ.Text + "'";
                }
                else
                {
                    strsql = strsql + ", DateNZ=NULL";
                }

                strsql = strsql + ", PodpForF3=" + (chPodpForF3.Checked ? "1" : "0");
                if (chPodpForF3.Checked)
                {
                    strsql = strsql + ", DatePodpForF3=" + "'" + DatePodpForF3.Text + "'";
                }
                else
                {
                    strsql = strsql + ", DatePodpForF3=NULL";
                }

                strsql = strsql + ", idPodpKS6=" + idPodpKS6.SelectedValue;
                strsql = strsql + ", idPrichinaNZP=" + idPrichinaNZP.SelectedValue;

                strsql = strsql + ", update_date ='" + System.DateTime.Now.ToString() + "'";
            strsql = strsql + ", update_user ='" + my.Login + "'";
            strsql = strsql + ", IdEntForPO =" + IdEntForPO.SelectedValue;
            strsql = strsql + ", IdEntprForDM =" + IdEntprForDM.SelectedValue;
            strsql = strsql + " Where IdF2 = " + idf2.ToString();
            my.cn.Open();

            my.sc.CommandText = strsql;
            my.sc.ExecuteScalar();

            //'привлеченный исполнитель
            if (rbPriv.Checked)
            {
                my.sc.CommandText = "update Forma2 set idisp = 0 where idf2 = " + idf2.ToString();
                my.sc.ExecuteScalar();
                my.sc.CommandText = "select * from F2Priv WHERE idf2=" + idf2.ToString();
                //my.sc.ExecuteScalar();
                if (my.sc.ExecuteScalar() == null) // нет записи
                { my.sc.CommandText = "Insert into F2Priv(IdF2,Priv,Idfrompriv) VALUES (" + idf2.ToString() + "," + F2Priv.SelectedValue.ToString() + ", " + IdFromPriv.SelectedValue.ToString() + ")"; }
                else
                { my.sc.CommandText = "UPDATE F2Priv SET Priv=" + F2Priv.SelectedValue.ToString() + ",IdFrompriv = " + IdFromPriv.SelectedValue.ToString() + " WHERE IdF2=" + idf2.ToString(); }
                my.sc.ExecuteScalar();
            }
            //'движение акта формы №2
            strsql = "UPDATE MoveF2 SET PostChern=" + (chPostChern.Checked ? "1" : "0") + ", OtprZak=" + (chOtprZak.Checked ? "1" : "0") + ", PodpZak=" + (chPodpZak.Checked ? "1" : "0");
            strsql = strsql + ", DatePostChern=" + (chPostChern.Checked ? "'" + DatePostChern.Text + "'" : "Null");
            strsql = strsql + ", DateOtprZak=" + (chOtprZak.Checked ? "'" + DateOtprZak.Text + "'" : "Null");
            strsql = strsql + ", DatePodpZak=" + (chPodpZak.Checked ? "'" + DatePodpZak.Text + "'" : "Null");

            strsql = strsql + ", Lastlogin= '" + LastLogin.Text + "'";
            strsql = strsql + ", update_date ='" + System.DateTime.Now.ToString() + "'";
            strsql = strsql + ", update_user ='" + my.Login + "'";
            strsql = strsql + " WHERE IdF2=" + idf2.ToString();
            my.sc.CommandText = strsql;
            my.sc.ExecuteScalar();

                if (smrUpr.Enabled)
                {
                    strsql = strsql + ", smrUpr=" + System.Convert.ToString(smrUpr);
                    my.sc.CommandText = "exec sUprCopyf2 " + System.Convert.ToString(idf2) + "," + my.Id_us + "," + (smrUpr.Checked ? 1 : 0) + "," + (Check1.Checked ? "'" + PeriodUpr.SelectedValue + "'" : "null");
                    my.sc.ExecuteScalar();
                }

                if (AfterClose != 1)
            {
                MessageBox.Show("Данные сохранены");
            }
            my.cn.Close();

            }
            catch (Exception ex)
            {

               if (my.cn.State == ConnectionState.Open) my.cn.Close();
                MessageBox.Show(ex.Message);
            }
            //Exit Sub
            //ex:
            //MessageBox.Show "Данные заполнены не верно! Сохранение невозможно!" & err.Description
            //}
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!my.KontrolSMR(Period, my.identpr, 0)) return;
            if (MessageBox.Show("Удалить акт?", "Внимание!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) 
            {
                if (my.InF3(idf2))
                {
                    MessageBox.Show("Удалить акт нельзя, поскольку он взят в справку формы №3");
                    return;
                }
                else if (my.ExeScalar("select idF2 from SootvF2Parent where idF2 =" + idf2) != "")
                {
                    MessageBox.Show("К акту " + kodunic + " добавлены дочерние акты. Удалите сначала их!"); return;
                }
                else
                {
                    my.ExeScalar("update Forma2 set  update_date ='" + DateTime.Now + "'" + ", update_user ='" + my.Login + "' WHERE IdF2=" + idf2 + "; DELETE FROM Forma2 WHERE IdF2=" + idf2.ToString());
                    //my.sc.CommandText = "DELETE FROM Forma2 WHERE IdF2=" + idf2.ToString();
                    //my.cn.Open();
                    //my.sc.ExecuteScalar();
                    //my.cn.Close();
                    Save1 = false;
                    Close();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Button2.Text = "Измените номер сметы";
            NotRem = true;
            idSm.Enabled = true;
            IdObj.Enabled = true;
            idsm = (int)idSm.SelectedValue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Double Lch; Double Rch; Double Rch84 = 0; Double Rch91 = 0;
            textBox39.Text = "0";
            textBox36.Text = "0";
            textBox34.Text = "0";
            textBox37.Text = "0";
            textBox35.Text = "0";
            textBox38.Text = "0";
            Lch = Convert.ToDouble(textBox2.Text); Rch = 0;
            for (int i1 = 1; i1 <= 11; i1++)
            {
                if (i1 != 9) Rch = Rch + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
                if (this.tableLayoutPanel2.GetControlFromPosition(1, i1).Text.Trim() != "") Rch84 = Rch84 + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(1, i1).Text);
                if (this.tableLayoutPanel2.GetControlFromPosition(2, i1).Text.Trim() != "") Rch91 = Rch91 + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(2, i1).Text);

            }
            Rch = Lch - Rch;
            Rch84 = Convert.ToDouble(textBox0.Text) - Rch84;
            Rch91 = Convert.ToDouble(textBox1.Text) - Rch91;
            if (rbStr.Checked)
            {
                textBox39.Text = Convert.ToString(Rch);
                textBox36.Text = "0";
                textBox37.Text = Convert.ToString(Rch84);
                textBox34.Text = "0";
                textBox38.Text = Convert.ToString(Rch91);
                textBox35.Text = "0";
            }
            else
                if (rbMont.Checked)
                {
                    textBox39.Text = "0";
                    textBox36.Text = Convert.ToString(Rch);
                    textBox34.Text = Convert.ToString(Rch84);
                    textBox37.Text = "0";
                    textBox35.Text = Convert.ToString(Rch91);
                    textBox38.Text = "0";
                }

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAct_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Me.SSUltraGrid1.Update
            if (Save1)
            {
                DialogResult otv = MessageBox.Show("Сохранить данные?", "Внимание!", MessageBoxButtons.YesNoCancel);
                if (otv == DialogResult.Yes) { Save(1); }
                if (otv == DialogResult.Cancel) { e.Cancel = true; return; }
            }


            if (pform1.Name == "frmActs") { ((frmActs)pform1).spisok(); }
            if (pform1.Name == "frmSprDGV") { ((frmSprDGV)pform1).spisok(""); }
            //     If fr.Name = "Zapros" Then fr.spisok

        }

        private void chOplDrGP_CheckedChanged(object sender, EventArgs e)
        {
            if (chOplDrGP.Checked)
            {
                idGP.Enabled = true;
                idDog.Enabled = true;
            }
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (Dgv1.Columns[e.ColumnIndex].Name)
            {
                case "IdMarka":
                    my.Nbut = 51;
                    break;
                default:
                    my.Nbut = 0;

                    break;
            }
            if (my.Nbut == 0) return;
            my.Szap = "";
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, true, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Double Lch; Double Rch;
            Lch = Convert.ToDouble(textBox2.Text); Rch = 0;
            for (int i1 = 14; i1 <= 28; i1++)
            {
                if (this.tableLayoutPanel1.GetControlFromPosition(1, i1) == null) continue;
                if (i1 != 16 && this.tableLayoutPanel1.GetControlFromPosition(1, i1).GetType().Name == "TextBox")
                {
                    Rch = Rch + Convert.ToDouble(this.tableLayoutPanel1.GetControlFromPosition(1, i1).Text);
                    //MessageBox.Show(this.tableLayoutPanel1.GetControlFromPosition(1, i1).Text);
                }
            }
            for (int i1 = 1; i1 <= 17; i1++)
            {
                if (i1 != 9 & i1!= 12 & i1 != 13 & i1 != 14)
                {
                    Rch = Rch + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
                    //MessageBox.Show(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
                }
            }

            if (Lch != Rch)
            { MessageBox.Show("1-ый этап (без разделения на строительные и монтажные работы) - Не идет сумма итогов на  " + Convert.ToString(Lch - Rch)); }
            else
            { MessageBox.Show("1-ый этап (без разделения на строительные и монтажные работы) - Верно !"); }

           Lch = Convert.ToDouble(textBox2.Text); Rch = 0;

            //for (int i1 = 14; i1 <= 28; i1++)
            //{
            //    if (this.tableLayoutPanel1.GetControlFromPosition(1, i1) == null) continue;
            //    if (i1 != 16 && this.tableLayoutPanel1.GetControlFromPosition(1, i1).GetType().Name == "TextBox")
            //    {
            //        Rch = Rch + Convert.ToDouble(this.tableLayoutPanel1.GetControlFromPosition(1, i1).Text);
            //        //MessageBox.Show(this.tableLayoutPanel1.GetControlFromPosition(1, i1).Text);
            //    }
            //}
            for (int i1 = 1; i1 <= 14; i1++)
            {
                if (i1 != 9 & i1 != 12)
                {
                    Rch = Rch + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
                    //MessageBox.Show(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
                }
            }

            if (Lch != Rch)
            { MessageBox.Show("2-oй этап (c разделением на строительные и монтажные работы) - Не идет сумма итогов на  " + Convert.ToString(Lch - Rch)); }
            else
            { MessageBox.Show("2-oй этап (с разделением на строительные и монтажные работы) - Верно !"); }
            //for (int i1 = 1; i1 <= 14; i1++)
            //{
            //    if (i1 != 12 && i1 != 9) Rch = Rch + Convert.ToDouble(this.tableLayoutPanel2.GetControlFromPosition(3, i1).Text);
            //}


            //if (Lch != Rch)
            //{ MessageBox.Show("2-ой этап (c разделением на строительные и монтажные работы) - Не идет сумма итогов на  " + Convert.ToString(Lch - Rch)); }
            //else
            //{ MessageBox.Show("2-ой этап (с разделением на строительные и монтажные работы) - Верно !"); }


        }

        private void DatePodpZak_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void idGP_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(Save1 == true)
            {
                UGP = my.ExeScalar("select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + idGP.SelectedValue);
                IdVidDog = my.ExeScalar("SELECT IdVidDog FROM dbo.VidGPDog WHERE  Pred = '" + UGP + "'");
                    ObnDog();idDog.SelectedValue = 0;
            }
        }

        private void idDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save1 == true) ObnProrab(); idProrab.SelectedValue = 0; idProrab.Text = "";
        }

        private void idSm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save1 == true)
            {
                if (NotRem)
                {
                    if (idsm != (int)idSm.SelectedValue)
                    {
                        Button2.Text = "Изменить смету, не меняя наименование акта";
                        NotRem = false;
                        idSm.Enabled = false;
                        IdObj.Enabled = false;

                    }
                    return;
                }
                if (idSm.Text == "")
                {
                    idSm.SelectedValue = 0;
                }
                else
                if (my.IsNumeric(idSm.SelectedValue) && (int)idSm.SelectedValue != 0)
                {
                    my.sc.CommandText = "select nmsmeti from sprav.dbo.tsmeti where idsm = " + idSm.SelectedValue.ToString();
                    my.cn.Open();
                    Naim.Text = my.sc.ExecuteScalar().ToString();
                    my.cn.Close();
                    my.sc.CommandText = "SELECT     WorkFull FROM         Sprav.dbo.tSmeti where idsm =  " + idSm.SelectedValue.ToString();
                    my.cn.Open();
                    if ((bool)my.sc.ExecuteScalar()) MessageBox.Show("По этой смете работы завершены.");
                    my.cn.Close();
                }
            }
        }

        private void IdObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save1 == true) ObnSmeta();
        }

        private void F2Priv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save1 == true)
            {
                if ((int)F2Priv.SelectedValue == 0)
                {
                    chSnjatie.Checked = false; chSnjatie.Enabled = false;
                }
                else
                {
                    chSnjatie.Enabled = true;
                }
            }
        }

        private void rbSv_CheckedChanged(object sender, EventArgs e)
        {
            if (Save1 == true) ObnSvCh();
        }

        private void chPodpZak_CheckedChanged(object sender, EventArgs e)
        {
            if (Save1 == true)
            {
                CheckBox ch = (CheckBox)sender;
                if (ch.Checked)
                {
                    tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Visible = true;
                    tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Text = DateTime.Today.ToString("dd.MM.yyyy");
                }
                else
                { tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Visible = false; }

                LastLogin.Text = my.Login;
            }
        }

        private void chSnjatieSKon_CheckedChanged(object sender, EventArgs e)
        {
            if (chSnjatieSKon.Checked) { chSnjatieSKonBudOplZak.Checked = false; }
        }

        private void chSnjatieSKonBudOplZak_CheckedChanged(object sender, EventArgs e)
        {
            if (chSnjatieSKonBudOplZak.Checked) { chSnjatieSKon.Checked = false; }
        }

        private void RdWrch(bool wr, Control c)
        {
            foreach (Control childc in c.Controls)
            {
                if (childc.HasChildren) RdWrch(wr, childc);
                //MessageBox.Show(childc.Name);
                if (childc is TextBox)
                {
                    if (childc.Enabled == true) { childc.Enabled = wr; }
                }
            }
        }
        private void RdWr(bool wr)
        {

            foreach (Control c in Controls)
            {
               // MessageBox.Show(c.Name);
                if (c.HasChildren) RdWrch(wr, c);

            }
        

            Button3.Enabled = wr;
            Button1.Enabled = wr;
        }



        private void idZak_EnabledChanged(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "ComboBox" || sender.GetType().Name == "MultiColumnComboBox")
            {
                ComboBox c = (ComboBox)sender;
                if (c.Enabled)
                    c.DropDownStyle = ComboBoxStyle.DropDown;
                else
                    c.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (sender.GetType().Name == "TextBox")
            {
                TextBox c = (TextBox)sender;
                c.BackColor = Color.White;
                            }

        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void smrUpr_CheckedChanged(object sender, EventArgs e)
        {
            if (WithLoad) return;
            if (smrUpr.Checked == Upr)   return;
            if (my.KontrolUpr(Period,0,0) == false)
            {
                smrUpr.Checked = Upr;
            }
            else
            {
               LoginSmrUpr.Text = my.Login;
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
          my.ExeScalar( "insert into SootvF2Parent (  IdF2,Idf2Child,SumChild) values (" + idf2 + "," + idf2 + ",0)");
            ObnKorrActs();
            Dgv3.Rows[Dgv3.Rows.Count - 1].Selected = true;
            //Dgv3.SelectedRows = this.SSUltraGrid2.GetRow(ssChildRowLast);
        }
        private void ObnKorrActs()
        {
            //my.MySpisok 47, " and IdF2 = " + idf2 + " order by OrderNom", null, this.SSUltraGrid1, cn1;
            //my.MySpisok 181, " and IdF2 = " + idf2 + "", null, this.SSUltraGrid2, cn1;
            //my.MySpisok( 211, " and IdF2 = " + idf2 + "", null, Dgv3);
            string s = my.FilterSel(211, this, my.sconn, " and IdF2 = " + idf2.ToString() );
            dskorr = new DataSet();
            dakorr = new SqlDataAdapter(s, my.sconn);
            dskorr.Clear();
            dakorr.Fill(dskorr);
            Dgv3.DataSource = dskorr.Tables[0];

             Dgv3.VLadd("idf2child", "Корректирующий акт", "SELECT     Idf2, kodunic FROM         forma2  where idsm = "  + (idSm.SelectedValue == null ? 0:idSm.SelectedValue) + " or idf2  IN (SELECT  IdF2Child FROM dbo.SootvF2Parent WHERE (IdF2 = " + idf2+"))   order by kodunic", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
            //Dgv3.VLadd("idf2child", "Корректирующий акт", "SELECT     Idf2, kodunic FROM         forma2    order by kodunic", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);

             //Dgv3.VLadd("idf2child", "Корректирующий акт", "SELECT     Idf2, kodunic FROM         forma2  where year(Period) >= 2010  order by kodunic", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);

            my.naimDG(my.headStr, Dgv3, my.widthStr);
            dakorr.UpdateCommand = new SqlCommand();
            dakorr.UpdateCommand.Connection = my.cn;
            dakorr.UpdateCommand.CommandText = "UPDATE dbo.SootvF2Parent SET   IdF2Child = @IdF2Child, SumChild = @SumChild,SumChildZam = @SumChildZam  WHERE IdSootvParent = @IdSootvParent";
            dakorr.UpdateCommand.Parameters.Add("@IdF2Child", SqlDbType.Int, 0, "IdF2Child");
            dakorr.UpdateCommand.Parameters.Add("@SumChild", SqlDbType.Float, 255, "SumChild");
            dakorr.UpdateCommand.Parameters.Add("@SumChildZam", SqlDbType.Float, 255, "SumChildZam");
            dakorr.UpdateCommand.Parameters.Add("@IdSootvParent", SqlDbType.Int, 0, "IdSootvParent");
            lblKorr.Text = my.ExeScalar("select dbo.fOstParent (" + idf2 + ")");
    }

        private void Delete_Click(object sender, EventArgs e)
        {
            my.ExeScalar("delete SootvF2Parent where idf2 =" +idf2 + " and IdF2Child =" + Dgv3.CurrentRow.Cells["idf2child"].Value );
            ObnKorrActs();

        }

        private void idSm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (idSm.SelectedValue == null ||(int)idSm.SelectedValue == 0)return;

            //try         
            this.Save(1);
            Save1 = false;
            //Form fr = null;
            int idsm = (int)idSm.SelectedValue;

            if (!my.isFormInMdi("frmCapSm", idsm, my.MDIForm))
            {
                frmCapSm fr = new frmCapSm();
                fr.MdiParent = my.MDIForm;
                fr.idsm = idsm;
                fr.Tag = idsm;
                Console.Write("show " + DateTime.Now.TimeOfDay.ToString() + "\n");
                fr.Show();


            }
            //Form fr1 = null;
            //Set fr1 = new frmCapSm();
            //foreach (Form frWithinLoop in Forms)
            //{
            //    fr = frWithinLoop;
            //    if (fr1.Caption == frWithinLoop.Caption)
            //    {
            //        if (Szap == frWithinLoop.idsm)
            //        {
            //            Set fr1 = frWithinLoop;
            //            break;
            //        }
            //    }
            //}
            //Set fr = fr1; //sprSmeta
            //fr.SetFocus;
            //fr.Show(); //1
            //ex:
            //Screen.MousePointer = vbDefault;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            idSm_MouseDoubleClick(null, null);
        }

        private void Check1_CheckedChanged(object sender, EventArgs e)
        {
            PeriodUpr.Enabled = Check1.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                my.ExeScalar("exec sUprCopyf2 " + System.Convert.ToString(idf2) + "," + my.Id_us + "," + (smrUpr.Checked ? 1 : 0) + "," + (Check1.Checked ? "'" + PeriodUpr.SelectedValue + "'" : "null")); 
                MessageBox.Show("Данные обновлены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                my.ExeScalar("exec sUprDelF2 " + idf2);
                MessageBox.Show("Акт удален из Управленческого Учета!");
                smrUpr.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Podpis_Click(object sender, EventArgs e)
        {
            frmSvjaz fr = new frmSvjaz();
            fr.KodUnicNZ.Text = kodunic ;
            fr.ShowDialog();
            ObnKorrActs();
        }

        private void IdPrice_SelectedIndexChanged(object sender, EventArgs e)
        {   if (!my.IsNumeric(IdPrice.SelectedValue)) return;
            if ((int)IdPrice.SelectedValue == 2)
            {
                label16.Visible = false;
                label67.Visible = false;
                textBox0.Visible = false;
                textBox41.Visible = false;
                textBox37.Visible = false;
                textBox34.Visible = false;
                textBox6.Visible = false;
                textBox26.Visible = false;
                textBox33.Visible = false;
                label17.Text = "в ценах 2000г";
                label68.Text = "в ценах 2000";
            }
            else
            {
                label16.Visible = true;
                label67.Visible = true;
                textBox0.Visible = true;
                textBox41.Visible = true;
                textBox37.Visible = true;
                textBox34.Visible = true;
                textBox6.Visible = true;
                textBox26.Visible = true;
                textBox33.Visible = true;
                label17.Text = "в ценах 91г";
                label68.Text = "в ценах 91";
            }
        }

        private void chPolNZ_CheckedChanged(object sender, EventArgs e)
        {
            if (chPolNZ.Checked)
            {
                DatePolNZ.Visible = true;
            }
            else
            {
                DatePolNZ.Visible = false;
            }
        }

        private void chPodpForF3_CheckedChanged(object sender, EventArgs e)
        {
            if (chPodpForF3.Checked)
            {
                DatePodpForF3.Visible = true;
                DatePodpForF3.Text = DateTime.Today.ToString("dd.MM.yyyy");
            }
            else
            {
                DatePodpForF3.Visible = false;
            }
        }

        private void btnZakrNZ_Click(object sender, EventArgs e)
        {
            try
            {

            if (Convert.ToInt32(textBox2.Text) >= 0)
            {
                MessageBox.Show("Акт должен быть минусовым!");
                return;
            }
            my.ExeScalar("exec sZakrNZ " + idf2 + "," + my.Id_us);
            if (Convert.ToInt32(my.ExeScalar("exec sZakrNZ " + idf2 + "," + my.Id_us + ",1")) == 1)
            {
                MessageBox.Show("Готово!");
            
                RealZak.Checked = true;
                btnZakrNZ.Text = "НЗ закрыто!";
            }
            else
            {
                MessageBox.Show("Нет привязки к родительскому акту!");
            }
            return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            my.Szap = " and IdF2Child  = " + idf2;
            my.Nbut = 213;
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, false, false);
            }
        }

        private void Dgv3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv3.Columns[e.ColumnIndex].Name == "idf2child")
            {
                try
                {
                    Dgv3.Rows[e.RowIndex].Cells["SumChild"].Value = my.ExeScalar("SELECT     VipTek FROM         dbo.Forma2 WHERE     IdF2 = " + Dgv3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    Dgv3.Rows[e.RowIndex].Cells["SumChildZam"].Value = Dgv3.Rows[e.RowIndex].Cells["SumChild"].Value;
                    my.ExeScalar("update    SootvF2Parent  set SumChild = " + Dgv3.Rows[e.RowIndex].Cells["SumChild"].Value + ",SumChildZam = " + Dgv3.Rows[e.RowIndex].Cells["SumChildZam"].Value + "  WHERE     IdSootvParent  = " + Dgv3.Rows[e.RowIndex].Cells["idsootvparent"].Value);
                }
                catch (Exception ex)
                {

                }

            }
            //if (dskorr.HasChanges())
            { my.Up(dakorr, dskorr.Tables[0]); };
            lblKorr.Text = my.ExeScalar("select dbo.fOstParent (" + idf2 + ")");
        }

        private void Dgv3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void chPodpCur_CheckedChanged(object sender, EventArgs e)
        {
            if (Save1 == true)
            {
                CheckBox ch = (CheckBox)sender;
                if (ch.Checked)
                {
                    tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Visible = true;
                    tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Text = DateTime.Today.ToString("dd.MM.yyyy");
                }
                else
                { tableLayoutPanel3.GetControlFromPosition(1, this.tableLayoutPanel3.GetCellPosition(ch).Row).Visible = false; }

                LastLogin.Text = my.Login;
            }
        }
    }
}

