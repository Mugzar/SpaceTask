﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPI.Models;

#nullable disable

namespace MovieAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"), 1L, 1);

                    b.Property<string>("Directors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMDBtitleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ImDbRating")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            Directors = "Lana Wachowski, Lilly Wachowski",
                            Genres = "Action, Sci-Fi",
                            IMDBtitleId = "tt0133093",
                            ImDbRating = 8.6999999999999993,
                            Image = "https://imdb-api.com/images/original/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_Ratio0.6791_AL_.jpg",
                            Plot = "Thomas A. Anderson is a man living two lives. By day he is an average computer programmer and by night a hacker known as Neo. Neo has always questioned his reality, but the truth is far beyond his imagination. Neo finds himself targeted by the police when he is contacted by Morpheus, a legendary computer hacker branded a terrorist by the government. As a rebel against the machines, Neo must confront the agents: super-powerful computer programs devoted to stopping Neo and the entire human rebellion.",
                            Title = "The Matrix"
                        },
                        new
                        {
                            MovieID = 2,
                            Directors = "Wachewski brothers",
                            Genres = "ACtion",
                            IMDBtitleId = "asd321",
                            Plot = "short description about the movie",
                            Title = "Matrix"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "akizhan@gmail.com",
                            UserName = "Morpheus"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "akizhan@gmail.com",
                            UserName = "Neo"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.WatchList", b =>
                {
                    b.Property<int>("WatchListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WatchListID"), 1L, 1);

                    b.Property<int>("UserRefId")
                        .HasColumnType("int");

                    b.HasKey("WatchListID");

                    b.HasIndex("UserRefId")
                        .IsUnique();

                    b.ToTable("WatchLists");

                    b.HasData(
                        new
                        {
                            WatchListID = 1,
                            UserRefId = 1
                        },
                        new
                        {
                            WatchListID = 2,
                            UserRefId = 2
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.WatchMovie", b =>
                {
                    b.Property<int>("WatchListId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDateOffered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 13, 38, 36, 787, DateTimeKind.Local).AddTicks(8388));

                    b.HasKey("WatchListId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("WatchMovie");

                    b.HasData(
                        new
                        {
                            WatchListId = 1,
                            MovieId = 1,
                            LastDateOffered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            WatchListId = 1,
                            MovieId = 2,
                            LastDateOffered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            WatchListId = 2,
                            MovieId = 2,
                            LastDateOffered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.WatchList", b =>
                {
                    b.HasOne("MovieAPI.Models.User", "User")
                        .WithOne("WatchList")
                        .HasForeignKey("MovieAPI.Models.WatchList", "UserRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieAPI.Models.WatchMovie", b =>
                {
                    b.HasOne("MovieAPI.Models.Movie", "Movie")
                        .WithMany("WatchMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.WatchList", "WatchList")
                        .WithMany("WatchMovies")
                        .HasForeignKey("WatchListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("WatchList");
                });

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.Navigation("WatchMovies");
                });

            modelBuilder.Entity("MovieAPI.Models.User", b =>
                {
                    b.Navigation("WatchList")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieAPI.Models.WatchList", b =>
                {
                    b.Navigation("WatchMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
