namespace SMRC.Forms
{
    partial class frmLSSmeti
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv2 = new SMRC.DGVt(this.components);
            this.lNomer = new System.Windows.Forms.Label();
            this.lNaim = new System.Windows.Forms.Label();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 48);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Dgv1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.Dgv2);
            this.splitContainer1.Size = new System.Drawing.Size(821, 505);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Выполненные объемы";
            // 
            // Dgv2
            // 
            this.Dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv2.Location = new System.Drawing.Point(0, 23);
            this.Dgv2.Name = "Dgv2";
            this.Dgv2.Size = new System.Drawing.Size(821, 99);
            this.Dgv2.TabIndex = 56;
            // 
            // lNomer
            // 
            this.lNomer.Location = new System.Drawing.Point(2, 9);
            this.lNomer.Name = "lNomer";
            this.lNomer.Size = new System.Drawing.Size(194, 36);
            this.lNomer.TabIndex = 58;
            this.lNomer.Text = "Номер";
            // 
            // lNaim
            // 
            this.lNaim.AllowDrop = true;
            this.lNaim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lNaim.Location = new System.Drawing.Point(202, 9);
            this.lNaim.Name = "lNaim";
            this.lNaim.Size = new System.Drawing.Size(621, 36);
            this.lNaim.TabIndex = 59;
            this.lNaim.Text = "Наименование";
            // 
            // Dgv1
            // 
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.Location = new System.Drawing.Point(0, 0);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(821, 379);
            this.Dgv1.TabIndex = 57;
            // 
            // frmLSSmeti
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 557);
            this.Controls.Add(this.lNaim);
            this.Controls.Add(this.lNomer);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmLSSmeti";
            this.Text = "Локальная смета";
            this.Load += new System.EventHandler(this.frmLSSmeti_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DGVt Dgv2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lNomer;
        public System.Windows.Forms.Label lNaim;
        private DGVt Dgv1;
    }
}