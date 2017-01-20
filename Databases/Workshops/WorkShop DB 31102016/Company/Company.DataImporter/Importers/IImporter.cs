using Company.Data;
using Company.DataImporter.Logger;
using System;

namespace Company.DataImporter.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<CompanyEntities, ILogger, IRandomGenerator> Get { get; }
    }
}
