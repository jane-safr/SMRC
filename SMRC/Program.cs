using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
//using ConnVar;
namespace SMRC
{
    public static class Program
    {

           [STAThread]
      
        static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //my.Main2();
                DataSet dataSet1= new DataSet(); 
               //DataRow dr;
               // dataSet1.ReadXml("C:/cis/Conn.xml");
               //dr = dataSet1.Tables[0].Rows[0];

               //if (dataSet1.Tables[0].Rows.Count == 1)
               //{
               //    my.Szap = dr[1].ToString();
               //}
               //else
               //{
                  //SMRC.Forms.Conn fr = new SMRC.Forms.Conn();
                  //     fr.ComboBox1.DataSource = dataSet1.Tables[0];
                  //     fr.ComboBox1.ValueMember = dataSet1.Tables[0].Columns[1].ColumnName ;
                  //     fr.ComboBox1.DisplayMember = dataSet1.Tables[0].Columns[2].ColumnName ;
                  //     Application.Run(fr);
               //}
               //if (my.Szap == "") { return; };
                my.Login = SystemInformation.UserName.ToString();
               //my.Login = "e.novikova";
                //my.Login = "n.mitlikina";
               //my.Login = "i.makarenko";
                //my.Login = "o.baeva";
                        {
                           my.sconn = "Initial Catalog=smr;User ID=prog;Password=prog;Data Source=SQL-A0;Connect Timeout=30000000;"; // +my.Szap + ";";
                           my.cn = new SqlConnection(my.sconn);
                           my.cn.ConnectionString = my.sconn;

                my.sconnjane = "Initial Catalog=test;User ID=prog;Password=prog;Data Source=SQL_JANE\\JANE1;Connect Timeout=30000000;"; // +my.Szap + ";";
                my.cnjane = new SqlConnection(my.sconnjane);
                my.cnjane.ConnectionString = my.sconnjane;

                my.sconnReadOnly = "Initial Catalog=smr;User ID=prog;Password=prog;Data Source=SQL-A0;Connect Timeout=30000000;ApplicationIntent=ReadOnly;"; // +my.Szap + ";";
                my.cnReadOnly = new SqlConnection(my.sconnReadOnly);
                my.cnReadOnly.ConnectionString = my.sconnReadOnly;

                
            }
                        //my.Login = "a.vahmyanin";
        my.cn.Open();
            //i.zyubritsaya
            //my.Login = "i.zyubritskaya";
        my.sc = new SqlCommand("select * from dostup.dbo.users  where login =  '" + my.Login + "' ", my.cn);
        //my.sc = new SqlCommand("set dateformat dmy exec r_svodnall  '01.01.2008','01.07.2008',0 , 0,0,0", my.cn);
               
        SqlDataReader sd = my.sc.ExecuteReader();
        //Microsoft.SqlServer.Server.SqlContext.Pipe.Send(sd);

        //sd.Close();
        int dostup = 0;
        while (sd.Read())
        {
            dostup = 1;
            my.Id_us = (int)sd["id_us"];
            my.Id_UsName = sd["fio"].ToString();

        }
            if (dostup != 1) { MessageBox.Show("У Вас нет прав для работы с программой. Обратитесь к администратору!"); my.cn.Close(); return; }

        my.cn.Close();
        sd.Close();

        my.sc.CommandText = "select * from SluPolzPred where Id_us =" + my.Id_us;
        my.cn.Open();
        sd = my.sc.ExecuteReader();
        if (!sd.Read())
        { my.identpr = 0; }
       else
        { my.identpr = (int)(sd["identpr"]); }
        sd.Close();
        my.sc.CommandText = "select * from v_User where Id_us = " + my.Id_us;
        sd = my.sc.ExecuteReader();

        if (! sd.Read()) 
        {sd.Close();
        my.sc.CommandText = "SET DATEFORMAT dmy insert into SluPolzRazn (Id_us, IdEntpr, Period) Values (" + my.Id_us + "," + my.identpr + "" + ", '" + DateTime.Today.AddDays(-DateTime.Today.Day + 1) + "')";
        my.sc.ExecuteScalar();
        my.sc.CommandText = "select * from v_User where Id_us = " + my.Id_us;
            sd = my.sc.ExecuteReader();
            sd.Read();
        }
        my.Dostup = (bool)sd["Dostup"];
        my.identpr = (int)sd["identpr"];
        my.UpredName = sd["Name"].ToString();
        my.Uper = (DateTime)sd["Period"];
        my.UperName = my.Uper.ToString("MMMM").ToLower() + " " + my.Uper.ToString("yyyy").ToLower().ToLower() + " г.";
            my.Id_UsName = sd["fio"].ToString();

