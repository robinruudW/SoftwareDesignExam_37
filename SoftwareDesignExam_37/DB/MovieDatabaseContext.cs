using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam_37.Entity;

namespace SoftwareDesignExam_37.DB
{
	public class MovieDatabaseContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Show> Shows { get; set; }

		public MovieDatabaseContext() { }

		public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options)
			: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				string dbPath = @"C:\Users\robin\OneDrive\Desktop\SoftwareDesignExam_37\SoftwareDesignExam_37\movies.db";

				Console.WriteLine($"Using database at: {dbPath}");

				optionsBuilder.UseSqlite($"Data Source={dbPath}");
			}
		}
	}
}



