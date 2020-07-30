using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T>, IDisposable
    {

        // Internal node class to represent data
        internal class Node<T>
        {
            public Node(T data, Node<T> prev, Node<T> next)
            {
                Data = data;
                Prev = prev;
                Next = next;
            }

            public Node<T>? Prev { get; set; }
            public Node<T>? Next { get; set; }
            public T Data { get; set; }

            public override string ToString()
            {
                return string.Format($"{Data}");
            }
        }


        internal Node<T>? Head;
        internal Node<T>? Tail;


        public DoublyLinkedList()
        {
            Head = Tail = null;

            Size = 0;
        }

        public DoublyLinkedList(IEnumerable<T> data)
        {
            foreach (T d in data)
            {
                Add(d);
            }
        }


        public int Size { get; private set; }

        public bool IsEmpty => Size == 0 /*|| Head is null || Tail is null*/;


        public T this[int i] => ToArray()[i];




        /// <summary>
        /// Empty this linked list, O(n)
        /// </summary>
        public void Clear()
        {
            Node<T> trav = Head;
            while (trav != null)
            {
                Node<T> next = trav.Next;
                trav.Prev = trav.Next = null;
                trav.Data = default; // null?
                trav = next;
            }
            Head = Tail = trav = null;
            Size = 0;
        }

        /// <summary>
        /// Add an element to the tail of the linked list, O(1)
        /// </summary>
        // <param name="elem"></param>
        public void Add(T elem)
        {
            AddLast(elem);
        }


        /// <summary>
        /// Add a node to the tail of the linked list, O(1)
        /// </summary>
        // <param name="elem"></param>
        public void AddLast(T elem)
        {
            if (IsEmpty)
            {
                Head = Tail = new Node<T>(elem, null, null);
            }
            else
            {
                Tail.Next = new Node<T>(elem, Tail, null);
                Tail = Tail.Next;
            }
            Size++;
        }


        // Add an element to the beginning of this linked list, O(1)
        public void AddFirst(T elem)
        {
            if (IsEmpty)
            {
                Head = Tail = new Node<T>(elem, null, null);
            }
            else
            {
                Head.Prev = new Node<T>(elem, null, Head);
                Head = Head.Prev;
            }
            Size++;
        }


        // Add an element at a specified index
        public void AddAt(int index, T data)
        {
            if (index < 0)
            {
                throw new Exception("Illegal Index");
            }
            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == Size)
            {
                AddLast(data);
                return;
            }

            Node<T> temp = Head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            Node<T> newNode = new Node<T>(data, temp, temp.Next);
            temp.Next.Prev = newNode;
            temp.Next = newNode;

            Size++;
        }

        // Check the value of the first node if it exists, O(1)
        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty list");
            }

            return Head.Data;
        }



        // Check the value of the last node if it exists, O(1)
        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty list");
            }

            return Tail.Data;
        }

        // Remove the first value at the head of the linked list, O(1)
        public T RemoveFirst()
        {
            // Can't remove data from an empty list
            if (IsEmpty)
            {
                throw new Exception("Empty list");
            }

            // Extract the data at the head and move
            // the head pointer forwards one node
            T data = Head.Data;
            Head = Head.Next;
            --Size;

            // If the list is empty set the tail to null
            if (IsEmpty)
            {
                Tail = null;
            }
            // Do a memory cleanup of the previous node
            else
            {
                Head.Prev = null;
            }

            // Return the data that was at the first node we just removed
            return data;
        }

        // Remove the last value at the tail of the linked list, O(1)
        public T RemoveLast()
        {
            // Can't remove data from an empty list
            if (IsEmpty)
            {
                throw new Exception("Empty list");
            }

            // Extract the data at the tail and move
            // the tail pointer backwards one node
            T data = Tail.Data;
            Tail = Tail.Prev;
            --Size;

            // If the list is now empty set the head to null
            if (IsEmpty)
            {
                Head = null;
            }
            // Do a memory clean of the node that was just removed
            else
            {
                Tail.Next = null;
            }

            // Return the data that was in the last node we just removed
            return data;
        }


        // Remove an arbitrary node from the linked list, O(1)
        internal T Remove(Node<T> node)
        {
            // If the node to remove is somewhere either at the
            // head or the tail handle those independently
            if (node.Prev == null)
            {
                return RemoveFirst();
            }

            if (node.Next == null)
            {
                return RemoveLast();
            }

            // Make the pointers of adjacent nodes skip over 'node'
            node.Next.Prev = node.Prev;
            node.Prev.Next = node.Next;

            // Temporarily store the data we want to return
            T data = node.Data;

            // Memory cleanup
            node.Data = default; // null?
            node = node.Prev = node.Next = null;

            --Size;

            // Return the data in the node we just removed
            return data;
        }


        // Remove a node at a particular index, O(n)
        public T RemoveAt(int index)
        {
            // Make sure the index provided is valid
            if (index < 0 || index >= Size)
            {
                throw new Exception(); // TODO:
            }

            int i;
            Node<T> trav;

            // Search from the front of the list
            if (index < Size / 2)
            {
                for (i = 0, trav = Head; i != index; i++)
                {
                    trav = trav.Next;
                }
                // Search from the back of the list
            }
            else
            {
                for (i = Size - 1, trav = Tail; i != index; i--)
                {
                    trav = trav.Prev;
                }
            }

            return Remove(trav);
        }


        // Remove a particular value in the linked list, O(n)
        public bool Remove(T obj)
        {
            Node<T> trav = Head;

            // Support searching for null
            if (obj is null)
            {
                for (trav = Head; trav != null; trav = trav.Next)
                {
                    if (trav.Data is null)
                    {
                        Remove(trav);
                        return true;
                    }
                }
                // Search for non null object
            }
            else
            {
                for (trav = Head; trav != null; trav = trav.Next)
                {
                    if (obj.Equals(trav.Data))
                    {
                        Remove(trav);
                        return true;
                    }
                }
            }
            return false;
        }


        // Find the index of a particular value in the linked list, O(n)
        public int IndexOf(T obj)
        {
            int index = 0;
            Node<T> trav = Head;

            // Support searching for null
            if (obj is null)
            {
                for (; trav != null; trav = trav.Next, index++)
                {
                    if (trav.Data is null)
                    {
                        return index;
                    }
                }
                // Search for non null object
            }
            else
            {
                for (; trav != null; trav = trav.Next, index++)
                {
                    if (obj.Equals(trav.Data))
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        // Check is a value is contained within the linked list
        public bool Contains(T obj)
        {
            return IndexOf(obj) != -1;
        }




        public List<T> ToList()
        {
            List<T> arr = new List<T>();
            Node<T> current = Head;
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
            Node<T> current = Head;
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

            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            Node<T> trav = Head;
            while (trav != null)
            {
                sb.Append(trav.Data);
                if (trav.Next != null)
                {
                    sb.Append(", ");
                }
                trav = trav.Next;
            }
            sb.Append(" ]");

            return sb.ToString();
        }

        public void Dispose()
        {
            Clear();
            //GC.SuppressFinalize(this);
        }
    }

}
