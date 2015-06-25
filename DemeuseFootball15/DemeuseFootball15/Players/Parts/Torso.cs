using DemeuseFootball15.Players.Parts.Base;

namespace DemeuseFootball15.Players.Parts
{
    public class Torso : IBone, IMuscle, IBodyPart
    {
        // shoulders
        public double SpineHealth { get; protected set; }

        public double BoneDensity { get; protected set; }

        public double BoneFatigue { get; protected set; }

        public bool IsBoneBruised { get; protected set; }

        public bool IsMuscleBruised { get; protected set; }

        public double MuscleDensity { get; protected set; }

        public double MuscleFatigue { get; protected set; }

        public double MuscleFibreTwitch { get; protected set; }

        public double MuscleFlexibility { get; protected set; }

        public double OverallFatigue { get; protected set; }

        public double OverallFlexibility { get; protected set; }
    }
}
