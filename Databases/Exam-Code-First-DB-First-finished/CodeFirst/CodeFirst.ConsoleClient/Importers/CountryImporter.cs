using System.Collections.Generic;
using System.Linq;

using CodeFirst.Data;
using CodeFirst.Models;


namespace CodeFirst.ConsoleClient.Importers
{
    public class CountryImporter : ICountryImporter
    {
        private IRepository<Country> countryRepository;
        private IRepository<Planet> planetsRepository;
        private IUnitOfWork unitOfWork;

        public CountryImporter(IRepository<Planet> planetsRepository, IRepository<Country> countryRepository, IUnitOfWork unitOfWork)
        {
            this.planetsRepository = planetsRepository;
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(IDictionary<string, string> countries)
        {
            var planets = this.planetsRepository.All();

            var count = 1;
            foreach (var country in countries)
            {
                this.countryRepository.Add(new Country()
                {
                    Name = country.Key,
                    Planet = planets.FirstOrDefault(pl => pl.Name == country.Value)
                });

                if (count % 100 == 0)
                {
                    this.unitOfWork.Commit();
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
