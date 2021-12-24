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
            modelBuilder.Entity<User>().HasData(new User { UserID = 1, UserName = "Morpheus", Email="akizhan@gmail.com"});
            modelBuilder.Entity<User>().HasData(new User { UserID = 2, UserName = "Neo", Email="akizhan@gmail.com" });

            modelBuilder.Entity<WatchList>().HasData(new WatchList { WatchListID = 1, UserRefId = 1 });
            modelBuilder.Entity<WatchList>().HasData(new WatchList { WatchListID = 2, UserRefId = 2 });

            modelBuilder.Entity<Movie>(entity => { entity.Property(e => e.Title).IsRequired(); });
            modelBuilder.Entity<Movie>().HasData(new Movie { 
                MovieID = 1, 
                Title= "The Matrix", 
                Plot= "Thomas A. Anderson is a man living two lives. By day he is an average computer programmer and by night a hacker known as Neo. Neo has always questioned his reality, but the truth is far beyond his imagination. Neo finds himself targeted by the police when he is contacted by Morpheus, a legendary computer hacker branded a terrorist by the government. As a rebel against the machines, Neo must confront the agents: super-powerful computer programs devoted to stopping Neo and the entire human rebellion.", 
                Directors= "Lana Wachowski, Lilly Wachowski", 
                Genres= "Action, Sci-Fi",
                Image= "https://imdb-api.com/images/original/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_Ratio0.6791_AL_.jpg",
                ImDbRating = 8.7,
                IMDBtitleId = "tt0133093"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie { 
                MovieID = 2, 
                Title ="Matrix", 
                Plot = "short description about the movie", 
                Directors = "Wachewski brothers", 
                Genres = "ACtion", 
                IMDBtitleId="asd321" 
            });

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
