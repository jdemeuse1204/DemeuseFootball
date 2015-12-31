using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class PotentialPropertyAttribute : Attribute
    {
    }
}
