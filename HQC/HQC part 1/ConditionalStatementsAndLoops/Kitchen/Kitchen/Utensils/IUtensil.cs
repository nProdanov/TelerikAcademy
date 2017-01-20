namespace Kitchen.Utensils
{
    using System.Collections.Generic;

    using Products;

    public interface IUtensil
    {
        double CapacityInLiters { get; }

        bool IsFull { get; set; }

        ICollection<IVegetable> ProductsInThere { get; }
    }
}
