using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleMini.UI.CustomControls.HTML
{
    internal class RTFBuilder
    {
        private static Regex rtfHeaderPattern = new Regex(@"^\{\\rtf.*?\\fs\d+", RegexOptions.Compiled);
        private static readonly char[] slashable = new[] { '{', '}', '\\' };

        private string header;
        private StringBuilder stringBuilder;
        private Dictionary<Color, int> foreColors;

        public RTFBuilder(string rtfTemplate)
        {
            stringBuilder = new StringBuilder();
            foreColors = new Dictionary<Color, int>();

            var match = rtfHeaderPattern.Match(rtfTemplate);
            if (match.Success)
            {
                header = match.Value;
            }
            else
            {
                header = @"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset0 Consolas;}}\viewkind4\uc1\pard\lang1033\f0\fs18";
            }
        }

        public void Append(string value, Color foreColor)
        {
            if (!foreColors.TryGetValue(foreColor, out int cfNumber))
            {
                cfNumber = foreColors.Count + 1;
                foreColors.Add(foreColor, cfNumber);
            }
            value = Escape(value);
            stringBuilder.Append($"\\cf{cfNumber} ");
            stringBuilder.Append(value.Replace("\n", "\\par\n"));
        }

        public override string ToString()
        {
            var colorTableBuilder = new StringBuilder();
            colorTableBuilder.Append("{\\colortbl ;");
            var colorMap = new Color[foreColors.Count + 1];
            foreach (var item in foreColors)
            {
                colorMap[item.Value] = item.Key;
            }
            for (int i = 1; i < colorMap.Length; i++)
            {
                var item = colorMap[i];
                colorTableBuilder.AppendFormat("\\red{0}\\green{1}\\blue{2};", item.R, item.G, item.B);
            }
            colorTableBuilder.AppendLine("}");

            var colorTableInsertionPoint = header.IndexOf(@"\viewkind4");
            header = header.Insert(colorTableInsertionPoint, colorTableBuilder.ToString());

            return header + " " + stringBuilder.ToString() + "}";
        }

        private string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            if (value.IndexOfAny(slashable) >= 0)
            {
                value = value.Replace("\\", "\\\\").Replace("{", "\\{").Replace("}", "\\}");
            }
            return value;
        }
    }
}
