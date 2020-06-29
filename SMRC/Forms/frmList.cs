using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }

        private void TVib_Click(object sender, EventArgs e)
        {
            if (TreeView1.Nodes.Count != 0)
            {
                string s = (TEx.Tag.ToString() == "String" ? "'" : "").ToString();
                string sel1 = "";
                string t = "";
                for (int i = 0; i <= TreeView1.Nodes.Count - 1; i++)
                {
                    TreeNode node = TreeView1.Nodes[i];
                    if (node.Checked)
                    {

                        string rsname = node.Text.Trim();
                        sel1 = sel1 + TreeView1.Tag.ToString() + " = " + s + rsname + s + " or ";
                        t = t + s + rsname + s + ",";
                    }
                }
                //'sel = Microsoft.VisualBasic.Left(sel, Len(sel) - 1) + "]"
                sel1 = sel1.Substring(0, sel1.Length - 4);
                t = t.Substring(0, t.Length - 1) + ")";
                if ((int)my.headStr.IndexOf("где", 0) == -1) { my.headStr = my.headStr + ", где "; } else { my.headStr = my.headStr + ", и "; }
                //'headStr = Microsoft.VisualBasic.Left(t, Len(t) - 1)
                my.headStr = my.headStr + my.cap + " в (" + t;
                //'   Pform.Text2.Tag = t
                //'Pform.sel = Pform.sel + sel
                my.Ustr = sel1;
                //'PForm.refCR()
            }
           //if (my.Pform.Name == "frmReps") {((frmReps)my.Pform ).frmReps_Activated(null, null);}
            Close();



        }
    }
}