namespace InstructionSet.Models.Decorators
{
    public class IndentDecorator : TextBlockDecorator
    {
        public enum IndentType { Left, Right }

        public IndentDecorator():base(null) { }

        public IndentType Indent { get; set; }

        public IndentDecorator(TextBlock decoratedTextBlock, IndentType indent) : base(decoratedTextBlock)
        {
            Indent = indent;
        }

        public override string ToRtf(RtfContext context)
        {
            var cmd = (Indent == IndentType.Left ? "li" : "ri");
            return $@"\{cmd}720 {DecoratedTextBlock.ToRtf(context)}";
        }
    }
}
