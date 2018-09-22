using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoogleMini.UI
{
    public partial class SearchResultItem : UserControl
    {        
        private readonly SearchResultItemModel searchResult;

        public delegate void LinkFollowedEventHandler(SearchResultItem sender, SearchResultItemModel searchResult);

        public event LinkFollowedEventHandler LinkFollowed;        

        public SearchResultItem(SearchResultItemModel searchResult)
        {
            this.searchResult = searchResult;
            InitializeComponent();
            titleLabel.Text = searchResult.FileName;
            pathLabel.Text = searchResult.FilePath;
            locationLabel.Text = $"Line number {searchResult.LineNumber} \t Column {searchResult.ColumnNumber}";
            contextRichTextBox.Text = searchResult.Context;
            contextRichTextBox.Find(searchResult.SearchText, searchResult.WordIndexInContext, -1, RichTextBoxFinds.WholeWord);
            contextRichTextBox.SelectionBackColor = Color.Yellow;
            contextRichTextBox.SelectionColor = Color.Black;            
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {
            titleLabel.ForeColor = Color.FromArgb(102, 0, 153);
            LinkFollowed?.Invoke(this, searchResult);
        }

        private void TitleLabel_MouseEnter(object sender, EventArgs e)
        {
            titleLabel.Font = new Font(titleLabel.Font.Name, titleLabel.Font.SizeInPoints, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
        }

        private void TitleLabel_MouseLeave(object sender, EventArgs e)
        {
            titleLabel.Font = new Font(titleLabel.Font.Name, titleLabel.Font.SizeInPoints, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        private void SearchResultItem_Resize(object sender, EventArgs e)
        {
            titleLabel.MaximumSize = pathLabel.MaximumSize = locationLabel.MaximumSize = new Size(ClientSize.Width, 0);
            contextRichTextBox.Width = ClientSize.Width;
        }

        private void ContextRichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            contextRichTextBox.Size = new Size(e.NewRectangle.Width, e.NewRectangle.Height + 4);
        }

        private void SearchResultItem_Layout(object sender, LayoutEventArgs e)
        {
            pathLabel.Top = titleLabel.Top + titleLabel.Height + 2;
            contextRichTextBox.Top = pathLabel.Top + pathLabel.Height + 2;
            locationLabel.Top = contextRichTextBox.Top + contextRichTextBox.Height;
            Height = locationLabel.Top + locationLabel.Height + 1;
        }
    }

    public class SearchResultItemModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int CharIndex { get; set; }
        public string Context { get; set; }
        public int WordIndexInContext { get; set; }
        public string SearchText { get; set; }
    }
}
