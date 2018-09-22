using System.Xml.Serialization;

namespace InstructionSet.Models
{
    public abstract class TextBlock
    {                
        [XmlIgnore]
        public abstract string RawText { get; }
        public abstract string ToRtf(RtfContext context);        
    }
}
