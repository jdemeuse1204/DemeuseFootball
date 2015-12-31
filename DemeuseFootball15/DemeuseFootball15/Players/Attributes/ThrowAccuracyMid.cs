using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class ThrowAccuracyMid : PlayerAttribute
    {
        [PotentialProperty]
        private double _coordinationModifier { get; set; }

        [PotentialProperty]
        private double _mechanicsModifier { get; set; }

        [PotentialProperty]
        private double _armStrengthModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var mechanics = player.ThrowingMechanics.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();
            var armStrength = player.ArmStrength.GetValue<double>();
            var value = 30d;

            // armStrength modifier
            if (armStrength <= 30)
            {
                _armStrengthModifier = shaker.RandomRoll(-.2, -.1);
            }
            else if (armStrength > 30 && armStrength <= 40)
            {
                _armStrengthModifier = shaker.RandomRoll(-.1, -.05);
            }
            else if (armStrength > 40 && armStrength <= 50)
            {
                _armStrengthModifier = shaker.RandomRoll(-.05, 0);
            }
            else if (armStrength > 60 && armStrength <= 75)
            {
                _armStrengthModifier = shaker.RandomRoll(0, .1);
            }
            else if (armStrength > 75 && armStrength <= 90)
            {
                _armStrengthModifier = shaker.RandomRoll(.1, .15);
            }
            else
            {
                _armStrengthModifier = shaker.RandomRoll(.15, .25);
            }

            // coordination modifier
            if (coordination <= 30)
            {
                _coordinationModifier = shaker.RandomRoll(-.3, -.1);
            }
            else if (coordination > 30 && coordination <= 60)
            {
                _coordinationModifier = shaker.RandomRoll(-.1, -.05);
            }
            else if (coordination > 60 && coordination <= 75)
            {
                _coordinationModifier = shaker.RandomRoll(-.05, .1);
            }
            else if (coordination > 75 && coordination <= 90)
            {
                _coordinationModifier = shaker.RandomRoll(.1, .15);
            }
            else
            {
                _coordinationModifier = shaker.RandomRoll(.15, .25);
            }

            // mechanics modifier
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
            var armStrength = player.ArmStrength.GetValue<double>();

            value += (_mechanicsModifier * mechanics) + (_coordinationModifier * coordination) + (_armStrengthModifier * armStrength);

            return value < 0 ? 0 : value;
        }
    }
}
