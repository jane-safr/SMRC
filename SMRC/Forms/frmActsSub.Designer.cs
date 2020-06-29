namespace SMRC.Forms
{
    partial class frmActsSub
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAllTime = new System.Windows.Forms.RadioButton();
            this.rbTekMes = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chDr = new System.Windows.Forms.CheckBox();
            this.DgvActs = new SMRC.DGVt(this.components);
            this.DgvObj = new SMRC.DGVt(this.components);
            this.DgvUsF2 = new SMRC.DGVt(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtVvodSum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idDog = new Edneeis.Controls.MultiColumnComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.idIstFin = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnF3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lblSelect = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvObj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsF2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAllTime);
            this.groupBox1.Controls.Add(this.rbTekMes);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 35);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbAllTime
            // 
            this.rbAllTime.AutoSize = true;
            this.rbAllTime.Location = new System.Drawing.Point(109, 13);
            this.rbAllTime.Name = "rbAllTime";
            this.rbAllTime.Size = new System.Drawing.Size(93, 17);
            this.rbAllTime.TabIndex = 1;
            this.rbAllTime.Text = "за все время";
            this.rbAllTime.UseVisualStyleBackColor = true;
            // 
            // rbTekMes
            // 
            this.rbTekMes.AutoSize = true;
            this.rbTekMes.Location = new System.Drawing.Point(12, 13);
            this.rbTekMes.Name = "rbTekMes";
            this.rbTekMes.Size = new System.Drawing.Size(80, 17);
            this.rbTekMes.TabIndex = 0;
            this.rbTekMes.Text = "тек. месяц";
            this.rbTekMes.UseVisualStyleBackColor = true;
            this.rbTekMes.CheckedChanged += new System.EventHandler(this.rbTekMes_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chDr
            // 
            this.chDr.AutoSize = true;
            this.chDr.Location = new System.Drawing.Point(227, 13);
            this.chDr.Name = "chDr";
            this.chDr.Size = new System.Drawing.Size(109, 17);
            this.chDr.TabIndex = 3;
            this.chDr.Text = "др. предприятия";
            this.chDr.UseVisualStyleBackColor = true;
            this.chDr.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DgvActs
            // 
            this.DgvActs.AllowUserToAddRows = false;
            this.DgvActs.AllowUserToOrderColumns = true;
            this.DgvActs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvActs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvActs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActs.Location = new System.Drawing.Point(1, 83);
            this.DgvActs.Name = "DgvActs";
            this.DgvActs.Size = new System.Drawing.Size(732, 299);
            this.DgvActs.TabIndex = 5;
            this.DgvActs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActs_CellEndEdit);
            this.DgvActs.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActs_CellValidated);
            this.DgvActs.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvActs_RowPrePaint);
            this.DgvActs.SelectionChanged += new System.EventHandler(this.DgvActs_SelectionChanged);
            // 
            // DgvObj
            // 
            this.DgvObj.AllowUserToAddRows = false;
            this.DgvObj.AllowUserToOrderColumns = true;
            this.DgvObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DgvObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvObj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvObj.Location = new System.Drawing.Point(1, 388);
            this.DgvObj.Name = "DgvObj";
            this.DgvObj.Size = new System.Drawing.Size(286, 67);
            this.DgvObj.TabIndex = 6;
            // 
            // DgvUsF2
            // 
            this.DgvUsF2.AllowUserToAddRows = false;
            this.DgvUsF2.AllowUserToOrderColumns = true;
            this.DgvUsF2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvUsF2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvUsF2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUsF2.Location = new System.Drawing.Point(293, 388);
            this.DgvUsF2.Name = "DgvUsF2";
            this.DgvUsF2.Size = new System.Drawing.Size(440, 67);
            this.DgvUsF2.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtVvodSum);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 64);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "100%";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtVvodSum
            // 
            this.txtVvodSum.Location = new System.Drawing.Point(56, 16);
            this.txtVvodSum.Name = "txtVvodSum";
            this.txtVvodSum.Size = new System.Drawing.Size(100, 20);
            this.txtVvodSum.TabIndex = 1;
            this.txtVvodSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVvodSum_KeyPress);
            this.txtVvodSum.Leave += new System.EventHandler(this.txtVvodSum_Leave);
            this.txtVvodSum.Validated += new System.EventHandler(this.txtVvodSum_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "сумма";
            // 
            // idDog
            // 
            this.idDog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.idDog.ColumnHeaderBorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.idDog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.idDog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idDog.FormattingEnabled = true;
            this.idDog.ImageIndexMember = "";
            this.idDog.ImageList = null;
            this.idDog.Location = new System.Drawing.Point(250, 469);
            this.idDog.Name = "idDog";
            this.idDog.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.idDog.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.idDog.ShowColumnHeader = false;
            this.idDog.ShowColumns = false;
            this.idDog.ShowImageInText = false;
            this.idDog.Size = new System.Drawing.Size(254, 21);
            this.idDog.TabIndex = 43;
            // 
            // Label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(178, 469);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 42;
            this.Label5.Text = "Договор";
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(178, 497);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(55, 13);
            this.Label8.TabIndex = 45;
            this.Label8.Text = "Ист. фин.";
            // 
            // idIstFin
            // 
            this.idIstFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.idIstFin.BackColor = System.Drawing.Color.Snow;
            this.idIstFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idIstFin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idIstFin.FormattingEnabled = true;
            this.idIstFin.Location = new System.Drawing.Point(250, 494);
            this.idIstFin.Name = "idIstFin";
            this.idIstFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idIstFin.Size = new System.Drawing.Size(254, 21);
            this.idIstFin.TabIndex = 44;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(510, 469);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "Выделить выбранное";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Image = global::SMRC.Properties.Resources.Delete;
            this.button4.Location = new System.Drawing.Point(647, 468);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 22);
            this.button4.TabIndex = 47;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Image = global::SMRC.Properties.Resources.exlel;
            this.button5.Location = new System.Drawing.Point(682, 467);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 22);
            this.button5.TabIndex = 48;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnF3
            // 
            this.btnF3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnF3.Location = new System.Drawing.Point(511, 497);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(130, 23);
            this.btnF3.TabIndex = 49;
            this.btnF3.Text = "Ф3!";
            this.btnF3.UseVisualStyleBackColor = true;
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(647, 498);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 23);
            this.button7.TabIndex = 50;
            this.button7.Text = "Закрыть";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(3, 64);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(35, 13);
            this.lblSelect.TabIndex = 51;
            this.lblSelect.Text = "label2";
            // 
            // frmActsSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 537);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnF3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.idIstFin);
            this.Controls.Add(this.idDog);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DgvUsF2);
            this.Controls.Add(this.DgvObj);
            this.Controls.Add(this.DgvActs);
            this.Controls.Add(this.chDr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmActsSub";
            this.Text = "Акты субподряд";
            this.Load += new System.EventHandler(this.frmActsSub_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvObj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsF2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAllTime;
        private System.Windows.Forms.RadioButton rbTekMes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chDr;
        public DGVt DgvActs;
        public DGVt DgvObj;
        public DGVt DgvUsF2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtVvodSum;
        private System.Windows.Forms.Label label1;
        private Edneeis.Controls.MultiColumnComboBox idDog;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ComboBox idIstFin;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnF3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lblSelect;
    }
}