using System;

namespace DemeuseFootball15.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DiceAttribute : Attribute
    {
        public readonly int Min;
        public readonly int Max;

        public DiceAttribute(int sides)
        {
            Min = 1;
            Max = sides;
        }

        public DiceAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
