namespace Space3D
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D Start;

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D StartPoint
        {
            get
            {
                return Start;
            }
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public override string ToString()
        {
            return string.Format("{{{0:F2}, {1:F2}, {2:F2} }}", this.X, this.Y, this.Z);
        }

        public static Point3D Parse(string pointStr)
        {
            var arr = pointStr.Split(new char[] { ' ', ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            var x = double.Parse(arr[0]);
            var y = double.Parse(arr[1]);
            var z = double.Parse(arr[2]);
            return new Point3D(x, y, z);
        }
    }
}
