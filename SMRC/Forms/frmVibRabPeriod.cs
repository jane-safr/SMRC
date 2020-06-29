using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
   public partial class frmVibRabPeriod : Form
    {
        public DataGridViewSelectedRowCollection DGVKol;
        public frmVibRabPeriod()
        {
            InitializeComponent();
        }

        private void TEx_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVibRabPeriod_Load(object sender, EventArgs e)
        {
            this.Top = (my.MDIForm.Height - this.Height) / 3;
            this.Left = (my.MDIForm.Width - this.Width) / 3;
            my.ObnPer(d1);
            d1.SelectedValue = my.Uper;
        }

        private void frmVibRabPeriod_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void butLeft_Click(object sender, EventArgs e)
        {
            if (d1.SelectedIndex > 0) d1.SelectedIndex = d1.SelectedIndex - 1;
        }

        private void butRight_Click(object sender, EventArgs e)
        {
            if (d1.SelectedIndex < d1.Items.Count-1) d1.SelectedIndex = d1.SelectedIndex + 1;
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            if (my.Nbut == 6)
            {
                
                foreach (DataGridViewRow selRow in DGVKol)
                {
                    my.ExeScalar("update forma2 set  update_date =  '" + DateTime.Now + "', update_user =  '" + my.Login + "'  WHERE IdF2=" + selRow.Cells["IdF2"].Value);
                    my.ExeScalar("set dateformat 'dmy' exec F2_CopyPerenos " + selRow.Cells["IdF2"].Value + ", " + my.Id_us + "," + my.identpr + ",'" + d1.SelectedValue + "'");
                                 }
                //MessageBox.Show("Готово!");
            }
            if (my.Nbut ==2)
            {
                my.ExeScalar("update forma3 set  update_date =  '" + DateTime.Now + "', update_user =  '" + my.Login + "'  WHERE IdF3=" + my.Szap);
                my.ExeScalar("set dateformat 'dmy' exec F3_MoveF3 " + my.Szap + ", " + "'" + d1.SelectedValue + "'" );
                using (frmF3 fr =(frmF3)my.Pform)
                {
                    fr.WithSave = false;
                    fr.Close();
                }
            }
            if (my.Nbut == 13)
            {
                foreach (DataGridViewRow selRow in DGVKol)
                {
                    if (my.InF3((int)selRow.Cells["IdF2"].Value) == true)
                    {
                        MessageBox.Show(selRow.Cells["KodUnic"].Value.ToString()  + " нельзя, поскольку он взят в справку формы №3");
                    }
                    else
                    {
                        my.ExeScalar("update forma2 set  update_date =  '" + DateTime.Now + "', update_user =  '" + my.Login + "'  WHERE IdF2=" + selRow.Cells["IdF2"].Value);
                        my.ExeScalar("set dateformat 'dmy' exec F2_MoveAkt '" + selRow.Cells["IdF2"].Value + "', " + "'" + d1.SelectedValue +"'");
                    }
                }
                ((frmActs)my.Pform).spisok();

            }
            Close();
        }
    }
}
