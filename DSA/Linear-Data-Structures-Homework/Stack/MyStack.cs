using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int StartArraySize = 8;

        private T[] array;
        private int pointer;

        public MyStack()
        {
            this.array = new T[StartArraySize];
            this.pointer = 0;
        }

        public int Count
        {
            get
            {
                return this.pointer;
            }
        }

        public bool Contains(T value)
        {
            bool found = false;
            for (int i = 0; i < this.pointer; i++)
            {
                if (value.Equals(this.array[i]))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public void Push(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value to add cannot be null");
            }

            this.array[pointer] = value;
            pointer++;

            if (pointer >= this.array.Length)
            {
                ResizeTheArray();
            }
        }

        public T Pop()
        {
            if (this.pointer == 0)
            {
                throw new ArgumentException("Stack is empty");
            }

            this.pointer--;
            return this.array[this.pointer];
        }

        public T Peek()
        {
            if (this.pointer == 0)
            {
                throw new ArgumentException("Stack is empty");
            }
            
            return this.array[this.pointer - 1];
        }

        public void ResizeTheArray()
        {
            var newArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.pointer; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
