namespace SMRC.Forms
{
    partial class frmVibPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibPeriod));
            this.d1 = new System.Windows.Forms.ComboBox();
            this.d2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.Color.Snow;
            this.d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.d1.FormattingEnabled = true;
            this.d1.Location = new System.Drawing.Point(12, 12);
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
            this.d2.Location = new System.Drawing.Point(135, 14);
            this.d2.Name = "d2";
            this.d2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d2.Size = new System.Drawing.Size(109, 21);
            this.d2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 15);
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
            this.ToolStrip1.Location = new System.Drawing.Point(0, 47);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(261, 25);
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
            // frmVibPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 72);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmVibPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор периода";
            this.Activated += new System.EventHandler(this.frmVibPeriod_Activated);
            this.Load += new System.EventHandler(this.frmVibPeriod_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox d1;
        internal System.Windows.Forms.ComboBox d2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
    }
}