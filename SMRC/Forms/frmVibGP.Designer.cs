namespace SMRC.Forms
{
    partial class frmVibGP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibGP));
            this.d1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSub = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.d2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chIsp = new System.Windows.Forms.CheckBox();
            this.d3 = new System.Windows.Forms.ComboBox();
            this.d4 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chVvod = new System.Windows.Forms.CheckBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Snow;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d1.FormattingEnabled = true;
            this.d1.Location = new System.Drawing.Point(20, 24);
            this.d1.Name = "d1";
            this.d1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d1.Size = new System.Drawing.Size(104, 21);
            this.d1.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSub);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 82);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период по";
            // 
            // rbSub
            // 
            this.rbSub.AutoSize = true;
            this.rbSub.Location = new System.Drawing.Point(6, 52);
            this.rbSub.Name = "rbSub";
            this.rbSub.Size = new System.Drawing.Size(84, 17);
            this.rbSub.TabIndex = 30;
            this.rbSub.TabStop = true;
            this.rbSub.Text = "Субподряду";
            this.rbSub.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(6, 32);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(106, 17);
            this.rb3.TabIndex = 29;
            this.rb3.TabStop = true;
            this.rb3.Text = "справкам ф.№3";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Checked = true;
            this.rb2.Location = new System.Drawing.Point(6, 15);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(87, 17);
            this.rb2.TabIndex = 28;
            this.rb2.TabStop = true;
            this.rb2.Text = "формам №2";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.Color.Snow;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d2.FormattingEnabled = true;
            this.d2.Location = new System.Drawing.Point(143, 26);
            this.d2.Name = "d2";
            this.d2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d2.Size = new System.Drawing.Size(109, 21);
            this.d2.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "с";
            // 
            // chIsp
            // 
            this.chIsp.AutoSize = true;
            this.chIsp.Location = new System.Drawing.Point(9, 1);
            this.chIsp.Name = "chIsp";
            this.chIsp.Size = new System.Drawing.Size(115, 17);
            this.chIsp.TabIndex = 33;
            this.chIsp.Text = "С исполнителями";
            this.chIsp.UseVisualStyleBackColor = true;
            // 
            // d3
            // 
            this.d3.BackColor = System.Drawing.Color.Snow;
            this.d3.Enabled = false;
            this.d3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d3.FormattingEnabled = true;
            this.d3.Location = new System.Drawing.Point(17, 141);
            this.d3.Name = "d3";
            this.d3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d3.Size = new System.Drawing.Size(104, 21);
            this.d3.TabIndex = 34;
            // 
            // d4
            // 
            this.d4.BackColor = System.Drawing.Color.Snow;
            this.d4.Enabled = false;
            this.d4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d4.FormattingEnabled = true;
            this.d4.Location = new System.Drawing.Point(140, 143);
            this.d4.Name = "d4";
            this.d4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d4.Size = new System.Drawing.Size(109, 21);
            this.d4.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "по";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "с";
            // 
            // chVvod
            // 
            this.chVvod.AutoSize = true;
            this.chVvod.Location = new System.Drawing.Point(9, 168);
            this.chVvod.Name = "chVvod";
            this.chVvod.Size = new System.Drawing.Size(97, 17);
            this.chVvod.TabIndex = 38;
            this.chVvod.Text = "Период ввода";
            this.chVvod.UseVisualStyleBackColor = true;
            this.chVvod.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib,
            this.toolStripButton1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 186);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(272, 25);
            this.ToolStrip1.TabIndex = 47;
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
            this.toolStripButton1.Image = global::SMRC.Properties.Resources.TemPlan;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(74, 22);
            this.toolStripButton1.Text = "Таблица";
            this.toolStripButton1.Click += new System.EventHandler(this.TVib_Click);
            // 
            // frmVibGP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 211);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.chVvod);
            this.Controls.Add(this.d3);
            this.Controls.Add(this.d4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chIsp);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmVibGP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVibGP";
            this.Activated += new System.EventHandler(this.frmVibGP_Activated);
            this.Load += new System.EventHandler(this.frmVibGP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox d1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        internal System.Windows.Forms.ComboBox d2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbSub;
        private System.Windows.Forms.CheckBox chIsp;
        internal System.Windows.Forms.ComboBox d3;
        internal System.Windows.Forms.ComboBox d4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chVvod;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}