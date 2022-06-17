using RecipeWebApp.Models;

namespace RecipeWebApp.Services.RecipeService
{
    public interface IRecipeService
    {
        void Create(Recipe recipe, string userId);
        void Update(Recipe recipe);
        void Delete(Guid id);
    }
}
