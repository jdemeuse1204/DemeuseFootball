using DemeuseFootball15.Enumeration;
using TestSimpleRNG;

namespace DemeuseFootball15.RandomProperty
{
    public class RandomDouble
    {
        public RandomDouble(double mean, double standardDeviation, Volatility volatility)
        {
            var v = (int) volatility;
            var total = 0d;

            for (var i = 0; i < v; i++)
            {
                total += SimpleRNG.GetNormal(mean, standardDeviation);
            }

            Value = total / v;
        }

        public RandomDouble(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }
    }
}
