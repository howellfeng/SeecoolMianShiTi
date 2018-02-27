using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeecoolMianShiTi
{
    class QuadTree
    {
        public class Node
        {
            /// <summary>
            /// 深度
            /// </summary>
            public int Depth { get; set; }
            /// <summary>
            /// 是否叶子节点
            /// </summary>
            public bool IsLeaf { get; set; } = true;
            /// <summary>
            /// 区域范围
            /// </summary>
            public Rect Region { get; set; }

            //对该节点进行田字分裂
            /// <summary>
            /// 左上
            /// </summary>
            public Node LeftTop { get; set; }
            /// <summary>
            /// 左下
            /// </summary>
            public Node LeftBottom { get; set; }
            /// <summary>
            /// 右上
            /// </summary>
            public Node RightTop { get; set; }
            /// <summary>
            /// 右下
            /// </summary>
            public Node RightBottom { get; set; }

            /// <summary>
            /// 元素集合
            /// </summary>
            public List<Point> Elements { get; set; } = new List<Point>();
        }
        public void SplitNode(Node root)
        {
            double centerX = (root.Region.Left + root.Region.Right) / 2;
            double centerY = (root.Region.Top + root.Region.Bottom) / 2;
            //分裂
            root.IsLeaf = false;
            root.LeftTop = createNode(root, root.Region.Left, root.Region.Top, centerX, centerY);
            root.LeftBottom = createNode(root, root.Region.Left, centerY, centerX, root.Region.Bottom);
            root.RightTop = createNode(root, centerX, root.Region.Top, root.Region.Right, centerY);
            root.RightBottom = createNode(root, centerX, centerY, root.Region.Right, root.Region.Bottom);
            //将元素放到分裂后的节点中
            for (int i = 0; i < root.Elements.Count; i++)
            {
                insertChildNode(root,root.Elements[i]);
                root.Elements.RemoveAt(i);
                i--;
            }
        }

        private void insertChildNode(Node root, Point point)
        {
            throw new NotImplementedException();
        }

        private Node createNode(Node root, double left, double top, double right, double botton)
        {
            throw new NotImplementedException();
        }
    }
}
