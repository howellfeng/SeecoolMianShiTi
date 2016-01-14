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
        }

    }
}
