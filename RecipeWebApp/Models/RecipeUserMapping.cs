namespace RecipeWebApp.Models
{
    public class RecipeUserMapping
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }
        public User User { get; set; }

        public Guid? RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
