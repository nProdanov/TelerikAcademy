using System;

using CohesionAndCoupling.Utils;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FilesUtil.GetFileExtension("example"));
            Console.WriteLine(FilesUtil.GetFileExtension("example.pdf"));
            Console.WriteLine(FilesUtil.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FilesUtil.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FilesUtil.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FilesUtil.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceCalculator.CalcDistance2D(1, -2, 3, 4));

            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var figure = new Parallelepiped(3, 5, 7);

            Console.WriteLine("Volume = {0:f2}", figure.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", figure.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure.CalcDiagonalYZ());
        }
    }
}
