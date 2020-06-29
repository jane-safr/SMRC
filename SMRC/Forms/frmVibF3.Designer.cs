namespace SMRC.Forms
{
    partial class frmVibF3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVibF3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBezNDS = new System.Windows.Forms.RadioButton();
            this.rbNDS = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdBezKop = new System.Windows.Forms.RadioButton();
            this.rbKop = new System.Windows.Forms.RadioButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TEx = new System.Windows.Forms.ToolStripButton();
            this.TVib = new System.Windows.Forms.ToolStripButton();
            this.ch84 = new System.Windows.Forms.CheckBox();
            this.ch91 = new System.Windows.Forms.CheckBox();
            this.ch2000 = new System.Windows.Forms.CheckBox();
            this.chDavMat = new System.Windows.Forms.CheckBox();
            this.chActs = new System.Windows.Forms.CheckBox();
            this.ch2000AEP = new System.Windows.Forms.CheckBox();
            this.chOborud = new System.Windows.Forms.CheckBox();
            this.tfltr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBezNDS);
            this.groupBox1.Controls.Add(this.rbNDS);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbBezNDS
            // 
            this.rbBezNDS.AutoSize = true;
            this.rbBezNDS.Location = new System.Drawing.Point(10, 33);
            this.rbBezNDS.Name = "rbBezNDS";
            this.rbBezNDS.Size = new System.Drawing.Size(70, 17);
            this.rbBezNDS.TabIndex = 1;
            this.rbBezNDS.TabStop = true;
            this.rbBezNDS.Text = "без НДС";
            this.rbBezNDS.UseVisualStyleBackColor = true;
            // 
            // rbNDS
            // 
            this.rbNDS.AutoSize = true;
            this.rbNDS.Location = new System.Drawing.Point(10, 10);
            this.rbNDS.Name = "rbNDS";
            this.rbNDS.Size = new System.Drawing.Size(58, 17);
            this.rbNDS.TabIndex = 0;
            this.rbNDS.TabStop = true;
            this.rbNDS.Text = "с НДС";
            this.rbNDS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBezKop);
            this.groupBox2.Controls.Add(this.rbKop);
            this.groupBox2.Location = new System.Drawing.Point(120, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rdBezKop
            // 
            this.rdBezKop.AutoSize = true;
            this.rdBezKop.Location = new System.Drawing.Point(6, 33);
            this.rdBezKop.Name = "rdBezKop";
            this.rdBezKop.Size = new System.Drawing.Size(82, 17);
            this.rdBezKop.TabIndex = 2;
            this.rdBezKop.TabStop = true;
            this.rdBezKop.Text = "без копеек";
            this.rdBezKop.UseVisualStyleBackColor = true;
            // 
            // rbKop
            // 
            this.rbKop.AutoSize = true;
            this.rbKop.Location = new System.Drawing.Point(6, 10);
            this.rbKop.Name = "rbKop";
            this.rbKop.Size = new System.Drawing.Size(90, 17);
            this.rbKop.TabIndex = 1;
            this.rbKop.TabStop = true;
            this.rbKop.Text = "с копейками";
            this.rbKop.UseVisualStyleBackColor = true;
            this.rbKop.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TEx,
            this.TVib});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 161);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ToolStrip1.Size = new System.Drawing.Size(241, 25);
            this.ToolStrip1.TabIndex = 45;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // TEx
            // 
            this.TEx.Image = ((System.Drawing.Image)(resources.GetObject("TEx.Image")));
            this.TEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TEx.Name = "TEx";
            this.TEx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TEx.Size = new System.Drawing.Size(73, 22);
            this.TEx.Text = "Закрыть";
            this.TEx.ToolTipText = "Выход";
            this.TEx.Click += new System.EventHandler(this.TEx_Click);
            // 
            // TVib
            // 
            this.TVib.Image = global::SMRC.Properties.Resources.BOOK02;
            this.TVib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TVib.Name = "TVib";
            this.TVib.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TVib.Size = new System.Drawing.Size(53, 22);
            this.TVib.Text = "КС-3";
            this.TVib.ToolTipText = "Просмотр";
            this.TVib.Click += new System.EventHandler(this.TVib_Click);
            // 
            // ch84
            // 
            this.ch84.AutoSize = true;
            this.ch84.Location = new System.Drawing.Point(0, 67);
            this.ch84.Name = "ch84";
            this.ch84.Size = new System.Drawing.Size(49, 17);
            this.ch84.TabIndex = 46;
            this.ch84.Text = "84 г.";
            this.ch84.UseVisualStyleBackColor = true;
            // 
            // ch91
            // 
            this.ch91.AutoSize = true;
            this.ch91.Location = new System.Drawing.Point(0, 81);
            this.ch91.Name = "ch91";
            this.ch91.Size = new System.Drawing.Size(49, 17);
            this.ch91.TabIndex = 47;
            this.ch91.Text = "91 г.";
            this.ch91.UseVisualStyleBackColor = true;
            // 
            // ch2000
            // 
            this.ch2000.AutoSize = true;
            this.ch2000.Location = new System.Drawing.Point(0, 95);
            this.ch2000.Name = "ch2000";
            this.ch2000.Size = new System.Drawing.Size(91, 17);
            this.ch2000.TabIndex = 48;
            this.ch2000.Text = "2000 г. АтЭИ";
            this.ch2000.UseVisualStyleBackColor = true;
            this.ch2000.CheckedChanged += new System.EventHandler(this.ch2000_CheckedChanged);
            // 
            // chDavMat
            // 
            this.chDavMat.AutoSize = true;
            this.chDavMat.Location = new System.Drawing.Point(0, 139);
            this.chDavMat.Name = "chDavMat";
            this.chDavMat.Size = new System.Drawing.Size(112, 17);
            this.chDavMat.TabIndex = 49;
            this.chDavMat.Text = "Давальч. мат-лы";
            this.chDavMat.UseVisualStyleBackColor = true;
            // 
            // chActs
            // 
            this.chActs.AutoSize = true;
            this.chActs.Location = new System.Drawing.Point(126, 73);
            this.chActs.Name = "chActs";
            this.chActs.Size = new System.Drawing.Size(113, 17);
            this.chActs.TabIndex = 52;
            this.chActs.Text = "с расш. по актам";
            this.chActs.UseVisualStyleBackColor = true;
            // 
            // ch2000AEP
            // 
            this.ch2000AEP.AutoSize = true;
            this.ch2000AEP.Location = new System.Drawing.Point(0, 110);
            this.ch2000AEP.Name = "ch2000AEP";
            this.ch2000AEP.Size = new System.Drawing.Size(86, 17);
            this.ch2000AEP.TabIndex = 53;
            this.ch2000AEP.Text = "2000 г. АЭП";
            this.ch2000AEP.UseVisualStyleBackColor = true;
            this.ch2000AEP.CheckedChanged += new System.EventHandler(this.ch2000AEP_CheckedChanged);
            // 
            // chOborud
            // 
            this.chOborud.AutoSize = true;
            this.chOborud.Location = new System.Drawing.Point(126, 87);
            this.chOborud.Name = "chOborud";
            this.chOborud.Size = new System.Drawing.Size(85, 17);
            this.chOborud.TabIndex = 54;
            this.chOborud.Text = "с оборудов.";
            this.chOborud.UseVisualStyleBackColor = true;
            // 
            // tfltr
            // 
            this.tfltr.Location = new System.Drawing.Point(126, 131);
            this.tfltr.Name = "tfltr";
            this.tfltr.Size = new System.Drawing.Size(108, 20);
            this.tfltr.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Фильтр по полю";
            // 
            // frmVibF3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 186);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tfltr);
            this.Controls.Add(this.chOborud);
            this.Controls.Add(this.ch2000AEP);
            this.Controls.Add(this.chActs);
            this.Controls.Add(this.chDavMat);
            this.Controls.Add(this.ch2000);
            this.Controls.Add(this.ch91);
            this.Controls.Add(this.ch84);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVibF3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор печатной формы справки";
            this.Activated += new System.EventHandler(this.frmVibF3_Activated);
            this.Load += new System.EventHandler(this.frmVibF3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbBezNDS;
        private System.Windows.Forms.RadioButton rbNDS;
        private System.Windows.Forms.RadioButton rbKop;
        private System.Windows.Forms.RadioButton rdBezKop;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton TEx;
        internal System.Windows.Forms.ToolStripButton TVib;
        private System.Windows.Forms.CheckBox ch84;
        private System.Windows.Forms.CheckBox ch91;
        private System.Windows.Forms.CheckBox chDavMat;
        private System.Windows.Forms.CheckBox chActs;
        private System.Windows.Forms.CheckBox ch2000;
        private System.Windows.Forms.CheckBox ch2000AEP;
        private System.Windows.Forms.CheckBox chOborud;
        private System.Windows.Forms.TextBox tfltr;
        private System.Windows.Forms.Label label1;
    }
}