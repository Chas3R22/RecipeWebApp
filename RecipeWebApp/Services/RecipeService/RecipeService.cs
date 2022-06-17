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
        public void Create(Recipe recipe,string userId)
        {
            recipe.UserId = userId;
            this.applicationDbContext.Recipes.Add(recipe);
            this.applicationDbContext.SaveChanges();
        }
        public void Update(Recipe recipe)
        {
            this.applicationDbContext.Recipes.Update(recipe);
            this.applicationDbContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var recipe = this.applicationDbContext.Recipes.Find(id);
            this.applicationDbContext.Recipes.Remove(recipe);
            this.applicationDbContext.SaveChanges();
        }
    }
}
