using System.Collections.Generic;

namespace CSharpSort
{
    public class MergeSort
    {
        private (List<int>, List<int>) _split(List<int> data)
        {
            int middle = data.Count / 2;
            List<int> left = data.GetRange(0, middle);
            List<int> right = data.GetRange(middle, (data.Count-middle));
            return (left,right);
        }

        private List<int> _merge(List<int> data, List<int> tempList,int tempIndex,int resultIndex)
        {
            while (tempIndex < tempList.Count)
            {
                data[resultIndex] = tempList[tempIndex];
                resultIndex++;
                tempIndex++;
            }
            return data;
        }
        public List<int> Sort(List<int> data)
        {   
            // return the data when the data list is to small to split to stop a stack overflow 
            if (data.Count <= 1) return data;
            // split the data in 2 halfs 
            var (left,right) = _split(data);
            // sort the halves again 
            Sort(left);
            Sort(right);

            int leftIndex, rightIndex, resultIndex;
            leftIndex = rightIndex = resultIndex = 0;
            
            // sort the 2 list with each other 
            while(leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    data[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    data[resultIndex] = right[rightIndex];
                    rightIndex++;
                }

                resultIndex++;
            }
            // merge the 2 lists to one list 
            data = _merge(data, left, leftIndex, resultIndex);
            data = _merge(data, right, rightIndex, resultIndex);
            return data;
        }
    }
}