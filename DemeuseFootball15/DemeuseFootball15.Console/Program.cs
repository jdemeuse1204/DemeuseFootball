﻿using DemeuseFootball15.Players;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var shaker = new DiceShaker();
            Player player = new RandomPlayer(shaker);

            if (player != null)
            {
                
            }

        }
    }
}