using System;

namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, ITraveller, IShopkeeper
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
