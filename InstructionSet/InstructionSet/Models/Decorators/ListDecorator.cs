using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace InstructionSet.Models.Decorators
{
    public class ListDecorator : TextBlockDecorator
    {
        private static readonly Regex numericListRegex = new Regex(@"^\s*(\d[\d\.]*\d|\d)(\W)", RegexOptions.Compiled | RegexOptions.Multiline);

        public ListDecorator():base(null) { }

        public ListDecorator(TextBlock decoratedTextBlock) : base(decoratedTextBlock)
        {
        }

        public override string ToRtf(RtfContext context)
        {
            var text = DecoratedTextBlock.RawText;
            var match = numericListRegex.Match(text);
            if (match.Success)
            {                
                context.ListStyle = match.Groups[2].Value;
                context.LastListNumbering = match.Groups[1].Value;
                return DecoratedTextBlock.ToRtf(context);
            }
            var lastNumbering = context.LastListNumbering ?? "0";
            var sections = lastNumbering.Split('.').Select(d=>int.Parse(d)).ToList();
            sections[sections.Count - 1]++;
            var numbering = String.Join(".", sections);
            context.LastListNumbering = numbering;
            context.ListStyle = context.ListStyle ?? ".";
            return $@"{numbering}{context.ListStyle}{DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
