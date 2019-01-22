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
                float hMargin = settings.HMargin;
                float vMargin = settings.VMargin;

                float x = anchor.IsLeft() ? hMargin : imgSize.Width - (textSize.Width + hMargin);
                float y = anchor.IsTop() ? vMargin : imgSize.Height - (textSize.Height + vMargin);
                PointF position = new PointF(x, y);

                g.DrawString(text, font, brush, position);
            }

            if (settings.EraseFiles)
                File.Delete(fileName);

            string suffix = !string.IsNullOrEmpty(settings.TransformedFileSuffix) ? settings.TransformedFileSuffix : "_wm";
            string saveFileName = fileName.Replace(".", $"{suffix}.");

            img.Save(saveFileName);
            img.Dispose();
        }    

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