using System;
using System.IO;
using System.Xml.Linq;

namespace XMLParsing_Directory_Files_To_Xml_XDocument
{
    class DirectoryFilesToXml
    {
        static void Main(string[] args)
        {
            var desktopFolderUrl = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var desktopFolderXmlUrl = "..\\..\\..\\..\\desktopFolderXDoc.xml";

            var desktopFolderElement = Traverse(desktopFolderUrl);
            desktopFolderElement.Save(desktopFolderXmlUrl);
        }

        public static XElement Traverse(string folderUrl)
        {
            var element = new XElement("dir");
            var attribute = new XAttribute("path", folderUrl);
            element.Add(attribute);

            foreach (var folder in Directory.GetDirectories(folderUrl))
            {
                element.Add(Traverse(folder));
            }

            foreach (var file in Directory.GetFiles(folderUrl))
            {
                var fileElement = new XElement("file");
                var fileAttribute = new XAttribute("fileName", Path.GetFileName(file));
                fileElement.Add(fileAttribute);
                element.Add(fileElement);
            }

            return element;
        }
    }
}
