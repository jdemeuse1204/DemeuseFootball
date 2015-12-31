using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class PlayAction : PlayerAttribute
    {
        [PotentialProperty]
        private double _techniqueModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var technique = player.Technique.GetValue<double>();
            double value;

            // coordination modifier
            if (technique <= 30)
            {
                value = 8;
                _techniqueModifier = shaker.RandomRoll(-.5, -.3);
            }
            else if (technique > 30 && technique <= 60)
            {
                value = shaker.RandomRoll(10, 15);
                _techniqueModifier = shaker.RandomRoll(-.3, -.1);
            }
            else if (technique > 60 && technique <= 75)
            {
                value = shaker.RandomRoll(15, 20);
                _techniqueModifier = shaker.RandomRoll(-.1, .1);
            }
            else if (technique > 75 && technique <= 90)
            {
                value = shaker.RandomRoll(25, 30);
                _techniqueModifier = shaker.RandomRoll(.1, .15);
            }
            else
            {
                value = shaker.RandomRoll(30, 35);
                _techniqueModifier = shaker.RandomRoll(.15, .25);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var technique = player.Technique.GetValue<double>();

            value += (_techniqueModifier * technique);

            return value < 0 ? 0 : value;
        }
    }
}
