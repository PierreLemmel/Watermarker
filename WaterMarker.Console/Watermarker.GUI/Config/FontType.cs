using System.ComponentModel;
using System.Drawing;

namespace Watermarker.Config
{
    public enum FontType
    {
        [Description("Normale")]
        Regular = FontStyle.Regular,
        [Description("Gras")]
        Bold = FontStyle.Bold,
        [Description("Italique")]
        Italic = FontStyle.Italic,
        [Description("Gras et italique")]
        BoldItalic = FontStyle.Bold | FontStyle.Italic
    }
}
