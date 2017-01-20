using System.Text;

using Abstraction.Figures.Contracts;

namespace Abstraction.Figures
{
    public abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double GetArea { get; }

        public abstract double GetPerimeter { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0}:", this.GetType().Name).AppendLine();
            result.AppendFormat("Perimeter: {0}cm", this.GetPerimeter).AppendLine();
            result.AppendFormat("Surface: {0}cm2", this.GetArea).AppendLine();
            result.Append(new string('-', 20));

            return result.ToString();
        }
    }
}
