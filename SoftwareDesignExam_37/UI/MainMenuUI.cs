using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.UI
{
	public class MainMenuUI
	{
		private readonly MovieMenuUI _movieMenu;
		private readonly ShowMenuUI _showMenu;

		public MainMenuUI(MovieMenuUI movieMenu, ShowMenuUI showMenu)
		{
			_movieMenu = movieMenu;
			_showMenu = showMenu;
		}

		public void ShowMainMenu()
		{
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nWelcome to the Media Database!\n");
				Console.WriteLine("1. Movie Menu");
				Console.WriteLine("2. Show Menu");
				Console.WriteLine("3. Exit");
				Console.Write("Enter a number between 1-3 to proceed: ");

				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						_movieMenu.ShowMovieMenu();
						break;
					case "2":
						_showMenu.ShowShowMenu();
						break;
					case "3":
						exit = true;
						break;
					default:
						Console.WriteLine("Invalid input, please try again!");
						break;
				}

				if (!exit)
				{
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}
		}
	}

}
