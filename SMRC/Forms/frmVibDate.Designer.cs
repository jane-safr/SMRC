namespace SMRC.Forms
{
    partial class frmVibDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibDate));
            this.d2 = new System.Windows.Forms.DateTimePicker();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dend = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.NMEnt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ind = new System.Windows.Forms.TextBox();
            this.StrDate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(145, 12);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(122, 20);
            this.d2.TabIndex = 0;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 153);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "остатки смет на";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "планируемый период по";
            // 
            // dend
            // 
            this.dend.Location = new System.Drawing.Point(145, 38);
            this.dend.Name = "dend";
            this.dend.Size = new System.Drawing.Size(122, 20);
            this.dend.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Предприятие";
            // 
            // NMEnt
            // 
            this.NMEnt.BackColor = System.Drawing.Color.Snow;
            this.NMEnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NMEnt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.NMEnt.FormattingEnabled = true;
            this.NMEnt.Location = new System.Drawing.Point(89, 67);
            this.NMEnt.Name = "NMEnt";
            this.NMEnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NMEnt.Size = new System.Drawing.Size(176, 21);
            this.NMEnt.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Индекс-дефлятор в тек.цены";
            // 
            // ind
            // 
            this.ind.Location = new System.Drawing.Point(173, 91);
            this.ind.Name = "ind";
            this.ind.Size = new System.Drawing.Size(94, 20);
            this.ind.TabIndex = 54;
            this.ind.Text = "6.19";
            // 
            // StrDate
            // 
            this.StrDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StrDate.BackColor = System.Drawing.Color.Snow;
            this.StrDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StrDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StrDate.FormattingEnabled = true;
            this.StrDate.Location = new System.Drawing.Point(89, 120);
            this.StrDate.Name = "StrDate";
            this.StrDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StrDate.Size = new System.Drawing.Size(176, 21);
            this.StrDate.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Колонка даты";
            // 
            // frmVibDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 178);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StrDate);
            this.Controls.Add(this.ind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NMEnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.d2);
            this.Name = "frmVibDate";
            this.Text = "Тематический план";
            this.Load += new System.EventHandler(this.frmVibDate_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker d2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dend;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox NMEnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ind;
        internal System.Windows.Forms.ComboBox StrDate;
        private System.Windows.Forms.Label label5;
    }
}