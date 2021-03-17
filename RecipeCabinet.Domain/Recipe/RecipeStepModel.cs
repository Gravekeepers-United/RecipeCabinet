namespace RecipeCabinet.Domain.Recipe
{
    /// <summary>
    /// Individual step details for a recipe.
    /// </summary>
    public class RecipeStepModel
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }

    }
}
