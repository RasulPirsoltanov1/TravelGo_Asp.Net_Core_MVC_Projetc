using System.ComponentModel.DataAnnotations;

namespace TravelGo.Areas.Memmber.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Please fill UserName field")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please fill name field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill Username field")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please fill Email field")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Please fill PhoneNumber field")]
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        //[Required(ErrorMessage = "Please fill Password field")]
        public string? Password { get; set; }
        //[Required(ErrorMessage = "Please fill ConfirmPassword field")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password not equla ")]
        public string? ConfirmPassword { get; set; }
        public IFormFile? Image { get; set; }
    }
}
