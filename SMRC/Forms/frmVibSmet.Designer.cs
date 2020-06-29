namespace SMRC.Forms
{
    partial class frmVibSmet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibSmet));
            this.d1 = new System.Windows.Forms.ComboBox();
            this.IdEnt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.d2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.chPr = new System.Windows.Forms.CheckBox();
            this.chUch = new System.Windows.Forms.CheckBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Snow;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d1.FormattingEnabled = true;
            this.d1.Location = new System.Drawing.Point(12, 28);
            this.d1.Name = "d1";
            this.d1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d1.Size = new System.Drawing.Size(104, 21);
            this.d1.TabIndex = 22;
            // 
            // IdEnt
            // 
            this.IdEnt.BackColor = System.Drawing.Color.Snow;
            this.IdEnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdEnt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdEnt.FormattingEnabled = true;
            this.IdEnt.Location = new System.Drawing.Point(86, 3);
            this.IdEnt.Name = "IdEnt";
            this.IdEnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdEnt.Size = new System.Drawing.Size(158, 21);
            this.IdEnt.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Предприятие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "по";
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.Color.Snow;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d2.FormattingEnabled = true;
            this.d2.Location = new System.Drawing.Point(135, 30);
            this.d2.Name = "d2";
            this.d2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d2.Size = new System.Drawing.Size(109, 21);
            this.d2.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton0);
            this.groupBox1.Location = new System.Drawing.Point(4, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 55);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Рассчитывать по";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 17);
            this.radioButton1.TabIndex = 29;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "справкам ф.№3";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Checked = true;
            this.radioButton0.Location = new System.Drawing.Point(6, 15);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(87, 17);
            this.radioButton0.TabIndex = 28;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "формам №2";
            this.radioButton0.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(122, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 55);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 17);
            this.radioButton3.TabIndex = 29;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Усеченный";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 28;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Полный";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // chPr
            // 
            this.chPr.AutoSize = true;
            this.chPr.Location = new System.Drawing.Point(4, 118);
            this.chPr.Name = "chPr";
            this.chPr.Size = new System.Drawing.Size(93, 17);
            this.chPr.TabIndex = 31;
            this.chPr.Text = "По прорабам";
            this.chPr.UseVisualStyleBackColor = true;
            this.chPr.Visible = false;
            // 
            // chUch
            // 
            this.chUch.AutoSize = true;
            this.chUch.Location = new System.Drawing.Point(122, 121);
            this.chUch.Name = "chUch";
            this.chUch.Size = new System.Drawing.Size(90, 17);
            this.chUch.TabIndex = 32;
            this.chUch.Text = "По участкам";
            this.chUch.UseVisualStyleBackColor = true;
            this.chUch.Visible = false;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib,
            this.toolStripButton1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 141);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(244, 25);
            this.ToolStrip1.TabIndex = 45;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // TEx
            // 
            this.TEx.Image = ((System.Drawing.Image)(resources.GetObject("TEx.Image")));
            this.TEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TEx.Name = "TEx";
            this.TEx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TEx.Size = new System.Drawing.Size(73, 22);
            this.TEx.Text = "Закрыть";
            this.TEx.ToolTipText = "Выход";
            this.TEx.Click += new System.EventHandler(this.TEx_Click);
            // 
            // TVib
            // 
            this.TVib.Image = global::SMRC.Properties.Resources.PreviewAkt;
            this.TVib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TVib.Name = "TVib";
            this.TVib.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TVib.Size = new System.Drawing.Size(84, 22);
            this.TVib.Text = "Просмотр";
            this.TVib.ToolTipText = "Просмотр";
            this.TVib.Click += new System.EventHandler(this.TVib_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton1.Text = "Таблица";
            // 
            // frmVibSmet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 166);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.chUch);
            this.Controls.Add(this.chPr);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdEnt);
            this.Name = "frmVibSmet";
            this.Text = "Выберите параметры";
            this.Activated += new System.EventHandler(this.frmVibSmet_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVibSmet_FormClosing);
            this.Load += new System.EventHandler(this.frmVibSmet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox d1;
        internal System.Windows.Forms.ComboBox IdEnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox d2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox chPr;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.CheckBox chUch;
    }
}