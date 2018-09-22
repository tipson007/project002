using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using GoogleMini.TextProcessing;
using GoogleMini.FolderManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMini.Util;

namespace GoogleMini.UI
{
    public partial class SearchResultsView : UserControl
    {
        private enum SearchResultsViewState { Loading, ResultsAvailable }

        private const int MaxNumofPageButtonsShown = 10, ResultsPerPage = 10, MaxNumOfCharsInContext = 200;

        private readonly TextFileProcessor textFileProcessor;
        private readonly FolderManager folderManager;
        private readonly string searchText;
        private List<WordOccurrence> searchResults;
        private int currentPage, numOfPages, loadingDots;

        public delegate void SearchItemClickedEventHandler(SearchResultsView sender, SearchResultItemModel searchResult);
        public event EventHandler LoadAsWebPage;
        public event SearchItemClickedEventHandler SearchItemClicked;

        public SearchResultsView(TextFileProcessor textFileProcessor, FolderManager folderManager, string searchText)
        {
            InitializeComponent();
            this.textFileProcessor = textFileProcessor;
            this.folderManager = folderManager;
            this.searchText = searchText.Split().FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
            noResultLabel.Visible = resultCountLabel.Visible = false;
            previousButton.Visible = nextButton.Visible = false;
            SwitchState(SearchResultsViewState.Loading);
        }

        private void SwitchState(SearchResultsViewState state)
        {
            resultsPanel.Visible = pagerPanel.Visible = resultCountLabel.Visible = loadingLabel.Visible = false;
            resultsPanel.Dock = pagerPanel.Dock = resultCountLabel.Dock = loadingLabel.Dock = DockStyle.None;

            switch (state)
            {
                case SearchResultsViewState.Loading:
                    loadingTimer.Enabled = true;
                    loadingLabel.Visible = true;
                    loadingLabel.Dock = DockStyle.Fill;
                    break;
                case SearchResultsViewState.ResultsAvailable:
                    loadingTimer.Enabled = false;
                    resultCountLabel.Dock = DockStyle.Top;
                    resultsPanel.Visible = true;
                    resultsPanel.Dock = DockStyle.Fill;
                    pagerPanel.Visible = true;
                    pagerPanel.Dock = DockStyle.Bottom;
                    break;
            }
        }

        private async void SearchResultsControl_Load(object sender, EventArgs e)
        {
            searchResults = await Task.Run(() => textFileProcessor.SearchIndex(searchText));
            searchResults = searchResults.OrderBy(s => s.FileId).ToList();
            SwitchState(SearchResultsViewState.ResultsAvailable);
            if (searchResults.Any())
            {
                currentPage = 1;
                BuildPager();
                await BuildResultListing();
            }
            else
            {
                resultCountLabel.Visible = false;
                pagerPanel.Visible = false;
                noResultLabel.Visible = true;
                noResultLabel.Text = $"Your search - {searchText} - did not match any documents.\n\nSuggestions:\n    \u2022 Make sure that the word is spelled correctly.";
                resultsPanel.Controls.Add(noResultLabel);
            }
        }

        private void BuildPager()
        {
            numOfPages = (int)Math.Ceiling((double)searchResults.Count / ResultsPerPage);
            resultCountLabel.Visible = true;
            resultCountLabel.Text = (numOfPages == 1 ? $"Your search for \"{searchText}\" returned " : $"page {currentPage} of ") + $"{searchResults.Count.ToString("n0")} result" + (searchResults.Count > 1 ? "s" : "");

            if (numOfPages < 2)
            {
                pagerPanel.Visible = false;
                return;
            }

            var minPageNumber = Math.Max(1, currentPage - MaxNumofPageButtonsShown / 2);
            var maxPageNumber = Math.Min(1 + numOfPages - minPageNumber, minPageNumber + MaxNumofPageButtonsShown - 1);

            pagerPanel.SuspendLayout();
            pagerPanel.Controls.Clear();
            
            pagerPanel.Controls.Add(pagesLabel);
            pagerPanel.Controls.Add(previousButton);            
            previousButton.Visible = (currentPage != 1);

            for (var pageNum = minPageNumber; pageNum <= maxPageNumber; ++pageNum)
            {
                var pageButton = new Button
                {
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11.25F, pageNum == currentPage ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, 0),
                    ForeColor = Color.FromArgb(66, 133, 244),
                    Size = new Size(27, 32),
                    Text = $"{pageNum}",
                    UseVisualStyleBackColor = true,
                    Tag = pageNum
                };

                pageButton.FlatAppearance.BorderSize = 0;
                pageButton.MouseEnter += PageButton_MouseEnter;
                pageButton.MouseLeave += PageButton_MouseLeave;
                pageButton.Click += PageButton_Click;

                pagerPanel.Controls.Add(pageButton);
            }

