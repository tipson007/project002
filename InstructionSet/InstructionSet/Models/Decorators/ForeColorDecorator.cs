using System.Drawing;
using System.Xml.Serialization;

namespace InstructionSet.Models.Decorators
{
    public class ForeColorDecorator : TextBlockDecorator
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color ForeColor { get; set; }

        public ForeColorDecorator():base(null) { }

        public ForeColorDecorator(TextBlock decoratedTextBlock, Color forecolor) : base(decoratedTextBlock)
        {
            ForeColor = forecolor;
        }

        public override string ToRtf(RtfContext context)
        {
            if (ForeColor == null)
            {
                return DecoratedTextBlock.ToRtf(context);
            }           
            var cnumber = context.AddColor(ForeColor);
            return $@"\cf{cnumber} {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
