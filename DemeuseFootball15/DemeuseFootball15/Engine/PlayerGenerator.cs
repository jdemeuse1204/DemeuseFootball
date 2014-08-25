using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

			player.PhysicalTraits = _generatePhysicalTraits(mod, player);
			player.Drive = _generateDrive(1);
			player.Athleticism = _generateAthleticism(player.PhysicalTraits, 1);
			player.Character = _generateCharacter(1);
			player.Talent = _generateTalent(1);

			player.Age = _rnd.Next(14, 16);

			return player;
		}

		private static int _getNextInt()
		{
			return _rnd.Next(1, 100);
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

		private static PlayerAthleticism _generateAthleticism(PlayerPhysicalTraits traits, int mod)
		{
			PlayerAthleticism athleticism = new PlayerAthleticism();
			athleticism.Acceleration = _getModHigh();
			athleticism.Agility = _getModHigh();
			athleticism.BlockShedding = _getModLow();
			athleticism.Carry = _getModLow();
			athleticism.Catching = _getModLow();
			athleticism.Elusiveness = _getModLow();
			athleticism.FinessMove = _getModLow();
			athleticism.HitPower = _getModLow();
			athleticism.Injury = _getModLow();
			athleticism.KickAccuracy = _getModLow();
			athleticism.KickPower = _getModLow();
			athleticism.ManCoverage = _getModLow();
			athleticism.PassBlock = _getModLow();
			athleticism.PlayAction = _getModLow();
			athleticism.PowerMove = _getModLow();
			athleticism.RunBlock = _getModLow();
			athleticism.RunPower = _getModLow();
			athleticism.Speed = _getModHigh();
			athleticism.Stamina = _getModLow();
			athleticism.Strength = _getModLow();
			athleticism.Tackling = _getModLow();
			athleticism.ThrowAccuracyDeep = _getModLow();
			athleticism.ThrowAccuracyMid = _getModLow();
			athleticism.ThrowAccuracyShort = _getModLow();
			athleticism.ThrowOnTheRun = _getModLow();
			athleticism.ThrowPower = _getModLow();
			athleticism.ZoneCoverage = _getModLow();

			return athleticism;
		}

		private static PlayerCharacter _generateCharacter(int mod)
		{
			PlayerCharacter character = new PlayerCharacter();
			character.Competitiveness = _getModHigh();
			character.Confidence = _getModLow();
			character.Disruptiveness = _getModLow();
			character.Diva = _getModLow();
			character.Humbleness = _getModHigh();
			character.Influence = _getModHigh();
			character.NegativeInfluenceBlock = _getModLow();
			character.ShowBoat = _getModLow();

			return character;
		}

		private static PlayerDrive _generateDrive(int mod)
		{
			PlayerDrive drive = new PlayerDrive();
			drive.PersonalGoals = _getModHigh();
			drive.TeamWork = _getModHigh();
			drive.WorkEthic = _getModHigh();

			return drive;
		}

		private static IEnumerable<PlayerGoal> _generateGoals(int mod)
		{
			return null;
		}

		private static IEnumerable<PlayerInfluence> _generateInfluences(int mod)
		{
			return null;
		}

		private static PlayerPhysicalTraits _generatePhysicalTraits(int mod, Player player)
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

		private static PlayerTalent _generateTalent(int mod)
		{
			PlayerTalent talent = new PlayerTalent();
			talent.Awareness = _getModHigh();
			talent.BaseKnowledge = _getModHigh();
			talent.Intangibles = _getModHigh();
			talent.LearningAbility = _getModHigh();
			talent.PlayBook = _getModHigh();
			talent.PlayReading = _getModHigh();
			talent.Release = _getModHigh();
			talent.RouteRunning = _getModHigh();
			talent.UnderPressure = _getModHigh();

			return talent;
		}

		private static bool _addSpecialModifier()
		{
			var mod = _getNextInt();

			for (int i = 1; i < SPECIAL_MOD_LOOP_COUNT; i++)
			{
				if (mod < SPECIAL_MOD_CONST)
				{
					return false;
				}
				mod = _getNextInt();
			}

			return true;
		}
	}
}
