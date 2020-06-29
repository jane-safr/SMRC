namespace SMRC
{
    partial class UCFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFilter));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.TFilter = new System.Windows.Forms.ToolStripButton();
            this.TRem = new System.Windows.Forms.ToolStripButton();
            this.TSpisok = new System.Windows.Forms.ToolStripButton();
            this.TBack = new System.Windows.Forms.ToolStripButton();
            this.TForward = new System.Windows.Forms.ToolStripButton();
            this.ToolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.TExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.ToolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox1,
            this.ToolStripTextBox1,
            this.TFilter,
            this.TRem,
            this.TSpisok,
            this.TBack,
            this.TForward,
            this.ToolStripTextBox2,
            this.TExit,
            this.toolStripButton1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(759, 25);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripComboBox1
            // 
            this.ToolStripComboBox1.Name = "ToolStripComboBox1";
            this.ToolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // ToolStripTextBox1
            // 
            this.ToolStripTextBox1.Name = "ToolStripTextBox1";
            this.ToolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // TFilter
            // 
            this.TFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TFilter.Image = ((System.Drawing.Image)(resources.GetObject("TFilter.Image")));
            this.TFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TFilter.Name = "TFilter";
            this.TFilter.Size = new System.Drawing.Size(23, 22);
            this.TFilter.ToolTipText = "Применить фильтр по введенному значению";
            this.TFilter.Click += new System.EventHandler(this.TFilter_Click);
            // 
            // TRem
            // 
            this.TRem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TRem.Image = ((System.Drawing.Image)(resources.GetObject("TRem.Image")));
            this.TRem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TRem.Name = "TRem";
            this.TRem.Size = new System.Drawing.Size(23, 22);
            this.TRem.ToolTipText = "Убрать фильтр";
            this.TRem.Click += new System.EventHandler(this.TRem_Click);
            // 
            // TSpisok
            // 
            this.TSpisok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSpisok.Image = ((System.Drawing.Image)(resources.GetObject("TSpisok.Image")));
            this.TSpisok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSpisok.Name = "TSpisok";
            this.TSpisok.Size = new System.Drawing.Size(23, 22);
            this.TSpisok.ToolTipText = "Расскрыть список значений";
            this.TSpisok.Click += new System.EventHandler(this.TSpisok_Click);
            // 
            // TBack
            // 
            this.TBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TBack.Image = ((System.Drawing.Image)(resources.GetObject("TBack.Image")));
            this.TBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TBack.Name = "TBack";
            this.TBack.Size = new System.Drawing.Size(23, 22);
            this.TBack.Text = "ToolStripButton5";
            this.TBack.ToolTipText = "Отменить";
            this.TBack.Click += new System.EventHandler(this.TBack_Click);
            // 
            // TForward
            // 
            this.TForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TForward.Image = ((System.Drawing.Image)(resources.GetObject("TForward.Image")));
            this.TForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TForward.Name = "TForward";
            this.TForward.Size = new System.Drawing.Size(23, 22);
            this.TForward.Text = "ToolStripButton6";
            this.TForward.ToolTipText = "Вернуть";
            this.TForward.Click += new System.EventHandler(this.TForward_Click_1);
            // 
            // ToolStripTextBox2
            // 
            this.ToolStripTextBox2.Name = "ToolStripTextBox2";
            this.ToolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // TExit
            // 
            this.TExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TExit.Image = ((System.Drawing.Image)(resources.GetObject("TExit.Image")));
            this.TExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TExit.Name = "TExit";
            this.TExit.Size = new System.Drawing.Size(23, 22);
            this.TExit.ToolTipText = "Выход";
            this.TExit.Click += new System.EventHandler(this.TExit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TextBox2);
            this.splitContainer1.Size = new System.Drawing.Size(759, 89);
            this.splitContainer1.SplitterDistance = 528;
            this.splitContainer1.TabIndex = 5;
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(0, 0);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(528, 82);
            this.ListBox1.TabIndex = 5;
            // 
            // TextBox2
            // 
            this.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox2.Location = new System.Drawing.Point(0, 0);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(227, 89);
            this.TextBox2.TabIndex = 1;
            // 
            // UCFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "UCFilter";
            this.Size = new System.Drawing.Size(759, 114);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripComboBox ToolStripComboBox1;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox1;
        internal System.Windows.Forms.ToolStripButton TFilter;
        internal System.Windows.Forms.ToolStripButton TRem;
        internal System.Windows.Forms.ToolStripButton TSpisok;
        internal System.Windows.Forms.ToolStripButton TBack;
        internal System.Windows.Forms.ToolStripButton TForward;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox2;
        internal System.Windows.Forms.ToolStripButton TExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
