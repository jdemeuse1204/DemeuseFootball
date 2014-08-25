using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Traits
{
	public abstract class RandomizeDependencyTrait : Trait
	{
		public void Randomize(Random rnd, RandomizeTrait dependencyTrait)
		{
			_getRandom(rnd, dependencyTrait);
		}

		protected virtual void _getRandom(Random rnd, RandomizeTrait dependencyTrait)
		{
			Value = rnd.Next(Min, Max);

			if ((Value >= _high || Value <= _low) && _possibilityCount < _maxPossibilityCount)
			{
				_possibilityCount++;
				_getRandom(rnd, dependencyTrait);
			}
		}
	}
}
