using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Acceleration : PlayerAttribute
    {
        [PotentialProperty]
        private double _strengthModifier { get; set; }

        [PotentialProperty]
        private double _twitchModifier { get; set; }

        [PotentialProperty]
        private double _flexibilityModifier { get; set; }

        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var twitch = player.MuscleFibreTwitch.GetValue<double>();
            var strength = player.LegStrength.GetValue<double>();
            var flexibility = player.Flexibility.GetValue<double>();
            var value = shaker.Roll((dynamic)diceAttribute);

            // strength modifier
            if (strength <= 30)
            {
                _strengthModifier = shaker.RandomRoll(-.3, -.2);
            }
            else if (strength > 30 && strength <= 60)
            {
                _strengthModifier = shaker.RandomRoll(-.15, -.05);
            }
            else if (strength > 60 && strength <= 75)
            {
                _strengthModifier = shaker.RandomRoll(.09, .15);
            }
            else if (strength > 75 && strength <= 90)
            {
                _strengthModifier = shaker.RandomRoll(.15, .19);
            }
            else
            {
                _strengthModifier = shaker.RandomRoll(.19, .25);
            }

            // twitch modifier
            if (twitch <= 30)
            {
                _twitchModifier = shaker.RandomRoll(-.12, 0);
            }
            else if (twitch > 30 && twitch <= 60)
            {
                _twitchModifier = shaker.RandomRoll(-.8, 0);
            }
            else if (twitch > 60 && twitch <= 75)
            {
                _twitchModifier = shaker.RandomRoll(.03, .06);
            }
            else if (twitch > 75 && twitch <= 90)
            {
                _twitchModifier = shaker.RandomRoll(.06, .09);
            }
            else
            {
                _twitchModifier = shaker.RandomRoll(.09, .15);
            }

            // How much of the flexibility should we take
            if (flexibility <= 30)
            {
                _flexibilityModifier = shaker.RandomRoll(-.2, 0);
            }
            else if (flexibility > 30 && flexibility <= 60)
            {
                _flexibilityModifier = shaker.RandomRoll(-.1, 0);
            }
            else if (flexibility > 60 && flexibility <= 75)
            {
                _flexibilityModifier = shaker.RandomRoll(0, .05);
            }
            else if (flexibility > 75 && flexibility <= 90)
            {
                _flexibilityModifier = shaker.RandomRoll(.05, .08);
            }
            else
            {
                _flexibilityModifier = shaker.RandomRoll(.08, .12);
            }

            var result = _calculateValue(player, value);

            SetValue(result);
        }

        private double _calculateValue(Player player, double value)
        {
            var twitch = player.MuscleFibreTwitch.GetValue<double>();
            var strength = player.LegStrength.GetValue<double>();
            var flexibility = player.Flexibility.GetValue<double>();

            value += (_twitchModifier * twitch) + (_strengthModifier * strength) + (_flexibilityModifier * flexibility);

            return value;
        }
    }
}
