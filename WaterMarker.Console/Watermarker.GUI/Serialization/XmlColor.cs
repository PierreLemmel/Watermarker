using System.Drawing;

namespace Watermarker.Serialization
{
    public class XmlColor
    {
        public XmlColor() { }
        public XmlColor(Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

        public static implicit operator XmlColor(Color color) => FromColor(color);
        public static implicit operator Color(XmlColor xmlColor) => ToColor(xmlColor);

        public static XmlColor FromColor(Color color) => new XmlColor(color);
        public static Color ToColor(XmlColor xmlColor) => Color.FromArgb(xmlColor.Red, xmlColor.Green, xmlColor.Blue);

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}
