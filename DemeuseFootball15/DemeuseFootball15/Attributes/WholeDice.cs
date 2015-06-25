using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WholeDiceAttribute : DiceAttribute
    {
        public WholeDiceAttribute(int sides)
        {
            Min = 1;
            Max = sides;
            Volatility = DiceVolatility._0;
        }

        public WholeDiceAttribute(int min, int max)
        {
            Min = min;
            Max = max;
            Volatility = DiceVolatility._0;
        }

        public WholeDiceAttribute(int min, int max, DiceVolatility volatility)
        {
            Min = min;
            Max = max;
            Volatility = volatility;
        }
    }
}
