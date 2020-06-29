using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmVibList : Form
    {
        FontStyle style = new FontStyle();
        public frmVibList()
        {
            InitializeComponent();
        }

        private void frmVibList_Load(object sender, EventArgs e)
        {
            tYear.Text = DateTime.Today.Year.ToString();
            lbxShNMEntpr.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
            lbxType.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);

            style |= FontStyle.Bold;
        }
        private void ListBox1_DrawItem(object sender,
System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Gray);//Choose the color


            e.DrawBackground();
            //  if (e.Index != 0)
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), new Font(FontFamily.GenericSansSerif, 10.0F, style), Brushes.DarkSlateGray, e.Bounds, StringFormat.GenericDefault);
            //DarkSlateGray DarkSlateGray
        }
        private  string SetFilter(ListBox lb)
        {
            string tmpStr = "";
            foreach (var item in lb.SelectedItems)
            {
                if (lb.GetItemText(item).Length >= 19)
                    tmpStr += lb.GetItemText(item).Substring(0, 19) + "|";
                else
                    tmpStr += lb.GetItemText(item) + "|";
            }
            if (tmpStr != "") tmpStr = tmpStr.Substring(0, tmpStr.Length - 1);
            return tmpStr;
        }
        public  void GrafikUni(string stringStringSQL)
        {
            Process myProcess = new Process();
            string flsh = SetFilter(lbxShNMEntpr);
            string fltype = SetFilter(lbxType);
            //string flperiod = SetFilter(lbxPeriod);
            my.cnjane.Open();

            SqlCommand sc = new SqlCommand(stringStringSQL, my.cnjane);
            SqlDataReader dr = sc.ExecuteReader();
            try
            {
                dr.Read();

                string path = dr["plot"].ToString();
                if (lbxShNMEntpr.Items.Count == 0)
                {
                    string[] itemsEnt = dr["shNMEntpr"].ToString().Split('|');
                    lbxShNMEntpr.DataSource = itemsEnt;
                    lbxShNMEntpr.SelectedItem = null;
                }
                if (lbxType.Items.Count == 0)
                {
                    string[] itemsType = dr["Type"].ToString().Split('|');
                    lbxType.DataSource = itemsType;
                    lbxType.SelectedItem = null;
                }
                //if (lbxPeriod.Items.Count == 0)
                //{
                //    string[] itemsType = dr["PeriodName"].ToString().Split('|');
                //    lbxPeriod.DataSource = itemsType;
                //    lbxPeriod.SelectedItem = null;
                //}

                dr.Close();
                myProcess.StartInfo.FileName = path;
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                //panel1.Visible = true;
            }
            catch (Exception ex)
            {
                if (my.cnjane.State == ConnectionState.Open) { my.cnjane.Close(); }
                MessageBox.Show(ex.Message);

            }
            if (my.cnjane.State == ConnectionState.Open) { my.cnjane.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string flsh = SetFilter(lbxShNMEntpr);
                string fltype = SetFilter(lbxType);


                string s = "exec sRInFile '" + flsh + "','" + fltype + "','','test','" + tYear.Text + "','nz'";
                GrafikUni(s);
                //  MessageBox.Show("Готово");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ent = SelEntpr(lbxShNMEntpr);
            my.Szap = " and YearF2 = " + tYear.Text + (ent != ""? " and shNmEntpr in (" + SelEntpr (lbxShNMEntpr)+ ")":"");
            my.Nbut = 718;
            //my.Nbut = 8;
            bool withup = false;
            my.Pform = this;
            //if (my.Nbut == 704) { if (my.UserInGroup(my.Id_us,234)) ; }
            if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
            {
                my.showSprDGV(my.Nbut, withup, true);
            }
        }

        private string SelEntpr(ListBox lb)
        {
            string tmpStr = "";
            foreach (var item in lb.SelectedItems)
            {

                tmpStr += "'" +lb.GetItemText(item) + "',";
            }
            if (tmpStr != "") tmpStr = tmpStr.Substring(0, tmpStr.Length - 1);
            return tmpStr;
        }
        private void lbxSelected(ListBox myListBox,bool sel)
        {
            for (int i = 0; i < myListBox.Items.Count; i++)
            {
                myListBox.SetSelected(i, sel);
            }
        }
        private void chType_CheckedChanged(object sender, EventArgs e)
        {
            lbxSelected(lbxType,chType.Checked);

        }

        private void chShNMEntpr_CheckedChanged(object sender, EventArgs e)
        {
            lbxSelected(lbxShNMEntpr, chShNMEntpr.Checked);
        }
    }
}
