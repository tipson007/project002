using System.Drawing;
using System.Xml.Serialization;

namespace InstructionSet.Models
{
    public class XmlFont
    {
        [XmlAttribute]
        public string FontFamily { get; set; }
        [XmlAttribute]
        public float Size { get; set; }
        public GraphicsUnit GraphicsUnit { get; set; }              
        public FontStyle Style { get; set; }

        /// <summary>
        /// Intended for xml serialization purposes only
        /// </summary>
        private XmlFont() { }

        public XmlFont(Font f)
        {
            FontFamily = f.FontFamily.Name;
            GraphicsUnit = f.Unit;
            Size = f.Size;
            Style = f.Style;
        }       

        public static implicit operator Font(XmlFont x)
        {
            return new Font(x.FontFamily, x.Size, x.Style, x.GraphicsUnit);
        }

        public static implicit operator XmlFont(Font f)
        {
            return new XmlFont(f);
        }
    }
}
