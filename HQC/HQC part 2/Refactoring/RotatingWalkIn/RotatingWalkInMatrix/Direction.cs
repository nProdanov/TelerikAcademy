namespace RotatingWalk
{
    public class Direction
    {
        private static int[] deltasX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] deltasY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private DirectionType currentDirection;

        public Direction()
        {
            this.currentDirection = DirectionType.RightDown;
            this.X = deltasX[(int)this.currentDirection];
            this.Y = deltasY[(int)this.currentDirection];
        }

        public static Direction StartDirection
        {
            get
            {
                return new Direction();
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public void GetNextDirection()
        {
            if ((int)this.currentDirection == 7)
            {
                this.currentDirection = (DirectionType)0;
            }
            else
            {
                this.currentDirection = (DirectionType)((int)this.currentDirection + 1);
            }

            this.X = deltasX[(int)this.currentDirection];
            this.Y = deltasY[(int)this.currentDirection];
        }
    }
}
