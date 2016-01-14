using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    /// <summary>
    /// 单向链表反转
    /// </summary>
    public class Reverse
    {
        private int _n = 0;
        public Reverse(int n)
        {
            _n = n;
        }
        public void Calc()
        {
            if (_n <= 0)
                return;

            //生成单向链表
            Node[] nodes = new Node[_n];
            for (int i = 1; i <= _n; i++)
                nodes[i - 1] = new Node() { Id = i };
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].Next = nodes[i + 1];

            //反转
            Node current = nodes[0];
            Node last = null;
            while (current.Next != null)
            {
                Node temp = current.Next;
                current.Next = last;
                last = current;
                current = temp;
            }
            current.Next = last;

            //输出
            while (current.Next != null)
            {
                Console.WriteLine(current.Id);
                current = current.Next;
            }
            Console.WriteLine(current.Id);
        }

        private class Node
        {
            public int Id { get; set; }
            public Node Next { get; set; }
        }
    }
}
