using Algorithms.DataStructures;
using System;
using System.Linq;

namespace Algorithms.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>()
            {
                2, 4, 8
            };

            // Indexers 
            list[3] = 16;
            list[4] = 32;

            foreach (int l in list) // IEnumerable<T>
                Console.WriteLine(l);
        }
    }
}
