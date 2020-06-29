namespace SMRC.Forms
{
    partial class frmVibList
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
            this.lbxShNMEntpr = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lbxType = new System.Windows.Forms.ListBox();
            this.chType = new System.Windows.Forms.CheckBox();
            this.chShNMEntpr = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbxShNMEntpr
            // 
            this.lbxShNMEntpr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxShNMEntpr.BackColor = System.Drawing.SystemColors.Window;
            this.lbxShNMEntpr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbxShNMEntpr.FormattingEnabled = true;
            this.lbxShNMEntpr.ItemHeight = 20;
            this.lbxShNMEntpr.Location = new System.Drawing.Point(2, 97);
            this.lbxShNMEntpr.Name = "lbxShNMEntpr";
            this.lbxShNMEntpr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxShNMEntpr.Size = new System.Drawing.Size(326, 493);
            this.lbxShNMEntpr.Sorted = true;
            this.lbxShNMEntpr.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Данные по НЗП для диаграммы формируются каждую ночь.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "Отобразить график по НЗП за";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tYear
            // 
            this.tYear.Location = new System.Drawing.Point(199, 40);
            this.tYear.Name = "tYear";
            this.tYear.Size = new System.Drawing.Size(82, 20);
            this.tYear.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "год";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 25);
            this.button2.TabIndex = 19;
            this.button2.Text = "Разница в снятии и закрытии";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbxType
            // 
            this.lbxType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxType.BackColor = System.Drawing.SystemColors.Window;
            this.lbxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbxType.FormattingEnabled = true;
            this.lbxType.ItemHeight = 20;
            this.lbxType.Location = new System.Drawing.Point(330, 97);
            this.lbxType.Name = "lbxType";
            this.lbxType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxType.Size = new System.Drawing.Size(404, 492);
            this.lbxType.Sorted = true;
            this.lbxType.TabIndex = 20;
            // 
            // chType
            // 
            this.chType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chType.AutoSize = true;
            this.chType.Location = new System.Drawing.Point(719, 77);
            this.chType.Name = "chType";
            this.chType.Size = new System.Drawing.Size(15, 14);
            this.chType.TabIndex = 21;
            this.chType.UseVisualStyleBackColor = true;
            this.chType.CheckedChanged += new System.EventHandler(this.chType_CheckedChanged);
            // 
            // chShNMEntpr
            // 
            this.chShNMEntpr.AutoSize = true;
            this.chShNMEntpr.Location = new System.Drawing.Point(313, 77);
            this.chShNMEntpr.Name = "chShNMEntpr";
            this.chShNMEntpr.Size = new System.Drawing.Size(15, 14);
            this.chShNMEntpr.TabIndex = 22;
            this.chShNMEntpr.UseVisualStyleBackColor = true;
            this.chShNMEntpr.CheckedChanged += new System.EventHandler(this.chShNMEntpr_CheckedChanged);
            // 
            // frmVibList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 596);
            this.Controls.Add(this.chShNMEntpr);
            this.Controls.Add(this.chType);
            this.Controls.Add(this.lbxType);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tYear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxShNMEntpr);
            this.Name = "frmVibList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма выбора";
            this.Load += new System.EventHandler(this.frmVibList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxShNMEntpr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lbxType;
        private System.Windows.Forms.CheckBox chType;
        private System.Windows.Forms.CheckBox chShNMEntpr;
    }
}