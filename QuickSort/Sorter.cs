using System;

// ReSharper disable InconsistentNaming
namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[]? array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 1)
            {
                return;
            }

            int[] stack = new int[array.Length];

            int top = -1;
            stack[++top] = 0;
            stack[++top] = array.Length - 1;

            while (top >= 0)
            {
                int high = stack[top--];
                int low = stack[top--];

                int pivotIndex = Partition(array, low, high);

                if (pivotIndex - 1 > low)
                {
                    stack[++top] = low;
                    stack[++top] = pivotIndex - 1;
                }

                if (pivotIndex + 1 < high)
                {
                    stack[++top] = pivotIndex + 1;
                    stack[++top] = high;
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[]? array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            RecursiveQuickSort(array, 0, array.Length - 1);
        }

        private static void RecursiveQuickSort(this int[]? array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                RecursiveQuickSort(array, low, pivotIndex - 1);
                RecursiveQuickSort(array, pivotIndex + 1, high);
            }
        }

        private static int Partition(this int[]? array, int low, int high)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private static void Swap(this int[]? array, int index1, int index2)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
