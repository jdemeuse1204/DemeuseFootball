namespace DemeuseFootball15.Players.Parts.Base
{
    public abstract class Phalange : IBone, IBodyPart
    {
        public double OverallFatigue { get; protected set; }

        public double OverallFlexibility { get; protected set; }

        public double BoneDensity { get; protected set; }

        public double BoneFatigue { get; protected set; }

        public bool IsBoneBruised { get; protected set; }

        public double LigamentStrength { get; protected set; }

        public double JointStrength { get; protected set; }
    }
}
