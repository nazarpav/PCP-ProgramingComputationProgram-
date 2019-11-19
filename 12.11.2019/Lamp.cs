using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._11._2019
{
    class Lamp : BaseMyElement
    {
        private static int IdCount=0;
        Image _imageLeverOff = new Bitmap(@"LampLightFalse2.png");
        Image _imageLeverOn = new Bitmap(@"LampLightTrue2.png");
        public int ID { get; set; }
        public bool IsEnabled { get; set; }
        public Lamp(Rectangle rectangle, bool IsEnabled) : base(MyElementFigureType.Lever, rectangle)
        {
            this.IsEnabled = IsEnabled;
            ID=IdCount++;
        }
        public Lamp(Rectangle rectangle) : base(MyElementFigureType.Lever, rectangle)
        {
            IsEnabled = false;
            ID = IdCount++;
        }
        public override void Draw(Graphics grph)
        {
            grph.DrawImage((IsEnabled ? _imageLeverOn : _imageLeverOff), rect);
        }
        public void SetState(bool bool_)
        {
            IsEnabled = bool_;
        }
    }
}
