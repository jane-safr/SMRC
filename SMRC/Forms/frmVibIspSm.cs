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
    public partial class frmVibIspSm : Form
    {
        public frmVibIspSm()
        {
            InitializeComponent();
        }

        private void frmVibIspSm_Load(object sender, EventArgs e)
        {
            this.Top = (my.MDIForm.Height - this.Height) / 3;
            this.Left = (my.MDIForm.Width - this.Width) / 3;
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
            my.ObnPer(d2);
            d2.SelectedValue = my.Uper;
            my.FillDC(IdDog, 16, " and IdStatDog = 2  or iddog = 0");
            my.FillDC(idComplex, 1, " ");
            my.FillDC(IdEnt, 7, " and Bits & 2 > 0 or identpr = 0 ");
            IdEnt.Enabled = false;
            IdDog.Enabled = false;
            IdDog.SelectedValue = 0;
            IdEnt.SelectedValue = 0;
            idComplex.SelectedValue = -1;
            my.FillDC(idPk, 37, " ");
            idPk.SelectedValue = 0;
        }

        private void rb20_CheckedChanged(object sender, EventArgs e)
        {
            TreeView1.Enabled = false;
        }

        private void rb21_CheckedChanged(object sender, EventArgs e)
        {
            TreeView1.Enabled = true;
            TreeView1.Nodes.Clear();
            string s = "SELECT     TOP (100) PERCENT IdObj, isnull(Name,'') FROM         Sprav.dbo.SprObject ORDER BY Name";
            my.sc.CommandText = s;
            my.cn.Open();
            SqlDataReader sd = my.sc.ExecuteReader();

            while (sd.Read())
            {
                TreeView1.Nodes.Add("r" + sd[0].ToString(), sd[1].ToString());
            }
            sd.Close();
            my.cn.Close();
        }

        private void rb22_CheckedChanged(object sender, EventArgs e)
        {
            TreeView1.Enabled = true;
            TreeView1.Nodes.Clear();
            string s = "SELECT     TOP (100) PERCENT IdObj, isnull(Name,'') FROM         Sprav.dbo.SprObject where vib  = 1 ORDER BY Name";
            my.sc.CommandText = s;
            my.cn.Open();
            SqlDataReader sd = my.sc.ExecuteReader();

            while (sd.Read())
            {
                TreeView1.Nodes.Add("r" + sd[0].ToString(), sd[1].ToString());
            }
            sd.Close();
            my.cn.Close();
        }

        private void ch1_CheckedChanged(object sender, EventArgs e)
        {
            this.IdEnt.Enabled = ch1.Checked;
            if (ch1.Checked)
            {
                this.IdEnt.SelectedValue = my.identpr;
            }
            else
            {
                this.IdEnt.SelectedValue = 0;
            }
        }

        private void ch20_CheckedChanged(object sender, EventArgs e)
        {
            ch1.Enabled = ch20.Checked;
            if (!ch20.Checked)
            {
                ch1.Checked = false;
            }
            ch1_CheckedChanged(null,null);
        }

        private void ch3_CheckedChanged(object sender, EventArgs e)
        {
            IdDog.Enabled = ch3.Checked;
            if (!ch3.Checked)
            {
                IdDog.SelectedValue = 0;
            }
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            string s = null;
if (rb20.Checked)
{
	s = "0,";
}
else
{
s = "";
	for (var i = 0; i <= this.TreeView1.Nodes.Count-1; i++)
	{
		   if (this.TreeView1.Nodes[i].Checked)
		   {
			   s = s + Microsoft.VisualBasic.Conversion.Val(TreeView1.Nodes[i].Name.Substring((TreeView1.Nodes[i].Name.IndexOf("r", 0) + 1))) + ",";
		   }
	}
}
if (s == "")
{
    MessageBox.Show("Выберите объект!");
	return;
}
 s = s.Substring(0, s.Length - 1);
	my.Szap = Microsoft.VisualBasic.Conversion.Val(idComplex.SelectedValue).ToString();
    my.Szap = my.Szap + " , " + ((rb10.Checked) ? 0 : 1).ToString() + " , " + (ch20.Checked ? 1 : 0).ToString() + " , " + (ch21.Checked ? 1 : 0).ToString() + " , " + (ch22.Checked ? 1 : 0).ToString() + ", '" + d1.SelectedValue + "','" + d2.SelectedValue + "', " + (ch23.Checked ? 1 : 0).ToString() + ", " + 0 + ", '" + s + "', " + (ch24.Checked ? 1 : 0).ToString() + "," + IdEnt.SelectedValue + "," + IdDog.SelectedValue + "," + idPk.SelectedValue;
    if (!my.isFormInMdi("frmPerechSm", 0, this))
    {
        frmPerechSm fr = new frmPerechSm();
        fr.Tag = 0;
        my.Nbut = 0;
        fr.MdiParent = my.MDIForm;
        //fr.Hide();
        fr.Show();
    }
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
