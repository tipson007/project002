using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMini.UI.CustomControls.HTML
{
    public class HTMLTextBox : RichTextBox
    {
        private static Dictionary<string, Color> SyntaxColors;

        static HTMLTextBox()
        {
            SyntaxColors = new Dictionary<string, Color>
            {                
                {"js.interpolation", Color.FromArgb(163, 21, 21) },
                {"js.interpolation.open", Color.FromArgb(0, 0, 255) },
                {"js.interpolation.expression", Color.FromArgb(0, 0, 0) },
                {"js.interpolation.close", Color.FromArgb(0, 0, 255) },
                {"js.string", Color.FromArgb(163, 21, 21) },
                {"js.comment", Color.FromArgb(0, 128, 0) },
                {"js.keyword", Color.FromArgb(0, 0, 255) },
                {"js.regexp", Color.FromArgb(163, 21, 21) },
                {"js.userdatatype", Color.FromArgb(43, 145, 175) },
                {"js.regexp.modifier", Color.FromArgb(0, 0, 255) },
                {"html.attribute", Color.FromArgb(255, 0, 0) },
                {"html.operator", Color.FromArgb(0, 0, 255) },
                {"html.value", Color.FromArgb(0, 0, 255) },
                {"html.quote", Color.FromArgb(0, 0, 255) },
                {"html.tag.name", Color.FromArgb(128, 0, 0) },
                {"html.tag.<", Color.FromArgb(0, 0, 255) },
                {"html.tag.>", Color.FromArgb(0, 0, 255) },
                {"html.comment", Color.FromArgb(0, 100, 0) }
            };
        }       

        private CancellationTokenSource _renderingTaskCancellationTokenSource;
        private Task<string> _renderingTask;               

        public HTMLTextBox()
        {
            WordWrap = false;
            ReadOnly = true;
            ScrollBars = RichTextBoxScrollBars.None;            
        }

        public async void SetHTML(string htmlCode)
        {
            Text = htmlCode;                       
            StopHighlighting();
            await StartHighlighting(htmlCode);
        }

        private async Task StartHighlighting(string htmlCode)
        {
            // copy Rtf and ForeColor into local variables to avoid exception thrown when accessing UI control properties from another thread. 
            var _rtf = Rtf;
            var _defaultColor = ForeColor;

            _renderingTaskCancellationTokenSource = new CancellationTokenSource();
            var token = _renderingTaskCancellationTokenSource.Token;
            var syntaxHighlighter = new SyntaxHighlighter(htmlCode, HTMLSyntaxHighlighter.HighlightDescriptors, token);            
            _renderingTask = Task.Run(() => syntaxHighlighter.HighlightAsRtf(SyntaxColors, _defaultColor, _rtf), token);
            try
            {               
                Rtf = await _renderingTask;
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void StopHighlighting()
        {
            if (_renderingTaskCancellationTokenSource?.IsCancellationRequested ?? true)
                return;

            _renderingTaskCancellationTokenSource?.Cancel();
            _renderingTaskCancellationTokenSource?.Dispose();
            _renderingTask?.Dispose();
            _renderingTaskCancellationTokenSource = null;
        }

        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            base.OnContentsResized(e);
            Size = new Size(e.NewRectangle.Width, e.NewRectangle.Height + 4);
        }

        protected override void WndProc(ref Message m)
        {
            // Send WM_MOUSEWHEEL messages to the parent
            if (m.Msg == 0x20a)
                SendMessage(this.Parent.Handle, m.Msg, m.WParam, m.LParam);
            else
                base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);                
    }
}
