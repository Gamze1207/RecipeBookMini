using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Data.Entities
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UnitOfMeasurement { get; set; } = string.Empty;
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
