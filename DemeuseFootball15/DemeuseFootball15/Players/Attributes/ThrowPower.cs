using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class ThrowPower : PlayerAttribute
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
            var armStrength = player.Coordination.GetValue<double>();
            double value;

            // arm strength modifier
            if (armStrength <= 15)
            {
                value = 15;
                _armStrengthModifier = shaker.RandomRoll(-.2, 0);
            }
            else if (armStrength > 15 && armStrength <= 20)
            {
                value = 17.5;
                _armStrengthModifier = shaker.RandomRoll(-.12, 0);
            }
            else if (armStrength > 25 && armStrength <= 30)
            {
                value = 27.5;
                _armStrengthModifier = shaker.RandomRoll(0, .01);
            }
            else if (armStrength > 35 && armStrength <= 40)
            {
                value = 37.5;
                _armStrengthModifier = shaker.RandomRoll(.06, .1);
            }
            else if (armStrength > 45 && armStrength <= 50)
            {
                value = 47.5;
                _armStrengthModifier = shaker.RandomRoll(.1, .19);
            }
            else
            {
                value = 50;
                _armStrengthModifier = shaker.RandomRoll(.19, .25);
            }

            // coordination modifier
            if (coordination <= 30)
            {
                _coordinationModifier = shaker.RandomRoll(-.1, 0);
            }
            else if (coordination > 30 && coordination <= 60)
            {
                _coordinationModifier = shaker.RandomRoll(0, .05);
            }
            else if (coordination > 60 && coordination <= 75)
            {
                _coordinationModifier = shaker.RandomRoll(.05,.09);
            }
            else if (coordination > 75 && coordination <= 90)
            {
                _coordinationModifier = shaker.RandomRoll(.09, .1);
            }
            else
            {
                _coordinationModifier = shaker.RandomRoll(.1, .15);
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
            var armStrength = player.Coordination.GetValue<double>();

            value += (_armStrengthModifier * armStrength) + (_mechanicsModifier * mechanics) + (_coordinationModifier * coordination);

            return value < 0 ? 0 : value;
        }
    }
}
