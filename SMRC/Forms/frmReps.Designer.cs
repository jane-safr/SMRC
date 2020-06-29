namespace SMRC.Forms
{
    partial class frmReps
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
            this.ucFilter1 = new UCFilter.UCFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DC1 = new System.Windows.Forms.ComboBox();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucFilter1
            // 
            this.ucFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(858, 136);
            this.ucFilter1.TabIndex = 2;
            this.ucFilter1.Load += new System.EventHandler(this.ucFilter1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.DC1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 38);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // DC1
            // 
            this.DC1.FormattingEnabled = true;
            this.DC1.Location = new System.Drawing.Point(6, 12);
            this.DC1.Name = "DC1";
            this.DC1.Size = new System.Drawing.Size(156, 21);
            this.DC1.TabIndex = 0;
            this.DC1.SelectedIndexChanged += new System.EventHandler(this.DC1_SelectedIndexChanged);
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 174);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(858, 331);
            this.ReportViewer1.TabIndex = 4;
            this.ReportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.ReportViewer1_ReportExport);
            this.ReportViewer1.Load += new System.EventHandler(this.ReportViewer1_Load);
            // 
            // frmReps
            // 
            this.ClientSize = new System.Drawing.Size(858, 505);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucFilter1);
            this.Name = "frmReps";
            this.Load += new System.EventHandler(this.frmReps_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        //private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DC1;
        private UCFilter.UCFilter ucFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        //private System.Windows.Forms.ComboBox ComboBox1;
        //private UCFilter.UCFilter ucFilter2;
        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}