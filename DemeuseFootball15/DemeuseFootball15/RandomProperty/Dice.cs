using System;
using System.Security.Cryptography;

namespace DemeuseFootball15.RandomProperty
{
    public class Dice : RandomNumberGenerator
    {
        public readonly int MinValue;

        public readonly int MaxValue;

        private static RandomNumberGenerator randomNumberGenerator;

        public Dice(int sides)
            : this()
        {
            MinValue = 1;
            MaxValue = ++sides;
        }

        public Dice(int min, int max)
            : this()
        {
            MinValue = min;
            MaxValue = ++max;
        }

        Dice()
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

        public int Shake()
        {
            var range = (long)(MaxValue - MinValue);

            return (int)((long)Math.Floor(_nextDouble() * range) + MinValue);
        }
    }
}
