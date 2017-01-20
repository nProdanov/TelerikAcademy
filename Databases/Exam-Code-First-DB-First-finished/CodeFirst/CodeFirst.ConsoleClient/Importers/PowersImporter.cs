using System.Collections.Generic;

using CodeFirst.Data;
using CodeFirst.Models;

namespace CodeFirst.ConsoleClient.Importers
{
    public class PowersImporter : IPowersImporter
    {
        private IRepository<Power> repository;
        private IUnitOfWork unitOfWork;

        public PowersImporter(IRepository<Power> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(IEnumerable<string> powers)
        {
            var count = 1;
            foreach (var power in powers)
            {
                repository.Add(new Power() { Name = power });

                if (count % 100 == 0)
                {
                    this.unitOfWork.Commit();
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
