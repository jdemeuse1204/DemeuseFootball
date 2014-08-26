﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemeuseFootball15.Traits
{
	public class Weight : RandomizeDependencyTrait
	{
		public override int Max { get { return _defaultMax; } }

		protected override int _maxPossibilityCount { get { return 3; } }

		protected override int _high { get { return Average + _defaultDelta; } }

		protected override int _low { get { return Average - _defaultDelta; } }

		public override int Average { get { return _defaultAverage; } }

		public override int Min { get { return _defaultMin; } }

		public double Overweight { get { return (Value - _defaultMax); } }

		public double DeltaFromAverage { get { return (Value - Average); } }

		private Height _height { get; set; }
		private int _defaultAverage { get; set; }
		private int _defaultDelta { get; set; }
		private int _defaultMax { get; set; }
		private int _defaultMin { get; set; }

		public void Randomize(Random rnd, Height height)
		{
			_height = height;
			_getGetDefaults();
			_getRandom(rnd, height);
		}

		private void _getGetDefaults()
		{
			XmlDocument doc = new XmlDocument();
			
			doc.Load(@"..\..\HeightWeightRatio.xml");

			XmlNodeList elemList = doc.GetElementsByTagName("ratio");
			for (int i = 0; i < elemList.Count; i++)
			{
				var item = elemList[i].Attributes;
				var avg = Convert.ToInt32(item["avg"].Value);
				var delta = Convert.ToInt32(item["delta"].Value);
				var height = Convert.ToInt32(item["value"].Value);
				_defaultMax = avg + delta;
				_defaultMin = avg - delta;

				if (height == _height.Value)
				{
					_defaultAverage = avg;
					_defaultDelta = delta;
					break;
				}
			}
		}
	}
}
