using System;
using System.Text;

namespace RotatingWalk
{
    public class SquareMatrix
    {
        private int[,] matrix;

        private int size;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[size, size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0 || 100 < value)
                {
                    throw new ArgumentOutOfRangeException("Size of the Matrix");
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public void SetValue(int rowPos, int colPos, int cellValue)
        {
            if (this.IsNextPositionValid(rowPos, colPos))
            {
                this.matrix[rowPos, colPos] = cellValue;
            }
            else
            {
                throw new ArgumentException("Passed position is not valid");
            }
        }

        public bool IsNextPositionValid(int nextRowPos, int nextColPos)
        {
            bool isNextRowPositionInRange = 0 <= nextRowPos && nextRowPos < this.size;
            bool isNextColPositionInRange = 0 <= nextColPos && nextColPos < this.size;
            bool isNextPositionInRange = isNextRowPositionInRange && isNextColPositionInRange;

            return isNextPositionInRange && this.matrix[nextRowPos, nextColPos] == 0;
        }

        public int[] GetFirstEmptyPosition()
        {
            int[] emptyPos = new int[2];

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    if (this.matrix[row, col] == 0)
                    {
                        emptyPos[0] = row;
                        emptyPos[1] = col;
                        return emptyPos;
                    }
                }
            }

            return null;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    result.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
