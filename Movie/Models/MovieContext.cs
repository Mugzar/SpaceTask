using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options): base(options) 
        { 
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        //public DbSet<WatchMovie> WatchMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<User>(entity => { entity.Property(e => e.UserName).IsRequired(); });
            modelBuilder.Entity<User>()
                        .HasOne<WatchList>(u => u.WatchList)
                        .WithOne(w => w.User)
                        .HasForeignKey<WatchList>(w => w.UserRefId);
            modelBuilder.Entity<User>().HasData(new User { UserID = 1, UserName = "Morpheus"});
            modelBuilder.Entity<User>().HasData(new User { UserID = 2, UserName = "Neo" });

            modelBuilder.Entity<WatchList>().HasData(new WatchList { WatchListID = 1, UserRefId = 1 });
            modelBuilder.Entity<WatchList>().HasData(new WatchList { WatchListID = 2, UserRefId = 2 });

            modelBuilder.Entity<Movie>(entity => { entity.Property(e => e.Title).IsRequired(); });
            modelBuilder.Entity<Movie>().HasData(new Movie { MovieID = 1, Title="Movie1", Description="short description about the movie", Director="Some director", Genre="ACtion", IMDBtitleId="qwe123" });
            modelBuilder.Entity<Movie>().HasData(new Movie { MovieID = 2, Title ="Matrix", Description = "short description about the movie", Director = "Wachewski brothers", Genre = "ACtion", IMDBtitleId="asd321" });

            modelBuilder.Entity<WatchMovie>().HasKey(wm => new { wm.WatchListId, wm.MovieId });
            modelBuilder.Entity<WatchMovie>().Property(pt => pt.LastDateOffered).HasDefaultValue(DateTime.Now.AddMonths(-3));

            modelBuilder.Entity<WatchMovie>()
                .HasOne(pt => pt.WatchList)
                .WithMany(p => p.WatchMovies)
                .HasForeignKey(pt => pt.WatchListId);

            modelBuilder.Entity<WatchMovie>()
                .HasOne(pt => pt.Movie)
                .WithMany(t => t.WatchMovies)
                .HasForeignKey(pt => pt.MovieId);
            
            modelBuilder.Entity<WatchMovie>().HasData(new[]
            {
                new WatchMovie{ WatchListId = 1, MovieId = 1 },
                new WatchMovie{ WatchListId = 1, MovieId = 2 },
                new WatchMovie{ WatchListId = 2, MovieId = 2 }
            });

        }
    }
}
