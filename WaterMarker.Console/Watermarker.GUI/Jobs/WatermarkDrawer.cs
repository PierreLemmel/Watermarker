using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Watermarker.Config;

namespace Watermarker.Jobs
{
    public class WatermarkDrawer
    {
        public void Draw(IReadOnlyCollection<string> files, WatermarkSettings settings)
        {
            foreach (string file in files)
            {
                DrawTextOnImage(file, settings);
            }
        }


        private void DrawTextOnImage(string fileName, WatermarkSettings settings)
        {
            Image img;
            using (Image original = Image.FromFile(fileName))
            {
                img = (Image)original.Clone();
            }

            EXIFOrientation orientation = GetEXIFOrientation(img);
            RotateFlipType rotateFlip = GetRotationForExifOrientation(orientation);
            img.RotateFlip(rotateFlip);

            FontStyle fontStyle = (FontStyle)settings.FontType;

            using (Graphics g = Graphics.FromImage(img))
            using (Brush brush = new SolidBrush(settings.Color))
            using (Font font = new Font(settings.FontName, settings.TextSize, fontStyle))
            {
                string text = settings.Text;

                Size imgSize = img.Size;
                SizeF textSize = g.MeasureString(text, font);
                Anchor anchor = settings.Anchor;
                SizeF marginSize = new SizeF(settings.HMargin, settings.VMargin);
                TextOrientation textOrientation = settings.TextOrientation;

                float textRotation = GetTextRotation(textOrientation);

                PointF textPosition = GetTextPosition(textOrientation, anchor, imgSize, textSize, marginSize);

                g.TranslateTransform(textPosition.X, textPosition.Y);
                g.RotateTransform(textRotation);

                g.DrawString(text, font, brush, PointF.Empty);
            }

            if (settings.EraseFiles)
                File.Delete(fileName);

            string suffix = !string.IsNullOrEmpty(settings.TransformedFileSuffix) ? settings.TransformedFileSuffix : "_wm";
            string saveFileName = fileName.Replace(".", $"{suffix}.");

            img.Save(saveFileName);
            img.Dispose();
        }

        private static float GetTextRotation(TextOrientation textOrientation)
        {
            switch (textOrientation)
            {
                case TextOrientation.Horizontal:
                    return 0.0f;
                case TextOrientation.VerticalAscending:
                    return -90.0f;
                case TextOrientation.VerticalDescending:
                    return 90.0f;
                default:
                    throw new InvalidOperationException($"Unexpected text orientation: {textOrientation}");
            }
        }

        private static PointF GetTextPosition(TextOrientation textOrientation, Anchor anchor, SizeF imgSize, SizeF textSize, SizeF marginSize)
        {
            PositionProvider positionProvider = PositionProviderMap[(textOrientation, anchor)];

            PointF textPosition = positionProvider(imgSize, textSize, marginSize);
            return textPosition;
        }

        private delegate PointF PositionProvider(SizeF imgSize, SizeF textSize, SizeF marginSize);
        private static readonly IReadOnlyDictionary<(TextOrientation, Anchor), PositionProvider> PositionProviderMap
            = new Dictionary<(TextOrientation, Anchor), PositionProvider>()
            {
                [(TextOrientation.Horizontal, Anchor.BottomRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - (textSize.Width + marginSize.Width),
                    imgSize.Height - (textSize.Height + marginSize.Height)
                ),
                [(TextOrientation.Horizontal, Anchor.BottomLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width,
                    imgSize.Height - (textSize.Height + marginSize.Height)
                ),
                [(TextOrientation.Horizontal, Anchor.TopRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - (textSize.Width + marginSize.Width),
                    marginSize.Height
                ),
                [(TextOrientation.Horizontal, Anchor.TopLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width,
                    marginSize.Height
                ),

                [(TextOrientation.VerticalAscending, Anchor.BottomRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - (textSize.Height + marginSize.Width),
                    imgSize.Height - marginSize.Height
                ),
                [(TextOrientation.VerticalAscending, Anchor.BottomLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width,
                    imgSize.Height - marginSize.Height
                ),
                [(TextOrientation.VerticalAscending, Anchor.TopRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - (textSize.Height + marginSize.Width),
                    marginSize.Height + textSize.Width
                ),
                [(TextOrientation.VerticalAscending, Anchor.TopLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width,
                    marginSize.Height + textSize.Width
                ),

                [(TextOrientation.VerticalDescending, Anchor.BottomRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - marginSize.Width,
                    imgSize.Height - (textSize.Width + marginSize.Height)
                ),
                [(TextOrientation.VerticalDescending, Anchor.BottomLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width + textSize.Height,
                    imgSize.Height - (textSize.Width + marginSize.Height)
                ),
                [(TextOrientation.VerticalDescending, Anchor.TopRight)] = (imgSize, textSize, marginSize) => new PointF(
                    imgSize.Width - marginSize.Width,
                    marginSize.Height
                ),
                [(TextOrientation.VerticalDescending, Anchor.TopLeft)] = (imgSize, textSize, marginSize) => new PointF(
                    marginSize.Width + textSize.Height,
                    marginSize.Height
                ),
            };

        private static EXIFOrientation GetEXIFOrientation(Image img)
        {
            PropertyItem property = img.PropertyItems.FirstOrDefault(item => item.Id == 274);

            if (property != null)
            {
                byte byteVal = property.Value.First();

                return (EXIFOrientation)byteVal;
            }
            else
                return EXIFOrientation.NoRotation;
        }

        private static RotateFlipType GetRotationForExifOrientation(EXIFOrientation orientation)
        {
            switch (orientation)
            {
                case EXIFOrientation.NoRotation:
                    return RotateFlipType.RotateNoneFlipNone;
                case EXIFOrientation.Rotation90:
                    return RotateFlipType.Rotate90FlipNone;
                case EXIFOrientation.Rotation180:
                    return RotateFlipType.Rotate180FlipNone;
                case EXIFOrientation.Rotation270:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    throw new NotSupportedException($"Unsupported exif orientation: {orientation}");
            }
        }
    }
}