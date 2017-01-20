namespace Generics
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private T[] array;
        private int currLength;

        public GenericList()
        {
            this.array = new T[16];
            this.currLength = 0;
        }

        public int Count
        {
            get
            {
                return this.currLength;
            }
        }

        public T this[int index]
        {
            get
            {
                this.CheckBoundaries(index);
                return this.array[index];
            }

            set
            {
                this.CheckBoundaries(index);
                this.array[index] = value;
            }
        }

        public T Max()
        {
            if (this.currLength < 1)
            {
                throw new ArgumentException("The array is empty");
            }

            var max = this.array[0];

            for (int i = 1; i < this.currLength; i++)
            {
                if (max.CompareTo(this.array[i]) < 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public T Min()
        {
            if (this.currLength < 1)
            {
                throw new ArgumentException("The array is empty");
            }

            var min = this.array[0];

            for (int i = 1; i < this.currLength; i++)
            {
                if (min.CompareTo(this.array[i]) > 0)
                {
                    min = this.array[i];
                }
            }

            return min;
        }

        public int IndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < this.currLength; i++)
            {
                if (this.array[i].Equals(element))
                {
                    result = i;
                }
            }

            return result;
        }

        public void Add(T element)
        {
            this.CheckForGrow();
            this.array[this.currLength] = element;
            this.currLength++;
        }

        public void RemoveAt(int index)
        {
            this.CheckBoundaries(index);
            for (int i = index; i < this.currLength - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.currLength--;
        }

        public void Insert(T element, int index)
        {
            this.CheckBoundaries(index);
            this.CheckForGrow();
            this.currLength++;

            for (int i = this.currLength - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = element;
        }

        public void Clear()
        {
            this.array = new T[16];
            this.currLength = 0;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.currLength; i++)
            {
                result.Append(this.array[i]);

                if (i + 1 != this.currLength)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }

        private void CheckForGrow()
        {
            if (this.currLength == this.array.Length && this.currLength != 0)
            {
                T[] tempArray = new T[this.currLength * 2];
                for (int i = 0; i < this.currLength; i++)
                {
                    tempArray[i] = this.array[i];
                }

                this.array = tempArray;
            }
        }

        private void CheckBoundaries(int index)
        {
            if (this.currLength == 0)
            {
                throw new ArgumentException("The array is empty");
            }

            if (index < 0 || index >= this.currLength)
            {
                throw new ArgumentOutOfRangeException("The index is out of boudaries of an array");
            }
        }
    }
}
