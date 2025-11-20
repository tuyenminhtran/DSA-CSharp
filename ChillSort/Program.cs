using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChillSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        
        public static void Sort(int[] arr)
        {
            for ( int i = 0; i < arr.Length - 1; i++)
                for ( int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        Thread.Sleep(100);
                    }
        }
    }
}
