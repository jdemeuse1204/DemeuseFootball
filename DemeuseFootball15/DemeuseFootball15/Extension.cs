using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15
{
	public static class Extension
	{
		public static double NextDouble(this Random random, int minValue, int maxValue, int numberOfTimesUnderMin, int numberOfTimesOverMax, double minThreshhold, double maxThreshhold)
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
				var num = Convert.ToDouble(random.Next(minValue, maxValue));

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
	}
}
