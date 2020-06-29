using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMRC.Forms
{
    public partial class frmOSR : Form
    {
        public bool WithUp;
        SqlDataAdapter[] da = new SqlDataAdapter[3]; DataSet ds; DataView dv;
        public frmOSR()
        {
            InitializeComponent();
        }

        private void frmOSR_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            checkBox1_CheckedChanged(null, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            String sel;
            sel = my.FilterSel(66, null, my.sconn, "");
            my.tvinit(checkBox1.Checked, sel, "Иерархия", treeView1, false, -1, "");
            my.cn.Close();
            //foreach (TreeNode item in treeView1.Nodes[0].Nodes)
            //{
            //    foreach (TreeNode item1 in item.Nodes)
            //    {
            //        item1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //    }
            //}
            
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (WithUp)   if (ds.HasChanges()) { if (MessageBox.Show("Сохранить измененные данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes) { my.Up(da[0], ds.Tables[0]); } }
            ds = new DataSet();
            string sel = "";
            if (treeView1.SelectedNode.Text != "")
            {
                TreeNode tn = treeView1.SelectedNode;
                
                Dgv1.AllowUserToAddRows = false;
                switch (tn.Level.ToString())
                {
                    case "0":
                        sel = my.FilterSel(72, null, my.sconn, "");
                        break;
                    case "1":
                        sel = my.FilterSel(59, null, my.sconn, "") + " where idGrComplex = " + e.Node.Tag.ToString();
                        break;
                    case "2":
                        sel = my.FilterSel(60, null, my.sconn, "") + " where idComplex = " + (Convert.ToInt16(e.Node.Tag) - 100).ToString(); 
                        break;
                    case "3":
                        sel = my.FilterSel(61, null, my.sconn, "") + " and idcomplexchapter =  " + (Convert.ToInt16(e.Node.Tag) - 5000).ToString();
                        break;
                    case "4":
                        sel = my.FilterSel(71, null, my.sconn, "") + " where idosr =  " + (Convert.ToInt16(e.Node.Tag) - 1000).ToString(); ;
                        break;
                    default:
                        sel = "";
                        break;
                }

                //MessageBox.Show(tn.Level.ToString());
                if (sel != "")
                {
                    da[0] = new SqlDataAdapter();
                    DaDs dads1 = new DaDs();
                    //dads1.DaInd(0, "select * from Portal.dbo.tGrafik", my.sconn, "", ds, true);
                    dads1.DaInd(0, "set language 'русский' " + sel, my.sconn, "", ds, true);
                    da[0] = dads1.Da[0];
                    dv = new DataView();
                    dv.Table = ds.Tables[0];
                    //Dgv1.DataSource = null;
                    Dgv1.DataSource = dv;
                    my.naimDG(my.headStr, Dgv1, my.widthStr);
                    switch (tn.Level.ToString())
                    {
                        case "2":
                            Dgv1.VLadd("главы", "Главы", "SELECT        idChapter, NMChapter FROM            Sprav.dbo.tsChapter   order by NMChapter", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
                            break;
                        case "3":
                            Dgv1.VLadd("договор", "Договор", "SELECT     TOP(100) PERCENT idDog, RegNomer FROM         Sprav.dbo.Dogovor  where  iddog = 0 or iddog in (SELECT DISTINCT dbo.Forma2.IdDog FROM         dbo.Forma2 INNER JOIN        Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm INNER JOIN     Sprav.dbo.tsOSR ON Sprav.dbo.tSmeti.IdOsr = Sprav.dbo.tsOSR.idOSR INNER JOIN        Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter) ORDER BY RegNomer", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 10);
                            break;
                        case "4":
                            Dgv1.VLadd("объект", "Объект", "SELECT        IdObj, Name FROM            Sprav.dbo.SprObject   order by Name", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
                            break;
                    }
                    my.naimDG(my.headStr, Dgv1, my.widthStr);
                }}
                else
                { Dgv1.DataSource = null; }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (WithUp)
            {
               
                TreeViewEventArgs tn = new TreeViewEventArgs(treeView1.SelectedNode);
                Dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit); BindingContext[ds, "tab0"].EndCurrentEdit();
               // da[0].AcceptChangesDuringFill = false;
                my.Up(da[0], ds.Tables[0]); treeView1_AfterSelect(Dgv1, tn);
            }
            else { MessageBox.Show("У Вас нет прав для выполнения этой операции!"); }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //TreeNode tn = treeView1.SelectedNode;
            //switch (tn.Level.ToString())
            //{
            //    case "2":
            //        Dgv1.VLadd("главы", "Главы", "SELECT        idChapter, NMChapter FROM            Sprav.dbo.tsChapter   order by NMChapter", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
            //        break;
            //    case "3":
            //        Dgv1.VLadd("договор", "Договор", "SELECT     TOP(100) PERCENT idDog, RegNomer FROM         Sprav.dbo.Dogovor  where  iddog = 0 or iddog in (SELECT DISTINCT dbo.Forma2.IdDog FROM         dbo.Forma2 INNER JOIN        Sprav.dbo.tSmeti ON dbo.Forma2.IdSm = Sprav.dbo.tSmeti.IdSm INNER JOIN     Sprav.dbo.tsOSR ON Sprav.dbo.tSmeti.IdOsr = Sprav.dbo.tsOSR.idOSR INNER JOIN        Sprav.dbo.tComplexChapter ON Sprav.dbo.tsOSR.idComplexChapter = Sprav.dbo.tComplexChapter.idComplexChapter) ORDER BY RegNomer", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 10);
            //        break;
            //    case "4":
            //        Dgv1.VLadd("объект", "Объект", "SELECT        IdObj, Name FROM            Sprav.dbo.SprObject   order by Name", my.sconn, SMRC.DGVt.TypeVL.ComboBox, 2);
            //        break;
            //}
         DataRow dr =   ds.Tables[0].Rows.Add();
            dr[1] = Convert.ToInt32( treeView1.SelectedNode.Tag.ToString()) - (treeView1.SelectedNode.Level== 2?100: (treeView1.SelectedNode.Level == 3 ? 5000 : (treeView1.SelectedNode.Level == 4 ? 1000 : 0))) ;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (WithUp)
            {
                Dgv1.Rows.RemoveAt(Dgv1.CurrentRow.Index);
                Dgv1.Refresh();
            }
            else { MessageBox.Show("У Вас нет прав для выполнения этой операции!"); }
            // ds.Tables[0].Rows.RemoveAt(Dgv1.CurrentRow.Index);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(null, null);
        }



        private void Dgv1_DoubleClick(object sender, EventArgs e)
        {
            if (Dgv1.Columns[Dgv1.CurrentCell.ColumnIndex].Name == "главы")
            {
            my.Szap = "";
                    my.Nbut = 54;
                if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
                {
                    my.showSprDGV(my.Nbut, true, true);
                }
            }
            if (treeView1.SelectedNode.Level.ToString() == "3")
            { my.Szap = " and idosr = " + Dgv1.CurrentRow.Cells[ "idOsr"].Value;

                my.Nbut = 528;
                if (!my.isFormInMdi("frmSprDGV", my.Nbut, this))
                {
                    my.showSprDGV(my.Nbut, false, true);
                }
            }
        }
    }
}
