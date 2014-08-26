using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DemeuseFootball15.Enumeration;
using DemeuseFootball15.Players;
using DemeuseFootball15.Traits;

namespace DemeuseFootball15.Engine
{
	public static class PlayerGenerator
	{
		private const int SPECIAL_MOD_CONST = 92;
		private const int SPECIAL_MOD_LOOP_COUNT = 4;

		private const int MOD_1_MIN = 10;
		private const int MOD_1_MAX = 90;
		private const int MOD_1_THRESHHOLD = 40;
		private const int MOD_1_MAX_LOOP_COUNT = 5;

		private const int MOD_2_MIN = 10;
		private const int MOD_2_MAX = 50;
		private const int MOD_2_THRESHHOLD = 40;
		private const int MOD_2_MAX_LOOP_COUNT = 4;

		private static Random _rnd { get; set; }

		public static Player Generate()
		{
			_rnd = new Random();
			var player = new Player();
			var mod = _getNextInt();
			var specialModSlot1 = _addSpecialModifier();
			var specialModSlot2 = _addSpecialModifier();

			player.Age = _rnd.Next(14, 15);

			// Strength is needed for running style
			Strength strength = new Strength();
			strength.Randomize(_rnd, player.Age);

			player.PhysicalTraits = _generatePhysicalTraits(player);
			player.Drive = _generateDrive(1);
			player.Character = _generateCharacter(1);
			player.Talent = _generateTalent(1);
			player.Athleticism = _generateAthleticism(player, strength, 1);

			// Goals

			// Influences

			// Body Type
			player.Body = _getBodyType(player);

			// Run Type
			player.RunningStyle = _getRunStyle(player, strength);

			// Throw Type

			// Player postions

			return player;
		}

		private static int _getNextInt()
		{
			return _rnd.Next(1, 100);
		}

		private static BodyType _getBodyType(Player player)
		{ 
			var over = player.PhysicalTraits.Weight.Overweight;

			if (over > 10)
			{
				return BodyType.OverWeight;
			}
			else if (over > 0)
			{
				var val = _rnd.Next(1, 8);

				while (val == 2 || val == 3)
				{
					val = _rnd.Next(1, 8);
				}

				return (BodyType)val;
			}
			else if (over < -10)
			{
				return BodyType.Scrawny;
			}
			else
			{
				return BodyType.Average;
			}
		}

		private static RunStyle _getRunStyle(Player player, Strength strength)
		{
			// Run power bonuses based on run style
			if (player.Body == BodyType.ExtraPounds ||
				player.Body == BodyType.OverWeight)
			{
				return RunStyle.Upright;
			}


			if (player.Body == BodyType.SemiMuscular || 
				player.Body == BodyType.VeryMuscular || 
				player.Body == BodyType.Muscular)
			{
				var val = _rnd.Next(1, 5);

				if (val != 2)
				{
					val = _rnd.Next(1, 5);
				}

				return (RunStyle)val;
			}
			else
			{
				return (RunStyle)_rnd.Next(1, 5);
			}
		}

		private static double _getModHigh()
		{
			var mod = _rnd.Next(MOD_1_MIN, MOD_1_MAX);

			for (int i = 1; i < MOD_1_MAX_LOOP_COUNT; i++)
			{
				if (mod >= MOD_1_THRESHHOLD)
				{
					mod = _rnd.Next(MOD_1_MIN, MOD_1_MAX);
				}
				else
				{
					return (double)mod;
				}
			}

			return (double)mod;
		}

		private static double _getModLow()
		{
			var mod = _rnd.Next(MOD_2_MIN, MOD_2_MAX);

			for (int i = 1; i < MOD_2_MAX_LOOP_COUNT; i++)
			{
				if (mod >= MOD_2_THRESHHOLD)
				{
					mod = _rnd.Next(MOD_2_MIN, MOD_2_MAX);
				}
				else
				{
					return (double)mod;
				}
			}

			return (double)mod;
		}

