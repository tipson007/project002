namespace InstructionSet.UI
{
    partial class EditTextBlockForm
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
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.chbUnderline = new System.Windows.Forms.CheckBox();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.rtbEntry = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpToolbar.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.BackColor = System.Drawing.Color.White;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Cursor = System.Windows.Forms.Cursors.No;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Location = new System.Drawing.Point(3, 16);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(362, 161);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // flpToolbar
            // 
            this.flpToolbar.Controls.Add(this.btnFont);
            this.flpToolbar.Controls.Add(this.btnPenColor);
            this.flpToolbar.Controls.Add(this.btnBackColor);
            this.flpToolbar.Controls.Add(this.chbUnderline);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpToolbar.Location = new System.Drawing.Point(4, 4);
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.Size = new System.Drawing.Size(368, 43);
            this.flpToolbar.TabIndex = 1;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(3, 3);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(36, 23);
            this.btnFont.TabIndex = 0;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.BtnFont_Click);
            // 
            // btnPenColor
            // 
            this.btnPenColor.Location = new System.Drawing.Point(45, 3);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(62, 23);
            this.btnPenColor.TabIndex = 1;
            this.btnPenColor.Text = "Pen Color";
            this.btnPenColor.UseVisualStyleBackColor = true;
            this.btnPenColor.Click += new System.EventHandler(this.BtnPenColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(113, 3);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(100, 23);
            this.btnBackColor.TabIndex = 2;
            this.btnBackColor.Text = "Background Color";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.BtnBackColor_Click);
            // 
            // chbUnderline
            // 
            this.chbUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbUnderline.AutoSize = true;
            this.chbUnderline.Location = new System.Drawing.Point(219, 3);
            this.chbUnderline.Name = "chbUnderline";
            this.chbUnderline.Size = new System.Drawing.Size(62, 23);
            this.chbUnderline.TabIndex = 6;
            this.chbUnderline.Text = "Underline";
            this.chbUnderline.UseVisualStyleBackColor = true;
            this.chbUnderline.CheckedChanged += new System.EventHandler(this.ChbUnderline_CheckedChanged);
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnCancel);
            this.flpActions.Controls.Add(this.btnOk);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActions.Location = new System.Drawing.Point(4, 340);
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(368, 32);
            this.flpActions.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(209, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // rtbEntry
            // 
            this.rtbEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbEntry.Location = new System.Drawing.Point(4, 47);
            this.rtbEntry.Name = "rtbEntry";
            this.rtbEntry.Size = new System.Drawing.Size(368, 113);
            this.rtbEntry.TabIndex = 3;
            this.rtbEntry.Text = "";
            this.rtbEntry.TextChanged += new System.EventHandler(this.RtbEntry_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 180);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // EditTextBlockForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 376);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbEntry);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditTextBlockForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditBlockForm";
            this.flpToolbar.ResumeLayout(false);
            this.flpToolbar.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox chbUnderline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.RichTextBox rtbEntry;
    }
}