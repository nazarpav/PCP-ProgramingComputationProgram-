using System;
using System.Collections.Generic;
using System.Text;

namespace _12._11._2019
{
    class Byte_
    {
        public bool BIT0 { get; set; }
        public bool BIT1 { get; set; }
        public bool BIT2 { get; set; }
        public bool BIT3 { get; set; }
        public bool BIT4 { get; set; }
        public bool BIT5 { get; set; }
        public bool BIT6 { get; set; }
        public bool BIT7 { get; set; }
        public bool this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return BIT0;
                    case 1:
                        return BIT1;
                    case 2:
                        return BIT2;
                    case 3:
                        return BIT3;
                    case 4:
                        return BIT4;
                    case 5:
                        return BIT5;
                    case 6:
                        return BIT6;
                    case 7:
                        return BIT7;
                }
                throw new Exception("Invalid input");
            }

            set
            {
                switch (index)
                {
                    case 0:
                        BIT0=value;
                        break;
                    case 1:
                        BIT1 = value;
                        break;
                    case 2:
                        BIT2 = value;
                        break;
                    case 3:
                        BIT3 = value;
                        break;
                    case 4:
                        BIT4 = value;
                        break;
                    case 5:
                        BIT5 = value;
                        break;
                    case 6:
                        BIT6 = value;
                        break;
                    case 7:
                         BIT7 = value;
                        break;
                }
            }
        }
        public Byte_(bool BIT0, bool BIT1, bool BIT2, bool BIT3, bool BIT4, bool BIT5, bool BIT6, bool BIT7)
        {
            this.BIT0 = BIT0;
            this.BIT1 = BIT1;
            this.BIT2 = BIT2;
            this.BIT3 = BIT3;
            this.BIT4 = BIT4;
            this.BIT5 = BIT5;
            this.BIT6 = BIT6;
            this.BIT7 = BIT7;
        }
        public Byte_(byte num)
        {
            this.BIT7 = num % 2==1;
            num /= 2;
            this.BIT6 = num % 2==1;
            num /= 2;   
            this.BIT5 =num % 2==1;
            num /= 2;    
            this.BIT4 =num % 2==1;
            num /= 2;    
            this.BIT3 =num % 2==1;
            num /= 2;  
            this.BIT2 =num % 2==1;
            num /= 2;  
            this.BIT1 =num % 2==1;
            num /= 2;
            this.BIT0 = num % 2 == 1;
            num /= 2;
        }
        public Byte_()
        {

        }
        private bool ByteToBool(byte num)
        {
            switch (num)
            {
                case 0:return false;
                case 1:return true;
                default:
                    throw new Exception("invalid input");
            }
        }
        public Byte_(byte num1, byte num2, byte num3, byte num4, byte num5, byte num6, byte num7, byte num8)
        {
            this.BIT0 = ByteToBool(num1);
            this.BIT1 = ByteToBool(num2);
            this.BIT2 = ByteToBool(num3);
            this.BIT3 = ByteToBool(num4);
            this.BIT4 = ByteToBool(num5);
            this.BIT5 = ByteToBool(num6);
            this.BIT6 = ByteToBool(num7);
            this.BIT7 = ByteToBool(num8);
        }
        public override string ToString()
        {
            return (BIT0?"1":"0") + (BIT1 ? "1" : "0")  + (BIT2? "1" : "0") + (BIT3 ? "1" : "0") + (BIT4 ? "1" : "0") + (BIT5 ? "1" : "0") + (BIT6 ? "1" : "0") + (BIT7 ? "1" : "0");
        }
    }
}
