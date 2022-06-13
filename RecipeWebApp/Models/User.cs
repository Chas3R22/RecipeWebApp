using Microsoft.AspNetCore.Identity;

namespace RecipeWebApp.Models
{
    public class User : IdentityUser
    {
        public ICollection<Recipe> Recipes { get; set; }

        public ICollection<RecipeUserMapping> RecipeUserMappings { get; set; }
    }
}
