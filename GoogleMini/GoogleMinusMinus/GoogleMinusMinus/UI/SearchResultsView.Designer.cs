namespace GoogleMini.UI
{
    partial class SearchResultsView
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
            this.loadAsWebPageButton = new System.Windows.Forms.Button();
            this.resultsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.noResultLabel = new System.Windows.Forms.Label();
            this.pagerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.resultCountLabel = new System.Windows.Forms.Label();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.loadingLabel = new System.Windows.Forms.Label();
            this.resultsPanel.SuspendLayout();
            this.pagerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadAsWebPageButton
            // 
            this.loadAsWebPageButton.BackColor = System.Drawing.Color.White;
            this.loadAsWebPageButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadAsWebPageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.loadAsWebPageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.loadAsWebPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadAsWebPageButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadAsWebPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.loadAsWebPageButton.Location = new System.Drawing.Point(0, 0);
            this.loadAsWebPageButton.Name = "loadAsWebPageButton";
            this.loadAsWebPageButton.Size = new System.Drawing.Size(441, 38);
            this.loadAsWebPageButton.TabIndex = 0;
            this.loadAsWebPageButton.Text = "load as web page";
            this.loadAsWebPageButton.UseVisualStyleBackColor = false;
            this.loadAsWebPageButton.Click += new System.EventHandler(this.LoadAsWebPageButton_Click);
            this.loadAsWebPageButton.MouseEnter += new System.EventHandler(this.LoadAsWebPageButton_MouseEnter);
            this.loadAsWebPageButton.MouseLeave += new System.EventHandler(this.LoadAsWebPageButton_MouseLeave);
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Controls.Add(this.noResultLabel);
            this.resultsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.resultsPanel.Location = new System.Drawing.Point(0, 56);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(441, 199);
            this.resultsPanel.TabIndex = 1;
            this.resultsPanel.WrapContents = false;
            // 
            // noResultLabel
            // 
            this.noResultLabel.AutoSize = true;
            this.noResultLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noResultLabel.Location = new System.Drawing.Point(3, 0);
            this.noResultLabel.Name = "noResultLabel";
            this.noResultLabel.Size = new System.Drawing.Size(384, 20);
            this.noResultLabel.TabIndex = 0;
            this.noResultLabel.Text = "Your search - kb1908674 - did not match any documents.";
            // 
            // pagerPanel
            // 
            this.pagerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.pagerPanel.Controls.Add(this.previousButton);
            this.pagerPanel.Controls.Add(this.nextButton);
            this.pagerPanel.Controls.Add(this.pagesLabel);
            this.pagerPanel.Location = new System.Drawing.Point(0, 411);
            this.pagerPanel.Name = "pagerPanel";
            this.pagerPanel.Size = new System.Drawing.Size(441, 39);
            this.pagerPanel.TabIndex = 2;
            // 
            // previousButton
            // 
            this.previousButton.AutoSize = true;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Image = global::GoogleMini.Properties.Resources.Previous;
            this.previousButton.Location = new System.Drawing.Point(3, 3);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(32, 32);
            this.previousButton.TabIndex = 0;
            this.previousButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.AutoSize = true;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Image = global::GoogleMini.Properties.Resources.Next;
            this.nextButton.Location = new System.Drawing.Point(41, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(32, 32);
            this.nextButton.TabIndex = 1;
            this.nextButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pagesLabel
            // 
            this.pagesLabel.AutoSize = true;
            this.pagesLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pagesLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.pagesLabel.Location = new System.Drawing.Point(79, 0);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(54, 38);
            this.pagesLabel.TabIndex = 2;
            this.pagesLabel.Text = "Pages: ";
            this.pagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultCountLabel
            // 
            this.resultCountLabel.AutoSize = true;
            this.resultCountLabel.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.resultCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultCountLabel.Location = new System.Drawing.Point(16, 38);
            this.resultCountLabel.Margin = new System.Windows.Forms.Padding(8);
            this.resultCountLabel.Name = "resultCountLabel";
            this.resultCountLabel.Size = new System.Drawing.Size(71, 17);
            this.resultCountLabel.TabIndex = 3;
            this.resultCountLabel.Text = "100 results";
            // 
            // loadingTimer
            // 
            this.loadingTimer.Interval = 500;
            this.loadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loadingLabel.Location = new System.Drawing.Point(12, 274);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(398, 35);
            this.loadingLabel.TabIndex = 8;
            this.loadingLabel.Text = "Loading    ";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.pagerPanel);
            this.Controls.Add(this.resultCountLabel);
            this.Controls.Add(this.loadAsWebPageButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchResultsView";
            this.Size = new System.Drawing.Size(441, 450);
            this.Load += new System.EventHandler(this.SearchResultsControl_Load);
            this.Resize += new System.EventHandler(this.SearchResultsControl_Resize);
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.pagerPanel.ResumeLayout(false);
            this.pagerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadAsWebPageButton;
        private System.Windows.Forms.FlowLayoutPanel resultsPanel;
        private System.Windows.Forms.FlowLayoutPanel pagerPanel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label noResultLabel;
        private System.Windows.Forms.Label resultCountLabel;
        private System.Windows.Forms.Timer loadingTimer;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Label pagesLabel;
    }
}
