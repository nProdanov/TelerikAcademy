using CodeFirst.Data;
using CodeFirst.Models;
using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CodeFirst.ConsoleClient.Exporter
{
    public class SuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private IRepository<Country> countryRepository;
        private IRepository<Fraction> fractionsRepository;
        private IRepository<Planet> planetRepository;
        private IRepository<Superhero> superheroRepository;

        public SuperheroesUniverseExporter(
            IRepository<Superhero> superheroRepository,
            IRepository<Planet> planetRepository,
            IRepository<Country> countryRepository, 
            IRepository<Fraction> fractionsRepository)
        {
            this.superheroRepository = superheroRepository;
            this.countryRepository = countryRepository;
            this.planetRepository = planetRepository;
            this.fractionsRepository = fractionsRepository;
        }

        public string ExportAllSuperheroes()
        {
            var superheroes = this.superheroRepository.All();
            var countries = this.countryRepository.All();
            var planets = this.planetRepository.All();

            var rootElement = new XElement("superheroes");

            foreach (var superhero in superheroes)
            {

                var nameElement = new XElement("name");
                nameElement.Add(new XAttribute("id", superhero.Id));
                nameElement.Value = superhero.Name;

                var secretIdentityElement = new XElement("secretIdentity");
                secretIdentityElement.Value = superhero.SecretIdentity;

                var alignmentElement = new XElement("alignment");
                alignmentElement.Value = superhero.Alignment.ToString();

                var powersElement = new XElement("powers");
                foreach (var power in superhero.Powers)
                {
                    var powerElement = new XElement("power");
                    powerElement.Value = power.Name;

                    powersElement.Add(powerElement);
                }

                var cityEelement = new XElement("city");
                var city = superhero.City.Name;

                var country = countries.FirstOrDefault(c => c.Cities.Any(ci => ci.Name == city)).Name;
                var planet = planets.FirstOrDefault(p => p.Countries.Any(c => c.Name == country)).Name;
                cityEelement.Value = $"{city}, {country}, {planet}";

                var superheroElement = new XElement("superhero");
                superheroElement.Add(nameElement);
                superheroElement.Add(secretIdentityElement);
                superheroElement.Add(alignmentElement);
                superheroElement.Add(powersElement);
                superheroElement.Add(cityEelement);

                rootElement.Add(superheroElement);
            }

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(rootElement.ToString());

            return result.ToString();
        }

        public string ExportFractionDetails(object fractionId)
        {
            var fraction = this.fractionsRepository.All(fr => fr.Id == (int)fractionId).FirstOrDefault();

            

            var nameElement = new XElement("name");
            nameElement.Value = fraction.Name;

            var planetsElement = new XElement("planets");
            foreach (var planet in fraction.ProtectedPlanets)
            {
                var planetElement = new XElement("planet");
                planetElement.Value = planet.Name;

                planetsElement.Add(planetElement);
            }

            var memebersElement = new XElement("memebers");
            foreach (var member in fraction.Members)
            {
                var memeberElement = new XElement("memeber");
                memeberElement.Add(new XAttribute("id", member.Id));
                memeberElement.Value = member.Name;

                memebersElement.Add(memeberElement);
            }

            var rootElement = new XElement("fraction");
            rootElement.Add(new XAttribute("id", fraction.Id));
            rootElement.Add(new XAttribute("membersCount", fraction.Members.Count));

            rootElement.Add(nameElement);
            rootElement.Add(planetsElement);
            rootElement.Add(memebersElement);

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(rootElement.ToString());

            return result.ToString();

        }

        public string ExportFractions()
        {
            var fractions = this.fractionsRepository.All();

            var rootElement = new XElement("fractions");

            foreach (var fraction in fractions)
            {
                var nameElement = new XElement("name");
                nameElement.Value = fraction.Name;

                var planetsElement = new XElement("planets");
                foreach (var planet in fraction.ProtectedPlanets)
                {
                    var planetElement = new XElement("planet");
                    planetElement.Value = planet.Name;

                    planetsElement.Add(planetElement);
                }

                var fractionElement = new XElement("fraction");
                fractionElement.Add(new XAttribute("id", fraction.Id));
                fractionElement.Add(new XAttribute("membersCount", fraction.Members.Count));

                fractionElement.Add(nameElement);
                fractionElement.Add(planetsElement);

                rootElement.Add(fractionElement);
            }

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(rootElement.ToString());

            return result.ToString();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var superhero = this.superheroRepository.All(s => s.Id == (int)superheroId).FirstOrDefault();
            var countries = this.countryRepository.All();
            var planets = this.planetRepository.All();

            var nameElement = new XElement("name");
            nameElement.Add(new XAttribute("id", superhero.Id));
            nameElement.Value = superhero.Name;

            var secretIdentityElement = new XElement("secretIdentity");
            secretIdentityElement.Value = superhero.SecretIdentity;

            var alignmentElement = new XElement("alignment");
            alignmentElement.Value = superhero.Alignment.ToString();

            var powersElement = new XElement("powers");
            foreach (var superPower in superhero.Powers)
            {
                var powerElement = new XElement("power");
                powerElement.Value = superPower.Name;

                powersElement.Add(powerElement);
            }

            var fractionsElement = new XElement("fractions");
            foreach (var fraction in superhero.Fractions)
            {
                var fractionElement = new XElement("fraction");
                fractionElement.Value = fraction.Name;

                fractionsElement.Add(fractionElement);
            }
            
            var cityEelement = new XElement("city");
            var city = superhero.City.Name;

            var country = countries.FirstOrDefault(c => c.Cities.Any(ci => ci.Name == city)).Name;
            var planet = planets.FirstOrDefault(p => p.Countries.Any(c => c.Name == country)).Name;
            cityEelement.Value = $"{city}, {country}, {planet}";

            var storyElement = new XElement("stroy");
            storyElement.Value = superhero.Story;

            var superheroElement = new XElement("superhero");
            superheroElement.Add(nameElement);
            superheroElement.Add(secretIdentityElement);
            superheroElement.Add(alignmentElement);
            superheroElement.Add(powersElement);
            superheroElement.Add(fractionsElement);
            superheroElement.Add(cityEelement);
            superheroElement.Add(storyElement);


            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(superheroElement.ToString());

            return result.ToString();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var superheroes = this.superheroRepository.All(s => s.City.Name == cityName);

            var rootElement = new XElement("superheroes");

            foreach (var superhero in superheroes)
            {

                var nameElement = new XElement("name");
                nameElement.Add(new XAttribute("id", superhero.Id));
                nameElement.Value = superhero.Name;

                var secretIdentityElement = new XElement("secretIdentity");
                secretIdentityElement.Value = superhero.SecretIdentity;

                var alignmentElement = new XElement("alignment");
                alignmentElement.Value = superhero.Alignment.ToString();

                var powersElement = new XElement("powers");
                foreach (var power in superhero.Powers)
                {
                    var powerElement = new XElement("power");
                    powerElement.Value = power.Name;

                    powersElement.Add(powerElement);
                }

                var superheroElement = new XElement("superhero");
                superheroElement.Add(nameElement);
                superheroElement.Add(secretIdentityElement);
                superheroElement.Add(alignmentElement);
                superheroElement.Add(powersElement);

                rootElement.Add(superheroElement);
            }

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(rootElement.ToString());

            return result.ToString();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var superheroes = this.superheroRepository.All(s => s.Powers.Any(p => p.Name == power));
            var countries = this.countryRepository.All();
            var planets = this.planetRepository.All();

            var rootElement = new XElement("superheroes");

            foreach (var superhero in superheroes)
            {

                var nameElement = new XElement("name");
                nameElement.Add(new XAttribute("id", superhero.Id));
                nameElement.Value = superhero.Name;

                var secretIdentityElement = new XElement("secretIdentity");
                secretIdentityElement.Value = superhero.SecretIdentity;

                var alignmentElement = new XElement("alignment");
                alignmentElement.Value = superhero.Alignment.ToString();

                var powersElement = new XElement("powers");
                foreach (var superPower in superhero.Powers)
                {
                    var powerElement = new XElement("power");
                    powerElement.Value = superPower.Name;

                    powersElement.Add(powerElement);
                }

                var cityEelement = new XElement("city");
                var city = superhero.City.Name;

                var country = countries.FirstOrDefault(c => c.Cities.Any(ci => ci.Name == city)).Name;
                var planet = planets.FirstOrDefault(p => p.Countries.Any(c => c.Name == country)).Name;
                cityEelement.Value = $"{city}, {country}, {planet}";

                var superheroElement = new XElement("superhero");
                superheroElement.Add(nameElement);
                superheroElement.Add(secretIdentityElement);
                superheroElement.Add(alignmentElement);
                superheroElement.Add(powersElement);
                superheroElement.Add(cityEelement);

                rootElement.Add(superheroElement);
            }

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var result = new StringBuilder();
            result.AppendLine(declaration.ToString());
            result.AppendLine(rootElement.ToString());

            return result.ToString();
        }
    }
}
