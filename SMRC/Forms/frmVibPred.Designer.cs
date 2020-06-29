namespace SMRC.Forms
{
    partial class frmVibPred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibPred));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.d1 = new System.Windows.Forms.ComboBox();
            this.d2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IdEnt = new System.Windows.Forms.ComboBox();
            this.idComplex = new System.Windows.Forms.ComboBox();
            this.chSub = new System.Windows.Forms.CheckBox();
            this.chOldCodir = new System.Windows.Forms.CheckBox();
            this.chPoMes = new System.Windows.Forms.CheckBox();
            this.chSNds = new System.Windows.Forms.CheckBox();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 123);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(265, 25);
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
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Snow;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d1.FormattingEnabled = true;
            this.d1.Location = new System.Drawing.Point(12, 71);
            this.d1.Name = "d1";
            this.d1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d1.Size = new System.Drawing.Size(110, 21);
            this.d1.TabIndex = 48;
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.Color.Snow;
            this.d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d2.FormattingEnabled = true;
            this.d2.Location = new System.Drawing.Point(144, 73);
            this.d2.Name = "d2";
            this.d2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d2.Size = new System.Drawing.Size(117, 21);
            this.d2.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "с";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Предприятие";
            // 
            // IdEnt
            // 
            this.IdEnt.BackColor = System.Drawing.Color.Snow;
            this.IdEnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdEnt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.IdEnt.FormattingEnabled = true;
            this.IdEnt.Location = new System.Drawing.Point(86, 46);
            this.IdEnt.Name = "IdEnt";
            this.IdEnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdEnt.Size = new System.Drawing.Size(175, 21);
            this.IdEnt.TabIndex = 47;
            // 
            // idComplex
            // 
            this.idComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.idComplex.BackColor = System.Drawing.Color.Snow;
            this.idComplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idComplex.ForeColor = System.Drawing.SystemColors.Highlight;
            this.idComplex.FormattingEnabled = true;
            this.idComplex.Location = new System.Drawing.Point(12, 98);
            this.idComplex.Name = "idComplex";
            this.idComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idComplex.Size = new System.Drawing.Size(249, 21);
            this.idComplex.TabIndex = 53;
            // 
            // chSub
            // 
            this.chSub.AutoSize = true;
            this.chSub.Location = new System.Drawing.Point(114, 0);
            this.chSub.Name = "chSub";
            this.chSub.Size = new System.Drawing.Size(102, 17);
            this.chSub.TabIndex = 55;
            this.chSub.Text = "с субподрядом";
            this.chSub.UseVisualStyleBackColor = true;
            // 
            // chOldCodir
            // 
            this.chOldCodir.AutoSize = true;
            this.chOldCodir.Location = new System.Drawing.Point(0, 23);
            this.chOldCodir.Name = "chOldCodir";
            this.chOldCodir.Size = new System.Drawing.Size(118, 17);
            this.chOldCodir.TabIndex = 56;
            this.chOldCodir.Text = "старая кодировка";
            this.chOldCodir.UseVisualStyleBackColor = true;
            // 
            // chPoMes
            // 
            this.chPoMes.AutoSize = true;
            this.chPoMes.Location = new System.Drawing.Point(114, 23);
            this.chPoMes.Name = "chPoMes";
            this.chPoMes.Size = new System.Drawing.Size(87, 17);
            this.chPoMes.TabIndex = 57;
            this.chPoMes.Text = "по месяцам";
            this.chPoMes.UseVisualStyleBackColor = true;
            this.chPoMes.CheckedChanged += new System.EventHandler(this.chPoMes_CheckedChanged);
            // 
            // chSNds
            // 
            this.chSNds.AutoSize = true;
            this.chSNds.Location = new System.Drawing.Point(204, 23);
            this.chSNds.Name = "chSNds";
            this.chSNds.Size = new System.Drawing.Size(59, 17);
            this.chSNds.TabIndex = 58;
            this.chSNds.Text = "с НДС";
            this.chSNds.UseVisualStyleBackColor = true;
            // 
            // frmVibPred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 148);
            this.Controls.Add(this.chSNds);
            this.Controls.Add(this.chPoMes);
            this.Controls.Add(this.chOldCodir);
            this.Controls.Add(this.chSub);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdEnt);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.idComplex);
            this.Name = "frmVibPred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите параметры";
            this.Activated += new System.EventHandler(this.frmVibPred_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVibPred_FormClosing);
            this.Load += new System.EventHandler(this.frmVibPred_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        internal System.Windows.Forms.ComboBox d1;
        internal System.Windows.Forms.ComboBox d2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox IdEnt;
        internal System.Windows.Forms.ComboBox idComplex;
        private System.Windows.Forms.CheckBox chSub;
        private System.Windows.Forms.CheckBox chOldCodir;
        private System.Windows.Forms.CheckBox chPoMes;
        private System.Windows.Forms.CheckBox chSNds;
    }
}