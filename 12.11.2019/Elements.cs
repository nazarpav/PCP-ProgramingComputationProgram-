using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _12._11._2019
{
    static class Elements
    {
        private static readonly SoundPlayer _sound1 = new SoundPlayer(@"releSound1.wav");
        private static readonly SoundPlayer _sound2 = new SoundPlayer(@"releSound2.wav");
        private static readonly SoundPlayer _sound3 = new SoundPlayer(@"releSound3.wav");
        //private static readonly Sound _sound1;
        //private static readonly Sound _sound2;
        //private static readonly Sound _sound3;
        //static Elements()
        //{
        //    _sound1 = new Sound(new SoundBuffer(@"releSound1.wav"));
        //    _sound2 = new Sound(new SoundBuffer(@"releSound2.wav"));
        //    _sound3 = new Sound(new SoundBuffer(@"releSound3.wav"));
        //}
        public static uint GetCountInstruction {get;private set;}
        public const bool GND = false;
        //NOT
        //A|R
        //0|1
        //1|0
        public static bool NOT(bool Value)
        {
            GetCountInstruction++;
            return !Value;
        }
        //AND
        //AB|R
        //00|0
        //01|0
        //10|0
        //11|1
        public static bool AND(bool ValueA, bool ValueB)
        {
            GetCountInstruction++;
            return ValueA & ValueB;
        }
        //OR
        //AB|R
        //00|0
        //01|1
        //10|1
        //11|1
        public static bool OR(bool ValueA, bool ValueB)
        {
            GetCountInstruction++;
            return ValueA | ValueB;
        }
        //NOT AND
        //AB|R
        //00|1
        //01|1
        //10|1
        //11|0
        public static bool NAND(bool ValueA, bool ValueB)
        {
            GetCountInstruction++;
            return NOT(AND(ValueA, ValueB));
        }
        //NOT OR
        //AB|R
        //00|1
        //01|0
        //10|0
        //11|0
        public static bool NOR(bool ValueA, bool ValueB)
        {
            GetCountInstruction++;
            return NOT(OR(ValueA, ValueB));
        }

        //XOR
        //AB|R
        //00|0
        //01|1
        //10|1
        //11|0
        public static bool XOR(bool VA, bool VB)
        {
            GetCountInstruction++;
            return VA ^ VB;
        }


        public static bool ADDER(bool VA, bool VB, bool Cin,out bool Cout)
        {
            Cout = OR(AND(XOR(VA, VB), Cin), AND(VA, VB));
            return XOR(XOR(VA, VB), Cin);
        }
        private static Byte_ Inversion(Byte_ byte_ ,bool in_)
        {
            Byte_ result=new Byte_();
            result.BIT0 = XOR(byte_.BIT0, in_);
            result.BIT1 = XOR(byte_.BIT1, in_);
            result.BIT2 = XOR(byte_.BIT2, in_);
            result.BIT3 = XOR(byte_.BIT3, in_);
            result.BIT4 = XOR(byte_.BIT4, in_);
            result.BIT5 = XOR(byte_.BIT5, in_);
            result.BIT6 = XOR(byte_.BIT6, in_);
            result.BIT7 = XOR(byte_.BIT7, in_);
            return result;
        }
        public static Byte_ OneByteADDER(Byte_ ByteA, Byte_ ByteB,out bool t, bool IsSubstract)
        {
            Byte_ byte_ = Inversion(new Byte_(),IsSubstract);

            ByteB = Inversion(ByteB, IsSubstract);
            t = false;
            Byte_ result = new Byte_();
            result.BIT7 = ADDER(ByteA.BIT7, ByteB.BIT7, IsSubstract, out t);
            result.BIT6 = ADDER(ByteA.BIT6, ByteB.BIT6,t, out t);
            result.BIT5 = ADDER(ByteA.BIT5, ByteB.BIT5, t, out t);
            result.BIT4 = ADDER(ByteA.BIT4, ByteB.BIT4, t, out t);
            result.BIT3 = ADDER(ByteA.BIT3, ByteB.BIT3, t, out t);
            result.BIT2 = ADDER(ByteA.BIT2, ByteB.BIT2, t, out t);
            result.BIT1  = ADDER(ByteA.BIT1, ByteB.BIT1, t, out t);
            result.BIT0 = ADDER(ByteA.BIT0, ByteB.BIT0, t, out t);
            t = XOR(t,IsSubstract);
            if(t && IsSubstract)
            {
                for (int i = 0; i < 8; i++)
                    result[i] = NOT(result[i]);
                result=OneByteADDER(result, new Byte_(1),out bool tm,false);
            }

            return result;
        }
       
        /*
 7
 6
 5
 4
 3
 2
 1 
 0

        0
        1 
        2
        3
        4
        5
        6
        7
 */
    }
}
