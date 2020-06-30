using Algorithms.DataStructures;
using System;

namespace Algorithms.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 12; i++)
            {
                var r = i * new Random(1).Next(100);
                Console.WriteLine(r);
                list.Add(r);
            }

            Console.WriteLine(list);
            Console.WriteLine("-----------------");
            Console.WriteLine(list.Count);
            //Console.WriteLine(count);
        }
    }
}
