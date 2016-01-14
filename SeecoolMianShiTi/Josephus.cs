using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    /// <summary>
    /// 约瑟夫环
    /// </summary>
    public class Josephus
    {
        private int _n = 0;//共n个人
        private int _k = 0;//从第k个人开始
        private int _m = 0;//每到m就出列
        public Josephus(int n, int k, int m)
        {
            _n = n;
            _k = k;
            _m = m;
        }

        public void Start()
        {
            if (_n == 0 || _k == 0 || _m == 0 || _k > _n)
                return;
            Node[] nodes = new Node[_n];
            for (int i = 1; i <= _n; i++)
                nodes[i - 1] = new Node() { Id = i };

            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].Next = nodes[i + 1];
            nodes[nodes.Length - 1].Next = nodes[0];

            Node node = nodes[_k - 1];
            while (node.Next != node)
            {
                for (int i = 1; i < _m - 1; i++)
                    node = node.Next;
                Console.WriteLine(node.Next.Id);
                node.Next = node.Next.Next;
                node = node.Next;
            }
            Console.WriteLine(node.Id);
        }

        private class Node
        {
            public int Id = -1;
            public Node Next = null;
        }
    }

    public class Josephus2
    {
        private int _n = 0;//共n个
        private int _k = 0;//从第k个开始
        private int _m = 0;//每到第m出列
        public Josephus2(int n, int k, int m)
        {
            _n = n;
            _k = k;
            _m = m;
        }
        public void Calc()
        {
            if (_n == 0 || _k == 0 || _m == 0)
                return;
            Node[] nodes = new Node[_n];
            for (int i = 1; i <= _n; i++)
                nodes[i - 1] = new Node() { Id = i };
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].Next = nodes[i + 1];
            nodes[nodes.Length - 1].Next = nodes[0];
            Node node = nodes[_k - 1];
            while (node.Next != node)
            {
                for (int i = 1; i < _m - 1; i++)
                    node = node.Next;
                Console.WriteLine(node.Next.Id);
                node.Next = node.Next.Next;
                node = node.Next;                
            }
            Console.WriteLine(node.Id);
        }
        private class Node
        {
            public int Id { get; set; } = -1;
            public Node Next { get; set; }
        }
    }
}
