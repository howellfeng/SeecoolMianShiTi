using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public class BTree
    {
        public Node Root { get; set; }
        public BTree()
        {
            Root = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");
            Node nodeE = new Node("E");
            Node nodeF = new Node("F");
            Node NodeG = new Node("G");
            Root.Left = nodeB;
            Root.Right = nodeD;
            nodeB.Left = nodeC;
            nodeD.Left = nodeE;
            nodeD.Right = nodeF;
            nodeE.Right = NodeG;
        }
        public void CalcNLR(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Data);
                CalcNLR(node.Left);
                CalcNLR(node.Right);
            }
        }
        /// <summary>
        /// 非递归
        /// </summary>
        /// <param name="node"></param>
        public void CalcNLR2(Node node)
        {
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    Console.WriteLine(node.Data);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    node = node.Right;
                }
            }
        }
        public void CalcLNR(Node node)
        {
            if (node != null)
            {
                CalcLNR(node.Left);
                Console.WriteLine(node.Data);
                CalcLNR(node.Right);
            }
        }
        public void CalcLRN(Node node)
        {
            if (node != null)
            {
                CalcLRN(node.Left);
                CalcLRN(node.Right);
                Console.WriteLine(node.Data);
            }
        }
        public class Node
        {
            public string Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(string data)
            {
                Data = data;
            }
        }
        /// <summary>
        /// 二叉树插入
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node InsertNode(Node root, string key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            if (isSmall(key, root.Data))
                root.Left = InsertNode(root.Left, key);
            else
                root.Right = InsertNode(root.Right, key);
            return root;
        }

        private bool isSmall(string a, string b)
        {
            return string.Compare(a, b) < 0;
        }
    }
}
