using System.ComponentModel.DataAnnotations.Schema;

namespace usuario_sis.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [NotMapped]
        public string Password { get; set; } = string.Empty;
    }

    public class UserLogin
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}