            pagerPanel.Controls.Add(nextButton);            
            nextButton.Visible = (currentPage != numOfPages);

            pagerPanel.ResumeLayout();
        }

        private async Task BuildResultListing()
        {
            var models = new List<SearchResultItemModel>();
            var resultsInfoToShow = LinqExtensions.Skip(searchResults, (currentPage - 1) * ResultsPerPage).Take(ResultsPerPage).ToList();
            var fileIdToPathMap = await Task.Run(() => folderManager.GetFilePathsFromIds(resultsInfoToShow.Select(x => x.FileId).ToArray()));

            foreach (var resultInfo in resultsInfoToShow)
            {
                if (fileIdToPathMap.TryGetValue(resultInfo.FileId, out string filePath) && File.Exists(filePath))
                {
                    var (context, wordIndexInContext) = await WordContext.GetContext(filePath, searchText, resultInfo.CharIndex);
                    var sr = new SearchResultItemModel
                    {
                        ColumnNumber = resultInfo.ColumnNumber,
                        LineNumber = resultInfo.LineNumber,
                        CharIndex = resultInfo.CharIndex,
                        FileName = Path.GetFileName(filePath),
                        SearchText = searchText,
                        FilePath = filePath,
                        Context = context,
                        WordIndexInContext = wordIndexInContext
                    };
                    models.Add(sr);
                }
            }


            var factor = resultsPanel.ClientSize.Width < Screen.PrimaryScreen.Bounds.Width / 2 ? 1 : 0.75;
            resultsPanel.SuspendLayout();
            resultsPanel.Controls.Clear();
            foreach (var item in models)
            {
                var srItem = new SearchResultItem(item)
                {
                    Margin = new Padding(8, 0, 0, 8),
                    Width = (int)(resultsPanel.ClientSize.Width * factor)
                };
                srItem.LinkFollowed += SrItem_LinkFollowed;
                resultsPanel.Controls.Add(srItem);
            }
            resultsPanel.ResumeLayout();
        }

        private void SrItem_LinkFollowed(SearchResultItem sender, SearchResultItemModel searchResult)
        {
            SearchItemClicked?.Invoke(this, searchResult);
        }

        private void LoadAsWebPageButton_Click(object sender, EventArgs e)
        {
            LoadAsWebPage?.Invoke(this, EventArgs.Empty);
        }

        private void LoadAsWebPageButton_MouseEnter(object sender, EventArgs e)
        {
            loadAsWebPageButton.ForeColor = Color.White;
            loadAsWebPageButton.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
        }

        private void LoadAsWebPageButton_MouseLeave(object sender, EventArgs e)
        {
            loadAsWebPageButton.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void SearchResultsControl_Resize(object sender, EventArgs e)
        {
            resultCountLabel.MaximumSize = new Size(ClientSize.Width, 0);
            var factor = resultsPanel.ClientSize.Width < Screen.PrimaryScreen.Bounds.Width / 2 ? 1 : 0.75;
            foreach (Control item in resultsPanel.Controls)
            {
                item.Width = (int)(resultsPanel.ClientSize.Width * factor);
            }
        }

        private async void PreviousButton_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
                return;
            --currentPage;
            BuildPager();
            await BuildResultListing();
        }

        private async void NextButton_Click(object sender, EventArgs e)
        {
            if (currentPage == numOfPages)
                return;
            ++currentPage;
            BuildPager();
            await BuildResultListing();
        }

        private async void PageButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var pageNumber = (int)btn.Tag;
            if (pageNumber == currentPage || pageNumber < 0 || pageNumber > numOfPages)
                return;
            currentPage = pageNumber;
            BuildPager();
            await BuildResultListing();
        }

        private void PageButton_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var pageNumber = (int)btn.Tag;
            var fontStyle = FontStyle.Underline;
            if (pageNumber == currentPage)
                fontStyle |= FontStyle.Bold;
            btn.Font = new Font(btn.Font, fontStyle);
        }

        private void PageButton_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var pageNumber = (int)btn.Tag;
            var fontStyle = FontStyle.Regular;
            if (pageNumber == currentPage)
                fontStyle |= FontStyle.Bold;
            btn.Font = new Font(btn.Font, fontStyle);
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            loadingDots++;
            loadingDots %= 4;
            loadingLabel.Text = "Loading" + new string('.', loadingDots) + new string(' ', 3 - loadingDots);
        }
    }
}
