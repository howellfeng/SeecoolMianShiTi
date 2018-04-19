using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    static class Sort
    {
        public static void BubbleSort<T>(T[] datas)
            where T : IComparable
        {
            for (int i = 0; i < datas.Length - 1; i++)
            {
                for (int j = 0; j < datas.Length - 1 - i; j++)
                {
                    if (datas[j].CompareTo(datas[j + 1]) == 1)
                    {
                        T temp = datas[j + 1];
                        datas[j + 1] = datas[j];
                        datas[j] = temp;
                    }
                }
            }
        }
    }
}
