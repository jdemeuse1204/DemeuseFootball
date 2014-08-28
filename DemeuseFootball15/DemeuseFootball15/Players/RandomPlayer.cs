using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Players
{
	public class RandomPlayer : Player
	{
		private Random _rnd { get; set; }

		public RandomPlayer()
			: base()
		{
			_rnd = new Random();
			// Get Random player

			// All players start at 10-11 years old
			// Sources from 12-16 can grow up to 1 foot and gain 15-65 lbs
			// http://health.howstuffworks.com/sexual-health/male-reproductive-system/male-puberty3.htm

			// Height Weight info
			// http://www.disabled-world.com/artman/publish/height-weight-teens.shtml
			// Age		Weight		Height
			// 10		70.5		54.5	~4'6"
			// 11		78.5		56.5
			// 12		88			58.7
			// 13		100			61.5	~5'
			// 14		112			64.5
			// 15		123.5		67
			// 16		134			68.3
			// 17		142			69
			// 18		147.5		69.2
			// 19		152			69.5
			// 20		155			69.7

			// General
			// set bday

			// Physical Traits
			this.Height = _rnd.NextDouble(48, 64, 3, 3, 57, 50);

			// Get Weight based on age

			this.Weight = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.ArmLength = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.WingSpan = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.Hand = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.Foot = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.GrowthLeft = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
			this.Metabolism = _rnd.NextDouble(54, 81, 4, 2, 75, 60);
		}
	}

	static class Extension
	{
		public static double NextDouble(this Random random, int min, int max, int maxCount, int minCount, double maxThreshhold, double minThreshhold)
		{
			var result = Convert.ToDouble(random.Next(min, max));
			var minCounter = 0;
			var maxCounter = 0;
			var loopAgain = true;

			while (loopAgain)
			{
				result = Convert.ToDouble(random.Next(min, max));

				if (result < maxThreshhold && result > minThreshhold)
				{
					loopAgain = false;
				}
				else if (result <= minThreshhold)
				{
					minCounter++;
				}
				else if (result >= maxThreshhold)
				{
					maxCounter++;
				}

				if (maxCounter >= maxCount || minCounter >= minCount)
				{
					loopAgain = false;
				}
			}

			return result;
		}
	}
}
