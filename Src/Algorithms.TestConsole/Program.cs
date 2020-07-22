using Algorithms.DataStructures;
using System;

namespace Algorithms.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < 12; i++)
            {
                int r = i * new Random().Next(8, 16);
                list.Add(r);
            }


            Console.WriteLine(list);
            //foreach (int l in list)
            //{
            //    Console.WriteLine(l);
            //}


            list.RemoveAt(5);


            // Console.WriteLine(list.IsEmpty);
            // Console.WriteLine(list[1]); // TODO:
            // Console.WriteLine("-----------------");

        }
    }
}
