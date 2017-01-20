using CodeFirst.Data;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.ConsoleClient.Importers
{
    public class CitiesImporter : ICitiesImporter
    {
        private IRepository<City> citiesRepository;
        private IRepository<Country> countryRepository;
        private IUnitOfWork unitOfWork;

        public CitiesImporter(IRepository<Country> countryRepository, IRepository<City> citiesRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.citiesRepository = citiesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(IDictionary<string, string> cities)
        {
            var countries = this.countryRepository.All();

            var count = 1;
            foreach (var city in cities)
            {
                this.citiesRepository.Add(new City()
                {
                    Name = city.Key,
                    Country = countries.FirstOrDefault(c => c.Name == city.Value)
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
