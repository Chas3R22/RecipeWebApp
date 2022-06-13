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
        public void Create(Recipe recipe)
        {
            this.applicationDbContext.Recipes.Add(recipe);
            this.applicationDbContext.SaveChanges();
        }
    }
}
