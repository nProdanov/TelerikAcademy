namespace Kitchen.Products
{
    using Types;

    public class Carrot : Vegetable, IVegetable
    {
        public Carrot()
            : base(
                  ColorType.Orange,
                  ConditionType.OnePiece,
                  WhereLiveType.Root, 
                  PicancyType.NotSpicy)
        {
        }
    }
}
