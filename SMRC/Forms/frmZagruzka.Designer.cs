namespace SMRC.Forms
{
    partial class frmZagruzka
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
            this.flName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.zagName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColNM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kol = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.row = new System.Windows.Forms.TextBox();
            this.idComplex = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flName
            // 
            this.flName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flName.Location = new System.Drawing.Point(154, 27);
            this.flName.Name = "flName";
            this.flName.Size = new System.Drawing.Size(363, 20);
            this.flName.TabIndex = 0;
            this.flName.TextChanged += new System.EventHandler(this.flName_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zagName
            // 
            this.zagName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zagName.Location = new System.Drawing.Point(154, 58);
            this.zagName.Name = "zagName";
            this.zagName.Size = new System.Drawing.Size(363, 20);
            this.zagName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Заголовок файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Колонки";
            // 
            // ColNM
            // 
            this.ColNM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColNM.Enabled = false;
            this.ColNM.Location = new System.Drawing.Point(3, 188);
            this.ColNM.Multiline = true;
            this.ColNM.Name = "ColNM";
            this.ColNM.Size = new System.Drawing.Size(514, 105);
            this.ColNM.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество колонок";
            // 
            // kol
            // 
            this.kol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kol.Location = new System.Drawing.Point(154, 92);
            this.kol.Name = "kol";
            this.kol.Size = new System.Drawing.Size(363, 20);
            this.kol.TabIndex = 6;
            this.kol.Text = "10";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 22);
            this.button2.TabIndex = 8;
            this.button2.Text = "Названия колонок";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(361, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 22);
            this.button3.TabIndex = 9;
            this.button3.Text = "Загрузить!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество строк";
            // 
            // row
            // 
            this.row.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.row.Location = new System.Drawing.Point(154, 118);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(363, 20);
            this.row.TabIndex = 10;
            this.row.Text = "10";
            // 
            // idComplex
            // 
            this.idComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idComplex.BackColor = System.Drawing.Color.WhiteSmoke;
            this.idComplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idComplex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.idComplex.FormattingEnabled = true;
            this.idComplex.Location = new System.Drawing.Point(12, 2);
            this.idComplex.Name = "idComplex";
            this.idComplex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idComplex.Size = new System.Drawing.Size(505, 21);
            this.idComplex.TabIndex = 37;
            // 
            // frmZagruzka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 300);
            this.Controls.Add(this.idComplex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.row);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColNM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zagName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flName);
            this.Name = "frmZagruzka";
            this.Text = "Загрузка данных";
            this.Load += new System.EventHandler(this.frmZagruzka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox flName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox zagName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ColNM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kol;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox row;
        internal System.Windows.Forms.ComboBox idComplex;
    }
}