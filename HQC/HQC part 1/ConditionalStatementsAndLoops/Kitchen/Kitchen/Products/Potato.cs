namespace Kitchen.Products
{
    using Types;

    public class Potato : Vegetable, IVegetable
    {
        public Potato()
            : base(ColorType.Yellow, ConditionType.OnePiece, WhereLiveType.Root, PicancyType.NotSpicy)
        {
        }
    }
}
