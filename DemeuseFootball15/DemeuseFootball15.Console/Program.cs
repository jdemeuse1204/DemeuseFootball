using System.Collections.Generic;
using System.Linq;
using DemeuseFootball15.Players;
using DemeuseFootball15.Players.Attributes;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            var shaker = new DiceShaker();

            for (var i = 0; i < 100; i++)
            {
                var player = Factory.CreatePlayer(shaker);
                System.Console.WriteLine(string.Format("Player {0}:\r\nThrowing Power: {1}\r\nTAS: {2}:\r\nTAM: {3}", 
                    i,
                    player.ThrowPower.GetValue<double>(),
                    player.ThrowAccuracyShort.GetValue<double>(),
                    player.ThrowAccuracyMid.GetValue<double>()));
                players.Add(player); 
            }

            var maxPotential = players.Select(w => w.GetPotential()).Max();
            var bestPlayer = players.First(w => w.GetPotential() == maxPotential);

            var maxMidAcc = players.Max(w => w.ThrowAccuracyMid.GetValue<double>());

            bestPlayer = players.First(w => w.ThrowAccuracyMid.GetValue<double>() == maxMidAcc);

            var maxShortAcc = players.Max(w => w.ThrowAccuracyShort.GetValue<double>());

            bestPlayer = players.First(w => w.ThrowAccuracyShort.GetValue<double>() == maxShortAcc);

            if (bestPlayer != null)
            {
                
            }
        }
    }
}
