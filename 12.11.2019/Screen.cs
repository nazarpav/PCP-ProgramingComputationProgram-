using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._11._2019
{
    class Screen:BaseMyElement
    {
        private Image _ = new Bitmap(@"Symbol10.png");
        private Image _null = new Bitmap(@"SymbolNull.png");
        private Image _0 = new Bitmap(@"Symbol0.png");
        private Image _1 = new Bitmap(@"Symbol1.png");
        private Image _2 = new Bitmap(@"Symbol2.png");
        private Image _3 = new Bitmap(@"Symbol3.png");
        private Image _4 = new Bitmap(@"Symbol4.png");
        private Image _5 = new Bitmap(@"Symbol5.png");
        private Image _6 = new Bitmap(@"Symbol6.png");
        private Image _7 = new Bitmap(@"Symbol7.png");
        private Image _8 = new Bitmap(@"Symbol8.png");
        private Image _9 = new Bitmap(@"Symbol9.png");
        private readonly int _quantitySymbol;
        private string num=string.Empty;
        private Rectangle SaveRect;
        private bool isMinus;
        public Screen(int quantitySymbol, Rectangle rectangleOneElement):base(MyElementFigureType.Screen,rectangleOneElement)
        {
            _quantitySymbol = quantitySymbol;
            SaveRect = rectangleOneElement;
        }
        public void SetNum(string num,bool isMinus)
        {
            this.isMinus = isMinus;
            if (num.Length> _quantitySymbol)
            {
                throw new Exception("Num is large");
            }
            this.num = num;
        }
        public override void Draw(Graphics grph)
        {
            const int offset = 1;
            int counter= num .Length-1;
            SaveRect.X += rect.Width * _quantitySymbol - (int)(rect.Width/1.5f);
            for (int i = 0 ; i < _quantitySymbol; i++)
            {
                if (counter >= 0 && counter < num.Length)
                {
                    switch (num[counter--])
                    {
                        case '-':
                            grph.DrawImage(_, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '0':
                            grph.DrawImage(_0, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '1':
                            grph.DrawImage(_1, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '2':
                            grph.DrawImage(_2, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '3':
                            grph.DrawImage(_3, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '4':
                            grph.DrawImage(_4, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '5':
                            grph.DrawImage(_5, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '6':
                            grph.DrawImage(_6, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '7':
                            grph.DrawImage(_7, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '8':
                            grph.DrawImage(_8, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                        case '9':
                            grph.DrawImage(_9, SaveRect);
                            SaveRect.X -= SaveRect.Width + offset;
                            break;
                    }
                }
                else
                {
                    if (i == num.Length && isMinus)
                    {
                        grph.DrawImage(_, SaveRect);
                        SaveRect.X -= SaveRect.Width + offset;
                    }
                    else
                    {
                        grph.DrawImage(_null, SaveRect);
                        SaveRect.X -= SaveRect.Width + offset;
                    }
                }
            }
            SaveRect = rect;
        }
    }
}
