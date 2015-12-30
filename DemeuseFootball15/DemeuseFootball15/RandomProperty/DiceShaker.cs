using System.Collections.Generic;
using System.Linq;
using DemeuseFootball15.Attributes;
using DemeuseFootball15.Enumeration;

namespace DemeuseFootball15.RandomProperty
{
    public class DiceShaker : IDiceShaker
    {
        private readonly List<IDice> _dice;
  
        public DiceShaker()
        {
            _dice = new List<IDice>();
        }

        public int Roll(WholeDiceAttribute diceAttribute)
        {
            var dice =
                _dice.FirstOrDefault(
                    w =>
                        w.MinValue == diceAttribute.Min && w.MaxValue == diceAttribute.Max &&
                        w.Volatility == (double) diceAttribute.Volatility && w is WholeDice);

            if (dice != null) return (int)dice.Shake();

            dice = new WholeDice(diceAttribute);
            _dice.Add(dice);

            return (int)dice.Shake();
        }

        public double Roll(DecimalDiceAttribute diceAttribute)
        {
            var dice =
                _dice.FirstOrDefault(
                    w =>
                        w.MinValue == diceAttribute.Min && w.MaxValue == diceAttribute.Max &&
                        w.Volatility == (double) diceAttribute.Volatility && w is DecimalDice);

            if (dice != null) return dice.Shake();

            dice = new DecimalDice(diceAttribute);
            _dice.Add(dice);

            return dice.Shake();
        }

        public double RandomRoll(int min, int max)
        {
            var dice = new DecimalDice(min, max, Volatility._0);

            return dice.Shake();
        }
    }
}
