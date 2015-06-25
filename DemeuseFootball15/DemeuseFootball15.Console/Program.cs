using DemeuseFootball15.Players;
using DemeuseFootball15.RandomProperty;

namespace DemeuseFootball15.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var shaker = new DiceShaker();
            Player player = new RandomPlayer(shaker);

            if (player != null)
            {
                
            }

            var test = Factory.Create();

        }
    }

    public partial class Factory
    {

        public static P Create()
        {
            return new MyClass();
        }
        
        
    }

    public partial class Factory
    {
        protected class MyClass : P
        {

        } 
    }

    public abstract class P
    {
        public int ID { get; set; }
    }
}
