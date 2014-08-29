using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSimpleRNG;

namespace DemeuseFootball15
{
	public class Services
	{
		public static double NextDouble(double mean, double standardDeviation, int numberOfTimesUnderMin, int numberOfTimesOverMax, double minThreshhold, double maxThreshhold)
		{
			var overCount = 0;
			var underCount = 0;
			var normalCount = 0;
			var overSum = 0d;
			var underSum = 0d;
			var normalSum = 0d;
			var count = 0;

			while (count < 10 && underCount < numberOfTimesUnderMin && overCount < numberOfTimesOverMax)
			{
				count++;
				var num = Math.Round(SimpleRNG.GetNormal(mean, standardDeviation),2);

				if (num >= maxThreshhold)
				{
					overSum += num;
					overCount++;
				}
				else if (num <= minThreshhold)
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

			if (underCount >= numberOfTimesUnderMin)
			{
				return Math.Round(underSum / underCount, 2);
			}
			else if (overCount >= numberOfTimesOverMax)
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
