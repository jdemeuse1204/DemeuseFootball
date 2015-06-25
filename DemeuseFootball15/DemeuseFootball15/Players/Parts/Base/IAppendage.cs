namespace DemeuseFootball15.Players.Parts.Base
{
    public interface IAppendage : IBone, IMuscle
    {
        double WearAndTear { get; }

        double LigamentStrength { get; }

        double JointStrength { get; }

        double JointFlexibility { get; }

        double LigamentFlexibility { get; }

        double JointFatigue { get; }

        double LigamentFatigue { get; }
    }
}
