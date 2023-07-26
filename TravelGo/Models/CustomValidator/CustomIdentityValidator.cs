using Microsoft.AspNetCore.Identity;

namespace TravelGo.Models.CustomIdentityValidator
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code="PasswordTooShort",
                Description="Password length must be bigger then 7"
            };
        }
    }
}
