namespace SMRC.Forms
{
    partial class frmKP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Period = new System.Windows.Forms.ComboBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.NMPlan = new System.Windows.Forms.TextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Period);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(632, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 69);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор периода";
            // 
            // Period
            // 
            this.Period.BackColor = System.Drawing.Color.Snow;
            this.Period.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Period.FormattingEnabled = true;
            this.Period.Location = new System.Drawing.Point(6, 42);
            this.Period.Name = "Period";
            this.Period.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Period.Size = new System.Drawing.Size(197, 21);
            this.Period.TabIndex = 26;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(89, 19);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(58, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Месяц";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(16, 19);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(67, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Квартал";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // NMPlan
            // 
            this.NMPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NMPlan.Location = new System.Drawing.Point(4, 2);
            this.NMPlan.Name = "NMPlan";
            this.NMPlan.Size = new System.Drawing.Size(835, 20);
            this.NMPlan.TabIndex = 26;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripButton1});
            this.toolStrip3.Location = new System.Drawing.Point(4, 67);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(302, 25);
            this.toolStrip3.TabIndex = 34;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Добавить смету в план";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Удалить смету из плана";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Button4.Location = new System.Drawing.Point(765, 403);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(73, 23);
            this.Button4.TabIndex = 36;
            this.Button4.Text = "Закрыть";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button3.Image = ((System.Drawing.Image)(resources.GetObject("Button3.Image")));
            this.Button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Button3.Location = new System.Drawing.Point(676, 403);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(87, 23);
            this.Button3.TabIndex = 35;
            this.Button3.Text = "Сохранить";
            this.Button3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(105, 22);
            this.toolStripButton1.Text = "Растространить";
            this.toolStripButton1.ToolTipText = "Растространить начало и продолжительность работ на все сметы без даты";
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(4, 94);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(835, 303);
            this.Dgv1.TabIndex = 29;
            this.Dgv1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Dgv1_UserDeletingRow);
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            this.Dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellContentClick);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::SMRC.Properties.Resources.REFRESH;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton5.Text = "Обновить";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // frmKP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 428);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.NMPlan);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmKP";
            this.Text = "Календарное планирование";
            this.Load += new System.EventHandler(this.frmKP1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKP1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox Period;
        private System.Windows.Forms.RadioButton rb2;
        public System.Windows.Forms.RadioButton rb1;
        public System.Windows.Forms.TextBox NMPlan;
        private DGVt Dgv1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}