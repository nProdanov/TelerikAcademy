using CohesionAndCoupling.Utils;

namespace CohesionAndCoupling
{
    public class Parallelepiped
    {
        private double width;
        private double height;
        private double dept;

        public Parallelepiped(double width, double height, double dept)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = dept;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Parallelepiped width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Parallelepiped height");
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.dept;
            }
            private set
            {
                Validator.ValidateFigurePart(value, "Parallelepiped dept");
                this.dept = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
