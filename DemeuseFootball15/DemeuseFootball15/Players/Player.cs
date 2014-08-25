using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Players
{
	public class Player
	{
		public PlayerAthleticism Athleticism { get; set; }
		public PlayerPhysicalTraits PhysicalTraits { get; set; }
		public PlayerCharacter Character { get; set; }
		public PlayerDrive Drive { get; set; }
		public PlayerTalent Talent { get; set; }
		public IEnumerable<PlayerGoal> Goals { get; set; }
		public IEnumerable<PlayerInfluence> Influences { get; set; }
		public RunStyle RunningStyle { get; set; }
		public ThrowStyle ThrowingStyle { get; set; }

		public int Age { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int EducationLevel { get; set; }
	}
}
