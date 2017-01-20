using System;
using System.Reflection;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public Dealer Dealer { get; set; }

        public object this[string propertyName]
        {
            get
            {
                if(propertyName == "Dealer")
                {
                    Type dealer = typeof(Dealer);
                    PropertyInfo dealerName = dealer.GetProperty("Name");
                    return dealerName.GetValue(Dealer, null);
                }

                if (propertyName == "Manufacturer")
                {
                    propertyName = "ManufacturerName";
                }

                Type car = typeof(Car);
                PropertyInfo myPropInfo = car.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
        }
    }
}
