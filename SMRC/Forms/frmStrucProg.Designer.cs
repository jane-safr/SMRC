namespace SMRC.Forms
{
    partial class frmStrucProg
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
            this.FIO = new System.Windows.Forms.Label();
            this.Podtv = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idStrucZag = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tYear = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.idPredpr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // FIO
            // 
            this.FIO.AutoSize = true;
            this.FIO.Location = new System.Drawing.Point(330, 62);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(0, 13);
            this.FIO.TabIndex = 31;
            // 
            // Podtv
            // 
            this.Podtv.AutoSize = true;
            this.Podtv.Location = new System.Drawing.Point(237, 61);
            this.Podtv.Name = "Podtv";
            this.Podtv.Size = new System.Drawing.Size(87, 17);
            this.Podtv.TabIndex = 30;
            this.Podtv.Text = "Подтвердил";
            this.Podtv.UseVisualStyleBackColor = true;
            this.Podtv.Click += new System.EventHandler(this.Podtv_Click);
            this.Podtv.CheckedChanged += new System.EventHandler(this.Podtv_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Наименование плана";
            // 
            // idStrucZag
            // 
            this.idStrucZag.BackColor = System.Drawing.Color.Snow;
            this.idStrucZag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idStrucZag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idStrucZag.FormattingEnabled = true;
            this.idStrucZag.Location = new System.Drawing.Point(120, 32);
            this.idStrucZag.Name = "idStrucZag";
            this.idStrucZag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idStrucZag.Size = new System.Drawing.Size(327, 21);
            this.idStrucZag.TabIndex = 26;
            this.idStrucZag.SelectedValueChanged += new System.EventHandler(this.idStrucZag_SelectedValueChanged);
            this.idStrucZag.Click += new System.EventHandler(this.idStrucZag_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Добавить предприятие";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tYear
            // 
            this.tYear.Location = new System.Drawing.Point(120, 59);
            this.tYear.Name = "tYear";
            this.tYear.Size = new System.Drawing.Size(98, 20);
            this.tYear.TabIndex = 23;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(30, 8);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Предприятие";
            // 
            // idPredpr
            // 
            this.idPredpr.BackColor = System.Drawing.Color.Snow;
            this.idPredpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPredpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idPredpr.FormattingEnabled = true;
            this.idPredpr.Location = new System.Drawing.Point(120, 5);
            this.idPredpr.Name = "idPredpr";
            this.idPredpr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idPredpr.Size = new System.Drawing.Size(327, 21);
            this.idPredpr.TabIndex = 21;
            this.idPredpr.SelectedIndexChanged += new System.EventHandler(this.idPredpr_SelectedIndexChanged);
            this.idPredpr.SelectedValueChanged += new System.EventHandler(this.idPredpr_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Год";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton1,
            this.ToolStripButton3,
            this.ToolStripSeparator1,
            this.ToolStripButton10,
            this.toolStripButton2,
            this.toolStripButton4,
            this.ToolStripButton9});
            this.ToolStrip1.Location = new System.Drawing.Point(6, 85);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(154, 25);
            this.ToolStrip1.TabIndex = 24;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton1.Image = global::SMRC.Properties.Resources.add_small;
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton1.Text = "Добавить структуру программы";
            this.ToolStripButton1.ToolTipText = "Добавить структуру программы";
            this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // ToolStripButton3
            // 
            this.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton3.Image = global::SMRC.Properties.Resources.REFRESH;
            this.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton3.Name = "ToolStripButton3";
            this.ToolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton3.Text = "Обновить";
            this.ToolStripButton3.ToolTipText = "Обновить";
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Добавить привлеченную организацию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::SMRC.Properties.Resources.Copy;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::SMRC.Properties.Resources.Delete;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(1, 114);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(955, 395);
            this.Dgv1.TabIndex = 3;
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // frmStrucProg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.Podtv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idStrucZag);
            this.Controls.Add(this.idPredpr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.tYear);
            this.Name = "frmStrucProg";
            this.Text = "frmStrucProg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStrucProg_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStrucProg_FormClosed);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGVt Dgv1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox idPredpr;
        private System.Windows.Forms.TextBox tYear;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton10;
        internal System.Windows.Forms.ToolStripButton ToolStripButton9;
        internal System.Windows.Forms.ToolStripButton ToolStripButton3;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox idStrucZag;
        private System.Windows.Forms.CheckBox Podtv;
        private System.Windows.Forms.Label FIO;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}