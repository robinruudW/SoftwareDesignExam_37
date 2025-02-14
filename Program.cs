using SoftwareDesignExam_37.DB;
using SoftwareDesignExam_37.Logic;
using SoftwareDesignExam_37.UI;

namespace SoftwareDesignExam_37
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new MovieDatabaseContext())
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