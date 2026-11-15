using RecipeBookMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Data.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public CategoryType Type { get; set; }
    }
}
