using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemeuseFootball15.Players;

namespace DemeuseFootball15
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var players = new List<Player>();
			var player = new RandomPlayer();
			var count = 0;

			while (count < 100)
			{
				player = new RandomPlayer();
				Console.WriteLine("Weight : " + player.Weight);
				Console.WriteLine("Height : " + player.Height);
				players.Add(player);
				count++;
			}
		}
	}
}
