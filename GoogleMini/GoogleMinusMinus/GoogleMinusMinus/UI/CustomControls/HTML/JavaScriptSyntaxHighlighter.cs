using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleMini.UI.CustomControls.HTML
{
    using SHD = SyntaxHighlightDescriptor;
    static class JavaScriptSyntaxHighlighter
    {
        public static SHD[] HighlightDescriptors { get; }

        static JavaScriptSyntaxHighlighter()
        {
            HighlightDescriptors = new[]
            {     
                new SHD
                {
                    ColorKey ="js.string",
                    Pattern = new Regex(@"(""|')(?:[^\\]|\\\S)*?\1", RegexOptions.Compiled)
                },           
                new SHD
                {
                    ColorKey = "js.interpolation",
                    Pattern = new Regex(@"`(?:[^\$\\`]|\$(?!{)|\\\S|(\${)(.*?)(}))*`", RegexOptions.Compiled | RegexOptions.Singleline),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {
                        {1, new[]{new SHD { ColorKey = "js.interpolation.open" } } },
                        {2, new[]{new SHD { ColorKey = "js.interpolation.expression" } } },
                        {3, new[]{new SHD { ColorKey = "js.interpolation.close" } } }
                    }
                },
                new SHD
                {
                    ColorKey ="js.comment",
                    Pattern = new Regex(@"\/\*[\s\S]*?\*\/|(\/\/).*?$", RegexOptions.Compiled | RegexOptions.Multiline)
                },
                new SHD
                {
                    ColorKey = "js.keyword",
                    Pattern=new Regex(@"(?<!\.)\s*?\b(const|let|var|yield|implements|constructor|interface|goto|extends|import|as|get|set|super|null|true|false|export|default|from|break|do|instanceof|typeof|case|else|new|catch|finally|return|void|continue|for|switch|while|debugger|function|this|with|default|if|throw|delete|in|try)\b", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace)                    
                },                                                                               
                new SHD
                {         
                    ColorKey = "js.regexp",
                    Pattern=new Regex(@"\/(?![*+?])(?:[^\r\n\[/\\]|\\.|\[(?:[^\r\n\]\\]|\\.)*\])+\/(?!\/)([igm]{0,3})", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {                        
                        {1, new[]{new SHD { ColorKey = "js.regexp.modifier" } } }
                    }
                },                             
                new SHD
                {
                    Pattern=new Regex(@"(class)\s+(\w+)(?:\s+(extends)\s+\w+)?(?=\s*\{)", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace),
                    CapturedGroups = new Dictionary<int, SHD[]>
                    {
                        {1, new[]{new SHD { ColorKey = "js.keyword" } } },
                        {2, new[]{new SHD { ColorKey = "js.userdatatype" } } },
                        {3, new[]{new SHD { ColorKey = "js.keyword" } } }
                    }
                }                
            };
        }
    }
}
