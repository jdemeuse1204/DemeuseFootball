﻿using System;
using System.Linq;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Players.Attributes.Base;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Players.Attributes
{
    public class Foot : PlayerAttribute
    {
        public override void Calculate(Player player, IDiceShaker shaker)
        {

        }

        public override void Create(Player player, IDiceShaker shaker, IDiceAttribute diceAttribute)
        {
            var attribute = (ProportionalityDiceAttribute)diceAttribute;
            var basedOnProperty =
                player.GetType().GetProperties().First(w => w.PropertyType == attribute.ProportionalToType);
            var proportionalToValue = (PlayerAttribute)basedOnProperty.GetValue(player);
            const double min = .125d;
            const double max = .229d;

            var value = shaker.RandomRoll(min, max);
            var result = Convert.ToDouble(proportionalToValue.Value) * value;

            SetValue(result);
        }
    }
}
