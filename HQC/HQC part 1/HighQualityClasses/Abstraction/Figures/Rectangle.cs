using Abstraction.Figures.Contracts;
using Abstraction.Utils;

namespace Abstraction.Figures
{
    public class Rectangle : Figure, IFigure, IRectangle
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Rectangle width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Rectangle heigth");
                this.height = value;
            }
        }

        public override double GetArea
        {
            get
            {
                double surface = this.Width * this.Height;
                return surface;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                double perimeter = 2 * (this.Width + this.Height);
                return perimeter;
            }
        }
    }
}
