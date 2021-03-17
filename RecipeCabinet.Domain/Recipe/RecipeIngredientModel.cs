using RecipeCabinet.Domain.Ingredient;
using RecipeCabinet.Domain.Metadata;

namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Tracking recipe ingredient details
    /// </summary>
    public class RecipeIngredientModel
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public int Ingredient { get; set; }
        public float Amount { get; set; }
        public int Measurement { get; set; }
    }
}
