using System;
using System.Collections.Generic;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;
using DemeuseFootball15.Players.Attributes;
using DemeuseFootball15.Players.Parts;

namespace DemeuseFootball15.Players
{
	public abstract class Player
	{
        // when a player plants his foot and such.... change of tearing a muscle if not flexible, fatigue

        #region Appendages
        public Arm LeftArm { get; protected set; }

        public Arm RightArm { get; protected set; }

        public Leg LeftLeg { get; protected set; }

        public Leg RightLeg { get; protected set; }

	    public Neck Neck { get; protected set; }

        public Head Head { get; protected set; }

        public Torso Torso { get; protected set; }
        #endregion


        #region General
        public IEnumerable<PlayerGoal> Goals { get { return _goals; } }
		public IEnumerable<PlayerInfluence> HighSchoolInfluences { get; protected set; }
		public IEnumerable<PlayerInfluence> CollegiateInfluences { get; protected set; }
		public IEnumerable<PlayerInfluence> ProInfluences { get; protected set; }

		protected List<PlayerGoal> _goals { get; set; }
		protected List<PlayerInfluence> _highSchoolInfluences { get; set; }
		protected List<PlayerInfluence> _collegiateInfluences { get; set; }
		protected List<PlayerInfluence> _proInfluences { get; set; }

		public PostureStyle RunningStyle { get; protected set; }

		public ThrowStyle ThrowingStyle { get; protected set; }

		public IEnumerable<PositionType> DesiredPositionsTypes { get; protected set; }

		public PositionType CurrentPositionType { get; protected set; }

		public BodyType Body { get; protected set; }

        public BodyShapeType BodyShape { get; protected set; }

        public PlayerEvasionType EvasionType { get; protected set; }

        [DateDice(0)]
        public DateOfBirth DateOfBirth { get; protected set; }

		public int Age
		{
			get
			{
			    var value = (DateTime)DateOfBirth.Value;
			    var age = DateTime.Now.Year - value.Year;

			    if (DateTime.Now.Month < value.Month || (DateTime.Now.Month == value.Month && DateTime.Now.Day < value.Day))
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
        [DecimalDice(1, 50, 62, DiceVolatility._1)]
		public Height Height { get; protected set; } // inches

        [DecimalDice(2, 64, 130, DiceVolatility._2)]
        public Weight Weight { get; protected set; } // pounds

        public double ArmLength { get; protected set; }// inches

        public double Hand { get; protected set; } // inches

        public double Foot { get; protected set; } // inches

        public double GrowthLeft { get; protected set; } // inches

        public double Metabolism { get; protected set; }

        public double BoneDensity { get; protected set; }
		#endregion

		#region Athleticism
        //http://www.thestrengthandconditioningblog.com/2012/07/physical-characteristics-of-sprinters.html
		public double Speed { get; protected set; } // equate to MPH, what are the physical traits that make people a fast runner

        #region Physiology/Intangibles
        public double MuscleFibreTwitch { get; protected set; } // endowed with a dominance of the fast-twitch fibre and such

        // ligament strength
        // joint strength
        #endregion

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

        public double WearAndTear { get; protected set; }

        public double RecoveryTime { get; protected set; }

        public double ImmuneSystem { get; protected set; }

        public double MentalToughness { get; protected set; }

        public double Flexibility { get; protected set; }

        public double SelfProtection { get; protected set; } // how well does this person protect themselves from hits

        public double Fatigue { get; protected set; }

        public double ThrowingMechanics { get; protected set; }

        // TODO - diseases : major-minor (dormant)
        // TODO - pedirgee : family genes (can determine linemen and such)
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

        public double CollegiateFootballKnowledge { get; protected set; }

        public double ProfessionalFootballKnowledge { get; protected set; }

        public double Adaptation { get; protected set; } // can they adapt from youth to college to pros?
		#endregion

        #region Character
        public double Resilience { get; protected set; }

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

        public double Coachability { get; protected set; }

        // make stack like struct that has order 1-x of things responded to
        public CoachType ResposeToCoachTypes { get; protected set; }
		#endregion
	}
}
