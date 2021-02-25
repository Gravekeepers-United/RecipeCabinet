namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Individual step details for a recipe.
    /// </summary>
    public class RecipeStepModel
    {
        private int Id { get; set; }
        private int Recipe { get; set; }
        private string Description { get; set; }
        private int Order { get; set; }
        private int Type { get; set; }

    }
}
