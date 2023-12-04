using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Admin
{
    public class AuthenticateAdminDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "The password is required!")]
        public string Password { get; set; } = string.Empty;
    }
}
