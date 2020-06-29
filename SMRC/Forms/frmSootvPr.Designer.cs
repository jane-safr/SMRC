namespace SMRC.Forms
{
    partial class frmSootvPr
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
            this.label15 = new System.Windows.Forms.Label();
            this.idComplex1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idOsr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idCat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idCatValue = new System.Windows.Forms.ComboBox();
            this.idProj = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lProjSMR = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DgvProjSMR = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjSMR)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(9, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 14);
            this.label15.TabIndex = 39;
            this.label15.Text = "Выберите Инв.проект";
            // 
            // idComplex1
            // 
            this.idComplex1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idComplex1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idComplex1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idComplex1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idComplex1.FormattingEnabled = true;
            this.idComplex1.Location = new System.Drawing.Point(12, 33);
            this.idComplex1.Name = "idComplex1";
            this.idComplex1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idComplex1.Size = new System.Drawing.Size(478, 21);
            this.idComplex1.TabIndex = 38;
            this.idComplex1.SelectedIndexChanged += new System.EventHandler(this.idComplex1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 41;
            this.label4.Text = "Выберите ОСР";
            // 
            // idOsr
            // 
            this.idOsr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idOsr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idOsr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idOsr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idOsr.FormattingEnabled = true;
            this.idOsr.Location = new System.Drawing.Point(12, 89);
            this.idOsr.Name = "idOsr";
            this.idOsr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idOsr.Size = new System.Drawing.Size(557, 21);
            this.idOsr.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 42;
            this.label1.Text = "Primavera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "Выберите код проекта";
            // 
            // idCat
            // 
            this.idCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idCat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idCat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idCat.FormattingEnabled = true;
            this.idCat.Location = new System.Drawing.Point(12, 172);
            this.idCat.Name = "idCat";
            this.idCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idCat.Size = new System.Drawing.Size(557, 21);
            this.idCat.TabIndex = 43;
            this.idCat.SelectedIndexChanged += new System.EventHandler(this.idCat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "Значение кода проекта";
            // 
            // idCatValue
            // 
            this.idCatValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idCatValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idCatValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idCatValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idCatValue.FormattingEnabled = true;
            this.idCatValue.Location = new System.Drawing.Point(12, 217);
            this.idCatValue.Name = "idCatValue";
            this.idCatValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idCatValue.Size = new System.Drawing.Size(557, 21);
            this.idCatValue.TabIndex = 45;
            this.idCatValue.SelectedValueChanged += new System.EventHandler(this.idCatValue_SelectedValueChanged);
            // 
            // idProj
            // 
            this.idProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idProj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idProj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idProj.FormattingEnabled = true;
            this.idProj.Location = new System.Drawing.Point(12, 268);
            this.idProj.Name = "idProj";
            this.idProj.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idProj.Size = new System.Drawing.Size(557, 21);
            this.idProj.TabIndex = 47;
            this.idProj.SelectedValueChanged += new System.EventHandler(this.idProj_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 48;
            this.label5.Text = "Проект Primavera";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(496, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 52);
            this.button1.TabIndex = 50;
            this.button1.Text = "Показать проекты из ЦА";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lProjSMR
            // 
            this.lProjSMR.AutoSize = true;
            this.lProjSMR.Font = new System.Drawing.Font("Tahoma", 10.90909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lProjSMR.Location = new System.Drawing.Point(12, 294);
            this.lProjSMR.Name = "lProjSMR";
            this.lProjSMR.Size = new System.Drawing.Size(51, 18);
            this.lProjSMR.TabIndex = 51;
            this.lProjSMR.Text = "Всего:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(496, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 67);
            this.button2.TabIndex = 52;
            this.button2.Text = "Загрузить в коды работы Primavera ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(496, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 79);
            this.button3.TabIndex = 53;
            this.button3.Text = "Обновить Инв. проекты и ОСР в Primavera";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DgvProjSMR
            // 
            this.DgvProjSMR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvProjSMR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProjSMR.Location = new System.Drawing.Point(15, 315);
            this.DgvProjSMR.Name = "DgvProjSMR";
            this.DgvProjSMR.Size = new System.Drawing.Size(475, 154);
            this.DgvProjSMR.TabIndex = 49;
            // 
            // frmSootvPr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 472);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lProjSMR);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DgvProjSMR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.idProj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idCatValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idCat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idOsr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.idComplex1);
            this.Name = "frmSootvPr";
            this.Text = "Соответствие с Primavera";
            this.Load += new System.EventHandler(this.frmSootvPV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProjSMR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox idComplex1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox idOsr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox idCat;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox idCatValue;
        internal System.Windows.Forms.ComboBox idProj;
        private System.Windows.Forms.Label label5;
        private DGVt DgvProjSMR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lProjSMR;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}