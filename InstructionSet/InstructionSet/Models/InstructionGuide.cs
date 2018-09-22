using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace InstructionSet.Models
{
    public class InstructionGuide : IEnumerable<TextBlock>
    {
        private List<TextBlock> textBlocks = new List<TextBlock>();

        public Font DefaultFont { get; set; }

        public InstructionGuide()
        {
        }

        public InstructionGuide(IEnumerable<TextBlock> textBlocks)
        {
            this.textBlocks = textBlocks?.ToList() ?? new List<TextBlock>();
        }

        public IEnumerator<TextBlock> GetEnumerator()
        {
            return ((IEnumerable<TextBlock>)textBlocks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TextBlock>)textBlocks).GetEnumerator();
        }

        public void Add(TextBlock textBlock)
        {
            textBlocks.Add(textBlock);
        }

        public void Remove(TextBlock textBlock)
        {
            textBlocks.Remove(textBlock);
        }

        public string ToRtf()
        {
            var context = new RtfContext();
            context.AddFont(DefaultFont.Name);
            var sb = new StringBuilder();
            foreach (var textBlock in textBlocks)
            {
                sb.Append($@"{{\pard {textBlock.ToRtf(context)}\par}}");
            }
            return context.RtfHeader + sb.ToString() + "}";
        }

        public void Replace(TextBlock textBlock, TextBlock newTextBlock)
        {
            var index = textBlocks.IndexOf(textBlock);
            textBlocks[index] = newTextBlock;
        }

        public void MoveUp(TextBlock textBlock)
        {
            var index = textBlocks.IndexOf(textBlock);
            if (index == 0) return;
            textBlocks.RemoveAt(index);
            textBlocks.Insert(index - 1, textBlock);
        }

        public void MoveDown(TextBlock textBlock)
        {
            var index = textBlocks.IndexOf(textBlock);
            if (index == textBlocks.Count - 1) return;
            textBlocks.RemoveAt(index);
            textBlocks.Insert(index + 1, textBlock);
        }
    }
}
