using System.IO;
using System.Xml;

namespace From_Text_File_To_Xml
{
    class TextToXml
    {
        static void Main(string[] args)
        {
            var textUrl = "..\\..\\..\\..\\person.txt";
            var xmlUrl = "..\\..\\..\\..\\person.xml";
            using (StreamReader reader = new StreamReader(textUrl))
            using (XmlWriter writer = XmlWriter.Create(xmlUrl))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("person");

                writer.WriteStartElement("name");
                writer.WriteString(reader.ReadLine());
                writer.WriteEndElement();

                writer.WriteStartElement("address");
                writer.WriteString(reader.ReadLine());
                writer.WriteEndElement();

                writer.WriteStartElement("phoneNumber");
                writer.WriteString(reader.ReadLine());
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }
    }
}
