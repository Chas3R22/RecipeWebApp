using RecipeWebApp.Data;
using RecipeWebApp.Models;

namespace RecipeWebApp.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public RecipeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public RecipeService Create(Recipe recipe)
        {
            Recipe recipeDb = applicationDbContext.Recipes.Add(recipe).Entity;
            applicationDbContext.SaveChanges();
            return recipeDb;
        }
    }
}
