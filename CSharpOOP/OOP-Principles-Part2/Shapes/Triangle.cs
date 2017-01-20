namespace Shapes
{
    public class Triangle : Shape, IShape
    {
        public Triangle(double width, double height) 
            : base(width, height)
        {
        }

        public override double CalculateCalculateSurface()
        {
            var surface = (this.Width * this.Height) / 2;
            return surface;
        }

        public override string ToString()
        {
            return "Triangle";
        }
    }
}
