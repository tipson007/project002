using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace InstructionSet.Models
{
    public class RtfContext
    {                            
        private Dictionary<Color, int> colors = new Dictionary<Color, int>();
        private Dictionary<string, int> fonts = new Dictionary<string, int>();

        public string LastListNumbering { get; set; }

        public string ListStyle { get; internal set; }

        public string RtfHeader
        {
            get
            {
                var colorTable = BuildColorTable();
                var fontTable = BuildFontTable();               
                return $@"{{\rtf1\ansi\deff0{fontTable}{colorTable}\viewkind4\uc1\pard\lang1033\f0\fs18";
            }
        }       

        public string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            var sb = new StringBuilder();
            foreach (var c in value)
            {                
                if (c == '\\' || c == '{' || c == '}')
                    sb.Append($@"\{c}");
                else if (c <= 0x007F)
                    sb.Append(c);
                else if( c <= 0x07FFF)
                    sb.Append($@"\u{(int)c}?");
                else
                    sb.Append($@"\u{c - 0x10000}?");
            }
            return sb.ToString().Replace(Environment.NewLine, @"\line ");
        }          

        public int AddColor(Color color)
        {
            if (!colors.TryGetValue(color, out int cfNumber))
            {
                cfNumber = colors.Count + 1;
                colors.Add(color, cfNumber);
                return cfNumber;
            }
            return cfNumber;
        }

        public int AddFont(string fontName)
        {
            if (!fonts.TryGetValue(fontName, out int fNumber))
            {
                fNumber = fonts.Count;
                fonts.Add(fontName, fNumber);
                return fNumber;
            }
            return fNumber;
        }    
        
        private string BuildColorTable()
        {
            var colorTableBuilder = new StringBuilder();
            colorTableBuilder.Append(@"{\colortbl ;");
            var colorMap = new Color[colors.Count + 1];
            foreach (var item in colors)
            {
                colorMap[item.Value] = item.Key;
            }
            for (int i = 1; i < colorMap.Length; i++)
            {
                var item = colorMap[i];
                colorTableBuilder.AppendFormat("\\red{0}\\green{1}\\blue{2};", item.R, item.G, item.B);
            }
            colorTableBuilder.AppendLine("}");
            return colorTableBuilder.ToString();
        }

        private string BuildFontTable()
        {
            var fontTableBuilder = new StringBuilder();
            fontTableBuilder.Append(@"{\fonttbl");
            if (fonts.Count == 0)
            {
                fontTableBuilder.Append(@"{\f0\froman Times;}");
            }
            else
            {                
                foreach (var item in fonts)
                {
                    fontTableBuilder.Append($@"{{\f{item.Value}\fnil {item.Key};}}");                    
                }                
            }
            fontTableBuilder.Append("}");
            return fontTableBuilder.ToString();            
        }
    }
}