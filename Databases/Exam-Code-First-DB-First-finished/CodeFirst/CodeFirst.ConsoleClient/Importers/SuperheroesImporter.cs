using System;
using System.Collections.Generic;
using System.Linq;

using CodeFirst.ConsoleClient.Extensions;
using CodeFirst.Data;
using CodeFirst.Models;
using CodeFIrst.Parsers.ParsingModels;

namespace CodeFirst.ConsoleClient.Importers
{
    public class SuperheroesImporter : ISuperheroesImporter
    {
        private IRepository<City> citiesRepository;
        private IRepository<Fraction> fractionsRepository;
        private IRepository<Power> powersRepository;
        private IRepository<Superhero> superheroesRepository;
        private IUnitOfWork unitOfWork;

        public SuperheroesImporter(
            IRepository<City> citiesRepository,
            IRepository<Power> powersRepository,
            IRepository<Fraction> fractionsRepository,
            IRepository<Superhero> superheroesRepository,
            IUnitOfWork unitOfWork)
        {
            this.superheroesRepository = superheroesRepository;
            this.citiesRepository = citiesRepository;
            this.powersRepository = powersRepository;
            this.fractionsRepository = fractionsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Import(IEnumerable<SuperheroJsonModel> superheroJsonModels)
        {
            superheroJsonModels = superheroJsonModels.DistinctBy(s => s.SecretIdentity);

            var cities = this.citiesRepository.All();
            var fractions = this.fractionsRepository.All();
            var powers = this.powersRepository.All();

            var count = 1;
            foreach (var superheroJson in superheroJsonModels)
            {
                var superheroToAdd = new Superhero()
                {
                    Name = superheroJson.Name,
                    Alignment = (AlignmentType)Enum.Parse(typeof(AlignmentType), superheroJson.Alignment),
                    Story = superheroJson.Story,
                    SecretIdentity = superheroJson.SecretIdentity,
                    City = cities.FirstOrDefault(c => c.Name == superheroJson.City.Name)
                };

                if (superheroJson.Fractions != null)
                {
                    foreach (var fraction in superheroJson.Fractions)
                    {
                        superheroToAdd.Fractions.Add(fractions.FirstOrDefault(fr => fr.Name == fraction));
                    }
                }

                if (superheroJson.Powers != null)
                {
                    foreach (var power in superheroJson.Powers)
                    {
                        superheroToAdd.Powers.Add(powers.FirstOrDefault(p => p.Name == power));
                    }
                }

                this.superheroesRepository.Add(superheroToAdd);

                if (count % 100 == 0)
                {
                    this.unitOfWork.Commit();
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
