using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeecoolMianShiTi
{
    class RectangleIntersect
    {
        public bool IsIntersect(RectangleF rect1, RectangleF rect2)
        {
            //2个矩形相交情况较多，判断2个矩形不相交情况简单，加！即可判断相交
            //2矩形不相交情况左右或上下
            /*
             * rect1.Right < rect2.Left;//1在2左边
             * rect1.Left > rect2.Right;//1在2右边
             * rect1.Bottom < rect2.Top;//1在2下边
             * rect1.Top > rect2.Bottom;//1在2上边
             * */
            return !(rect1.Right < rect2.Left ||
                rect1.Left > rect2.Right ||
                rect1.Bottom < rect2.Top ||
                rect1.Top > rect2.Bottom);
        }
    }
}
