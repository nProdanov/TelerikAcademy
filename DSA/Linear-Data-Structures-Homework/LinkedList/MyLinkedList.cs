using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private int count;
        private ListItem<T> firstItem;
        private ListItem<T> lastItem;

        public MyLinkedList()
        {
            this.count = 0;
        }

        public ListItem<T> FirstItem
        {
            get
            {
                return this.firstItem;
            }
            set
            {
                this.ValidateIfItemIsNull(value, "First item cannot be null");
                this.firstItem = value;
            }
        }

        public ListItem<T> LastItem
        {
            get
            {
                if (this.lastItem == null)
                {
                    this.lastItem = this.GetLastItem();
                }

                return this.lastItem;
            }

            private set
            {
                this.ValidateIfItemIsNull(value, "Last item cannot be null");
                this.lastItem = value;
            }
        }

        public int Count
        {
            get
            {
                if (this.FirstItem != null)
                {
                    if (this.count == 0)
                    {
                        this.count = this.GetCount();
                    }
                }
                else
                {
                    if (this.count != 0)
                    {
                        this.count = 0;
                    }
                }

                return this.count;
            }
        }

        public ListItem<T> Find(T value)
        {
            ListItem<T> result = null;
            var currentItem = this.FirstItem;
            while (currentItem != null)
            {
                if (currentItem.Value.Equals(value))
                {
                    result = currentItem;
                    break;
                }

                currentItem = currentItem.NextItem;
            }

            return result;
        }

        public void Clear()
        {
            this.firstItem = null;
            this.lastItem = null;
            this.count = 0;
        }

        public void AddFirst(T itemToAdd)
        {
            this.ValidateIfItemIsNull(itemToAdd, "Item to add first cannot be null");

            var linkedListToAdd = new ListItem<T>(itemToAdd);
            linkedListToAdd.NextItem = this.firstItem;
            this.firstItem = linkedListToAdd;
            this.count++;
        }

        public void AddLast(T itemToAdd)
        {
            this.ValidateIfItemIsNull(itemToAdd, "Item to add last cannot be null");
            var linkedListToAdd = new ListItem<T>(itemToAdd);
            this.LastItem.NextItem = linkedListToAdd;
            this.lastItem = linkedListToAdd;
            this.count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentItem = this.FirstItem;

            while (currentItem != null)
            {
                yield return currentItem.Value;
                currentItem = currentItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetCount()
        {
            var count = 0;
            foreach (var item in this)
            {
                count++;
            }

            return count;
        }

        private ListItem<T> GetLastItem()
        {
            var lastItem = this.FirstItem;
            if (lastItem == null)
            {
                throw new ArgumentNullException("No items in list");
            }

            while (true)
            {
                if (lastItem.NextItem != null)
                {
                    lastItem = lastItem.NextItem;
                }
                else
                {
                    break;
                }
            }

            return lastItem;
        }

        private void ValidateIfItemIsNull(object item, string message)
        {
            if (item == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
