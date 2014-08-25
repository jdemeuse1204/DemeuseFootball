using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Traits;

namespace DemeuseFootball15.Players
{
	public class PlayerPhysicalTraits
	{
		public Height Height { get; set; }
		public Weight Weight { get; set; }
		public ArmLength ArmLength { get; set; }
		public double WingSpan { get; set; }
		public Hand Hand { get; set; }
		public Foot Foot { get; set; }
		public double GrowthLeft { get; set; }
	}
}
