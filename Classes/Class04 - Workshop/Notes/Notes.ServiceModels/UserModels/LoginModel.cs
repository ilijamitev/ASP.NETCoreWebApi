using System.ComponentModel.DataAnnotations;

namespace Notes.ServiceModels.UserModels
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
