using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmSvjaz : Form
    {
        public frmSvjaz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idf2NZ = my.ExeScalar("select idf2 from forma2 where kodunic = '" + KodUnicNZ.Text + "'");
            string idf2zak = my.ExeScalar("select idf2 from forma2 where kodunic = '" + KodUnicZak.Text + "'");
            if(! my.IsNumeric(idf2NZ))
            {
                MessageBox.Show("Не правильно введен номер акта НЗ!");
                return;
            }
            if (!my.IsNumeric(idf2zak))
            {
                MessageBox.Show("Не правильно введен номер акта к заказчику!");
                return;
            }
            my.ExeScalar("insert into SootvF2Parent (idf2,idf2child) values (" + idf2NZ + "," + idf2zak + ")");
            Close();
        }
    }
}
