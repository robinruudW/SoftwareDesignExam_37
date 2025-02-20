using Xunit;
using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam_37.DB;
using SoftwareDesignExam_37.Entity;
using SoftwareDesignExam_37.Logic;
using System.Linq;

namespace SoftwareDesignExam_37.Tests
{
	public class MovieLogicTests
	{
		private MovieDatabaseContext GetInMemoryDbContext()
		{
			var options = new DbContextOptionsBuilder<MovieDatabaseContext>()
				.UseInMemoryDatabase("MovieTestDb") 
				.Options;

			return new MovieDatabaseContext(options);
		}

		[Fact]
		public void AddMovie_ShouldIncreaseMovieCount()
		{
			var context = GetInMemoryDbContext();
			var movieLogic = new MovieLogic(context);
			context.Database.EnsureDeleted(); 

			
			context.Movies.Add(new Movie
			{
				Name = "Test Movie",
				Description = "Test Description",
				YearOfRelease = 2024,
				Director = "Test Director",
				ImdbScore = 8.5
			});
			context.SaveChanges();

			
			Assert.Equal(1, context.Movies.Count());
		}

		[Fact]
		public void RemoveMovie_ShouldDecreaseMovieCount()
		{
			var context = GetInMemoryDbContext();
			var movieLogic = new MovieLogic(context);

			context.Database.EnsureDeleted(); // Reset database before test

			var movie = new Movie { Name = "Movie to Remove" };
			context.Movies.Add(movie);
			context.SaveChanges();

			
			context.Movies.Remove(movie);
			context.SaveChanges();

			
			Assert.Equal(0, context.Movies.Count());
		}

		[Fact]
		public void ListMovies_ShouldReturnAllMovies()
		{
			var context = GetInMemoryDbContext();
			var movieLogic = new MovieLogic(context);

			context.Database.EnsureDeleted(); // Reset database before test

			context.Movies.Add(new Movie { Name = "Movie 1" });
			context.Movies.Add(new Movie { Name = "Movie 2" });
			context.SaveChanges();

			
			var movies = context.Movies.ToList();

			
			Assert.Equal(2, movies.Count);
		}
	}

	public class MovieDatabaseContextTests
	{
		[Fact]
		public void AddMovie_ShouldPersistInDatabase()
		{
			var options = new DbContextOptionsBuilder<MovieDatabaseContext>()
				.UseSqlite("Data Source=movies.db")
				.Options;

			using (var context = new MovieDatabaseContext(options))
			{
				context.Database.EnsureCreated();
				context.Movies.Add(new Movie { Name = "Persisted Movie", YearOfRelease = 2023 });
				context.SaveChanges();
			}

			using (var context = new MovieDatabaseContext(options))
			{
				var movie = context.Movies.FirstOrDefault(m => m.Name == "Persisted Movie");
				Assert.NotNull(movie);
			}
		}

		[Fact]
		public void UpdateMovie_ShouldModifyExistingEntry()
		{
			var options = new DbContextOptionsBuilder<MovieDatabaseContext>()
				.UseSqlite("Data Source=movies.db")
				.Options;

			using (var context = new MovieDatabaseContext(options))
			{
				context.Database.EnsureCreated();
				var movie = new Movie { Name = "Old Name", YearOfRelease = 2020 };
				context.Movies.Add(movie);
				context.SaveChanges();
			}

			using (var context = new MovieDatabaseContext(options))
			{
				var movie = context.Movies.FirstOrDefault(m => m.Name == "Old Name");
				movie.Name = "New Name";
				context.SaveChanges();
			}

			using (var context = new MovieDatabaseContext(options))
			{
				var movie = context.Movies.FirstOrDefault(m => m.Name == "New Name");
				Assert.NotNull(movie);
			}
		}

		[Fact]
		public void DeleteMovie_ShouldRemoveEntry()
		{
			var options = new DbContextOptionsBuilder<MovieDatabaseContext>()
				.UseSqlite("Data Source=movies.db")
				.Options;

			using (var context = new MovieDatabaseContext(options))
			{
				context.Database.EnsureCreated();
				var movie = new Movie { Name = "To Delete", YearOfRelease = 2019 };
				context.Movies.Add(movie);
				context.SaveChanges();
			}

			using (var context = new MovieDatabaseContext(options))
			{
				var movie = context.Movies.FirstOrDefault(m => m.Name == "To Delete");
				context.Movies.Remove(movie);
				context.SaveChanges();
			}

			using (var context = new MovieDatabaseContext(options))
			{
				var movie = context.Movies.FirstOrDefault(m => m.Name == "To Delete");
				Assert.Null(movie);
			}
		}
	}
}

