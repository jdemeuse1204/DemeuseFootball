using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Players
{
	public class PlayerGoal
	{
		public int Priority { get; set; }

		public int AgeStarted { get; set; }

		public Goal Goal { get; set; }
	}
}
