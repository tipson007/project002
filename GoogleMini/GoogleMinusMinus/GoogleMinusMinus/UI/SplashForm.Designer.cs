namespace GoogleMini.UI
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.cancelLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.minimizeLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.waveCanvas = new GoogleMini.UI.CustomControls.NoMouseEventsControl();            
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.ForeColor = System.Drawing.Color.Gray;
            this.copyrightLabel.Location = new System.Drawing.Point(60, 310);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(282, 15);
            this.copyrightLabel.TabIndex = 11;
            this.copyrightLabel.Text = "© 2017 Dublin Business School. All rights reserved\r\n";
            // 
            // cancelLabel
            // 
            this.cancelLabel.AutoSize = true;
            this.cancelLabel.BackColor = System.Drawing.Color.Transparent;
            this.cancelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelLabel.ForeColor = System.Drawing.Color.Gray;
            this.cancelLabel.Location = new System.Drawing.Point(444, 310);
            this.cancelLabel.Name = "cancelLabel";
            this.cancelLabel.Size = new System.Drawing.Size(45, 15);
            this.cancelLabel.TabIndex = 10;
            this.cancelLabel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.cancelLabel, "Cancel");
            this.cancelLabel.Click += new System.EventHandler(this.CancelLabel_Click);
            this.cancelLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelMouseDown);
            this.cancelLabel.MouseEnter += new System.EventHandler(this.LabelMouseEnter);
            this.cancelLabel.MouseLeave += new System.EventHandler(this.LabelMouseLeave);
            this.cancelLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelMouseMove);
            // 
            // closeLabel
            // 
            this.closeLabel.BackColor = System.Drawing.Color.Transparent;
            this.closeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.closeLabel.Location = new System.Drawing.Point(474, 10);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(14, 16);
            this.closeLabel.TabIndex = 9;
            this.closeLabel.Text = "x";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolTip1.SetToolTip(this.closeLabel, "Cancel");
            this.closeLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            this.closeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelMouseDown);
            this.closeLabel.MouseEnter += new System.EventHandler(this.LabelMouseEnter);
            this.closeLabel.MouseLeave += new System.EventHandler(this.LabelMouseLeave);
            this.closeLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelMouseMove);
            // 
            // minimizeLabel
            // 
            this.minimizeLabel.AutoSize = true;
            this.minimizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.minimizeLabel.Font = new System.Drawing.Font("Modern No. 20", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.minimizeLabel.Location = new System.Drawing.Point(457, 9);
            this.minimizeLabel.Name = "minimizeLabel";
            this.minimizeLabel.Size = new System.Drawing.Size(17, 15);
            this.minimizeLabel.TabIndex = 8;
            this.minimizeLabel.Text = "_";
            this.minimizeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.minimizeLabel, "Minimize");
            this.minimizeLabel.Click += new System.EventHandler(this.MinimizeLabel_Click);
            this.minimizeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelMouseDown);
            this.minimizeLabel.MouseEnter += new System.EventHandler(this.LabelMouseEnter);
            this.minimizeLabel.MouseLeave += new System.EventHandler(this.LabelMouseLeave);
            this.minimizeLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelMouseMove);
            // 
            // waveCanvas
            // 
            this.waveCanvas.BackColor = System.Drawing.Color.White;
            this.waveCanvas.Location = new System.Drawing.Point(1, 29);
            this.waveCanvas.Name = "waveCanvas";
            this.waveCanvas.Size = new System.Drawing.Size(498, 278);
            this.waveCanvas.TabIndex = 12;
            this.waveCanvas.TabStop = false;
            this.waveCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.WaveCanvas_Paint);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 335);
            this.Controls.Add(this.waveCanvas);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.cancelLabel);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.minimizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(500, 335);
            this.Name = "SplashForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google Mini";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SplashForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashForm_MouseDown);            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label copyrightLabel;
        internal System.Windows.Forms.Label cancelLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label closeLabel;
        internal System.Windows.Forms.Label minimizeLabel;
        private GoogleMini.UI.CustomControls.NoMouseEventsControl waveCanvas;
    }
}