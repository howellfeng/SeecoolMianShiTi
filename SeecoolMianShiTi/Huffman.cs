using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    public class Huffman
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Weights { get; set; }
            public string Data { get; set; }
        }
        public static Node CreateHuffmanTree(List<Node> nodes)
        {
            if (nodes.Count == 0)
                return null;
            else if (nodes.Count == 1)
                return nodes[0];
            else
            {
                Tuple<Node, Node> min = getMin2Node(nodes);
                Node min1 = min.Item1, min2 = min.Item2;
                nodes.Remove(min1);
                nodes.Remove(min2);
                Node newNode = new Node() { Left = min1, Right = min2, Weights = min1.Weights + min2.Weights };
                nodes.Add(newNode);
                return CreateHuffmanTree(nodes);
            }
        }
        private static Tuple<Node, Node> getMin2Node(List<Node> nodes)
        {
            Node min1 = nodes[0];
            Node min2 = nodes[1];
            if (nodes[0].Weights > nodes[1].Weights)
            {
                min1 = nodes[1];
                min2 = nodes[0];
            }
            for (int i = 2; i < nodes.Count; i++)
            {
                if (nodes[i].Weights < min1.Weights)
                {
                    Node temp = min1;
                    min1 = nodes[i];
                    min2 = temp;
                }
                else if (nodes[i].Weights < min2.Weights)
                    min2 = nodes[i];
            }
            return new Tuple<Node, Node>(min1, min2);
        }
    }
}
