using System.Collections.Generic;

namespace CSharpSort
{
    public class SelectionSort
    {
        private List<int> _swap(List<int> data, int minIndex,int index)
        {
            int temp = data[minIndex];
            data[minIndex] = data[index];
            data[index] = temp;
            return data;
        }
        public List<int> Sort(List<int> data)
        {
            // move the boundry of the array per looop 
            for (int i = 0; i < data.Count - 1; i++)
            {
                int minIndex = i;
                for(int j = i + 1;  j < data.Count; j++)
                    // find minimum element in the unsorted array 
                    if (data[j] < data[minIndex])
                        minIndex = j;
                // swap the new minimum value with the last minium value 
                data = _swap(data, minIndex, i);
            }

            return data;
        }
    }
}