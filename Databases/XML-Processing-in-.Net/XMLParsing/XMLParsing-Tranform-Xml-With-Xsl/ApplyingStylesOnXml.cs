using System.Xml.Xsl;

namespace XMLParsing_Tranform_Xml_With_Xsl
{
    class ApplyingStylesOnXml
    {
        static void Main(string[] args)
        {
            var styleUrl = "..\\..\\..\\..\\style.xslt";
            var xmlUrl = "..\\..\\..\\..\\catalogue.xml";
            var htmlUrl = "..\\..\\..\\..\\catalogue.html";

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(styleUrl);
            xslt.Transform(xmlUrl, htmlUrl);
        }
    }
}
