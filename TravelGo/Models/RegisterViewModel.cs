using System.ComponentModel.DataAnnotations;

namespace TravelGo.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Please fill name field")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Please fill Username field")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please fill Surname field")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Please fill Email field")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill PhoneNumber field")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please fill Password field")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please fill ConfirmPassword field")]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password not equla ")]
        public string ConfirmPassword { get; set; }
    }
}
