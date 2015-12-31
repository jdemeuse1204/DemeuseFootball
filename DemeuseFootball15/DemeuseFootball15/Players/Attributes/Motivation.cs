using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Motivation : PlayerAttribute
    {
        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var baseline = player.DriveBaseline;
            double value;

            // arm strength modifier
            if (baseline <= 15)
            {
                value = shaker.RandomRoll(10, 20);
            }
            else if (baseline > 15 && baseline <= 30)
            {
                value = shaker.RandomRoll(20, 30);
            }
            else if (baseline > 30 && baseline <= 45)
            {
                value = shaker.RandomRoll(30, 40);
            }
            else if (baseline > 45 && baseline <= 60)
            {
                value = shaker.RandomRoll(40, 50);
            }
            else if (baseline > 60 && baseline <= 75)
            {
                value = shaker.RandomRoll(50, 75);
            }
            else if (baseline > 75 && baseline <= 85)
            {
                value = shaker.RandomRoll(75, 85);
            }
            else if (baseline > 85 && baseline <= 90)
            {
                value = shaker.RandomRoll(85, 90);
            }
            else
            {
                value = shaker.RandomRoll(90, 100);
            }

            SetValue(value);
        }
    }
}
