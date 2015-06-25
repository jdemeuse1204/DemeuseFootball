using System;
using System.Security.Cryptography;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.RandomProperty
{
    public class WholeDice : RandomNumberGenerator, IDice
    {
        public double MinValue { get; private set; }

        public double MaxValue { get; private set; }

        public double Volatility { get; private set; }

        private static RandomNumberGenerator randomNumberGenerator;

        public WholeDice(double min, double max, Volatility volatility)
            : this()
        {
            MinValue = min;
            MaxValue = max;
            Volatility = (double)volatility;
        }

        public WholeDice(WholeDiceAttribute dice)
            : this()
        {
            MinValue = dice.Min;
            MaxValue = dice.Max;
            Volatility = (double)dice.Volatility;
        }

        WholeDice()
        {
            randomNumberGenerator = Create();
        }

        ///<summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name="buffer">An array of bytes to contain random numbers.</param>
        public override void GetBytes(byte[] buffer)
        {
            randomNumberGenerator.GetBytes(buffer);
        }

        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        private double _nextDouble()
        {
            var b = new byte[4];
            randomNumberGenerator.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        public double Shake()
        {
            var range = (long)(MaxValue - MinValue);

            return (int)((long)Math.Floor(_nextDouble() * range) + MinValue);
        }
    }
}
