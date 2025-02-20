using SoftwareDesignExam_37.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.UI
{
	public class MovieMenuUI
	{

		private readonly MovieLogic _movieLogic;

		public MovieMenuUI(MovieLogic movieLogic)
		{
			_movieLogic = movieLogic;
		}

		public void ShowMovieMenu()
		{
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nWelcome to the Movie Menu!\n");
				Console.WriteLine("1. Show all movies");
				Console.WriteLine("2. Add a movie");
				Console.WriteLine("3. Update a movie");
				Console.WriteLine("4. Remove a movie");
				Console.WriteLine("5. Rate a movie");
				Console.WriteLine("6. Exit");
				Console.Write("Enter a number between 1-6 to proceed: ");

				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						_movieLogic.ListMovies();
						break;
					case "2":
						_movieLogic.AddMovie();
						break;
					case "3":
						_movieLogic.UpdateMovie();
						break;
					case "4":
						_movieLogic.RemoveMovie();
						break;
					case "5":
						_movieLogic.RateMovie();
						break;
					case "6":
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
