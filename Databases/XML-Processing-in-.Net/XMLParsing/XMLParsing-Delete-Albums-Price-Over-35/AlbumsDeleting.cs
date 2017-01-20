using System.Linq;
using System.Xml;

namespace XMLParsing_Delete_Albums_Price_Over_35
{
    class AlbumsDeleting
    {
        static void Main(string[] args)
        {
            var url = "..\\..\\..\\..\\catalogue.xml";
            var doc = new XmlDocument();
            doc.Load(url);

            XmlNode catalogue = doc.DocumentElement;

            var albums = catalogue.ChildNodes.Cast<XmlNode>().ToList();

            albums.ForEach(delegate (XmlNode album)
            {
                int price = int.Parse(album["price"].InnerText);

                if (price >= 20)
                {
                    catalogue.RemoveChild(album);
                }
            });

            doc.Save("..\\..\\..\\..\\catalogueNew.xml");
        }
    }
}
