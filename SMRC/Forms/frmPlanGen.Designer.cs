namespace SMRC.Forms
{
    partial class frmPlanGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanGen));
            this.idComplex = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tInd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // idComplex
            // 
            this.idComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idComplex.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idComplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idComplex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idComplex.FormattingEnabled = true;
            this.idComplex.Location = new System.Drawing.Point(118, 6);
            this.idComplex.Name = "idComplex";
            this.idComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idComplex.Size = new System.Drawing.Size(705, 21);
            this.idComplex.TabIndex = 37;
            this.idComplex.SelectedIndexChanged += new System.EventHandler(this.idComplex_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10.90909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(-1, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 18);
            this.label15.TabIndex = 38;
            this.label15.Text = "Инв.проект";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton1});
            this.toolStrip3.Location = new System.Drawing.Point(2, 33);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(79, 25);
            this.toolStrip3.TabIndex = 39;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Добавить";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Удалить";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SMRC.Properties.Resources.rem1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Добавить кодирование из ф2";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tInd
            // 
            this.tInd.Location = new System.Drawing.Point(177, 35);
            this.tInd.Name = "tInd";
            this.tInd.Size = new System.Drawing.Size(100, 20);
            this.tInd.TabIndex = 41;
            this.tInd.Text = "117.5852";
            this.tInd.TextChanged += new System.EventHandler(this.tInd_TextChanged);
            this.tInd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tInd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.90909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(115, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "Индекс";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Из текущих в базовые";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Из базовых в текущие";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(2, 61);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(821, 432);
            this.Dgv1.TabIndex = 40;
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            this.Dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellContentClick);
            // 
            // frmPlanGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 494);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tInd);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.idComplex);
            this.Name = "frmPlanGen";
            this.Text = "Планирование по Инвестиционным проектам";
            this.Load += new System.EventHandler(this.frmPlanGen_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlanGen_FormClosed);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox idComplex;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private DGVt Dgv1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox tInd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}