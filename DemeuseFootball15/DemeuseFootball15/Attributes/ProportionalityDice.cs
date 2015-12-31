using System;

namespace DemeuseFootball15.Attributes
{
    public class ProportionalityDiceAttribute : DiceAttribute
    {
        public ProportionalityDiceAttribute(int order, Type proportionalToType) 
            : base(order)
        {
            ProportionalToType = proportionalToType;
        }

        public Type ProportionalToType { get; private set; }
    }
}
