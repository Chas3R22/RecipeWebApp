using RecipeWebApp.Models;

namespace RecipeWebApp.Services.RecipeService
{
    public interface IRecipeService
    {
        void Create(Recipe recipe, string userId);
    }
}
