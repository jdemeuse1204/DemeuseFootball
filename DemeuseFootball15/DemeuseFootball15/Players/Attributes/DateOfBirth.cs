using System;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class DateOfBirth : PlayerAttribute
    {
        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var roll = shaker.RandomRoll(-730, 730);
            var date = DateTime.Now.AddYears(-10).AddDays(-180);

            date = date.AddDays(roll);

            SetValue(date);
        }
    }
}
