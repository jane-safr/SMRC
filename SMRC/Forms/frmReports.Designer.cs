namespace SMRC.Forms
{
    partial class frmReports
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
            this.button2 = new System.Windows.Forms.Button();
            this.NMGrafik = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(3, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "Проекты с файлами pdf";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NMGrafik
            // 
            this.NMGrafik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NMGrafik.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NMGrafik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NMGrafik.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NMGrafik.FormattingEnabled = true;
            this.NMGrafik.Location = new System.Drawing.Point(3, 14);
            this.NMGrafik.Name = "NMGrafik";
            this.NMGrafik.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NMGrafik.Size = new System.Drawing.Size(240, 21);
            this.NMGrafik.TabIndex = 57;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(3, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 24);
            this.button3.TabIndex = 58;
            this.button3.Text = "Тематическое планирование";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 272);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.NMGrafik);
            this.Controls.Add(this.button2);
            this.Name = "frmReports";
            this.Text = "Отчеты";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.ComboBox NMGrafik;
        private System.Windows.Forms.Button button3;
    }
}