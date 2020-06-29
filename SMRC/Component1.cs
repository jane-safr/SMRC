using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace SMRC
{
    public partial class DGVt : DataGridView
    {
        public DGVt()
        {
            InitializeComponent();
        }
        public enum TypeVL
        {
            none = 2,
            ComboBox = 0,
            ComboBoxDropDown = 1
        }


        public DGVt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = System.Drawing.SystemColors.Info;
            this.RowHeadersWidth = 25;
        }

        public void VLadd(String colNM, String headerNM, String sSelect, String sConnect, TypeVL KindVL, int position)
        {

            String sErr = "simply ERROR :-)";
            String ss = "column & dgv unknown!";
            try
            {
                ss = " column: " + colNM + ", dgv: " + this.Name + ", parent: " + this.Parent.Name;
                DataGridViewComboBoxColumn Col = new DataGridViewComboBoxColumn();
                sErr = "Error set properties";
                Col.HeaderText = headerNM;
                Col.AutoComplete = true;
                Col.DisplayStyle = (DataGridViewComboBoxDisplayStyle)KindVL;
                Col.DataPropertyName = colNM;

                Col.DropDownWidth = 160;
                Col.MaxDropDownItems = 15;
                Col.FlatStyle = FlatStyle.Popup;
                sErr = "Error fill";

                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(sSelect, sConnect);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                Col.DataSource = dt;
                Col.ValueMember = dt.Columns[0].ColumnName;
                Col.DisplayMember = dt.Columns[1].ColumnName;
                sErr = "Error calc index";
                int ind = this.Columns[colNM].Index;
                sErr = "Error remove";
                this.Columns.Remove(colNM);
                sErr = "Error insert";
                if (position > 0)
                {
                    ind = position - 1;
                    if (ind > this.Columns.Count ) { MessageBox.Show("Programmer! Attention! Position of column automodified for correct columns count :-)"); ind = this.Columns.Count; }
                }
                Col.Name = colNM;
                this.Columns.Insert(ind, Col);

            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(sErr + ss + e.Message);
            }


        }

        private void DGVt_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {

                DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;

                cbo.DropDownStyle = ComboBoxStyle.DropDown;


            }
        }
        //void cbo_Validating(object sender, CancelEventArgs e)
        //{

            //    DataGridViewComboBoxEditingControl cbo = sender as DataGridViewComboBoxEditingControl;

            //    DataGridView grid = cbo.EditingControlDataGridView;

            //    object value = cbo.Text;


            //    // Add value to list if not there


            //    if (cbo.Items.IndexOf(value) == -1)
            //    {

            //        DataGridViewComboBoxColumn cboCol = grid.Columns[grid.CurrentCell.ColumnIndex] as DataGridViewComboBoxColumn;

            //        // Must add to both the current combobox as well as the template, to avoid duplicate entries...


            //        cbo.Items.Add(value);

            //        cboCol.Items.Add(value);

            //        grid.CurrentCell.Value = value;

            //    }

        //}
    }
}
