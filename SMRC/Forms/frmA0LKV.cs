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
    public partial class frmA0LKV : Form
    {
        public frmA0LKV()
        {
            InitializeComponent();
        }
        private void frmProj_Load(object sender, EventArgs e)
        {
            my.FillDC(IdEnt, 45, "");
            my.ObnPer(Period);
            Period.SelectedValue = DateTime.Today.AddDays(-DateTime.Today.Day + 1);

            //checkBox1_CheckedChanged(null, null);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listView1.AllowDrop = true;
            listView2.AllowDrop = true;

        }
        private void ObnProekt()
        {
            string s = my.FilterSel(206, this, my.sconn, " and IdDep = " + IdDep.SelectedValue + " and month(datevz) = month('" + ((DateTime)Period.SelectedValue) + "') and year(datevz) = year('" + ((DateTime)Period.SelectedValue) + "') order by NDoc");
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            string h = my.headStr;
            string w = my.widthStr;
            Dgv1.DataSource = ds.Tables[0];
            Dgv1.AllowUserToAddRows = false;
            my.naimDG(h, Dgv1, w);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ObnProekt();
        }



        private void IdEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (my.IsNumeric(IdEnt.SelectedValue))
            {
                my.FillDC(IdDep, 46, " and identpr = " + IdEnt.SelectedValue);
            }
        }


        private void Dgv1_SelectionChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (Dgv1.CurrentRow == null) return;
            string sel = my.FilterSel(205, null, my.sconn, " and  osn like '%" + Dgv1.CurrentRow.Cells[1].Value.ToString() + "%'");
            SqlDataAdapter da = new SqlDataAdapter(sel, my.sconn);
            da.Fill(ds);

            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            //dv.Sort = "wbs_name";
            sel = "";
            listView1.Groups.Clear();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            ListViewGroup lvg = null;
            listView1.Columns.Add("Шифр");
            listView1.Columns.Add("Наименование", 300);
            listView1.Columns.Add("Ед.изм.");
            listView1.Columns.Add("Объем");
            listView1.Columns.Add("ПЗ");
            for (int i = 0; i < dv.Count; i++)
            {
                if (sel != dv[i][0].ToString())
                {
                    lvg = new ListViewGroup(dv[i][0].ToString());
                    listView1.Groups.Add(lvg);
                }

                string[] str = new string[5];

                str[0] = dv[i][1].ToString();
                str[1] = dv[i][2].ToString();
                str[2] = dv[i][3].ToString();
                str[3] = dv[i][4].ToString();
                str[4] = dv[i][5].ToString();

                ListViewItem lvi = new ListViewItem(str);
                lvi.Group = lvg;
                listView1.Items.Add(lvi);
                sel = dv[i][0].ToString();
            }

            ///ЛКВ
            ds.Clear();
            sel = my.FilterSel(203, null, my.sconn, "");
            da = new SqlDataAdapter(sel + " " + Dgv1.CurrentRow.Cells[0].Value.ToString() + ",4", "Persist Security Info=False;Integrated Security=SSPI;Initial Catalog=smr;User ID=prog;Password=prog;Data Source=SQL-A0;Connect Timeout=10000;");
            da.Fill(ds);

            dv = new DataView();
            dv.Table = ds.Tables[0];
            //dv.Sort = "wbs_name";
            sel = "";
            listView2.Groups.Clear();
            listView2.Items.Clear();
            listView2.Columns.Clear();
            lvg = null;
            listView2.Columns.Add("OrderNom", "№ п/п");
            listView2.Columns.Add("Mat", "Материал", 300);
            listView2.Columns.Add("NMEdIzm", "Ед.измерения");
            listView2.Columns.Add("Total", "Всего");
            for (int i = 0; i < dv.Count; i++)
            {
                if (sel != dv[i]["Razd"].ToString())
                {
                    lvg = new ListViewGroup(dv[i]["Razd"].ToString());
                    listView2.Groups.Add(lvg);
                }

                string[] str = new string[4];

                str[0] = dv[i]["OrderNom"].ToString();
                str[1] = dv[i]["Mat"].ToString();
                str[2] = dv[i]["NMEdIzm"].ToString();
                str[3] = dv[i]["Total"].ToString();

                ListViewItem lvi = new ListViewItem(str);
                lvi.Group = lvg;
                listView2.Items.Add(lvi);
                sel = dv[i]["Razd"].ToString();
            }
            ///Материалы из учета

            string s = my.FilterSel(207, this, my.sconn, " and  osn like '%" + Dgv1.CurrentRow.Cells[1].Value.ToString() + "%'");
            ds = new DataSet();
            da = new SqlDataAdapter("set language 'русский'; " + s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv2.DataSource = ds.Tables[0];
            Dgv2.AllowUserToAddRows = false;
            my.naimDG(my.headStr, Dgv2, my.widthStr);

            ///сметы из учета

            s = my.FilterSel(208, this, my.sconn, " and  osn like '%" + Dgv1.CurrentRow.Cells[1].Value.ToString() + "%'");
            ds = new DataSet();
            da = new SqlDataAdapter("set language 'русский'; " + s, my.sconn);
            ds.Clear();
            da.Fill(ds);
            Dgv3.DataSource = ds.Tables[0];
            Dgv3.AllowUserToAddRows = false;
            my.naimDG(my.headStr, Dgv3, my.widthStr);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearLVHighlight((ListView)sender);
            if (((ListView)sender).SelectedItems.Count != 0)

                for (int i = 0; i < ((ListView)sender).SelectedItems.Count; i++)
                {
                    ((ListView)sender).SelectedItems[i].BackColor = Color.RoyalBlue;
                    ((ListView)sender).SelectedItems[i].ForeColor = Color.White;
                }
        }

        #region ForDragDrop



        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ((ListView)sender).DoDragDrop(e.Item, DragDropEffects.Move);
            lv = sender;
        }

        private void listView2_DragOver(object sender, DragEventArgs e)
        {

            Point position = new Point();
            position = new Point(0, 0);

            e.Effect = DragDropEffects.Move;

            position.X = e.X;
            position.Y = e.Y;
            position = ((ListView)sender).PointToClient(position);
            mobjHoverItem = ((ListView)sender).GetItemAt(position.X, position.Y);
            if (sender == lv) { return; }
            if ((mobjHoverItem == null))
            {
                return;
            }

            if (mintSavedHoverIndex == mobjHoverItem.Index)
            {
                return;
            }
            
            ((ListView)sender).BeginUpdate();
            ClearLVHighlight((ListView)sender);
            mobjHoverItem.BackColor = Color.RoyalBlue;
            mobjHoverItem.ForeColor = Color.White;
            ((ListView)sender).EndUpdate();

            mintSavedHoverIndex = mobjHoverItem.Index;
            

        }
        private ListViewItem mobjHoverItem;
        private int mintSavedHoverIndex; object lv;


        private void ClearLVHighlight(ListView objLV)
        {

            for (int intX = 0; intX < objLV.Items.Count; intX++)
            {
                objLV.Items[intX].ForeColor = Color.Black;
                objLV.Items[intX].BackColor = Color.White;
                //objLV.Items[intX].Selected = false;
            }

        }

        #endregion ForDragDrop


        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            //ClearLVHighlight(listView1);
            //ClearLVHighlight(listView2);
        }

        private void listView2_DragLeave(object sender, EventArgs e)
        {
            //ClearLVHighlight(listView1);
            //ClearLVHighlight(listView2);
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("htrf");
            ListView objLV = (ListView)sender;
            //for (int intX = 0; intX < objLV.Items.Count; intX++)
            //{
            //    objLV.Items[intX].ForeColor = Color.Black;
            //    objLV.Items[intX].BackColor = Color.White;
            //    objLV.Items[intX].Selected = false;
            //}
        }

    }
}
