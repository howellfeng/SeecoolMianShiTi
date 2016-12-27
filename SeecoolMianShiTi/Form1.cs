using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            Josephus2 j2 = new Josephus2(9, 1, 5);
            j2.Calc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reverse r = new Reverse(5);
            r.Calc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BTree t = new BTree();
            t.CalcNLR2(t.Root);
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
    }
}
