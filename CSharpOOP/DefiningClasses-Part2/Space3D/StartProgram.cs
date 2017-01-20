namespace Space3D
{
    using System;

    public class StartProgram
    {
        public static void PrintSeparator()
        {
            Console.WriteLine(new string('-', 25));
        }

        public static void Main()
        {
            var firstPoint = new Point3D(3, 4, 5);
            var secondPoint = new Point3D(12, 40, 4);
            var thirdPoint = new Point3D(141, 45, 63);
            var fourthPoint = new Point3D(34, 543, 12);

            var dist = Distance.CalculateDistance(firstPoint, secondPoint);  // task3

            var list = new Path(); // task4 - part1
            list.Add(firstPoint);
            list.Add(secondPoint);
            list.Add(thirdPoint);
            list[1] = fourthPoint;

            var path = new Path(); // task4 - part2
            path.Add(firstPoint);
            path.Add(secondPoint);
            path.Add(thirdPoint);
            PathStorage.SavePath(path, "text");
            var newPath = PathStorage.LoadPath("..//..//text.txt");

            // Test Task2
            Console.WriteLine(Point3D.StartPoint);
            PrintSeparator();

            // Test Task3
            Console.WriteLine(dist);
            PrintSeparator();

            // Test Task4 - part1
            Console.WriteLine(list[1]);
            Console.WriteLine(list);
            PrintSeparator();

            //Test Task4 - part2
            Console.WriteLine(newPath);














        }
    }
}
