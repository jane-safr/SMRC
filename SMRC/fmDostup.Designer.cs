namespace SMRC
{
    partial class frmDostup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label3 = new System.Windows.Forms.Label();
            this.id_group = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_user = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Dgv1 = new SMRC.DGVt(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Доступ";
            // 
            // id_group
            // 
            this.id_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_group.BackColor = System.Drawing.Color.Snow;
            this.id_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.id_group.ForeColor = System.Drawing.SystemColors.ControlText;
            this.id_group.FormattingEnabled = true;
            this.id_group.Location = new System.Drawing.Point(98, 6);
            this.id_group.Name = "id_group";
            this.id_group.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.id_group.Size = new System.Drawing.Size(344, 21);
            this.id_group.TabIndex = 21;
            this.id_group.SelectedIndexChanged += new System.EventHandler(this.id_group_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Пользователь";
            // 
            // id_user
            // 
            this.id_user.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_user.BackColor = System.Drawing.Color.Snow;
            this.id_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.id_user.ForeColor = System.Drawing.SystemColors.ControlText;
            this.id_user.FormattingEnabled = true;
            this.id_user.Location = new System.Drawing.Point(98, 33);
            this.id_user.Name = "id_user";
            this.id_user.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.id_user.Size = new System.Drawing.Size(344, 21);
            this.id_user.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(460, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.Dgv1.Location = new System.Drawing.Point(1, 60);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(548, 336);
            this.Dgv1.TabIndex = 26;
            this.Dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellClick);
            // 
            // frmDostup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 397);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_user);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.id_group);
            this.Name = "frmDostup";
            this.Text = "Доступ к изменению данных программы Учет СМР";
            this.Load += new System.EventHandler(this.fmDostup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox id_group;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox id_user;
        private System.Windows.Forms.Button button1;
        private DGVt Dgv1;
    }
}