﻿using System;
using System.Collections.Generic;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;
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

        [Dice(3)]
        public BodyShapeType BodyShape { get; protected set; }

        [Dice(4)]
        public PlayerEvasionType EvasionType { get; protected set; }

		public DateTime DateOfBirth { get; protected set; }
		public int Age
		{
			get
			{
				var age = DateTime.Now.Year - DateOfBirth.Year;
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
        [Dice(20, 70)]
		public double Height { get; protected set; } // inches

        [Dice(20, 70)]
        public double Weight { get; protected set; } // pounds

        [Dice(20, 70)]
        public double ArmLength { get; protected set; }// inches

        [Dice(20, 70)]
        public double Hand { get; protected set; } // inches

        [Dice(20, 70)]
        public double Foot { get; protected set; } // inches

        [Dice(20, 70)]
        public double GrowthLeft { get; protected set; } // inches

        [Dice(20, 70)]
        public double Metabolism { get; protected set; }

        public double BoneDensity { get; protected set; }
		#endregion

		#region Athleticism
        //http://www.thestrengthandconditioningblog.com/2012/07/physical-characteristics-of-sprinters.html
        [Dice(20, 70)]
		public double Speed { get; protected set; } // equate to MPH, what are the physical traits that make people a fast runner

        #region Physiology/Intangibles
        public double MuscleFibreTwitch { get; protected set; } // endowed with a dominance of the fast-twitch fibre and such

        // ligament strength
        // joint strength
        #endregion

        [Dice(20, 70)]
		public double Strength { get; protected set; }

        [Dice(20, 70)]
		public double Acceleration { get; protected set; }

        [Dice(20, 70)]
		public double Agility { get; protected set; }

        [Dice(20, 70)]
		public double Injury { get; protected set; }

        [Dice(20, 70)]
        public double Catching { get; protected set; }

        [Dice(20, 70)]
        public double Carry { get; protected set; }

        [Dice(20, 70)]
        public double ThrowPower { get; protected set; }

        [Dice(20, 70)]
        public double ThrowAccuracyShort { get; protected set; }

        [Dice(20, 70)]
        public double ThrowAccuracyMid { get; protected set; }

        [Dice(20, 70)]
        public double ThrowAccuracyDeep { get; protected set; }

        [Dice(20, 70)]
        public double ThrowOnTheRun { get; protected set; }

        [Dice(20, 70)]
        public double PlayAction { get; protected set; }

        [Dice(20, 70)]
        public double Elusiveness { get; protected set; }

        [Dice(20, 70)]
        public double RunPower { get; protected set; }

        [Dice(20, 70)]
        public double Stamina { get; protected set; }

        [Dice(20, 70)]
        public double PassBlock { get; protected set; }

        [Dice(20, 70)]
        public double RunBlock { get; protected set; }

        [Dice(20, 70)]
        public double Tackling { get; protected set; }

        [Dice(20, 70)]
        public double HitPower { get; protected set; }

        [Dice(20, 70)]
        public double PowerMove { get; protected set; }

        [Dice(20, 70)]
        public double FinessMove { get; protected set; }

        [Dice(20, 70)]
        public double BlockShedding { get; protected set; }

        [Dice(20, 70)]
        public double ManCoverage { get; protected set; }

        [Dice(20, 70)]
        public double ZoneCoverage { get; protected set; }

        [Dice(20, 70)]
        public double KickPower { get; protected set; }

        [Dice(20, 70)]
        public double KickAccuracy { get; protected set; }

        [Dice(20, 70)]
        public double Toughness { get; protected set; }

        [Dice(20, 70)]
        public double Coordination { get; protected set; }

        [Dice(20, 70)]
		public double Jumping { get; protected set; }

        [Dice(20, 70)]
        public double WearAndTear { get; protected set; }

        [Dice(20, 70)]
        public double RecoveryTime { get; protected set; }

        [Dice(20, 70)]
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
        [Dice(20, 70)]
		public double WorkEthic { get; protected set; }

        [Dice(20, 70)]
        public double TeamWork { get; protected set; }

        [Dice(20, 70)]
        public double PersonalGoals { get; protected set; }

        [Dice(20, 70)]
		public double Motivation { get; protected set; }
		#endregion

        #region Talent
        [Dice(20, 70)]
        public double Awareness { get; protected set; }

        [Dice(20, 70)]
        public double BaseKnowledge { get; protected set; }

        [Dice(20, 70)]
        public double LearningAbility { get; protected set; }			// Higher is better for player progression

        [Dice(20, 70)]
        public double Intangibles { get; protected set; }

        [Dice(20, 70)]
        public double RouteRunning { get; protected set; }

        [Dice(20, 70)]
        public double Release { get; protected set; }

        [Dice(20, 70)]
        public double PlayBook { get; protected set; }

        [Dice(20, 70)]
        public double PlayReading { get; protected set; }

        [Dice(20, 70)]
        public double UnderPressure { get; protected set; }

        [Dice(20, 70)]
        public double Technique { get; protected set; }					// Higher is better for player progression

        [Dice(20, 70)]
        public double CollegiateFootballKnowledge { get; protected set; }

        [Dice(20, 70)]
        public double ProfessionalFootballKnowledge { get; protected set; }

        [Dice(20, 70)]
        public double Adaptation { get; protected set; } // can they adapt from youth to college to pros?
		#endregion

        #region Character
        [Dice(20, 70)]
        public double Resilience { get; protected set; }

        [Dice(20, 70)]
        public double Confidence { get; protected set; }

        [Dice(20, 70)]
        public double Diva { get; protected set; }

        [Dice(20, 70)]
        public double ShowBoat { get; protected set; }

        [Dice(20, 70)]
        public double Disruptiveness { get; protected set; }

        [Dice(20, 70)]
        public double Influence { get; protected set; }

        [Dice(20, 70)]
        public double Competitiveness { get; protected set; }

        [Dice(20, 70)]
        public double Humbleness { get; protected set; }

        [Dice(20, 70)]
        public double NegativeInfluenceBlock { get; protected set; }

        [Dice(20, 70)]
        public double LoveForTheGame { get; protected set; }

        [Dice(20, 70)]
		public double EatingHabits { get; protected set; }

        [Dice(20, 70)]
        public double Coachable { get; protected set; }

        // make stack like struct that has order 1-x of things responded to
        public CoachType ResposeToCoachTypes { get; protected set; }
		#endregion
	}
}
