namespace Space3D
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> path;

        public Path()
        {
            this.path = new List<Point3D>();
        }

        public Point3D this[int index]
        {
            get
            {
                this.CheckForNegative(index);
                this.CheckForOutOFBoundaries(index);
                return this.path[index];
            }

            set
            {
                this.CheckForNegative(index);
                this.CheckForOutOFBoundaries(index);
                this.path[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this.path.Count;
            }
        }

        public void Add(Point3D point)
        {
            this.path.Add(point);
        }

        public override string ToString()
        {
            return string.Join(" -> ", this.path);
        }

        private void CheckForNegative(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index must be a non-negative integer number");
            }
        }

        private void CheckForOutOFBoundaries(int index)
        {
            if (index >= this.path.Count)
            {
                throw new ArgumentOutOfRangeException("The index is out of boundaries of a path");
            }
        }
    }
}
