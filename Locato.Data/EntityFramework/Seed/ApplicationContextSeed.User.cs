using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedUsers(CancellationToken cancellationToken)
        {
            var users = new List<User>
            {
                new User
                {
                    Email = "user1@example.com",
                    Phone = new Phone
                    {
                        CountryCode = 91,
                        NationalNumber = 123456789,
                        RawInput = "+91123456789",
                        E164Format = 91123456789
                    },
                    RoleId = (int)Roles.User,
                    LastSeen = null,
                    ProfileId = 1,
                    EmailVerified = true,
                    PhoneVerified = true,
                    AccountStatus = "Active",
                    BaseUserId = 1,
                    Designation = "Engineer"
                },
                new User
                {
                    Email = "user2@example.com",
                    Phone = new Phone
                    {
                        CountryCode = 91,
                        NationalNumber = 987654321,
                        RawInput = "+91987654321",
                        E164Format = 91987654321
                    },
                    RoleId = (int)Roles.User,
                    LastSeen = DateTime.UtcNow,
                    ProfileId = 2,
                    EmailVerified = true,
                    PhoneVerified = true,
                    AccountStatus = "Inactive",
                    BaseUserId = 2,
                    Designation = "Manager"
                }
            };

            _context.Users.AddRange(users);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

