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

    class Lever:BaseMyElement
    {
        
        Image _imageLeverOn = new Bitmap(@"LeverOn3.png");
        Image _imageLeverOff = new Bitmap(@"LeverOff3.png");
        
        SoundPlayer LeverPressed;
        public bool IsEnabled { get; set; }
        public Lever(Rectangle rectangle, bool IsEnabled):base(MyElementFigureType.Lever, rectangle)
        {
            this.IsEnabled = IsEnabled;
            LeverPressed = new SoundPlayer(@"leverSound.wav");
            LeverPressed.Load();
        }
        public Lever(Rectangle rectangle) : base(MyElementFigureType.Lever,rectangle)
        {
            IsEnabled = false;
            LeverPressed = new SoundPlayer(@"leverSound.wav");
        }
        public override void Draw(Graphics grph)
        {
            grph.DrawImage((IsEnabled ? _imageLeverOn : _imageLeverOff), rect);
        }
        public void Press()
        {
            IsEnabled = !IsEnabled;
            LeverPressed.Play();
        }
    }
}
