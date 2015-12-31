using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalDiceAttribute : DiceAttribute
    {
        public DecimalDiceAttribute(int order, int min, int max)
            : base(order)
        {
            Min = min;
            Max = max;
            Volatility = DiceVolatility._0;
        }

        public DecimalDiceAttribute(int order, int min, int max, DiceVolatility volatility)
            : base(order)
        {
            Min = min;
            Max = max;
            Volatility = volatility;
        }

        public DecimalDiceAttribute(int order)
            : base(order)
        {
            Min = -1;
            Max = -1;
            Volatility = DiceVolatility._0;
        }

        public DecimalDiceAttribute(int order, DiceVolatility volatility)
            : base(order)
        {
            Min = -1;
            Max = -1;
            Volatility = volatility;
        }
    }
}
