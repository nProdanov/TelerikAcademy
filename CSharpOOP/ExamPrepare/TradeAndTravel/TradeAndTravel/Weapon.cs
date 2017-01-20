namespace TradeAndTravel
{
    using System.Collections.Generic;

    public class Weapon : Item
    {
        private const int MoneyValue = 10;

        public Weapon(string name, Location location = null)
            :base(name, Weapon.MoneyValue, ItemType.Weapon, location)
        {
        }

        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron, ItemType.Wood };
        }
    }
}
