namespace Kitchen.Products
{
    using Types;

    public class Bean : Vegetable, IVegetable
    {
        public Bean()
            : base(ColorType.White, ConditionType.ManyPieces, WhereLiveType.Plant, PicancyType.NotSpicy)
        {
        }
    }
}
