namespace SMRC.Forms
{
    partial class frmVibDates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibDates));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.d2 = new System.Windows.Forms.DateTimePicker();
            this.d1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 40);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(370, 25);
            this.ToolStrip1.TabIndex = 48;
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
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(203, 7);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(154, 20);
            this.d2.TabIndex = 54;
            // 
            // d1
            // 
            this.d1.Location = new System.Drawing.Point(21, 7);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(151, 20);
            this.d1.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-39, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "с";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "с";
            // 
            // frmVibDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 65);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmVibDates";
            this.Text = "Выбор периода";
            this.Load += new System.EventHandler(this.frmVibDates_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.DateTimePicker d2;
        private System.Windows.Forms.DateTimePicker d1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}