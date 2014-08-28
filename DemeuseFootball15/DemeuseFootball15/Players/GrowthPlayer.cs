using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Players
{
	/// <summary>
	/// Calculates stats based on player physical growth
	/// </summary>
	public class GrowthPlayer : Player
	{
		private Random _rnd { get; set; }

		public GrowthPlayer()
		{
			_rnd = new Random();

			this.Foot = _getFootSize(Height);
			this.Hand = _getHandSize(Height);
		}

		protected double _getFootSize(double height)
		{
			if (height < 66)
			{
				// < 5'6"
				return _rnd.NextDouble(7, 9, 6, 1, 7, 9);
			}
			else if (height > 66 && height <= 72)
			{
				// 5'6" - 6'
				return _rnd.NextDouble(8, 12, 2, 2, 8, 11);
			}
			else if (height > 72 && height <= 75)
			{
				//  6' - 6'3"
				return _rnd.NextDouble(11, 15, 2, 2, 11, 13);
			}
			else
			{
				return _rnd.NextDouble(14, 17, 2, 2, 14, 16);
			}
		}

		protected double _getHandSize(double height)
		{
			if (height < 66)
			{
				// < 5'6"
				return _rnd.NextDouble(4, 5, 5, 1, 4, 5);
			}
			else if (height > 66 && height <= 72)
			{
				// 5'6" - 6'
				return _rnd.NextDouble(5, 7, 5, 1, 5, 7);
			}
			else if (height > 72 && height <= 75)
			{
				//  6' - 6'3"
				return _rnd.NextDouble(8, 10, 5, 2, 8, 10);
			}
			else
			{
				return _rnd.NextDouble(9, 11, 5, 2, 9, 12);
			}
		}

		protected double _getArmLength(double height)
		{
			if (height < 66)
			{
				// < 5'6"
				return _rnd.NextDouble(26, 28, 5, 1, 26, 27);
			}
			else if (height > 66 && height <= 72)
			{
				// 5'6" - 6'
				return _rnd.NextDouble(29, 31, 5, 1, 29, 30);
			}
			else if (height > 72 && height <= 75)
			{
				//  6' - 6'3"
				return _rnd.NextDouble(32, 33, 5, 2, 32, 33);
			}
			else
			{
				return _rnd.NextDouble(33, 35, 5, 2, 33, 34);
			}
		}
	}
}
