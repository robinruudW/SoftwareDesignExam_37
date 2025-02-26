using SoftwareDesignExam_37.DB;
using SoftwareDesignExam_37.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.Logic
{
	public class MovieLogic
	{

		private readonly MovieDatabaseContext _context;

		public MovieLogic(MovieDatabaseContext context)
		{
			_context = context;
		}


		public void AddMovie()
		{
			Console.WriteLine("Enter the name of the movie: ");
			string name = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the description of the movie: ");
			string description = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the year of release of the movie: ");
			int yearOfRelease;
			while (!int.TryParse(Console.ReadLine(), out yearOfRelease))
			{
				Console.WriteLine("Invalid input. Please enter a valid year (integer).");
			}

			Console.WriteLine("Enter the director of the movie: ");
			string director = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the IMDb score of the movie: ");
			double imdbScore;
			while (!double.TryParse(Console.ReadLine(), out imdbScore))
			{
				Console.WriteLine("Invalid input. Please enter a valid IMDb score (decimal number).");
			}

			var movie = new Movie
			{
				Name = name,
				Description = description,
				YearOfRelease = yearOfRelease,
				Director = director,
				ImdbScore = imdbScore
			};

			try
			{
				_context.Movies.Add(movie);
				_context.SaveChanges();
				Console.WriteLine("Movie added successfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error saving movie: {ex.Message}");
			}
		}


		public void RemoveMovie()
		{
			Console.WriteLine("Enter the name of the movie you want to remove: ");
			string name = Console.ReadLine();
			var movie = _context.Movies.FirstOrDefault(m => m.Name == name);
			if (movie == null)
			{
				Console.WriteLine("Movie not found!");
				return;
			}
			_context.Movies.Remove(movie);
			_context.SaveChanges();
			Console.WriteLine("Movie removed successfully!");
		}

		public void UpdateMovie()
		{
			Console.WriteLine("Enter the name of the movie you want to update: ");
			string name = Console.ReadLine() ?? "";

			var movie = _context.Movies.FirstOrDefault(m => m.Name == name);
			if (movie == null)
			{
				Console.WriteLine("Movie not found!");
				return;
			}

			Console.WriteLine("Enter the new name of the movie: ");
			string newName = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the new description of the movie: ");
			string newDescription = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the new year of release of the movie: ");
			int newYearOfRelease;
			while (!int.TryParse(Console.ReadLine(), out newYearOfRelease))
			{
				Console.WriteLine("Invalid input. Please enter a valid year (integer).");
			}

			Console.WriteLine("Enter the new director of the movie: ");
			string newDirector = Console.ReadLine() ?? "";

			Console.WriteLine("Enter the new IMDb score of the movie: ");
			double newImdbScore;
			while (!double.TryParse(Console.ReadLine(), out newImdbScore))
			{
				Console.WriteLine("Invalid input. Please enter a valid IMDb score (decimal number).");
			}

			movie.Name = newName;
			movie.Description = newDescription;
			movie.YearOfRelease = newYearOfRelease;
			movie.Director = newDirector;
			movie.ImdbScore = newImdbScore;

			try
			{
				_context.SaveChanges();
				Console.WriteLine("Movie updated successfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating movie: {ex.Message}");
			}
		}


		public void ListMovies()
		{
			var movies = _context.Movies.ToList();

			if (!movies.Any())
			{
				Console.WriteLine("No movies found.");
				return;
			}

			foreach (var movie in movies)
			{
				Console.WriteLine("====================================");
				Console.WriteLine($"Name: {movie.Name}");
				Console.WriteLine($"Description: {movie.Description}");
				Console.WriteLine($"Year of Release: {movie.YearOfRelease}");
				Console.WriteLine($"Director: {movie.Director}");
				Console.WriteLine($"IMDb Score: {movie.ImdbScore}");
				Console.WriteLine($"MyApp Average Rating: {movie.AverageRating:F1} ({movie.TotalRatings} votes)");
				Console.WriteLine("====================================");
				Console.WriteLine();
			}
		}

		public void RateMovie()
		{
			Console.WriteLine("Enter the name of the movie you want to rate:");
			string name = Console.ReadLine();

			var movie = _context.Movies.FirstOrDefault(m => m.Name == name);
			if (movie == null)
			{
				Console.WriteLine("Movie not found!");
				return;
			}

			Console.WriteLine("Enter your rating (1-10):");
			if (!double.TryParse(Console.ReadLine(), out double rating) || rating < 1 || rating > 10)
			{
				Console.WriteLine("Invalid rating! Must be between 1 and 10.");
				return;
			}

			movie.RatingSum += rating;
			movie.TotalRatings++;
			_context.SaveChanges();

			Console.WriteLine($"You rated '{movie.Name}' {rating}/10. New average rating: {movie.AverageRating:F1}");
		}




	}
}
