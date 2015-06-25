namespace DemeuseFootball15.Players.Parts.Base
{
    public abstract class Appendage : IAppendage, IBodyPart
    {
        public double OverallFatigue { get; protected set; }

        public double OverallFlexibility { get; protected set; }

        public double BoneDensity { get; protected set; }

        public double BoneFatigue { get; protected set; }

        public bool IsBoneBruised { get; protected set; }

        public bool IsMuscleBruised { get; protected set; }

        public double MuscleDensity { get; protected set; }

        public double MuscleFatigue { get; protected set; }

        public double MuscleFibreTwitch { get; protected set; }

        public double MuscleFlexibility { get; protected set; }

        public double LigamentStrength { get; protected set; }

        public double JointStrength { get; protected set; }

        public double JointFlexibility { get; protected set; }

        public double LigamentFlexibility { get; protected set; }

        public double JointFatigue { get; protected set; }

        public double LigamentFatigue { get; protected set; }

        public double WearAndTear { get; protected set; }
    }
}
