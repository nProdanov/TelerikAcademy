using System;

using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;
using DbFirst.Data;

namespace DbFirst.DataImporter.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<ComputersEntities, ILogger, IRandomGenerator> Get { get; }
    }
}
