using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._11._2019
{
    abstract class BaseMyElement
    {
        public readonly Rectangle rect;
        public readonly MyElementFigureType elementFigureType;
        public abstract void Draw(Graphics grph);

        public BaseMyElement(MyElementFigureType elementFigureType, Rectangle rect)
        {
            this.elementFigureType = elementFigureType;
            this.rect = rect;
        }
    }
}
