namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Interfaces;

    public class Company : ICompany
    {
        private const int MinNameLength = 5;
        private const int RegistrationNumberExactLenght = 10;
        private ICollection<IFurniture> furnitures;
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }
        
        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Name can not be null or empty!");
                Validator.CheckIfMinStringLengthIsValid(value, Company.MinNameLength, "Company name can not less than 5 symbols long");

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                var regex = new Regex(@"^\d{10}$");
                var match = regex.Match(value);
                if (!match.Success)
                {
                    throw new ArgumentException("registrationNumber must constains exact 10 digits and nothing else!");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            Validator.CheckIfNull(furniture, "furniture can not be null!");

            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var productsCount = this.furnitures.Count;

            var strWithProductCatalog = new StringBuilder();
            strWithProductCatalog.Append(string.Format(
                "{0} - {1} - {2} {3}", 
                this.Name,
                this.RegistrationNumber,
                productsCount==0?"no": productsCount.ToString(),
                productsCount==1?"furniture":"furnitures"));
            if (productsCount == 0 )
            {
                return strWithProductCatalog.ToString();
            }

            strWithProductCatalog.AppendLine();
            var orderedProducts = this.furnitures.
                OrderBy(p => p.Price).
                ThenBy(p => p.Model);
            foreach (var prod in orderedProducts)
            {
                strWithProductCatalog.AppendLine(prod.ToString());
            }

            return strWithProductCatalog.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            Validator.CheckIfStringIsNullOrEmpty(model, "model is null or empty value!");
            var foundFurniture = this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());

            return foundFurniture;
        }

        public void Remove(IFurniture furniture)
        {
            Validator.CheckIfNull(furniture, "furniture is a null value!");
            this.furnitures.Remove(furniture);
        }
    }
}
