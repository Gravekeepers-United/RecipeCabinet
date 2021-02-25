namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Tracking recipe ingredient details
    /// </summary>
    public class RecipeIngredientModel
    {
        private int Id { get; set; }
        private Ingredient Ingredient { get; set; }
        private float Amount { get; set; }
        private Measurement Measurement { get; set; }
    }
}
