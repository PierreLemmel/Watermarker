using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Watermarker.Config;

namespace Watermarker.Jobs
{
    public class SettingsSerializer
    {
        private const string Path = "settings.xml";

        private readonly XmlSerializer serializer = new XmlSerializer(typeof(WatermarkSettings));

        public WatermarkSettings RestoreSettings()
        {
            if (!File.Exists(Path))
                return null;

            try
            {
                using (XmlReader xmlReader = XmlReader.Create(Path))
                {
                    object objResult = serializer.Deserialize(xmlReader);
                    WatermarkSettings settings = (WatermarkSettings)objResult;

                    return settings;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }

        public void SaveSettings(WatermarkSettings settings)
        {
            try
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (FileStream fs = new FileStream(Path, FileMode.Truncate))
                using (XmlWriter writer = XmlWriter.Create(fs, xmlSettings))
                {
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }

        private void LogError(Exception ex)
        {
            Debug.WriteLine(ex.GetType().FullName);
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }
    }
}
