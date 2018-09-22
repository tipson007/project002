using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using GoogleMini.HTMLProcessing;
using System.Security.Authentication;

namespace GoogleMini.UI
{
    public partial class WebCodeView : UserControl
    {
        private enum WebCodeViewState { Loading, PageAvailable, Error }
        private int loadingDots;
        private string pageUri;

        public event EventHandler SearchIndex;

        public WebCodeView(string pageUri)
        {
            InitializeComponent();
            this.pageUri = pageUri;
            SwitchState(WebCodeViewState.Loading);
        }

        private void SwitchState(WebCodeViewState webCodeViewState)
        {
            tagsPanel.Visible = errorMsgLabel.Visible = loadingLabel.Visible = false;
            tagsPanel.Dock = errorMsgLabel.Dock = loadingLabel.Dock = DockStyle.None;

            switch (webCodeViewState)
            {
                case WebCodeViewState.Loading:
                    loadingTimer.Enabled = true;
                    loadingLabel.Visible = true;
                    loadingLabel.Dock = DockStyle.Fill;
                    break;
                case WebCodeViewState.PageAvailable:
                    loadingTimer.Enabled = false;
                    tagsPanel.Visible = true;
                    tagsPanel.Dock = DockStyle.Fill;
                    break;
                case WebCodeViewState.Error:
                    loadingTimer.Enabled = false;
                    errorMsgLabel.Visible = true;
                    errorMsgLabel.Dock = DockStyle.Fill;
                    break;
            }
        }

        private async void HTMLViewControl_Load(object sender, EventArgs e)
        {                        
            try
            {
                var htmlProcessor = new HTMLProcessor(pageUri);                
                var titleTagText = await htmlProcessor.GetTitleTag();
                var anchorTagsText = string.Join("\n\n", await htmlProcessor.GetAnchorTags());
                var scriptTagsText = string.Join("\n\n", await htmlProcessor.GetScriptTags());

                if ((new[] { titleTagText, anchorTagsText, scriptTagsText }).All(string.IsNullOrEmpty))
                {
                    errorMsgLabel.Text = $"I genuinely believe \"{pageUri}\" isn't a web page";
                    SwitchState(WebCodeViewState.Error);
                }
                else
                {
                    titleHtmlTextBox.SetHTML(titleTagText);
                    linksHtmlTextBox.SetHTML(anchorTagsText);
                    scriptsHtmlTextBox.SetHTML(scriptTagsText);
                    SwitchState(WebCodeViewState.PageAvailable);
                }
            }
            catch (InvalidOperationException)
            {
                errorMsgLabel.Text = "An invalid request URI was provided.The request URI must be an absolute URI.\n e.g http://google.com";
                SwitchState(WebCodeViewState.Error);
            }
            catch (Exception ex)
            {
                errorMsgLabel.Text = ex.Message;
                SwitchState(WebCodeViewState.Error);
            }
        }

        private void SearchIndexButton_Click(object sender, EventArgs e)
        {
            SearchIndex?.Invoke(this, EventArgs.Empty);
        }

        private void SearchIndexButton_MouseEnter(object sender, EventArgs e)
        {
            searchIndexButton.ForeColor = Color.White;
            searchIndexButton.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
        }

        private void SearchIndexButton_MouseLeave(object sender, EventArgs e)
        {
            searchIndexButton.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            loadingDots++;
            loadingDots %= 4;
            loadingLabel.Text = "Loading" + new string('.', loadingDots) + new string(' ', 3 - loadingDots);
        }
    }
}
