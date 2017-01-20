using System;

namespace RotatingWalk
{
    public class StartPoint
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            int squareMatrixSize = int.Parse(Console.ReadLine());

            var squareMatrix = new SquareMatrix(squareMatrixSize);
            var fillingLogic = new RotatingWalkLogic(
                squareMatrix,
                new Position(0, 0),
                Direction.StartDirection,
                1);

            fillingLogic.FillMatrix();

            Console.WriteLine(squareMatrix.ToString());
        }
    }
}
