using RecipeWebApp.Models;

namespace RecipeWebApp.Services.RecipeService
{
    public interface IRecipeService
    {
        public Recipe Create(Recipe recipe);
    }
}
