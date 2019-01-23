using Watermarker.Serialization;

using SColor = System.Drawing.Color;

namespace Watermarker.Config
{
    public class WatermarkSettings
    {
        public bool EraseFiles { get; set; } = false;
        public bool IncludeSubFolders { get; set; } = true;
        public string TransformedFileSuffix { get; set; } = "_wm";
        public Anchor Anchor { get; set; } = Anchor.BottomRight;
        public float HMargin { get; set; } = 10;
        public float VMargin { get; set; } = 10;
        public float TextSize { get; set; } = 14;
        public string Text { get; set; } = "©Author";
        public TextOrientation TextOrientation { get; set; } = TextOrientation.Horizontal;
        public XmlColor Color { get; set; } = SColor.White;
        public string FontName { get; set; } = "Arial";
        public FontType FontType { get; set; } = FontType.Regular;
    }
}