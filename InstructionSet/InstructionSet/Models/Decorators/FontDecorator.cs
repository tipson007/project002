using System;
using System.Drawing;
using System.Xml.Serialization;

namespace InstructionSet.Models.Decorators
{
    public class FontDecorator : TextBlockDecorator
    {
        [XmlIgnore]
        public Font Font { get; set; }

        public XmlFont XmlFont
        {
            get
            {
                return Font;
            }
            set
            {
                Font = value;
            }
        }

        public FontDecorator():base(null) { }

        public FontDecorator(TextBlock decoratedTextBlock, Font font) : base(decoratedTextBlock)
        {
            Font = font;
        }
        
        public override string ToRtf(RtfContext context)
        {            
            if(Font == null)
            {
                return DecoratedTextBlock.ToRtf(context);
            }            
            var strikeThroughCmd = Font.Strikeout ? "strike" : "strike0";            
            var twips = Math.Floor(Font.SizeInPoints * 2);
            var fnumber = context.AddFont(Font.Name);
            return $@"\f{fnumber}\fs{twips}\{strikeThroughCmd} {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
