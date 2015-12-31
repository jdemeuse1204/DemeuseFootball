using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class ThrowOnTheRun : PlayerAttribute
    {
        [PotentialProperty]
        private double _coordinationModifier { get; set; }

        [PotentialProperty]
        private double _mechanicsModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var mechanics = player.ThrowingMechanics.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();
            double value;

            // coordination modifier
            if (coordination <= 30)
            {
                value = 5;
                _coordinationModifier = shaker.RandomRoll(-.5, -.3);
            }
            else if (coordination > 30 && coordination <= 60)
            {
                value = 8;
                _coordinationModifier = shaker.RandomRoll(-.3, -.1);
            }
            else if (coordination > 60 && coordination <= 75)
            {
                value = shaker.RandomRoll(20, 30);
                _coordinationModifier = shaker.RandomRoll(-.1, .1);
            }
            else if (coordination > 75 && coordination <= 90)
            {
                value = shaker.RandomRoll(20, 50);
                _coordinationModifier = shaker.RandomRoll(.1, .15);
            }
            else
            {
                value = shaker.RandomRoll(20, 60);
                _coordinationModifier = shaker.RandomRoll(.15, .25);
            }

            // handSize modifier
            if (mechanics <= 30)
            {
                _mechanicsModifier = shaker.RandomRoll(-.6, -.5);
            }
            else if (mechanics > 30 && mechanics <= 50)
            {
                _mechanicsModifier = shaker.RandomRoll(-.4, -.3);
            }
            else if (mechanics > 50 && mechanics <= 60)
            {
                _mechanicsModifier = shaker.RandomRoll(-.3, -.2);
            }
            else if (mechanics > 60 && mechanics <= 70)
            {
                _mechanicsModifier = shaker.RandomRoll(-.1, 0);
            }
            else if (mechanics > 70 && mechanics <= 80)
            {
                _mechanicsModifier = shaker.RandomRoll(0, .1);
            }
            else if (mechanics > 80 && mechanics <= 90)
            {
                _mechanicsModifier = shaker.RandomRoll(.1, .13);
            }
            else
            {
                _mechanicsModifier = shaker.RandomRoll(.15, .19);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var mechanics = player.ThrowingMechanics.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();

            value += (_mechanicsModifier * mechanics) + (_coordinationModifier * coordination);

            return value < 0 ? 0 : value;
        }
    }
}
