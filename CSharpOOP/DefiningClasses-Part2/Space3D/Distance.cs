namespace Space3D
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            double deltaX = first.X - second.X;
            double deltaY = first.Y - second.Y;
            double deltaZ = first.Z - second.Z;
            double result = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
            return result;
        }
    }
}
