using System;

namespace Watermarker.Config
{
    public static class AnchorExtensions
    {
        public static bool IsLeft(this Anchor anchor) => anchor == Anchor.TopLeft || anchor == Anchor.BottomLeft;
        public static bool IsRight(this Anchor anchor) => anchor == Anchor.TopRight || anchor == Anchor.BottomRight;
        public static bool IsBottom(this Anchor anchor) => anchor == Anchor.BottomLeft || anchor == Anchor.BottomRight;
        public static bool IsTop(this Anchor anchor) => anchor == Anchor.TopLeft || anchor == Anchor.TopRight;
    }
}
