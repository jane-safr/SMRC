namespace SMRC.Forms
{
    partial class frmVibTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibTP));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.nm1 = new System.Windows.Forms.ComboBox();
            this.nm2 = new System.Windows.Forms.ComboBox();
            this.d1 = new System.Windows.Forms.DateTimePicker();
            this.d2 = new System.Windows.Forms.DateTimePicker();
            this.chAllWrk = new System.Windows.Forms.CheckBox();
            this.nm3 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "с";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 89);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(434, 25);
            this.ToolStrip1.TabIndex = 46;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // TEx
            // 
            this.TEx.Image = ((System.Drawing.Image)(resources.GetObject("TEx.Image")));
            this.TEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TEx.Name = "TEx";
            this.TEx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TEx.Size = new System.Drawing.Size(71, 22);
            this.TEx.Text = "Закрыть";
            this.TEx.ToolTipText = "Выход";
            this.TEx.Click += new System.EventHandler(this.TEx_Click);
            // 
            // TVib
            // 
            this.TVib.Image = global::SMRC.Properties.Resources.exlel;
            this.TVib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TVib.Name = "TVib";
            this.TVib.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TVib.Size = new System.Drawing.Size(61, 22);
            this.TVib.Text = "в Excel";
            this.TVib.ToolTipText = "Просмотр";
            this.TVib.Click += new System.EventHandler(this.TVib_Click);
            // 
            // nm1
            // 
            this.nm1.BackColor = System.Drawing.Color.Snow;
            this.nm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nm1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nm1.FormattingEnabled = true;
            this.nm1.Location = new System.Drawing.Point(22, 9);
            this.nm1.Name = "nm1";
            this.nm1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nm1.Size = new System.Drawing.Size(204, 21);
            this.nm1.TabIndex = 47;
            // 
            // nm2
            // 
            this.nm2.BackColor = System.Drawing.Color.Snow;
            this.nm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nm2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nm2.FormattingEnabled = true;
            this.nm2.Location = new System.Drawing.Point(243, 11);
            this.nm2.Name = "nm2";
            this.nm2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nm2.Size = new System.Drawing.Size(183, 21);
            this.nm2.TabIndex = 48;
            // 
            // d1
            // 
            this.d1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d1.Location = new System.Drawing.Point(22, 39);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(204, 20);
            this.d1.TabIndex = 49;
            // 
            // d2
            // 
            this.d2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d2.Location = new System.Drawing.Point(243, 39);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(183, 20);
            this.d2.TabIndex = 50;
            // 
            // chAllWrk
            // 
            this.chAllWrk.AutoSize = true;
            this.chAllWrk.Location = new System.Drawing.Point(248, 70);
            this.chAllWrk.Name = "chAllWrk";
            this.chAllWrk.Size = new System.Drawing.Size(90, 17);
            this.chAllWrk.TabIndex = 51;
            this.chAllWrk.Text = "все проекты";
            this.chAllWrk.UseVisualStyleBackColor = true;
            // 
            // nm3
            // 
            this.nm3.BackColor = System.Drawing.Color.Snow;
            this.nm3.Enabled = false;
            this.nm3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nm3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nm3.FormattingEnabled = true;
            this.nm3.Location = new System.Drawing.Point(22, 65);
            this.nm3.Name = "nm3";
            this.nm3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nm3.Size = new System.Drawing.Size(204, 21);
            this.nm3.TabIndex = 52;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmVibTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 114);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.nm3);
            this.Controls.Add(this.chAllWrk);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.nm1);
            this.Controls.Add(this.nm2);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmVibTP";
            this.Text = "Выбор периода для Тематического планирования";
            this.Load += new System.EventHandler(this.frmVibTP_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        internal System.Windows.Forms.ComboBox nm1;
        internal System.Windows.Forms.ComboBox nm2;
        private System.Windows.Forms.DateTimePicker d1;
        private System.Windows.Forms.DateTimePicker d2;
        private System.Windows.Forms.CheckBox chAllWrk;
        internal System.Windows.Forms.ComboBox nm3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}