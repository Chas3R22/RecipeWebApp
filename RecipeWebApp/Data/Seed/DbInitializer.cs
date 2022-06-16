using Microsoft.AspNetCore.Identity;
using RecipeWebApp.Models;

namespace RecipeWebApp.Data.Seed
{
    public class DbInitializer
    {
        private readonly static string adminId = "cbd958a7-bbc1-4b66-9085-f6a49a67b0fc";
        private readonly static string userId2 = "4bd958a7-bbc1-4b66-9085-f6a49a67b0fc";
        private readonly static string adminRoleId = "1bd958a7-bac1-4b66-9085-f6a49a67b0fc";
        private readonly static string userRoleId = "2bd958a7-bac1-4b66-1085-f6a49a67b0fc";
        public static void Seed(ApplicationDbContext context)
        {
            if(!context.Roles.Any())
            {
                context.AddRange(
                    new IdentityRole
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = userRoleId,
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
            }
            if(!context.Users.Any())
            {
                context.AddRange(
                    new User
                    {
                        Id = adminId,
                        Email = "YoinkySploinky@admin.com",
                        PasswordHash = new PasswordHasher<User>().HashPassword(null, "chas3r22")
                    },
                    new User
                    {
                        Id = userId2,
                        Email = "chas3r22@gmail.com",
                        PasswordHash = new PasswordHasher<User>().HashPassword(null, "ferovore")
                    }
                );
            }
            if(!context.UserRoles.Any())
            {
                context.AddRange(
                    new IdentityUserRole<string>
                    {
                        UserId = adminId,
                        RoleId = adminRoleId,
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = userId2,
                        RoleId = userRoleId
                    }
                    );
            }
            context.SaveChanges();
        }
    }
}
