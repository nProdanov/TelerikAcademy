namespace Matrix
{
    using System;

    public class TestMatrix
    {
        public static void Separator()
        {
            Console.WriteLine(new string('-', 25));
        }

        public static void Main()
        {
            // Test addition and substact
            var myMatrix = new Matrix<double>(2, 2);
            myMatrix[0, 0] = 3.5;
            myMatrix[0, 1] = 8.5;
            myMatrix[1, 0] = 4.5;
            myMatrix[1, 1] = 6.5;

            var anotherMatrix = new Matrix<double>(2, 2);
            anotherMatrix[0, 0] = 4.1;
            anotherMatrix[0, 1] = 0.1;
            anotherMatrix[1, 0] = 1.1;
            anotherMatrix[1, 1] = -9.1;

            var substract = myMatrix - anotherMatrix;
            var addition = myMatrix + anotherMatrix;

            Console.WriteLine(substract);
            Separator();
            Console.WriteLine(addition);
            Separator();

            // Test Multiply
            var firstMulti = new Matrix<int>(2, 3);
            firstMulti[0, 0] = 1;
            firstMulti[0, 1] = 2;
            firstMulti[0, 2] = 3;
            firstMulti[1, 0] = 4;
            firstMulti[1, 1] = 5;
            firstMulti[1, 2] = 6;

            var secondMulti = new Matrix<int>(3, 2);
            secondMulti[0, 0] = 7;
            secondMulti[0, 1] = 8;
            secondMulti[1, 0] = 9;
            secondMulti[1, 1] = 10;
            secondMulti[2, 0] = 11;
            secondMulti[2, 1] = 12;

            if (firstMulti & secondMulti)
            {
                var multiplication = firstMulti * secondMulti;
                Console.WriteLine(multiplication);
            }
        }
    }
}
