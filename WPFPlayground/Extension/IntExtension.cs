using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPlayground.Extension
{
    public static class IntExtension
    {
        public static int DoubleIt(this int value)
        {
            return value * 2;
        }

        public static int MultiplyByGivenValue(this int value, int givenValue)
        {
            return value * givenValue;
        }
    }
}
