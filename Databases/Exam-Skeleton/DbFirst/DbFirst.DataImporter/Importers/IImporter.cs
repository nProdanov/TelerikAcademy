using System;

using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;

namespace DbFirst.DataImporter.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<DbEntities, ILogger, IRandomGenerator> Get { get; }
    }
}
