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
                1, 2, 3
            };

            list[3] = 4;
            list[4] = 5;

            foreach (int l in list)
                Console.WriteLine(l);
        }
    }
}
