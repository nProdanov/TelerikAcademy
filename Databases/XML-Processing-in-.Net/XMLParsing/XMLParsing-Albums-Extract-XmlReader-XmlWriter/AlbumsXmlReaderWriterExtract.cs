using System.Xml;

namespace XMLParsing_Albums_Extract_XmlReader_XmlWriter
{
    class AlbumsXmlReaderWriterExtract
    {
        static void Main(string[] args)
        {
            var catalogueUrl = "..\\..\\..\\..\\catalogue.xml";
            var albumsUrl = "..\\..\\..\\..\\albums.xml";

            using (XmlReader reader = XmlReader.Create(catalogueUrl))
            using (XmlWriter writer = XmlWriter.Create(albumsUrl))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                while (reader.Read())
                {
                    if (reader.IsStartElement()) {
                        if (reader.Name == "name")
                        {
                            writer.WriteStartElement("album");
                            writer.WriteStartElement("name");
                            writer.WriteString(reader.ReadElementString());
                            writer.WriteEndElement();
                        }
                        else if(reader.Name == "artist")
                        {
                            writer.WriteStartElement("artist");
                            writer.WriteString(reader.ReadElementString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
