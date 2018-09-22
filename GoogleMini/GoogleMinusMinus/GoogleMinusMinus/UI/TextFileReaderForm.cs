using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoogleMini.UI
{
    public partial class TextFileReaderForm : Form
    {
        public TextFileReaderForm(SearchResultItemModel searchResultItemModel)
        {
            InitializeComponent();
            Text = searchResultItemModel.FileName;
            richTextBox.Text = File.ReadAllText(searchResultItemModel.FilePath);           
            richTextBox.Find(searchResultItemModel.SearchText, searchResultItemModel.CharIndex, -1, RichTextBoxFinds.WholeWord);
            richTextBox.SelectionBackColor = Color.Yellow;
            richTextBox.SelectionColor = Color.Black;
            richTextBox.SelectionStart = searchResultItemModel.CharIndex;
            richTextBox.SelectionLength = 0;
            richTextBox.ScrollToCaret();
        }        
    }
}
