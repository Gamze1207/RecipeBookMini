using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookMini.Data.Entities
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateOnly CreatedDate { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
