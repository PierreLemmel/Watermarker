namespace Watermarker.Config
{
    public static class TextOrientationExtensions
    {
        public static bool IsVertical(this TextOrientation orientation) => orientation == TextOrientation.VerticalAscending 
            || orientation == TextOrientation.VerticalDescending;
    }
}
