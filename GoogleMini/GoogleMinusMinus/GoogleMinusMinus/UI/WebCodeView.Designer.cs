using GoogleMini.UI.CustomControls.HTML;

namespace GoogleMini.UI
{
    partial class WebCodeView
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
            this.components = new System.ComponentModel.Container();
            this.searchIndexButton = new System.Windows.Forms.Button();
            this.tagsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleHtmlTextBox = new GoogleMini.UI.CustomControls.HTML.HTMLTextBox();
            this.linksLabel = new System.Windows.Forms.Label();
            this.linksHtmlTextBox = new GoogleMini.UI.CustomControls.HTML.HTMLTextBox();
            this.scriptsLabel = new System.Windows.Forms.Label();
            this.scriptsHtmlTextBox = new GoogleMini.UI.CustomControls.HTML.HTMLTextBox();
            this.errorMsgLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.tagsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchIndexButton
            // 
            this.searchIndexButton.BackColor = System.Drawing.Color.White;
            this.searchIndexButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchIndexButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.searchIndexButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.searchIndexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchIndexButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchIndexButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.searchIndexButton.Location = new System.Drawing.Point(0, 0);
            this.searchIndexButton.Name = "searchIndexButton";
            this.searchIndexButton.Size = new System.Drawing.Size(404, 38);
            this.searchIndexButton.TabIndex = 1;
            this.searchIndexButton.Text = "search index";
            this.searchIndexButton.UseVisualStyleBackColor = false;
            this.searchIndexButton.Click += new System.EventHandler(this.SearchIndexButton_Click);
            this.searchIndexButton.MouseEnter += new System.EventHandler(this.SearchIndexButton_MouseEnter);
            this.searchIndexButton.MouseLeave += new System.EventHandler(this.SearchIndexButton_MouseLeave);
            // 
            // tagsPanel
            // 
            this.tagsPanel.AutoScroll = true;
            this.tagsPanel.Controls.Add(this.titleLabel);
            this.tagsPanel.Controls.Add(this.titleHtmlTextBox);
            this.tagsPanel.Controls.Add(this.linksLabel);
            this.tagsPanel.Controls.Add(this.linksHtmlTextBox);
            this.tagsPanel.Controls.Add(this.scriptsLabel);
            this.tagsPanel.Controls.Add(this.scriptsHtmlTextBox);
            this.tagsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tagsPanel.Location = new System.Drawing.Point(0, 38);
            this.tagsPanel.Name = "tagsPanel";
            this.tagsPanel.Size = new System.Drawing.Size(401, 189);
            this.tagsPanel.TabIndex = 2;
            this.tagsPanel.WrapContents = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 21);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // titleHtmlTextBox
            // 
            this.titleHtmlTextBox.BackColor = System.Drawing.Color.White;
            this.titleHtmlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleHtmlTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.titleHtmlTextBox.Location = new System.Drawing.Point(3, 24);
            this.titleHtmlTextBox.Name = "titleHtmlTextBox";
            this.titleHtmlTextBox.ReadOnly = true;
            this.titleHtmlTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.titleHtmlTextBox.Size = new System.Drawing.Size(3, 18);
            this.titleHtmlTextBox.TabIndex = 1;
            this.titleHtmlTextBox.Text = "";
            this.titleHtmlTextBox.WordWrap = false;
            // 
            // linksLabel
            // 
            this.linksLabel.AutoSize = true;
            this.linksLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linksLabel.Location = new System.Drawing.Point(3, 45);
            this.linksLabel.Name = "linksLabel";
            this.linksLabel.Size = new System.Drawing.Size(46, 21);
            this.linksLabel.TabIndex = 2;
            this.linksLabel.Text = "Links";
            // 
            // linksHtmlTextBox
            // 
            this.linksHtmlTextBox.BackColor = System.Drawing.Color.White;
            this.linksHtmlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linksHtmlTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksHtmlTextBox.Location = new System.Drawing.Point(3, 69);
            this.linksHtmlTextBox.Name = "linksHtmlTextBox";
            this.linksHtmlTextBox.ReadOnly = true;
            this.linksHtmlTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.linksHtmlTextBox.Size = new System.Drawing.Size(3, 18);
            this.linksHtmlTextBox.TabIndex = 3;
            this.linksHtmlTextBox.Text = "";
            this.linksHtmlTextBox.WordWrap = false;
            // 
            // scriptsLabel
            // 
            this.scriptsLabel.AutoSize = true;
            this.scriptsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.scriptsLabel.Location = new System.Drawing.Point(3, 90);
            this.scriptsLabel.Name = "scriptsLabel";
            this.scriptsLabel.Size = new System.Drawing.Size(60, 21);
            this.scriptsLabel.TabIndex = 4;
            this.scriptsLabel.Text = "Scripts";
            // 
            // scriptsHtmlTextBox
            // 
            this.scriptsHtmlTextBox.BackColor = System.Drawing.Color.White;
            this.scriptsHtmlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scriptsHtmlTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.scriptsHtmlTextBox.Location = new System.Drawing.Point(3, 114);
            this.scriptsHtmlTextBox.Name = "scriptsHtmlTextBox";
            this.scriptsHtmlTextBox.ReadOnly = true;
            this.scriptsHtmlTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.scriptsHtmlTextBox.Size = new System.Drawing.Size(3, 18);
            this.scriptsHtmlTextBox.TabIndex = 5;
            this.scriptsHtmlTextBox.Text = "";
            this.scriptsHtmlTextBox.WordWrap = false;
            // 
            // errorMsgLabel
            // 
            this.errorMsgLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.errorMsgLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorMsgLabel.Location = new System.Drawing.Point(3, 325);
            this.errorMsgLabel.Name = "errorMsgLabel";
            this.errorMsgLabel.Size = new System.Drawing.Size(398, 35);
            this.errorMsgLabel.TabIndex = 6;
            this.errorMsgLabel.Text = "Oops! Error";
            this.errorMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loadingLabel.Location = new System.Drawing.Point(3, 283);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(398, 35);
            this.loadingLabel.TabIndex = 7;
            this.loadingLabel.Text = "Loading    ";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 500;
            this.loadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
            // 
            // WebCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.tagsPanel);
            this.Controls.Add(this.errorMsgLabel);
            this.Controls.Add(this.searchIndexButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "WebCodeView";
            this.Size = new System.Drawing.Size(404, 432);
            this.Load += new System.EventHandler(this.HTMLViewControl_Load);
            this.tagsPanel.ResumeLayout(false);
            this.tagsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchIndexButton;
        private System.Windows.Forms.FlowLayoutPanel tagsPanel;
        private System.Windows.Forms.Label titleLabel;
        private HTMLTextBox titleHtmlTextBox;
        private System.Windows.Forms.Label linksLabel;
        private HTMLTextBox linksHtmlTextBox;
        private System.Windows.Forms.Label scriptsLabel;
        private HTMLTextBox scriptsHtmlTextBox;
        private System.Windows.Forms.Label errorMsgLabel;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Timer loadingTimer;
    }
}
