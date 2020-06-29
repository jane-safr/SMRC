using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class Conn : Form
    {
        public Conn()
        {
            InitializeComponent();
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            my.Szap = ComboBox1.SelectedValue.ToString();
            Close();
        }

        private object CType(object p, string String)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void Conn_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedValue = "SQL-A0";
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}