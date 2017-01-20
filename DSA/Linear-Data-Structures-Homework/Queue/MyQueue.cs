using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> linkedList;

        public MyQueue()
        {
            this.linkedList = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.linkedList.Count;
            }
        }

        public void Enque(T value)
        {
            this.linkedList.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.linkedList.Count == 0)
            {
                throw new ArgumentException("Queue is empty");
            }

            var result = this.linkedList.First.Value;
            this.linkedList.RemoveFirst();

            return result;
        }

        public T Peek()
        {
            if (this.linkedList.Count == 0)
            {
                throw new ArgumentException("Queue is empty");
            }

            return this.linkedList.First.Value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
