using System;

using Abstraction.Figures.Contracts;
using Abstraction.Utils;

namespace Abstraction.Figures
{
    public class Circle : Figure, IFigure, ICircle
    {
        private double radius;

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Radius");
                this.radius = value;
            }
        }

        public override double GetArea
        {
            get
            {
                double surface = Math.PI * this.Radius * this.Radius;
                return surface;
            }
        }

        public override double GetPerimeter
        {
            get
            {
                double perimeter = 2 * Math.PI * this.Radius;
                return perimeter;
            }
        }
    }
}
