using GoogleMini.UI.CustomControls;

namespace GoogleMini.UI
{
    partial class SearchResultItem
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
            this.pathLabel = new System.Windows.Forms.Label();
            this.contextRichTextBox = new RichLabel();
            this.locationLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(33)))));
            this.pathLabel.Location = new System.Drawing.Point(0, 24);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(38, 15);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "label2";
            // 
            // contextRichTextBox
            // 
            this.contextRichTextBox.BackColor = System.Drawing.Color.White;
            this.contextRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contextRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.contextRichTextBox.DetectUrls = false;
            this.contextRichTextBox.Location = new System.Drawing.Point(2, 42);
            this.contextRichTextBox.Name = "contextRichTextBox";
            this.contextRichTextBox.ReadOnly = true;
            this.contextRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.contextRichTextBox.Size = new System.Drawing.Size(424, 18);
            this.contextRichTextBox.TabIndex = 2;
            this.contextRichTextBox.TabStop = false;
            this.contextRichTextBox.Text = "context goes here";
            this.contextRichTextBox.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.ContextRichTextBox_ContentsResized);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.ForeColor = System.Drawing.Color.Gray;
            this.locationLabel.Location = new System.Drawing.Point(0, 72);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(38, 15);
            this.locationLabel.TabIndex = 3;
            this.locationLabel.Text = "label1";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(13)))), ((int)(((byte)(171)))));
            this.titleLabel.Location = new System.Drawing.Point(-1, 3);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(51, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "label1";
            this.titleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            this.titleLabel.MouseEnter += new System.EventHandler(this.TitleLabel_MouseEnter);
            this.titleLabel.MouseLeave += new System.EventHandler(this.TitleLabel_MouseLeave);
            // 
            // SearchResultItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.contextRichTextBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchResultItem";
            this.Size = new System.Drawing.Size(433, 92);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.SearchResultItem_Layout);
            this.Resize += new System.EventHandler(this.SearchResultItem_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label pathLabel;
        private RichLabel contextRichTextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}
