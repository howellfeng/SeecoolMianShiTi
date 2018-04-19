using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeecoolMianShiTi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Josephus j = new Josephus(9, 1, 5);
            j.Start();
            Console.WriteLine("***");
            Josephus2 j2 = new Josephus2(9, 1, 5);
            j2.Calc();
            Console.WriteLine("***");
            Josephus3.Calc(9, 1, 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reverse r = new Reverse(5);
            r.Calc();

            Josephus3.Reverse(5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BTree t = new BTree();
            t.CalcNLR(t.Root);
            t.CalcNLR2(t.Root);
            t.LevelTraverse(t.Root);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BubbleSort b = new BubbleSort();
            b.Sort(4, 1, 2, 4, 3);
            b.Sort(4.1, 1.1, 2, 4, 3);
            b.Sort2(4, 1, 2, 4, 3);
            b.Sort2(4.1, 1.1, 2, 4, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FindMaxK find = new FindMaxK();
            Console.WriteLine(find.Find(2, 1, 2, 4, 3));
            Console.WriteLine(find.Find(2, 4.1, 1.1, 2, 4, 3));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RectangleIntersect ri = new RectangleIntersect();
            RectangleF rect = RectangleF.FromLTRB(120, 30, 121, 31);
            RectangleF rect2 = RectangleF.FromLTRB(122, 32, 123, 33);
            Console.WriteLine(ri.IsIntersect(rect, rect2));
            RectangleF rect3 = RectangleF.FromLTRB(120.5f, 30.5f, 121.5f, 31.5f);
            Console.WriteLine(ri.IsIntersect(rect, rect3));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Find256 find = new Find256();
            find.Calc();
        }

        private void buttonBTreeInsert_Click(object sender, EventArgs e)
        {
            BTree tree = new BTree();
            BTree.Node root = null;
            root = tree.InsertNode(root, "E");
            root = tree.InsertNode(root, "A");
            root = tree.InsertNode(root, "B");
            root = tree.InsertNode(root, "C");
            root = tree.InsertNode(root, "E");
            root = tree.InsertNode(root, "F");
            root = tree.InsertNode(root, "A");
            tree.CalcLNR(root);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[] array = new int[] { 6, 1, 9, 2, 0, 5, 7, 1 };
            Sort.BubbleSort(array);
            array.ForEach(Console.WriteLine);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int[] datas = new int[501];
            for (int i = 0; i < 250; i++)
            {
                datas[i] = i + 1;
            }
            for (int i = 0; i < 250; i++)
            {
                datas[i + 250] = i + 1;
            }
            datas[500] = 500;
            Josephus3.Calculate(datas);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[,] m1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Josephus3.PrintMatrix(m1, 2, 3);
            int[,] m2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Josephus3.PrintMatrix(m2, 3, 3);
            Josephus3.Matrix(m1, 2, 3, m2, 3, 3);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Huffman.Node> list = new List<Huffman.Node>();
            list.Add(new Huffman.Node() { Data = "a", Weights = 7 });
            list.Add(new Huffman.Node() { Data = "b", Weights = 5 });
            list.Add(new Huffman.Node() { Data = "c", Weights = 2 });
            list.Add(new Huffman.Node() { Data = "d", Weights = 4 });
            Huffman.Node root = Huffman.CreateHuffmanTree(list);
            Console.WriteLine("1");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string pattern = "ca*b?a";
            string[] strs = new string[] { "defabc", "acb", "012aaaabbb", "ccca","c","" };
            string[] result = RegexCopy.MatchRegex(strs, pattern);
            string[] result2 = RegexCopy.Match(strs, pattern);
            Console.WriteLine("1");
        }
    }
    static class Josephus3
    {
        class Node
        {
            public Node Next { get; set; }
            public int Data { get; set; }
        }
        public static void Calc(int n, int k, int m)
        {
            Node[] nodes = buildList(n);
            nodes[nodes.Length - 1].Next = nodes[0];
            Node current = nodes[k - 1];
            int index = 1;
            while (current.Next != null && current.Next != current)
            {
                if (index == m - 1)
                {
                    Node temp = current.Next;
                    Console.WriteLine(temp.Data);
                    current.Next = temp.Next;
                    index = 0;
                }
                current = current.Next;
                index++;
            }
            Console.WriteLine(current.Data);
        }
        private static Node[] buildList(int n)
        {
            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node() { Data = i + 1 };
            }
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                nodes[i].Next = nodes[i + 1];
            }
            return nodes;
        }

        public static void Reverse(int n)
        {
            Node[] nodes = buildList(n);
            Node current = nodes[0];
            Node next = current.Next;
            consoleNode(current);
            current.Next = null;
            while (next.Next != null)
            {
                Node temp = next.Next;
                next.Next = current;
                current = next;
                next = temp;
            }
            next.Next = current;
            consoleNode(next);
        }
        static void consoleNode(Node root)
        {
            Console.WriteLine();
            while (root.Next != null)
            {
                Console.Write(root.Data);
                root = root.Next;
            }
            Console.WriteLine(root.Data);
        }

        class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Data { get; set; }
        }
        static void DLR(TreeNode root)
        {
            Console.WriteLine(root.Data);
            if (root.Left != null)
                DLR(root.Left);
            if (root.Right != null)
                DLR(root.Right);
        }
        static void LDR(TreeNode root)
        {
            if (root.Left != null)
                LDR(root.Left);
            Console.WriteLine(root.Data);
            if (root.Right != null)
                LDR(root.Right);
        }
        static void LRD(TreeNode root)
        {
            if (root.Left != null)
                LRD(root.Left);
            if (root.Right != null)
                LRD(root.Right);
            Console.WriteLine(root.Data);
        }

        /// <summary>
        /// 501个数据，有250对一样的，一个不重复，找到找那一个
        /// </summary>
        /// <param name="datas"></param>
        public static void Calculate(int[] datas)
        {
            int[] temp = new int[501];
            datas.ForEach(p =>
            {
                temp[p - 1]++;
            });
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
        public static int Fibonacci(int index)
        {
            if (index < 3)
                return 1;
            else
                return Fibonacci(index - 1) + Fibonacci(index - 2);
        }
        public static void Matrix(int[,] matrix1, int r1, int c1, int[,] matrix2, int r2, int c2)
        {
            //m1的列要等于m2的行
            if (c1 != r2)
                return;
            int[,] result = new int[r1, c2];
            for (int i = 0; i < r1; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    result[i, j] = calcCell(matrix1, i, c1, matrix2, r2, j);
                }
            }
            PrintMatrix(result, r1, c2);
        }

        private static int calcCell(int[,] matrix1, int r1, int c1, int[,] matrix2, int r2, int c2)
        {
            int result = 0;
            for (int i = 0; i < c1;)
            {
                for (int j = 0; j < r2;)
                {
                    result += matrix1[r1, i] * matrix2[j, c2];
                    i++;
                    j++;
                }
            }
            return result;
        }
        public static void PrintMatrix(int[,] matrix, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    
}
