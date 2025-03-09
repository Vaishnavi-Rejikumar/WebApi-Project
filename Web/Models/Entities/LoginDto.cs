using System.ComponentModel.DataAnnotations;

namespace Web.Models.Entity.DTOs  // Change namespace to match your project
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
