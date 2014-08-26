using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Players
{
	public class PlayerTalent
	{
		public double Awareness { get; set; }
		public double BaseKnowledge { get; set; }
		public double LearningAbility { get; set; }			// Higher is better for player progression
		public double Intangibles { get; set; }
		public double RouteRunning { get; set; }
		public double Release { get; set; }
		public double PlayBook { get; set; }
		public double PlayReading { get; set; }
		public double UnderPressure { get; set; }
		public double Technique { get; set; }				// Higher is better for player progression
	}
}
