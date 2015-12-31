using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;
using DemeuseFootball15.Players.Attributes;
using DemeuseFootball15.Players.Parts;

namespace DemeuseFootball15.Players
{
	public abstract class Player
	{
        // when a player plants his foot and such.... chance of tearing a muscle if not flexible, fatigue

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

		public IEnumerable<PositionType> DesiredPositionsTypes { get; protected set; }

		public PositionType CurrentPositionType { get; protected set; }

        [WholeDice(100, 1, 8)]
        public BodyType Body { get; protected set; }

        [WholeDice(101, 1, 3)]
        public BodyShapeType BodyShape { get; protected set; }

        [WholeDice(102, 1, 4)]
        public PlayerEvasionType EvasionType { get; protected set; }

        [DateDice(0)]
        public DateOfBirth DateOfBirth { get; protected set; }

        [WholeDice(103, 1, 5)]
        public PostureStyle RunningStyle { get; protected set; }

        [WholeDice(104, 1, 4)]
        public ThrowStyle ThrowingStyle { get; protected set; }

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

		#region Physical Traits
        [DecimalDice(1, 50, 62, DiceVolatility._1)]
		public Height Height { get; protected set; } // inches

        [DecimalDice(2, 64, 130, DiceVolatility._0)]
        public Weight Weight { get; protected set; } // pounds

        [ProportionalityDice(3, typeof(Height))]
        public WingSpan WingSpan { get; protected set; }// inches

        [ProportionalityDice(4, typeof(Height))]
        public Hand Hand { get; protected set; } // inches

        [DecimalDice(5, 35, 100, DiceVolatility._0)]
        public Metabolism Metabolism { get; protected set; }

        [ProportionalityDice(6, typeof(Height))]
        public Foot Foot { get; protected set; } // inches

        [DecimalDice(7, 10, 30, DiceVolatility._1)]
        public GrowthLeft GrowthLeft { get; protected set; } // inches..... growth -- percentage more to grow

        [DecimalDice(17, 85, 100, DiceVolatility._0)]
        public BoneDensity BoneDensity { get; protected set; }
        #endregion

        #region Athleticism
        [DecimalDice(10, 30, 60, DiceVolatility._0)]
        public Speed Speed { get; protected set; } // equate to MPH, what are the physical traits that make people a fast runner

        #region Physiology/Intangibles

        [DecimalDice(9, 30, 100, DiceVolatility._0)]
        public MuscleFibreTwitch MuscleFibreTwitch { get; protected set; } // endowed with a dominance of the fast-twitch fibre and such

        // ligament strength
        // joint strength
        #endregion

        [DecimalDice(9, 15, 46, DiceVolatility._0)]
        public ArmStrength ArmStrength { get; protected set; }

        [DecimalDice(8, 35, 50, DiceVolatility._0)]
        public LegStrength LegStrength { get; protected set; }

        [DecimalDice(16, 30, 50, DiceVolatility._0)]
        public Acceleration Acceleration { get; protected set; }

        [DecimalDice(18, 30, 70, DiceVolatility._0)]
        public Agility Agility { get; protected set; }

        [DecimalDice(24, 40, 75, DiceVolatility._0)]
        public Injury Injury { get; protected set; }

        [DecimalDice(20, 40, 75, DiceVolatility._0)]
        public Catching Catching { get; protected set; }

        [DecimalDice(25, 40, 75, DiceVolatility._0)]
        public Carry Carry { get; protected set; }

        [DecimalDice(26, DiceVolatility._0)]
        public ThrowPower ThrowPower { get; protected set; }

        [DecimalDice(27, DiceVolatility._0)]
        public ThrowAccuracyShort ThrowAccuracyShort { get; protected set; }

        [DecimalDice(28, DiceVolatility._0)]
        public ThrowAccuracyMid ThrowAccuracyMid { get; protected set; }

        [DecimalDice(29, DiceVolatility._0)]
        public ThrowAccuracyDeep ThrowAccuracyDeep { get; protected set; }

        [DecimalDice(30, DiceVolatility._0)]
        public ThrowOnTheRun ThrowOnTheRun { get; protected set; }

        [DecimalDice(31, DiceVolatility._0)]
        public PlayAction PlayAction { get; protected set; }

        [DecimalDice(32, DiceVolatility._0)]
        public Elusiveness Elusiveness { get; protected set; }

        public RunPower RunPower { get; protected set; }

        public Stamina Stamina { get; protected set; }

        public PassBlock PassBlock { get; protected set; }

        public RunBlock RunBlock { get; protected set; }

        public Tackling Tackling { get; protected set; }

        public HitPower HitPower { get; protected set; }

        public PowerMove PowerMove { get; protected set; }

        public FinessMove FinessMove { get; protected set; }

        public BlockShedding BlockShedding { get; protected set; }

        public ManCoverage ManCoverage { get; protected set; }

        public ZoneCoverage ZoneCoverage { get; protected set; }

