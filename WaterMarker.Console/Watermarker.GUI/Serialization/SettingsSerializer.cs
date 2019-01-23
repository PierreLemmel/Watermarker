using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Watermarker.Config;

namespace Watermarker.Serialization
{
    public class SettingsSerializer
    {
        private string AppDataFolder = "Watermarker";

        private string AppDataFolderPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            AppDataFolder);

        private string SettingsPath => Path.Combine(AppDataFolderPath, "settings.xml");

        private readonly XmlSerializer serializer = new XmlSerializer(typeof(WatermarkSettings));

        public WatermarkSettings RestoreSettings()
        {
            if (!File.Exists(SettingsPath))
                return null;

            using (XmlReader xmlReader = XmlReader.Create(SettingsPath))
            {
                object objResult = serializer.Deserialize(xmlReader);
                WatermarkSettings settings = (WatermarkSettings)objResult;

                return settings;
            }
        }

        public void SaveSettings(WatermarkSettings settings)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };

            Directory.CreateDirectory(AppDataFolderPath);

            using (FileStream fs = new FileStream(SettingsPath, FileMode.Create))
            using (XmlWriter writer = XmlWriter.Create(fs, xmlSettings))
            {
                serializer.Serialize(writer, settings);
            }
        }
    }
}
