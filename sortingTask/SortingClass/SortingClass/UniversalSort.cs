using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingClass
{
    public delegate int ParametersComparer(object o1, object o2);  //delegate for methods:
                                                                   //CompareDouble, CompareInt, CompareString

    static class UniversalSort
    {
        public static void Sort<T>(T[] inputArray, string parameterForSorting,
                                    int startingIndex, int lastIndex,
                                    bool inDescendingOrder)
        {
            if (inputArray == null || inputArray.Length < 1)
                return;

            System.Reflection.PropertyInfo propertyToCheck = inputArray[0].GetType().GetProperty(parameterForSorting);
            //QuickSort<T>(inputArray, startingIndex, lastIndex, propertyToCheck, inDescendingOrder);
            HeapSort<T>(inputArray, startingIndex, lastIndex, propertyToCheck, inDescendingOrder);
        }


        //Heap sort methods

        public static void HeapSort<T>(T[] data, int low, int high, System.Reflection.PropertyInfo propertyToCheck, bool inDescendingOrder)
        {
            int dataLength = data.Length;

            for (int i = (data.Length) / 2; i > 0; i--)
            {
                int modifiedPosition = BuildHeap<T>(data, i, dataLength, propertyToCheck, inDescendingOrder);
                while (modifiedPosition >= 0)
                    modifiedPosition = BuildHeap<T>(data, modifiedPosition + 1, dataLength, propertyToCheck, inDescendingOrder);
            }

            for (int i = data.Length; i > 1; i--)
            {
                T temp = data[dataLength - 1];
                data[dataLength - 1] = data[0];
                data[0] = temp;

                int modifiedPosition = BuildHeap<T>(data, 1, --dataLength, propertyToCheck, inDescendingOrder);
                while (modifiedPosition >= 0)
                    modifiedPosition = BuildHeap<T>(data, modifiedPosition + 1, dataLength, propertyToCheck, inDescendingOrder);
            }
        }

        private static int BuildHeap<T>(T[] data, int fatherNumber, int bound, System.Reflection.PropertyInfo propertyToCheck, bool inDescendingOrder)
        {
            int fatherIndex = fatherNumber - 1;
            int leftSonIndex = (fatherNumber * 2 - 1 < data.Length && fatherNumber * 2 - 1 < bound) ? fatherNumber * 2 - 1 : -1;
            int rightSonIndex = (fatherNumber * 2 < data.Length && fatherNumber * 2 < bound) ? fatherNumber * 2 : -1;

            ParametersComparer comparer = null;

            if (propertyToCheck.GetValue(data[0]) is double)
                comparer = CompareDouble;
            else if (propertyToCheck.GetValue(data[0]) is int)
                comparer = CompareInt;
            else
                comparer = CompareString;


            if (inDescendingOrder)
            {
                if ((leftSonIndex < 0 && rightSonIndex < 0) ||
                    (rightSonIndex < 0 && comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[leftSonIndex])) <= 0) ||
                    (comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[leftSonIndex])) <= 0 &&
                    comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[rightSonIndex])) <= 0))
                    return -1;
                else if ((rightSonIndex < 0 && comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) <= 0) ||
                    (comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) <= 0 &&
                    comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[rightSonIndex])) <= 0))
                {
                    T temp = data[fatherIndex];
                    data[fatherIndex] = data[leftSonIndex];
                    data[leftSonIndex] = temp;
                    return leftSonIndex;
                }
                else if (comparer(propertyToCheck.GetValue(data[rightSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) <= 0 &&
                    comparer(propertyToCheck.GetValue(data[rightSonIndex]), propertyToCheck.GetValue(data[leftSonIndex])) <= 0)
                {
                    T temp = data[fatherIndex];
                    data[fatherIndex] = data[rightSonIndex];
                    data[rightSonIndex] = temp;
                    return rightSonIndex;
                }
            }
            else 
            {
                if ((leftSonIndex < 0 && rightSonIndex < 0) ||
                    (rightSonIndex < 0 && comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[leftSonIndex])) >= 0) ||
                    (comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[leftSonIndex])) >= 0 &&
                    comparer(propertyToCheck.GetValue(data[fatherIndex]), propertyToCheck.GetValue(data[rightSonIndex])) >= 0)) 
                    return -1;
                else if ((rightSonIndex < 0 && comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) >= 0) ||
                    (comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) >= 0 &&
                    comparer(propertyToCheck.GetValue(data[leftSonIndex]), propertyToCheck.GetValue(data[rightSonIndex])) >= 0))
                {
                    T temp = data[fatherIndex];
                    data[fatherIndex] = data[leftSonIndex];
                    data[leftSonIndex] = temp;
                    return leftSonIndex;
                }
                else if (comparer(propertyToCheck.GetValue(data[rightSonIndex]), propertyToCheck.GetValue(data[fatherIndex])) >= 0 &&
                    comparer(propertyToCheck.GetValue(data[rightSonIndex]), propertyToCheck.GetValue(data[leftSonIndex])) >= 0)
                {
                    T temp = data[fatherIndex];
                    data[fatherIndex] = data[rightSonIndex];
                    data[rightSonIndex] = temp;
                    return rightSonIndex;
                }
            }

            return -1;
        }

        // --------------

        //Quick sort methods

        public static void QuickSort<T>(T[] inputArray, int low, int high,
                                        System.Reflection.PropertyInfo propertyToCheck,
                                        bool inDescendingOrder)
        {
            if (low < high)
            {
                int p = Partition(inputArray, low, high, propertyToCheck, inDescendingOrder);

                QuickSort<T>(inputArray, low, p - 1, propertyToCheck, inDescendingOrder);
                QuickSort<T>(inputArray, p + 1, high, propertyToCheck, inDescendingOrder);
            }
        }

        static int Partition<T>(T[] data, int low, int high, System.Reflection.PropertyInfo propertyToCheck, bool inDescendingOrder)
        {
            T pivot = data[low];
            int i = (high + 1);
            ParametersComparer comparer = null;

            if (propertyToCheck.GetValue(pivot) is double)
                comparer = CompareDouble;
            else if (propertyToCheck.GetValue(pivot) is int)
                comparer = CompareInt;
            else
                comparer = CompareString;


            for (int j = high; j >= low + 1; j--)
            {
                if (comparer(propertyToCheck.GetValue(data[j]), propertyToCheck.GetValue(pivot)) * ((inDescendingOrder) ? -1 : 1) > 0) 
                {
                    i--;
                    Swap(data, i, j);
                }
            }

            Swap(data, i - 1, low);
            return (i - 1);
        }

        private static void Swap<T>(T[] data, int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        // -----------


        private static int CompareDouble(object o1, object o2)
        {
            return ((Double)o1).CompareTo(o2);
        }
        private static int CompareInt(object o1, object o2)
        {
            return ((int)o1).CompareTo(o2);
        }
        private static int CompareString(object o1, object o2)
        {
            return ((string)o1).CompareTo(o2);
        }
    }
}
