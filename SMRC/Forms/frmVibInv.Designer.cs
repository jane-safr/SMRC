namespace SMRC.Forms
{
    partial class frmVibInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibInv));
            this.label1 = new System.Windows.Forms.Label();
            this.d1 = new System.Windows.Forms.ComboBox();
            this.d2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IdComplex = new System.Windows.Forms.ComboBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IdDog = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.IdPrice = new System.Windows.Forms.ComboBox();
            this.ToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Код стройки";
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Snow;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d1.FormattingEnabled = true;
            this.d1.Location = new System.Drawing.Point(12, 52);
            this.d1.Name = "d1";
            this.d1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d1.Size = new System.Drawing.Size(104, 21);
            this.d1.TabIndex = 27;
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.Color.Snow;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d2.FormattingEnabled = true;
            this.d2.Location = new System.Drawing.Point(135, 54);
            this.d2.Name = "d2";
            this.d2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d2.Size = new System.Drawing.Size(109, 21);
            this.d2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "с";
            // 
            // IdComplex
            // 
            this.IdComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IdComplex.BackColor = System.Drawing.Color.Snow;
            this.IdComplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdComplex.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdComplex.FormattingEnabled = true;
            this.IdComplex.Location = new System.Drawing.Point(12, 25);
            this.IdComplex.Name = "IdComplex";
            this.IdComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdComplex.Size = new System.Drawing.Size(584, 21);
            this.IdComplex.TabIndex = 31;
            this.IdComplex.SelectedIndexChanged += new System.EventHandler(this.IdComplex_SelectedIndexChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 187);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(608, 25);
            this.ToolStrip1.TabIndex = 46;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.IdPrice);
            this.groupBox1.Controls.Add(this.IdDog);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton0);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 92);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // IdDog
            // 
            this.IdDog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IdDog.BackColor = System.Drawing.Color.Snow;
            this.IdDog.Enabled = false;
            this.IdDog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdDog.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdDog.FormattingEnabled = true;
            this.IdDog.Location = new System.Drawing.Point(158, 57);
            this.IdDog.Name = "IdDog";
            this.IdDog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdDog.Size = new System.Drawing.Size(420, 21);
            this.IdDog.TabIndex = 54;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(127, 17);
            this.radioButton2.TabIndex = 30;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "По контракту + ОСР";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton0_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 29;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "инв.проекту ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton0_CheckedChanged);
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Checked = true;
            this.radioButton0.Location = new System.Drawing.Point(6, 15);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(137, 17);
            this.radioButton0.TabIndex = 28;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "По инв.проекту + ОСР";
            this.radioButton0.UseVisualStyleBackColor = true;
            this.radioButton0.CheckedChanged += new System.EventHandler(this.radioButton0_CheckedChanged);
            // 
            // IdPrice
            // 
            this.IdPrice.BackColor = System.Drawing.Color.Snow;
            this.IdPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdPrice.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdPrice.FormattingEnabled = true;
            this.IdPrice.Location = new System.Drawing.Point(158, 11);
            this.IdPrice.Name = "IdPrice";
            this.IdPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdPrice.Size = new System.Drawing.Size(166, 21);
            this.IdPrice.TabIndex = 55;
            // 
            // frmVibInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.IdComplex);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVibInv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выборка";
            this.Activated += new System.EventHandler(this.frmVibInv_Activated);
            this.Load += new System.EventHandler(this.frmVibInv_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox d1;
        internal System.Windows.Forms.ComboBox d2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox IdComplex;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton0;
        internal System.Windows.Forms.ComboBox IdDog;
        internal System.Windows.Forms.ComboBox IdPrice;
    }
}