		private static PlayerAthleticism _generateAthleticism(Player player, Strength strength, double mod)
		{
			PlayerAthleticism athleticism = new PlayerAthleticism();
			athleticism.Strength = strength;								// Age

			Speed speed = new Speed(player, strength);
			speed.Randomize(_rnd, player.Age);
			athleticism.Speed = speed;										// Depends on Height/Weight Ratio, can be upped by strength

			Acceleration acceleration = new Acceleration(player, strength);
			acceleration.Randomize(_rnd, player.Age);
			athleticism.Acceleration = acceleration;						// Depends on Height/Weight Ratio, can be upped by strength

			Jumping jumping = new Jumping(player, strength);
			jumping.Randomize(_rnd, player.Age);
			athleticism.Jumping = jumping;									// Depends on Height/Weight Ratio, can be upped by Leg Strength

			Coordination coordination = new Coordination(player);
			coordination.Randomize(_rnd, player.Age);
			athleticism.Coordination = coordination;						// Height

			Agility agility = new Agility(player);
			agility.Randomize(_rnd, player.Age);
			athleticism.Agility = agility;									// Depends on Height/Weight Ratio

			athleticism.BlockShedding = _rnd.NextDouble(30, 70, 4, 60);		// Depends on Height/Weight Ratio/Strength
			athleticism.Carry = _rnd.NextDouble(10, 60, 4, 50);				// Depends on Height/Weight Ratio/Hand Size/Coordination
			athleticism.Catching = _rnd.NextDouble(10, 90, 6, 50);			// Hand Size/Coordination
			athleticism.Elusiveness = _rnd.NextDouble(10, 80, 4, 60);		// Depends on Height/Weight Ratio
			athleticism.FinessMove = _rnd.NextDouble(10, 80, 4, 60);		// Depends on Height/Weight Ratio/Arm Length
			athleticism.HitPower = _getModLow();							// Depends on Height/Weight Ratio
			athleticism.KickAccuracy = _getModLow();						// No dependence/Leg Strength/Coordination			
			athleticism.KickPower = _getModLow();							// No dependence/Leg Strength/Coordination
			athleticism.ManCoverage = _getModLow();							// No dependence/Coordination
			athleticism.PassBlock = _getModLow();							// Depends on Height/Weight Ratio
			athleticism.PowerMove = _getModLow();							// Depends on Height/Weight Ratio/Strength
			athleticism.RunBlock = _getModLow();							// Depends on Height/Weight Ratio
			athleticism.RunPower = _getModLow();							// Depends on Height/Weight Ratio
			athleticism.Stamina = _getModLow();								// Depends on Height/Weight Ratio
			athleticism.Tackling = _getModLow();							// No Dependence
			athleticism.ThrowAccuracyDeep = _getModLow();					// Strength/Coordination
			athleticism.ThrowAccuracyMid = _getModLow();					// Strength/Coordination
			athleticism.ThrowAccuracyShort = _getModLow();					// Strength/Coordination
			athleticism.ThrowOnTheRun = _getModLow();						// No Dependence/Coordination
			athleticism.ThrowPower = _getModLow();							// Arm Strength
			athleticism.ZoneCoverage = _getModLow();						// No Dependence/Coordination

			athleticism.Tackling = _rnd.NextDouble(10, 90, 4, 60); 			// No Dependence
			athleticism.PlayAction = _rnd.NextDouble(10, 70, 4, 60);		// No dependence
			athleticism.Injury = _rnd.NextDouble(70, 100, 0, 0);			// No dependence
			athleticism.Toughness = _rnd.NextDouble(35, 100, 3, 75);		// No dependence

			return athleticism;
		}

		private static PlayerCharacter _generateCharacter(double mod)
		{
			PlayerCharacter character = new PlayerCharacter();
			character.Competitiveness = _getModHigh() + mod; ;
			character.Confidence = _getModHigh() + mod; ;
			character.Disruptiveness = _getModLow() + mod; ;
			character.Diva = _getModLow() + mod; ;
			character.Humbleness = _getModHigh() + mod; ;
			character.Influence = _getModHigh() + mod; ;
			character.NegativeInfluenceBlock = _getModHigh();
			character.ShowBoat = _getModLow() + mod; ;

			return character;
		}

		private static PlayerDrive _generateDrive(double mod)
		{
			PlayerDrive drive = new PlayerDrive();
			drive.PersonalGoals = _getModHigh() + mod;
			drive.TeamWork = _getModHigh() + mod;
			drive.WorkEthic = _getModHigh() + mod;

			return drive;
		}

		private static IEnumerable<PlayerGoal> _generateGoals(double mod)
		{
			return null;
		}

		private static IEnumerable<PlayerInfluence> _generateInfluences(double mod)
		{
			return null;
		}

		private static PlayerPhysicalTraits _generatePhysicalTraits(Player player)
		{
			PlayerPhysicalTraits traits = new PlayerPhysicalTraits();

			Height height = new Height();
			height.Randomize(_rnd);
			traits.Height = height;

			Weight weight = new Weight();
			weight.Randomize(_rnd, height);
			traits.Weight = weight;

			ArmLength armLength = new ArmLength();
			armLength.Randomize(_rnd,height);
			traits.ArmLength = armLength;

			Foot foot = new Foot();
			foot.Randomize(_rnd, height);
			traits.Foot = foot;

			Hand hand = new Hand();
			hand.Randomize(_rnd, height);
			traits.Hand = hand;

			return traits;
		}

		private static PlayerTalent _generateTalent(double mod)
		{
			PlayerTalent talent = new PlayerTalent();
			talent.Awareness = _getModLow() + mod;
			talent.BaseKnowledge = _getModHigh() + mod;
			talent.Intangibles = _getModHigh() + mod;
			talent.LearningAbility = _getModHigh() + mod;
			talent.PlayBook = 0d;
			talent.PlayReading = _getModLow() + mod;
			talent.Release = _getModLow() + mod;
			talent.RouteRunning = _getModLow() + mod;
			talent.UnderPressure = _getModLow() + mod;

			return talent;
		}

		private static double _addSpecialModifier()
		{
			var mod = _getNextInt();

			for (int i = 1; i < SPECIAL_MOD_LOOP_COUNT; i++)
			{
				if (mod < SPECIAL_MOD_CONST)
				{
					return 0;
				}
				mod = _getNextInt();
			}

			return 6;
		}
	}

	static class Extension
	{
		public static double NextDouble(this Random random, int min, int max, int maxCount, double threshhold)
		{
			var result = Convert.ToDouble(random.Next(min, max));
			var counter = 0;

			while (result >= threshhold && counter < maxCount)
			{
				counter++;
				result = Convert.ToDouble(random.Next(min, max));
			}

			return result;
		}
	}
}
