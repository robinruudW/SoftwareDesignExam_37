using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesignExam_37.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    ImdbScore = table.Column<double>(type: "REAL", nullable: true),
                    TotalRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingSum = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfRelease = table.Column<int>(type: "INTEGER", nullable: true),
                    MyAppScore = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    Seasons = table.Column<int>(type: "INTEGER", nullable: true),
                    ImdbScore = table.Column<double>(type: "REAL", nullable: true),
                    TotalRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingSum = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfRelease = table.Column<int>(type: "INTEGER", nullable: true),
                    MyAppScore = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
