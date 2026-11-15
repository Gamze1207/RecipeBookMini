using Microsoft.EntityFrameworkCore;
using RecipeBookMini.Data;
using RecipeBookMini.Data.Entities;
using RecipeBookMini.Data.Enums;
using RecipeBookMini.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeDbContext _db;

        public RecipeService(RecipeDbContext context)
        {
            _db = context;
        }

        public async Task CreateAsync(string name, string products, string preparationMethod, int preparationTimeMinutes, Guid categoryId, List<CategoryType> categoryTypes)
        {
            var recipe = new Recipe
            {
                RecipeId = Guid.NewGuid(),
                Name = name,
                PreparationMethod = preparationMethod,
                PreparationTimeMinutes = preparationTimeMinutes,
                CategoryId = categoryId,
                CategoryTypes = categoryTypes ?? new List<CategoryType>()
            };

            _db.Recipes.Add(recipe);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllAsync(string searchTerm = null, CategoryType? categoryFilter = null)
        {
            var query = _db.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .Include(r => r.Reviews)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.Name.Contains(searchTerm));
            }

            if (categoryFilter.HasValue)
            {
                query = query.Where(r => r.Category.Type == categoryFilter.Value || r.CategoryTypes.Contains(categoryFilter.Value));
            }

            return await query.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _db.Categories.OrderBy(c => c.Name).ToListAsync();
        }
    }
}
