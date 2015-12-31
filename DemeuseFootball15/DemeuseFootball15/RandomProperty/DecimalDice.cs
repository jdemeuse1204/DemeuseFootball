using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.RandomProperty
{
    public class DecimalDice : Dice
    {
        public DecimalDice(DecimalDiceAttribute dice)
            : base(dice)
        {

        }

        public DecimalDice(double min, double max, Volatility volatility)
            : base(min,max,volatility)
        {
        }
    }
}
