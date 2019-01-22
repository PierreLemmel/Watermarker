using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Watermarker.DataSources
{
    public static class FontDataSource
    {
        public static IReadOnlyCollection<string> GetFontNames() => FontFamily
            .Families
            .Select(font => font.Name)
            .ToList();
    }
}
