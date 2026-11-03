using RecipeBookMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Data.Entities
{
    public class Recipe
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Products { get; set; } = string.Empty;
        public string PreparationMethod { get; set; } = string.Empty;
        public int PreparationTimeMinutes { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<CategoryType> CategoryTypes { get; set; } = new List<CategoryType>();
    }
}
