using System.Collections.Generic;
using System.Linq;

using CodeFirst.Data;
using CodeFirst.Models;

namespace CodeFirst.ConsoleClient.Importers
{
    public class PlanetsImporter : IPlanetsImporter
    {
        private IRepository<Fraction> fractionRepository;
        private IRepository<Planet> planetRepository;
        private IUnitOfWork unitOfWork;

        public PlanetsImporter(
            IRepository<Fraction> fractionRepository,
            IRepository<Planet> planetRepository, 
            IUnitOfWork unitOfWork)
        {
            this.fractionRepository = fractionRepository;
            this.planetRepository = planetRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(Dictionary<string, ICollection<string>> planets)
        {
            var fractions = this.fractionRepository.All();

            var count = 1;
            foreach (var planet in planets)
            {
                var planetToAdd = new Planet() { Name = planet.Key };
                foreach (var fraction in planet.Value)
                {
                    planetToAdd.PlanetFractions.Add(fractions.FirstOrDefault(fr => fr.Name == fraction));
                }

                this.planetRepository.Add(planetToAdd);

                if (count % 100 == 0)
                {
                    this.unitOfWork.Commit();
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
