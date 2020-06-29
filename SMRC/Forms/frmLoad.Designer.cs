namespace SMRC.Forms
{
    partial class frmLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoad));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cUper = new System.Windows.Forms.ComboBox();
            this.cUpred = new System.Windows.Forms.ComboBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.StatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cUper
            // 
            this.cUper.BackColor = System.Drawing.Color.Snow;
            this.cUper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cUper.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cUper.FormattingEnabled = true;
            this.cUper.Location = new System.Drawing.Point(164, 27);
            this.cUper.Name = "cUper";
            this.cUper.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cUper.Size = new System.Drawing.Size(118, 21);
            this.cUper.TabIndex = 20;
            this.cUper.SelectedIndexChanged += new System.EventHandler(this.cUpred_SelectedIndexChanged);
            // 
            // cUpred
            // 
            this.cUpred.BackColor = System.Drawing.Color.Snow;
            this.cUpred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cUpred.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cUpred.FormattingEnabled = true;
            this.cUpred.Location = new System.Drawing.Point(0, 27);
            this.cUpred.Name = "cUpred";
            this.cUpred.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cUpred.Size = new System.Drawing.Size(158, 21);
            this.cUpred.TabIndex = 19;
            this.cUpred.SelectedIndexChanged += new System.EventHandler(this.cUpred_SelectedIndexChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip.Location = new System.Drawing.Point(0, 484);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(812, 22);
            this.StatusStrip.TabIndex = 18;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 484);
            this.panel1.TabIndex = 26;
            this.panel1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(103, 484);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 15);
            this.toolStripLabel1.Text = "Реестры";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 19);
            this.toolStripButton1.Text = "Сводные отчеты";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(115, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 484);
            this.splitter1.TabIndex = 27;
            this.splitter1.TabStop = false;
            // 
            // frmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(812, 506);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cUper);
            this.Controls.Add(this.cUpred);
            this.Controls.Add(this.StatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmLoad";
            this.Text = "Учет выполнения";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLoad_FormClosed);
            this.Load += new System.EventHandler(this.frmLoad_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        internal System.Windows.Forms.ComboBox cUper;
        internal System.Windows.Forms.ComboBox cUpred;
        internal System.Windows.Forms.StatusStrip StatusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}



