using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    public class BubbleSort
    {
        public void Sort<T>(params T[] arr)
            where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) == 1)//j>j+1
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }

        public void Sort2<T>(params T[] arr)
            where T : IComparable
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) == 1)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            foreach (T t in arr)
                Console.WriteLine(t);
        }
    }
}
