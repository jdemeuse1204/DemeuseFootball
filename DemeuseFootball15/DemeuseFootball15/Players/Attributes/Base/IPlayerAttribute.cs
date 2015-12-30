using DemeuseFootball15.Attributes;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes.Base
{
    public interface IPlayerAttribute
    {
        object Value { get; }

        void Calculate(Player player, IDiceShaker shaker);

        void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute);
    }
}
