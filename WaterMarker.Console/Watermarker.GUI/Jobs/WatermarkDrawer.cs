using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            string text = settings.Text;
            float width = img.Width;
            float height = img.Height;

            using (Graphics g = Graphics.FromImage(img))
            using (Brush brush = new SolidBrush(settings.Color))
            using (Font font = new Font(settings.FontName, settings.TextSize))
            {


                PointF position = new PointF(settings.HMargin, settings.VMargin);
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, brush, position);
            }

            if (settings.EraseFiles)
                File.Delete(fileName);

            string suffix = !string.IsNullOrEmpty(settings.TransformedFileSuffix) ? settings.TransformedFileSuffix : "_wm";
            string saveFileName = fileName.Replace(".", $"{suffix}.");

            img.Save(saveFileName);
            img.Dispose();
        }
    }
}