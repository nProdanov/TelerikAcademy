namespace Test.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}