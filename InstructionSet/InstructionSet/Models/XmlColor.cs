using System;
using System.Drawing;
using System.Xml.Serialization;

namespace InstructionSet.Models
{
    /// <summary>
    /// See https://stackoverflow.com/questions/3280362/most-elegant-xml-serialization-of-color-structure
    /// </summary>
    public class XmlColor
    {
        private Color color = Color.Black;

        /// <summary>
        /// Intended for xml serialization purposes only
        /// </summary>
        private XmlColor() { }

        public XmlColor(Color color) { this.color = color; }        
        
        public static implicit operator Color(XmlColor x)
        {
            return x.color;
        }

        public static implicit operator XmlColor(Color c)
        {
            return new XmlColor(c);
        }

        [XmlAttribute]
        public string Web
        {
            get { return ColorTranslator.ToHtml(color); }
            set
            {
                try
                {
                    if (Alpha == 0xFF) // preserve named color value if possible
                        color = ColorTranslator.FromHtml(value);
                    else
                        color = Color.FromArgb(Alpha, ColorTranslator.FromHtml(value));
                }
                catch (Exception)
                {
                    color = Color.Black;
                }
            }
        }

        [XmlAttribute]
        public byte Alpha
        {
            get { return color.A; }
            set
            {
                if (value != color.A) // avoid hammering named color if no alpha change
                    color = Color.FromArgb(value, color);
            }
        }

        public bool ShouldSerializeAlpha() { return Alpha < 0xFF; }
    }

}
