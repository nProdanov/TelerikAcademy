namespace Kitchen.Products
{
    using Types;

    public class Zucchini : Vegetable, IVegetable
    {
        public Zucchini() 
            : base(ColorType.Green, ConditionType.OnePiece, WhereLiveType.Ground, PicancyType.NotSpicy)
        {
        }
    }
}
