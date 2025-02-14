using SoftwareDesignExam_37.DB;
using SoftwareDesignExam_37.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.Logic
{
	public class ShowLogic
	{

		private readonly MovieDatabaseContext _context;

		public ShowLogic(MovieDatabaseContext context)
		{
			_context = context;
		}

		public void AddShow()
		{
			Console.WriteLine("Enter the name of the show: ");
			string name = Console.ReadLine();
			Console.WriteLine("Enter the description of the show: ");
			string description = Console.ReadLine();
			Console.WriteLine("Enter the year of release of the show: ");
			int yearOfRelease = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the Creator of the show: ");
			string creator = Console.ReadLine();
			Console.WriteLine("Enter the imdb score of the show: ");
			double imdbScore = double.Parse(Console.ReadLine());
			var show = new Show
			{
				Name = name,
				Description = description,
				YearOfRelease = yearOfRelease,
				Creator = creator,
				ImdbScore = imdbScore
			};
			_context.Shows.Add(show);
			_context.SaveChanges();
			Console.WriteLine("Show added successfully!");

		}

		public void RemoveShow()
		{
			Console.WriteLine("Enter the name of the show you want to remove: ");
			string name = Console.ReadLine();
			var show = _context.Shows.FirstOrDefault(s => s.Name == name);
			if (show == null)
			{
				Console.WriteLine("Show not found!");
			}
			else
			{
				_context.Shows.Remove(show);
				_context.SaveChanges();
				Console.WriteLine("Show removed successfully!");
			}
		}

		public void UpdateShow()
		{
			Console.WriteLine("enter the name of the show you want to update: ");
			string name = Console.ReadLine();
			var show = _context.Shows.FirstOrDefault(s => s.Name == name);
			if (show == null)
			{
				Console.WriteLine("Show not found!");
				return;
			}
			Console.WriteLine("Enter the new name of the show: ");
			string newName = Console.ReadLine();
			Console.WriteLine("Enter the new description of the show: ");
			string newDescription = Console.ReadLine();
			Console.WriteLine("Enter the new year of release of the show: ");
			int newYearOfRelease = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the new Creator of the show: ");
			string newCreator = Console.ReadLine();
			Console.WriteLine("Enter the new imdb score of the show: ");
			double newImdbScore = double.Parse(Console.ReadLine());
			show.Name = newName;
			show.Description = newDescription;
			show.YearOfRelease = newYearOfRelease;
			show.Creator = newCreator;
			show.ImdbScore = newImdbScore;
			_context.SaveChanges();
			Console.WriteLine("Show updated successfully!");

		}

		public void ListShows()
		{
			var shows = _context.Shows.ToList();

			if (!shows.Any())
			{
				Console.WriteLine("No shows found!");
				return;
			}
			foreach (var show in shows)
			{
				Console.WriteLine("====================================");
				Console.WriteLine($"Name: {show.Name}");
				Console.WriteLine($"Description: {show.Description}");
				Console.WriteLine($"Year of release: {show.YearOfRelease}");
				Console.WriteLine($"Creator: {show.Creator}");
				Console.WriteLine($"Imdb score: {show.ImdbScore}");
				Console.WriteLine($"MyApp score: {show.MyAppScore}");
			}
		}

		public void RateShow()
		{
			Console.WriteLine("Enter the name of the show you want to rate:");
			string name = Console.ReadLine();

			var show = _context.Shows.FirstOrDefault(s => s.Name == name);
			if (show == null)
			{
				Console.WriteLine("Show not found!");
				return;
			}

			Console.WriteLine("Enter your rating (1-10):");
			if (!double.TryParse(Console.ReadLine(), out double rating) || rating < 1 || rating > 10)
			{
				Console.WriteLine("Invalid rating! Must be between 1 and 10.");
				return;
			}

			show.RatingSum += rating;
			show.TotalRatings++;
			_context.SaveChanges();

			Console.WriteLine($"You rated '{show.Name}' {rating}/10. New average rating: {show.AverageRating:F1}");
		}

	}
}
