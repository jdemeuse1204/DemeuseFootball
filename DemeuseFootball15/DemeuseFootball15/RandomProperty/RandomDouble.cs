using DemeuseFootball15.Enumeration;
using TestSimpleRNG;

namespace DemeuseFootball15.RandomProperty
{
    public class RandomDouble
    {
        public static double Next(double mean, double standardDeviation, Volatility volatility)
        {
            var v = (int) volatility;
            var total = 0d;

            for (var i = 0; i < v; i++)
            {
                total += SimpleRNG.GetNormal(mean, standardDeviation);
            }

            return total / v;
        }
    }
}
