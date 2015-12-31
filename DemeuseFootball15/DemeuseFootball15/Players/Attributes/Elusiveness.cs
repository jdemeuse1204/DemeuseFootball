using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Elusiveness : PlayerAttribute
    {
        [PotentialProperty]
        private double _coordinationModifier { get; set; }

        [PotentialProperty]
        private double _agilityModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var agility = player.Agility.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();
            double value;

            // coordination modifier
            if (coordination <= 30)
            {
                value = 20;
                _coordinationModifier = shaker.RandomRoll(-.5, -.3);
            }
            else if (coordination > 30 && coordination <= 60)
            {
                value = 30;
                _coordinationModifier = shaker.RandomRoll(-.3, -.1);
            }
            else if (coordination > 60 && coordination <= 75)
            {
                value = 40;
                _coordinationModifier = shaker.RandomRoll(-.1, .1);
            }
            else if (coordination > 75 && coordination <= 90)
            {
                value = 50;
                _coordinationModifier = shaker.RandomRoll(.1, .15);
            }
            else
            {
                value = 55;
                _coordinationModifier = shaker.RandomRoll(.15, .25);
            }

            // handSize modifier
            if (agility <= 30)
            {
                value = 20;
                _agilityModifier = shaker.RandomRoll(-.6, -.5);
            }
            else if (agility > 30 && agility <= 50)
            {
                value = 35;
                _agilityModifier = shaker.RandomRoll(-.4, -.3);
            }
            else if (agility > 50 && agility <= 60)
            {
                _agilityModifier = shaker.RandomRoll(-.3, -.2);
            }
            else if (agility > 60 && agility <= 70)
            {
                _agilityModifier = shaker.RandomRoll(-.1, 0);
            }
            else if (agility > 70 && agility <= 80)
            {
                _agilityModifier = shaker.RandomRoll(0, .1);
            }
            else if (agility > 80 && agility <= 90)
            {
                _agilityModifier = shaker.RandomRoll(.1, .13);
            }
            else
            {
                _agilityModifier = shaker.RandomRoll(.15, .19);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var agility = player.Agility.GetValue<double>();
            var coordination = player.Coordination.GetValue<double>();

            value += (_agilityModifier * agility) + (_coordinationModifier * coordination);

            return value < 0 ? 0 : value;
        }
    }
}
