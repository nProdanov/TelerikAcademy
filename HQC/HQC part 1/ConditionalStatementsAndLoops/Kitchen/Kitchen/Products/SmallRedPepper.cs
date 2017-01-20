namespace Kitchen.Products
{
    using Types;

    public class SmallRedPepper : Vegetable, IVegetable
    {
        public SmallRedPepper() 
            : base(ColorType.Red, ConditionType.OnePiece, WhereLiveType.Plant, PicancyType.Spicy)
        {
        }
    }
}
