namespace SMRC.Forms
{
    partial class frmDiagram
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPred = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Диаграмма по сводному отчету за 2017г";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPred);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 135);
            this.panel1.TabIndex = 2;
            // 
            // lbPred
            // 
            this.lbPred.FormattingEnabled = true;
            this.lbPred.Location = new System.Drawing.Point(221, 12);
            this.lbPred.Name = "lbPred";
            this.lbPred.Size = new System.Drawing.Size(151, 95);
            this.lbPred.TabIndex = 1;
            // 
            // frmDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 434);
            this.Controls.Add(this.panel1);
            this.Name = "frmDiagram";
            this.Text = "Диаграммы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDiagram_FormClosed);
            this.Load += new System.EventHandler(this.frmDiagram_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbPred;
    }
}