using DemeuseFootball15.Players;
using DemeuseFootball15.Players.Attributes;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Age();
            //var w = new Weight();

            //a.OnChange += w.OnPropertyChanged;

            var shaker = new DiceShaker();
            var test = Factory.CreatePlayer(shaker);

            if (test != null)
            {
                
            }
        }
    }
}
