using System;
    class CircleRectangle
    {
        static void Main()
        {
            double xUser = double.Parse(Console.ReadLine());
            double yUser = double.Parse(Console.ReadLine());

            double xCircle = 1;
            double yCircle = 1;
            double rad = 1.5;
            //R(top=1, left=-1, width=6, height=2)
            double top = 1;
            double left = -1;
            double right = 5;
            double bottom = -1;
            if (((xUser-xCircle)*(xUser-xCircle)+(yUser-yCircle)*(yUser-yCircle))<=rad*rad)
            {
                Console.Write("inside circle ");
            }
            else
            {
                Console.Write("outside circle ");
            }
            if (xUser>=left&&xUser<=right&&yUser>=bottom&&yUser<=top)
            {
                Console.WriteLine("inside rectangle");
            }
            else
            {
                Console.WriteLine("outside rectangle");
            }

        }
    }

