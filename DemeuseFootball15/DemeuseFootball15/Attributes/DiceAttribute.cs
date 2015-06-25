using System;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    public abstract class DiceAttribute : Attribute
    {
        public double Min { get; protected set; }
        public double Max { get; protected set; }
        public DiceVolatility Volatility { get; protected set; }
    }
}
