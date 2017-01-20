namespace Shapes
{
    public class Square : Rectangle, IShape
    {
        public Square(double width)
            : base(width, width)
        {
            this.Width = width;
            this.Height = width;
        }

        public override string ToString()
        {
            return "Square";
        }
    }
}
