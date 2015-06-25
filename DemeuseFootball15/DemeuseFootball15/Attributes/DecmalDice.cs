using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecmalDiceAttribute : DiceAttribute
    {
        public DecmalDiceAttribute(int min, int max)
        {
            Min = min;
            Max = max;
            Volatility = DiceVolatility._0;
        }

        public DecmalDiceAttribute(int min, int max, DiceVolatility volatility)
        {
            Min = min;
            Max = max;
            Volatility = volatility;
        }
    }
}
