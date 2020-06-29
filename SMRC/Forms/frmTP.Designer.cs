namespace SMRC.Forms
{
    partial class frmTP
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
            this.lCount = new System.Windows.Forms.Label();
            this.ucFilter1 = new UCFilter.UCFilter();
            this.Dgv1 = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCount.Location = new System.Drawing.Point(12, 115);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(46, 13);
            this.lCount.TabIndex = 56;
            this.lCount.Text = "Всего:";
            // 
            // ucFilter1
            // 
            this.ucFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(1014, 112);
            this.ucFilter1.TabIndex = 57;
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(12, 118);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(990, 438);
            this.Dgv1.TabIndex = 55;
            this.Dgv1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Dgv1_CellBeginEdit);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            // 
            // frmTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 581);
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.Dgv1);
            this.Name = "frmTP";
            this.Text = "Работы и сметы для формирования тематического планирования";
            this.Load += new System.EventHandler(this.frmTP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DGVt Dgv1;
        private System.Windows.Forms.Label lCount;
        private UCFilter.UCFilter ucFilter1;
    }
}