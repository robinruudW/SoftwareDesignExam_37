using SoftwareDesignExam_37.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.UI
{
	public class ShowMenuUI
	{

		private readonly ShowLogic _showLogic;

		public ShowMenuUI(ShowLogic showLogic)
		{
			_showLogic = showLogic;
		}

		public void ShowShowMenu()
		{
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nWelcome to the Show Menu!\n");
				Console.WriteLine("1. Show all shows");
				Console.WriteLine("2. Add a show");
				Console.WriteLine("3. Update a show");
				Console.WriteLine("4. Remove a show");
				Console.WriteLine("5. Rate a show");
				Console.WriteLine("6. Exit");
				Console.Write("Enter a number between 1-6 to proceed: ");

				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						_showLogic.ListShows();
						break;
					case "2":
						_showLogic.AddShow();
						break;
					case "3":
						_showLogic.UpdateShow();
						break;
					case "4":
						_showLogic.RemoveShow();
						break;
					case "5":
						_showLogic.RateShow();
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
