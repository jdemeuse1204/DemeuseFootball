using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class ThrowingMechanics : PlayerAttribute
    {
        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var technique = player.Technique.GetValue<double>();
            double result;

            // arm strength modifier
            if (technique <= 30)
            {
                result = shaker.RandomRoll(15, 25);
            }
            else if (technique > 30 && technique <= 60)
            {
                result = shaker.RandomRoll(25, 30);
            }
            else if (technique > 60 && technique <= 75)
            {
                result = shaker.RandomRoll(30, 40);
            }
            else if (technique > 75 && technique <= 90)
            {
                result = shaker.RandomRoll(40, 50);
            }
            else
            {
                result = shaker.RandomRoll(50, 60);
            }

            SetValue(result);
        }
    }
}
