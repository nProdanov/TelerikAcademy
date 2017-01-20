using System;

namespace LinkedList
{
    public class ListItem<T> 
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.Value = value;
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }
            set
            {
                this.nextItem = value; 
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value cannot be null");
                }
                this.value = value;
            }
        }
    }
}
