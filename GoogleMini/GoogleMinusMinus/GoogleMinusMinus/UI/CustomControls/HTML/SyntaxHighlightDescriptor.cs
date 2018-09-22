using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleMini.UI.CustomControls.HTML
{
    public class SyntaxHighlightDescriptor
    {
        public string ColorKey { get; set; }
        public Regex Pattern { get; set; }
        public Dictionary<int, SyntaxHighlightDescriptor[]> CapturedGroups { get; set; }

        public SyntaxHighlightDescriptor()
        {
            ColorKey = string.Empty;            
        }
    }
}
