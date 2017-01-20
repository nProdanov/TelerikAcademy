namespace Kitchen
{
    using System;
    using System.Collections.Generic;

    using Products;
    using Products.Types;
    using Utensils;

    public class Chef
    {
        private ICollection<IVegetable> vegetables;

        public Chef()
        {
            this.vegetables = new List<IVegetable>();
        }

        public IVegetable Cut(IVegetable vegetableToCut)
        {
            if (vegetableToCut == null)
            {
                throw new ArgumentNullException("Vegetable");
            }

            vegetableToCut.Condition = ConditionType.ManyPieces;

            return vegetableToCut;
        }

        public void AddVegetable(IVegetable vegetableToAdd)
        {
            if (vegetableToAdd == null)
            {
                throw new ArgumentNullException("Vegetable");
            }

            this.vegetables.Add(vegetableToAdd);
        }
        
        public void Cook(IUtensil utensil)
        {
            if (utensil == null)
            {
                throw new ArgumentNullException("Utensil");
            }

            foreach (var vegetable in this.vegetables)
            {
                if (vegetable.Condition == ConditionType.OnePiece)
                {
                    utensil.ProductsInThere.Add(vegetable);
                }
                else
                {
                    utensil.ProductsInThere.Add(this.Cut(vegetable));
                }
            }

            utensil.IsFull = true;
        }
    }
}
