using MovieAPI.Models;

namespace MovieAPI.Data
{
    public static class DBInitializer
    {
        public static void Initialize(MovieContext context)
        { 
            if (context.Users.Any())
            {
                return;   
            }
            var users = new User[]
            {
                new User{UserName="abc"},
                new User{UserName="bcd"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();


        }

    }
}
