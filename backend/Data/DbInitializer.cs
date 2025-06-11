using usuario_sis.Data;
using usuario_sis.Models;
using BCrypt.Net;
using System.Linq;


namespace usuario_sis
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any()) return;

            var admin = new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123")
            };

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}