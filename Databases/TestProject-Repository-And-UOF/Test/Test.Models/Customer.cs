using System.Collections.Generic;

namespace Test.Models
{
    public class Customer
    {
        private ICollection<Product> products;

        public Customer()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
