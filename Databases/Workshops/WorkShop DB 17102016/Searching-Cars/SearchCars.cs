using Cars;
using Import_Cars_From_Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;

namespace Searching_Cars
{
    class SearchCars
    {
        public const string JsonFileUrl = "..\\..\\data.1.json";
        public const string QueriesXmlUrl = "..\\..\\queries.xml";

        static void Main(string[] args)
        {
            var cars = LoadDB(JsonFileUrl);

            var xmlQuery = new Query();
            GetXmlQueries(xmlQuery, QueriesXmlUrl);

            var clauses = xmlQuery.WhereClause;
            var filteredCars = FilterCarsByQuery(clauses, cars);
    
            var orderedCars = filteredCars.OrderBy(car => car[xmlQuery.OrderBy]);

            var dealers = cars.Select(car => car.Dealer).GroupBy(dealer => dealer.Name);

            var outPutFileUrl = $"..\\..\\{xmlQuery.ResultFileName}";

            GenerateXmlResult(outPutFileUrl, orderedCars, dealers);
        }

        public static void GenerateXmlResult(string outPutFileUrl, IEnumerable<Car> cars, IEnumerable<IGrouping<string, Dealer>> dealers)
        {
            using (XmlWriter writer = XmlWriter.Create(outPutFileUrl))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Cars");
                writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");

                foreach (var car in cars)
                {
                    writer.WriteStartElement("Car");
                    writer.WriteAttributeString("Manufacturer", car.ManufacturerName);
                    writer.WriteAttributeString("Model", car.Model);
                    writer.WriteAttributeString("Year", car.Year.ToString());
                    writer.WriteAttributeString("Price", car.Price.ToString());

                    writer.WriteStartElement("TransmissionType");
                    writer.WriteString(car.TransmissionType.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("Dealer");
                    writer.WriteAttributeString("Name", car.Dealer.Name);

                    writer.WriteStartElement("Cities");

                    var cities = dealers
                        .Where(group => group.Key == car.Dealer.Name)
                        .FirstOrDefault()
                        .Select(d => d.City)
                        .Distinct();

                    foreach (var city in cities)
                    {
                        writer.WriteStartElement("City");
                        writer.WriteString(city);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }

        public static IEnumerable<Car> FilterCarsByQuery(WhereClause clauses, IEnumerable<Car> cars)
        {
            for (int queryCount = 0; queryCount < clauses.PropertyName.Count; queryCount++)
            {
                int comparingOperatorQuery = (int)clauses.ComparingOperator[queryCount];
                string propertyNameQuery = clauses.PropertyName[queryCount];
                switch (propertyNameQuery)
                {
                    case "Year":
                        cars = cars
                           .Where(car =>
                           {
                               int yearQuery = int.Parse(clauses.Property[queryCount]);
                               return car.Year.CompareTo(yearQuery) == comparingOperatorQuery;
                           });
                        break;

                    case "Price":
                        cars = cars
                            .Where(car =>
                            {
                                decimal priceQUery = decimal.Parse(clauses.Property[queryCount]);
                                return car.Price.CompareTo(priceQUery) == comparingOperatorQuery;
                            });
                        break;

                    case "Model":
                        string modelQuery = clauses.Property[queryCount].ToLower();

                        cars = cars
                            .Where(car =>
                            {
                                if (comparingOperatorQuery == 2)
                                {
                                    return car.Model.IndexOf(modelQuery) >= 0;
                                }
                                else
                                {
                                    return car.Model.ToLower().Equals(modelQuery);
                                }
                            });
                        break;

                    case "Manufacturer":
                        string manufacturerQuery = clauses.Property[queryCount].ToLower();

                        cars = cars
                            .Where(car =>
                            {
                                if (comparingOperatorQuery == 2)
                                {
                                    return car.ManufacturerName.IndexOf(manufacturerQuery) >= 0;
                                }
                                else
                                {
                                    return car.ManufacturerName.ToLower().Equals(manufacturerQuery);
                                }
                            });
                        break;

                    case "Dealer":
                        string dealerNameQUery = clauses.Property[queryCount].ToLower();

                        cars = cars
                            .Where(car =>
                            {
                                if (comparingOperatorQuery == 2)
                                {
                                    return car.Dealer.Name.IndexOf(dealerNameQUery) >= 0;
                                }
                                else
                                {
                                    return car.Dealer.Name.ToLower().Equals(dealerNameQUery);
                                }
                            });
                        break;

                    case "City":
                        string cityQuery = clauses.Property[queryCount].ToLower();

                        cars = cars
                            .Where(car => car.Dealer.City.ToLower().Equals(cityQuery));
                        break;
                }
                if (queryCount == clauses.Property.Count -1)
                {
                    return cars;
                }
            }
            return null;
        }

        public static void GetXmlQueries(Query xmlQuery, string queriesXmlUrl)
        {
            using (XmlReader reader = XmlReader.Create(queriesXmlUrl))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "OrderBy")
                        {
                            xmlQuery.OrderBy = reader.ReadElementString();
                        }

                        if (reader.Name == "WhereClause")
                        {
                            xmlQuery.WhereClause.PropertyName.Add(reader.GetAttribute("PropertyName"));
                            xmlQuery.WhereClause.ComparingOperator.Add((ComparingOperatorType)Enum.Parse(typeof(ComparingOperatorType), reader.GetAttribute("Type")));
                            xmlQuery.WhereClause.Property.Add(reader.ReadElementString());
                        }

                        if (reader.Name == "Query")
                        {
                            xmlQuery.ResultFileName = reader.GetAttribute("OutputFileName");
                        }
                    }
                }
            }
        }

        public static IEnumerable<Car> LoadDB(string jsonFileUrl)
        {
            string jsonText = GetJsonAsText(jsonFileUrl);
            return JsonToPoco.CarJsonParser(jsonText);
        }

        public static string GetJsonAsText(string jsonFileUrl)
        {
            return File.ReadAllText(jsonFileUrl);
        }
    }
}
