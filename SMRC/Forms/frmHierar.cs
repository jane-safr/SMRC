using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SMRC.Forms
{
    public partial class frmHierar : Form
    {
        public int idComplex;
        public string NMComplex;
        public frmHierar()
        {
            InitializeComponent();
        }

        private void frmHierar_Load(object sender, EventArgs e)
        {
            my.cn.Open();
            label1.Text = NMComplex;
            my.sc.CommandText = "select left(shifr,10) from sprav.dbo.tscomplex where idComplex = " + idComplex ;
            userControl11.Shifr = my.sc.ExecuteScalar().ToString();
            my.cn.Close();
            
            userControl11.sconn = my.sconn;
            WindowState = FormWindowState.Maximized;
        }
    }
}
