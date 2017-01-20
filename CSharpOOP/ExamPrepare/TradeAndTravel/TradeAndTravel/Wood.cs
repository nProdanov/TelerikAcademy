namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int MoneyValue = 2;

        public Wood(string name, Location location = null) 
            : base(name, Wood.MoneyValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
           if(interaction == "drop")
            {
                if (Value > 0)
                {
                    this.Value -= 1;
                }   
            }
        }
    }
}
