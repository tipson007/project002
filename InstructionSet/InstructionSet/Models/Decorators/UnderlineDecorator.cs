namespace InstructionSet.Models.Decorators
{
    public class UnderlineDecorator : TextBlockDecorator
    {
        public enum UnderlineType { None, Single, Double }

        public UnderlineType Underline{ get; set; }

        public UnderlineDecorator():base(null) { }

        public UnderlineDecorator(TextBlock decoratedTextBlock, UnderlineType underline) : base(decoratedTextBlock)
        {
            Underline = underline;
        }
        
        public override string ToRtf(RtfContext context)
        {
            var underlineCmd = "ul";
            switch (Underline)
            {
                case UnderlineType.None:
                    underlineCmd = "ulnone";
                    break;
                case UnderlineType.Single:
                    underlineCmd = "ul";
                    break;
                case UnderlineType.Double:
                    underlineCmd = "uldb";
                    break;                
            }
            return $@"\{underlineCmd} {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
