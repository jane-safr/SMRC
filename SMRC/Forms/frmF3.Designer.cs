namespace SMRC.Forms
{
    partial class frmF3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmF3));
            this.idIstFin = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.IdF3Predjav = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.FromIsp = new Edneeis.Controls.MultiColumnComboBox();
            this.FromZak = new Edneeis.Controls.MultiColumnComboBox();
            this.lSum = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.NMrab = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chNotBaseOsn = new System.Windows.Forms.CheckBox();
            this.chDrOb = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RegNomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.DgvActs = new SMRC.DGVt(this.components);
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // idIstFin
            // 
            this.idIstFin.BackColor = System.Drawing.Color.Snow;
            this.idIstFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idIstFin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idIstFin.FormattingEnabled = true;
            this.idIstFin.Location = new System.Drawing.Point(419, 3);
            this.idIstFin.Name = "idIstFin";
            this.idIstFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idIstFin.Size = new System.Drawing.Size(141, 21);
            this.idIstFin.TabIndex = 30;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(95, 290);
            this.listBox1.TabIndex = 31;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // IdF3Predjav
            // 
            this.IdF3Predjav.BackColor = System.Drawing.Color.Snow;
            this.IdF3Predjav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdF3Predjav.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IdF3Predjav.FormattingEnabled = true;
            this.IdF3Predjav.Location = new System.Drawing.Point(419, 26);
            this.IdF3Predjav.Name = "IdF3Predjav";
            this.IdF3Predjav.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdF3Predjav.Size = new System.Drawing.Size(141, 21);
            this.IdF3Predjav.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 34);
            this.label1.TabIndex = 33;
            this.label1.Text = "Номера справок";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.FromIsp);
            this.panel1.Controls.Add(this.FromZak);
            this.panel1.Controls.Add(this.lSum);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.NMrab);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RegNomer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DgvActs);
            this.panel1.Controls.Add(this.IdF3Predjav);
            this.panel1.Controls.Add(this.idIstFin);
            this.panel1.Controls.Add(this.Dgv1);
            this.panel1.Location = new System.Drawing.Point(106, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 377);
            this.panel1.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(438, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 21);
            this.button2.TabIndex = 52;
            this.button2.Text = "Удалить акт из КС-3";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FromIsp
            // 
            this.FromIsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FromIsp.ColumnHeaderBorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.FromIsp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FromIsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FromIsp.FormattingEnabled = true;
            this.FromIsp.ImageIndexMember = "";
            this.FromIsp.ImageList = null;
            this.FromIsp.Location = new System.Drawing.Point(163, 270);
            this.FromIsp.Name = "FromIsp";
            this.FromIsp.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.FromIsp.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.FromIsp.ShowColumnHeader = false;
            this.FromIsp.ShowColumns = false;
            this.FromIsp.ShowImageInText = false;
            this.FromIsp.Size = new System.Drawing.Size(161, 21);
            this.FromIsp.TabIndex = 51;
            // 
            // FromZak
            // 
            this.FromZak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FromZak.ColumnHeaderBorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.FromZak.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FromZak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FromZak.FormattingEnabled = true;
            this.FromZak.ImageIndexMember = "";
            this.FromZak.ImageList = null;
            this.FromZak.Location = new System.Drawing.Point(3, 271);
            this.FromZak.Name = "FromZak";
            this.FromZak.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.FromZak.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.FromZak.ShowColumnHeader = false;
            this.FromZak.ShowColumns = false;
            this.FromZak.ShowImageInText = false;
            this.FromZak.Size = new System.Drawing.Size(152, 21);
            this.FromZak.TabIndex = 50;
            // 
            // lSum
            // 
            this.lSum.AutoSize = true;
            this.lSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSum.Location = new System.Drawing.Point(160, 12);
            this.lSum.Name = "lSum";
            this.lSum.Size = new System.Drawing.Size(11, 13);
            this.lSum.TabIndex = 49;
            this.lSum.Text = "-";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(330, 349);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 21);
            this.button8.TabIndex = 48;
            this.button8.Text = "Пересчитать";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.AutoSize = true;
            this.button7.Location = new System.Drawing.Point(438, 324);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 23);
            this.button7.TabIndex = 47;
            this.button7.Text = "Добавить акт в Ф3";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(438, 298);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 21);
            this.button6.TabIndex = 46;
            this.button6.Text = "Выделить все";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(331, 324);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 23);
            this.button5.TabIndex = 45;
            this.button5.Text = "Протокол индекса";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(330, 298);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 21);
            this.button4.TabIndex = 37;
            this.button4.Text = "Протокол";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // NMrab
            // 
            this.NMrab.Location = new System.Drawing.Point(1, 53);
            this.NMrab.Name = "NMrab";
            this.NMrab.Size = new System.Drawing.Size(561, 20);
            this.NMrab.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Наименование работ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chNotBaseOsn);
            this.panel2.Controls.Add(this.chDrOb);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(-2, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 77);
            this.panel2.TabIndex = 42;
            // 
            // chNotBaseOsn
            // 
            this.chNotBaseOsn.Location = new System.Drawing.Point(185, 44);
            this.chNotBaseOsn.Name = "chNotBaseOsn";
            this.chNotBaseOsn.Size = new System.Drawing.Size(124, 34);
            this.chNotBaseOsn.TabIndex = 37;
            this.chNotBaseOsn.Text = "Не брать базу из основного акта";
            this.chNotBaseOsn.UseVisualStyleBackColor = true;
            // 
            // chDrOb
            // 
            this.chDrOb.Location = new System.Drawing.Point(185, 3);
            this.chDrOb.Name = "chDrOb";
            this.chDrOb.Size = new System.Drawing.Size(136, 43);
            this.chDrOb.TabIndex = 36;
            this.chDrOb.Text = "Печатать суммы с нач. года по другим объектам";
            this.chDrOb.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 21);
            this.button3.TabIndex = 35;
            this.button3.Text = "Реестр";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(100, 4);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(79, 21);
            this.butDel.TabIndex = 1;
            this.butDel.Text = "Удалить";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Просмотр Ф3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "от исполнителя";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "от заказчика";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Рег. номер";
            // 
            // RegNomer
            // 
            this.RegNomer.Location = new System.Drawing.Point(76, 7);
            this.RegNomer.Name = "RegNomer";
            this.RegNomer.Size = new System.Drawing.Size(62, 20);
            this.RegNomer.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Отд. зак.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Ист. фин.";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(5, 346);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 34);
            this.button9.TabIndex = 49;
            this.button9.Text = "Перенести в другой период";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button10.Location = new System.Drawing.Point(597, 386);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(73, 23);
            this.button10.TabIndex = 51;
            this.button10.Text = "Закрыть";
            this.button10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.Image = ((System.Drawing.Image)(resources.GetObject("butSave.Image")));
            this.butSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butSave.Location = new System.Drawing.Point(508, 386);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(87, 23);
            this.butSave.TabIndex = 50;
            this.butSave.Text = "Сохранить";
            this.butSave.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // DgvActs
            // 
            this.DgvActs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvActs.BackgroundColor = System.Drawing.SystemColors.Info;
            this.DgvActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvActs.Location = new System.Drawing.Point(331, 74);
            this.DgvActs.Name = "DgvActs";
            this.DgvActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvActs.Size = new System.Drawing.Size(231, 217);
            this.DgvActs.TabIndex = 33;
            this.DgvActs.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActs_CellValidated);

            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(3, 74);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(322, 177);
            this.Dgv1.TabIndex = 7;
            // 
            // frmF3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 414);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "frmF3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа со справкой формы №3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmF3_FormClosing);
            this.Load += new System.EventHandler(this.frmF3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvActs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DGVt Dgv1;
        public System.Windows.Forms.ComboBox idIstFin;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ComboBox IdF3Predjav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RegNomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public DGVt DgvActs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox NMrab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        internal System.Windows.Forms.Button button10;
        internal System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label lSum;
        public System.Windows.Forms.CheckBox chDrOb;
        public Edneeis.Controls.MultiColumnComboBox FromZak;
        public Edneeis.Controls.MultiColumnComboBox FromIsp;
        public System.Windows.Forms.CheckBox chNotBaseOsn;
        private System.Windows.Forms.Button button2;
    }
}