namespace SMRC.Forms
{
    partial class frmSogl
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
            this.KodUnic = new System.Windows.Forms.ComboBox();
            this.NomerKS3Sub = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idDog = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idIstFin = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lCount = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.DgvSoglF3 = new SMRC.DGVt(this.components);
            this.DgvSoglSumRazl = new SMRC.DGVt(this.components);
            this.DgvSoglSumRazlUchet = new SMRC.DGVt(this.components);
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglSumRazl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglSumRazlUchet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер сторонней КС3 ";
            // 
            // KodUnic
            // 
            this.KodUnic.FormattingEnabled = true;
            this.KodUnic.Location = new System.Drawing.Point(437, 6);
            this.KodUnic.Name = "KodUnic";
            this.KodUnic.Size = new System.Drawing.Size(139, 21);
            this.KodUnic.TabIndex = 44;
            this.KodUnic.SelectedValueChanged += new System.EventHandler(this.KodUnic_SelectedValueChanged);
            // 
            // NomerKS3Sub
            // 
            this.NomerKS3Sub.FormattingEnabled = true;
            this.NomerKS3Sub.Location = new System.Drawing.Point(147, 6);
            this.NomerKS3Sub.Name = "NomerKS3Sub";
            this.NomerKS3Sub.Size = new System.Drawing.Size(139, 21);
            this.NomerKS3Sub.TabIndex = 46;
            this.NomerKS3Sub.SelectedValueChanged += new System.EventHandler(this.NomerKS3Sub_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(302, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Код уникальный КС3 ";
            // 
            // idDog
            // 
            this.idDog.FormattingEnabled = true;
            this.idDog.Location = new System.Drawing.Point(147, 38);
            this.idDog.Name = "idDog";
            this.idDog.Size = new System.Drawing.Size(139, 21);
            this.idDog.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Договор";
            // 
            // idIstFin
            // 
            this.idIstFin.FormattingEnabled = true;
            this.idIstFin.Location = new System.Drawing.Point(437, 35);
            this.idIstFin.Name = "idIstFin";
            this.idIstFin.Size = new System.Drawing.Size(139, 21);
            this.idIstFin.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(302, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Ист.фин.";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(828, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Нет соответствий.";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvSoglSumRazl);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvSoglSumRazlUchet);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(822, 479);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Нет соответствия в согласованных актах";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Нет соответствия в КСУП";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TextBox1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.lCount);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.btnCreate);
            this.tabPage2.Controls.Add(this.DgvSoglF3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Найденные соответствия.";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(456, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(297, 27);
            this.btnCreate.TabIndex = 54;
            this.btnCreate.Text = "Создать новую КС3 и добавить отсутствующие акты";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(111, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(339, 27);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Добавить/изменить соответствующие акты в выбранную КС3";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(9, 17);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(40, 13);
            this.lCount.TabIndex = 56;
            this.lCount.Text = "Всего:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-1, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 517);
            this.tabControl1.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Image = global::SMRC.Properties.Resources.REFRESH;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(646, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 27);
            this.button1.TabIndex = 53;
            this.button1.Text = "Обновить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DgvSoglF3
            // 
            this.DgvSoglF3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSoglF3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSoglF3.Location = new System.Drawing.Point(3, 51);
            this.DgvSoglF3.Name = "DgvSoglF3";
            this.DgvSoglF3.Size = new System.Drawing.Size(897, 437);
            this.DgvSoglF3.TabIndex = 53;
            this.DgvSoglF3.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvSoglF3_RowPrePaint);
            // 
            // DgvSoglSumRazl
            // 
            this.DgvSoglSumRazl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSoglSumRazl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSoglSumRazl.Location = new System.Drawing.Point(0, 27);
            this.DgvSoglSumRazl.Name = "DgvSoglSumRazl";
            this.DgvSoglSumRazl.Size = new System.Drawing.Size(369, 452);
            this.DgvSoglSumRazl.TabIndex = 47;
            // 
            // DgvSoglSumRazlUchet
            // 
            this.DgvSoglSumRazlUchet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvSoglSumRazlUchet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSoglSumRazlUchet.Location = new System.Drawing.Point(0, 27);
            this.DgvSoglSumRazlUchet.Name = "DgvSoglSumRazlUchet";
            this.DgvSoglSumRazlUchet.Size = new System.Drawing.Size(449, 452);
            this.DgvSoglSumRazlUchet.TabIndex = 48;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(779, 3);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(112, 23);
            this.TextBox1.TabIndex = 58;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 22);
            this.button2.TabIndex = 57;
            this.button2.Text = "Найти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSogl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idIstFin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idDog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.NomerKS3Sub);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KodUnic);
            this.Controls.Add(this.label1);
            this.Name = "frmSogl";
            this.Text = "Данные согласования актов";
            this.Load += new System.EventHandler(this.frmSogl_Load);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglSumRazl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSoglSumRazlUchet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox KodUnic;
        private System.Windows.Forms.ComboBox NomerKS3Sub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox idDog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox idIstFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DGVt DgvSoglSumRazl;
        private System.Windows.Forms.Label label3;
        private DGVt DgvSoglSumRazlUchet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCreate;
        private DGVt DgvSoglF3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button button2;
    }
}