using RecipeBookMini.Data.Entities;
using RecipeBookMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllAsync(string searchTerm = null, CategoryType? categoryFilter = null);
        Task CreateAsync(string name, string products, string preparationMethod, int preparationTimeMinutes, Guid categoryId, List<CategoryType> categoryTypes);
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
