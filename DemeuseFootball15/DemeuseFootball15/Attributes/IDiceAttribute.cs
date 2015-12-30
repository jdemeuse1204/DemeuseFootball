using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Attributes
{
    public interface IDiceAttribute
    {
        double Min { get; }

        double Max { get; }

        DiceVolatility Volatility { get; }

        int Order { get;}
    }
}
