using System;
using System.Collections.Generic;

namespace CSharpSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int> {3, 5, 2, 1, 303, 4, 2, 12, 4, 5, 3, 121};
            MergeSort mergeSort = new MergeSort();
            BubbleSort bubbleSort = new BubbleSort();
            SelectionSort selectionSort = new SelectionSort();

            
            Console.WriteLine("mergesort " + String.Join(", ",  mergeSort.Sort(new List<int>(data))));
            Console.WriteLine("selection " + String.Join(", ",  selectionSort.Sort(new List<int>(data))));
            Console.WriteLine("bubble " + String.Join(", ",  bubbleSort.Sort(new List<int>(data))));
        }
    }
}