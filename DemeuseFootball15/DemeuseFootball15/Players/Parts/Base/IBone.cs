namespace DemeuseFootball15.Players.Parts.Base
{
    public interface IBone
    {
        double BoneDensity { get; }

        double BoneFatigue { get; }

        bool IsBoneBruised { get; }
    }
}
