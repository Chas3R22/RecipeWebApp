using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebApp.Data;
using RecipeWebApp.Models;
using RecipeWebApp.Services.RecipeService;

namespace RecipeWebApp.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IRecipeService recipeService;
        public RecipesController(ApplicationDbContext applicationDbContext, IRecipeService recipeService)
        {
            this.applicationDbContext = applicationDbContext;
            this.recipeService = recipeService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        { 
            List<Recipe> recipes = this.applicationDbContext.Recipes.ToList();
            return View(recipes); 
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Recipe recipe = this.applicationDbContext.Recipes.Find(id);
            if(recipe == null)
            {
                return RedirectToAction(nameof(this.Index));
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var recipe = this.applicationDbContext.Recipes.Find(id);
            this.applicationDbContext.Recipes.Remove(recipe);
            this.applicationDbContext.SaveChanges();
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var recipe = this.applicationDbContext.Recipes.Find(id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            this.applicationDbContext.Update(recipe);
            this.applicationDbContext.SaveChanges();
            return RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            this.recipeService.Create(recipe);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
