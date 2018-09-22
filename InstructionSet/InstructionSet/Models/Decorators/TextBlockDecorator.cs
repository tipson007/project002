namespace InstructionSet.Models.Decorators
{
    public abstract class TextBlockDecorator : TextBlock
    {
        public TextBlock DecoratedTextBlock { get; set; }

        public override string RawText => DecoratedTextBlock.RawText?? "";        

        public TextBlockDecorator() { }

        public TextBlockDecorator(TextBlock decoratedTextBlock)
        {
            DecoratedTextBlock = decoratedTextBlock;
        }                            

        public static T FindDecorator<T>(TextBlock textBlock) where T: TextBlockDecorator
        {
            while(true)
            {
                switch (textBlock)
                {                    
                    case T p:
                        return p;
                    case TextBlockDecorator tbd:
                        textBlock = tbd.DecoratedTextBlock;
                        break;
                    default:
                        return null;
                }
            }
        }
    }
}
