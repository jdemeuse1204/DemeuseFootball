using System;
using System.Linq;
using System.Reflection;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15
{
    public partial class Factory
    {
        public static Player CreatePlayer(IDiceShaker shaker)
        {
            return new RandomPlayer(shaker);
        }
    }

    public partial class Factory
    {
        protected class RandomPlayer : Player
        {
            public RandomPlayer(IDiceShaker shaker)
            {

                var properties = GetType().GetProperties();

                // create the player
                foreach (
                    var property in
                        properties.Where(w => w.GetCustomAttribute<DiceAttribute>() != null)
                            .OrderBy(w => w.GetCustomAttribute<DiceAttribute>().Order))
                {
                    var instance = (IPlayerAttribute)Activator.CreateInstance(property.PropertyType);
                    var attribute = property.GetCustomAttribute<DiceAttribute>();

                    instance.Create(this, shaker, attribute);

                    property.SetValue(this, instance);
                }
            }
        }
    }
}
