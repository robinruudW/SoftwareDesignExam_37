using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.Entity
{
	public class Show : Media
	{

		public String? Creator { get; set; }

		public int? Seasons { get; set; }

		public double? ImdbScore { get; set; }

		public int TotalRatings { get; set; } = 0;
		public double RatingSum { get; set; } = 0;

		public Show() { }

		public Show(string name, string description, int yearOfRelease, string creator, int seasons, double imdbScore, double myAppScore)
		{
			Name = name;
			Description = description;
			YearOfRelease = yearOfRelease;
			Creator = creator;
			Seasons = seasons;
			ImdbScore = imdbScore;
			MyAppScore = myAppScore;
		}

		public double AverageRating => TotalRatings == 0 ? 0 : RatingSum / TotalRatings;

		public override string ToString()
		{
			return $"Name: {Name}\nDescription: {Description}\nYear Of Release: {YearOfRelease}\n" +
			   $"Creator: {Creator}\nSeasons: {Seasons}\nIMDb Score: {ImdbScore}\n" +
			   $"MyApp Average Rating: {AverageRating:F1} ({TotalRatings} votes)";
		}

	}
}
