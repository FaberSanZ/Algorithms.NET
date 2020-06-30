using System;
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

        public LinkedList(IEnumerable<T> data)
        {
            foreach (T d in data)
            {
                Add(d);
            }
        }


        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0 || Head is null;

        public T this[int i] => ToArray()[i];


        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);

            if (Head is null)
            {
                Head = new LinkedListNode<T>(data);

                Count += 1;
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

        public LinkedListNode<T> AddFirst(T data)
        {
            LinkedListNode<T> newListElement = new LinkedListNode<T>(data)
            {
                Next = Head,
            };

            Head = newListElement;

            return newListElement;
        }


        public LinkedListNode<T> AddLast(T data)
        {
            LinkedListNode<T> newElement = new LinkedListNode<T>(data);

            if (Head is null)
            {
                Head = newElement;
                return newElement;
            }

            LinkedListNode<T> tempElement = Head;

            while (tempElement.Next != null)
            {
                tempElement = tempElement.Next;
            }

            tempElement.Next = newElement;
            return newElement;
        }



        public T GetElementByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            LinkedListNode<T> tempElement = Head;

            for (int i = 0; tempElement != null && i < index; i++)
            {
                tempElement = tempElement.Next;
            }

            if (tempElement is null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return tempElement.Data;
        }

        public bool DeleteElement(T element)
        {
            LinkedListNode<T> current = Head;

            LinkedListNode<T>? previous = null;


            while (current != null)
            {
                if ((current.Data is null && element is null) || (current.Data != null && current.Data.Equals(element)))
                {
                    // if element is head just take the next one as head
                    if (current.Equals(Head))
                    {
                        Head = Head.Next;
                        Count--;
                        return true;
                    }

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        Count--;
                        return true;
                    }
                }

                // iterating
                previous = current;

                current = current.Next;
            }


            return false;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
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

            T[] array = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
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
            if (Head is null)
            {
                return string.Format($"Elements length is: {Count}");
            }
            else
            {
                return string.Join(", ", ToArray());
            }
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
