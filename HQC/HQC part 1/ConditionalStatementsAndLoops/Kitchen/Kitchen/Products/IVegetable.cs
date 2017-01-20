namespace Kitchen.Products
{
    using Types;

    public interface IVegetable
    {
        ColorType Color { get; set; }

        ConditionType Condition { get; set; }

        WhereLiveType Type { get; }

        PicancyType Picancy { get; }
    }
}
