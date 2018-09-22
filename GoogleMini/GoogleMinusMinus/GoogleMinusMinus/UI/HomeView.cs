using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GoogleMini.FolderManagement;
using Ookii.Dialogs;
using GoogleMini.TextProcessing;
using System.Threading.Tasks;
using GoogleMini.Util;

namespace GoogleMini.UI
{
    public partial class HomeView : UserControl
    {
        private readonly List<Label> reportLabels = new List<Label>();
        private readonly TextFileProcessor textFileProcessor;
        private readonly FolderManager folderManager;        
        private bool pendingRefreshStatsRequest;

        public HomeView(TextFileProcessor textFileProcessor, FolderManager folderManager)
        {
            InitializeComponent();
            this.textFileProcessor = textFileProcessor;
            this.folderManager = folderManager;            

            ChangeView(Properties.Settings.Default.View);
            ChangeSortAttribute(Properties.Settings.Default.SortAttribute);
            ChangeSortOrder(Properties.Settings.Default.SortOrder);
            reportLabels = new List<Label> {
                totalWordsIndexedTitle, totalWordsIndexedLabel,
                totalUniqueWordsIndexedTitle, totalUniqueWordsIndexedLabel,
                longestWordIndexedTitle, longestWordIndexedLabel,
                shortestWordIndexedTitle, shortestWordIndexedLabel,
                mostFrequentWordIndexedTitle, mostFrequentWordIndexedLabel,
                leastFrequentWordIndexedTitle, leastFrequentWordIndexedLabel
            };
            textFileProcessor.OnIdle += (s, e) =>
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)refreshStatsButton.PerformClick);
                }
            };

            LayoutReportLabels();
            FillWatchedFoldersListView();
            refreshStatsButton.PerformClick();                    
        }               

        private void LayoutReportLabels()
        {
            int margin = 2, y = 6 * margin + statTitleLabel.Height;
            for (var index = 0; index < reportLabels.Count; ++index)
            {
                var label = reportLabels[index];
                label.Location = new Point(margin, y);
                y += label.Height + (index % 2 == 0 ? 1 : 8) * margin;
            }
            refreshStatsButton.Location = new Point(margin, y);
        }

        private void UpdateDatabaseStatisticsLabels(Statistics statistics)
        {
            var stat = statistics;
            totalWordsIndexedLabel.Text = stat.TotalWordsIndexed.ToString("n0");
            totalUniqueWordsIndexedLabel.Text = stat.TotalUniqueWordsIndexed.ToString("n0");
            longestWordIndexedLabel.Text = stat.LongestWordIndexed;
            shortestWordIndexedLabel.Text = stat.ShortestWordIndexed;
            mostFrequentWordIndexedLabel.Text = stat.MostFrequentWordIndexed;
            leastFrequentWordIndexedLabel.Text = stat.LeastFrequentWordIndexed;
        }

        private async void FillWatchedFoldersListView()
        {
            var sortByName = Properties.Settings.Default.SortAttribute.ToLowerInvariant() == "name";
            Func<Folder, IComparable> sortbyFunc = (Folder folder) =>
            {
                if (sortByName)
                {
                    return folder.Name;
                }
                return folder.DateAdded;
            };

            var folders = await Task.Run(() => folderManager.GetWatchedFolders());

            IOrderedEnumerable<Folder> orderedFolders = folders.OrderBy(sortbyFunc);

            if (Properties.Settings.Default.SortOrder == SortOrder.Descending)
            {
                orderedFolders = folders.OrderByDescending(sortbyFunc);
            }

            var items = new List<ListViewItem>();
            foreach (var folder in orderedFolders)
            {
                var item = new ListViewItem(folder.Name, 0) { ImageIndex = 0 };
                item.SubItems.Add(folder.Path);
                item.SubItems.Add(folder.DateAdded.ToShortDateString());
                items.Add(item);
            }
            watchedFoldersListView.Items.Clear();
            watchedFoldersListView.Items.AddRange(items.ToArray());
            watchedFoldersListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void ChangeView(View view)
        {
            largeIconsToolStripMenuItem.Checked = false;
            detailsToolStripMenuItem.Checked = false;
            smallIconsToolStripMenuItem.Checked = false;
            listToolStripMenuItem.Checked = false;
            tilesToolStripMenuItem.Checked = false;
            switch (view)
            {
                case View.LargeIcon:
                    largeIconsToolStripMenuItem.Checked = true;
                    break;
                case View.Details:
                    detailsToolStripMenuItem.Checked = true;
                    break;
                case View.SmallIcon:
                    smallIconsToolStripMenuItem.Checked = true;
                    break;
                case View.List:
                    listToolStripMenuItem.Checked = true;
                    break;
                case View.Tile:
                    tilesToolStripMenuItem.Checked = true;
                    break;
            }
            watchedFoldersListView.View = view;
            Properties.Settings.Default.View = view;
            Properties.Settings.Default.Save();
        }

        private void ChangeSortAttribute(string attribute)
        {
            nameToolStripMenuItem.Checked = false;
            dateAddedToolStripMenuItem.Checked = false;
            attribute = attribute.ToLowerInvariant();
            if (attribute == "name")
            {
                nameToolStripMenuItem.Checked = true;
            }
            else if (attribute == "date added")
            {
                dateAddedToolStripMenuItem.Checked = true;
            }
            else
            {
                return;
            }
            Properties.Settings.Default.SortAttribute = attribute;
            Properties.Settings.Default.Save();
        }

        private void ChangeSortOrder(SortOrder order)
        {
            ascendingToolStripMenuItem.Checked = false;
            descendingToolStripMenuItem.Checked = false;
            switch (order)
            {
                case SortOrder.None:
                    break;
                case SortOrder.Ascending:
                    ascendingToolStripMenuItem.Checked = true;
                    break;
                case SortOrder.Descending:
                    descendingToolStripMenuItem.Checked = true;
                    break;
            }
            Properties.Settings.Default.SortOrder = order;
            Properties.Settings.Default.Save();
        }

        private void HomeControl_Resize(object sender, EventArgs e)
        {
            watchedFoldersListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void SplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            foreach (var label in reportLabels)
            {
                label.MaximumSize = new Size(splitContainer.Panel1.ClientSize.Width, 0);
            }
            LayoutReportLabels();
        }

        private void WatchedFoldersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopTrackingToolStripMenuItem.Enabled = watchedFoldersListView.SelectedItems.Count > 0;
            if (watchedFoldersListView.SelectedItems.Count == 1)
            {
                pathStripStatusLabel.Text = watchedFoldersListView.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                pathStripStatusLabel.Text = watchedFoldersListView.SelectedItems.Count.ToString("n0") + " items selected";
            }
        }

        private async void TrackNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new VistaFolderBrowserDialog() { ShowNewFolderButton = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var currentCursor = Cursor;
                    Cursor = Cursors.WaitCursor;
                    await Task.Run(()=> folderManager.Watch(dlg.SelectedPath));
                    Cursor = currentCursor;
                    FillWatchedFoldersListView();
                }
            }
        }

        private async void StopTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentCursor = Cursor; 
            Cursor = Cursors.WaitCursor;
            foreach (ListViewItem item in watchedFoldersListView.SelectedItems)
            {
                var path = item.SubItems[1].Text;
                await Task.Run(()=> folderManager.Unwatch(path));
            }
            Cursor = currentCursor;
            FillWatchedFoldersListView();
        }

        private void TilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeView(View.Tile);
        }

        private void LargeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeView(View.LargeIcon);
        }

        private void SmallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeView(View.SmallIcon);
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeView(View.List);
        }

        private void DetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeView(View.Details);
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillWatchedFoldersListView();
        }

        private void NameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSortAttribute("name");
            FillWatchedFoldersListView();
        }

        private void DateAddedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSortAttribute("date added");
            FillWatchedFoldersListView();
        }

        private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSortOrder(SortOrder.Ascending);
            FillWatchedFoldersListView();
        }

        private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSortOrder(SortOrder.Descending);
            FillWatchedFoldersListView();
        }

        private async void RefreshStatsButton_Click(object sender, EventArgs e)
        {
            if (pendingRefreshStatsRequest)
                return;
            pendingRefreshStatsRequest = true;
            var stats = await Task.Run(() => textFileProcessor.RecomputeStatistics());
            UpdateDatabaseStatisticsLabels(stats);
            pendingRefreshStatsRequest = false;
        }
    }
}
