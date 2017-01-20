namespace Matrix
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        public int Rows
        {
            get
            {
                if (this.rows < 1)
                {
                    throw new ArgumentException("Empty matrix");
                }

                return this.rows;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The number of rows must be a positive number");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                if (this.cols < 1)
                {
                    throw new ArgumentException("Empty matrix");
                }

                return this.cols;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The number of cols must be a positive number");
                }

                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.CheckRow(row);
                this.CheckCol(col);
                return this.matrix[row, col];
            }

            set
            {
                this.CheckRow(row);
                this.CheckCol(col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            CheckForAddSubstract(first, second);
            Matrix<T> result = new Matrix<T>(first.rows, first.cols);

            for (int rows = 0; rows < first.Rows; rows++)
            {
                for (int cols = 0; cols < first.Cols; cols++)
                {
                    result[rows, cols] = (dynamic)first[rows, cols] + (dynamic)second[rows, cols];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            CheckForAddSubstract(first, second);
            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

            for (int rows = 0; rows < first.Rows; rows++)
            {
                for (int cols = 0; cols < first.Cols; cols++)
                {
                    result[rows, cols] = (dynamic)first[rows, cols] - (dynamic)second[rows, cols];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            CheckMultiply(first, second);
            var result = new Matrix<T>(first.Rows, second.Cols);

            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < second.Cols; col++)
                {
                    for (int i = 0; i < first.Cols; i++)
                    {
                        result[row, col] += (dynamic)first[row, i] * (dynamic)second[i, col];
                    }
                }
            }

            return result;
        }

         public static bool operator true(Matrix<T> sample)
        {
            for (int row = 0; row < sample.Rows; row++)
            {
                for (int col = 0; col < sample.Cols; col++)
                {
                    if (sample[row, col] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> sample)
        {
            for (int row = 0; row < sample.Rows; row++)
            {
                for (int col = 0; col < sample.Cols; col++)
                {
                    if (sample[row, col] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator &(Matrix<T> first, Matrix<T> second)
        {
            if (first)
            {
                if (second)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this.matrix[row, col]);
                    if (row + 1 != this.Rows)
                    {
                        result.Append(", ");
                    }
                    else
                    {
                        if (col + 1 != this.Cols)
                        {
                            result.Append(", ");
                        }
                    }
                }

                if (row + 1 != this.Rows)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }

        private static void CheckMultiply(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Cols)
            {
                throw new ArgumentException("For Operation Multiply the rows of the first matrix must be the same as the cols of second");
            }
        }

        private static void CheckForAddSubstract(Matrix<T> first, Matrix<T> second)
        {
            if (first.Cols != second.Cols || first.Rows != second.Rows)
            {
                throw new ArgumentException("Operations Add and Substact can be applied only for matrices with same size");
            }
        }

        private void CheckCol(int col)
        {
            if (col < 0 || col >= this.Cols)
            {
                throw new ArgumentException("Col value is out of boundaries");
            }
        }

        private void CheckRow(int row)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new ArgumentException("Row value is out of boundaries");
            }
        }
    }
}
