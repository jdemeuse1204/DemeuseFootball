using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Players;

namespace DemeuseFootball15.Traits
{
	public class Coordination
	{
		public double LegStrengthAdjustment { get { return _legStrengthAdjustment; } }
		private double _legStrengthAdjustment { get; set; }
		public double OverweightAdjustment { get { return _overweightAdjustment; } }
		private double _overweightAdjustment { get; set; }

		private Height _height { get; set; }
		private Weight _weight { get; set; }
		private double _value;
		private int _currentCount = 0;
		private int _maxCount = 3;

		public double Value
		{
			get { return _value + LegStrengthAdjustment + OverweightAdjustment; }
			set { _value = value; }
		}

		public Coordination(Player player)
		{
			_height = player.PhysicalTraits.Height;
			_weight = player.PhysicalTraits.Weight;
		}

		public void Randomize(Random rnd, int age)
		{
			// adjust based on height

			if (_height.Value >= 78)
			{
				_maxCount = 8;
			}

			_getRandom(rnd, age);
		}

		protected virtual void _getRandom(Random rnd, int age)
		{
			// Factor in height and weight
			var max = 0;
			var threshhold = 0;

			if (age == 14)
			{
				max = 95;
				threshhold = 75;
			}
			else
			{
				max = 100;
				threshhold = 80;
			}

			_value = rnd.Next(10, max);

			if ((_value >= threshhold) && _currentCount < _maxCount)
			{
				_currentCount++;
				_getRandom(rnd, age);
			}
		}
	}
}
