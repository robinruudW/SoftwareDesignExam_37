using SoftwareDesignExam_37.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SoftwareDesignExam_37.DB
{
	
	public class MovieDatabaseContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }

		public DbSet<Show> Shows { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{	

			// for some reason the db path file is not working. so i have to set the path manualy. you will have to do that aswell for the application to work.
			string dbPath = @"C:\Users\robin\OneDrive\Desktop\SoftwareDesign\SoftwareDesignExam_37\movies.db";
			optionsBuilder.UseSqlite($"Data Source={dbPath}");
		}
	}
}
