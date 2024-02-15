using System.ComponentModel.DataAnnotations;

namespace Self.Entity
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        public string? Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string role { get; set; }
    }
}
