using System.Collections.Generic;
using DemeuseFootball15.Players.Parts.Base;

namespace DemeuseFootball15.Players.Parts
{
    public class Arm : Appendage
    {
        public List<Finger> Fingers { get; protected set; }
    }
}
