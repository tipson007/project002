using InstructionSet.Models.Decorators;

namespace InstructionSet.Models
{
    class TextBlockUtil
    {
        public static PlainTextBlock FindPlainTextBox(TextBlock textBlock)
        {
            while (true)
            {
                switch (textBlock)
                {
                    case TextBlockDecorator tbd:
                        textBlock = tbd.DecoratedTextBlock;
                        break;
                    case PlainTextBlock p:
                        return p;
                    default:
                        return null;
                }
            }
        }
    }
}
