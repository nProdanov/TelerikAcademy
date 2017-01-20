using System.Linq;
using System.Collections.Generic;

using CodeFIrst.Parsers;
using CodeFirst.ConsoleClient.Importers;
using CodeFIrst.Parsers.ParsingModels;

namespace CodeFirst.ConsoleClient
{
    public class DataImporter
    {
        private const string JsonFilePath = "..\\..\\..\\sample-data.json";

        private IJsonParser jsonParser;
        private IPowersImporter powerImporter;
        private IFractionsImporter fractionsImporter;
        private IPlanetsImporter planetsImporter;
        private ICountryImporter countryImporter;
        private ICitiesImporter citiesImporter;
        private ISuperheroesImporter superheroImporter;

        public DataImporter(
            IJsonParser jsonParser, 
            IPowersImporter powerImporter, 
            IFractionsImporter fractionsImporter,
            IPlanetsImporter planetsImporter,
            ICountryImporter countryImporter,
            ICitiesImporter citiesImporter,
            ISuperheroesImporter superheroImporter)
        {
            this.jsonParser = jsonParser;
            this.powerImporter = powerImporter;
            this.fractionsImporter = fractionsImporter;
            this.planetsImporter = planetsImporter;
            this.countryImporter = countryImporter;
            this.citiesImporter = citiesImporter;
            this.superheroImporter = superheroImporter;
        }

        public void Import()
        {
            var superheroesJsonModels = this.jsonParser.Parse(JsonFilePath);

            this.ImportPowers(superheroesJsonModels);
            this.ImportFractions(superheroesJsonModels);
            this.ImportPlanets(superheroesJsonModels);
            this.ImportCountries(superheroesJsonModels);
            this.ImportCities(superheroesJsonModels);

            this.superheroImporter.Import(superheroesJsonModels);
        }

        private void ImportPowers(IEnumerable<SuperheroJsonModel> superheroesJsonModels)
        {
            var distinctPowers = superheroesJsonModels.SelectMany(s => s.Powers).Distinct();
            this.powerImporter.Import(distinctPowers);
        }

        private void ImportFractions(IEnumerable<SuperheroJsonModel> superheroesJsonModels)
        {
            var fractions = new Dictionary<string, string>();

            superheroesJsonModels = superheroesJsonModels.Where(s => s.Fractions != null);

            foreach (var superheroJsonModel in superheroesJsonModels)
            {
                foreach (var fraction in superheroJsonModel.Fractions)
                {
                    if (!fractions.ContainsKey(fraction))
                    {
                        fractions.Add(fraction, superheroJsonModel.Alignment);
                    }
                }
            }

            this.fractionsImporter.Import(fractions);
        }

        private void ImportPlanets(IEnumerable<SuperheroJsonModel> superheroesJsonModels)
        {
            var planets = new Dictionary<string, ICollection<string>>();

            foreach (var superheroModel in superheroesJsonModels)
            {
                var planet = superheroModel.City.Planet;
                if (!planets.ContainsKey(planet))
                {
                    planets.Add(planet, new List<string>());

                }

                if (superheroModel.Fractions != null)
                {
                    foreach (var fraction in superheroModel.Fractions)
                    {
                        if (!planets[planet].Contains(fraction))
                        {
                            planets[planet].Add(fraction);
                        }
                    }
                }
            }

            this.planetsImporter.Import(planets);

        }

        private void ImportCountries(IEnumerable<SuperheroJsonModel> superheroesJsonModels)
        {
            var countries = new Dictionary<string, string>();

            foreach (var superhero in superheroesJsonModels)
            {
                if (!countries.ContainsKey(superhero.City.Country))
                {
                    countries.Add(superhero.City.Country, superhero.City.Planet);
                }
            }

            this.countryImporter.Import(countries);
        }

        private void ImportCities(IEnumerable<SuperheroJsonModel> superheroesJsonModels)
        {
            var cities = new Dictionary<string, string>();

            foreach (var superhero in superheroesJsonModels)
            {
                var city = superhero.City.Name;
                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, superhero.City.Country);
                }
            }

            this.citiesImporter.Import(cities);
        }
    }
}
