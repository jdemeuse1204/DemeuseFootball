using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    public abstract class DiceAttribute : Attribute, IDiceAttribute
    {
        protected DiceAttribute(int order)
        {
            Order = order;
        }

        public double Min { get; protected set; }

        public double Max { get; protected set; }

        public DiceVolatility Volatility { get; protected set; }

        public int Order { get; protected set; }
    }
}
