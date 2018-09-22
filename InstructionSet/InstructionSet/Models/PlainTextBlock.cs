namespace InstructionSet.Models
{
    public class PlainTextBlock : TextBlock
    {
        public string Text
        {
            get; set;
        }

        public override string RawText => Text;

        public PlainTextBlock()
        {
            Text = "";
        }
        
        public override string ToRtf(RtfContext context)
        {
            return context.Escape(Text ?? "");
        }
    }
}
