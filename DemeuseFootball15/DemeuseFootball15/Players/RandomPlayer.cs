using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Players
{
	public class RandomPlayer : GrowthPlayer
	{
		private Random _rnd { get; set; }
		/// <summary>
		/// Randomizes player stats
		/// </summary>
		public RandomPlayer()
			: base()
		{
			_rnd = new Random();
			// Get Random player

			// All players start at 10-11 years old
			// Sources from 12-16 can grow up to 1 foot and gain 15-65 lbs
			// http://health.howstuffworks.com/sexual-health/male-reproductive-system/male-puberty3.htm

			// Height Weight info
			// http://www.disabled-world.com/artman/publish/height-weight-teens.shtml
			// Age		Weight		Height
			// 10		70.5		54.5	~4'6"
			// 11		78.5		56.5
			// 12		88			58.7
			// 13		100			61.5	~5'
			// 14		112			64.5
			// 15		123.5		67
			// 16		134			68.3
			// 17		142			69
			// 18		147.5		69.2
			// 19		152			69.5
			// 20		155			69.7

			// General
			// Age
			var age = _rnd.Next(10, 12);

			while (age >= 12)
			{
				age = _rnd.Next(10, 12);
			}

			// Date of Birth
			var yearDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day).AddYears(-1);
			var days = DateTime.IsLeapYear(yearDate.Year + 1) ? 365 : 364;
			var findBday = _rnd.Next(0, days);
			DateTime min = yearDate;
			DateTime max = yearDate.AddDays(days);

			this.DateOfBirth = yearDate.AddDays(findBday);

			// Physical Traits
			if (this.Age == 10)
			{
				this.Height = _rnd.NextDouble(45, 64, 3, 6, 57, 50);
				this.Weight = _rnd.NextDouble(62, 100, 6, 6, 65, 80);
			}
			else
			{
				this.Height = _rnd.NextDouble(47, 66, 6, 4, 59, 52);
				this.Weight = _rnd.NextDouble(70, 108, 6, 6, 73, 88);
			}

			this.Metabolism = _rnd.NextDouble(30, 100, 4, 2, 75, 60);

			// As player grows physically these stats will get bigger
			this.GrowthLeft = _getGrowthLeft(Height);
			this.Foot = _getFootSize(Height);
			this.Hand = _getHandSize(Height);
			this.ArmLength = _getArmLength(Height);
			this.Body = BodyType.Average;
			this.RunningStyle = RunStyle.Natural;

			// Player Drive
			this.Motivation = _rnd.NextDouble(30, 100, 4, 4, 40, 60);
			this.PersonalGoals = _rnd.NextDouble(30, 100, 4, 4, 40, 60);

			var goalsToSkip = new List<Goal>();
			var totalGoals = _getExtraTotalGoalsFromMotivation(Motivation, out goalsToSkip);			

			if (this.PersonalGoals < 40)
			{
				totalGoals += 1;

				// Skip these goals
				goalsToSkip.Add(Goal.BecomeALegend);
				goalsToSkip.Add(Goal.BestAtPositionInHistory);
				goalsToSkip.Add(Goal.WinMostSuperBowlsInHistory);
			}
			else if (this.PersonalGoals > 40 && this.PersonalGoals <= 60)
			{
				totalGoals += 2;
			}
			else if (this.PersonalGoals > 60 && this.PersonalGoals <= 80)
			{
				totalGoals += 3;

				// Skip these goals
				goalsToSkip.Add(Goal.CouchPotato);
				goalsToSkip.Add(Goal.JustGetBy);
			}
			else if (this.PersonalGoals > 80 && this.PersonalGoals <= 100)
			{
				totalGoals += _rnd.Next(4, 6);

				// Skip these goals
				goalsToSkip.Add(Goal.CouchPotato);
				goalsToSkip.Add(Goal.JustGetBy);
				goalsToSkip.Add(Goal.AveragePlayer);
			}

			// Goals - Based on Drive
			this._goals = _getGoals(totalGoals, goalsToSkip);

			// Team Work
			this.TeamWork = _rnd.NextDouble(30, 100, 4, 4, 40, 60);

			// Work Ethic
			if (this.Motivation < 40)
			{
				this.WorkEthic = _rnd.NextDouble(30, 60, 4, 4, 35, 55);
			}
			else if (this.Motivation > 40 && this.Motivation <= 60)
			{
				this.WorkEthic = _rnd.NextDouble(50, 70, 4, 4, 55, 65);
			}
			else if (this.Motivation > 60 && this.Motivation <= 80)
			{
				this.WorkEthic = _rnd.NextDouble(60, 80, 4, 4, 65, 75);
			}
			else if (this.Motivation > 80 && this.Motivation <= 100)
			{
				this.WorkEthic = _rnd.NextDouble(80, 100, 3, 3, 85, 95);
			}
		}

		private double _getGrowthLeft(double height)
		{
			if (height < 48)
			{
				return _rnd.NextDouble(18, 20, 6, 1, 18, 19);
			}
			else if (height > 48 && height <= 54)
			{
				// 5'6" - 6'
				return _rnd.NextDouble(17, 20, 2, 2, 18, 19);
			}
			else if (height > 54 && height <= 60)
			{
				//  6' - 6'3"
				return _rnd.NextDouble(14, 16, 6, 2, 14, 16);
			}
			else
			{
				return _rnd.NextDouble(10, 13, 6, 2, 10, 12);
			}
		}

		private int _getExtraTotalGoalsFromMotivation(double motivation, out List<Goal> extraGoalsToSkip)
		{
			var totalGoals = 0;
			extraGoalsToSkip = new List<Goal>();

			if (motivation < 40)
			{
				totalGoals = 0;
			}
			else if (motivation > 40 && motivation <= 60)
			{
				totalGoals = 1;
			}
			else if (motivation > 60 && motivation <= 80)
			{
				totalGoals = 1;
				extraGoalsToSkip.Add(Goal.CouchPotato);
			}
			else
			{
				totalGoals = 1;

				extraGoalsToSkip.Add(Goal.CouchPotato);
				extraGoalsToSkip.Add(Goal.JustGetBy);
				extraGoalsToSkip.Add(Goal.AveragePlayer);
			}

			return totalGoals;
		}

		private List<PlayerGoal> _getGoals(int totalGoals, List<Goal> goalsToSkip)
		{
			var goals = new List<PlayerGoal>();

			for (int i = 1; i < totalGoals + 1; i++)
			{
				var rnd = _rnd.Next(1, 19);
				var goal = (Goal)rnd;

				while (goals.Select(w => w.Goal).Contains(goal) || goalsToSkip.Contains(goal))
				{
					rnd = _rnd.Next(1, 19);
					goal = (Goal)rnd;
				}

				goals.Add(new PlayerGoal()
				{
					Goal = goal,
					AgeStarted = this.Age,
					Priority = i
				});
			}

			return goals;
		}
	}
}
