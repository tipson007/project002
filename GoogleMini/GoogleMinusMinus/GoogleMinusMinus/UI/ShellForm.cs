using System;
using System.Linq;
using System.Windows.Forms;
using GoogleMini.DataStore;
using GoogleMini.FolderManagement;
using GoogleMini.TextProcessing;
using GoogleMini.Util;

namespace GoogleMini.UI
{
    public partial class ShellForm : Form
    {
        private IncrementalIdentityStore identityStore;
        private TextFileProcessor textFileProcessor;
        private FolderManager folderManager;        

        public ShellForm(TextFileProcessor textFileProcessor, FolderManager folderManager, IncrementalIdentityStore identityStore)
        {
            InitializeComponent();
            
            this.identityStore = identityStore;
            this.folderManager = folderManager;
            this.textFileProcessor = textFileProcessor;            

            Load += (s, e) =>
            {
                searchBar_middle_image.Width = searchBar_right_image.Left - searchBar_middle_image.Left + 3;
                urlNsearchTextbox.Width = searchBar_middle_image.Width - 3;
            };
            Resize += (s, e) =>
            {
                searchBar_middle_image.Width = searchBar_right_image.Left - searchBar_middle_image.Left + 3;
                urlNsearchTextbox.Width = searchBar_middle_image.Width - 3;
            };
            homeButton.MouseEnter += (s, e) => homeButton.BackgroundImage = Properties.Resources.Home_Enter;
            homeButton.MouseLeave += (s, e) => homeButton.BackgroundImage = Properties.Resources.Home_Leave;
            homeButton.MouseDown += (s, e) => homeButton.BackgroundImage = Properties.Resources.Home_Press;
            homeButton.MouseUp += (s, e) => homeButton.BackgroundImage = Properties.Resources.Home_Leave;

            goButton.MouseEnter += (s, e) => goButton.BackgroundImage = Properties.Resources.Search_Enter;
            goButton.MouseLeave += (s, e) => goButton.BackgroundImage = Properties.Resources.Search_Leave;
            goButton.MouseDown += (s, e) => goButton.BackgroundImage = Properties.Resources.Search_Press;
            goButton.MouseUp += (s, e) => goButton.BackgroundImage = Properties.Resources.Search_Leave;
        }

        private void LoadNewView(Control control)
        {
            if (childContainerPanel.Controls.Count > 0)
            {
                var currentView = childContainerPanel.Controls[0];
                childContainerPanel.Controls.Clear();
                currentView.Dispose();
            }
            control.Width = childContainerPanel.ClientSize.Width;
            control.Dock = DockStyle.Fill;
            childContainerPanel.Controls.Add(control);
        }

        private void ShellForm_Load(object sender, EventArgs e)
        {
            homeButton.PerformClick();
        }

        private void ShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            folderManager?.Dispose();
            textFileProcessor?.Dispose();
            identityStore?.Dispose();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (childContainerPanel.Controls.OfType<HomeView>().Any())
                return;
            LoadNewView(new HomeView(textFileProcessor, folderManager));
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            var searchText = urlNsearchTextbox.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
                return;
            var isUri = Uri.IsWellFormedUriString(searchText, UriKind.Absolute);
            if (isUri)
            {
                LoadWebPage(searchText);
            }
            else
            {
                SearchIndex(searchText);
            }
        }

        private void UrlNsearchTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                goButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LoadWebPage(string searchText)
        {
            var htmlViewControl = new WebCodeView(searchText);
            htmlViewControl.SearchIndex += (s, e) => SearchIndex(searchText);
            LoadNewView(htmlViewControl);
        }

        private void SearchIndex(string searchText)
        {
            var searchResultsControl = new SearchResultsView(textFileProcessor, folderManager, searchText);
            searchResultsControl.LoadAsWebPage += (s, e) => LoadWebPage(searchText);
            searchResultsControl.SearchItemClicked += (s, e) => OpenTextFile(e);
            LoadNewView(searchResultsControl);
        }

        private void OpenTextFile(SearchResultItemModel searchResultItemModel)
        {
            var factor = ClientSize.Width < Screen.PrimaryScreen.Bounds.Width / 2 ? 1 : 0.5;
            using (var dlg = new TextFileReaderForm(searchResultItemModel))
            {
                dlg.Width = (int)(Width * factor);
                dlg.ShowDialog(this);
            }
        }
    }
}
