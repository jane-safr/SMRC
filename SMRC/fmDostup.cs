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

namespace SMRC
{
    public partial class frmDostup : Form
    {
        DataSet ds; SqlDataAdapter da;
        public frmDostup()
        {
            InitializeComponent();
        }

        private void fmDostup_Load(object sender, EventArgs e)
        {
            my.FillDC(id_group, 67, " and (id = 22 OR   id = 49 OR     id = 52)");
            my.FillDC(id_user, 68, " and id_us in (SELECT     id_user FROM         dostup.dbo.UsersInGroups WHERE     (id_group = 22) AND (id_user <> 0))");
            Dgv1.AllowUserToAddRows = false;
        }

        private void spisok()
        {
            if (id_group.SelectedValue.ToString() != "")

            {

                string s = "SELECT   dostup.dbo.UsersInGroups.id,  dostup.dbo.Users.FIO as ФИО FROM         dostup.dbo.UsersInGroups INNER JOIN         dostup.dbo.Users ON dostup.dbo.UsersInGroups.id_user = dostup.dbo.Users.Id_us WHERE   (id_user <> 0) AND dostup.dbo.UsersInGroups.id_group = " + id_group.SelectedValue + " order by dostup.dbo.Users.FIO";
                ds = new DataSet();
                da = new SqlDataAdapter(s, my.sconn);
                ds.Clear();
                da.Fill(ds);
                Dgv1.DataSource = ds.Tables[0];


                {
                    if (Dgv1.Columns.Count == ds.Tables[0].Columns.Count)
                    {
                        Dgv1.Columns[0].Visible = false;
                        Dgv1.Columns[1].Width = 400;
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Text = "Запретить";
                        col.Name = "Доступ";
                        

                        //if (Dgv1.Columns.Count == dv.Table.Columns.Count)
                        Dgv1.Columns.Add(col);
                        Dgv1.Columns["Доступ"].DisplayIndex = 2;

                        Dgv1.Columns["Доступ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(id_group.SelectedValue)!= 0 && Convert.ToInt32(id_user.SelectedValue) != 0)
            {
                my.ExeScalar("insert into dostup.dbo.UsersInGroups (id_group,id_user) values (" + id_group.SelectedValue + "," + id_user.SelectedValue + ")");
                spisok();
                //if (Dgv1.Columns[e.ColumnIndex].Name == "Акты ")
            }
        }

        private void id_group_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (my.IsNumeric(id_group.SelectedValue)) spisok();
        }

        private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv1.Columns[e.ColumnIndex].Name == "Доступ")
            {
                if (MessageBox.Show("Вы действительно хотите запретить доступ пользователя " + Dgv1.CurrentRow.Cells["ФИО"].Value + " к " + id_group.Text + "?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    my.ExeScalar("delete from dostup.dbo.UsersInGroups where id = " + Dgv1.CurrentRow.Cells["id"].Value );
                    spisok();
                }
            }

        }
    }
}
