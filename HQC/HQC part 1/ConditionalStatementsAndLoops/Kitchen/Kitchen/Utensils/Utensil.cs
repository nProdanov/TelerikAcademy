namespace Kitchen.Utensils
{
    using System;
    using System.Collections.Generic;

    using Products;

    public abstract class Utensil : IUtensil
    {
        protected double capacityInLiters;
        protected ICollection<IVegetable> productsInThere;

        public Utensil(double capacityInLiters)
        {
            this.CapacityInLiters = capacityInLiters;
            this.IsFull = false;
            this.productsInThere = new List<IVegetable>();
        }

        public double CapacityInLiters
        {
            get
            {
                return this.capacityInLiters;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity", "can not be less or equal to 0!");
                }

                this.capacityInLiters = value;
            }
        }

        public bool IsFull { get; set; }

        public ICollection<IVegetable> ProductsInThere
        {
            get
            {
                return this.productsInThere;
            }
        }
    }
}
