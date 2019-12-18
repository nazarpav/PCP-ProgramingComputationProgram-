using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12._11._2019
{
    public partial class Form1 : Form
    {
        List<BaseMyElement> InSwitch1;
        List<BaseMyElement> InSwitch2;
        List<Lamp> lamps;
        Lamp OutOfRange;
        Lever lever;
        Byte_ _outByte;
        Byte_ _inByte1;
        Byte_ _inByte2;
        Screen screen1;
        Screen screen2;
        Screen screen3;
        Screen screen4CounterInstructions;
        bool OutOfRange_;
        bool IsSubstract;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Programing Computational Program";
            Paint += Form1_Paint;
            InSwitch1 = new List<BaseMyElement>();
            InSwitch2 = new List<BaseMyElement>();
            _outByte = new Byte_();
            _inByte1 = new Byte_();
            _inByte2 = new Byte_();
            
            lamps = new List<Lamp>();

            MouseClick += MouseClick_;
            LoadMyElement();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void MouseClick_(object sender, MouseEventArgs e)
        {
            UpdateAll(e);
            UpdateLamp();
            UpdateScreen();
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].IsEnabled = _outByte[i];
            }
            OutOfRange.IsEnabled = OutOfRange_;
            UpdateLamp();
            UpdateScreen();
            Invalidate();
        }
        private void UpdateAll(MouseEventArgs e)
        {
            if (lever.rect.Contains(e.Location))
            {
                lever.Press();
                IsSubstract = lever.IsEnabled;
            }
            for (int i = 0; i < InSwitch1.Count; i++)
            {
                if (InSwitch1[i].rect.Contains(e.Location))
                {
                    switch (InSwitch1[i].elementFigureType)
                    {
                        case MyElementFigureType.Lever:
                            ((Lever)InSwitch1[i]).Press();
                            _inByte1[i] = ((Lever)InSwitch1[i]).IsEnabled;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < InSwitch2.Count; i++)
            {
                if (InSwitch2[i].rect.Contains(e.Location))
                {
                    switch (InSwitch2[i].elementFigureType)
                    {
                        case MyElementFigureType.Lever:
                            ((Lever)InSwitch2[i]).Press();
                            _inByte2[i] = ((Lever)InSwitch2[i]).IsEnabled;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < lamps.Count; i++)
            {
                lamps[i].IsEnabled = _outByte[i];
            }
            OutOfRange.IsEnabled = OutOfRange_;
        }
        private void UpdateLamp()
        {
            _outByte = Elements.OneByteADDER(_inByte1, _inByte2, out OutOfRange_,IsSubstract);
        }
        private void UpdateScreen()
        {
            screen1.SetNum(Convert.ToInt32(_inByte1.ToString(), 2).ToString(), false);
            screen2.SetNum(Convert.ToInt32(_inByte2.ToString(), 2).ToString(), false);
            screen3.SetNum(Convert.ToInt32(_outByte.ToString(), 2).ToString(), OutOfRange.IsEnabled&& IsSubstract);
            screen4CounterInstructions.SetNum(Elements.GetCountInstruction.ToString(), false);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawMyElements(e.Graphics);
        }
        private void DrawMyElements(Graphics grph)
        {
            foreach (var element in InSwitch1)
            {
                element.Draw(grph);
            }
            foreach (var element in InSwitch2)
            {
                element.Draw(grph);
            }
            foreach (var i in lamps)
            {
                i.Draw(grph);
            }
            OutOfRange.Draw(grph);
            lever.Draw(grph);
            screen1.Draw(grph);
            screen2.Draw(grph);
            screen3.Draw(grph);
            screen4CounterInstructions.Draw(grph);
        }
        private void LoadMyElement()
        {
            const int _8BitQuantityNum = 8;
            for (int i = 1; i <= _8BitQuantityNum; i++)
            {
                InSwitch1.Add(new Lever(new Rectangle(new Point(48 * i, 100), new Size(48, 48))));
                InSwitch2.Add(new Lever(new Rectangle(new Point(48 * i, 150), new Size(48, 48))));
                lamps.Add(new Lamp(new Rectangle(new Point(48*i, 210), new Size(48, 48))));
            }
            lever = new Lever(new Rectangle(new Point(0, 120), new Size(48, 48)));
            OutOfRange = new Lamp(new Rectangle(new Point(48 , 260), new Size(48, 48)));
            const int quantitySymbolInScreen = 4;
            screen1 = new Screen(quantitySymbolInScreen,new Rectangle(new Point(48* (_8BitQuantityNum+1),100),new Size(36,48)));
            screen2 = new Screen(quantitySymbolInScreen,new Rectangle(new Point(48* (_8BitQuantityNum+1),150),new Size(36,48)));
            screen3 = new Screen(quantitySymbolInScreen,new Rectangle(new Point(48* (_8BitQuantityNum+1),210),new Size(36,48)));
            screen4CounterInstructions = new Screen(5,new Rectangle(new Point(48* (_8BitQuantityNum+5),100),new Size(36,48)));
        }


    }
}
