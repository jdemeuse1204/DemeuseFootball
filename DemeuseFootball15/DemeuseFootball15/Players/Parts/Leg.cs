using System.Collections.Generic;
using DemeuseFootball15.Players.Parts.Base;

namespace DemeuseFootball15.Players.Parts
{
    public class Leg : Appendage
    {
        public List<Toe> Toes { get; protected set; }
    }
}
