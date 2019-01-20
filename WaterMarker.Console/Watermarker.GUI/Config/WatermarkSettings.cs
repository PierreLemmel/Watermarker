using System.Drawing;

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
        public Color Color { get; set; } = Color.White;
        public string FontName { get; set; } = "Arial";
    }
}