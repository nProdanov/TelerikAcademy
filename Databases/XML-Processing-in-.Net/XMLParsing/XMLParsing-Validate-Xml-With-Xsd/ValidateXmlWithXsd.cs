using System;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XMLParsing_Validate_Xml_With_Xsd
{
    class ValidateXmlWithXsd
    {
        static void Main(string[] args)
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "..\\..\\..\\..\\catalogue.xsd");

            var catalogueDoc = XDocument.Load("..\\..\\..\\..\\catalogue.xml");
            var invalidCatalogueDoc = XDocument.Load("..\\..\\..\\..\\invalidCatalogue.xml");
            
            Console.WriteLine(ValidationResult(catalogueDoc, schema, "catalogue.xml"));
            Console.WriteLine(new String('*', 20));
            Console.WriteLine(ValidationResult(invalidCatalogueDoc, schema, "invalidCatalogue.xml"));
        }

        public static string ValidationResult(XDocument document, XmlSchemaSet schema, string fileName)
        {
            var errorResult = new StringBuilder();
            document.Validate(schema, (obj, e) =>
            {
                errorResult.AppendLine(e.Message);
            });

            if (string.IsNullOrEmpty(errorResult.ToString()))
            {
                errorResult.Append("Xml file is valid!");
            }

            var result = new StringBuilder();
            result.AppendLine(fileName);
            result.Append(errorResult);

            return result.ToString();
        }
    }
}
