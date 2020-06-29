namespace SMRC.Forms
{
    partial class frmActsZak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActsZak));
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LSum = new System.Windows.Forms.Label();
            this.idIstFin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NMrab = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReestr = new System.Windows.Forms.ToolStripButton();
            this.tsbF3 = new System.Windows.Forms.ToolStripButton();
            this.tsbSelAll = new System.Windows.Forms.ToolStripButton();
            this.tsbSelCh = new System.Windows.Forms.ToolStripButton();
            this.tsbSelRem = new System.Windows.Forms.ToolStripButton();
            this.tsbEx = new System.Windows.Forms.ToolStripButton();
            this.DgvActs = new SMRC.DGVt(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(631, 7);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(112, 23);
            this.TextBox1.TabIndex = 6;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(631, 27);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(112, 22);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Найти";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LSum);
            this.panel1.Controls.Add(this.idIstFin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NMrab);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Button1);
            this.panel1.Controls.Add(this.TextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 64);
            this.panel1.TabIndex = 7;
            // 
            // LSum
            // 
            this.LSum.AutoSize = true;
            this.LSum.Location = new System.Drawing.Point(12, 48);
            this.LSum.Name = "LSum";
            this.LSum.Size = new System.Drawing.Size(35, 13);
            this.LSum.TabIndex = 11;
            this.LSum.Text = "label3";
            // 
            // idIstFin
            // 
            this.idIstFin.FormattingEnabled = true;
            this.idIstFin.Location = new System.Drawing.Point(130, 27);
            this.idIstFin.Name = "idIstFin";
            this.idIstFin.Size = new System.Drawing.Size(172, 21);
            this.idIstFin.TabIndex = 10;
            this.idIstFin.SelectedIndexChanged += new System.EventHandler(this.idIstFin_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ист.фин.";
            // 
            // NMrab
            // 
            this.NMrab.Location = new System.Drawing.Point(130, 7);
            this.NMrab.Name = "NMrab";
            this.NMrab.Size = new System.Drawing.Size(494, 20);
            this.NMrab.TabIndex = 8;
            this.NMrab.Leave += new System.EventHandler(this.NMrab_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Наименование работ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 33);
            this.panel2.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReestr,
            this.tsbF3,
            this.tsbSelAll,
            this.tsbSelCh,
            this.tsbSelRem,
            this.tsbEx});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReestr
            // 
            this.tsbReestr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReestr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReestr.Name = "tsbReestr";
            this.tsbReestr.Size = new System.Drawing.Size(48, 22);
            this.tsbReestr.Text = "Реестр";
            this.tsbReestr.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbReestr.Click += new System.EventHandler(this.tsbReestr_Click);
            // 
            // tsbF3
            // 
            this.tsbF3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbF3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbF3.Name = "tsbF3";
            this.tsbF3.Size = new System.Drawing.Size(104, 22);
            this.tsbF3.Text = "             Ф3!            ";
            this.tsbF3.Click += new System.EventHandler(this.tsbF3_Click);
            // 
            // tsbSelAll
            // 
            this.tsbSelAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelAll.Name = "tsbSelAll";
            this.tsbSelAll.Size = new System.Drawing.Size(85, 22);
            this.tsbSelAll.Text = "Выделить все";
            this.tsbSelAll.Click += new System.EventHandler(this.tsbSelAll_Click);
            // 
            // tsbSelCh
            // 
            this.tsbSelCh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelCh.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelCh.Image")));
            this.tsbSelCh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelCh.Name = "tsbSelCh";
            this.tsbSelCh.Size = new System.Drawing.Size(129, 22);
            this.tsbSelCh.Text = "Выделить выбранное";
            this.tsbSelCh.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsbSelRem
            // 
            this.tsbSelRem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelRem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelRem.Name = "tsbSelRem";
            this.tsbSelRem.Size = new System.Drawing.Size(128, 22);
            this.tsbSelRem.Text = "Очистить выбранное";
            this.tsbSelRem.Click += new System.EventHandler(this.tsbSelRem_Click);
            // 
            // tsbEx
            // 
            this.tsbEx.Image = global::SMRC.Properties.Resources.Exit1;
            this.tsbEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEx.Name = "tsbEx";
            this.tsbEx.Size = new System.Drawing.Size(73, 22);
            this.tsbEx.Text = "Закрыть";
            this.tsbEx.Click += new System.EventHandler(this.tsbEx_Click);
            // 
            // DgvActs
            // 
            this.DgvActs.BackgroundColor = System.Drawing.SystemColors.Info;
            this.DgvActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvActs.Location = new System.Drawing.Point(0, 64);
            this.DgvActs.Name = "DgvActs";
            this.DgvActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvActs.Size = new System.Drawing.Size(747, 253);
            this.DgvActs.TabIndex = 5;
            this.DgvActs.SelectionChanged += new System.EventHandler(this.Dgv1_SelectionChanged);
            // 
            // frmActsZak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 350);
            this.Controls.Add(this.DgvActs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmActsZak";
            this.Text = "frmActsZak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmActsZak_FormClosing);
            this.Load += new System.EventHandler(this.frmActsZak_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DGVt DgvActs;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox NMrab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LSum;
        public System.Windows.Forms.ComboBox idIstFin;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbReestr;
        private System.Windows.Forms.ToolStripButton tsbF3;
        private System.Windows.Forms.ToolStripButton tsbSelAll;
        private System.Windows.Forms.ToolStripButton tsbSelCh;
        private System.Windows.Forms.ToolStripButton tsbSelRem;
        private System.Windows.Forms.ToolStripButton tsbEx;
    }
}