using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<User> userManager;
        public RecipesController(ApplicationDbContext applicationDbContext, IRecipeService recipeService, UserManager<User> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.recipeService = recipeService;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        { 
            List<Recipe> recipes = this.applicationDbContext.Recipes
                .Include(r => r.User)
                .Select(r => new Recipe()
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    UserId = r.UserId,
                    User = new User()
                    {
                        Id = r.UserId,
                        UserName = r.User.UserName
                    }
                })
                .ToList();
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
            string userId = userManager.GetUserId(User);
            var recipe = this.applicationDbContext.Recipes.Find(id);
            if (!(recipe.UserId == userId || User.IsInRole("Admin")))
            {
                return RedirectToAction(nameof(this.Index));
            }
            else if (recipe == null)
            {
                return RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.recipeService.Delete(id);
                return RedirectToAction(nameof(this.Index));
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            string userId = userManager.GetUserId(User);
            var recipe = this.applicationDbContext.Recipes.Find(id);

            if(recipe == null)
            {
                return RedirectToAction(nameof(this.Index));
            }
            else if (!(recipe.UserId == userId || User.IsInRole("Admin")))
            {
                return RedirectToAction(nameof(this.Index));
            }
            else
            {
                return View(recipe);
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            this.recipeService.Update(recipe);
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
            string userId = userManager.GetUserId(User);
            this.recipeService.Create(recipe, userId);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
