namespace SMRC.Forms
{
    partial class frmLinkWRK
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
            this.idWRK = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.idEntpr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Dgv1 = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // idWRK
            // 
            this.idWRK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idWRK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idWRK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idWRK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idWRK.FormattingEnabled = true;
            this.idWRK.Location = new System.Drawing.Point(83, 12);
            this.idWRK.Name = "idWRK";
            this.idWRK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idWRK.Size = new System.Drawing.Size(540, 21);
            this.idWRK.TabIndex = 72;
            this.idWRK.SelectedIndexChanged += new System.EventHandler(this.idWRK_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "ID работы";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(620, 33);
            this.label2.TabIndex = 75;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(445, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 24);
            this.button1.TabIndex = 76;
            this.button1.Text = "Создать подчиненную работу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idEntpr
            // 
            this.idEntpr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idEntpr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idEntpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idEntpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idEntpr.FormattingEnabled = true;
            this.idEntpr.Location = new System.Drawing.Point(83, 72);
            this.idEntpr.Name = "idEntpr";
            this.idEntpr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idEntpr.Size = new System.Drawing.Size(356, 21);
            this.idEntpr.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Исполнитель";
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(3, 102);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(620, 344);
            this.Dgv1.TabIndex = 74;
            this.Dgv1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Dgv1_UserDeletingRow);
            this.Dgv1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Dgv1_CellBeginEdit);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            // 
            // frmLinkWRK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idEntpr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idWRK);
            this.Name = "frmLinkWRK";
            this.Text = "Связь работ с подчиненными";
            this.Load += new System.EventHandler(this.frmLinkWRK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox idWRK;
        private System.Windows.Forms.Label label1;
        private DGVt Dgv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ComboBox idEntpr;
        private System.Windows.Forms.Label label3;
    }
}