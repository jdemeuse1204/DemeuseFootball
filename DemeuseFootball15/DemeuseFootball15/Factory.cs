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
                    var attribute = property.GetCustomAttribute<DiceAttribute>();

                    if (property.PropertyType.IsSubclassOf(typeof(PlayerAttribute)))
                    {
                        var instance = (PlayerAttribute)Activator.CreateInstance(property.PropertyType);
                        
                        instance.Create(this, shaker, attribute);

                        property.SetValue(this, instance);
                        continue;
                    }

                    // plain property
                    var value = shaker.Roll((dynamic) attribute);

                    property.SetValue(this,
                        property.PropertyType.IsEnum
                            ? Enum.ToObject(property.PropertyType, value)
                            : Convert.ChangeType(value, property.PropertyType));
                }
            }
        }
    }
}
