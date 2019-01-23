using System.ComponentModel;

namespace Watermarker.Config
{
    public enum TextOrientation
    {
        [Description("Horizontale")]
        Horizontal = 0,
        [Description("Verticale montante")]
        VerticalAscending = 1,
        [Description("Verticale descendate")]
        VerticalDescending = 2,
    }
}