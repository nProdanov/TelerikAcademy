namespace Shapes
{
    public class Rectangle : Shape, IShape
    {
        public Rectangle(double width, double height) 
            : base(width, height)
        {
        }

        public override double CalculateCalculateSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            return "Rectangle";
        }
    }
}
