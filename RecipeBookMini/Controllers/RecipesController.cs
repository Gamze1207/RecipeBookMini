using Microsoft.AspNetCore.Mvc;
using RecipeBookMini.Data.Enums;
using RecipeBookMini.Services.Interfaces;

namespace RecipeBookMini.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index(string searchTerm, CategoryType? categoryFilter)
        {
            var recipes = await _recipeService.GetAllAsync(searchTerm, categoryFilter);

            ViewData["SearchTerm"] = searchTerm;
            ViewData["CategoryFilter"] = categoryFilter;

            return View(recipes);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _recipeService.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string products, string preparationMethod, int preparationTimeMinutes, Guid categoryId, List<CategoryType> categoryTypes)
        {
            if (preparationTimeMinutes <= 0)
            {
                ModelState.AddModelError(nameof(preparationTimeMinutes), "Preparation time must be positive.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _recipeService.CreateAsync(name, products, preparationMethod, preparationTimeMinutes, categoryId, categoryTypes);

            return RedirectToAction(nameof(Index));
        }
    }
}
