using System.Collections.Generic;

namespace CodeFIrst.Parsers
{
    public interface IJsonParser
    {
        IEnumerable<T> Parse<T>(string filePath);
    }
}