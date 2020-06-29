namespace SMRC.Forms
{
    partial class frmTask
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
            this.task_code1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.user_field_201 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.user_field_7966 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.user_field_6678 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Dgv3 = new SMRC.DGVt(this.components);
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.Dgv2 = new SMRC.DGVt(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // task_code1
            // 
            this.task_code1.Location = new System.Drawing.Point(62, 8);
            this.task_code1.Name = "task_code1";
            this.task_code1.Size = new System.Drawing.Size(296, 20);
            this.task_code1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Работа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Сметы из ЦА";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Проекты из ЦА";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Сметы";
            // 
            // user_field_201
            // 
            this.user_field_201.Location = new System.Drawing.Point(4, 50);
            this.user_field_201.Multiline = true;
            this.user_field_201.Name = "user_field_201";
            this.user_field_201.Size = new System.Drawing.Size(172, 104);
            this.user_field_201.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Проекты";
            // 
            // user_field_7966
            // 
            this.user_field_7966.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.user_field_7966.Location = new System.Drawing.Point(361, 50);
            this.user_field_7966.Multiline = true;
            this.user_field_7966.Name = "user_field_7966";
            this.user_field_7966.Size = new System.Drawing.Size(331, 104);
            this.user_field_7966.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "№ действующей сметы ";
            // 
            // user_field_6678
            // 
            this.user_field_6678.Location = new System.Drawing.Point(178, 50);
            this.user_field_6678.Multiline = true;
            this.user_field_6678.Name = "user_field_6678";
            this.user_field_6678.Size = new System.Drawing.Size(180, 104);
            this.user_field_6678.TabIndex = 63;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 160);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.Dgv3);
            this.splitContainer1.Panel1.Controls.Add(this.Dgv1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Dgv2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(688, 440);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 65;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 61;
            this.button1.Text = "Проекты с pdf";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Файлы документов";
            // 
            // Dgv3
            // 
            this.Dgv3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv3.Location = new System.Drawing.Point(357, 23);
            this.Dgv3.Name = "Dgv3";
            this.Dgv3.Size = new System.Drawing.Size(328, 193);
            this.Dgv3.TabIndex = 59;
            this.Dgv3.DoubleClick += new System.EventHandler(this.Dgv3_DoubleClick);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(3, 23);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(348, 193);
            this.Dgv1.TabIndex = 55;
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            // 
            // Dgv2
            // 
            this.Dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv2.Location = new System.Drawing.Point(3, 21);
            this.Dgv2.Name = "Dgv2";
            this.Dgv2.Size = new System.Drawing.Size(682, 193);
            this.Dgv2.TabIndex = 56;
            this.Dgv2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 603);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.user_field_6678);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.user_field_7966);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user_field_201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.task_code1);
            this.Name = "frmTask";
            this.Text = "Форма работы";
            this.Load += new System.EventHandler(this.frmTask_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox task_code1;
        private System.Windows.Forms.Label label1;
        private DGVt Dgv1;
        private DGVt Dgv2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox user_field_201;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox user_field_7966;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox user_field_6678;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private DGVt Dgv3;
        private System.Windows.Forms.Button button1;
    }
}