namespace SMRC.Forms
{
    partial class frmActs
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.flNotPodp = new System.Windows.Forms.CheckBox();
            this.flNev = new System.Windows.Forms.CheckBox();
            this.flAll = new System.Windows.Forms.CheckBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.New = new System.Windows.Forms.ToolStripButton();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Delete = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Copy = new System.Windows.Forms.ToolStripButton();
            this.Move = new System.Windows.Forms.ToolStripButton();
            this.Podpis = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Refresh = new System.Windows.Forms.ToolStripButton();
            this.History = new System.Windows.Forms.ToolStripButton();
            this.Excel = new System.Windows.Forms.ToolStripButton();
            this.A0 = new System.Windows.Forms.ToolStripButton();
            this.RemPeriod = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.flNotReal = new System.Windows.Forms.CheckBox();
            this.Dgv1 = new SMRC.DGVt(this.components);
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.TextBox1);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.ToolStrip1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1049, 73);
            this.Panel1.TabIndex = 1;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(597, 28);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(112, 23);
            this.TextBox1.TabIndex = 3;
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(597, 51);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(112, 22);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Найти";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.flNotReal);
            this.GroupBox1.Controls.Add(this.flNotPodp);
            this.GroupBox1.Controls.Add(this.flNev);
            this.GroupBox1.Controls.Add(this.flAll);
            this.GroupBox1.Location = new System.Drawing.Point(3, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(566, 39);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Условия выбора актов";
            // 
            // flNotPodp
            // 
            this.flNotPodp.AutoSize = true;
            this.flNotPodp.Location = new System.Drawing.Point(294, 16);
            this.flNotPodp.Name = "flNotPodp";
            this.flNotPodp.Size = new System.Drawing.Size(97, 17);
            this.flNotPodp.TabIndex = 2;
            this.flNotPodp.Text = "не подписаны";
            this.flNotPodp.UseVisualStyleBackColor = true;
            this.flNotPodp.CheckedChanged += new System.EventHandler(this.flNotPodp_CheckedChanged);
            // 
            // flNev
            // 
            this.flNev.AutoSize = true;
            this.flNev.Location = new System.Drawing.Point(157, 16);
            this.flNev.Name = "flNev";
            this.flNev.Size = new System.Drawing.Size(131, 17);
            this.flNev.TabIndex = 1;
            this.flNev.Text = "неверная раскладка\r\n";
            this.flNev.UseVisualStyleBackColor = true;
            this.flNev.CheckedChanged += new System.EventHandler(this.flNev_CheckedChanged);
            // 
            // flAll
            // 
            this.flAll.AutoSize = true;
            this.flAll.Location = new System.Drawing.Point(9, 16);
            this.flAll.Name = "flAll";
            this.flAll.Size = new System.Drawing.Size(142, 17);
            this.flAll.TabIndex = 0;
            this.flAll.Text = "по всему предприятию";
            this.flAll.UseVisualStyleBackColor = true;
            this.flAll.CheckedChanged += new System.EventHandler(this.flAll_CheckedChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Open,
            this.Delete,
            this.ToolStripSeparator1,
            this.Copy,
            this.Move,
            this.Podpis,
            this.ToolStripSeparator2,
            this.Refresh,
            this.History,
            this.Excel,
            this.A0,
            this.RemPeriod,
            this.Exit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1049, 25);
            this.ToolStrip1.TabIndex = 0;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // New
            // 
            this.New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.New.Image = global::SMRC.Properties.Resources.NewAkt;
            this.New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(23, 22);
            this.New.Text = "Новый";
            this.New.ToolTipText = "Новый акт формы №2";
            this.New.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // Open
            // 
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = global::SMRC.Properties.Resources.Open;
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(23, 22);
            this.Open.Text = "Открыть";
            this.Open.ToolTipText = "Открыть акт";
            this.Open.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // Delete
            // 
            this.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Delete.Image = global::SMRC.Properties.Resources.Delete;
            this.Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(23, 22);
            this.Delete.Text = "Удалить";
            this.Delete.ToolTipText = "Удалить акт(ы)";
            this.Delete.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Copy
            // 
            this.Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy.Image = global::SMRC.Properties.Resources.Copy;
            this.Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(23, 22);
            this.Copy.Text = "Скопировать";
            this.Copy.ToolTipText = "Скопировать акт";
            this.Copy.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // Move
            // 
            this.Move.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Move.Image = global::SMRC.Properties.Resources.rem1;
            this.Move.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(23, 22);
            this.Move.Text = "Перенести акт(ы) на другой месяц(+/-)";
            this.Move.ToolTipText = "Перенести акт(ы) на другой месяц(+/-)";
            this.Move.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // Podpis
            // 
            this.Podpis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Podpis.Image = global::SMRC.Properties.Resources.NOTE14;
            this.Podpis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Podpis.Name = "Podpis";
            this.Podpis.Size = new System.Drawing.Size(23, 22);
            this.Podpis.Text = "Подписать";
            this.Podpis.ToolTipText = "Поставить(убрать) признак \"Подписан\"";
            this.Podpis.Click += new System.EventHandler(this.ToolStripButton6_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Refresh
            // 
            this.Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh.Image = global::SMRC.Properties.Resources.REFRESH;
            this.Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(23, 22);
            this.Refresh.Text = "Обновить";
            this.Refresh.ToolTipText = "Обновить список актов";
            this.Refresh.Click += new System.EventHandler(this.ToolStripButton7_Click);
            // 
            // History
            // 
            this.History.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.History.Image = global::SMRC.Properties.Resources.rask;
            this.History.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(23, 22);
            this.History.Text = "Показать движение акта";
            this.History.Click += new System.EventHandler(this.ToolStripButton8_Click);
            // 
            // Excel
            // 
            this.Excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Excel.Image = global::SMRC.Properties.Resources.exlel;
            this.Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(23, 22);
            this.Excel.Text = "Акты из А0";
            this.Excel.Click += new System.EventHandler(this.ToolStripButton10_Click);
            // 
            // A0
            // 
            this.A0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.A0.Image = global::SMRC.Properties.Resources.SootvA0;
            this.A0.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.A0.Name = "A0";
            this.A0.Size = new System.Drawing.Size(23, 22);
            this.A0.Text = "toolStripButton1";
            this.A0.Click += new System.EventHandler(this.A0_Click);
            // 
            // RemPeriod
            // 
            this.RemPeriod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemPeriod.Image = global::SMRC.Properties.Resources.ARW08RT;
            this.RemPeriod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemPeriod.Name = "RemPeriod";
            this.RemPeriod.Size = new System.Drawing.Size(23, 22);
            this.RemPeriod.Text = "Перенос на другой месяц";
            this.RemPeriod.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // Exit
            // 
            this.Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Exit.Image = global::SMRC.Properties.Resources.Exit1;
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(23, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.ToolStripButton9_Click);
            // 
            // flNotReal
            // 
            this.flNotReal.AutoSize = true;
            this.flNotReal.Location = new System.Drawing.Point(397, 16);
            this.flNotReal.Name = "flNotReal";
            this.flNotReal.Size = new System.Drawing.Size(158, 17);
            this.flNotReal.TabIndex = 3;
            this.flNotReal.Text = "не сняты под реализацию";
            this.flNotReal.UseVisualStyleBackColor = true;
            this.flNotReal.CheckedChanged += new System.EventHandler(this.flNotReal_CheckedChanged);
            // 
            // Dgv1
            // 
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.Location = new System.Drawing.Point(0, 73);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(1049, 415);
            this.Dgv1.TabIndex = 2;
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            this.Dgv1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.Dgv1_RowPrePaint);
            // 
            // frmActs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 488);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.Panel1);
            this.Name = "frmActs";
            this.Text = "Акты формы №2. Синий цвет - акты из программы А0, коричневые - из 1С, зеленый цве" +
    "т - предварительные акты.";
            this.Load += new System.EventHandler(this.frmActs_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox flNotPodp;
        internal System.Windows.Forms.CheckBox flNev;
        internal System.Windows.Forms.CheckBox flAll;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton New;
        internal System.Windows.Forms.ToolStripButton Open;
        internal System.Windows.Forms.ToolStripButton Delete;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton Copy;
        internal System.Windows.Forms.ToolStripButton Move;
        internal System.Windows.Forms.ToolStripButton Podpis;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton Refresh;
        internal System.Windows.Forms.ToolStripButton History;
        internal System.Windows.Forms.ToolStripButton Excel;
        internal System.Windows.Forms.ToolStripButton Exit;
        private DGVt Dgv1;
        private System.Windows.Forms.ToolStripButton A0;
        private System.Windows.Forms.ToolStripButton RemPeriod;
        internal System.Windows.Forms.CheckBox flNotReal;
    }
}