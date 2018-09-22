namespace InstructionSet.Models.Decorators
{
    public class ItalicsDecorator : TextBlockDecorator
    {
        public ItalicsDecorator():base(null) { }

        public ItalicsDecorator(TextBlock decoratedTextBlock) : base(decoratedTextBlock)
        {
        }

        public override string ToRtf(RtfContext context)
        {
            return $@"\i {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
