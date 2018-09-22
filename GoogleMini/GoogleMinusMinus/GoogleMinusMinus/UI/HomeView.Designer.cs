namespace GoogleMini.UI
{
    partial class HomeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;        

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.refreshStatsButton = new System.Windows.Forms.Button();
            this.statTitleLabel = new System.Windows.Forms.Label();
            this.leastFrequentWordIndexedLabel = new System.Windows.Forms.Label();
            this.mostFrequentWordIndexedLabel = new System.Windows.Forms.Label();
            this.shortestWordIndexedLabel = new System.Windows.Forms.Label();
            this.longestWordIndexedLabel = new System.Windows.Forms.Label();
            this.totalWordsIndexedLabel = new System.Windows.Forms.Label();
            this.leastFrequentWordIndexedTitle = new System.Windows.Forms.Label();
            this.mostFrequentWordIndexedTitle = new System.Windows.Forms.Label();
            this.shortestWordIndexedTitle = new System.Windows.Forms.Label();
            this.longestWordIndexedTitle = new System.Windows.Forms.Label();
            this.totalWordsIndexedTitle = new System.Windows.Forms.Label();
            this.watchedFoldersListView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateAddedHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listviewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateAddedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.pathStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trackNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalUniqueWordsIndexedLabel = new System.Windows.Forms.Label();
            this.totalUniqueWordsIndexedTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.listviewContextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.Black;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.totalUniqueWordsIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.totalUniqueWordsIndexedTitle);
            this.splitContainer.Panel1.Controls.Add(this.refreshStatsButton);
            this.splitContainer.Panel1.Controls.Add(this.statTitleLabel);
            this.splitContainer.Panel1.Controls.Add(this.leastFrequentWordIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.mostFrequentWordIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.shortestWordIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.longestWordIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.totalWordsIndexedLabel);
            this.splitContainer.Panel1.Controls.Add(this.leastFrequentWordIndexedTitle);
            this.splitContainer.Panel1.Controls.Add(this.mostFrequentWordIndexedTitle);
            this.splitContainer.Panel1.Controls.Add(this.shortestWordIndexedTitle);
            this.splitContainer.Panel1.Controls.Add(this.longestWordIndexedTitle);
            this.splitContainer.Panel1.Controls.Add(this.totalWordsIndexedTitle);
            this.splitContainer.Panel1.Resize += new System.EventHandler(this.SplitContainer_Panel1_Resize);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.watchedFoldersListView);
            this.splitContainer.Panel2.Controls.Add(this.statusStrip);
            this.splitContainer.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer.Size = new System.Drawing.Size(839, 531);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 0;
            // 
            // refreshStatsButton
            // 
            this.refreshStatsButton.Location = new System.Drawing.Point(17, 394);
            this.refreshStatsButton.Name = "refreshStatsButton";
            this.refreshStatsButton.Size = new System.Drawing.Size(113, 27);
            this.refreshStatsButton.TabIndex = 11;
            this.refreshStatsButton.Text = "Refresh Statistics";
            this.refreshStatsButton.UseVisualStyleBackColor = true;
            this.refreshStatsButton.Click += new System.EventHandler(this.RefreshStatsButton_Click);
            // 
            // statTitleLabel
            // 
            this.statTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statTitleLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.statTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.statTitleLabel.Name = "statTitleLabel";
            this.statTitleLabel.Size = new System.Drawing.Size(305, 47);
            this.statTitleLabel.TabIndex = 10;
            this.statTitleLabel.Text = "Statistics";
            this.statTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leastFrequentWordIndexedLabel
            // 
            this.leastFrequentWordIndexedLabel.AutoSize = true;
            this.leastFrequentWordIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leastFrequentWordIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.leastFrequentWordIndexedLabel.Location = new System.Drawing.Point(13, 356);
            this.leastFrequentWordIndexedLabel.Name = "leastFrequentWordIndexedLabel";
            this.leastFrequentWordIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.leastFrequentWordIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.leastFrequentWordIndexedLabel.TabIndex = 9;
            this.leastFrequentWordIndexedLabel.Text = " ";
            this.leastFrequentWordIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mostFrequentWordIndexedLabel
            // 
            this.mostFrequentWordIndexedLabel.AutoSize = true;
            this.mostFrequentWordIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostFrequentWordIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.mostFrequentWordIndexedLabel.Location = new System.Drawing.Point(13, 274);
            this.mostFrequentWordIndexedLabel.Name = "mostFrequentWordIndexedLabel";
            this.mostFrequentWordIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.mostFrequentWordIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.mostFrequentWordIndexedLabel.TabIndex = 8;
            this.mostFrequentWordIndexedLabel.Text = " ";
            this.mostFrequentWordIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shortestWordIndexedLabel
            // 
            this.shortestWordIndexedLabel.AutoSize = true;
            this.shortestWordIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortestWordIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.shortestWordIndexedLabel.Location = new System.Drawing.Point(13, 210);
            this.shortestWordIndexedLabel.Name = "shortestWordIndexedLabel";
            this.shortestWordIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.shortestWordIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.shortestWordIndexedLabel.TabIndex = 7;
            this.shortestWordIndexedLabel.Text = " ";
            this.shortestWordIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // longestWordIndexedLabel
            // 
            this.longestWordIndexedLabel.AutoSize = true;
            this.longestWordIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longestWordIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.longestWordIndexedLabel.Location = new System.Drawing.Point(13, 149);
            this.longestWordIndexedLabel.Name = "longestWordIndexedLabel";
            this.longestWordIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.longestWordIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.longestWordIndexedLabel.TabIndex = 6;
            this.longestWordIndexedLabel.Text = " ";
            this.longestWordIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalWordsIndexedLabel
            // 
            this.totalWordsIndexedLabel.AutoSize = true;
            this.totalWordsIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalWordsIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.totalWordsIndexedLabel.Location = new System.Drawing.Point(5, 90);
            this.totalWordsIndexedLabel.Name = "totalWordsIndexedLabel";
            this.totalWordsIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.totalWordsIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.totalWordsIndexedLabel.TabIndex = 5;
            this.totalWordsIndexedLabel.Text = " ";
            this.totalWordsIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leastFrequentWordIndexedTitle
            // 
            this.leastFrequentWordIndexedTitle.AutoSize = true;
            this.leastFrequentWordIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leastFrequentWordIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.leastFrequentWordIndexedTitle.Location = new System.Drawing.Point(11, 322);
            this.leastFrequentWordIndexedTitle.Name = "leastFrequentWordIndexedTitle";
            this.leastFrequentWordIndexedTitle.Size = new System.Drawing.Size(221, 21);
            this.leastFrequentWordIndexedTitle.TabIndex = 4;
            this.leastFrequentWordIndexedTitle.Text = "Least frequent word indexed";
            // 
            // mostFrequentWordIndexedTitle
            // 
            this.mostFrequentWordIndexedTitle.AutoSize = true;
            this.mostFrequentWordIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostFrequentWordIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.mostFrequentWordIndexedTitle.Location = new System.Drawing.Point(11, 249);
            this.mostFrequentWordIndexedTitle.Name = "mostFrequentWordIndexedTitle";
            this.mostFrequentWordIndexedTitle.Size = new System.Drawing.Size(221, 21);
            this.mostFrequentWordIndexedTitle.TabIndex = 3;
            this.mostFrequentWordIndexedTitle.Text = "Most frequent word indexed";
            // 
            // shortestWordIndexedTitle
            // 
            this.shortestWordIndexedTitle.AutoSize = true;
            this.shortestWordIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortestWordIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.shortestWordIndexedTitle.Location = new System.Drawing.Point(11, 185);
            this.shortestWordIndexedTitle.Name = "shortestWordIndexedTitle";
            this.shortestWordIndexedTitle.Size = new System.Drawing.Size(177, 21);
            this.shortestWordIndexedTitle.TabIndex = 2;
            this.shortestWordIndexedTitle.Text = "Shortest word indexed";
            // 
            // longestWordIndexedTitle
            // 
            this.longestWordIndexedTitle.AutoSize = true;
            this.longestWordIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longestWordIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.longestWordIndexedTitle.Location = new System.Drawing.Point(11, 124);
            this.longestWordIndexedTitle.Name = "longestWordIndexedTitle";
            this.longestWordIndexedTitle.Size = new System.Drawing.Size(174, 21);
            this.longestWordIndexedTitle.TabIndex = 1;
            this.longestWordIndexedTitle.Text = "Longest word indexed";
            // 
            // totalWordsIndexedTitle
            // 
            this.totalWordsIndexedTitle.AutoSize = true;
            this.totalWordsIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalWordsIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.totalWordsIndexedTitle.Location = new System.Drawing.Point(3, 65);
            this.totalWordsIndexedTitle.Name = "totalWordsIndexedTitle";
            this.totalWordsIndexedTitle.Size = new System.Drawing.Size(238, 21);
            this.totalWordsIndexedTitle.TabIndex = 0;
            this.totalWordsIndexedTitle.Text = "Total number of words indexed";
            // 
            // watchedFoldersListView
            // 
            this.watchedFoldersListView.AllowColumnReorder = true;
            this.watchedFoldersListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.watchedFoldersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.pathHeader,
            this.dateAddedHeader});
            this.watchedFoldersListView.ContextMenuStrip = this.listviewContextMenuStrip;
            this.watchedFoldersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.watchedFoldersListView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchedFoldersListView.FullRowSelect = true;
            this.watchedFoldersListView.LargeImageList = this.largeImageList;
            this.watchedFoldersListView.Location = new System.Drawing.Point(0, 24);
            this.watchedFoldersListView.Name = "watchedFoldersListView";
            this.watchedFoldersListView.ShowItemToolTips = true;
            this.watchedFoldersListView.Size = new System.Drawing.Size(535, 485);
            this.watchedFoldersListView.SmallImageList = this.smallImageList;
            this.watchedFoldersListView.TabIndex = 1;
            this.watchedFoldersListView.UseCompatibleStateImageBehavior = false;
            this.watchedFoldersListView.View = System.Windows.Forms.View.Tile;
            this.watchedFoldersListView.SelectedIndexChanged += new System.EventHandler(this.WatchedFoldersListView_SelectedIndexChanged);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = -2;
            // 
            // pathHeader
            // 
            this.pathHeader.Text = "Path";
            this.pathHeader.Width = -2;
            // 
            // dateAddedHeader
            // 
            this.dateAddedHeader.Text = "Date added";
            this.dateAddedHeader.Width = -2;
            // 
            // listviewContextMenuStrip
            // 
            this.listviewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.sortByToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.listviewContextMenuStrip.Name = "listviewContextMenuStrip";
            this.listviewContextMenuStrip.Size = new System.Drawing.Size(114, 70);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.tilesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Checked = true;
            this.largeIconsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.largeIconsToolStripMenuItem.Text = "La&rge icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem.Text = "Small ico&ns";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.SmallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem.Text = "&List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.detailsToolStripMenuItem.Text = "&Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.DetailsToolStripMenuItem_Click);
            // 
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.tilesToolStripMenuItem.Text = "Tile&s";
            this.tilesToolStripMenuItem.Click += new System.EventHandler(this.TilesToolStripMenuItem_Click);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.dateAddedToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.sortByToolStripMenuItem.Text = "S&ort by";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Checked = true;
            this.nameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.NameToolStripMenuItem_Click);
            // 
            // dateAddedToolStripMenuItem
            // 
            this.dateAddedToolStripMenuItem.Name = "dateAddedToolStripMenuItem";
            this.dateAddedToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.dateAddedToolStripMenuItem.Text = "Date added";
            this.dateAddedToolStripMenuItem.Click += new System.EventHandler(this.DateAddedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Checked = true;
            this.ascendingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ascendingToolStripMenuItem.Text = "&Ascending";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.AscendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descendingToolStripMenuItem.Text = "&Descending";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.DescendingToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "R&efresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // largeImageList
            // 
            this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeImageList.Images.SetKeyName(0, "folder_blue.png");
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "folder_blue.png");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 509);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(535, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // pathStripStatusLabel
            // 
            this.pathStripStatusLabel.Name = "pathStripStatusLabel";
            this.pathStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackNewFolderToolStripMenuItem,
            this.stopTrackingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trackNewFolderToolStripMenuItem
            // 
            this.trackNewFolderToolStripMenuItem.Name = "trackNewFolderToolStripMenuItem";
            this.trackNewFolderToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.trackNewFolderToolStripMenuItem.Text = "Watch New Folder";
            this.trackNewFolderToolStripMenuItem.Click += new System.EventHandler(this.TrackNewFolderToolStripMenuItem_Click);
            // 
            // stopTrackingToolStripMenuItem
            // 
            this.stopTrackingToolStripMenuItem.Enabled = false;
            this.stopTrackingToolStripMenuItem.Name = "stopTrackingToolStripMenuItem";
            this.stopTrackingToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.stopTrackingToolStripMenuItem.Text = "Stop Watching";
            this.stopTrackingToolStripMenuItem.Click += new System.EventHandler(this.StopTrackingToolStripMenuItem_Click);
            // 
            // totalUniqueWordsIndexedLabel
            // 
            this.totalUniqueWordsIndexedLabel.AutoSize = true;
            this.totalUniqueWordsIndexedLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalUniqueWordsIndexedLabel.ForeColor = System.Drawing.Color.Black;
            this.totalUniqueWordsIndexedLabel.Location = new System.Drawing.Point(15, 472);
            this.totalUniqueWordsIndexedLabel.Name = "totalUniqueWordsIndexedLabel";
            this.totalUniqueWordsIndexedLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.totalUniqueWordsIndexedLabel.Size = new System.Drawing.Size(29, 20);
            this.totalUniqueWordsIndexedLabel.TabIndex = 13;
            this.totalUniqueWordsIndexedLabel.Text = " ";
            this.totalUniqueWordsIndexedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalUniqueWordsIndexedTitle
            // 
            this.totalUniqueWordsIndexedTitle.AutoSize = true;
            this.totalUniqueWordsIndexedTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalUniqueWordsIndexedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.totalUniqueWordsIndexedTitle.Location = new System.Drawing.Point(13, 447);
            this.totalUniqueWordsIndexedTitle.Name = "totalUniqueWordsIndexedTitle";
            this.totalUniqueWordsIndexedTitle.Size = new System.Drawing.Size(292, 21);
            this.totalUniqueWordsIndexedTitle.TabIndex = 12;
            this.totalUniqueWordsIndexedTitle.Text = "Total number of unique words indexed";
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HomeView";
            this.Size = new System.Drawing.Size(839, 531);
            this.Resize += new System.EventHandler(this.HomeControl_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.listviewContextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

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

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label leastFrequentWordIndexedTitle;
        private System.Windows.Forms.Label mostFrequentWordIndexedTitle;
        private System.Windows.Forms.Label shortestWordIndexedTitle;
        private System.Windows.Forms.Label longestWordIndexedTitle;
        private System.Windows.Forms.Label totalWordsIndexedTitle;
        private System.Windows.Forms.Label leastFrequentWordIndexedLabel;
        private System.Windows.Forms.Label mostFrequentWordIndexedLabel;
        private System.Windows.Forms.Label shortestWordIndexedLabel;
        private System.Windows.Forms.Label longestWordIndexedLabel;
        private System.Windows.Forms.Label totalWordsIndexedLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trackNewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTrackingToolStripMenuItem;
        private System.Windows.Forms.ListView watchedFoldersListView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader pathHeader;
        private System.Windows.Forms.ColumnHeader dateAddedHeader;
        private System.Windows.Forms.Label statTitleLabel;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ContextMenuStrip listviewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateAddedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel pathStripStatusLabel;
        private System.Windows.Forms.Button refreshStatsButton;
        private System.Windows.Forms.Label totalUniqueWordsIndexedLabel;
        private System.Windows.Forms.Label totalUniqueWordsIndexedTitle;
    }
}
