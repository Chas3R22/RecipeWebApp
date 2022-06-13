using System.ComponentModel.DataAnnotations;

namespace RecipeWebApp.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<RecipeUserMapping> RecipeUserMappings { get; set; }
    }
}
