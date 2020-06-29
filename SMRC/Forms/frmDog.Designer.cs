namespace SMRC.Forms
{
    partial class frmDog
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
            this.butActs = new System.Windows.Forms.Button();
            this.butF3 = new System.Windows.Forms.Button();
            this.butex = new System.Windows.Forms.Button();
            this.Dgv1 = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // butActs
            // 
            this.butActs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butActs.Location = new System.Drawing.Point(472, 12);
            this.butActs.Name = "butActs";
            this.butActs.Size = new System.Drawing.Size(105, 25);
            this.butActs.TabIndex = 1;
            this.butActs.Text = "Работа с актами";
            this.butActs.UseVisualStyleBackColor = true;
            this.butActs.Click += new System.EventHandler(this.butActs_Click);
            // 
            // butF3
            // 
            this.butF3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butF3.Location = new System.Drawing.Point(472, 43);
            this.butF3.Name = "butF3";
            this.butF3.Size = new System.Drawing.Size(105, 25);
            this.butF3.TabIndex = 2;
            this.butF3.Text = "Работа с Ф.№3";
            this.butF3.UseVisualStyleBackColor = true;
            this.butF3.Click += new System.EventHandler(this.butF3_Click);
            // 
            // butex
            // 
            this.butex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butex.Location = new System.Drawing.Point(472, 74);
            this.butex.Name = "butex";
            this.butex.Size = new System.Drawing.Size(105, 25);
            this.butex.TabIndex = 3;
            this.butex.Text = "Выход";
            this.butex.UseVisualStyleBackColor = true;
            this.butex.Click += new System.EventHandler(this.butex_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.AllowUserToOrderColumns = true;
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(1, -3);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(465, 284);
            this.Dgv1.TabIndex = 0;
            // 
            // frmDog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 280);
            this.Controls.Add(this.butex);
            this.Controls.Add(this.butF3);
            this.Controls.Add(this.butActs);
            this.Controls.Add(this.Dgv1);
            this.Name = "frmDog";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Договоры";
            this.Load += new System.EventHandler(this.frmDog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DGVt Dgv1;
        private System.Windows.Forms.Button butActs;
        private System.Windows.Forms.Button butF3;
        private System.Windows.Forms.Button butex;
    }
}