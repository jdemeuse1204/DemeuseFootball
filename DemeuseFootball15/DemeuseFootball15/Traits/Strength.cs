using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Traits
{
	public class Strength
	{
		public double LegsStrength { get; set; }
		public double ArmsStrength { get; set; }
		public double CoreStrength { get; set; }

		public double LegsStrengthAverage { get; private set; }
		public double ArmsStrengthAverage { get; private set; }
		public double CoreStrengthAverage { get; private set; }

		private int _maxPossibilityCount_Legs = 5;
		private int _currentCount_Legs = 0;

		private int _maxPossibilityCount_Arms = 5;
		private int _currentCount_Arms = 0;

		private int _maxPossibilityCount_Core= 5;
		private int _currentCount_Core = 0;

		public void Randomize(Random rnd, int age)
		{
			_getRandomLegsStrength(rnd, age);
			_getRandomArmsStrength(rnd, age);
			_getRandomCoreStrength(rnd, age);
		}

		protected virtual void _getRandomLegsStrength(Random rnd, int age)
		{
			var max = 0;
			var threshhold = 0;
			LegsStrengthAverage = 37.5;

			if (age == 14)
			{
				max = 55;
				threshhold = 40;
			}
			else 
			{
				max = 65;
				threshhold = 50;
			}

			LegsStrength = rnd.Next(15, max);

			if ((LegsStrength >= threshhold) && _currentCount_Legs < _maxPossibilityCount_Legs)
			{
				_currentCount_Legs++;
				_getRandomLegsStrength(rnd, age);
			}
		}

		protected virtual void _getRandomArmsStrength(Random rnd, int age)
		{
			var max = 0;
			var threshhold = 0;
			ArmsStrengthAverage = 37.5;

			if (age == 14)
			{
				max = 50;
				threshhold = 45;
			}
			else 
			{
				max = 55;
				threshhold = 45;
			}

			ArmsStrength = rnd.Next(20, max);

			if ((ArmsStrength >= threshhold) && _currentCount_Arms < _maxPossibilityCount_Arms)
			{
				_currentCount_Arms++;
				_getRandomArmsStrength(rnd, age);
			}
		}

		protected virtual void _getRandomCoreStrength(Random rnd, int age)
		{
			var max = 0;
			var threshhold = 0;
			CoreStrengthAverage = 35;

			if (age == 14)
			{
				max = 45;
				threshhold = 35;
			}
			else
			{
				max = 50;
				threshhold = 35;
			}

			CoreStrength = rnd.Next(40, max);

			if ((CoreStrength >= threshhold) && _currentCount_Core < _maxPossibilityCount_Core)
			{
				_currentCount_Core++;
				_getRandomCoreStrength(rnd, age);
			}
		}
	}
}
