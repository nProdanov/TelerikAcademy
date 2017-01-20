namespace RotatingWalk
{
    public class RotatingWalkLogic
    {
        private SquareMatrix squareMatrix;
        private Position currPos;
        private Direction currDir;
        private int currCellValue;

        public RotatingWalkLogic(SquareMatrix squareMatrix, Position startPos, Direction startDir, int firstCellValue)
        {
            this.squareMatrix = squareMatrix;
            this.currPos = startPos;
            this.currDir = startDir;
            this.currCellValue = firstCellValue;
        }

        public void FillMatrix()
        {
            while (true)
            {
                this.squareMatrix.SetValue(this.currPos.X, this.currPos.Y, this.currCellValue);

                if (!this.IsThereEmptyNeighbourCell())
                {
                    var emptyPos = this.squareMatrix.GetFirstEmptyPosition();
                    if (emptyPos != null)
                    {
                        this.currCellValue++;
                        this.currPos.X = emptyPos[0];
                        this.currPos.Y = emptyPos[1];
                        this.currDir = Direction.StartDirection;
                        this.FillMatrix();
                    }

                    break;
                }

                this.GetNextValidDirection();

                this.currPos.X += this.currDir.X;
                this.currPos.Y += this.currDir.Y;
                this.currCellValue++;
            }
        }

        private void GetNextValidDirection()
        {
            var nextPos = new Position(this.currPos.X + this.currDir.X, this.currPos.Y + this.currDir.Y);
            bool isNextPositionValid = this.squareMatrix.IsNextPositionValid(nextPos.X, nextPos.Y);

            while (!isNextPositionValid)
            {
                this.currDir.GetNextDirection();

                nextPos.X = this.currPos.X + this.currDir.X;
                nextPos.Y = this.currPos.Y + this.currDir.Y;
                isNextPositionValid = this.squareMatrix.IsNextPositionValid(nextPos.X, nextPos.Y);
            }
        }

        private bool IsThereEmptyNeighbourCell()
        {
            var direction = Direction.StartDirection;
            var nextPos = new Position(this.currPos.X + direction.X, this.currPos.Y + direction.Y);

            for (int i = 0; i < 8; i++)
            {
                if (this.squareMatrix.IsNextPositionValid(nextPos.X, nextPos.Y))
                {
                    return true;
                }

                direction.GetNextDirection();
                nextPos.X = this.currPos.X + direction.X;
                nextPos.Y = this.currPos.Y + direction.Y;
            }

            return false;
        }
    }
}
