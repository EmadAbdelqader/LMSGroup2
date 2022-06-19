using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    public class MathOperations
    {
        public double X { get; set; }
        public double Y { get; set; }


        public double Add()
        {
            return X + Y;
        }

        public double Subtract()
        {
            return X - Y;
        }
    }
}
