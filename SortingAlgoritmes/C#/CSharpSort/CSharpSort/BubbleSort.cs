using System;
using System.Collections.Generic;

namespace CSharpSort
{
    public class BubbleSort
    {
        private List<int> _swap(List<int> data, int index)
        {
            int temp = data[index];
            data[index] = data[index + 1];
            data[index + 1] = temp;
            return data;
        }
        public List<int> Sort(List<int> data)
        {
            for (int i = 0; i < data.Count -1; i++)
                for (int j = 0; j < data.Count - i - 1; j++)
                        if (data[j] > data[j + 1])
                            // swaps the 2 numbers 
                            data = _swap(data, j);
            return data;
        }
    }
}