            sd.Close();
        my.sc.CommandText = "select id_group from dostup.dbo.usersingroups where id_group = 99 and id_user = " + my.Id_us;
        if (my.sc.ExecuteScalar() != null) my.Id_gr = (byte)(my.sc.ExecuteScalar());
        my.sc.CommandText = "exec Access.dbo.sUserIdentLog '" +my.Login+ "',33";
        my.sc.ExecuteScalar();
        my.sc.CommandText = "select KodEntpr from Sprav.dbo.tsEntpr where identpr =" + my.identpr;
        my.Upred = my.sc.ExecuteScalar().ToString();
        my.cn.Close();
        my.MyStr[0] = " identpr =" + my.identpr + " and month(Period) =" + my.Uper.Month + " and Year(Period) = " + my.Uper.Year;
        my.MyStr[1] = my.MyStr[0] + " and id_us=" + my.Id_us;
        my.MyStr[2] = " identpr =" + my.identpr + " ";

        my.MDIForm = new SMRC.Forms.frmLoad();
        my.MDIFormCont = new Form();
        Application.Run(my.MDIForm);

        }






    }
   }

        //public static class clsSearchInfo{
        //    public static String searchString  = "";
        //    public static String lookIn;
        //    public static SearchDirectionEnum searchDirection = SearchDirectionEnum.All;
        //    public static SearchContentEnum searchContent = SearchContentEnum.WholeField;
        //    public static bool matchCase = false;
        //}
   public class clsSearchInfo
   {
       public string searchString;
       public string lookIn;
       public SearchDirectionEnum searchDirection;
       public SearchContentEnum searchContent;
       public bool matchCase = false;
   }

   public enum SearchDirectionEnum
   {
       Down = 0,
       Up = 1,
       All = 2
   }
public enum SearchContentEnum
{
    AnyPartOfField = 0,
    WholeField = 1,
    StartOfField = 2
}
    public struct DaDs
    {
       public SqlDataAdapter[] Da;
       public SqlDataAdapter[] Da1;
       public DataSet ds;
        public void DaInd(int i ,String sel , String sconn  ,String  NMid ,DataSet  ds1 , bool WithUp ) 
        {   if (Da ==null) { Da1 = new   SqlDataAdapter[10]; Da = new   SqlDataAdapter[10]; ds = ds1;} //  SqlDataAdapter[10] Da; Da1[10] ;
            DataTable[] dt = new DataTable[10]; 
             SqlCommandBuilder[] cb = new  SqlCommandBuilder[10];
            
            Da1[i] = new  SqlDataAdapter(sel, sconn);
            dt[i] = new DataTable("tab" + i.ToString());
            if (WithUp) {
                Da[i] = new SqlDataAdapter(sel, sconn);
                cb[i] = new  SqlCommandBuilder(Da1[i]);
                cb[i].QuotePrefix = "[";
                cb[i].QuoteSuffix = "]";
                Da1[i].DeleteCommand = cb[i].GetDeleteCommand();
                Da1[i].UpdateCommand = cb[i].GetUpdateCommand();
                Da1[i].InsertCommand = cb[i].GetInsertCommand();
                cb = null;
                Da1[i].FillSchema(dt[i], SchemaType.Mapped);
                dt[i].Columns[0].AutoIncrement = true;
                dt[i].Columns[0].AutoIncrementSeed = -1;
                dt[i].Columns[0].AutoIncrementStep = -1;
                for (int i1 = 1;i1 <=dt[i].Columns.Count - 1;i1++)
                {
                    if (!dt[i].Columns[i1].AllowDBNull ) {
                        if (dt[i].Columns[i1].DataType.Name == "Int16" || dt[i].Columns[i1].DataType.Name == "Int32" || dt[i].Columns[i1].DataType.Name == "Double" || dt[i].Columns[i1].DataType.Name == "Byte" || dt[i].Columns[i1].DataType.Name == "Boolean")
                        { dt[i].Columns[i1].DefaultValue = 0; }
                        else if (dt[i].Columns[i1].DataType.Name == "String")
                        { dt[i].Columns[i1].DefaultValue = ""; }
                        else {MessageBox.Show(dt[i].Columns[i1].DataType.Name);}
                }
                }

            }
            Da1[i].Fill(dt[i]);
            ds.Tables.Add(dt[i]);
            if (WithUp) {
                if (NMid == "") {NMid = dt[i].Columns[0].ColumnName;}
                Da1[i].InsertCommand.CommandText += "; " + sel + " and " + NMid + "= SCOPE_IDENTITY()";
                Da[i] = new SqlDataAdapter();
                Da[i].DeleteCommand = Da1[i].DeleteCommand;
                Da[i].InsertCommand = Da1[i].InsertCommand;
                Da[i].UpdateCommand = Da1[i].UpdateCommand;
                Da1[i].InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            }
        }
        }
