using GoogleMini.UI.CustomControls;

namespace GoogleMini.UI
{
    partial class ShellForm
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
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.urlNsearchTextbox = new System.Windows.Forms.TextBox();
            this.homeButton = new GoogleMini.UI.CustomControls.NoFocusCuesButton();
            this.goButton = new GoogleMini.UI.CustomControls.NoFocusCuesButton();
            this.searchBar_left_image = new System.Windows.Forms.PictureBox();
            this.searchBar_right_image = new System.Windows.Forms.PictureBox();
            this.searchBar_middle_image = new System.Windows.Forms.PictureBox();
            this.childContainerPanel = new System.Windows.Forms.Panel();
            this.toolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_left_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_right_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_middle_image)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolbarPanel.BackgroundImage = global::GoogleMini.Properties.Resources.upbar;
            this.toolbarPanel.Controls.Add(this.urlNsearchTextbox);
            this.toolbarPanel.Controls.Add(this.homeButton);
            this.toolbarPanel.Controls.Add(this.goButton);
            this.toolbarPanel.Controls.Add(this.searchBar_left_image);
            this.toolbarPanel.Controls.Add(this.searchBar_right_image);
            this.toolbarPanel.Controls.Add(this.searchBar_middle_image);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(725, 61);
            this.toolbarPanel.TabIndex = 2;
            // 
            // urlNsearchTextbox
            // 
            this.urlNsearchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlNsearchTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlNsearchTextbox.Location = new System.Drawing.Point(90, 18);
            this.urlNsearchTextbox.Name = "urlNsearchTextbox";
            this.urlNsearchTextbox.Size = new System.Drawing.Size(557, 18);
            this.urlNsearchTextbox.TabIndex = 0;
            this.urlNsearchTextbox.WordWrap = false;
            this.urlNsearchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlNsearchTextbox_KeyDown);
            // 
            // homeButton
            // 
            this.homeButton.BackgroundImage = global::GoogleMini.Properties.Resources.Home_Leave;
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Location = new System.Drawing.Point(1, 4);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(46, 44);
            this.homeButton.TabIndex = 1;
            this.homeButton.UseMnemonic = false;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.BackgroundImage = global::GoogleMini.Properties.Resources.Search_Leave;
            this.goButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.goButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goButton.FlatAppearance.BorderSize = 0;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Location = new System.Drawing.Point(686, 10);
            this.goButton.Margin = new System.Windows.Forms.Padding(0);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(31, 35);
            this.goButton.TabIndex = 2;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // searchBar_left_image
            // 
            this.searchBar_left_image.Image = global::GoogleMini.Properties.Resources.Search_Left;
            this.searchBar_left_image.Location = new System.Drawing.Point(51, 10);
            this.searchBar_left_image.Margin = new System.Windows.Forms.Padding(0);
            this.searchBar_left_image.Name = "searchBar_left_image";
            this.searchBar_left_image.Size = new System.Drawing.Size(35, 35);
            this.searchBar_left_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.searchBar_left_image.TabIndex = 3;
            this.searchBar_left_image.TabStop = false;
            // 
            // searchBar_right_image
            // 
            this.searchBar_right_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar_right_image.Image = global::GoogleMini.Properties.Resources.Search_Right;
            this.searchBar_right_image.Location = new System.Drawing.Point(651, 10);
            this.searchBar_right_image.Margin = new System.Windows.Forms.Padding(0);
            this.searchBar_right_image.Name = "searchBar_right_image";
            this.searchBar_right_image.Size = new System.Drawing.Size(35, 35);
            this.searchBar_right_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.searchBar_right_image.TabIndex = 5;
            this.searchBar_right_image.TabStop = false;
            // 
            // searchBar_middle_image
            // 
            this.searchBar_middle_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchBar_middle_image.Image = global::GoogleMini.Properties.Resources.Search_Middle;
            this.searchBar_middle_image.Location = new System.Drawing.Point(86, 10);
            this.searchBar_middle_image.Margin = new System.Windows.Forms.Padding(0);
            this.searchBar_middle_image.Name = "searchBar_middle_image";
            this.searchBar_middle_image.Size = new System.Drawing.Size(565, 35);
            this.searchBar_middle_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchBar_middle_image.TabIndex = 4;
            this.searchBar_middle_image.TabStop = false;
            // 
            // childContainerPanel
            // 
            this.childContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childContainerPanel.Location = new System.Drawing.Point(0, 61);
            this.childContainerPanel.Name = "childContainerPanel";
            this.childContainerPanel.Size = new System.Drawing.Size(725, 452);
            this.childContainerPanel.TabIndex = 3;
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(222)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(725, 513);
            this.Controls.Add(this.childContainerPanel);
            this.Controls.Add(this.toolbarPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "ShellForm";
            this.Text = "Google Mini";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellForm_FormClosing);
            this.Load += new System.EventHandler(this.ShellForm_Load);
            this.toolbarPanel.ResumeLayout(false);
            this.toolbarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_left_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_right_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBar_middle_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox urlNsearchTextbox;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.PictureBox searchBar_left_image;
        private System.Windows.Forms.PictureBox searchBar_right_image;
        private System.Windows.Forms.PictureBox searchBar_middle_image;
        private System.Windows.Forms.Panel childContainerPanel;
        private NoFocusCuesButton homeButton;
        private NoFocusCuesButton goButton;
    }
}