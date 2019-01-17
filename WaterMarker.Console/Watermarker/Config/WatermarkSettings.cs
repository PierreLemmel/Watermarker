using System;
using System.Drawing;

namespace Watermarker.Config
{
    public class WatermarkSettings
    {
        public bool EraseFile { get; set; } = false;
        public string TransformedFileSuffix { get; set; } = "_wm";
        public Anchor Anchor { get; set; } = Anchor.BottomRight;
        public int HMargin { get; set; } = 10;
        public int VMargin { get; set; } = 10;
        public string Text { get; set; } = "©Author";
        public Color Color { get; set; } = Color.White;
    }
}
