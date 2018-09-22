using System.Drawing;
using System.Xml.Serialization;

namespace InstructionSet.Models.Decorators
{
    public class BackColorDecorator : TextBlockDecorator
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color BackColor { get; set; }

        public BackColorDecorator():base(null) { }

        public BackColorDecorator(TextBlock decoratedTextBlock, Color backcolor) : base(decoratedTextBlock)
        {
            BackColor = backcolor;
        }

        public override string ToRtf(RtfContext context)
        {
            if (BackColor == null)
            {
                return DecoratedTextBlock.ToRtf(context);
            }
            var cnumber = context.AddColor(BackColor);
            return $@"\highlight{cnumber} {DecoratedTextBlock.ToRtf(context)}";
        }        
    }
}
