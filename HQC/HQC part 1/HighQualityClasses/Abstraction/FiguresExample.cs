using System;
using System.Collections.Generic;

using Abstraction.Figures;
using Abstraction.Figures.Contracts;

namespace Abstraction
{
    public class FiguresExample
    {
        public static void Main()
        {
            var figures = new List<IFigure>();
            figures.Add(new Rectangle(45, 23));
            figures.Add(new Rectangle(12, 21));
            figures.Add(new Circle(3));
            figures.Add(new Rectangle(10, 10));
            figures.Add(new Circle(10));

            foreach (var fig in figures)
            {
                Console.WriteLine(fig.ToString());
            }
        }
    }
}
