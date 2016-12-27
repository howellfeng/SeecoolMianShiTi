using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    /// <summary>
    /// 1-256共256个不重复的自然数，从中随机选择255个放入数组arr[255]，请编写一个算法，找出没有被放入数组的数字
    /// </summary>
    public class Find256
    {
        public void Calc()
        {
            int[] arr = prepareArr();
            int[] arr2 = new int[256];
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[arr[i] - 1] = arr[i];//将arr中每个元素，用元素值做索引放到新数组中，如1放到index=0
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] == 0)
                    Console.WriteLine(i + 1);
            }
        }

        private int[] prepareArr()
        {
            HashSet<int> result = new HashSet<int>();
            Random random = new Random(Environment.TickCount);
            int temp = 0;
            while (result.Count < 255)
            {
                temp = random.Next(1, 256);
                if (!result.Contains(temp))
                    result.Add(temp);
            }
            return result.ToArray();
        }
    }
}
