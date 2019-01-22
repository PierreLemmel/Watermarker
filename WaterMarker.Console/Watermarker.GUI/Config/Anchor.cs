using System.ComponentModel;

namespace Watermarker.Config
{
    public enum Anchor
    {
        [Description("En bas à droite")]
        BottomRight,
        [Description("En bas à gauche")]
        BottomLeft,
        [Description("En haut à droite")]
        TopRight,
        [Description("En haut à gauche")]
        TopLeft
    }
}
