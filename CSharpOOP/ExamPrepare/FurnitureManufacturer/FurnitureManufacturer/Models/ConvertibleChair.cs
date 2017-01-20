namespace FurnitureManufacturer.Models
{
    using System.Text;

    using Interfaces;

    public class ConvertibleChair : AdjustableChair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private readonly decimal InitialHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.InitialHeight = this.Height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (IsConverted)
            {
                this.IsConverted = false;
                this.SetHeight(this.InitialHeight);
            }
            else
            {
                this.IsConverted = true;
                this.SetHeight(ConvertibleChair.ConvertedHeight);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));

            return result.ToString();
        }
    }
}
