using System;
using TestSimpleRNG;

namespace DemeuseFootball15
{
	public class Services
	{
        public static double NextDouble(double one, double two, double three, double four, double five, double six)
	    {
	        return 0d;
	    }

		public static double NextDouble(RndObject rnd)
		{
			var overCount = 0;
			var underCount = 0;
			var normalCount = 0;
			var overSum = 0d;
			var underSum = 0d;
			var normalSum = 0d;
			var count = 0;

			while (count < 10 && underCount < rnd.NumberOfTimesUnderMin && overCount < rnd.NumberOfTimesOverMax)
			{
				var num = Math.Round(SimpleRNG.GetNormal(rnd.Mean, rnd.StandardDeviation),2);

				if (num >= 100 || num <= 0 || num >= rnd.MaxThrowAwayValue || num <= rnd.MinThrowAwayValue)
				{
					continue;
				}

				count++;

				if (num >= rnd.MaxThreshhold)
				{
					overSum += num;
					overCount++;
				}
				else if (num <= rnd.MinThreshhold)
				{
					underSum += num;
					underCount++;
				}
				else
				{
					normalSum += num;
					normalCount++;
				}
			}

			if (underCount >= rnd.NumberOfTimesUnderMin)
			{
				return Math.Round(underSum / underCount, 2);
			}
			else if (overCount >= rnd.NumberOfTimesOverMax)
			{
				return Math.Round(overSum / overCount, 2);
			}
			else
			{
				return Math.Round(normalSum / normalCount, 2);
			}
		}

		public static int Next(int minValue, int maxValue)
		{
			Random rnd = new Random();
			return rnd.Next(minValue, maxValue);
		}

		public static double Next(double mean, double standardDeviation)
		{
			return Math.Round(SimpleRNG.GetNormal(mean, standardDeviation), 2);
		}
	}
}
