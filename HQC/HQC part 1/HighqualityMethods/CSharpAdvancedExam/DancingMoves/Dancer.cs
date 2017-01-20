namespace DancingMoves
{
    internal class Dancer
    {
        private int moves;

        internal Dancer(int[] path)
        {
            this.Path = path;
            this.Points = 0;
            this.CurrentPosition = 0;
            this.moves = 0;
        }

        internal int[] Path { get; set; }

        internal long Points { get; private set; }

        internal int CurrentPosition { get; set; }

        internal double AveragePointsPerLine
        {
            get
            {
                return this.Points / (double)this.moves;
            }
        }

        internal void MoveRight(int moves, int step)
        {
            for (int i = 0; i < moves; i++)
            {
                int actualStep = step % this.Path.Length;
                if (this.CurrentPosition + actualStep < this.Path.Length)
                {
                    this.CurrentPosition += actualStep;
                }
                else
                {
                    this.CurrentPosition = (this.CurrentPosition + actualStep) - this.Path.Length;
                }

                this.Points += this.Path[this.CurrentPosition];
            }

            this.moves++;
        }

        internal void MoveLeft(int moves, int step)
        {
            for (int i = 0; i < moves; i++)
            {
                int actualStep = step % this.Path.Length;
                if (this.CurrentPosition - actualStep >= 0)
                {
                    this.CurrentPosition -= actualStep;
                }
                else
                {
                    this.CurrentPosition = this.Path.Length - (actualStep - this.CurrentPosition);
                }

                this.Points += this.Path[this.CurrentPosition];
            }

            this.moves++;
        }
    }
}