        public KickPower KickPower { get; protected set; }

        public KickAccuracy KickAccuracy { get; protected set; }

        public Toughness Toughness { get; protected set; }

        [DecimalDice(8, 30, 85, DiceVolatility._2)]
        public Coordination Coordination { get; protected set; }

		public double Jumping { get; protected set; }

        [DecimalDice(23, 0, 40, DiceVolatility._10)]
        public WearAndTear WearAndTear { get; protected set; }

        [DecimalDice(22, 90, 100, DiceVolatility._0)]
        public RecoveryTime RecoveryTime { get; protected set; }

        [DecimalDice(22, 90, 100, DiceVolatility._0)]
        public ImmuneSystem ImmuneSystem { get; protected set; }

        [DecimalDice(19, 30, 100, DiceVolatility._1)]
        public MentalToughness MentalToughness { get; protected set; }

        [DecimalDice(9, 30, 50, DiceVolatility._1)]
        public Flexibility Flexibility { get; protected set; }

        public SelfProtection SelfProtection { get; protected set; } // how well does this person protect themselves from hits

        public Fatigue Fatigue { get; protected set; }

        [DecimalDice(9, DiceVolatility._1)]
        public ThrowingMechanics ThrowingMechanics { get; protected set; }

        // TODO - diseases : major-minor (dormant)
        // TODO - pedirgee : family genes (can determine linemen and such)
        #endregion

        #region Drive 
        [DecimalDice(34, 33, 100, DiceVolatility._7)]
        public double DriveBaseline { get; protected set; }

        [DecimalDice(35)]
        public WorkEthic WorkEthic { get; protected set; }

        [DecimalDice(36)]
        public TeamWork TeamWork { get; protected set; }

        [DecimalDice(37)]
        public PersonalGoals PersonalGoals { get; protected set; }

        [DecimalDice(38)]
        public Motivation Motivation { get; protected set; }
        #endregion

        #region Talent
        [DecimalDice(39, 30,50, DiceVolatility._8)]
        public Awareness Awareness { get; protected set; }

        [DecimalDice(40, 30, 100, DiceVolatility._7)]
        public BaseKnowledge BaseKnowledge { get; protected set; }

        [DecimalDice(41, 30, 100, DiceVolatility._7)]
        public LearningAbility LearningAbility { get; protected set; }          // Higher is better for player progression

        // intangibles based on stuff that doesnt change... muscle twitch, hand size, wing span, height

        [DecimalDice(42, 20, 40, DiceVolatility._7)]
        public RouteRunning RouteRunning { get; protected set; }

        [DecimalDice(43)]
        public Release Release { get; protected set; }

        public PlayBook PlayBook { get; protected set; }

        public PlayReading PlayReading { get; protected set; }

        public UnderPressure UnderPressure { get; protected set; }

        [DecimalDice(0, 30, 50, DiceVolatility._1)]
        public Technique Technique { get; protected set; }					// Higher is better for player progression

        public CollegiateFootballKnowledge CollegiateFootballKnowledge { get; protected set; }

        public ProfessionalFootballKnowledge ProfessionalFootballKnowledge { get; protected set; }

        public Adaptation Adaptation { get; protected set; } // can they adapt from youth to college to pros?
        #endregion

        #region Character
        [DecimalDice(43, 40, 100, DiceVolatility._0)]
        public double CharacterBaseline { get; protected set; }

        public Resilience Resilience { get; protected set; }

        public Confidence Confidence { get; protected set; }

        public Diva Diva { get; protected set; }

        public ShowBoat ShowBoat { get; protected set; }

        public Disruptiveness Disruptiveness { get; protected set; }

        public double Influence { get; protected set; }

        public double BodyBalance { get; protected set; } // running and breaking tackles

        public Competitiveness Competitiveness { get; protected set; }

        public Humbleness Humbleness { get; protected set; }

        public NegativeInfluenceBlock NegativeInfluenceBlock { get; protected set; }

        public LoveForTheGame LoveForTheGame { get; protected set; }

		public EatingHabits EatingHabits { get; protected set; }

        public Coachability Coachability { get; protected set; }

        // make stack like struct that has order 1-x of things responded to
        public CoachType ResposeToCoachTypes { get; protected set; }

        public double Potential { get; protected set; }

	    public double GetPotential()
	    {
	        var properties =
	            GetType()
	                .GetProperties()
	                .Where(
	                    w =>
	                        w.GetCustomAttribute<DiceAttribute>() != null &&
	                        w.PropertyType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
	                            .Any(x => x.GetCustomAttribute<PotentialPropertyAttribute>() != null)).ToList();

	        return (from property in properties
	            let propertyValue = property.GetValue(this)
	            select
	                property.PropertyType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
	                    .Where(w => w.GetCustomAttribute<PotentialPropertyAttribute>() != null)
	                    .Sum(item => (double) item.GetValue(propertyValue))).Sum();
	    }
        #endregion
    }
}
