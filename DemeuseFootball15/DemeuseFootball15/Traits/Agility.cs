using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Players;

namespace DemeuseFootball15.Traits
{
	public class Agility
	{
		public double OutOfShapeAdjustment { get { return _outOfShapeAdjustment; } }
		private double _outOfShapeAdjustment { get; set; }

		private Height _height { get; set; }
		private Weight _weight { get; set; }
		private double _value;
		private int _currentCount = 0;
		private int _maxCount = 5;

		// Per 5 lbs
		private double _penalty = 1;

		public double Value
		{
			get { return _value + OutOfShapeAdjustment; }
			set { _value = value; }
		}

		public Agility(Player player)
		{
			_height = player.PhysicalTraits.Height;
			_weight = player.PhysicalTraits.Weight;
		}

		public void Randomize(Random rnd, int age)
		{
			_getRandom(rnd, age);

			// Assess penalties if overweight
			if (_weight.Overweight > 0)
			{
				//outofshapemodifer=".2" penalty="1" inshapereward=".3"
				_outOfShapeAdjustment = _weight.Overweight * _penalty;
			}
		}

		protected virtual void _getRandom(Random rnd, int age)
		{
			// Factor in height and weight
			var max = 0;
			var threshhold = 0;

			if (age == 14)
			{
				max = 100;
				threshhold = 50;
			}
			else
			{
				max = 100;
				threshhold = 60;
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
