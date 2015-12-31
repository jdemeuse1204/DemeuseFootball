using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Carry : PlayerAttribute
    {
        [PotentialProperty]
        private double _coordinationModifier { get; set; }

        [PotentialProperty]
        private double _handSizeModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var handSize = player.Hand.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();
            var value = shaker.Roll((dynamic)diceAttribute);

            // coordination modifier
            if (coordination <= 30)
            {
                _coordinationModifier = shaker.RandomRoll(-.4, -.3);
            }
            else if (coordination > 30 && coordination <= 60)
            {
                _coordinationModifier = shaker.RandomRoll(-.3, -.2);
            }
            else if (coordination > 60 && coordination <= 75)
            {
                _coordinationModifier = shaker.RandomRoll(-.1, 0);
            }
            else if (coordination > 75 && coordination <= 90)
            {
                _coordinationModifier = shaker.RandomRoll(.1, .19);
            }
            else
            {
                _coordinationModifier = shaker.RandomRoll(.19, .25);
            }

            // handSize modifier
            if (handSize <= 5)
            {
                _handSizeModifier = shaker.RandomRoll(-.2, 0);
            }
            else if (handSize > 5 && handSize <= 5.5)
            {
                _handSizeModifier = shaker.RandomRoll(-.12, 0);
            }
            else if (handSize > 5.5 && handSize <= 6)
            {
                _handSizeModifier = shaker.RandomRoll(0, .01);
            }
            else if (handSize > 6 && handSize <= 7)
            {
                _handSizeModifier = shaker.RandomRoll(.06, .1);
            }
            else if (handSize > 7 && handSize <= 8)
            {
                _handSizeModifier = shaker.RandomRoll(.1, .19);
            }
            else
            {
                _handSizeModifier = shaker.RandomRoll(.19, 1);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var handSize = player.Hand.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();

            value += (_coordinationModifier * coordination) + (_handSizeModifier * handSize);

            return value < 0 ? 0 : value;
        }
    }
}
