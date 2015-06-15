using System.Collections.Generic;
using System.Linq;

namespace DemeuseFootball15.RandomProperty
{
    public class DiceShaker
    {
        private readonly List<Dice> _dice;
  
        public DiceShaker()
        {
            _dice = new List<Dice>();
        }

        public int Roll(int min, int max)
        {
            var dice = _dice.FirstOrDefault(w => w.MinValue == min && w.MaxValue == max);

            if (dice != null) return dice.Shake();

            dice = new Dice(min, max);
            _dice.Add(dice);

            return dice.Shake();
        }
    }
}
