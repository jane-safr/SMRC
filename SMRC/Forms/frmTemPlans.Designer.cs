namespace SMRC.Forms
{
    partial class frmTemPlans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemPlans));
            this.IdEntpr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.Button4 = new System.Windows.Forms.Button();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // IdEntpr
            // 
            this.IdEntpr.BackColor = System.Drawing.Color.Snow;
            this.IdEntpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdEntpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdEntpr.FormattingEnabled = true;
            this.IdEntpr.Location = new System.Drawing.Point(144, 1);
            this.IdEntpr.Name = "IdEntpr";
            this.IdEntpr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdEntpr.Size = new System.Drawing.Size(126, 21);
            this.IdEntpr.TabIndex = 20;
            this.IdEntpr.SelectedIndexChanged += new System.EventHandler(this.IdEntpr_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Предприятие";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip3.Location = new System.Drawing.Point(3, 9);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(58, 25);
            this.toolStrip3.TabIndex = 32;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Добавить фактического заказчика";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Удалить фактического заказчика";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // Button4
            // 
            this.Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Button4.Location = new System.Drawing.Point(344, 315);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(73, 23);
            this.Button4.TabIndex = 33;
            this.Button4.Text = "Закрыть";
            this.Button4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(3, 34);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(414, 275);
            this.Dgv1.TabIndex = 22;
            this.Dgv1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Dgv1_UserDeletingRow);
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(276, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 17);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "по всем предприятиям";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmTemPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 340);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdEntpr);
            this.Name = "frmTemPlans";
            this.Text = "Тематическое планирование";
            this.Load += new System.EventHandler(this.frmTemPlans_Load);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox IdEntpr;
        private System.Windows.Forms.Label label1;
        private DGVt Dgv1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        internal System.Windows.Forms.Button Button4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}