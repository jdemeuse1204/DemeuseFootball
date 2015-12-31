using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Flexibility : PlayerAttribute
    {
        [PotentialProperty]
        private double _legStrengthModifier { get; set; }

        [PotentialProperty]
        private double _armStrengthModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var armStrength = player.ArmStrength.GetValue<double>();
            var legStrength = player.LegStrength.GetValue<double>();
            var value = shaker.Roll((dynamic)diceAttribute);

            // arm strength modifier
            if (armStrength <= 30)
            {
                _armStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (armStrength > 30 && armStrength <= 60)
            {
                _armStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (armStrength > 60 && armStrength <= 75)
            {
                _armStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (armStrength > 75 && armStrength <= 90)
            {
                _armStrengthModifier = shaker.RandomRoll(-.16, 0);
            }
            else
            {
                _armStrengthModifier = shaker.RandomRoll(-.22, -.12);
            }

            // leg strength modifier
            if (legStrength <= 30)
            {
                _legStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (legStrength > 30 && legStrength <= 60)
            {
                _legStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (legStrength > 60 && legStrength <= 75)
            {
                _legStrengthModifier = shaker.RandomRoll(0, .15);
            }
            else if (legStrength > 75 && legStrength <= 90)
            {
                _legStrengthModifier = shaker.RandomRoll(-.16, 0);
            }
            else
            {
                _legStrengthModifier = shaker.RandomRoll(-.22, -.12);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var legStrength = player.LegStrength.GetValue<double>();
            var armStrength = player.ArmStrength.GetValue<double>();

            value += (_legStrengthModifier * legStrength) + (_armStrengthModifier * armStrength);

            return value;
        }
    }
}
