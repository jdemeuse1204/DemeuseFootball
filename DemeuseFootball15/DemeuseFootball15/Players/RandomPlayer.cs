using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.Players
{
	public class RandomPlayer : Player
	{
		/// <summary>
		/// Randomizes player stats
		/// </summary>
		public RandomPlayer()
			: base()
		{
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
			var age = Services.Next(10, 12);

			while (age >= 12)
			{
				age = Services.Next(10, 12);
			}

			// Date of Birth
			var yearDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day).AddYears(-1);
			var days = DateTime.IsLeapYear(yearDate.Year + 1) ? 365 : 364;
			var findBday = Services.Next(0, days);
			DateTime min = yearDate;
			DateTime max = yearDate.AddDays(days);

			this.DateOfBirth = yearDate.AddDays(findBday);

			// Physical Traits
			if (this.Age == 10)
			{
				this.Height = Services.NextDouble(54.5, 5, 3, 3, 48, 62);
			}
			else
			{
				this.Height = Services.NextDouble(56.5, 8, 3, 3, 50, 64);
			}

			this.Metabolism = Services.NextDouble(70, 30, 4, 2, 40, 70);

			this.Weight = _getPlayerWeight(Height, Metabolism);

			// As player grows physically these stats will get bigger
			this.GrowthLeft = _getGrowthLeft(Height);

			var growth = new GrowthPlayer(this);
			this.Foot = growth.Foot;
			this.Hand = growth.Hand;
			this.ArmLength = growth.ArmLength;

			this.Body = BodyType.Average;
			this.RunningStyle = RunStyle.Natural;

			// Player Drive
			this.Motivation = Services.NextDouble(70, 30, 4, 4, 40, 60);
			this.PersonalGoals = Services.NextDouble(70, 30, 4, 4, 40, 60);

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
				totalGoals += Services.Next(4, 6);

				// Skip these goals
				goalsToSkip.Add(Goal.CouchPotato);
				goalsToSkip.Add(Goal.JustGetBy);
				goalsToSkip.Add(Goal.AveragePlayer);
			}

			// Goals - Based on Drive
			this._goals = _getGoals(totalGoals, goalsToSkip);

			// Team Work
			this.TeamWork = Services.NextDouble(60, 40, 4, 4, 40, 60);

			// Work Ethic
			if (this.Motivation < 40)
			{
				this.WorkEthic = Services.NextDouble(60, 60, 4, 4, 35, 55);
			}
			else if (this.Motivation > 40 && this.Motivation <= 60)
			{
				this.WorkEthic = Services.NextDouble(60, 40, 4, 4, 55, 65);
			}
			else if (this.Motivation > 60 && this.Motivation <= 80)
			{
				this.WorkEthic = Services.NextDouble(60, 20, 4, 4, 65, 75);
			}
			else if (this.Motivation > 80 && this.Motivation <= 100)
			{
				this.WorkEthic = Services.NextDouble(80, 10, 3, 3, 85, 95);
			}
		}

		private double _getPlayerWeight(double height, double metabolism)
		{
			var mean = 0;
			var stdDev = 0;
			var minThreshhold = 0d;
			var maxThreshhold = 0d;

			if (metabolism < 40)
			{
				mean = 85;
				stdDev = 15;
				minThreshhold = 90;
				maxThreshhold = 95;
			}
			else if (metabolism > 40 && metabolism <= 60)
			{
				mean = 80;
				stdDev = 15;
				minThreshhold = 82;
				maxThreshhold = 92;
			}
			else if (metabolism > 60 && metabolism <= 80)
			{
				mean = 70;
				stdDev = 20;
				minThreshhold = 72;
				maxThreshhold = 88;
			}
			else if (metabolism > 80 && metabolism <= 100)
			{
				mean = 62;
				stdDev = 18;
				minThreshhold = 64;
				maxThreshhold = 78;
			}

			if (Age == 11)
			{
				mean += 8;
				stdDev += 8;
				minThreshhold += 8;
				maxThreshhold += 8;
			}

			// TODO Adjust for height

			if (this.Height > 50 && this.Height <= 55)
			{
				mean += 8;
				stdDev += 8;
				minThreshhold += 8;
				maxThreshhold += 8;
			}
			else if (this.Height > 55 && this.Height <= 60)
			{
				mean += 12;
				stdDev += 12;
				minThreshhold += 12;
				maxThreshhold += 12;
			}
			else if (this.Height > 60 && this.Height <= 65)
			{
				mean += 16;
				stdDev += 16;
				minThreshhold += 12;
				maxThreshhold += 12;
			}
			else if (this.Height > 65)
			{
				mean += 22;
				stdDev += 22;
				minThreshhold += 16;
				maxThreshhold += 16;
			}

			return Services.NextDouble(mean, stdDev, 6, 6, minThreshhold, maxThreshhold);
		}

		private double _getGrowthLeft(double height)
		{
			if (height < 48)
			{
				return Services.NextDouble(18, 2, 6, 1, 18, 19);
			}
			else if (height > 48 && height <= 54)
			{
				// 5'6" - 6'
				return Services.NextDouble(17, 3, 2, 2, 18, 19);
			}
			else if (height > 54 && height <= 60)
			{
				//  6' - 6'3"
				return Services.NextDouble(14, 2, 6, 2, 14, 16);
			}
			else if (height > 60 && height <= 65)
			{
				return Services.NextDouble(10, 2, 6, 2, 14, 16);
			}
			else
			{
				return Services.NextDouble(8, 2, 6, 2, 10, 12);
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
				var rnd = Services.Next(1, 19);
				var goal = (Goal)rnd;

				while (goals.Select(w => w.Goal).Contains(goal) || goalsToSkip.Contains(goal))
				{
					rnd = Services.Next(1, 19);
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
