using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.RandomProperty
{
    public class WholeDice : Dice
    {
        public WholeDice(double min, double max, Volatility volatility)
            : base(min,max,volatility)
        {

        }

        public WholeDice(WholeDiceAttribute dice)
            : base(dice)
        {

        }

        public override double Shake()
        {
            return (int) base.Shake();
        }
    }
}
