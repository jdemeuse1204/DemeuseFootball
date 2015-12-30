using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateDiceAttribute : DiceAttribute
    {
        public DateDiceAttribute(int order)
            : base(order)
        {
            Min = -1;
            Max = -1;
            Volatility = DiceVolatility._0;
        }
    }
}
