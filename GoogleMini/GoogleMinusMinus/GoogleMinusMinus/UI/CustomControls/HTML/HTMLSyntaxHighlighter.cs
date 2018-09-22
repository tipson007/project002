using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleMini.UI.CustomControls.HTML
{
    using SHD = SyntaxHighlightDescriptor;
    static class HTMLSyntaxHighlighter
    {
        public static SHD[] HighlightDescriptors { get; }

        static HTMLSyntaxHighlighter()
        {
            HighlightDescriptors = new[]
            {
                new SHD
                {
                    Pattern=new Regex(@"<script(?!src).*?>([\s\S]*?)<\/script>", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {
                        {1,  JavaScriptSyntaxHighlighter.HighlightDescriptors }
                    }
                },
                new SHD
                {
                    ColorKey = "html.comment",
                    Pattern = new Regex(@"<!--[\S\s]*?-->", RegexOptions.Compiled)
                },
                new SHD
                {
                    Pattern = new Regex(@"(<\??)(!?\w+)((?:\s+[^'""\/>]+|""[^""]*""|'[^']*')*)\s*(\/?>)", RegexOptions.Compiled),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {
                        {1, new[] {new SHD{ColorKey= "html.tag.<" } } },
                        {2, new[] {new SHD{ColorKey= "html.tag.name" } } },
                        {3, new[] 
                            {
                                new SHD
                                {
                                    Pattern = new Regex(@"(=)\s*('|"")(.*?)(\2)", RegexOptions.Compiled | RegexOptions.Singleline),
                                    CapturedGroups = new Dictionary<int, SHD[]>
                                    {
                                        {1, new []{new SHD{ColorKey = "html.operator"} } },
                                        {2, new []{new SHD{ColorKey = "html.quote"} } },
                                        {3, new []{new SHD{ColorKey = "html.value"} } },
                                        {4, new []{new SHD{ColorKey = "html.quote"} } }
                                    }
                                },
                                new SHD
                                {
                                    Pattern = new Regex(@"(=)\s*([a-zA-Z\-0-9]*)\b", RegexOptions.Compiled),
                                    CapturedGroups = new Dictionary<int, SHD[]>
                                    {
                                        {1, new []{new SHD{ColorKey = "html.operator"} } },
                                        {2, new []{new SHD{ColorKey = "html.value"} } }
                                    }
                                },
                                new SHD
                                {
                                    Pattern = new Regex(@"\b([\w-]+)", RegexOptions.Compiled),
                                    CapturedGroups = new Dictionary<int, SHD[]>
                                    {
                                        {1, new []{new SHD{ColorKey = "html.attribute"} } },
                                    }
                                }
                            }
                        },
                        {4, new[] {new SHD{ColorKey= "html.tag.>" } } },
                    }
                },
                new SHD
                {                    
                    Pattern = new Regex(@"(<\/)(\w+)\s*(>)", RegexOptions.Compiled),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {
                        {1, new[] {new SHD{ColorKey= "html.tag.<" } } },
                        {2, new[] {new SHD{ColorKey= "html.tag.name" } } },
                        {3, new[] {new SHD{ColorKey= "html.tag.>" } } }
                    }
                }
            };
        }
    }
}
