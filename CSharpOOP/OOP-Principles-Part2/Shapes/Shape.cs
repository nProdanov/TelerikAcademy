namespace Shapes
{
    using System;

    public abstract class Shape : IShape
    {
        protected double width;
        protected double heigth;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.heigth;
            }
            protected set
            {
                this.CheckInputValues(value);
                this.heigth = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                this.CheckInputValues(value);
                this.width = value;
            }
        }

        public abstract double CalculateCalculateSurface();
        
        protected void CheckInputValues(double value)
        {
            if (value<=0)
            {
                throw new ArgumentOutOfRangeException("Value must be positive");
            }
        }
    }
}
