namespace DemeuseFootball15.RandomProperty
{
    public interface IDice
    {
        void GetBytes(byte[] buffer);

        double MinValue { get; }

        double MaxValue { get; }

        double Volatility { get; }

        double Shake();
    }
}
