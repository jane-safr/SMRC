namespace SMRC.Forms
{
    partial class frmTemPlanVibor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Dgv2 = new SMRC.DGVt(this.components);
            this.Dgv1 = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(675, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список смет, которые включены в график тематического планирования за выбранный пе" +
                "риод";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.727273F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "Виды работ по смете";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Добавить сметы в тематический план";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Добавить ОСР в календарный план";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dgv2
            // 
            this.Dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv2.Location = new System.Drawing.Point(2, 332);
            this.Dgv2.Name = "Dgv2";
            this.Dgv2.Size = new System.Drawing.Size(699, 126);
            this.Dgv2.TabIndex = 31;
            this.Dgv2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(2, 44);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(699, 258);
            this.Dgv1.TabIndex = 29;
            this.Dgv1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_RowEnter);
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // frmTemPlanVibor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 460);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dgv2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.label1);
            this.Name = "frmTemPlanVibor";
            this.Text = "Выбор смет";
            this.Load += new System.EventHandler(this.frmTemPlanVibor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DGVt Dgv1;
        private System.Windows.Forms.Label label2;
        private DGVt Dgv2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}