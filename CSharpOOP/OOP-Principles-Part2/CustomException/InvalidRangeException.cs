namespace CustomException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {
        private T min;
        private T max;

        public InvalidRangeException(string message, T min, T max, Exception e)
            : base(string.Format("{0} Parameter must be in range between {1} and {2}",message,  min, max), e)
        {
            this.Min = Min;
            this.Max = Max;
        }

        public InvalidRangeException(string message, T min, T max)
            : this(message, min, max, null)
        {
        }

        public T Min
        {
            get
            {
                return this.min;
            }

            private set
            {
                this.min = value;
            }
        }

        public T Max
        {
            get
            {
                return this.max;
            }

            private set
            {
                this.max = value;
            }
        }
    }
}
