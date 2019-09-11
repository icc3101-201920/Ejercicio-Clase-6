using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_LINQ
{
    public class CustomList<T>
    {
        private T[] items;
        private int count;

        public T[] Items { get => items; set => items = value; }
        public int Count { get => count; private set => count = value; }

        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
        public CustomList()
        {
            Items = new T[1];
            Count = 0;
        }

        public CustomList(T[] elements)
        {
            Items = elements.Clone() as T[];
            Count = elements.Length;
        }

        public void Append(T element)
        {
            T[] tempArray = Items.Clone() as T[];
            Items = new T[Count + 1];
            tempArray.CopyTo(Items, 0);
            Items[Count] = element;
            Count += 1;
        }

        public void Prepend(T element)
        {
            T[] tempArray = Items.Clone() as T[];
            Items = new T[Count + 2];
            tempArray.CopyTo(Items, 1);
            Items[0] = element;
            Count += 1;
        }

        public void Pop()
        {
            if (Count > 0)
            {
                T[] tempArray = Items.Clone() as T[];
                Items = new T[Count - 1];
                Array.Copy(tempArray, 0, Items, 0, Count - 1);
                Count -= 1;
            }
        }

        public override string ToString()
        {
            string stringPrint = "[";
            for (int i = 0; i < Count - 1; i++)
            {
                stringPrint += $"{Items[i]}, ";
            }
            stringPrint += $"{Items[Count - 1]}]";

            return stringPrint;
        }

    }
}
