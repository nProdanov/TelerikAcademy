using System;
using System.IO;
using System.Xml;

namespace XMLParsing_Directory_Files_To_Xml_XmlWriter
{
    class DirectoryFilesToXml
    {
        static void Main(string[] args)
        {
            // Let see how clean is your Desktop :)
            var desktopUrl = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirFilesUrl = "..\\..\\..\\..\\desktopFolderXmlWriter.xml";

            using (XmlWriter writer = XmlWriter.Create(dirFilesUrl))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", desktopUrl);
                Traverse(desktopUrl, writer);
                foreach (var file in Directory.GetFiles(desktopUrl))
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("fileName", Path.GetFileName(file));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static void Traverse(string url, XmlWriter writer)
        {
            foreach (var dirUrl in Directory.GetDirectories(url))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", dirUrl);
                Traverse(dirUrl, writer);

                foreach (var file in Directory.GetFiles(dirUrl))
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("fileName", Path.GetFileName(file));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            
        }
    }
}
