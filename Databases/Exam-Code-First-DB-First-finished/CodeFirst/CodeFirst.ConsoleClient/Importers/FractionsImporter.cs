using System;
using System.Collections.Generic;

using CodeFirst.Data;
using CodeFirst.Models;

namespace CodeFirst.ConsoleClient.Importers
{
    public class FractionsImporter : IFractionsImporter
    {
        private IRepository<Fraction> repository;
        private IUnitOfWork unitOfWork;

        public FractionsImporter(IRepository<Fraction> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(IDictionary<string, string> fractions)
        {
            var count = 1;
            foreach (var fraction in fractions)
            {
                this.repository.Add(new Fraction() { Name = fraction.Key, Alignment = (AlignmentType)Enum.Parse(typeof(AlignmentType), fraction.Value) });

                if (count % 100 == 0)
                {
                    this.unitOfWork.Commit();
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
