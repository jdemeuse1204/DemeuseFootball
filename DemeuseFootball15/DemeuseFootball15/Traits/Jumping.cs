using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Players;

namespace DemeuseFootball15.Traits
{
	public class Jumping
	{
		public double LegStrengthAdjustment { get { return _legStrengthAdjustment; } }
		private double _legStrengthAdjustment { get; set; }
		public double OverweightAdjustment { get { return _overweightAdjustment; } }
		private double _overweightAdjustment { get; set; }

		private Strength _strength { get; set; }
		private Weight _weight { get; set; }
		private double _value;
		private int _currentCount = 0;
		private int _maxCount = 5;

		public double Value
		{
			get { return _value + LegStrengthAdjustment + OverweightAdjustment; }
			set { _value = value; }
		}

		public Jumping(Player player, Strength strength)
		{
			_strength = strength;
			_weight = player.PhysicalTraits.Weight;
		}

		public void Randomize(Random rnd, int age)
		{
			_getRandom(rnd, age);
			var adjustment = .8d;

			// Assess penalties if overweight
			if (_weight.Overweight > 0)
			{
				_overweightAdjustment =  _weight.Overweight * 1d;
				adjustment = .1d;
			}

			var legStrengthDelta = _strength.LegsStrength - _strength.LegsStrengthAverage;
			if (legStrengthDelta > 0)
			{
				_legStrengthAdjustment = legStrengthDelta * adjustment;
			}
		}

		protected virtual void _getRandom(Random rnd, int age)
		{
			// Factor in height and weight
			var max = 0;
			var threshhold = 0;

			if (age == 14)
			{
				max = 65;
				threshhold = 40;
			}
			else
			{
				max = 75;
				threshhold = 50;
			}

			_value = rnd.Next(15, max);

			if ((_value >= threshhold) && _currentCount < _maxCount)
			{
				_currentCount++;
				_getRandom(rnd, age);
			}
		}
	}
}
