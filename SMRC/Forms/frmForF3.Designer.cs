namespace SMRC.Forms
{
    partial class frmForF3
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
            this.IdIstFin = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bF3 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.NMrab = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.IdZak = new System.Windows.Forms.ComboBox();
            this.IdDog = new System.Windows.Forms.ComboBox();
            this.IdIsp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tKodUnic = new System.Windows.Forms.TextBox();
            this.tSum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.rb1 = new System.Windows.Forms.GroupBox();
            this.rbSub = new System.Windows.Forms.RadioButton();
            this.rbZak = new System.Windows.Forms.RadioButton();
            this.ChDr = new System.Windows.Forms.CheckBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.dgVt1 = new SMRC.DGVt(this.components);
            this.DgvActs = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.rb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).BeginInit();
            this.SuspendLayout();
            // 
            // IdIstFin
            // 
            this.IdIstFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IdIstFin.BackColor = System.Drawing.Color.Snow;
            this.IdIstFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdIstFin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdIstFin.FormattingEnabled = true;
            this.IdIstFin.Location = new System.Drawing.Point(409, 25);
            this.IdIstFin.Name = "IdIstFin";
            this.IdIstFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdIstFin.Size = new System.Drawing.Size(219, 21);
            this.IdIstFin.TabIndex = 30;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 112);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgVt1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblSum);
            this.splitContainer1.Panel2.Controls.Add(this.button7);
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.DgvActs);
            this.splitContainer1.Size = new System.Drawing.Size(760, 342);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 32;
            // 
            // button7
            // 
            this.button7.Image = global::SMRC.Properties.Resources.ARW08LT;
            this.button7.Location = new System.Drawing.Point(3, 28);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(27, 23);
            this.button7.TabIndex = 33;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Image = global::SMRC.Properties.Resources.ARW08RT;
            this.button6.Location = new System.Drawing.Point(3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(27, 23);
            this.button6.TabIndex = 32;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(633, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Реестр";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bF3
            // 
            this.bF3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bF3.Location = new System.Drawing.Point(633, 23);
            this.bF3.Name = "bF3";
            this.bF3.Size = new System.Drawing.Size(128, 23);
            this.bF3.TabIndex = 34;
            this.bF3.Text = "Создать Ф3";
            this.bF3.UseVisualStyleBackColor = true;
            this.bF3.Click += new System.EventHandler(this.bF3_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(633, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "Работа с Ф.№3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(633, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "Выделить все";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // NMrab
            // 
            this.NMrab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NMrab.Location = new System.Drawing.Point(334, 86);
            this.NMrab.Name = "NMrab";
            this.NMrab.Size = new System.Drawing.Size(427, 20);
            this.NMrab.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Наименование работ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Ист.фин.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(-2, 55);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 50;
            this.Label5.Text = "Договор";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(-2, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 49;
            this.Label3.Text = "Заказчик";
            // 
            // IdZak
            // 
            this.IdZak.BackColor = System.Drawing.Color.Snow;
            this.IdZak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdZak.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdZak.FormattingEnabled = true;
            this.IdZak.Location = new System.Drawing.Point(79, 4);
            this.IdZak.Name = "IdZak";
            this.IdZak.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdZak.Size = new System.Drawing.Size(217, 21);
            this.IdZak.TabIndex = 48;
            this.IdZak.SelectedIndexChanged += new System.EventHandler(this.idZak_SelectedIndexChanged);
            // 
            // IdDog
            // 
            this.IdDog.BackColor = System.Drawing.Color.Snow;
            this.IdDog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdDog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdDog.FormattingEnabled = true;
            this.IdDog.Location = new System.Drawing.Point(79, 50);
            this.IdDog.Name = "IdDog";
            this.IdDog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdDog.Size = new System.Drawing.Size(217, 21);
            this.IdDog.TabIndex = 51;
            // 
            // IdIsp
            // 
            this.IdIsp.BackColor = System.Drawing.Color.Snow;
            this.IdIsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdIsp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdIsp.FormattingEnabled = true;
            this.IdIsp.Location = new System.Drawing.Point(79, 27);
            this.IdIsp.Name = "IdIsp";
            this.IdIsp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdIsp.Size = new System.Drawing.Size(217, 21);
            this.IdIsp.TabIndex = 53;
            this.IdIsp.SelectedIndexChanged += new System.EventHandler(this.IdIsp_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Исполнитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Поиск по параметрам";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "КодУник";
            // 
            // tKodUnic
            // 
            this.tKodUnic.Location = new System.Drawing.Point(47, 89);
            this.tKodUnic.Name = "tKodUnic";
            this.tKodUnic.Size = new System.Drawing.Size(100, 20);
            this.tKodUnic.TabIndex = 56;
            // 
            // tSum
            // 
            this.tSum.Location = new System.Drawing.Point(191, 89);
            this.tSum.Name = "tSum";
            this.tSum.Size = new System.Drawing.Size(82, 20);
            this.tSum.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Сумма";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(275, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 59;
            this.button5.Text = "Найти";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // rb1
            // 
            this.rb1.Controls.Add(this.rbSub);
            this.rb1.Controls.Add(this.rbZak);
            this.rb1.Location = new System.Drawing.Point(302, 1);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(98, 57);
            this.rb1.TabIndex = 60;
            this.rb1.TabStop = false;
            // 
            // rbSub
            // 
            this.rbSub.AutoSize = true;
            this.rbSub.Location = new System.Drawing.Point(6, 32);
            this.rbSub.Name = "rbSub";
            this.rbSub.Size = new System.Drawing.Size(78, 17);
            this.rbSub.TabIndex = 1;
            this.rbSub.Text = "субподряд";
            this.rbSub.UseVisualStyleBackColor = true;
            this.rbSub.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbZak
            // 
            this.rbZak.AutoSize = true;
            this.rbZak.Checked = true;
            this.rbZak.Location = new System.Drawing.Point(6, 13);
            this.rbZak.Name = "rbZak";
            this.rbZak.Size = new System.Drawing.Size(86, 17);
            this.rbZak.TabIndex = 0;
            this.rbZak.TabStop = true;
            this.rbZak.Text = "к заказчику";
            this.rbZak.UseVisualStyleBackColor = true;
            this.rbZak.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ChDr
            // 
            this.ChDr.AutoSize = true;
            this.ChDr.Location = new System.Drawing.Point(302, 66);
            this.ChDr.Name = "ChDr";
            this.ChDr.Size = new System.Drawing.Size(106, 17);
            this.ChDr.TabIndex = 61;
            this.ChDr.Text = "др.предприятия";
            this.ChDr.UseVisualStyleBackColor = true;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(31, 4);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(0, 13);
            this.lblSum.TabIndex = 34;
            // 
            // dgVt1
            // 
            this.dgVt1.AllowUserToAddRows = false;
            this.dgVt1.AllowUserToDeleteRows = false;
            this.dgVt1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgVt1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVt1.Location = new System.Drawing.Point(0, 0);
            this.dgVt1.Name = "dgVt1";
            this.dgVt1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVt1.Size = new System.Drawing.Size(373, 342);
            this.dgVt1.TabIndex = 31;
            // 
            // DgvActs
            // 
            this.DgvActs.AllowUserToAddRows = false;
            this.DgvActs.AllowUserToDeleteRows = false;
            this.DgvActs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvActs.BackgroundColor = System.Drawing.SystemColors.Info;
            this.DgvActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActs.Location = new System.Drawing.Point(31, 21);
            this.DgvActs.Name = "DgvActs";
            this.DgvActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvActs.Size = new System.Drawing.Size(349, 321);
            this.DgvActs.TabIndex = 6;
            // 
            // frmForF3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 458);
            this.Controls.Add(this.ChDr);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tSum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tKodUnic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IdIsp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IdDog);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.IdZak);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NMrab);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.bF3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.IdIstFin);
            this.Name = "frmForF3";
            this.Text = "Создание формы3";
            this.Load += new System.EventHandler(this.frmForF3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.rb1.ResumeLayout(false);
            this.rb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DGVt DgvActs;
        public DGVt dgVt1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox NMrab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox IdDog;
        internal System.Windows.Forms.ComboBox IdIsp;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tKodUnic;
        private System.Windows.Forms.TextBox tSum;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox rb1;
        private System.Windows.Forms.CheckBox ChDr;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.RadioButton rbSub;
        public System.Windows.Forms.RadioButton rbZak;
        internal System.Windows.Forms.ComboBox IdZak;
        internal System.Windows.Forms.ComboBox IdIstFin;
        public System.Windows.Forms.Button bF3;
        private System.Windows.Forms.Label lblSum;
    }
}