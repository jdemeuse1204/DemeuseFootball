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
		#region General
		public IEnumerable<PlayerGoal> Goals { get { return _goals; } }
		public IEnumerable<PlayerInfluence> HighSchoolInfluences { get; protected set; }
		public IEnumerable<PlayerInfluence> CollegiateInfluences { get; protected set; }
		public IEnumerable<PlayerInfluence> ProInfluences { get; protected set; }
		protected List<PlayerGoal> _goals { get; set; }
		protected List<PlayerInfluence> _highSchoolInfluences { get; set; }
		protected List<PlayerInfluence> _collegiateInfluences { get; set; }
		protected List<PlayerInfluence> _proInfluences { get; set; }

		public RunStyle RunningStyle { get; protected set; }
		public ThrowStyle ThrowingStyle { get; protected set; }
		public IEnumerable<PositionType> DesiredPositionsTypes { get; protected set; }
		public PositionType CurrentPositionType { get; protected set; }
		public BodyType Body { get; protected set; }
		public DateTime DateOfBirth { get; protected set; }
		public int Age
		{
			get
			{
				int age = DateTime.Now.Year - DateOfBirth.Year;
				if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
				{
					age--;
				}
				return age;
			}
		}
		public string City { get; protected set; }
		public string State { get; protected set; }
		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }
		public int EducationLevel { get; protected set; }
		#endregion

		// Done
		#region Physical Traits
		public double Height { get; protected set; }
		public double Weight { get; protected set; }
		public double ArmLength { get; protected set; }
		public double Hand { get; protected set; }
		public double Foot { get; protected set; }
		public double GrowthLeft { get; protected set; }
		public double Metabolism { get; protected set; }
		#endregion

		#region Athleticism
		public double Speed { get; protected set; }
		public double Strength { get; protected set; }
		public double Acceleration { get; protected set; }
		public double Agility { get; protected set; }
		public double Injury { get; protected set; }
		public double Catching { get; protected set; }
		public double Carry { get; protected set; }
		public double ThrowPower { get; protected set; }
		public double ThrowAccuracyShort { get; protected set; }
		public double ThrowAccuracyMid { get; protected set; }
		public double ThrowAccuracyDeep { get; protected set; }
		public double ThrowOnTheRun { get; protected set; }
		public double PlayAction { get; protected set; }
		public double Elusiveness { get; protected set; }
		public double RunPower { get; protected set; }
		public double Stamina { get; protected set; }
		public double PassBlock { get; protected set; }
		public double RunBlock { get; protected set; }
		public double Tackling { get; protected set; }
		public double HitPower { get; protected set; }
		public double PowerMove { get; protected set; }
		public double FinessMove { get; protected set; }
		public double BlockShedding { get; protected set; }
		public double ManCoverage { get; protected set; }
		public double ZoneCoverage { get; protected set; }
		public double KickPower { get; protected set; }
		public double KickAccuracy { get; protected set; }
		public double Toughness { get; protected set; }
		public double Coordination { get; protected set; }
		public double Jumping { get; protected set; }
		#endregion

		// Done
		#region Drive 
		public double WorkEthic { get; protected set; }
		public double TeamWork { get; protected set; }
		public double PersonalGoals { get; protected set; }
		public double Motivation { get; protected set; }
		#endregion

		#region Talent 
		public double Awareness { get; protected set; }
		public double BaseKnowledge { get; protected set; }
		public double LearningAbility { get; protected set; }			// Higher is better for player progression
		public double Intangibles { get; protected set; }
		public double RouteRunning { get; protected set; }
		public double Release { get; protected set; }
		public double PlayBook { get; protected set; }
		public double PlayReading { get; protected set; }
		public double UnderPressure { get; protected set; }
		public double Technique { get; protected set; }					// Higher is better for player progression
		#endregion

		#region Character
		public double Confidence { get; protected set; }
		public double Diva { get; protected set; }
		public double ShowBoat { get; protected set; }
		public double Disruptiveness { get; protected set; }
		public double Influence { get; protected set; }
		public double Competitiveness { get; protected set; }
		public double Humbleness { get; protected set; }
		public double NegativeInfluenceBlock { get; protected set; }
		public double LoveForTheGame { get; protected set; }
		public double EatingHabits { get; protected set; }
		#endregion
	}
}
