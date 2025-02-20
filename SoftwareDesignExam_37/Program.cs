using System;
using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam_37.DB;
using SoftwareDesignExam_37.Logic;
using SoftwareDesignExam_37.UI;

namespace SoftwareDesignExam_37
{
	class Program
	{
		static void Main(string[] args)
		{
			
			var options = new DbContextOptionsBuilder<MovieDatabaseContext>()
				.UseSqlite("Data Source=movies.db")
				.Options;

			using (var context = new MovieDatabaseContext(options)) 
			{
				var movieLogic = new MovieLogic(context);
				var showLogic = new ShowLogic(context);
				var movieMenu = new MovieMenuUI(movieLogic);
				var showMenu = new ShowMenuUI(showLogic);
				var mainMenu = new MainMenuUI(movieMenu, showMenu);

				mainMenu.ShowMainMenu();
			}
		}
	}
}

