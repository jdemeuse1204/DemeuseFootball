using DemeuseFootball15.Attributes;

namespace DemeuseFootball15.RandomProperty
{
    public interface IDiceShaker
    {
        int Roll(WholeDiceAttribute diceAttribute);

        double Roll(DecimalDiceAttribute diceAttribute);

        double RandomRoll(int min, int max);
    }
}
