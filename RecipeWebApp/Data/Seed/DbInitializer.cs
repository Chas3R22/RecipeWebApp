using Microsoft.AspNetCore.Identity;
using RecipeWebApp.Models;

namespace RecipeWebApp.Data.Seed
{
    public class DbInitializer
    {
        public static void RoleSeed(ApplicationDbContext context)
        {
            if(context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new IdentityRole()
            {
                Name = "User",
                NormalizedName = "User".ToUpper()
            });

            context.Roles.Add(new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            context.SaveChanges();
        }

        public static void AdminSeed(UserManager<User> userManager)
        {
            string email = "Chaser@admin.com";
            var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            if (user == null)
            {
                User admin = new User()
                {
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper()
                };

                userManager.CreateAsync(admin, "Chaser1@admin.com").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }

            if (userManager.GetRolesAsync(user).Result.Contains("Admin"))
            {
                return;
            }

            userManager.RemoveFromRoleAsync(user, "User").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }
    }
}