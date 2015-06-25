namespace DemeuseFootball15.Players.Parts.Base
{
    public interface IMuscle
    {
        bool IsMuscleBruised { get; }

        double MuscleDensity { get; }

        double MuscleFatigue { get; }

        double MuscleFibreTwitch { get; }

        double MuscleFlexibility { get; }
    }
}
