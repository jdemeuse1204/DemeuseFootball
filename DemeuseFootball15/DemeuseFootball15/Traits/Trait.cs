using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Traits
{
	public abstract class Trait
	{
		public double Value { get; set; }

		public abstract int Max { get; }

		public abstract int Min { get; }

		protected int _possibilityCount { get; set; }

		protected abstract int _maxPossibilityCount { get; }

		protected abstract int _high { get; }

		protected abstract int _low { get; }

		public abstract int Average { get; }
	}
}
