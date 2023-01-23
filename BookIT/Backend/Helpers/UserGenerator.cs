using Backend.Entities.Users;
using PasswordGenerator;

namespace Backend.Helpers;

public static class UserGenerator
{
    public static User GenerateUserFromEmail(string email)
    {
        return new User()
        {
            Email = email,
            NormalizedEmail = email.ToUpper(),
            UserName = email.Substring(0, email.IndexOf("@", StringComparison.Ordinal)),
            FirstName = email.Substring(0, email.IndexOf(".", StringComparison.Ordinal)),
            LastName = email.Substring(email.IndexOf(".", StringComparison.Ordinal), email.IndexOf("@", StringComparison.Ordinal)),
            PasswordHash = new Password(16).Next(),
            NormalizedUserName = email.Substring(0, email.IndexOf("@", StringComparison.Ordinal)).ToUpper(),
            SecurityStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
    } 
}