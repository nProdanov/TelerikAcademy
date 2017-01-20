namespace ShapeTestClient
{
    using System;
    using Shapes;

    class ShapeTest
    {
        static void Main()
        {
            var shapesArr = new IShape[] { new Square(4), new Rectangle(4, 5), new Triangle(2, 3) };

            foreach (var shape in shapesArr)
            {
                Console.WriteLine(string.Format("Surface of {0} is: {1:F2}", shape, shape.CalculateCalculateSurface()));
            }
        }
    }
}
