namespace SMRC.Forms
{
    partial class frmColumns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColumns));
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.tbSelAll = new System.Windows.Forms.ToolStripLabel();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView1
            // 
            this.TreeView1.CheckBoxes = true;
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.Location = new System.Drawing.Point(0, 25);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(366, 538);
            this.TreeView1.TabIndex = 3;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVib,
            this.tbSelAll,
            this.TEx});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(366, 25);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // TVib
            // 
            this.TVib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TVib.Image = ((System.Drawing.Image)(resources.GetObject("TVib.Image")));
            this.TVib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TVib.Name = "TVib";
            this.TVib.Size = new System.Drawing.Size(23, 22);
            this.TVib.Text = "ToolStripButton1";
            this.TVib.ToolTipText = "Выбрать отмеченные значения";
            this.TVib.Click += new System.EventHandler(this.TVib_Click);
            // 
            // tbSelAll
            // 
            this.tbSelAll.Name = "tbSelAll";
            this.tbSelAll.Size = new System.Drawing.Size(78, 22);
            this.tbSelAll.Text = "Выделить все";
            this.tbSelAll.Click += new System.EventHandler(this.tbSelAll_Click);
            // 
            // TEx
            // 
            this.TEx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TEx.Image = ((System.Drawing.Image)(resources.GetObject("TEx.Image")));
            this.TEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TEx.Name = "TEx";
            this.TEx.Size = new System.Drawing.Size(23, 22);
            this.TEx.Text = "ToolStripButton2";
            this.TEx.ToolTipText = "Выход";
            this.TEx.Click += new System.EventHandler(this.TEx_Click);
            // 
            // frmColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 563);
            this.Controls.Add(this.TreeView1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmColumns";
            this.Text = "Список столбцов";
            this.Load += new System.EventHandler(this.frmColumns_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TVib;
        internal System.Windows.Forms.ToolStripButton TEx;
        private System.Windows.Forms.ToolStripLabel tbSelAll;
    }
}