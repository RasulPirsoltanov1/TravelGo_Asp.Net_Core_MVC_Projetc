using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.Password
{
    public class ResetPasswordDTO
    {
        [Required]
        public string? Password { get; set; }
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
