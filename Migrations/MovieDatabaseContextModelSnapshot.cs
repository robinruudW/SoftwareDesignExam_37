﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareDesignExam_37.DB;

#nullable disable

namespace SoftwareDesignExam_37.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    partial class MovieDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("SoftwareDesignExam_37.Entity.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ImdbScore")
                        .HasColumnType("REAL");

                    b.Property<double?>("MyAppScore")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("RatingSum")
                        .HasColumnType("REAL");

                    b.Property<int>("TotalRatings")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YearOfRelease")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SoftwareDesignExam_37.Entity.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Creator")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ImdbScore")
                        .HasColumnType("REAL");

                    b.Property<double?>("MyAppScore")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("RatingSum")
                        .HasColumnType("REAL");

                    b.Property<int?>("Seasons")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalRatings")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YearOfRelease")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
