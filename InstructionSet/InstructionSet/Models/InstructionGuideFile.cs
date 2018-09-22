using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using InstructionSet.Models.Decorators;

namespace InstructionSet.Models
{
    public class InstructionGuideFile
    {
        private static readonly Type[] textBlockTypes = {
            typeof(PlainTextBlock),
            typeof(TextBlockDecorator),
            typeof(BackColorDecorator),
            typeof(BoldDecorator),
            typeof(ForeColorDecorator),
            typeof(FontDecorator),
            typeof(IndentDecorator),
            typeof(ItalicsDecorator),
            typeof(ListDecorator),
            typeof(UnderlineDecorator),
        };

        public static void SerializeToXmlFile(InstructionGuide guide, string fileName)
        {
            var textBlocks = guide.ToList();
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                var ser = new XmlSerializer(typeof(List<TextBlock>), textBlockTypes);
                ser.Serialize(fileStream, textBlocks);
            }
        }

        public static InstructionGuide DeserializeFromXmlFile(string fileName)
        {
            List<TextBlock> result;
            var ser = new XmlSerializer(typeof(List<TextBlock>), textBlockTypes);
            using (var tr = new StreamReader(fileName))
            {
                result = (List<TextBlock>)ser.Deserialize(tr);
            }
            var guide = new InstructionGuide(result);
            return guide;
        }
    }
}
