using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public static class BubbleSorter
    {
        public static void SortExt<T>(this IList<T> array)
        {
            if (typeof(T) == typeof(string))
            {
                bool swap;
                string temp; //change this too
                for (int index = 0; index < (array.Count - 1); index++)
                {
                    if (string.Compare(array[index] as string, array[index + 1] as string) < 0) //if first number is greater then second then swap
                    {
                        //swap

                        temp = array[index] as string;
                        array[index] = array[index + 1];
                        //array[index + 1] = temp;
                        swap = true;
                    }
                }
            }
            if (typeof(int) == typeof(T))
            {
                Console.WriteLine("int");
            }
            


        } 

    }
}
