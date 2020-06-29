using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMRC.Forms
{
    public partial class frmColumns : Form
    {
        public int mode;
        public frmColumns()
        {
            InitializeComponent();
        }

        private void frmColumns_Load(object sender, EventArgs e)
        {
            spisok("select * from grafik.dbo.ttaskwrk Where 1=2");
        }
        private void spisok(string szap)
        { 
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(szap, my.sconn);
            da.Fill(ds);
            //string sel = "";
            //my.sc.CommandText = "select Stroka  FROM        dbo.str2rst(select Nastr from grafik.dbo.tUsNastr where login = '" + my.Login + "')";
            DataSet dscol = new DataSet();
            da = new SqlDataAdapter("select ltrim(Stroka) as Stroka  FROM        dbo.IzStr((select Nastr from grafik.dbo.tUsNastr where login = '" + my.Login + "' and mode = "+mode+"))", my.sconn);
            da.Fill(dscol);
            DataView dv = new DataView();
            dv.Table = dscol.Tables[0];
            my.cn.Open(); string NM = "";
            try
            {
            for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            {
                my.sc.CommandText = "select grafik.dbo.fNMCol('" + ds.Tables[0].Columns[i].ColumnName + "',"+mode.ToString()+",1)";
                NM = my.sc.ExecuteScalar().ToString();
                TreeNode node = TreeView1.Nodes.Add(ds.Tables[0].Columns[i].ColumnName, NM);
                dv.RowFilter = "stroka = '" + ds.Tables[0].Columns[i].ColumnName.Trim() + "'";
                if (dv.Count > 0)
                {
                    node.Checked = true;
                }
            }
            }
            catch (Exception)
            {

            }
            my.cn.Close();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            string sel = "";
            {
                if (TreeView1.Nodes.Count != 0)
                {
                    for (int i = 0; i <= TreeView1.Nodes.Count - 1; i++)
                    {
                        TreeNode node = TreeView1.Nodes[i];
                        if (node.Checked)
                        {
                            sel =  sel +"," +  node.Name ;
                        }
                    }
                    if (sel != "") { sel = sel.Substring(1); } else { sel = "task_code"; }
                }

                if (sel != "")
                {
                    my.cn.Open();
                    my.sc.CommandText = "exec grafik.dbo.sUsNastr '" + my.Login + "','" + sel + "'," + mode.ToString();
                    my.sc.ExecuteScalar();
                    my.cn.Close();
                    sel = "";

                }
                Close();
            }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbSelAll_Click(object sender, EventArgs e)
        {
            bool fl;
            if (tbSelAll.Text == "Выделить все") { fl = true; } else { fl = false; }
            if (TreeView1.Nodes.Count != 0)
            {

                for (int i = 0; i <= TreeView1.Nodes.Count - 1; i++)
                {
                    TreeNode node = TreeView1.Nodes[i];
                    node.Checked = fl;
                }
            }
            if (fl)
            {
                tbSelAll.Text = "Снять выделение";
            }
            else
            { tbSelAll.Text = "Выделить все"; }
        }


    }
}
