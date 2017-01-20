namespace Kitchen.Utensils
{
    public class Bowl : Utensil, IUtensil
    {
        private const double Capacity = 3;

        public Bowl() 
            : base(Bowl.Capacity)
        {
        }
    }
}
