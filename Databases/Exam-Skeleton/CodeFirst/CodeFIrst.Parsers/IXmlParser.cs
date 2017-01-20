using System.Collections.Generic;

namespace CodeFIrst.Parsers
{
    public interface IXmlParser
    {
        IEnumerable<T> Parse<T>(string filePath, string rootElement);
    }
}