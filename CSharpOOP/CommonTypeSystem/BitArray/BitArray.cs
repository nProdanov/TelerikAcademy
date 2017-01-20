namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray : IComparable<BitArray>, IEnumerable<int>
    {
        private ulong number;

        public BitArray(ulong num)
        {
            this.Number = num;
        }

        public ulong Number
        {
            get
            {
               return this.number;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ulong values start from 0");
                }

                if (value > ulong.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Max value of Ulong is: {0}", ulong.MaxValue));
                }

                this.number = value;
            }
        }

        public int this[int index]
        {
            get
            {
                this.CheckOutOfRangeindex(index);
                return (int)((this.Number >> index) & 1);
            }
            set
            {
                this.CheckOutOfRangeindex(index);
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Invalid bit value");
                }

                if ((int)((this.Number >> index) & 1) != value)
                {
                    var mask = (ulong)1 << index;
                    this.Number ^= mask;
                }   
            }
        }

        public static bool operator ==(BitArray first, BitArray second)
        {
            if (first.Number == second.Number)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(BitArray first, BitArray second)
        {
            if (first.Number != second.Number)
            {
                return false;
            }

            return true;
        }

        public int CompareTo(BitArray other)
        {
            if (this.Number.CompareTo(other.Number) < 0)
            {
                return -1;
            }

            if (this.Number.CompareTo(other.Number) > 0)
            {
                return 1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            var anotherBitArray = obj as BitArray;
            if (anotherBitArray == null)
            {
                return false;
            }

            return this.Number.Equals(anotherBitArray.Number);
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                result.Insert(0, (this.Number >> i) & 1);
            }

            return result.ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckOutOfRangeindex(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new ArgumentOutOfRangeException("Index is out of boundaries");
            }
        }
    }
}
