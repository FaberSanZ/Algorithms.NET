using Algorithms.DataStructures;
using Algorithms.Sorting;
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
                var r = i + 1;
                Console.WriteLine(r);
                list.Add(r);
            }


            list.DeleteElement(5);

           list.ToList().SortExt<int>();
            Console.WriteLine(list.IsEmpty);
            Console.WriteLine(list[1]);
            Console.WriteLine("-----------------");
            Console.WriteLine(list.Count);
            //Console.WriteLine(count);
        }
    }
}
