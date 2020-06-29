namespace SMRC.Forms
{
    partial class frmTemPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemPlan));
            this.IdEntpr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NMPlan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Period = new System.Windows.Forms.ComboBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.chOsnovnoi = new System.Windows.Forms.CheckBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.i1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.i3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.i2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbplan = new System.Windows.Forms.RadioButton();
            this.rballnezav = new System.Windows.Forms.RadioButton();
            this.rbosr = new System.Windows.Forms.RadioButton();
            this.IdOSR = new System.Windows.Forms.ComboBox();
            this.Dgv2 = new SMRC.DGVt(this.components);
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.groupBox1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // IdEntpr
            // 
            this.IdEntpr.BackColor = System.Drawing.Color.Snow;
            this.IdEntpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdEntpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdEntpr.FormattingEnabled = true;
            this.IdEntpr.Location = new System.Drawing.Point(4, 23);
            this.IdEntpr.Name = "IdEntpr";
            this.IdEntpr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdEntpr.Size = new System.Drawing.Size(225, 21);
            this.IdEntpr.TabIndex = 20;
            this.IdEntpr.SelectedIndexChanged += new System.EventHandler(this.IdEntpr_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Предприятие";
            // 
            // NMPlan
            // 
            this.NMPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NMPlan.Location = new System.Drawing.Point(4, 102);
            this.NMPlan.Name = "NMPlan";
            this.NMPlan.Size = new System.Drawing.Size(682, 20);
            this.NMPlan.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Наименование";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Period);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(263, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 89);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор периода";
            // 
            // Period
            // 
            this.Period.BackColor = System.Drawing.Color.Snow;
            this.Period.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Period.FormattingEnabled = true;
            this.Period.Location = new System.Drawing.Point(6, 62);
            this.Period.Name = "Period";
            this.Period.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Period.Size = new System.Drawing.Size(197, 21);
            this.Period.TabIndex = 26;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(16, 43);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(58, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Месяц";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
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
            // chOsnovnoi
            // 
            this.chOsnovnoi.AutoSize = true;
            this.chOsnovnoi.Location = new System.Drawing.Point(6, 56);
            this.chOsnovnoi.Name = "chOsnovnoi";
            this.chOsnovnoi.Size = new System.Drawing.Size(76, 17);
            this.chOsnovnoi.TabIndex = 25;
            this.chOsnovnoi.Text = "Основной";
            this.chOsnovnoi.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton5});
            this.toolStrip3.Location = new System.Drawing.Point(4, 212);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(244, 25);
            this.toolStrip3.TabIndex = 33;
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
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "План";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton1.Text = "Отчет";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.MergeIndex = 1;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton5.Text = "Обновить";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Button4.Location = new System.Drawing.Point(615, 504);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(73, 23);
            this.Button4.TabIndex = 27;
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
            this.Button3.Location = new System.Drawing.Point(526, 504);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(87, 23);
            this.Button3.TabIndex = 26;
            this.Button3.Text = "Сохранить";
            this.Button3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.727273F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "План по видам работ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "СМР";
            // 
            // i1
            // 
            this.i1.Location = new System.Drawing.Point(109, 16);
            this.i1.Name = "i1";
            this.i1.Size = new System.Drawing.Size(92, 20);
            this.i1.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.i3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.i2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.i1);
            this.groupBox2.Location = new System.Drawing.Point(478, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 98);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Индексы перевода в текущие цены";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 20);
            this.button1.TabIndex = 43;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Прочие";
            // 
            // i3
            // 
            this.i3.Location = new System.Drawing.Point(109, 59);
            this.i3.Name = "i3";
            this.i3.Size = new System.Drawing.Size(92, 20);
            this.i3.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Оборудование";
            // 
            // i2
            // 
            this.i2.Location = new System.Drawing.Point(109, 37);
            this.i2.Name = "i2";
            this.i2.Size = new System.Drawing.Size(92, 20);
            this.i2.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rbplan);
            this.groupBox3.Controls.Add(this.rballnezav);
            this.groupBox3.Controls.Add(this.rbosr);
            this.groupBox3.Controls.Add(this.IdOSR);
            this.groupBox3.Location = new System.Drawing.Point(2, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 81);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // rbplan
            // 
            this.rbplan.AutoSize = true;
            this.rbplan.Checked = true;
            this.rbplan.Location = new System.Drawing.Point(10, 10);
            this.rbplan.Name = "rbplan";
            this.rbplan.Size = new System.Drawing.Size(71, 17);
            this.rbplan.TabIndex = 44;
            this.rbplan.TabStop = true;
            this.rbplan.Text = "По плану";
            this.rbplan.UseVisualStyleBackColor = true;
            this.rbplan.CheckedChanged += new System.EventHandler(this.rbosr_CheckedChanged);
            // 
            // rballnezav
            // 
            this.rballnezav.AutoSize = true;
            this.rballnezav.Location = new System.Drawing.Point(10, 58);
            this.rballnezav.Name = "rballnezav";
            this.rballnezav.Size = new System.Drawing.Size(320, 17);
            this.rballnezav.TabIndex = 43;
            this.rballnezav.Text = "Все незавершенное строительство за выбранный период";
            this.rballnezav.UseVisualStyleBackColor = true;
            // 
            // rbosr
            // 
            this.rbosr.AutoSize = true;
            this.rbosr.Location = new System.Drawing.Point(10, 35);
            this.rbosr.Name = "rbosr";
            this.rbosr.Size = new System.Drawing.Size(274, 17);
            this.rbosr.TabIndex = 42;
            this.rbosr.Text = "По ОСР, включая незавершенное строительство";
            this.rbosr.UseVisualStyleBackColor = true;
            this.rbosr.CheckedChanged += new System.EventHandler(this.rbosr_CheckedChanged);
            // 
            // IdOSR
            // 
            this.IdOSR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.IdOSR.BackColor = System.Drawing.Color.Snow;
            this.IdOSR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdOSR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdOSR.FormattingEnabled = true;
            this.IdOSR.Location = new System.Drawing.Point(298, 31);
            this.IdOSR.Name = "IdOSR";
            this.IdOSR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdOSR.Size = new System.Drawing.Size(380, 21);
            this.IdOSR.TabIndex = 34;
            this.IdOSR.Visible = false;
            this.IdOSR.SelectedIndexChanged += new System.EventHandler(this.IdOSR_SelectedIndexChanged);
            // 
            // Dgv2
            // 
            this.Dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv2.Location = new System.Drawing.Point(4, 423);
            this.Dgv2.Name = "Dgv2";
            this.Dgv2.Size = new System.Drawing.Size(682, 75);
            this.Dgv2.TabIndex = 35;
            this.Dgv2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv2_CellEndEdit);
            this.Dgv2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv2_CellEnter);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(4, 240);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(682, 162);
            this.Dgv1.TabIndex = 28;
            this.Dgv1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_RowEnter);
            this.Dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv1_CellFormatting);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // frmTemPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 529);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.Dgv2);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.chOsnovnoi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NMPlan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdEntpr);
            this.Name = "frmTemPlan";
            this.Text = "Тематический план";
            this.Load += new System.EventHandler(this.frmTemPlan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox IdEntpr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox Period;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.CheckBox chOsnovnoi;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        private DGVt Dgv1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private DGVt Dgv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox i1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox i3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox i2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.TextBox NMPlan;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        public System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox IdOSR;
        public System.Windows.Forms.RadioButton rballnezav;
        public System.Windows.Forms.RadioButton rbosr;
        public System.Windows.Forms.RadioButton rbplan;
    }
}