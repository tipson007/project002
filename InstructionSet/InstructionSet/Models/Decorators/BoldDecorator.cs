namespace InstructionSet.Models.Decorators
{
    public class BoldDecorator : TextBlockDecorator
    {
        public BoldDecorator():base(null) { }

        public BoldDecorator(TextBlock decoratedTextBlock) : base(decoratedTextBlock)
        {
        }

        public override string ToRtf(RtfContext context)
        {
            return $@"\b {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
