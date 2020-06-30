using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }




        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);

            if (Head is null)
            {
                Head = new LinkedListNode<T>(data);
                if (Count is 0)
                {
                    Count += 1;
                }
                else
                {
                    Count = 0;
                }
            }
            else
            {
                LinkedListNode<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                Count++;
            }
        }


        public List<T> ToList()
        {
            List<T> arr = new List<T>();
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                arr.Add(current.Data);
                current = current.Next;
            }

            return arr;
        }


        public T[] ToArray()
        {
            List<T> list = ToList();

            T[] array = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = list[i];
            }

            return array /*list.ToArray();*/;
        }


        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public override string ToString()
        {
            return string.Join(", ", ToArray());
        }



    }

    public class LinkedListNode<T>
    {
        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;

        }

        public LinkedListNode<T>? Next { get; set; }
        public T Data { get; }
    }

}
