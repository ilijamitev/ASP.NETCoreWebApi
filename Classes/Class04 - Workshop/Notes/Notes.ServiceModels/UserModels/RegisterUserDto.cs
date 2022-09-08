using System.ComponentModel.DataAnnotations;

namespace Notes.ServiceModels.UserModels
{
    public class RegisterUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
