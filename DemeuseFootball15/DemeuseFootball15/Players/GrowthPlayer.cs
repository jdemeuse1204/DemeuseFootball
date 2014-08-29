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
		public GrowthPlayer()
		{
			this.Foot = _getFootSize();
			this.Hand = _getHandSize();
			this.ArmLength = _getArmLength();
		}

		public GrowthPlayer(Player player)
		{
			this.Height = player.Height;
			this.Foot = _getFootSize();
			this.Hand = _getHandSize();
			this.ArmLength = _getArmLength();
		}

		protected double _getFootSize()
		{
			if (this.Height < 66)
			{
				// < 5'6"
				return Services.NextDouble(7, 2, 6, 1, 7, 9);
			}
			else if (this.Height > 66 && this.Height <= 72)
			{
				// 5'6" - 6'
				return Services.NextDouble(8, 4, 2, 2, 8, 11);
			}
			else if (this.Height > 72 && this.Height <= 75)
			{
				//  6' - 6'3"
				return Services.NextDouble(11, 4, 2, 2, 11, 13);
			}
			else
			{
				return Services.NextDouble(14, 3, 2, 2, 14, 16);
			}
		}

		protected double _getHandSize()
		{
			if (this.Height < 66)
			{
				// < 5'6"
				return Services.NextDouble(5, 1, 5, 1, 4, 5);
			}
			else if (this.Height > 66 && this.Height <= 72)
			{
				// 5'6" - 6'
				return Services.NextDouble(5,1, 5, 1, 5, 7);
			}
			else if (this.Height > 72 && this.Height <= 75)
			{
				//  6' - 6'3"
				return Services.NextDouble(7, 2, 5, 2, 7, 9);
			}
			else
			{
				return Services.NextDouble(9, 2, 5, 2, 8, 10);
			}
		}

		protected double _getArmLength()
		{
			if (this.Height < 66)
			{
				// < 5'6"
				return Services.NextDouble(26, 2, 5, 1, 26, 27);
			}
			else if (this.Height > 66 && this.Height <= 72)
			{
				// 5'6" - 6'
				return Services.NextDouble(29, 2, 5, 1, 28, 30);
			}
			else if (this.Height > 72 && this.Height <= 75)
			{
				//  6' - 6'3"
				return Services.NextDouble(32, 1, 5, 2, 31, 33);
			}
			else
			{
				return Services.NextDouble(33, 2, 5, 2, 31, 34);
			}
		}
	}
}
