namespace SMRC.Forms
{
    partial class frmPlanSmA0
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem tsbFind;
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tslCount = new System.Windows.Forms.ToolStripLabel();
            this.tstText = new System.Windows.Forms.ToolStripTextBox();
            this.tsFilter = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv1 = new SMRC.DGVt(this.components);
            tsbFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton1,
            this.ToolStripButton2,
            this.ToolStripButton3,
            this.ToolStripSeparator1,
            this.ToolStripButton10,
            this.toolStripButton4,
            this.tslCount,
            this.tstText,
            tsbFind,
            this.tsFilter,
            this.ToolStripButton9});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(979, 25);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton1.Image = global::SMRC.Properties.Resources.NewAkt;
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton1.Text = "Новая";
            this.ToolStripButton1.ToolTipText = "Новая смета";
            this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // ToolStripButton2
            // 
            this.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton2.Image = global::SMRC.Properties.Resources.Open;
            this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton2.Name = "ToolStripButton2";
            this.ToolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton2.Text = "Открыть";
            this.ToolStripButton2.ToolTipText = "Открыть смету";
            this.ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // ToolStripButton3
            // 
            this.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton3.Image = global::SMRC.Properties.Resources.Delete;
            this.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton3.Name = "ToolStripButton3";
            this.ToolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton3.Text = "Удалить";
            this.ToolStripButton3.ToolTipText = "Удалить смету(ы)";
            this.ToolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripButton10
            // 
            this.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton10.Image = global::SMRC.Properties.Resources.exlel;
            this.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton10.Name = "ToolStripButton10";
            this.ToolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton10.Text = "ToolStripButton10";
            this.ToolStripButton10.ToolTipText = "В Excel";
            this.ToolStripButton10.Click += new System.EventHandler(this.ToolStripButton10_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::SMRC.Properties.Resources.Reestr;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Отчет о выполнении Регламента";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(39, 22);
            this.tslCount.Text = "Всего:";
            // 
            // tstText
            // 
            this.tstText.Name = "tstText";
            this.tstText.Size = new System.Drawing.Size(200, 25);
            this.tstText.DoubleClick += new System.EventHandler(this.tstText_DoubleClick);
            // 
            // tsFilter
            // 
            this.tsFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFilter.Image = global::SMRC.Properties.Resources.FILTER2;
            this.tsFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(23, 22);
            this.tsFilter.Text = "toolStripButton5";
            this.tsFilter.Click += new System.EventHandler(this.tsFilter_Click);
            // 
            // ToolStripButton9
            // 
            this.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton9.Image = global::SMRC.Properties.Resources.Exit1;
            this.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton9.Name = "ToolStripButton9";
            this.ToolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton9.Text = "Выход";
            this.ToolStripButton9.Click += new System.EventHandler(this.ToolStripButton9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(371, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(1, 42);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(978, 458);
            this.Dgv1.TabIndex = 3;
            this.Dgv1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellLeave);
            this.Dgv1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_RowEnter);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellClick);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // tsbFind
            // 
            tsbFind.Image = global::SMRC.Properties.Resources.Find;
            tsbFind.Name = "tsbFind";
            tsbFind.Size = new System.Drawing.Size(66, 25);
            tsbFind.Text = "Найти";
            tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // frmPlanSmA0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Dgv1);
            this.Name = "frmPlanSmA0";
            this.Text = "Перечень смет, планируемых к закрытию актами КС-2";
            this.Load += new System.EventHandler(this.frmPlanSmA0_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGVt Dgv1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton2;
        internal System.Windows.Forms.ToolStripButton ToolStripButton3;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton10;
        internal System.Windows.Forms.ToolStripButton ToolStripButton9;
        private System.Windows.Forms.ToolStripLabel tslCount;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton tsFilter;
        internal System.Windows.Forms.ToolStripTextBox tstText;
        private System.Windows.Forms.Label label1;
    }
}