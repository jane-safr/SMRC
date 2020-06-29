namespace SMRC.Forms
{
    partial class frmSprDGV
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
            System.Windows.Forms.ToolStripMenuItem tsbFind;
            System.Windows.Forms.ToolStripMenuItem tsbExit;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MS2 = new System.Windows.Forms.MenuStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tstText = new System.Windows.Forms.ToolStripTextBox();
            this.tsFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslCount = new System.Windows.Forms.ToolStripLabel();
            this.AutoH = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbl1 = new System.Windows.Forms.ToolStripLabel();
            this.Dgv1 = new SMRC.DGVt(this.components);
            tsbFind = new System.Windows.Forms.ToolStripMenuItem();
            tsbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.MS2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsbFind
            // 
            tsbFind.Image = global::SMRC.Properties.Resources.Find;
            tsbFind.Name = "tsbFind";
            tsbFind.Size = new System.Drawing.Size(69, 23);
            tsbFind.Text = "Найти";
            tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // tsbExit
            // 
            tsbExit.Image = global::SMRC.Properties.Resources.Exit1;
            tsbExit.Name = "tsbExit";
            tsbExit.Size = new System.Drawing.Size(28, 23);
            tsbExit.ToolTipText = "Выход";
            tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(266, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SMRC.Properties.Resources.REFRESH;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 23);
            this.btnRefresh.ToolTipText = "Выгрузить данные в Excel";
            this.btnRefresh.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 52);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(595, 24);
            this.menuStrip2.TabIndex = 46;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // MS2
            // 
            this.MS2.BackColor = System.Drawing.Color.Lavender;
            this.MS2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDel,
            this.tstText,
            tsbFind,
            this.tsFilter,
            this.tsExcel,
            this.btnRefresh,
            tsbExit});
            this.MS2.Location = new System.Drawing.Point(0, 0);
            this.MS2.Name = "MS2";
            this.MS2.Size = new System.Drawing.Size(825, 27);
            this.MS2.TabIndex = 43;
            this.MS2.Text = "MS2";
            // 
            // tsbAdd
            // 
            this.tsbAdd.BackColor = System.Drawing.Color.Lavender;
            this.tsbAdd.Image = global::SMRC.Properties.Resources.add_small;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(28, 23);
            this.tsbAdd.ToolTipText = "Добавит запись";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::SMRC.Properties.Resources.Delete;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(28, 23);
            this.tsbDel.ToolTipText = "Удалить запись";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tstText
            // 
            this.tstText.Name = "tstText";
            this.tstText.Size = new System.Drawing.Size(200, 23);
            this.tstText.DoubleClick += new System.EventHandler(this.tstText_DoubleClick);
            // 
            // tsFilter
            // 
            this.tsFilter.BackColor = System.Drawing.Color.Lavender;
            this.tsFilter.Image = global::SMRC.Properties.Resources.FILTER1;
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(28, 23);
            this.tsFilter.ToolTipText = "Фильтр";
            this.tsFilter.Click += new System.EventHandler(this.tsFilter_Click);
            // 
            // tsExcel
            // 
            this.tsExcel.Image = global::SMRC.Properties.Resources.exlel;
            this.tsExcel.Name = "tsExcel";
            this.tsExcel.Size = new System.Drawing.Size(28, 23);
            this.tsExcel.ToolTipText = "Выгрузить данные в Excel";
            this.tsExcel.Click += new System.EventHandler(this.tsExcel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Lavender;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCount,
            this.AutoH,
            this.toolStripLabel1,
            this.lbl1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(41, 22);
            this.tslCount.Text = "Всего:";
            // 
            // AutoH
            // 
            this.AutoH.Name = "AutoH";
            this.AutoH.Size = new System.Drawing.Size(123, 22);
            this.AutoH.Text = "                 Автовысота";
            this.AutoH.Click += new System.EventHandler(this.AutoH_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "                     ";
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(10, 22);
            this.lbl1.Text = " ";
            // 
            // Dgv1
            // 
            this.Dgv1.BackgroundColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Dgv1.Location = new System.Drawing.Point(0, 52);
            this.Dgv1.Name = "Dgv1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv1.Size = new System.Drawing.Size(825, 413);
            this.Dgv1.TabIndex = 12;
            this.Dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellClick);
            this.Dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellContentClick);
            this.Dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellDoubleClick);
            this.Dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEndEdit);
            this.Dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellEnter);
            this.Dgv1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellLeave);
            this.Dgv1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.Dgv1_UserAddedRow);
            this.Dgv1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Dgv1_UserDeletingRow);
            // 
            // frmSprDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MS2);
            this.Name = "frmSprDGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSprDGV_FormClosed);
            this.Load += new System.EventHandler(this.frmSprDGV_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.MS2.ResumeLayout(false);
            this.MS2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DGVt Dgv1;
        private System.Windows.Forms.MenuStrip MS2;
        internal System.Windows.Forms.ToolStripMenuItem tsbAdd;
        internal System.Windows.Forms.ToolStripMenuItem tsbDel;
        internal System.Windows.Forms.ToolStripTextBox tstText;
        internal System.Windows.Forms.ToolStripMenuItem tsFilter;
        internal System.Windows.Forms.ToolStripMenuItem tsExcel;
        internal System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslCount;
        private System.Windows.Forms.ToolStripLabel AutoH;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripLabel lbl1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}