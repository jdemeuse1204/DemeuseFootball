using System;
using System.Linq;
using System.Reflection;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15
{
    public partial class Factory
    {
        public static Player CreatePlayer()
        {
            return new RandomPlayer();
        }
    }

    public partial class Factory
    {
        protected class RandomPlayer : Player
        {
            public RandomPlayer(DiceShaker shaker)
            {
                // General
                // Age
                var age = shaker.RandomRoll(10, 12);

                // in case age is outside of rabge
                while (age >= 12)
                {
                    age = shaker.RandomRoll(10, 12);
                }

                // Date of Birth
                var yearDate = new DateTime(DateTime.Now.Year - (int)age, DateTime.Now.Month, DateTime.Now.Day).AddYears(-1);
                var days = DateTime.IsLeapYear(yearDate.Year + 1) ? 365 : 364;
                var findBday = Services.Next(0, days);

                DateOfBirth = yearDate.AddDays(findBday);

                // Physical Traits
                this.Height = this.Age == 10 ? Services.NextDouble(54.5, 5, 3, 3, 48, 62) : Services.NextDouble(56.5, 8, 3, 3, 50, 64);

                var properties = this.GetType().GetProperties().Where(w => w.GetCustomAttribute<DiceAttribute>() != null);

                foreach (var property in properties)
                {
                    var attr = property.GetCustomAttribute<DiceAttribute>();

                    property.SetValue(this, shaker.Roll(attr as dynamic));
                }
            }
        }
    }
}
