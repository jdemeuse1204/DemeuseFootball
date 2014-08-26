using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DemeuseFootball15.Enumeration;
using DemeuseFootball15.Players;

namespace DemeuseFootball15.Traits
{
	public class Speed
	{
		public double LegStrengthAdjustment { get { return _legStrengthAdjustment; } }
		private double _legStrengthAdjustment { get; set; }
		public double InShapeAdjustment { get { return _inShapeAdjustment; } }
		private double _inShapeAdjustment { get; set; }
		public double OutOfShapeAdjustment { get { return _outOfShapeAdjustment; } }
		private double _outOfShapeAdjustment { get; set; }

		private Strength _strength { get; set; }
		private Height _height { get; set; }
		private Weight _weight { get; set; }
		private BodyType _bodyType { get; set; }
		private RunStyle _runStyle { get; set; }
		private double _value;
		private int _currentCount = 0;
		private int _maxCount = 3;

		// Per 5 lbs
		private double _inShapeReward { get; set; }
		private double _outOfShapeModifier { get; set; }
		private double _penalty { get; set; }

		public double Value
		{
			get { return _value + LegStrengthAdjustment + InShapeAdjustment + OutOfShapeAdjustment; }
			set { _value = value; }
		}

		public Speed(Player player, Strength strength)
		{
			_strength = strength;
			_height = player.PhysicalTraits.Height;
			_weight = player.PhysicalTraits.Weight;
			_bodyType = player.Body;
		}

		public void Randomize(Random rnd, int age)
		{
			_setOverUnderWeightPenalties();
			_getRandom(rnd, age);

			// Assess penalties if overweight
			if (_weight.Overweight > 0)
			{
				//outofshapemodifer=".2" penalty="1" inshapereward=".3"
				_outOfShapeAdjustment = _outOfShapeModifier * _weight.Overweight * _penalty;
			}

			var legStrengthDelta = _strength.LegsStrength - _strength.LegsStrengthAverage;
			if (legStrengthDelta > 0)
			{
				_legStrengthAdjustment = legStrengthDelta * .1d;
			}
		}

		private void _setOverUnderWeightPenalties()
		{
			XmlDocument doc = new XmlDocument();

			doc.Load(@"..\..\HeightWeightSpeedRatio.xml");

			XmlNodeList elemList = doc.GetElementsByTagName("ratio");
			for (int i = 0; i < elemList.Count; i++)
			{
				var item = elemList[i].Attributes;
				var height = Convert.ToDouble(item["value"].Value);

				if (height == _height.Value)
				{
					_inShapeReward = Convert.ToDouble(item["inshapereward"].Value);
					_outOfShapeModifier = Convert.ToDouble(item["outofshapemodifer"].Value);
					_penalty = Convert.ToDouble(item["penalty"].Value);
					break;
				}
			}
		}

		protected virtual void _getRandom(Random rnd, int age)
		{
			var mod = _weight.Overweight / 10;

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
				max = 80;
				threshhold = 50;
			}

			_value = rnd.Next((int)(40 + mod), max);

			if ((_value >= threshhold) && _currentCount < _maxCount)
			{
				_currentCount++;
				_getRandom(rnd, age);
			}
		}
	}
}
