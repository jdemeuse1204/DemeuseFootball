using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Traits
{
	public class Height : RandomizeTrait
	{
		public override int Max { get { return 81; } }

		protected override int _maxPossibilityCount { get { return 6; } }

		protected override int _high { get { return Average + 4; } }

		protected override int _low { get { return Average - 4; } }

		public override int Average { get { return 66; } }

		public override int Min { get { return 54; } }
	}
}
