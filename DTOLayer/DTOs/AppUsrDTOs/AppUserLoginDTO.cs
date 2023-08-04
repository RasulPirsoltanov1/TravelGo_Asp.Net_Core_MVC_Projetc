using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.AppUsrDTOs
{
    public class AppUserLoginDTO
    {

        [Required(ErrorMessage = "Please fill Username field")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill Password field")]
        public string Password { get; set; }
    }
}
