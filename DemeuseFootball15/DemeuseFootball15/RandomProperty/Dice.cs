using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.RandomProperty
{
    public abstract class Dice : RandomNumberGenerator, IDice
    {
        public double MinValue { get; private set; }

        public double MaxValue { get; private set; }

        public double Volatility { get; private set; }

        private static RandomNumberGenerator randomNumberGenerator;

        protected Dice(IDiceAttribute dice)
            : this()
        {
            MinValue = dice.Min;
            MaxValue = dice.Max;
            Volatility = (double)dice.Volatility;
        }

        protected Dice(double min, double max, Volatility volatility)
            : this()
        {
            MinValue = min;
            MaxValue = max;
            Volatility = (double)volatility;
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
            var bf = new BinaryFormatter();

            using (var ms = new MemoryStream())
            {
                var rnd = RandomDouble.Next(100, 1000, Enumeration.Volatility._0);
                bf.Serialize(ms, rnd);

                var b = ms.ToArray();
                randomNumberGenerator.GetBytes(b);
                return (double)BitConverter.ToUInt32(b, 0) / uint.MaxValue;
            }
        }

        public virtual double Shake()
        {
            var range = (MaxValue - MinValue);

            return (Math.Floor(_nextDouble() * range) + MinValue);
        }
    }
}
