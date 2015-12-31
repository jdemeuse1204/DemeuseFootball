using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Injury : PlayerAttribute
    {
        [PotentialProperty]
        private double _mentalToughnessModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var mentalToughness = player.MentalToughness.GetValue<double>();
            var value = shaker.Roll((dynamic)diceAttribute);

            // coordination modifier
            if (mentalToughness <= 30)
            {
                _mentalToughnessModifier = shaker.RandomRoll(-.3, -.2);
            }
            else if (mentalToughness > 30 && mentalToughness <= 60)
            {
                _mentalToughnessModifier = shaker.RandomRoll(-.2, -.1);
            }
            else if (mentalToughness > 60 && mentalToughness <= 75)
            {
                _mentalToughnessModifier = shaker.RandomRoll(0, .15);
            }
            else if (mentalToughness > 75 && mentalToughness <= 90)
            {
                _mentalToughnessModifier = shaker.RandomRoll(.1, .19);
            }
            else
            {
                _mentalToughnessModifier = shaker.RandomRoll(.19, .25);
            }
            
            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var mentalToughness = player.MentalToughness.GetValue<double>();

            value += (_mentalToughnessModifier * mentalToughness);

            return value < 0 ? 0 : value;
        }
    }
}
