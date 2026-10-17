using Microsoft.AspNetCore.Mvc;

namespace RecipeBookMini.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
