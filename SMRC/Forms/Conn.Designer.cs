namespace SMRC.Forms
{
    partial class Conn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conn));
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.ToolStripLabel1.Text = "Вход";
            this.ToolStripLabel1.ToolTipText = "Добавить расценки в смету";
            this.ToolStripLabel1.Click += new System.EventHandler(this.ToolStripLabel1_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel1,
            this.ToolStripButton3});
            this.ToolStrip1.Location = new System.Drawing.Point(100, 25);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(96, 25);
            this.ToolStrip1.TabIndex = 13;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton3
            // 
            this.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton3.Image")));
            this.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton3.Name = "ToolStripButton3";
            this.ToolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton3.Text = "ToolStripButton3";
            this.ToolStripButton3.ToolTipText = "Выход";
            this.ToolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label1.Location = new System.Drawing.Point(1, 1);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Сервер";
            // 
            // ComboBox1
            // 
            this.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(57, 0);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(139, 21);
            this.ComboBox1.TabIndex = 11;
            // 
            // Conn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 51);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ComboBox1);
            this.Name = "Conn";
            this.Text = "Выберите сервер";
            this.Load += new System.EventHandler(this.Conn_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox ComboBox1;

    }
}