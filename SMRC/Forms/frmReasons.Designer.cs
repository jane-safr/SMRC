namespace SMRC.Forms
{
    partial class frmReasons
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
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.IdBlock = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.idStatus = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.idReason = new System.Windows.Forms.ComboBox();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBox1
            // 
            this.ListBox1.BackColor = System.Drawing.SystemColors.Window;
            this.ListBox1.ColumnWidth = 170;
            this.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 20;
            this.ListBox1.Location = new System.Drawing.Point(0, 59);
            this.ListBox1.MultiColumn = true;
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(572, 124);
            this.ListBox1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.IdBlock);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.idStatus);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TextBox2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.idReason);
            this.panel1.Controls.Add(this.ListBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 184);
            this.panel1.TabIndex = 15;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(694, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(113, 26);
            this.button7.TabIndex = 36;
            this.button7.Text = "Назначить блок";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // IdBlock
            // 
            this.IdBlock.BackColor = System.Drawing.Color.Snow;
            this.IdBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdBlock.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.IdBlock.FormattingEnabled = true;
            this.IdBlock.Location = new System.Drawing.Point(694, 32);
            this.IdBlock.Name = "IdBlock";
            this.IdBlock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IdBlock.Size = new System.Drawing.Size(113, 21);
            this.IdBlock.TabIndex = 35;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Выбрать все";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Image = global::SMRC.Properties.Resources.NOTE14;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(851, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 34);
            this.button6.TabIndex = 33;
            this.button6.Text = "Отчет по НЗП, ЛАЭС-2";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(492, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 26);
            this.button4.TabIndex = 32;
            this.button4.Text = "Назначить статус заказчика";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Image = global::SMRC.Properties.Resources.add_small;
            this.button5.Location = new System.Drawing.Point(664, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 23);
            this.button5.TabIndex = 31;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // idStatus
            // 
            this.idStatus.BackColor = System.Drawing.Color.Snow;
            this.idStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.idStatus.FormattingEnabled = true;
            this.idStatus.Location = new System.Drawing.Point(492, 32);
            this.idStatus.Name = "idStatus";
            this.idStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idStatus.Size = new System.Drawing.Size(166, 21);
            this.idStatus.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 26);
            this.button2.TabIndex = 29;
            this.button2.Text = "Назначить причину";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Всего:";
            // 
            // TextBox2
            // 
            this.TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox2.Location = new System.Drawing.Point(571, 59);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(533, 124);
            this.TextBox2.TabIndex = 27;
            this.TextBox2.Text = "Выбрать сметы";
            // 
            // button3
            // 
            this.button3.Image = global::SMRC.Properties.Resources.edit_clear;
            this.button3.Location = new System.Drawing.Point(233, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 38);
            this.button3.TabIndex = 26;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::SMRC.Properties.Resources.FILTER2;
            this.btnFilter.Location = new System.Drawing.Point(193, 18);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(34, 38);
            this.btnFilter.TabIndex = 24;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Image = global::SMRC.Properties.Resources.add_small;
            this.button1.Location = new System.Drawing.Point(448, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idReason
            // 
            this.idReason.BackColor = System.Drawing.Color.Snow;
            this.idReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idReason.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.idReason.FormattingEnabled = true;
            this.idReason.Location = new System.Drawing.Point(290, 32);
            this.idReason.Name = "idReason";
            this.idReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idReason.Size = new System.Drawing.Size(152, 21);
            this.idReason.TabIndex = 21;
            // 
            // Dgv1
            // 
            this.Dgv1.AllowUserToAddRows = false;
            this.Dgv1.AllowUserToDeleteRows = false;
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Dgv1.Location = new System.Drawing.Point(0, 184);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(1105, 344);
            this.Dgv1.TabIndex = 3;
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            // 
            // frmReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 528);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.panel1);
            this.Name = "frmReasons";
            this.Text = "Форма назначения причин НЗП на сметы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReasons_FormClosed);
            this.Load += new System.EventHandler(this.frmReasons_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DGVt Dgv1;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox idReason;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        internal System.Windows.Forms.ComboBox idStatus;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button7;
        internal System.Windows.Forms.ComboBox IdBlock;
    }
}